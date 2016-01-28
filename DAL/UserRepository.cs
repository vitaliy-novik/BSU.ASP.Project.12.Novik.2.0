using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext context;

        public UserRepository(DbContext u)
        {
            this.context = u;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return context.Set<User>().Select(user => new DalUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                ProfileId = user.Profile.Id
            });
        }

        public DalUser GetById(int key)
        {
            var user = context.Set<User>().FirstOrDefault(ormuser => ormuser.Id == key);
            return new DalUser()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                ProfileId = user.Profile.Id
            };
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            ParameterExpression param = f.Parameters[0];            
            BinaryExpression operation = (BinaryExpression)f.Body;
            MemberExpression p = (MemberExpression)operation.Left;
            ParameterExpression newParam = Expression.Parameter(typeof(User), "User");
            MemberExpression prop = Expression.Property(newParam, p.Member.Name);
            BinaryExpression newOperation = Expression.MakeBinary(operation.NodeType, prop, operation.Right);
            Expression<Func<User, bool>> func = Expression.Lambda<Func<User, bool>>(newOperation, newParam);
            var user = context.Set<User>().FirstOrDefault(func);
            if (user != null)
            {
                return new DalUser()
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    //ProfileId = user.Profile.Id
                };
            }
            return null;
        }

        public void Create(DalUser e)
        {
            var prof = new UserProfile()
            {
                FirstName = e.Profile.FirstName,
                LastName = e.Profile.LastName,
                Email = e.Profile.Email,
                BirthDate = e.Profile.BirthDate
            };
            var user = new User()
            {
                Login = e.Login,
                Password = e.Password,
                Roles = new HashSet<Role> { context.Set<Role>().FirstOrDefault(r => r.Id == e.RoleId) },
                Profile = prof
            };
            context.Set<User>().Add(user);
            //context.Set
        }

        public void Delete(DalUser e)
        {
            var user = new User()
            {
                Id = e.Id,
                Login = e.Login,
                Password = e.Password
            };
            user = context.Set<User>().Single(u => u.Id == user.Id);
            context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
