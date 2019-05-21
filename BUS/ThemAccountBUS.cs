using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;
using DAO;

namespace BUS
{
    public class ThemAccountBUS
    {
        ThemAccountDAO themaccountDAO = new ThemAccountDAO();

        public List<ThemAccountDTO> GetThemAccount()
        {
            try
            {
                return themaccountDAO.GetThemAccount();
            }
            catch (SqlException ex)
            {

                throw ex;
            }    
        }
        public int Add(ThemAccountDTO them)
        {
            try
            {
                return themaccountDAO.Add(them);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int Delete(ThemAccountDTO them)
        {
            try
            {
                return themaccountDAO.Delete(them);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
