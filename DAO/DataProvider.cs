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
    public class DataProvider
    {
        SqlConnection cn;

        public DataProvider()
        {
            string cnStr = "Data Source =.; Initial Catalog = QLPetMarket; Integrated Security = True";
            cn = new SqlConnection(cnStr);

        }
        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public void Disconnect()
        {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int myExcuteScalar(string sql)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            Connect();
            try
            {
                int number = (int)cmd.ExecuteScalar();
                return number;
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

        public SqlDataReader myExecuteDataReader(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            Connect();
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        public int MyExcuteNonQuery(string sql, CommandType type, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;//se cap nhat
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            Connect();

            try
            {
                int numberOfRows = cmd.ExecuteNonQuery();
                return numberOfRows;
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

        public SqlDataReader MyExecuteDataReader(string sql ,CommandType type, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;//se cap nhat
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            Connect();

            try
            {               
                return cmd.ExecuteReader();
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
    }
}
