using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class ProfileMappers
    {
        public static DalProfile ToDalProfile(this ProfileEntity profileEntity)
        {
            return new DalProfile()
            {
                Id = profileEntity.Id,
                FirstName = profileEntity.FirstName,
                LastName = profileEntity.LastName,
                Email = profileEntity.Email,
                BirthDate = profileEntity.BirthDate,
            };
        }

        public static ProfileEntity ToBllProfile(this DalProfile dalProfile)
        {
            return new ProfileEntity()
            {
                Id = dalProfile.Id,
                FirstName = dalProfile.FirstName,
                LastName = dalProfile.LastName,
                Email = dalProfile.Email,
                BirthDate = dalProfile.BirthDate,

            };
        }
    }
}
