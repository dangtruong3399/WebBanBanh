using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanBanh.Models
{
    public class ItemGioHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
        public string HinhAnh { get; set; }

        public ItemGioHang(int iMaSP)
        {
            using (QL_BANHANGDataContext db = new QL_BANHANGDataContext())
            {
                this.MaSP = iMaSP;
                SANPHAM sp = db.SANPHAMs.Single(n => n.MASP == iMaSP);
                this.TenSP = sp.TENSP;
                this.HinhAnh = sp.HINHANH;
                this.DonGia = sp.DONGIA.Value;
                this.SoLuong = 1;
                this.ThanhTien = DonGia * SoLuong;

            }
        }

        public ItemGioHang(int iMaSP, int sl)
        {
            using (QL_BANHANGDataContext db = new QL_BANHANGDataContext())
            {
                this.MaSP = iMaSP;
                SANPHAM sp = db.SANPHAMs.Single(n => n.MASP == iMaSP);
                this.TenSP = sp.TENSP;
                this.HinhAnh = sp.HINHANH;
                this.DonGia = sp.DONGIA.Value;
                this.SoLuong = sl;
                this.ThanhTien = DonGia * SoLuong;

            }
        }

        public ItemGioHang()
        {

        }
    }
}