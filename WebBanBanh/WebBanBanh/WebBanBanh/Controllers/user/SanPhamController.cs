using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanBanh.Models;
using PagedList;
using System.Net;
namespace WebBanBanh.Controllers.user
{
    public class SanPhamController : Controller
    {

        // GET: /SanPham/
        QL_BANHANGDataContext db = new QL_BANHANGDataContext();
        //tạo partial view sản phẩm 1  để hiển thị sản phẩm
        [ChildActionOnly]
        public ActionResult SanPhamStyle1Partial()
        {
            return PartialView();
        }


        //Xây dựng trang xem chi tiết
        public ActionResult XemChiTiet(int? id)
        {
            //kiểm tra tham số truyền vào có rỗng hay không
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Nếu không thì truy xuất csdl lấy ra sản phẩm tương ứng
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            if (sp == null)
            {
                //Thông báo nếu như không có sản phẩm đó
                return HttpNotFound();
            }
            return View(sp);
        }

        //Xây dựng 1 action load sản phẩm theo mã loại sản phẩm và mã nhà sản xuất
        public ActionResult SanPham(int? MaLoaiSP, int? MaNSX, int? page)
        {
            //Có thể ràng buộc hạn chế vào một số trang
            //if (Session["TAIKHOAN"]==null || Session["TAIKHOAN"].ToString()=="")
            //{
            //    return RedirectToAction("Index","Home");
            //}
            if (MaLoaiSP == null || MaNSX == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Load sản phẩm dựa theo tiêu chí Mã loại sản phẩm và mã nhà sản xuất 2 trường trong bảng sản phẩm 
            var lstSP = db.SANPHAMs.Where(n => n.MALOAISP == MaLoaiSP && n.MANSX == MaNSX);
            if (lstSP.Count() == 0)
            {
                //Thông báo nếu như không có sản phẩm đó 
                return HttpNotFound();
            }
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }

            //thực hiện chức năng phân trang
            //tạo  biến số sản phẩm trên trang
            int PageSize = 6;

            //tạo biến thứ 2: số trang hiện tại
            int PageNumber = (page ?? 1);
            ViewBag.MaLoaiSP = MaLoaiSP;
            ViewBag.MaNSX = MaNSX;
            return View(lstSP.OrderBy(n => n.MASP).ToPagedList(PageNumber, PageSize));
        }


    }
}
