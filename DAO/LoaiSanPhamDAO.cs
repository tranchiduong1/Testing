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
    public class LoaiSanPhamDAO : DataProvider
    {
        //lấy danh sách loại sản phẩm
        public List<LoaiSanPhamDTO> GetLoaiSP()
        {
            string sql = "SELECT * FROM LoaiSanPham";
            List<LoaiSanPhamDTO> list = new List<LoaiSanPhamDTO>();
            Connect();
            string MaLSP, TenLSP;
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                while (rd.Read())
                {
                    MaLSP = rd[0].ToString();
                    TenLSP = rd[1].ToString();

                    LoaiSanPhamDTO lsp = new LoaiSanPhamDTO(MaLSP, TenLSP);
                    list.Add(lsp);
                }
                rd.Close();
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Tìm
        public List<LoaiSanPhamDTO> GetLoaiSPWK(string MaLSP)
        {
            string sql = "SELECT * FROM LoaiSanPham WHERE MaLoaiSanPham = '"+ MaLSP + "'";
            List<LoaiSanPhamDTO> list = new List<LoaiSanPhamDTO>();
            Connect();
            string TenLSP;
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                while (rd.Read())
                {
                    MaLSP = rd[0].ToString();
                    TenLSP = rd[1].ToString();

                    LoaiSanPhamDTO lsp = new LoaiSanPhamDTO(MaLSP, TenLSP);
                    list.Add(lsp);
                }
                rd.Close();
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Thêm
        public int Add(LoaiSanPhamDTO loaisanpham)
        {
            string sql = "INSERT INTO LoaiSanPham VALUES (@MaLoaiSanPham, @TenLoaiSanPham)";
            List<SqlParameter> paramerters = new List<SqlParameter>();
            paramerters.Add(new SqlParameter("@MaLoaiSanPham", loaisanpham.MaLoaiSanPham));
            paramerters.Add(new SqlParameter("@TenLoaiSanPham", loaisanpham.TenLoaiSanPham));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, paramerters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Delete(LoaiSanPhamDTO loaisanpham)
        {
            string sql = "DELETE FROM LoaiSanPham WHERE MaLoaiSanPham = @MaLoaiSanPham";
            List<SqlParameter> paramerters = new List<SqlParameter>();
            paramerters.Add(new SqlParameter("@MaLoaiSanPham", loaisanpham.MaLoaiSanPham));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, paramerters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Update(LoaiSanPhamDTO loaisanpham)
        {
            string sql = "UPDATE LoaiSanPham SET TenLoaiSanPham = @TenLoaiSanPham WHERE  MaLoaiSanPham = @MaLoaiSanPham";
            List<SqlParameter> paramerters = new List<SqlParameter>();
            paramerters.Add(new SqlParameter("@MaLoaiSanPham", loaisanpham.MaLoaiSanPham));
            paramerters.Add(new SqlParameter("@TenLoaiSanPham", loaisanpham.TenLoaiSanPham));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, paramerters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        } 
    }
}
