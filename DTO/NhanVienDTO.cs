using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public string MaNhanVien { get; set; }
        public string HoNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string ChucDanh { get; set; }
        public string NgaySinh { get; set; }
        public string NgayBatDauLamViec { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }

        public NhanVienDTO()
        { }

        public NhanVienDTO(string MaNhanVien, string HoNhanVien, string TenNhanVien, string ChucDanh, string NgayBatDauLamViec, string NgaySinh, string GioiTinh, string DiaChi, string SoDienThoai)
        {
            this.MaNhanVien = MaNhanVien;
            this.HoNhanVien = HoNhanVien;
            this.TenNhanVien = TenNhanVien;
            this.ChucDanh = ChucDanh;
            this.NgaySinh = NgaySinh;
            this.NgayBatDauLamViec = NgayBatDauLamViec;
            this.GioiTinh = GioiTinh;
            this.DiaChi = DiaChi;
            this.SoDienThoai = SoDienThoai;
        }

        public NhanVienDTO(string MaNhanVien)
        {
            this.MaNhanVien = MaNhanVien;
        }
    }
}
