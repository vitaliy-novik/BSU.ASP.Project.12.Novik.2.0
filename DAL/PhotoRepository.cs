using DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using System.Linq.Expressions;
using ORM;
using System.Data.Entity;
using ORM.Models;

namespace DAL
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly DbContext context;

        public PhotoRepository(DbContext dc)
        {
            this.context = dc;
        }

        public void Create(DalPhoto e)
        {
            var photo = new Photo
            {
                Image = e.Image,
                Description = e.Description,
                LoadDate = e.LoadDate,
                User = context.Set<User>().First(u => u.Id == e.UserId),
            };
            photo.User.Profile = null;
            context.Set<Photo>().Add(photo);
        }

        public void Delete(DalPhoto e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalPhoto> FindPhoto(string login, string description = "")
        {
            return context.Set<Photo>().Where(p => p.User.Login.ToUpper() == login.ToUpper() 
            //&& p.Description.ToUpper().Contains(description.ToUpper())
            ).Select(photo => new DalPhoto()
                {
                    Id = photo.Id,
                    Image = photo.Image,
                    Description = photo.Description,
                    LoadDate = photo.LoadDate,
                    UserId = photo.User.Id,
                    LikesCount = photo.Likes.Count
                });
        }

        public IEnumerable<DalPhoto> GetAll()
        {
            return context.Set<Photo>().Select(photo => new DalPhoto()
            {
                Id = photo.Id,
                Image = photo.Image,
                Description = photo.Description,
                LoadDate = photo.LoadDate,
                UserId = photo.User.Id,
                LikesCount = photo.Likes.Count
            });
        }

        public IEnumerable<DalPhoto> GetAllByPredicate(Expression<Func<DalPhoto, bool>> f)
        {
            ParameterExpression param = f.Parameters[0];
            BinaryExpression operation = (BinaryExpression)f.Body;
            MemberExpression p = (MemberExpression)operation.Left;
            ParameterExpression newParam = Expression.Parameter(typeof(Photo), "Photo");
            MemberExpression prop = Expression.Property(newParam, p.Member.Name);
            BinaryExpression newOperation = Expression.MakeBinary(operation.NodeType, prop, operation.Right);
            Expression<Func<Photo, bool>> func = Expression.Lambda<Func<Photo, bool>>(newOperation, newParam);
            var photoList = context.Set<Photo>().Where(func);
            List<DalPhoto> dList = new List<DalPhoto>();
            if (photoList != null)
            {
                foreach (var item in photoList)
                {
                    dList.Add(new DalPhoto
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Image = item.Image,
                        LoadDate = item.LoadDate,
                        LikesCount = item.Likes.Count
                    });
                }
                return dList;                
            }
            return null;
        }

        public IEnumerable<int> GetAllPhotosId(int userId)
        {
            return context.Set<Photo>().Where(photo => photo.User.Id == userId).OrderBy(ph => ph.LoadDate).Select(p => p.Id);
        }

        public DalPhoto GetById(int key)
        {
            var photo = context.Set<Photo>().FirstOrDefault(r => r.Id == key);
            return new DalPhoto()
            {
                Id = photo.Id,
                Image = photo.Image,
                LoadDate = photo.LoadDate,
                Description = photo.Description,
                LikesCount = photo.Likes.Count
            };
        }

        public DalPhoto GetByPredicate(Expression<Func<DalPhoto, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalPhoto entity)
        {
            throw new NotImplementedException();
        }
    }
}
