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
    public class LikeRepository : ILikeRepository
    {
        private readonly DbContext context;

        public LikeRepository(DbContext dc)
        {
            this.context = dc;
        }

        public int CountLikes(int id)
        {
            Photo photo = context.Set<Photo>().FirstOrDefault(p => p.Id == id);
            return photo.Likes.Count();
        }

        public void Create(DalLike e)
        {
            User user = context.Set<User>().FirstOrDefault(u => u.Login == e.Login);
            Photo photo = context.Set<Photo>().FirstOrDefault(p => p.Id == e.PhotoId);
            user.Profile = null;
            Like like = context.Set<Like>()
                .FirstOrDefault(l => l.Photo.Id == photo.Id && l.User.Id == user.Id);
            if (like == null)
                context.Set<Like>().Add(new Like
                {
                    User = user,
                    Photo = photo
                });
            else
                context.Set<Like>().Remove(like);
                
        }

        public void Delete(DalLike e)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalLike> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalLike GetById(int key)
        {
            throw new NotImplementedException();
        }

        public DalLike GetByPredicate(Expression<Func<DalLike, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Update(DalLike entity)
        {
            throw new NotImplementedException();
        }
    }
}
