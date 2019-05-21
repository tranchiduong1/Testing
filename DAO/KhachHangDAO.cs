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
    public class KhachHangDAO : DataProvider
    {

        // Lấy Danh sách Khách hàng
        public List<KhachHangDTO> GetKhachHang()
        {
            string sql = "SELECT * FROM KhachHang";
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            Connect();
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                string MaKH, HoKH, TenKH, DiaChiKH, DienThoaiKH;
                while (rd.Read())
                {
                    MaKH = rd[0].ToString();
                    HoKH = rd[1].ToString();
                    TenKH = rd[2].ToString();
                    DiaChiKH = rd[3].ToString();
                    DienThoaiKH = rd[4].ToString();

                    KhachHangDTO kh = new KhachHangDTO(MaKH, HoKH, TenKH, DiaChiKH, DienThoaiKH);
                    list.Add(kh);
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

        //Tìm
        public List<KhachHangDTO> GetKhachHangWK(string MaKH)
        {
            string sql = "SELECT * FROM KhachHang WHERE MaKhachHang = '"+MaKH+"'";
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            Connect();
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                string HoKH, TenKH, DiaChiKH, DienThoaiKH;
                while (rd.Read())
                {
                    MaKH = rd[0].ToString();
                    HoKH = rd[1].ToString();
                    TenKH = rd[2].ToString();
                    DiaChiKH = rd[3].ToString();
                    DienThoaiKH = rd[4].ToString();

                    KhachHangDTO kh = new KhachHangDTO(MaKH, HoKH, TenKH, DiaChiKH, DienThoaiKH);
                    list.Add(kh);
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

        //THÊM
        public int Add(KhachHangDTO khachhang)
        {
            string sql = "INSERT INTO KhachHang VALUES(@MaKH, @HoKH, @TenKH, @DiaChi, @SDT)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("MaKH", khachhang.MaKH));
            parameters.Add(new SqlParameter("HoKh", khachhang.HoKH));
            parameters.Add(new SqlParameter("TenKH", khachhang.TenKH));
            parameters.Add(new SqlParameter("DiaChi", khachhang.DiaChiKH));
            parameters.Add(new SqlParameter("SDT", khachhang.DienThoaiKH));

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
        public int Delete(KhachHangDTO khachhang)
        {
            string sql = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKH";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("MaKH", khachhang.MaKH));
            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Sửa
        public int Update(KhachHangDTO khachhang)
        {
            string sql = "UPDATE KhachHang SET HoKhachHang = @HoKh, TenKhachHang = @TenKH, DiaChi = @DiaChi, DienThoai = @SDT WHERE  MaKhachHang = @MaKH";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("MaKH", khachhang.MaKH));
            parameters.Add(new SqlParameter("HoKh", khachhang.HoKH));
            parameters.Add(new SqlParameter("TenKH", khachhang.TenKH));
            parameters.Add(new SqlParameter("DiaChi", khachhang.DiaChiKH));
            parameters.Add(new SqlParameter("SDT", khachhang.DienThoaiKH));

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
