using BLL.Interface.Services;
using MVC.Infrastructure.Mappers;
using MVC.Models;
using MVC.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService service)
        {
            this.userService = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            var type = HttpContext.User.GetType();
            var iden = HttpContext.User.Identity.GetType();
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInModel signModel)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(signModel.Login, signModel.Password))
                //Проверяет учетные данные пользователя и управляет параметрами пользователей
                {
                    FormsAuthentication.SetAuthCookie(signModel.Login, signModel.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(signModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegisterModel regModel)
        {
            bool anyUser = userService.IsUserExist(regModel.ToBllUser());

            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View(regModel);
            }

            if (ModelState.IsValid)
            {
                var membershipUser = ((GalleryMembershipProvider)Membership.Provider)
                    .CreateUser(regModel.Login, regModel.Password, regModel.Email, regModel.FirstName,
                    regModel.LastName, regModel.BirthDate);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(regModel.Login, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(regModel);

        }
    }
}