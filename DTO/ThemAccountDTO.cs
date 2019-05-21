using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThemAccountDTO
    {
        public string taiKhoan { get; set; }
        public string matKhau { get; set; }

        public int ID { get; set; }

        public ThemAccountDTO(string tk, string mk, int id)
        {
            this.taiKhoan = tk;
            this.matKhau = mk;
            this.ID = id;
        }
        public ThemAccountDTO(int id)
        {
            this.ID = id;
        }
    }
}
