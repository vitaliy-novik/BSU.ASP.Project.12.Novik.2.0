using BLL.Interface.Services;
using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;

        public RoleService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public int GetRoleId(string name)
        {
            return uow.Roles.GetByPredicate(role => role.Name == name).Id;
        }
    }
}
