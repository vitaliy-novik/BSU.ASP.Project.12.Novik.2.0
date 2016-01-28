using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class RoleMapper
    {
        public static DalRole ToDalUser(this RoleEntity roleEntity)
        {
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Description = roleEntity.Description,
            };
        }

        public static RoleEntity ToBllRole(this DalRole dalRole)
        {
            return new RoleEntity()
            {
                Id = dalRole.Id,
                Name = dalRole.Name,
                Description = dalRole.Description,
            };
        }
    }
}
