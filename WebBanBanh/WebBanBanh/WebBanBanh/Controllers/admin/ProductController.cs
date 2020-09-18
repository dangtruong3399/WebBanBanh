using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanBanh.Models;
//using System.;
namespace WebBanBanh.Controllers.admin
{
    public class ProductController : Controller
    {
        QL_BANHANGDataContext sqlconnect = new QL_BANHANGDataContext();
        //
        // GET: /Product/
        //Page Edit Data Detail Product
        public ActionResult IndexProdDetail(int id)
        {
            var All_LoaiSP = (from loaisp in sqlconnect.LOAISANPHAMs select loaisp).ToList();
            var All_NSX = (from nsx in sqlconnect.NHASANXUATs select nsx).ToList();
            ViewBag.LoaiSP = (List<LOAISANPHAM>)All_LoaiSP;
            ViewBag.NhaSX = (List<NHASANXUAT>)All_NSX;
            var Edit_product = sqlconnect.SANPHAMs.Where(m => m.MASP == id).ToList();
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                return View(Edit_product);
            }
            //return View(Edit_product);
        }
        public ActionResult IndexNSXDetail(int id)
        {
            var All_NSX = sqlconnect.NHASANXUATs.First(m => m.MANSX == id);
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                return View(All_NSX);
            }
        }
        public ActionResult IndexLoaiSpDetail(int id)
        {
            var Edit_LoaiSP = sqlconnect.LOAISANPHAMs.First(m => m.MALOAISP == id);
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                return View(Edit_LoaiSP);
            }
        }
        [HttpPost]
        public ActionResult EditProduct(int id,FormCollection collection)//edit update data product
        {
            var product = sqlconnect.SANPHAMs.First(m => m.MASP == id);
            var CT_TenSP = collection["TenSP"];
            var CT_DonGia = collection["DonGia"];
            var CT_MoTa = collection["MoTa"];
            var CT_HinhAnh = collection["HinhAnh"];
            var CT_SoLuongTon = collection["SoLuongTon"];
            var CT_MaLoaiSP = collection["MaLoaiSP"];
            var CT_MaNSX = collection["MaNSX"];
            var CT_NguyenLieuBanh = collection["NguyenLieuBanh"];
            if (string.IsNullOrEmpty(CT_TenSP) || string.IsNullOrEmpty(CT_DonGia) || string.IsNullOrEmpty(CT_MoTa) || string.IsNullOrEmpty(CT_HinhAnh) || string.IsNullOrEmpty(CT_SoLuongTon) || string.IsNullOrEmpty(CT_MaLoaiSP) || string.IsNullOrEmpty(CT_MaNSX))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                product.TENSP = CT_TenSP;
                DateTime now = DateTime.Now;
       
                product.NGAYCAPNHAT = now;
                product.DONGIA = int.Parse(CT_DonGia);
                product.MOTA = CT_MoTa;
                product.HINHANH = CT_HinhAnh;
                product.SOLUONGTON = int.Parse(CT_SoLuongTon);
                product.MALOAISP = int.Parse(CT_MaLoaiSP);
                product.MANSX = int.Parse(CT_MaNSX);
                UpdateModel(product);
                sqlconnect.SubmitChanges();
                return RedirectToAction("IndexProdDetail");
            }
            return this.Index();


        }
        [HttpPost]
        public ActionResult EditProduct111( FormCollection collection)//edit update data product
        {
            var CT_MaSP = collection["MASP"];
            var CT_TenSP = collection["TenSP"];
            var CT_DonGia = collection["DonGia"];
            var CT_MoTa = collection["MoTa"];
            var CT_HinhAnh = collection["HinhAnh"];
            var CT_SoLuongTon = collection["SoLuongTon"];
            var CT_MaLoaiSP = collection["MaLoaiSP"];
            var CT_MaNSX = collection["MaNSX"];
            var CT_NguyenLieuBanh = collection["NguyenLieuBanh"];
            var product = sqlconnect.SANPHAMs.First(m => m.MASP == int.Parse(CT_MaSP));
         
            if (string.IsNullOrEmpty(CT_TenSP) || string.IsNullOrEmpty(CT_DonGia) || string.IsNullOrEmpty(CT_MoTa) || string.IsNullOrEmpty(CT_HinhAnh) || string.IsNullOrEmpty(CT_SoLuongTon) || string.IsNullOrEmpty(CT_MaLoaiSP) || string.IsNullOrEmpty(CT_MaNSX))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                product.TENSP = CT_TenSP;
                DateTime now = DateTime.Now;

                product.NGAYCAPNHAT = now;
                product.DONGIA = int.Parse(CT_DonGia);
                product.MOTA = CT_MoTa;
                product.HINHANH = CT_HinhAnh;
                product.SOLUONGTON = int.Parse(CT_SoLuongTon);
                product.MALOAISP = int.Parse(CT_MaLoaiSP);
                product.MANSX = int.Parse(CT_MaNSX);
                UpdateModel(product);
                sqlconnect.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();


        }
        [HttpPost]
        public ActionResult EditLoaiSP(int id,FormCollection collection)//edit update data loaisp
        {
          
            var CT_TenLoaiSP = collection["tenloai"];
            var CT_Icon = collection["icon"];
            var loaiSP = sqlconnect.LOAISANPHAMs.First(m => m.MALOAISP == id);
            if (string.IsNullOrEmpty(CT_TenLoaiSP) || string.IsNullOrEmpty(CT_Icon))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                loaiSP.TENLOAI = CT_TenLoaiSP;
                loaiSP.ICON = CT_Icon; 
                UpdateModel(loaiSP);
                sqlconnect.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();
        }
        [HttpPost]
        public ActionResult EditLoaiSP1(FormCollection collection)//edit update data loaisp
        {
            var CT_IdLoaiSP = collection["IDTYPE"];
            var CT_TenLoaiSP = collection["tenloai"];
            var CT_Icon = collection["icon"];
            var loaiSP = sqlconnect.LOAISANPHAMs.First(m => m.MALOAISP == int.Parse(CT_IdLoaiSP));
            if (string.IsNullOrEmpty(CT_TenLoaiSP) || string.IsNullOrEmpty(CT_Icon))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                loaiSP.TENLOAI = CT_TenLoaiSP;
                loaiSP.ICON = CT_Icon;
                UpdateModel(loaiSP);
                sqlconnect.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();
        }
        [HttpPost]
        public ActionResult EditNSX(int id,FormCollection collection)//edit update data nsx
        {
           
            var CT_IdNSX = collection["IDNSX"];
            var CT_TenNSX = collection["TENNSX"];
            var CT_ThongTin = collection["THONGTIN"];
            var CT_Logo = collection["LOGO"];
            var nsx = sqlconnect.NHASANXUATs.First(m => m.MANSX == int.Parse(CT_IdNSX));
            if (string.IsNullOrEmpty(CT_TenNSX) || string.IsNullOrEmpty(CT_ThongTin) || string.IsNullOrEmpty(CT_Logo))
                ViewData["Loi"] = "Không Được Để Trống"; 
            else
            {
                nsx.TENNSX = CT_TenNSX;
                nsx.THONGTIN = CT_ThongTin;
                nsx.LOGO = CT_Logo;
                UpdateModel(nsx);
                sqlconnect.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();
        }
        [HttpPost]
        public ActionResult EditNSX1(FormCollection collection)//edit update data nsx
        {

            var CT_IdNSX = collection["IDNSX"];
            var CT_TenNSX = collection["TENNSX"];
            var CT_ThongTin = collection["THONGTIN"];
            var CT_Logo = collection["LOGO"];
            var nhasanxuat1 = sqlconnect.NHASANXUATs.First(m => m.MANSX == int.Parse(CT_IdNSX));
            if (string.IsNullOrEmpty(CT_TenNSX) || string.IsNullOrEmpty(CT_ThongTin) || string.IsNullOrEmpty(CT_Logo))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                nhasanxuat1.TENNSX = CT_TenNSX;
                nhasanxuat1.THONGTIN = CT_ThongTin;
                nhasanxuat1.LOGO = CT_Logo;
                UpdateModel(nhasanxuat1);
                sqlconnect.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();
        }
        //Page Table Data Detail Product
        public ActionResult Index()
        {
            //var All_Product = from prod in sqlconnect.SANPHAMs select prod;
            //var All_NSX = from nsx in sqlconnect.NHASANXUATs select nsx;
            //ViewData["Product"] = All_Product;
            //ViewData["NSX"] = All_NSX;
            //return View();

            
            var All_Product = from prod in sqlconnect.SANPHAMs select prod;
            var All_LoaiSP = (from loaisp in sqlconnect.LOAISANPHAMs select loaisp).ToList();
            var All_NSX = (from nsx in sqlconnect.NHASANXUATs select nsx).ToList();
            ViewBag.LoaiSP = (List<LOAISANPHAM>)All_LoaiSP;
            ViewBag.NhaSX = (List<NHASANXUAT>)All_NSX;
            if (Session["ss_DNuser"] == null)
            {
                return RedirectToAction("DangNhap", "Admin");
            }
            else
            {
                return View(All_Product);
            }
        }
        
        
        [HttpPost]
        public ActionResult CreateProduct(FormCollection collection,SANPHAM product)
        {
            //tạo biến CT_Product lấy giá trị mà người dùng nhập vào form create product
            var CT_TenSP = collection["TenSP"];
            var CT_DonGia = collection["DonGia"];
            var CT_MoTa = collection["MoTa"];
            var CT_HinhAnh = collection["HinhAnh"];
            var CT_SoLuongTon = collection["SoLuongTon"];
            var CT_MaLoaiSP = collection["MaLoaiSP"];
            var CT_MaNSX = collection["MaNSX"];
            var CT_LuotXem = collection["luotxem"];
            var CT_LuotBinhChon = collection["luotbinhchon"];
            var CT_LuotBinhLuan = collection["luotbinhluan"];
            var CT_NguyenLieu = collection["nguyenlieubanh"];
            if (string.IsNullOrEmpty(CT_TenSP) || string.IsNullOrEmpty(CT_DonGia) || string.IsNullOrEmpty(CT_MoTa) || string.IsNullOrEmpty(CT_HinhAnh) || string.IsNullOrEmpty(CT_SoLuongTon) || string.IsNullOrEmpty(CT_MaLoaiSP) || string.IsNullOrEmpty(CT_MaNSX)|| string.IsNullOrEmpty(CT_LuotXem) || string.IsNullOrEmpty(CT_LuotBinhChon) || string.IsNullOrEmpty(CT_LuotBinhLuan) || string.IsNullOrEmpty(CT_NguyenLieu))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                product.TENSP = CT_TenSP;
                //product.DONGIA = float.Parse(CT_DonGia);
                product.MOTA = CT_MoTa;
                product.HINHANH = CT_HinhAnh;
                product.SOLUONGTON = int.Parse(CT_SoLuongTon);
                product.MALOAISP = int.Parse(CT_MaLoaiSP);
                product.MANSX = int.Parse(CT_MaNSX);
                product.LUOTXEM = int.Parse(CT_LuotXem);
                product.LUOTBINHCHON = int.Parse(CT_LuotBinhChon);
                product.LUOTBINHLUAN = int.Parse(CT_LuotBinhLuan);
                product.NGUYENLIEUBANH = CT_NguyenLieu;
                sqlconnect.SANPHAMs.InsertOnSubmit(product);
                sqlconnect.SubmitChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CreateLoaiSP(FormCollection collection, LOAISANPHAM loaiSP) // create loaisp
        {
            //tạo biến CT_Product lấy giá trị mà người dùng nhập vào form create product
            var CT_TenLoaiSP = collection["tenloai"];
            var CT_Icon = collection["icon"];
            if (string.IsNullOrEmpty(CT_TenLoaiSP) || string.IsNullOrEmpty(CT_Icon))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                loaiSP.TENLOAI = CT_TenLoaiSP;
                loaiSP.ICON = CT_Icon;
                sqlconnect.LOAISANPHAMs.InsertOnSubmit(loaiSP);
                sqlconnect.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();
        }
        [HttpPost]
        public ActionResult CreateNSX(FormCollection collection, NHASANXUAT nsx) // create loaisp
        {
            //tạo biến CT_Product lấy giá trị mà người dùng nhập vào form create product
            var CT_TenNSX = collection["TENNSX"];
            var CT_ThongTin = collection["THONGTIN"];
            var CT_LOGO = collection["LOGO"];
            if (string.IsNullOrEmpty(CT_TenNSX) || string.IsNullOrEmpty(CT_ThongTin) || string.IsNullOrEmpty(CT_LOGO))
                ViewData["Loi"] = "Không Được Để Trống";
            else
            {
                nsx.TENNSX = CT_TenNSX;
                nsx.THONGTIN = CT_ThongTin;
                nsx.LOGO = CT_LOGO;
                sqlconnect.NHASANXUATs.InsertOnSubmit(nsx);
                sqlconnect.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Index();
        }

        public ActionResult DeleteProduct(string id)
        {
            var D_tin = sqlconnect.SANPHAMs.Where(m => m.MASP.ToString() == id).First();
            sqlconnect.SANPHAMs.DeleteOnSubmit(D_tin);
            sqlconnect.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteLoaiSP(string id)
        {

            var D_PRODUCT = sqlconnect.SANPHAMs.Where(m => m.MALOAISP.ToString() == id).ToList();
            sqlconnect.SANPHAMs.DeleteAllOnSubmit(D_PRODUCT);
            sqlconnect.SubmitChanges();

            var D_loaiSP = sqlconnect.LOAISANPHAMs.Where(m => m.MALOAISP.ToString() == id).First();
            sqlconnect.LOAISANPHAMs.DeleteOnSubmit(D_loaiSP);
            sqlconnect.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteNSX(string id)
        {
            var D_PRODUCT = sqlconnect.SANPHAMs.Where(m => m.MANSX.ToString() == id).ToList();
            sqlconnect.SANPHAMs.DeleteAllOnSubmit(D_PRODUCT);
            sqlconnect.SubmitChanges();

            sqlconnect.SANPHAMs.DeleteAllOnSubmit(D_PRODUCT);
            var D_NSX = sqlconnect.NHASANXUATs.Where(m => m.MANSX.ToString() == id).First();
           
            
            sqlconnect.NHASANXUATs.DeleteOnSubmit(D_NSX);
            sqlconnect.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}
