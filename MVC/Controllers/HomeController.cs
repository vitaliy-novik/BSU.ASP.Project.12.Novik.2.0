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
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService service)
        {
            this.userService = service;
        }

        public ActionResult Index()
        {
            List<UserEntity> userList = new List<UserEntity>(userService.GetAllUserEntities());
            List<UserPreviewModel> viewList = new List<UserPreviewModel>();
            foreach (var item in userList)
            {
                viewList.Add(new UserPreviewModel
                {
                    Name = item.Login,
                    Photos = new List<PhotoEntity>(userService.FindPhotos(item.Login).Take(4))
                });
            }
            return View(viewList);
        }

    }
}