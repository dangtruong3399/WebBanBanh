using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanBanh.Models;
namespace WebBanBanh.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        QL_BANHANGDataContext db = new QL_BANHANGDataContext();
        // admincontroller become Chart
        public ActionResult IndexChart()
        {
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                return View();
            }
        }
        // admincontroller become HomePage
        public ActionResult Index()
        {
            if(Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap","Admin");
            }
            else
            {
                ViewBag.dangnhap = Session["ss_DNuser"];
                return View();
            }
            
        }

        public ActionResult DangNhap()
        {
            if (Session["ss_DNuser"] == null)
            {
                return View();
            }
            else
            {
            
                return RedirectToAction("Index", "Admin");
            }
        }

        public ActionResult IndexProfile()
        {
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                ViewBag.dangnhap = Session["ss_DNuser"];
                ViewBag.tentk = Session["tentk"] ;
                ViewBag.tenmk = Session["tenmk"] ;
                ViewBag.tenadmin = Session["tenadmin"];
                return View();
            }

        }
        public ActionResult AdminProfile(string tk)//edit admin
        {
            ViewBag.tentk = Session["tentk"];
            var admin = db.dangnhaps.First(m => m.taikhoan == tk);
            return View(admin);
        }
        [HttpPost]
        public ActionResult EditAdminProfile(string tk, FormCollection collection)//edit admin
        {
            var admin = db.dangnhaps.First(m => m.taikhoan == tk);
            var CT_TenTK = collection["TAIKHOAN"];
            var CT_MatKhau = collection["MATKHAU"];
            var CT_TenAdmin= collection["TENADMIN"];
            if (string.IsNullOrEmpty(CT_TenTK) || string.IsNullOrEmpty(CT_MatKhau) || string.IsNullOrEmpty(CT_TenAdmin))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                admin.taikhoan = CT_TenTK;
                admin.matkhau = CT_MatKhau;
                admin.tenadmin = CT_TenAdmin;
                UpdateModel(admin);
                //db.SubmitChanges();
     
            }
            return RedirectToAction("IndexProfile");
        }
        [HttpPost]
        public ActionResult postDangNhap(FormCollection collection)
        {
            string username = collection["txtname"];
            string password = collection["txtpassword"];
            
            dangnhap checkDN = db.dangnhaps.FirstOrDefault(m => m.taikhoan == username && m.matkhau == password);
            if (checkDN == null)
                return RedirectToAction("DangNhap");
            else
            {
                Session["ss_DNuser"] = checkDN;
                Session["tentk"] = username;
                Session["tenmk"] = password;
                Session["tenadmin"] = checkDN.tenadmin;
                return RedirectToAction("Index","Admin");
               
            }
        }
        public ActionResult postLogDangNhap()
        {
                Session["ss_DNuser"] = null;
                return RedirectToAction("DangNhap", "Admin");
        }
    }
}
