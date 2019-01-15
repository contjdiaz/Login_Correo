using System;
using System.Collections.Generic;
using System.Text;

namespace WebSite_Correo.DAL
{
    public class Conexion
    {
        public string ValidarUsuarioIcetex(string login)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            string password = string.Empty;
            DataTable objUsuario;
            parametros.Add("P_USUARIO", login);
            objUsuario = SqlDataProvider.DBInstance.EjecutarADataTable("PKG_CON_UTILIDADES.TECNO_OPER_VALIDAR_USUARIO", CommandType.StoredProcedure, parametros);

            if (objUsuario.Rows.Count != 0)
                password = objUsuario.Rows[0]["PASSWORD"].ToString();

            return password;
        }
    }
}
