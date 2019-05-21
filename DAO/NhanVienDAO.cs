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
    public class NhanVienDAO : DataProvider
    {

        // LẤY DANH SÁCH
        public List<NhanVienDTO> GetNhanVien()
        {
            string sql = "SELECT * FROM NhanVien";
            List<NhanVienDTO> list = new List<NhanVienDTO>();

            Connect();
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                string MaNV, HoNV, TenNV, CD, NS, NBDLV, GT, DC, SDT;
                while (rd.Read())
                {
                    MaNV = rd[0].ToString();
                    HoNV = rd[1].ToString();
                    TenNV = rd[2].ToString();
                    CD = rd[3].ToString();
                    NS = rd[4].ToString();
                    NBDLV = rd[5].ToString();
                    GT = rd[6].ToString();
                    DC = rd[7].ToString();
                    SDT = rd[8].ToString();

                    NhanVienDTO qt = new NhanVienDTO(MaNV, HoNV, TenNV, CD, NS, NBDLV, GT, DC, SDT);
                    list.Add(qt);
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
        public List<NhanVienDTO> GetNhanVienWK(string MaNV)
        {
            string sql = "SELECT * FROM NhanVien WHERE MaNhanVien = '"+MaNV+"'";
            List<NhanVienDTO> list = new List<NhanVienDTO>();

            Connect();
            try
            {
                SqlDataReader rd = myExecuteDataReader(sql);
                string HoNV, TenNV, CD, NS, NBDLV, GT, DC, SDT;
                while (rd.Read())
                {
                    MaNV = rd[0].ToString();
                    HoNV = rd[1].ToString();
                    TenNV = rd[2].ToString();
                    CD = rd[3].ToString();
                    NS = rd[4].ToString();
                    NBDLV = rd[5].ToString();
                    GT = rd[6].ToString();
                    DC = rd[7].ToString();
                    SDT = rd[8].ToString();

                    NhanVienDTO qt = new NhanVienDTO(MaNV, HoNV, TenNV, CD, NS, NBDLV, GT, DC, SDT);
                    list.Add(qt);
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
        // THÊM:
        public int Add(NhanVienDTO quantri)
        {
            string sql = "INSERT INTO NhanVien VALUES(@MaNhanVien, @HoNhanVien, @TenNhanVien, @ChucDanh, @NgaySinh, @NgayBatDauLamViec, @GioiTinh, @DiaChi, @SoDienThoai)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaNhanVien", quantri.MaNhanVien));
            parameters.Add(new SqlParameter("@HoNhanVien", quantri.HoNhanVien));
            parameters.Add(new SqlParameter("@TenNhanVien", quantri.TenNhanVien));
            parameters.Add(new SqlParameter("@ChucDanh", quantri.ChucDanh));
            parameters.Add(new SqlParameter("@NgaySinh", quantri.NgaySinh));
            parameters.Add(new SqlParameter("@NgayBatDauLamViec", quantri.NgayBatDauLamViec));
            parameters.Add(new SqlParameter("@GioiTinh", quantri.GioiTinh));
            parameters.Add(new SqlParameter("@DiaChi", quantri.DiaChi));
            parameters.Add(new SqlParameter("@SoDienThoai", quantri.SoDienThoai));

            try
            {
                return MyExcuteNonQuery(sql, CommandType.Text, parameters);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // XOÁ

        public int Delete(NhanVienDTO quantri)
        {
            string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNV";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaNV", quantri.MaNhanVien));

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
        public int Update(NhanVienDTO quantri)
        {
            string sql = "UPDATE NhanVien SET HoNhanVien = @HoNhanVien, TenNhanVien = @TenNhanVien, ChucDanh = @ChucDanh, NgaySinh = @NgaySinh, NgayBatDauLamViec = @NgayBatDauLamViec, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai WHERE MaNhanVien = @MaNhanVien";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@MaNhanVien", quantri.MaNhanVien));
            parameters.Add(new SqlParameter("@HoNhanVien", quantri.HoNhanVien));
            parameters.Add(new SqlParameter("@TenNhanVien", quantri.TenNhanVien));
            parameters.Add(new SqlParameter("@ChucDanh", quantri.ChucDanh));
            parameters.Add(new SqlParameter("@NgaySinh", quantri.NgaySinh));
            parameters.Add(new SqlParameter("@NgayBatDauLamViec", quantri.NgayBatDauLamViec));
            parameters.Add(new SqlParameter("@GioiTinh", quantri.GioiTinh));
            parameters.Add(new SqlParameter("@DiaChi", quantri.DiaChi));
            parameters.Add(new SqlParameter("@SoDienThoai", quantri.SoDienThoai));

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
        //public List<NhanVienDTO> TimNV()
        //{
        //    string sql = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@MaNhanVien", quantri.MaNhanVien));

        //    return myExecuteDataReader(sql);
        //}
    }
}
