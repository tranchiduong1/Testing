﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; }
        public string HoKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChiKH { get; set; }
        public string DienThoaiKH { get; set; }

        public KhachHangDTO(string MaKH, string HoKH, string TenKH, string DiaChiKH, string DienThoaiKH)
        {
            this.MaKH = MaKH;
            this.HoKH = HoKH;
            this.TenKH = TenKH;
            this.DiaChiKH = DiaChiKH;
            this.DienThoaiKH = DienThoaiKH;
        }
        public KhachHangDTO(string MaKH)
        {
            this.MaKH = MaKH;
        }
    }
}
