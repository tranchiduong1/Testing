using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSanPhamDTO
    {
        public string MaLoaiSanPham { get; set; }
        public string TenLoaiSanPham { get; set; }

        public LoaiSanPhamDTO(string MaLoaiSanPham, string TenLoaiSanPham)
        {
            this.MaLoaiSanPham = MaLoaiSanPham;
            this.TenLoaiSanPham = TenLoaiSanPham;
        }
        public LoaiSanPhamDTO(string MaLoaiSanPham)
        {
            this.MaLoaiSanPham = MaLoaiSanPham;
        }
    }
}
