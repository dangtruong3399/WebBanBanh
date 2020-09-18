using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanBanh.Models;

namespace WebBanBanh.Controllers.user
{
    public class GioHangController : Controller
    {
        QL_BANHANGDataContext db = new QL_BANHANGDataContext();
        //Lấy giỏ hàng
        public List<ItemGioHang> LayGioHang()
        {
            //Giỏ hà = Session["GioHang"] as Listng  đã tồn tài
            List<ItemGioHang> lstGioHang=Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ session giỏ hàng chưa tồn tại thì khởi tạo giỏ hàng
                lstGioHang = new List<ItemGioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }



        //Thêm giỏ hàng thông thường(Load lại trang)
        public ActionResult ThemGioHang(int MaSP, string strURL)
        {
            //Có thể ràng buộc hạn chế vào một số trang
            if (Session["TAIKHOAN"] == null || Session["TAIKHOAN"].ToString() == "")
            {
                return RedirectToAction("Index", "Home");
            }

            //kiểm tra sản phẩm có tồn tại trong CSDL không
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MaSP);
            if (sp == null)
            {
                //trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }

            //lấy giỏ hàng
            List<ItemGioHang> lstGioHang = LayGioHang();
            //trường hợp 1 nếu sản phẩm đã tồn tại trong giỏ hàng
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck != null)
            {
                //kiểm tra số lượng tồn trước khi cho khách mua hàng
                if (sp.SOLUONGTON < spCheck.SoLuong)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);
            }

            ItemGioHang itemGH = new ItemGioHang(MaSP);
            if (sp.SOLUONGTON < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            lstGioHang.Add(itemGH);
            return Redirect(strURL);
        }


