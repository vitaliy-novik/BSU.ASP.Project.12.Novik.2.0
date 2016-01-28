using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(string login);
        RoleEntity GetUserRole(string login);
        ProfileEntity GetUserProfile(string login);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user, ProfileEntity profile);
        void DeleteUser(UserEntity user);
        bool IsUserExist(UserEntity user);
        void LoadPhoto(PhotoEntity photo, string login);
        IEnumerable<PhotoEntity> FindPhotos(string login, string description = "");
        IEnumerable<int> GetAllPhotosId(string login);
        PhotoEntity GetPhotoById(int id);
        void AddLike(string login, int phId);
    }
}
