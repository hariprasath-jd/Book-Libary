using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book_Libary.Controllers
{
    public class AdminNotificationController : Controller
    {
        // GET: AdminNotification
        public ActionResult Index()
        {
            return View();
        }

        [Route("NotificationIndex")]
        public ActionResult NotificationIndex()
        {

            return View("SendNotification");
        }
    }
}