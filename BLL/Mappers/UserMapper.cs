using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static DalUser ToDalUser(this UserEntity userEntity)
        {
            return new DalUser()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Password = userEntity.Password,
                RoleId = userEntity.RoleId,
                ProfileId = userEntity.ProfileId
            };
        }

        public static UserEntity ToBllUser(this DalUser dalUser)
        {
            return new UserEntity()
            {
                Id = dalUser.Id,
                Login = dalUser.Login,
                Password = dalUser.Password,
                RoleId = dalUser.RoleId,
                ProfileId = dalUser.ProfileId
            };
        }
    }
}
