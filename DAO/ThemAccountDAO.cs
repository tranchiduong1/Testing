using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class ThemAccountDAO:DataProvider
    {
        public List<ThemAccountDTO> GetThemAccount()
        {
            string sql = "SELECT * FROM TaiKhoanNhanVien";
            List<ThemAccountDTO> list = new List<ThemAccountDTO>();

            SqlDataReader dr = myExecuteDataReader(sql);
            string tk, mk;
            int id;
            while (dr.Read())
            {
                tk = dr[0].ToString();
                mk = dr[1].ToString();
                id = int.Parse(dr[2].ToString());


                ThemAccountDTO them = new ThemAccountDTO(tk, mk, id);
                list.Add(them);
            }
            dr.Close();
            return list;
        }
        public int Add(ThemAccountDTO them)
        {
            string sql = "INSERT INTO TaiKhoanNhanVien VALUES (@TaiKhoan, @MatKhau, @ID)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TaiKhoan", them.taiKhoan));
            parameters.Add(new SqlParameter("@MatKhau", them.matKhau));
            parameters.Add(new SqlParameter("@ID", them.ID));

            return MyExcuteNonQuery(sql, CommandType.Text, parameters);
        }
        //Thêm hàm xoá để tiện xoá sau khi test
        public int Delete(ThemAccountDTO them)
        {
            string sql = "DELETE FROM TaiKhoanNhanVien WHERE MaNhanVien = @MaNV";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaNV", them.ID));

            return MyExcuteNonQuery(sql, CommandType.Text, parameters);
        }
    }
}