        //tính tổng số lượng
        public double TinhTongSoLuong()
        {
            //lấy giỏ hàng
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.SoLuong);
        }


        //tính tổng tiền
        public double TinhTongTien()
        {
            //lấy giỏ hàng
            List<ItemGioHang> lstGioHang = Session["GioHang"] as List<ItemGioHang>;
            if (lstGioHang == null)
            {
                return 0;
            }
            return lstGioHang.Sum(n => n.ThanhTien);
        }


        public ActionResult GioHangPartial()
        {
            if (TinhTongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;

                return PartialView();
            }
            ViewBag.TongSoLuong = TinhTongSoLuong();
            ViewBag.TongTien = TinhTongTien();

            return PartialView();
        }



        //
        // GET: /GioHang/

        public ActionResult XemGioHang()
        {
            //lấy giỏ hàng
            List<ItemGioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }


        [HttpGet]
        //chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang(int MaSP)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //kiểm tra sản phẩm có tồn tại trong CSDL không
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MaSP);
            if (sp == null)
            {
                //trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }

            //lấy list giỏ hàng từ session
            List<ItemGioHang> lstGioHang = LayGioHang();
            //Kiểm tra xem sản phẩm đó có tồn tại trong giỏ hàng hay không
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //lấy list giỏ hàng tạo giao diện
            ViewBag.GioHang = lstGioHang;

            //Nếu tồn tại rồi
            return View(spCheck);
        }


        //Xử lý cập nhật giỏ hàng
        [HttpPost]
        public ActionResult CapNhatGioHang(ItemGioHang itemGH)
        {

            //kiểm tra số lượng tồn
            SANPHAM spCheck = db.SANPHAMs.SingleOrDefault(n => n.MASP == itemGH.MaSP);
            if (spCheck.SOLUONGTON < itemGH.SoLuong)
            {
                return View("ThongBao");
            }

            //Cập nhật số lượng trog session giỏ hàng
            //Bước 1: lấy List<GioHang> từ session ["GioHang"]
            List<ItemGioHang> lstGH = LayGioHang();
            //Bước 2: Lấy sản phẩm cần cập nhật từ trong list<GioHang> ra
            ItemGioHang itemGHUpdate = lstGH.Find(n => n.MaSP == itemGH.MaSP);
            //Bước 3: Tiến hàng cập nhật lại số lựog cùng thành tiền
            itemGHUpdate.SoLuong = itemGH.SoLuong;
            itemGHUpdate.ThanhTien = itemGHUpdate.SoLuong * itemGHUpdate.DonGia;
            return RedirectToAction("XemGioHang");

        }

        public ActionResult XoaGioHang(int MaSP)
        {
            //Kiểm tra session giỏ hàng tồn tại chưa
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //kiểm tra sản phẩm có tồn tại trong CSDL không
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MaSP);
            if (sp == null)
            {
                //trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }

            //lấy list giỏ hàng từ session
            List<ItemGioHang> lstGioHang = LayGioHang();
            //Kiểm tra xem sản phẩm đó có tồn tại trong giỏ hàng hay không
            ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Xóa item trong giỏ hàng
            lstGioHang.Remove(spCheck);

            return RedirectToAction("XemGioHang");
        }

        //Xây dựng chức năng đặt hàng
        public ActionResult DatHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //Thêm đơn hàng
            DONDATHANG ddh = new DONDATHANG();
            ddh.NGAYDAT = DateTime.Now;
            ddh.TINHTRANGGIAOHANG = false;
            ddh.DATHANHTOAN = false;
            ddh.UUDAI = 0;
            db.DONDATHANGs.InsertOnSubmit(ddh);
            db.SubmitChanges();

            //thêm chi tiết  đơn đặt hàng
            List<ItemGioHang> lstGH = LayGioHang();
            foreach (var item in lstGH)
            {
                CHITIETDONDATHANG ctdh = new CHITIETDONDATHANG();
                ctdh.MADDH = ddh.MADDH;
                ctdh.MASP = item.MaSP;
                ctdh.TENSP = item.TenSP;
                ctdh.SOLUONG = item.SoLuong;
                ctdh.DONGIA = item.DonGia;
                db.CHITIETDONDATHANGs.InsertOnSubmit(ctdh);
            }
            db.SubmitChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XemGioHang");
        }
        //public ActionResult DatHang(KHACHHANG kh)
        //{
        //    //Kiểm tra session giỏ hàng tồn tại chưa
        //    if (Session["GioHang"] == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    KHACHHANG khang=new KHACHHANG();
        //    if (Session["TAIKHOAN"] == null)
        //    {
        //        //Thêm khách hàng vào bảng khách hàng đối với khách hàng chưa có tài khoản

        //        khang = kh;
        //        db.KHACHHANGs.Add(khang);
        //        db.SaveChanges();
        //    }
        //    else
        //    { 
        //        //đối với khách hàng  là thành viên
        //        THANHVIEN tv=Session["TAIKHOAN"] as THANHVIEN;
        //        khang.TENKH = tv.HOTEN;
        //        khang.DIACHI = tv.DIACHI;
        //        khang.EMAIL = tv.EMAIL;
        //        khang.SODIENTHOAI = tv.SODIENTHOAI;
        //        khang.MATHANHVIEN = tv.MALOAITV;
        //        db.KHACHHANGs.Add(khang);
        //        db.SaveChanges();
        //    }


        //    //THÊM đơn hàng
        //    //DONDATHANG ddh = new DONDATHANG();
        //    DONDATHANG ddh = new DONDATHANG();
        //    ddh.MAKH = khang.MAKH;
        //    ddh.NGAYDAT = DateTime.Now;
        //    ddh.TINHTRANGGIAOHANG = false;
        //    ddh.DATHANHTOAN = false;

        //    db.DONDATHANGs.Add(ddh);
        //    db.SaveChanges();

        //    //thêm chi tiết đơn đặt hàng
        //    List<ItemGioHang> lstGH = LayGioHang();
        //    foreach (var item in lstGH)
        //    {
        //        CHITIETDONDATHANG ctdh = new CHITIETDONDATHANG();
        //        ctdh.MADDH = ddh.MADDH;
        //        ctdh.MASP = item.MaSP;
        //        ctdh.TENSP = item.TenSP;
        //        ctdh.SOLUONG = item.SoLuong;
        //        ctdh.DONGIA = item.DonGia;
        //        db.CHITIETDONDATHANGs.Add(ctdh);
        //    }
        //    db.SaveChanges();
        //    Session["GioHang"] = null;

        //    return RedirectToAction("XemGioHang");
        //}
        //Thêm giỏ hàng AJAX
        //public ActionResult ThemGioHangAjax(int MaSP, string strURL)
        //{
        //    //kiểm tra sản phẩm có tồn tại trong CSDL không
        //    SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MaSP);
        //    if (sp == null)
        //    {
        //        //trang đường dẫn không hợp lệ
        //        Response.StatusCode = 404;
        //        return null;
        //    }

        //    //lấy giỏ hàng
        //    List<ItemGioHang> lstGioHang = LayGioHang();
        //    //trường hợp 1 nếu sản phẩm đã tồn tại trong giỏ hàng
        //    ItemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
        //    if (spCheck != null)
        //    {
        //        //kiểm tra số lượng tồn trước khi cho khách mua hàng
        //        if (sp.SOLUONGTON < spCheck.SoLuong)
        //        {
        //            return Content("<script> alert(\"Sản phẩm đã hết hàng!\")</script>");
        //        }
        //        spCheck.SoLuong++;
        //        spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
        //        ViewBag.TongSoLuong = TinhTongSoLuong();
        //        ViewBag.TongTien = TinhTongTien();
        //        return PartialView("GioHangPartial");
        //    }

        //    ItemGioHang itemGH = new ItemGioHang(MaSP);
        //    if (sp.SOLUONGTON < itemGH.SoLuong)
        //    {
        //        return Content("<script> alert(\"Sản phẩm đã hết hàng!\")</script>");
        //    }
        //    lstGioHang.Add(itemGH);
        //    ViewBag.TongSoLuong = TinhTongSoLuong();
        //    ViewBag.TongTien = TinhTongTien();
        //    return PartialView("GioHangPartial");
        //}


    }
}
