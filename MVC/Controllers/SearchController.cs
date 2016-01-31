using BLL.Interface.Entities;
using BLL.Interface.Services;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Controllers
{
    
    public class SearchController : Controller
    {
        private readonly IUserService userService;
        
        public SearchController(IUserService service)
        {
            this.userService = service;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchPhotoModel searcPhoto)
        {
            /*List<PhotoEntity> resultsList = new List<PhotoEntity>(
                userService.FindPhotos(searcPhoto.UserName, searcPhoto.Description));
            if (Request.IsAjaxRequest())
                return PartialView(resultsList);
                */
            return RedirectToAction("Index", "Album", new { id = searcPhoto.UserName });
        }

        public ActionResult Find(string id)
        {
            List<PhotoEntity> list = new List<PhotoEntity>(userService.FindPhotosByTag("#"+id));
            return View(list);
        }
        
    }
}