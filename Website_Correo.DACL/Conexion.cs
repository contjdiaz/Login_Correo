using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using log4net;

namespace Website_Correo.DACL
{
    public class Conexion
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString());
        private static readonly ILog log = LogManager.GetLogger(typeof(Conexion));

        private void Open()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            catch (SqlException ex)
            {
                log.Error("Error abriendo conexion", ex);
            }
        }

        private void Close()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error cerrando conexion", ex);
            }
        }

        /// <summary>
        /// Metodo que ejecuta stored procedure
        /// </summary>
        /// <param name="storedProcedure">Nombre del stored procedure</param>
        /// <param name="param">Parametros de entrada</param>
        public int ExecuteCMD(string storedProcedure, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedure;
            cmd.Connection = conn;

            if (param != null)
            {
                cmd.Parameters.AddRange(param);
            }
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error("Error ejecutando ExecuteCMD", ex);
                return 0;
            }
            finally
            {
                this.Close();
                cmd.Dispose();
            }
        }

        /// <summary>
        /// Metodo que ejecuta stored procedure retornando datatable
        /// </summary>
        /// <param name="storedProcedure">Nombre del stored procedure</param>
        /// <param name="param">Parametros de entrada</param>
        //public DataTable ExecuteDataTableCMD(string storedProcedure, SqlParameter[] param)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = storedProcedure;
        //    cmd.Connection = conn;

        //    DataTable dt = new DataTable();

        //    if (param != null)
        //    {
        //        cmd.Parameters.AddRange(param);
        //    }
        //    try
        //    {
        //        dt.Load(cmd.ExecuteReader());
        //        return dt;
        //    }
        //    catch (SqlException ex)
        //    {
        //        log.Error("Error ejecutando ExecuteDataTableCMD", ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        this.Close();
        //        cmd.Dispose();
        //    }
        //}

        public DataTable ExecuteDataTableCMDO(string select)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = select;
            cmd.Connection = conn;

            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (SqlException ex)
            {
                log.Error("Error ejecutando ExecuteDataTableCMD", ex);
                return null;
            }
            finally
            {
                this.Close();
                cmd.Dispose();
            }
        }

    }
}
