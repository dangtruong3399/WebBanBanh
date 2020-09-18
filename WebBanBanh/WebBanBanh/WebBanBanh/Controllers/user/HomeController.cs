using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanBanh.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;
namespace WebBanBanh.Controllers.user
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QL_BANHANGDataContext db = new QL_BANHANGDataContext();
        public ActionResult Index()
        {
            //Lần lượt  tạo các viewbag để lấy list  sản phẩm từ cơ sỏ dữ liệu
            //List bánh kem
            var lstBKM = db.SANPHAMs.Where(n => n.MALOAISP == 1);
            //Gán vào viewbag
            ViewBag.ListBKM = lstBKM;

            //List bánh kem
            var lstBQM = db.SANPHAMs.Where(n => n.MALOAISP == 2);
            //Gán vào viewbag
            ViewBag.ListBQM = lstBQM;

            //List bánh kem
            var lstBMM = db.SANPHAMs.Where(n => n.MALOAISP == 3);
            //Gán vào viewbag
            ViewBag.ListBMM = lstBMM;


            return View();
        }

        public ActionResult MenuPartial()
        {
            //truy vấn lấy về 1 list các sản phẩm 
            var lstSP = db.SANPHAMs;
            return PartialView(lstSP);
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh, FormCollection f)
        {
            //kiểm tra captcha hợp lệ
          
                ViewBag.ThongBao = "Thêm thành công";
                //Thêm khách hàng vào csdl
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
            
            ViewBag.ThongBao = "Sai mã captcha";
            return View();
        }


        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            //kiểm tra  tên đăng nhập và mật khẩu
            string sTaiKhoan = f["txtTenDangNhap"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();

            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TAIKHOAN == sTaiKhoan && n.MATKHAU == sMatKhau);
            if (kh != null)
            {
                Session["TAIKHOAN"] = kh;
                return Content("<script>window.location.reload();</script>");
                //return RedirectToAction("Index");
            }

            return Content("tài khoản hoặc mật khẩu không đúng!");
            //return RedirectToAction("Index");
        }


        public ActionResult DangXuat(FormCollection f)
        {
            Session["TAIKHOAN"] = null;
            Session["GIOHANG"] = null;
            return RedirectToAction("Index");
        }
    }
}
