using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LightSotre.Models;

namespace LightSotre.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private Context db = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login log)
        {
            if (ModelState.IsValid)
            {
                //var user = db.Login.Where(x => x.UserName == log.UserName && x.Passowrd == log.Passowrd).Count();
                ////var User = db.Login.FirstOrDefault(x => x.UserName == log.UserName && x.Passowrd == log.Passowrd);
                //if (user > 0)
                //{
                //    Session["UserName"] = User.UserName;
                //    return RedirectToAction("Index", "Uruns");
                //}
                var AdminInfo = db.Login.FirstOrDefault(x => x.UserName == log.UserName && x.Passowrd == log.Passowrd);
                if (AdminInfo != null)
                {
                    FormsAuthentication.SetAuthCookie(AdminInfo.UserName, false);
                    Session["UserName"] = AdminInfo.UserName;
                    if (User.IsInRole("a"))
                    {
                        return RedirectToAction("Index", "Uruns");
                    }
                    else if(User.IsInRole("b"))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("password", "The username or password is incorrect");
                }
            }
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,UserName,Passowrd,,Eposta,Role")] Login log)
        {
            if (ModelState.IsValid)
            {
                db.Login.Add(log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(log);
        }

    }
}