using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanBanh.Models;
namespace WebBanBanh.Controllers.admin
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        QL_BANHANGDataContext db = new QL_BANHANGDataContext();
        public ActionResult Index()
        {
            var All_KhachHang = from kh in db.KHACHHANGs select kh;
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                return View(All_KhachHang);
            }
          
        }
        public ActionResult IndexDetailKH(int id)
        {
            var Edit_KhachHang = db.KHACHHANGs.First(m => m.MAKH == id);
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                return View(Edit_KhachHang);
            }
           
        }
        [HttpPost]
        public ActionResult EditKhachHang(int id, FormCollection collection)//edit update data product
        {
            var khachhang = db.KHACHHANGs.First(m => m.MAKH == id);
            var CT_TenKH = collection["HOTEN"];
            var CT_MatKhau = collection["MATKHAU"];
            var CT_TaiKhoan = collection["TAIKHOAN"];
            var CT_DiaChi = collection["DIACHI"];
            var CT_Email = collection["EMAIL"];
            var CT_SDT = collection["SODIENTHOAI"];
            if (string.IsNullOrEmpty(CT_TenKH) || string.IsNullOrEmpty(CT_MatKhau) || string.IsNullOrEmpty(CT_TaiKhoan) || string.IsNullOrEmpty(CT_DiaChi) || string.IsNullOrEmpty(CT_Email) || string.IsNullOrEmpty(CT_SDT) )
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                khachhang.HOTEN = CT_TenKH;
                khachhang.MATKHAU = CT_MatKhau;
                khachhang.TAIKHOAN = CT_TaiKhoan;
                khachhang.DIACHI = CT_DiaChi;
                khachhang.EMAIL = CT_Email;
                khachhang.SODIENTHOAI = CT_SDT;
                UpdateModel(khachhang);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();

        }
        [HttpPost]
        public ActionResult EditKhachHang1(FormCollection collection)//edit update data product
        {
       
            var CT_MAKH = collection["MAKH"];
            var CT_TenKH = collection["HOTEN"];
            var CT_MatKhau = collection["MATKHAU"];
            var CT_TaiKhoan = collection["TAIKHOAN"];
            var CT_DiaChi = collection["DIACHI"];
            var CT_Email = collection["EMAIL"];
            var CT_SDT = collection["SODIENTHOAI"];
            var khachhang = db.KHACHHANGs.Where(m => m.MAKH == int.Parse(CT_MAKH)).First();
            if (string.IsNullOrEmpty(CT_TenKH) || string.IsNullOrEmpty(CT_MatKhau) || string.IsNullOrEmpty(CT_TaiKhoan) || string.IsNullOrEmpty(CT_DiaChi) || string.IsNullOrEmpty(CT_Email) || string.IsNullOrEmpty(CT_SDT))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                khachhang.HOTEN = CT_TenKH;
                khachhang.MATKHAU = CT_MatKhau;
                khachhang.TAIKHOAN = CT_TaiKhoan;
                khachhang.DIACHI = CT_DiaChi;
                khachhang.EMAIL = CT_Email;
                khachhang.SODIENTHOAI = CT_SDT;
                UpdateModel(khachhang);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();

        }
        [HttpPost]
        public ActionResult CreateKhachHang(FormCollection collection, KHACHHANG khachhang)
        {
            var CT_TenKH = collection["HOTEN"];
            var CT_MatKhau = collection["MATKHAU"];
            var CT_TaiKhoan = collection["TAIKHOAN"];
            var CT_DiaChi = collection["DIACHI"];
            var CT_Email = collection["EMAIL"];
            var CT_SDT = collection["SODIENTHOAI"];
            if (string.IsNullOrEmpty(CT_TenKH) || string.IsNullOrEmpty(CT_MatKhau) || string.IsNullOrEmpty(CT_TaiKhoan) || string.IsNullOrEmpty(CT_DiaChi) || string.IsNullOrEmpty(CT_Email) || string.IsNullOrEmpty(CT_SDT))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                khachhang.HOTEN = CT_TenKH;
                khachhang.MATKHAU = CT_MatKhau;
                khachhang.TAIKHOAN = CT_TaiKhoan;
                khachhang.DIACHI = CT_DiaChi;
                khachhang.EMAIL = CT_Email;
                khachhang.SODIENTHOAI = CT_SDT;
               
                db.KHACHHANGs.InsertOnSubmit(khachhang);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();
        }

        public ActionResult DeleteKhachHang(string id)
        {
            var D_DDH = db.DONDATHANGs.Where(m => m.MAKH.ToString() == id).ToList();
            foreach(var item in D_DDH)
            {
                var D_CTDDH = db.CHITIETDONDATHANGs.Where(m => m.MADDH == item.MADDH).First();
                db.CHITIETDONDATHANGs.DeleteOnSubmit(D_CTDDH);
            }
            db.DONDATHANGs.DeleteAllOnSubmit(D_DDH);
            db.SubmitChanges();


            var D_KH = db.KHACHHANGs.Where(m => m.MAKH.ToString() == id).First();
            db.KHACHHANGs.DeleteOnSubmit(D_KH);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }


    }
}
