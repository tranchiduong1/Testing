using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class KhachHangBUS
    {
        KhachHangDAO khachhangDAO = new KhachHangDAO();
        public List<KhachHangDTO> GetKhachHang()
        {
            try
            {
                return khachhangDAO.GetKhachHang();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<KhachHangDTO> GetKhachHangWK(string MaKH)
        {
            try
            {
                return khachhangDAO.GetKhachHangWK(MaKH);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Add(KhachHangDTO khachhang)
        {
            try
            {
                return khachhangDAO.Add(khachhang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
       public int Delete(KhachHangDTO khachhang)
        {
            try
            {
                return khachhangDAO.Delete(khachhang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Update(KhachHangDTO khachhang)
        {
            try
            {
                return khachhangDAO.Update(khachhang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
