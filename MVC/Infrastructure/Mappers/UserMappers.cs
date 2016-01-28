using BLL.Interface.Entities;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Infrastructure.Mappers
{
    public static class UserMappers
    {
        public static RegisterModel ToMvcUser(this UserEntity userEntity)
        {
            return new RegisterModel()
            {
                Login = userEntity.Login,
                Password = userEntity.Password
            };
        }

        public static UserEntity ToBllUser(this RegisterModel regModel)
        {
            return new UserEntity()
            {
                Login = regModel.Login,
                Password = regModel.Password
            };
        }

        public static ProfileEntity ToBllProfile(this RegisterModel regModel)
        {
            return new ProfileEntity()
            {
                FirstName = regModel.FirstName,
                LastName = regModel.LastName,
                Email = regModel.Email,
                BirthDate = regModel.BirthDate
            };
        }
    }
}