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
    public class DonHangChiTietDAO : DataProvider
    {
        public List<DonHangChiTietDTO> GetDHCT()
        {
            string sql = "SELECT * FROM HoaDonChiTiet";
            List<DonHangChiTietDTO> list = new List<DonHangChiTietDTO>();
            Connect();
            try
            {
                SqlDataReader dr = myExecuteDataReader(sql);
                string MaHDBan, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien;
                while (dr.Read())
                {
                    MaHDBan = dr[0].ToString();
                    MaSanPham = dr[1].ToString();
                    SoLuong = dr[2].ToString();
                    DonGia = dr[3].ToString();
                    GiamGia = dr[4].ToString();
                    ThanhTien = dr[5].ToString();


                    DonHangChiTietDTO odd = new DonHangChiTietDTO(MaHDBan, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien);
                    list.Add(odd);
                }

                dr.Close();
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

        public List<DonHangChiTietDTO> GetDHCTWK(string MaHD)
        {
            string sql = "SELECT * FROM HoaDonChiTiet WHERE MaHDBan ='"+MaHD+"'";
            List<DonHangChiTietDTO> list = new List<DonHangChiTietDTO>();
            Connect();
            try
            {
                SqlDataReader dr = myExecuteDataReader(sql);
                string MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien;
                while (dr.Read())
                {
                    MaHD = dr[0].ToString();
                    MaSanPham = dr[1].ToString();
                    SoLuong = dr[2].ToString();
                    DonGia = dr[3].ToString();
                    GiamGia = dr[4].ToString();
                    ThanhTien = dr[5].ToString();


                    DonHangChiTietDTO odd = new DonHangChiTietDTO(MaHD, MaSanPham, SoLuong, DonGia, GiamGia, ThanhTien);
                    list.Add(odd);
                }

                dr.Close();
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

        public int Add(DonHangChiTietDTO dhct)
        {
            string sql = "INSERT INTO HoaDonChiTiet VALUES (@MaHDBan, @MaSP, @SL, @DG, @GG, @TT)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaHDBan", dhct.MaHDBan));
            parameters.Add(new SqlParameter("@MaSP", dhct.MaSanPham));
            parameters.Add(new SqlParameter("@Sl", dhct.SoLuong));
            parameters.Add(new SqlParameter("@DG", dhct.DonGia));
            parameters.Add(new SqlParameter("@GG", dhct.GiamGia));
            parameters.Add(new SqlParameter("@TT", dhct.ThanhTien));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Delete(DonHangChiTietDTO dhct)
        {
            string sql = "DELETE FROM HoaDonChiTiet WHERE MaHDBan = @MaHDBan";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaHDBan", dhct.MaHDBan));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Update(DonHangChiTietDTO dhct)
        {
            string sql = "UPDATE HoaDonChiTiet SET MaSanPham = @MaSP, SoLuong = @Sl, DonGia = @DG, GiamGia = @GG, ThanhTien = @TT WHERE  MaHDBan = @MaHDBan";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaHDBan", dhct.MaHDBan));
            parameters.Add(new SqlParameter("@MaSP", dhct.MaSanPham));
            parameters.Add(new SqlParameter("@Sl", dhct.SoLuong));
            parameters.Add(new SqlParameter("@DG", dhct.DonGia));
            parameters.Add(new SqlParameter("@GG", dhct.GiamGia));
            parameters.Add(new SqlParameter("@TT", dhct.ThanhTien));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
