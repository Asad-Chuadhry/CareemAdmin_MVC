using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareemAdminMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            // this action is for handle post (login)
            if (ModelState.IsValidField("EmailID")&& ModelState.IsValidField("Password")) // this is check validity
            {
                using (UserDBEntities1 dc = new UserDBEntities1())
                {
                    
                    var v = dc.Users.Where(a => (a.EmailID.Equals(u.EmailID) && a.Password.Equals(u.Password))).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.UserID.ToString();
                        Session["LogedUserFullname"] = v.FullName.ToString();
                        Session["Email"] = v.EmailID.ToString();
                        return RedirectToRoute("Login", v);
                    }
                    
                }
            }
            ViewBag.Message = "No Admin with this detial";
            return View(u);
        }
        public ActionResult Logout()
        {
            Session["Email"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User U)
        {
            if (ModelState.IsValidField("EmailID")&&ModelState.IsValidField("Password")&&ModelState.IsValidField("FullName"))

            {
                using (UserDBEntities1 dc = new UserDBEntities1())
                {
                    var count = dc.Users.Where(s => s.EmailID==U.EmailID).Count();
                    if (count > 0 )
                    {
                        ViewBag.Message = "User already exists";
                        
                        return View("Register", U);
                    }
                    //you should check duplicate registration here 

                    int id = dc.Users.Max(u => u.UserID);
                    U.UserID = ++id;
                    dc.Users.Add(U);
                    dc.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully Registration Done";
                }
            }

            return View(U);
        }
    }

}