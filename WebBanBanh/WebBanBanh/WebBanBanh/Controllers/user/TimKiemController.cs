using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanBanh.Models;
using PagedList;
namespace WebBanBanh.Controllers.user
{
    public class TimKiemController : Controller
    {
        //
        // GET: /TimKiem/
        QL_BANHANGDataContext db = new QL_BANHANGDataContext();
        [HttpGet]
        public ActionResult KQTimKiem(string sTuKhoa, int? page)
        {
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int PageSize = 10;
            int PageNumber = (page ?? 1);
            //tìm kiếm theo tên sản phẩm
            var lstSP = db.SANPHAMs.Where(n => n.TENSP.Contains(sTuKhoa));
            ViewBag.TuKhoa = sTuKhoa;
            return View(lstSP.OrderBy(n => n.TENSP).ToPagedList(PageNumber, PageSize));
        }

        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string sTuKhoa)
        {
            //Gọi về hàm get Tìm kiếm
            return RedirectToAction("KQTimKiem", new { @sTuKhoa = sTuKhoa });
        }


    }
}
