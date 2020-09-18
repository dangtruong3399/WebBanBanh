using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanBanh.Models;
namespace WebBanBanh.Controllers.admin
{
    public class DonDatHangController : Controller
    {
        // GET: /KhachHang/
        QL_BANHANGDataContext db = new QL_BANHANGDataContext();
        public ActionResult Index()
        {
            var All_KH = (from mkh in db.KHACHHANGs select mkh).ToList();
            var All_DonDatHang = from ddh in db.DONDATHANGs select ddh;
            var All_CTDonDatHang = (from ctddh in db.CHITIETDONDATHANGs select ctddh).ToList();
            var All_SP = (from sp in db.SANPHAMs select sp).ToList();
            ViewBag.KhachHang = (List<KHACHHANG>)All_KH;
            ViewBag.CTDDH = (List<CHITIETDONDATHANG>)All_CTDonDatHang;
            ViewBag.SANPHAM = (List<SANPHAM>)All_SP;
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                ViewBag.dangnhap = Session["ss_DNuser"];
                return View(All_DonDatHang);
            }
          
        }
        public ActionResult IndexDetailDDH(int id)
        {
            var All_KH = (from mkh in db.KHACHHANGs select mkh).ToList();
            var All_DonDatHang = from ddh in db.DONDATHANGs select ddh;
            var All_CTDonDatHang = (from ctddh in db.CHITIETDONDATHANGs select ctddh).ToList();
            var All_SP = (from sp in db.SANPHAMs select sp).ToList();
            ViewBag.KhachHang = (List<KHACHHANG>)All_KH;
            ViewBag.CTDDH = (List<CHITIETDONDATHANG>)All_CTDonDatHang;
            ViewBag.SANPHAM = (List<SANPHAM>)All_SP;
            var Edit_DonDatHang = db.DONDATHANGs.Where(m => m.MADDH == id);

            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                ViewBag.dangnhap = Session["ss_DNuser"];
                return View(Edit_DonDatHang);
            }

        }
        public ActionResult IndexDetailChiTietDDH(int id)
        {
            var All_KH = (from mkh in db.KHACHHANGs select mkh).ToList();
            var All_DonDatHang = from ddh in db.DONDATHANGs select ddh;
            var All_CTDonDatHang = (from ctddh in db.CHITIETDONDATHANGs select ctddh).ToList();
            var All_SP = (from sp in db.SANPHAMs select sp).ToList();
            ViewBag.KhachHang = (List<KHACHHANG>)All_KH;
            ViewBag.CTDDH = (List<CHITIETDONDATHANG>)All_CTDonDatHang;
            ViewBag.SANPHAM = (List<SANPHAM>)All_SP;
            var Edit_DonDatHang = db.CHITIETDONDATHANGs.First(m => m.MACHITIETDDH == id);
     
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                ViewBag.dangnhap = Session["ss_DNuser"];
                return View(Edit_DonDatHang);
            }
        }
        [HttpPost]
        public ActionResult EditDonDatHang(int id, FormCollection collection)//edit update data product
        {
            try
            {
                var dondathang = db.DONDATHANGs.First(m => m.MADDH == id);
                var CT_NgayDat = collection["NGAYDAT"];
                var CT_TinhTrang = collection["TINHTRANGGIAOHANG"];
                var CT_NgayGiao = collection["NGAYGIAO"];
                var CT_DaThanhToan = collection["DATHANHTOAN"];
                var CT_MaKh = collection["MAKH"];
                var CT_UuDai = collection["UUDAI"];
                if (string.IsNullOrEmpty(CT_NgayDat) || string.IsNullOrEmpty(CT_TinhTrang) || string.IsNullOrEmpty(CT_NgayGiao) || string.IsNullOrEmpty(CT_DaThanhToan) || string.IsNullOrEmpty(CT_MaKh) || string.IsNullOrEmpty(CT_UuDai))
                    ViewData["Loi"] = "Không Được Để Trống";
                else
                {
                    if(CT_TinhTrang == "yes")
                        dondathang.TINHTRANGGIAOHANG = true;
                    else
                        dondathang.TINHTRANGGIAOHANG = false;
                    if (CT_DaThanhToan == "yes")
                        dondathang.DATHANHTOAN = true;
                    else
                        dondathang.DATHANHTOAN = false;
                    dondathang.NGAYDAT = DateTime.ParseExact(CT_NgayDat, "dd/MM/yyyy", null);
                    dondathang.NGAYGIAO = DateTime.ParseExact(CT_NgayGiao, "dd/MM/yyyy", null);
                
                    dondathang.MAKH = int.Parse(CT_MaKh);
                    dondathang.UUDAI = int.Parse(CT_UuDai);
                    UpdateModel(dondathang);
                    db.SubmitChanges();
                    string script = "alert('thanh cong')";
                     JavaScript(script);
                    return RedirectToAction("Index");
                }
            }
            catch (ApplicationException ex)
            {
                string script = "alert('that bai')";
                return JavaScript(script);
            }
            return this.Index();

        }
        [HttpPost]
        public ActionResult CreateDonDatHang(FormCollection collection, DONDATHANG dondathang)
        {
            var CT_NgayDat = collection["NGAYDAT"];
            var CT_TinhTrang = collection["TINHTRANGGIAOHANG"];
            var CT_NgayGiao = collection["NGAYGIAO"];
            var CT_DaThanhToan = collection["DATHANHTOAN"];
            var CT_MaKh = collection["MAKH"];
            var CT_UuDai = collection["UUDAI"];
            
            if (string.IsNullOrEmpty(CT_NgayDat) || string.IsNullOrEmpty(CT_TinhTrang) || string.IsNullOrEmpty(CT_NgayGiao) || string.IsNullOrEmpty(CT_DaThanhToan) || string.IsNullOrEmpty(CT_MaKh) || string.IsNullOrEmpty(CT_UuDai))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                if (CT_TinhTrang == "yes")
                    dondathang.TINHTRANGGIAOHANG = true;
                else
                    dondathang.TINHTRANGGIAOHANG = false;
                if (CT_DaThanhToan == "yes")
                    dondathang.DATHANHTOAN = true;
                else
                    dondathang.DATHANHTOAN = false;
                dondathang.NGAYDAT = DateTime.ParseExact(CT_NgayDat, "dd/MM/yyyy", null);
                dondathang.NGAYGIAO = DateTime.ParseExact(CT_NgayGiao, "dd/MM/yyyy", null);
                
                dondathang.MAKH = int.Parse(CT_MaKh);
                dondathang.UUDAI = int.Parse(CT_UuDai);

                db.DONDATHANGs.InsertOnSubmit(dondathang);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();
        }
        public ActionResult CreateChiTietDonDatHang(FormCollection collection, CHITIETDONDATHANG ctdh)
        {
            var CT_MAHDD = collection["MADDH"];
            var CT_TENSP = collection["TENSP"];
            var CT_MASP = collection["MASP"];
            var CT_SOLUONG = collection["SOLUONG"];
            var CT_DONGIA = collection["DONGIA"];
           
            ctdh.MADDH = int.Parse(CT_MAHDD);
            ctdh.TENSP = CT_TENSP;
            ctdh.MASP = int.Parse(CT_MASP);
            ctdh.SOLUONG = int.Parse(CT_SOLUONG);
            ctdh.DONGIA = int.Parse(CT_DONGIA);
            db.CHITIETDONDATHANGs.InsertOnSubmit(ctdh);
            db.SubmitChanges();
            return RedirectToAction("Index");
    
        }

        public ActionResult DeleteDonDatHang(string id)
        {
            var D_CTDDH = db.CHITIETDONDATHANGs.Where(m => m.MADDH.ToString() == id).ToList();
            db.CHITIETDONDATHANGs.DeleteAllOnSubmit(D_CTDDH);
            db.SubmitChanges();

            var D_DDH = db.DONDATHANGs.Where(m => m.MADDH.ToString() == id).ToList();
            db.DONDATHANGs.DeleteAllOnSubmit(D_DDH);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteChiTietDonDatHang(string id)
        {
            var D_CTDDH = db.CHITIETDONDATHANGs.Where(m => m.MACHITIETDDH.ToString() == id).ToList();
            db.CHITIETDONDATHANGs.DeleteAllOnSubmit(D_CTDDH);
            db.SubmitChanges();
            
            return RedirectToAction("Index");
        }


    }
}
