using Book_Libary.Models.Admin;
using Book_Libary.Models.Inventory;
using System;
using System.IO;
using System.Linq;
using System.Web;
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
            if (Session["name"] != null)
            {
                ViewData["TotalUser"] = (from count in context.LoginDetails select count).Count();
                ViewData["ToTalBooks"] = (from count in context.Products select count).Count();
                return View();
            }
            else
            {
                return View("PageNotAccessable");
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
                        Session["_attri"] = info.AdminAttributte;
                        Session.Timeout = 5;
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
            if (Session["name"] != null)
            {
                var data = (from supplier in context.Genres select supplier).ToList();
                var auth = (from author in context.Authors select author).ToList();
                var prod = (from a in context.Products select a).ToList();
                ViewBag.Auhtor = auth;
                ViewBag.Genre = data;

                return View("Products", prod);
            }
            else
            {
                return View("PageNotAccessable");
            }
        }

        [Route("SortProduct")]
        public ActionResult SortProduct(FormCollection form)
        {
            if (Session["name"] != null)
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
            else
            {
                return View("PageNotAccessable");
            }
        }

        [Route("Update")]
        public ActionResult Update(int id)
        {
            if (Session["name"] != null)
            {
                Product prd = (from y in context.Products where y.Id == id select y).First();
                ViewData["id"] = prd.Id;
                ViewData["PName"] = prd.ProductName;
                ViewData["PDescription"] = prd.ProductDescription;
                ViewData["Pprice"] = prd.ProductPrice;
                return View();
            }
            else
            {
                return View("PageNotAccessable");
            }
        }

        public ActionResult Updated(FormCollection form)
        {
            if (Session["name"] != null)
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
            else
            {
                return View("PageNotAccessable");
            }
        }

        [Route("NewProduct")]
        public ActionResult AddNewProduct()
        {
            if (Session["name"] != null)
            {
                var genre = (from supplier in context.Genres select supplier).ToList();
                var auth = (from author in context.Authors select author).ToList();
                var supp = (from a in context.Suppliers select a).ToList();
                ViewBag.Author = auth;
                ViewBag.Genre = genre;
                ViewBag.Supplier = supp;

                ViewBag.Message = "";
                return View();
            }
            else
            {
                return View("PageNotAccessable");
            }
        }


        public ActionResult AddedProduct(FormCollection form, HttpPostedFileBase file)
        {
            string name = form["ProductName"];
            string des = form["ProductDescription"];
            int supplierid = Convert.ToInt32(form["Supplier"]);
            int genreid = Convert.ToInt32(form["Genre"]);
            int authorid = Convert.ToInt32(form["Author"]);
            string price = form["Price"];
            var data = (from supplier in context.Genres select supplier).ToList();
            var auth = (from author in context.Authors select author).ToList();
            

            var prod = (from a in context.Products select a).ToList();
            try
            {
                string _FileName = "";
                string _path = "";
                
                if (file.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(file.FileName); 
                    _path = Path.Combine(Server.MapPath("~/Uploaded_Cover_Image/Product"), _FileName);
                    file.SaveAs(_path);


                }
                string img_path = "/Uploaded_Cover_Image"+_FileName;   
                Product product = new Product() { ProductName = name, ProductDescription = des, ProductPrice = price, ProductCoverImage = img_path, SupplierId = supplierid, AuthorId = authorid, CategoryId = genreid };
                context.Products.Add(product);
                context.SaveChanges();
                
                ViewBag.Message = "File Uploaded Successfully!!";
                return RedirectToAction("ViewProducts");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                ViewBag.Auhtor = auth;
                ViewBag.Genre = data;
                return View("ViewProducts", prod);
            }
        }

        [Route("Supplier")]
        public ActionResult ViewSupplier()
        {
            if (Session["name"] != null)
            {
                var supp = (from a in context.Suppliers select a).ToList();
                return View(supp);
            }
            else
            {
                return View("PageNotAccessable");
            }
        }

        [Route("AddSupplier")]
        public ActionResult AddSupplier()
        {
            if (Session["name"] != null)
            {
                ViewBag.Bool = false;
                return View();
            }
            else
            {
                return View("PageNotAccessable");
            }
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
            if (Session["name"] != null)
            {
                ViewBag.Validation = false;
                ViewBag.result = false;
                var genre = (from g in context.Genres select g).ToList();
                return View(genre);
            }
            else
            {
                return View("PageNotAccessable");
            }
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
                return View("ViewGenre", genremodal);
            }
            else
            {
                ViewBag.result = false;
                ViewBag.Validation = true;
                var genremodal = (from g in context.Genres select g).ToList();
                return View("ViewGenre", genremodal);
            }
        }

        public ActionResult UpdateGenre(int id)
        {
            Genre gen = (from gg in context.Genres where gg.Id == id select gg).FirstOrDefault();
            ViewData["id"] = gen.Id;
            ViewData["GenreType"] = gen.GerneType;
            ViewData["GenreDes"] = gen.GenreDescription;
            return View();
        }

        public ActionResult AfterGenreUpdate(FormCollection form)
        {
            int id = Convert.ToInt32(form["Id"]);
            string name = form["GenreType"].ToString();
            string des = form["GenreDes"].ToString();
            Genre gen = new Genre() { Id = id, GerneType = name, GenreDescription = des };
            context.Genres.Attach(gen);
            context.Entry(gen).Property(x => x.GerneType).IsModified = true;
            context.Entry(gen).Property(x => x.GenreDescription).IsModified = true;
            context.SaveChanges();
            ViewBag.Validation = false;
            ViewBag.result = true;
            var genre = (from g in context.Genres select g).ToList();
            return View("ViewGenre",genre);
        }     
        [Route("Author")]
        public ActionResult ViewAuthor()
        {
            var auhtor = (from auth in context.Authors select auth).ToList();
            return View(auhtor);
        }

        [Route("AddAuthor")]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        [Route("InsertAuthor")]
        public String InsertAuthor()
        {
            string authorName = Request.Form["AuthorName"];
            string authorDescription = Request.Form["AuthorDescription"];
            var file = Request.Files["AuthorImage"];
            string _FileName = "";
            string _path = "";

            if (file.ContentLength > 0)
            {
                _FileName = Path.GetFileName(file.FileName);
                _path = Path.Combine(Server.MapPath("~/Uploaded_Cover_Image/Author/"), _FileName);
                file.SaveAs(_path);
            }
            
            string img_path = "/Uploaded_Cover_Image/Author/" + _FileName;
            Author auth = new Author() { AuthorName = authorName, AuthorDescription = authorDescription, AuthorImage = img_path };
            context.Authors.Add(auth);
            context.SaveChanges();

            ViewBag.Message = "File Uploaded Successfully!!";
            return "pass";
        }

        public ActionResult UpdateAuthor(int id)
        {
            Author gen = (from gg in context.Authors where gg.Id == id select gg).FirstOrDefault();
            ViewData["id"] = gen.Id;
            ViewData["GenreType"] = gen.AuthorName;
            ViewData["GenreDes"] = gen.AuthorDescription;
            return View();
        }

        [Route("AddAdmin")]
        public ActionResult AddAdmin()
        {
            if (Session["_attri"].ToString() == "S")
            {
                ViewBag.AdminError = "";
                return View();
            }
            else
            {
                return View("AdminWarning");
            }
        }

        [Route("CreateAdmin")]
        public ActionResult AdminDetails(FormCollection form)
        {
            string adminid = form["AdminName"];
            string Adminpass = form["AdminPassword"];
            string retype = form["Re-Type"];
            string admintype = form["PermissionType"];
            if ((adminid != "") || (Adminpass != "") || (retype != "") || (admintype != ""))
            {
                if (Adminpass == retype)
                {
                    AdminLogin al = new AdminLogin() { AdminId = adminid, AdminPassword = Adminpass, AdminAttributte = admintype };
                    context.AdminLogins.Add(al);
                    context.SaveChanges();
                    ViewBag.AdminError = "Admin Added";
                    return View("AddAdmin");
                }
                else
                {
                    ViewBag.AdminError = "Admin not added";
                    return View("AddAdmin");
                }
            }
            else
            {
                ViewBag.AdminError = "Please fill All the field";
                return View("AddAdmin");
            }
        }

        [Route("Logout")]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
  