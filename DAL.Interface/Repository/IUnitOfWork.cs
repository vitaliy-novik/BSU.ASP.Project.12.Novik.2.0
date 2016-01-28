using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users {get;}
        IPhotoRepository Photos { get; }
        ILikeRepository Likes { get; }
        IRoleRepository Roles { get; }
        IProfileRepository Profiles { get; }
        void Commit();
        
    }
}
