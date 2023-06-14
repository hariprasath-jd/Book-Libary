using Book_Libary.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Book_Libary.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Models.AppContext context = new Models.AppContext();

        [Route]
        public ActionResult Login()
        {
            ViewData["UserWarning"] = "";
            ViewData["PasswdWarning"] = "";
            return View();
        }

        public ActionResult LoginValidate(FormCollection form)
        {
            string Userid = form["UserName"];
            string passwd = form["PassWord"];
            
            try
            {
                UserLoginInfo li = (from name in context.LoginDetails where name.UserName == Userid select name).First();

                if (li.UserName == Userid)
                {
                    if (li.Password == passwd)
                    {
                        return RedirectToRoute("HomePage");

                    }
                    else
                    {
                        ViewData["UserWarning"] = "";
                        ViewData["PasswdWarning"] = "Password Didn't Match";
                        return View("Login","_IndexLayout");
                    }
                }
                else
                {
                    ViewData["UserWarning"] = "User Not Found*";
                    ViewData["PasswdWarning"] = "";
                    return View("Login");
                }

            }
            catch (Exception)
            {
                ViewData["UserWarning"] = "User Not Found*";
                ViewData["PasswdWarning"] = "";
                return View("Login");
            }
        }

        [Route("Register")]
        public ActionResult Register()
        {
            ViewData["Re-Password"] = "";
            ViewData["EmailValid"] = "";
            ViewData["passLength"] = "";
            return View();
        }

        public ActionResult RegisterNextForm(FormCollection form)
        {
            string userId = form["UserName"];
            string passwd = form["PassWord"];
            string Confpasswd = form["ConfirmPassWord"];
            Regex emailRegex = new Regex(@"^\S+@\S+\.\S+$");
            if (emailRegex.IsMatch(userId))
            {
                if (passwd.Length >= 8)
                {
                    if (passwd == Confpasswd)
                    {
                        UserLoginInfo info = new UserLoginInfo() { UserName = userId, Password = passwd };
                        context.LoginDetails.Add(info);
                        ViewData["Id"] = context.LoginDetails.Find(info.Id);
                        context.SaveChanges();
                        return View("BasicInfo",info);
                    }
                    else
                    {
                        ViewData["Re-Password"] = "the Password's didn't match";
                        ViewData["EmailValid"] = "";
                        ViewData["passLength"] = "";
                        return View("Register");
                    }
                }
                else
                {
                    ViewData["passLength"] = "Password Length must be above 8 characters";
                    ViewData["Re-Password"] = "";
                    ViewData["EmailValid"] = "";
                    return View("Register");
                }
            }
            else
            {
                ViewData["EmailValid"] = "Please enter a valid Email Id";
                ViewData["Re-Password"] = "";
                ViewData["passLength"] = "";
                return View("Register");
            }
             
        }

        public ActionResult BasicInfo()
        {
            return View();
        }

        public ActionResult InfoRegister(FormCollection form)
        {
            string FirstName = form["FirstName"];
            string LastName = form["lastName"];
            string Mobile = form["MobileNo"];
            string gender = form["gender"];
            string address = form["inputAddress"] +", "+ form["inputAddress2"];
            string city = form["inputCity"];
            string State = form["inputState"];
            string Zip = form["inputZip"];
            UserLoginInfo info = new UserLoginInfo() { Id = Convert.ToInt32(ViewData["Id"]) };
            UserBasicInfo basic = new UserBasicInfo() { FirstName=FirstName,LastName = LastName,Mobile=Mobile,Gender=gender, UserInfo = info };
            UserLocationInfo location = new UserLocationInfo() { Address = address,City=city,State = State,ZipCode = Zip,UserInfo = info};
            context.BasicInfo.Add(basic);
            context.LocationInfo.Add(location);
            context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}