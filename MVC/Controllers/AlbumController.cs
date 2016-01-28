using BLL.Interface.Entities;
using BLL.Interface.Services;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        private readonly IUserService userService;
        private static List<int> photoIdList;
        private static int current = 0;
        private static bool isMy;        

        public AlbumController(IUserService service)
        {
            this.userService = service;
            
        }

        public ActionResult Index(string id)
        {
            string login = id;
            if (id == null)
                login = User.Identity.Name;
            isMy = login == User.Identity.Name;
            List<PhotoEntity> album = new List<PhotoEntity>(userService.FindPhotos(login));
            photoIdList = new List<int>(userService.GetAllPhotosId(login));

            return View(album);
        }

        public ActionResult AddLike(int? id)
        {
            if (id != null)
                userService.AddLike(User.Identity.Name, id.Value);
            return Redirect("/Album/ViewPhoto/" + id);
        }

        public ActionResult NextPhoto(int id)
        {
            int i = photoIdList[current + id];
            return Redirect("/Album/ViewPhoto/" + i);
        }
/*
        public ActionResult ViewPhoto(int? id)
        {
            ViewBag.IsMy = isMy;
            if (id == null)
            {
                id = photoIdList[0];
                current = 0;
            }
            else
                current = photoIdList.IndexOf(id.Value);
            PhotoEntity photo = userService.GetPhotoById(photoIdList[current]);
            return PartialView(photo);

        }
*/
        public FileResult ViewPhoto(int? id)
        {
            ViewBag.IsMy = isMy;
            if (id == null)
            {
                id = photoIdList[0];
                current = 0;
            }
            else
                current = photoIdList.IndexOf(id.Value);
            PhotoEntity photo = userService.GetPhotoById(photoIdList[current]);
            return File(photo.Image, "image/jpeg");

        }

    }
}