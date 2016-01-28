using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Repository;
using ORM;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext db;
        private UserRepository userRepository;
        private PhotoRepository photoRepository;
        private LikeRepository likeRepository;
        private RoleRepository roleRepository;
        private ProfileRepository profileRepository;

        public UnitOfWork(DbContext db)
        {
            this.db = db;
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IPhotoRepository Photos
        {
            get
            {
                if (photoRepository == null)
                    photoRepository = new PhotoRepository(db);
                return photoRepository;
            }
        }

        public ILikeRepository Likes
        {
            get
            {
                if (likeRepository == null)
                    likeRepository = new LikeRepository(db);
                return likeRepository;
            }
        }

        public IRoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public IProfileRepository Profiles
        {
            get
            {
                if (profileRepository == null)
                    profileRepository = new ProfileRepository(db);
                return profileRepository;
            }
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
