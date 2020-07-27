using DataLibrary.DataAccess;
using DataLibrary.Logic;
using NatureBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NatureBox.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel data)
        {
            if(ModelState.IsValid)
            {
                if (UsersProccessor.Login("NatureBoxDB", "Users", data.Email, data.Password) == true)
                {
                   
                    Session["UserName"] = data.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    data.Errormessege = "Email Adress or password incorrect";
                    return View(data);
                }
            }
            return View();
        }


        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(RegisterModel user)
        {
            if (ModelState.IsValid)
            {

                if (UsersProccessor.Validate("NatureBoxDB","Users",user.Email) == true)
                {
                    user.ErrorMessege = "Your Email is invalide!";
                    return View(user);
                }
                else
                {

                    Session["UserName"] = user.FirstName + " " + user.LastName;
                    string x = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVxXyYzZ0123456789";
                    string token = null;
                    Random rn = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        token = token + x[rn.Next(x.Length)];
                    }

                    UsersProccessor.CreateUser("NatureBoxDB", "Users", user.FirstName, user.LastName,
                                                user.Email, 1, token, user.Password);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }
    }
}