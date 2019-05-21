using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class NhanVienBUS
    {
        NhanVienDAO quantriDAO = new NhanVienDAO();
        public List<NhanVienDTO> GetNhanVien()
        {
            try
            {
                return quantriDAO.GetNhanVien();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<NhanVienDTO> GetNhanVienWK(string MaNV)
        {
            try
            {
                return quantriDAO.GetNhanVienWK(MaNV);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Add(NhanVienDTO quantri)
        {
            try
            {
                return quantriDAO.Add(quantri);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Delete(NhanVienDTO quantri)
        {
            try
            {
                return quantriDAO.Delete(quantri);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Update(NhanVienDTO quantri)
        {
            try
            {
                return quantriDAO.Update(quantri);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
