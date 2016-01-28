using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using System.Linq.Expressions;
using ORM;
using System.Data.Entity;

namespace DAL
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DbContext context;

        public ProfileRepository(DbContext db)
        {
            this.context = db;
        }

        public void Create(DalProfile e)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalProfile e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalProfile> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalProfile GetById(int key)
        {
            var profile = context.Set<User>().Include("Profile").FirstOrDefault(p => p.Id == key).Profile;
            return new DalProfile()
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email,
                BirthDate = profile.BirthDate
            };
        }

        public DalProfile GetByPredicate(Expression<Func<DalProfile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalProfile entity)
        {
            throw new NotImplementedException();
        }
    }
}
