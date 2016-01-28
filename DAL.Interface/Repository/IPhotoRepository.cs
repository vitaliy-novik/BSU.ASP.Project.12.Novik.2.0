using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Repository
{
    public interface IPhotoRepository : IRepository<DalPhoto>
    {
        IEnumerable<int> GetAllPhotosId(int userId);
        IEnumerable<DalPhoto> GetAllByPredicate(Expression<Func<DalPhoto, bool>> f);
        IEnumerable<DalPhoto> FindPhoto(string login, string description = "");
    }
}
