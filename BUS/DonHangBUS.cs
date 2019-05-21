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
    public class DonHangBUS
    {
        DonHangDAO donhangDAO = new DonHangDAO();
        public List<DonHangDTO> GetDonHang()
        {
            try
            {
                return donhangDAO.GetDonHang();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<DonHangDTO> GetDonHangWK(string MaHD)
        {
            try
            {
                return donhangDAO.GetDonHangWK(MaHD);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Add(DonHangDTO donhang)
        {
            try
            {
                return donhangDAO.Add(donhang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Delete(DonHangDTO donhang)
        {
            try
            {
                return donhangDAO.Delete(donhang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Update(DonHangDTO donhang)
        {
            try
            {
                return donhangDAO.Update(donhang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
