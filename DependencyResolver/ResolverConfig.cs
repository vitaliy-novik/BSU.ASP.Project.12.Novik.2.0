using BLL.Interface.Services;
using BLL.Services;
using DAL;
using DAL.Interface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<DataContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<DataContext>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IPhotoRepository>().To<PhotoRepository>();
            kernel.Bind<ILikeRepository>().To<LikeRepository>();
            kernel.Bind<IRoleService>().To<RoleService>();
        }
    }
}
