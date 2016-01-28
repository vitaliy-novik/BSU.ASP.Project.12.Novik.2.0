using BLL.Interface.Entities;
using BLL.Interface.Services;
using MVC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Providers
{
    public class GalleryRoleProvider : RoleProvider
    {
        private IUserService userService => 
            (IUserService) System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));

        public override string[] GetRolesForUser(string login)
        {
            string[] role = new string[] { };
            RoleEntity re = userService.GetUserRole(login);
            if (re != null)
                role = new string[] { re.Name };
            return role;
        }

        public override bool IsUserInRole(string login, string roleName)
        {
            bool outputResult = false;
            RoleEntity re = userService.GetUserRole(login);
            if (re != null && re.Name == roleName)
                 outputResult = true;
            return outputResult;
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}