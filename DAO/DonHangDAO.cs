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
    public class DonHangDAO : DataProvider
    {
        public List<DonHangDTO> GetDonHang()
        {
            string sql = "SELECT * FROM HoaDon";
            List<DonHangDTO> list = new List<DonHangDTO>();
            Connect();
            try
            {
                SqlDataReader dr = myExecuteDataReader(sql);
                string MaHDBan, MaNhanVien, NgayBan, MaKhachHang;
                while (dr.Read())
                {
                    MaHDBan = dr[0].ToString();
                    MaNhanVien = dr[1].ToString();
                    NgayBan = dr[2].ToString();
                    MaKhachHang = dr[3].ToString();

                    DonHangDTO xhd = new DonHangDTO(MaHDBan, MaNhanVien, NgayBan, MaKhachHang);
                    list.Add(xhd);
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

        public List<DonHangDTO> GetDonHangWK(string MaHD)
        {
            string sql = "SELECT * FROM HoaDon WHERE MaHDBan = '"+MaHD+"'";
            List<DonHangDTO> list = new List<DonHangDTO>();
            Connect();
            try
            {
                SqlDataReader dr = myExecuteDataReader(sql);
                string MaNhanVien, NgayBan, MaKhachHang;
                while (dr.Read())
                {
                    MaHD = dr[0].ToString();
                    MaNhanVien = dr[1].ToString();
                    NgayBan = dr[2].ToString();
                    MaKhachHang = dr[3].ToString();

                    DonHangDTO xhd = new DonHangDTO(MaHD, MaNhanVien, NgayBan, MaKhachHang);
                    list.Add(xhd);
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

        public int Add(DonHangDTO donhang)
        {
            string sql = "INSERT INTO HoaDon VALUES(@MaHD, @MaNV, @NB, @MaKH)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("MaHD", donhang.MaHDBan));
            parameters.Add(new SqlParameter("MaNV", donhang.MaNhanVien));
            parameters.Add(new SqlParameter("NB", donhang.NgayBan));
            parameters.Add(new SqlParameter("MaKH", donhang.MaKhachHang));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Delete(DonHangDTO donhang)
        {
            string sql = "DELETE FROM HoaDon WHERE MaHDBan = @MaHDBan";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("MaHDBan", donhang.MaHDBan));
            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Update(DonHangDTO donhang)
        {
            string sql = "UPDATE HoaDon SET MaNhanVien = @MaNV, NgayBan = @NB, MaKhachHang= @MaKH WHERE MaHDBan = @MaHD";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("MaHD", donhang.MaHDBan));
            parameters.Add(new SqlParameter("MaNV", donhang.MaNhanVien));
            parameters.Add(new SqlParameter("NB", donhang.NgayBan));
            parameters.Add(new SqlParameter("MaKH", donhang.MaKhachHang));

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
