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
                
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchPhotoModel searcPhoto)
        {
            List<PhotoEntity> resultsList = new List<PhotoEntity>(
                userService.FindPhotos(searcPhoto.UserName, searcPhoto.Description));
            
            return PartialView(resultsList);
        }
        
    }
}