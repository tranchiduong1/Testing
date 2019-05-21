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
    public class LoaiSanPhamBUS
    {
        LoaiSanPhamDAO loaisanphamDAO = new LoaiSanPhamDAO();
        public List<LoaiSanPhamDTO> GetLoaiSP()
        {
            try
            {
                return loaisanphamDAO.GetLoaiSP();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<LoaiSanPhamDTO> GetLoaiSPWK(string MaLSP)
        {
            try
            {
                return loaisanphamDAO.GetLoaiSPWK(MaLSP);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Add(LoaiSanPhamDTO loaisanpham)
        {
            try
            {
                return loaisanphamDAO.Add(loaisanpham);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Delete(LoaiSanPhamDTO loaisanpham)
        {
            return loaisanphamDAO.Delete(loaisanpham);
        }

        public int Update(LoaiSanPhamDTO loaisanpham)
        {
            return loaisanphamDAO.Update(loaisanpham);
        }

    }
}
