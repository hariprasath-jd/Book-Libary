using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Libary.Controllers
{
    public class AdminPermissionController : Controller
    {
        // GET: AdminPermission
        [Route("AdminPermission")]
        public ActionResult AdminLoginPermission()
        {
                
            return View();
        }
    }
}