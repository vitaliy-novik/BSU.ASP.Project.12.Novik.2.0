using BLL.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using DAL.Interface.Repository;
using BLL.Mappers;
using DAL.Interface.DTO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;

        public UserService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public UserEntity GetUserEntity(string login)
        {
            var user = uow.Users.GetByPredicate(dalUser => dalUser.Login == login);
            if (user != null)
                return user.ToBllUser();
            return null;
        }

        public ProfileEntity GetUserProfile(string login)
        {
            UserEntity user = uow.Users.GetByPredicate(dalUser => dalUser.Login == login).ToBllUser();
            ProfileEntity profile = uow.Profiles.GetById(user.Id).ToBllProfile();
            return profile;
        }

        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return uow.Users.GetAll().Select(user => user.ToBllUser());
        }

        public void CreateUser(UserEntity user, ProfileEntity profile)
        {
            DalUser du = user.ToDalUser();
            du.Profile = profile.ToDalProfile();
            DalProfile dp = profile.ToDalProfile();
            dp.User = user.ToDalUser();
            uow.Users.Create(du);
            //uow.Profiles.Create(dp);
            uow.Commit();
        }

        public void DeleteUser(UserEntity user)
        {
            uow.Users.Delete(user.ToDalUser());
            uow.Commit();
        }

        public RoleEntity GetUserRole(string login)
        {
            UserEntity user = uow.Users.GetByPredicate(dalUser => dalUser.Login == login).ToBllUser();
            RoleEntity role = uow.Roles.GetById(user.RoleId).ToBllRole();
            return role;
        }

        public bool IsUserExist(UserEntity user)
        {
            return uow.Users.GetAll().Any(u => u.Login == user.Login);
        }

        public void LoadPhoto(PhotoEntity photo, string login)
        {
            DalUser user = uow.Users.GetByPredicate(dalUser => dalUser.Login == login);
            DalPhoto dalPhoto = photo.ToDalPhoto();
            dalPhoto.UserId = user.Id;
            uow.Photos.Create(dalPhoto);
            uow.Commit();
        }

        public IEnumerable<PhotoEntity> FindPhotos(string login, string description = "")
        {
            return uow.Photos.FindPhoto(login, description).Select(p => p.ToBllPhoto());
        }

        public IEnumerable<int> GetAllPhotosId(string login)
        {
            var user = uow.Users.GetByPredicate(dalUser => dalUser.Login == login);
            return uow.Photos.GetAllPhotosId(user.Id);
        }

        public PhotoEntity GetPhotoById(int id)
        {
            return uow.Photos.GetById(id).ToBllPhoto();
        }

        public void AddLike(string login, int phId)
        {
            uow.Likes.Create(new DalLike
            {
                Login = login,
                PhotoId = phId
            });
            uow.Commit();
        }

    }
}
