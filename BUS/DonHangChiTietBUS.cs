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
    public class DonHangChiTietBUS
    {
        DonHangChiTietDAO donhangchitietDAO = new DonHangChiTietDAO();
        public List<DonHangChiTietDTO> GetDHCT()
        {
            try
            {
                return donhangchitietDAO.GetDHCT();
            }


            catch (SqlException ex)
            {

                throw ex;
            };
        }

        public List<DonHangChiTietDTO> GetDHCTWK(string MaHD)
        {
            try
            {
                return donhangchitietDAO.GetDHCTWK(MaHD);
            }


            catch (SqlException ex)
            {

                throw ex;
            };
        }

        public int Add(DonHangChiTietDTO dhct)
        {
            try
            {
                return donhangchitietDAO.Add(dhct);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Delete(DonHangChiTietDTO dhct)
        {
            try
            {
                return donhangchitietDAO.Delete(dhct);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Update(DonHangChiTietDTO dhct)
        {
            try
            {
                return donhangchitietDAO.Update(dhct);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
