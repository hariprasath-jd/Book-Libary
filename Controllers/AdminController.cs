using Book_Libary.Models.Admin;
using Book_Libary.Models.Inventory;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;

namespace Book_Libary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Models.AppContext context = new Models.AppContext();

        [Route("Index")]
        public ActionResult Index()
        {

            return View();
        }

        [Route("Login")]
        public ActionResult Login()
        {
            ViewData["AdminWarning"] = "";
            ViewData["AdminPasswdWarning"] = "";
            return View();
        }

        public ActionResult LoginValidate(FormCollection form)
        {
            string userid = form["Username"].ToString();
            string passwd = form["Password"].ToString();

            try
            {
                AdminLogin info = (from data in context.AdminLogins where data.AdminId == userid select data).FirstOrDefault();

                if (info.AdminId == userid)
                {
                    if (info.AdminPassword == passwd)
                    {
                        Session["UserName"] = "";
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ViewData["AdminWarning"] = "";
                        ViewData["AdminPasswdWarning"] = "Password Didn't Match";
                        return View("Login");
                    }
                }
                else
                {
                    ViewData["AdminWarning"] = "User Not Found*";
                    ViewData["AdminPasswdWarning"] = "";
                    return View("Login");
                }

            }
            catch (Exception)
            {
                ViewData["AdminWarning"] = "User Not Found*";
                ViewData["AdminPasswdWarning"] = "";
                return View("Login");
            }
        }

        [Route("Products")]
        public ActionResult Products()
        {
            var data = (from supplier in context.Genres select supplier).ToList();
            var auth = (from author in context.Authors select author).ToList();
            var prod = (from a in context.Products select a).ToList();
            ViewBag.Auhtor = auth;
            ViewBag.Genre = data;

            return View("Products", prod);
        }

        [Route("SortProduct")]
        public ActionResult SortProduct(FormCollection form)
        {

            string value1 = form["Genre"].ToString();
            string value2 = form["Author"].ToString();

            var sup = (from supplier in context.Genres select supplier).ToList();
            var auth = (from author in context.Authors select author).ToList();
            ViewBag.Auhtor = auth;
            ViewBag.Genre = sup;


            if ((value1 == "") && (value2 == ""))
            {
                var data = (from a in context.Products select a).ToList();
                return View("Products", data);
            }

            if ((value1 != "") &&  (value2 != ""))
            {
                int authint = Convert.ToInt32(value2);
                int genreint = Convert.ToInt32(value1);
                var data = (from info in context.Products where info.AuthorId == authint && info.CategoryId == genreint select info).ToList();
                return View("Products", data);
            }

            else if ((value1 != "") && (value2 == ""))
            {
                int genreint = Convert.ToInt32(value1);
                var data = (from info in context.Products where info.CategoryId == genreint select info).ToList();
                return View("Products", data);
            }

            else
            {
                int authint = Convert.ToInt32(value2);
                var data = (from info in context.Products where info.AuthorId == authint select info).ToList();
                return View("Products", data);
            }
        }

        [Route("Update")]
        public ActionResult Update(int id)
        {
            Product prd = (from y in context.Products where y.Id == id select y).First();
            ViewData["id"] = prd.Id;
            ViewData["PName"] = prd.ProductName;
            ViewData["PDescription"] = prd.ProductDescription;
            ViewData["Pprice"] = prd.ProductPrice;
            return View();
        }

        public ActionResult Updated(FormCollection form)
        {
            int id = Convert.ToInt32(form["id"]);
            string pName = form["pName"].ToString();
            string pDes = form["pDes"].ToString();
            string pPrice = form["pPrice"].ToString();

            Product prdinfo = new Product() { Id = id, ProductName = pName, ProductDescription = pDes, ProductPrice = pPrice };
            context.Products.Attach(prdinfo);
            context.Entry(prdinfo).Property(x => x.ProductName).IsModified = true;
            context.Entry(prdinfo).Property(x => x.ProductDescription).IsModified = true;
            context.Entry(prdinfo).Property(x => x.ProductPrice).IsModified = true;
            context.SaveChanges();
            return RedirectToAction("Products");
        }

        [Route("NewProduct")]
        public ActionResult AddNewProduct()
        {
            var genre = (from supplier in context.Genres select supplier).ToList();
            var auth = (from author in context.Authors select author).ToList();
            var supp = (from a in context.Suppliers select a).ToList();
            ViewBag.Author = auth;
            ViewBag.Genre = genre;
            ViewBag.Supplier = supp;

            return View();
        }
    }
}
