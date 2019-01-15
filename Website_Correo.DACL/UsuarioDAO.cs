using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Website_Correo.DACL
{
    public class UsuarioDAO
    {
        private Conexion conexion;
        /// <summary>
        /// Valida credenciales de usuario para verificar login
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="password">Password</param>
        /// <returns>Retorna estado de autenticacion de usuario</returns>
        public DataTable ValidarUsuario(string email, string password)
        {

            try
            {
                conexion = new Conexion();
                
                return conexion.ExecuteDataTableCMDO("select * from usuarios where email = '"+ email +"' and contrasena = '"+ password +"'");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable ValidaCorreo(string email)
        {

            try
            {
                conexion = new Conexion();

                return conexion.ExecuteDataTableCMDO("select * from usuarios where email = '" + email + "'");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ActualizarUsuario(string email, string clave1)
        {
            conexion = new Conexion();
            SqlParameter[] parameters = new SqlParameter[] {
             new SqlParameter("@NuevaClave",clave1),
            new SqlParameter("@Correo", email)};

            conexion.ExecuteCMD("dbo.ActualizarClave", parameters);
            conexion = null;
        }


    }
}
