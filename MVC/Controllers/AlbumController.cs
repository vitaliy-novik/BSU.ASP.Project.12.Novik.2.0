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
            ViewBag.IsMy = login == User.Identity.Name;
            ViewBag.Login = login;
            int pageSize = 4;
            var photos = userService.FindPhotos(login);
            int n = photos.Count();
            int mp = n / pageSize;
            if (n % pageSize > 0)
                mp++;
            ViewBag.MaxPage = mp;
            ViewBag.Page = 1;
            List<PhotoEntity> album = new List<PhotoEntity>(photos.Take(pageSize));
            //photoIdList = new List<int>(userService.GetAllPhotosId(login));

            return View(album);
        }

        public ActionResult GetMore(string id, int? page)
        {
            string login = id;
            if (id == null)
                login = User.Identity.Name;
            int pageSize = 4;
            var photos = userService.FindPhotos(login).Skip((page.Value - 1) * pageSize);
            List<PhotoEntity> album = new List<PhotoEntity>(photos.Take(pageSize));
            return PartialView(album);
        }

        public ActionResult OneByOne(string id)
        {
            string login = id;
            if (id == null)
                login = User.Identity.Name;
            photoIdList = new List<int>(userService.GetAllPhotosId(login));
            return View(photoIdList);
        }

        public int AddLike(int? id)
        {             
            return userService.AddLike(User.Identity.Name, id.Value);
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
        [AllowAnonymous]
        public FileResult ViewPhoto(int? id)
        {
            ViewBag.IsMy = isMy;
            PhotoEntity photo = userService.GetPhotoById(id.Value);
            return File(photo.Image, "image/jpeg");

        }

    }
}