using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Libary.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Route("Home/HomePage")]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}