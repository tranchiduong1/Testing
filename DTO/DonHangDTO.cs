using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHangDTO
    {
        private string maNV;
        private DateTime nB;
        private string maKH;

        public string MaHDBan { get; set; }
        public string MaNhanVien { get; set; }

        public string NgayBan { get; set; }
        public string MaKhachHang { get; set; }

        public DonHangDTO(string MaHDBan, string MaNhanVien, string NgayBan, string MaKhachHang)
        {
            this.MaHDBan = MaHDBan;
            this.MaNhanVien = MaNhanVien;
            this.NgayBan = NgayBan;
            this.MaKhachHang = MaKhachHang;
        }
        public DonHangDTO(string MaHDBan)
        {
            this.MaHDBan = MaHDBan;
        }

        //public DonHangDTO(string MaHDBan, string maNV, DateTime nB, string maKH) : this(MaHDBan)
        //{
        //    this.MaNhanVien = maNV;
        //    NgayBan = DateTime.Parse(nB.ToString());
        //    this.maKH = maKH;
        //}
    }
}
