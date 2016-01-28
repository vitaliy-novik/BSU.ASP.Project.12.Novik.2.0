using BLL.Interface.Entities;
using BLL.Interface.Services;
using MVC.Models;
using MVC.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly IUserService userService;

        public ProfileController(IUserService service)
        {
            this.userService = service;
        }

        public ActionResult LoadPhoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadPhoto(LoadPhotoModel photo, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid && files != null)
            {
                foreach (var item in files)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(item.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(item.ContentLength);
                    }
                    photo.Image = imageData;
                    userService.LoadPhoto(photo.ToBllPhoto(), User.Identity.Name);
                }
                return Redirect("/Album/Index");
            }
            return View(photo);
        }

        // GET: Profile
        public ActionResult Index()
        {
            ProfileEntity prof = userService.GetUserProfile(User.Identity.Name);
            ProfileModel profile = prof.ToProfileModel();
            return View(profile);
        }
    }
}