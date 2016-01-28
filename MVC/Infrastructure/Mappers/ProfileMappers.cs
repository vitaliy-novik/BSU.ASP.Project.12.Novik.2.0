using BLL.Interface.Entities;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Infrastructure.Mappers
{
    public static class ProfileMappers
    {
        public static ProfileModel ToProfileModel(this ProfileEntity profileEntity)
        {
            return new ProfileModel()
            {
                FirstName = profileEntity.FirstName,
                LastName = profileEntity.LastName,
                Email = profileEntity.Email,
                BirthDate = profileEntity.BirthDate,
            };
        }

        public static ProfileEntity ToBllProfile(this ProfileModel dalProfile)
        {
            return new ProfileEntity()
            {
                FirstName = dalProfile.FirstName,
                LastName = dalProfile.LastName,
                Email = dalProfile.Email,
                BirthDate = dalProfile.BirthDate,

            };
        }
    }
}