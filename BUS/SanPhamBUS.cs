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
    public class SanPhamBUS
    {
        SanPhamDAO sanphamDAO = new SanPhamDAO();
        public List<SanPhamDTO> GetSanPham()
        {
            try
            {
                return sanphamDAO.GetSanPham();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public List<SanPhamDTO> GetSanPhamWK(string MaSP)
        {
            try
            {
                return sanphamDAO.GetSanPhamWK(MaSP);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public List<SanPhamDTO> GetLSPWK(string MaLSP)
        {
            try
            {
                return sanphamDAO.GetLSPWK(MaLSP);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Add(SanPhamDTO sanpham)
        {
            try
            {
                return sanphamDAO.Add(sanpham);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Delete(SanPhamDTO sanpham)
        {
            return sanphamDAO.Delete(sanpham);
        }
        public int Update(SanPhamDTO sanpham)
        {
            return sanphamDAO.Update(sanpham);
        }


    }
}
