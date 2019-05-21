﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHangChiTietDTO
    {
        public string MaHDBan { get; set; }
        public string MaSanPham { get; set; }
        public string SoLuong { get; set; }
        public string DonGia { get; set; }
        public string GiamGia { get; set; }
        public string ThanhTien { get; set; }

        public DonHangChiTietDTO(string MaHDBan, string MaSanPham, string SoLuong, string DonGia, string GiamGia, string ThanhTien)
        {
            this.MaHDBan = MaHDBan;
            this.MaSanPham = MaSanPham;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
            this.GiamGia = GiamGia;
            this.ThanhTien = ThanhTien;
        }

        public DonHangChiTietDTO(string MaHDBan)
        {
            this.MaHDBan = MaHDBan;
        }
    }
}
