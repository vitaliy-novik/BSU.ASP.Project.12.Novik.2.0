using BLL.Interface.Entities;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Infrastructure.Mappers
{
    public static class PhotoMappers
    {
        public static PhotoEntity ToBllPhoto(this LoadPhotoModel photo)
        {
            return new PhotoEntity()
            {
                Image = photo.Image,
                Description = photo.Description,
                LoadDate = DateTime.Now.Date
            };
        }

    }
}