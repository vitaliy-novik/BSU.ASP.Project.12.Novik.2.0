using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using System.Linq.Expressions;
using System.Data.Entity;
using ORM;

namespace DAL
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext context;

        public RoleRepository(DbContext dc)
        {
            this.context = dc;
        }

        public void Create(DalRole e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalRole GetById(int key)
        {
            var role = context.Set<Role>().FirstOrDefault(r => r.Id == key);
            return new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description =role.Description
            };
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            ParameterExpression param = f.Parameters[0];
            BinaryExpression operation = (BinaryExpression)f.Body;
            MemberExpression p = (MemberExpression)operation.Left;
            ParameterExpression newParam = Expression.Parameter(typeof(Role), "Role");
            MemberExpression prop = Expression.Property(newParam, p.Member.Name);
            BinaryExpression newOperation = Expression.MakeBinary(operation.NodeType, prop, operation.Right);
            Expression<Func<Role, bool>> func = Expression.Lambda<Func<Role, bool>>(newOperation, newParam);
            var role = context.Set<Role>().FirstOrDefault(func);
            if (role != null)
                return new DalRole()
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                };
            return null;
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
