using BLL.Interface.Entities;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class PhotoMappers
    {
        public static DalPhoto ToDalPhoto(this PhotoEntity p)
        {
            return new DalPhoto()
            {
                Id = p.Id,
                Image = p.Image,
                Description = p.Description,
                LoadDate = p.LoadDate,
                UserId = p.UserId,
                LikesCount = p.likesNumber
            };
        }

        public static PhotoEntity ToBllPhoto(this DalPhoto p)
        {
            return new PhotoEntity()
            {
                Id = p.Id,
                Image = p.Image,
                Description = p.Description,
                LoadDate = p.LoadDate,
                UserId = p.UserId,
                likesNumber = p.LikesCount
            };
        }
    }
}
