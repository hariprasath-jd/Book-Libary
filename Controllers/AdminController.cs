using Book_Libary.Models.Admin;
using Book_Libary.Models.Inventory;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Policy;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Book_Libary.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Models.AppContext context = new Models.AppContext();

        [Route("Index")]
        public ActionResult Index()
        {
            if (Session["name"] != null)
            {
                ViewData["TotalUser"] = (from count in context.LoginDetails select count).Count();
                ViewData["ToTalBooks"] = (from count in context.Products select count).Count();
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
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
                        Session["name"] = userid;
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

        [Route("ViewProducts")]
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

            if ((value1 != "") && (value2 != ""))
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


        public ActionResult AddedProduct()
        {
            return View();
        }

        [Route("Supplier")]
        public ActionResult ViewSupplier()
        {
            var supp = (from a in context.Suppliers select a).ToList();
            return View(supp);
        }

        [Route("AddSupplier")]
        public ActionResult AddSupplier()
        {
            ViewBag.Bool = false;
            return View();
        }

        public ActionResult InsertSupplier(FormCollection form)
        {
            try
            {
                string supname = form["SupplierName"];
                string supemail = form["SupplierEmail"];
                string supmobile = form["SupplierMobile"];
                string supdes = form["SupplierDescription"];
                if ((supdes == "") || (supemail == "") || (supmobile == "") || (supname == ""))
                {
                    ViewBag.Bool = true;
                    return View("AddSupplier");
                }
                else
                {
                    Supplier supplier = new Supplier() { SupplierName = supname, SupplierEmail = supemail, SupplierPhone = supmobile, SupplierDescription = supdes };
                    context.Suppliers.Add(supplier);
                    context.SaveChanges();
                    ViewBag.Bool = false;
                    return View("AddSupplier");
                }
            }
            catch (Exception)
            {
                ViewBag.Bool = true;
                return View("AddSupplier");
            }
        }
        public ActionResult UpdateSupplier(int id)
        {
            Supplier supplier = (from y in context.Suppliers where y.Id == id select y).First();
            ViewData["id"] = supplier.Id;
            ViewData["SupName"] = supplier.SupplierName;
            ViewData["SupMobile"] = supplier.SupplierPhone;
            ViewData["SupEmail"] = supplier.SupplierEmail;
            ViewData["SupDescription"] = supplier.SupplierDescription;
            return View();
        }

        public ActionResult UpdateResult(FormCollection form)
        {
            int id = Convert.ToInt32(form["Id"]);
            string name = form["SupName"];
            string mobile = form["SupMobile"];
            string email = form["SupEmail"];
            string Des = form["SupDescription"];
            Supplier sup = new Supplier() { Id = id, SupplierName = name, SupplierPhone = mobile, SupplierEmail = email, SupplierDescription = Des };
            context.Suppliers.Attach(sup);
            context.Entry(sup).Property(x => x.SupplierName).IsModified = true;
            context.Entry(sup).Property(x => x.SupplierPhone).IsModified = true;
            context.Entry(sup).Property(x => x.SupplierEmail).IsModified = true;
            context.Entry(sup).Property(x => x.SupplierDescription).IsModified = true;
            context.SaveChanges();
            return RedirectToAction("ViewSupplier");
        }

        [Route("Genre")]
        public ActionResult ViewGenre()
        {
            ViewBag.Validation = false;
            ViewBag.result = false;
            var genre = (from g in context.Genres select g).ToList();
            return View(genre);
        }

        public ActionResult AddGenre(FormCollection form)
        {
            string name = form["GenreName"];
            string description = form["GenreDescription"];
            if ((name != "") || (description != ""))
            {
                ViewBag.Validation = false;
                ViewBag.result = true;
                Genre genre = new Genre() { GerneType = name, GenreDescription = description };
                context.Genres.Add(genre);
                context.SaveChanges();
                var genremodal = (from g in context.Genres select g).ToList();
                return View("ViewGenre",genremodal);
            }
            else
            {
                ViewBag.result = false;
                ViewBag.Validation = true;
                var genremodal = (from g in context.Genres select g).ToList();
                return View("ViewGenre", genremodal);
            }
        }

        [Route("Author")]
        public ActionResult ViewAuthor()
        {
            var auhtor = (from auth in context.Authors select auth).ToList();
            return View(auhtor);
        }





    }
}
