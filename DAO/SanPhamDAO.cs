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
    public class SanPhamDAO : DataProvider
    {
        //Lấy danh sách 
        public List<SanPhamDTO> GetSanPham()
        {
            string sql = "SELECT * FROM SanPham";
            List<SanPhamDTO> list = new List<SanPhamDTO>();
            Connect();
            string MaSP, TenSP, MaLSP, SLTonKho, DGNhap, DGBan;
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                while (rd.Read())
                {
                    MaSP = rd[0].ToString();
                    TenSP = rd[1].ToString();
                    MaLSP = rd[2].ToString();
                    SLTonKho = rd[3].ToString();
                    DGNhap = rd[4].ToString();
                    DGBan = rd[5].ToString();

                    SanPhamDTO sp = new SanPhamDTO(MaSP, TenSP, MaLSP, SLTonKho, DGNhap, DGBan);
                    list.Add(sp);
                }
                rd.Close();
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        //Thêm
        public int Add(SanPhamDTO sanpham)
        {
            string sql = "INSERT INTO SanPham VALUES (@MaSP, @TenSP, @MaLSP, @SLTK, @DGN, @DGB)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaSP", sanpham.MaSP));
            parameters.Add(new SqlParameter("@TenSP", sanpham.TenSP));
            parameters.Add(new SqlParameter("@MaLSP", sanpham.MaLSP));
            parameters.Add(new SqlParameter("@SLTK", sanpham.SLTonKho));
            parameters.Add(new SqlParameter("@DGN", sanpham.DGNhap));
            parameters.Add(new SqlParameter("@DGB", sanpham.DGBan));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Xoá
        public int Delete(SanPhamDTO sanpham)
        {
            string sql = "DELETE FROM SanPham WHERE MaSanPham = @MaSP";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaSP", sanpham.MaSP));

            return MyExcuteNonQuery(sql, CommandType.Text, parameters);
        }

        //Sửa
        public int Update(SanPhamDTO sanpham)
        {
            string sql = "UPDATE SanPham SET TenSanPham = @TenSP, MaLoaiSanPham = @MaLSP, SoLuongTonKho = @SLTK, DonGiaNhap = @DGN, DonGiaBan=@DGB WHERE  MaSanPham = @MaSP";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaSP", sanpham.MaSP));
            parameters.Add(new SqlParameter("@TenSP", sanpham.TenSP));
            parameters.Add(new SqlParameter("@MaLSP", sanpham.MaLSP));
            parameters.Add(new SqlParameter("@SLTK", sanpham.SLTonKho));
            parameters.Add(new SqlParameter("@DGN", sanpham.DGNhap));
            parameters.Add(new SqlParameter("@DGB", sanpham.DGBan));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        //Tìm
        public List<SanPhamDTO> GetSanPhamWK(string MaSP)
        {
            string sql = "SELECT * FROM SanPham WHERE MaSanPham ='" + MaSP + "' ";
            List<SanPhamDTO> list = new List<SanPhamDTO>();
            Connect();
            string TenSP, MaLSP, SLTonKho, DGNhap, DGBan;
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                while (rd.Read())
                {
                    MaSP = rd[0].ToString();
                    TenSP = rd[1].ToString();
                    MaLSP = rd[2].ToString();
                    SLTonKho = rd[3].ToString();
                    DGNhap = rd[4].ToString();
                    DGBan = rd[5].ToString();

                    SanPhamDTO sp = new SanPhamDTO(MaSP, TenSP, MaLSP, SLTonKho, DGNhap, DGBan);
                    list.Add(sp);
                }
                rd.Close();
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        public List<SanPhamDTO> GetLSPWK(string MaLSP)
        {
            string sql = "SELECT * FROM SanPham WHERE MaLoaiSanPham ='" + MaLSP + "' ";
            List<SanPhamDTO> list = new List<SanPhamDTO>();
            Connect();
            string MaSP, TenSP, SLTonKho, DGNhap, DGBan;
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                while (rd.Read())
                {
                    MaSP = rd[0].ToString();
                    TenSP = rd[1].ToString();
                    MaLSP = rd[2].ToString();
                    SLTonKho = rd[3].ToString();
                    DGNhap = rd[4].ToString();
                    DGBan = rd[5].ToString();

                    SanPhamDTO sp = new SanPhamDTO(MaSP, TenSP, MaLSP, SLTonKho, DGNhap, DGBan);
                    list.Add(sp);
                }
                rd.Close();
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}