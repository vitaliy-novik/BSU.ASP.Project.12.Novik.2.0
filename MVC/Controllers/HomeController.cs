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
    
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService service)
        {
            this.userService = service;
        }

        public ActionResult Index()
        {
            var users = userService.GetAllUserEntities();
            int n = users.Count();
            int pageSize = 1;
            int mp = n / pageSize;
            if (n % pageSize > 0)
                mp++;
            ViewBag.MaxPage = mp;
            ViewBag.Page = 1;
            List<UserEntity> userList = new List<UserEntity>(users.Take(pageSize));
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

        public ActionResult GetMore(int? page)
        {
            int pageSize = 1;
            var users = userService.GetAllUserEntities().Skip((page.Value-1)*pageSize);
            List<UserEntity> userList = new List<UserEntity>(users.Take(pageSize));
            List<UserPreviewModel> viewList = new List<UserPreviewModel>();
            foreach (var item in userList)
            {
                viewList.Add(new UserPreviewModel
                {
                    Name = item.Login,
                    Photos = new List<PhotoEntity>(userService.FindPhotos(item.Login).Take(4))
                });
            }
            return PartialView(viewList);
        }

    }
}