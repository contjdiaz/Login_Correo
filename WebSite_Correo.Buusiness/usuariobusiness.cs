using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite_Correo.Entities;
using System.Data;
using Website_Correo.DACL;

namespace WebSite_Correo.Buusiness
{
    public class usuariobusiness
    {
        private UsuarioDAO usuarioDao;

        /// <summary>
        /// Constructor
        /// </summary>
        public usuariobusiness()
        {
            this.usuarioDao = new UsuarioDAO();
        }


        public UsuarioEntity ValidarUsuario2(string email, string password)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuario.SeAutentica = false;
            //bool ingreso = false;

            //CRijndael MEncriptar = new CRijndael();
            //string contraseniaEncriptada = MEncriptar.Encriptar(password);

            DataTable vobjResultado = this.usuarioDao.ValidarUsuario(email, password);
            List<UsuarioEntity> lstusuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);

            if (lstusuario.Count > 0)
            {
                usuario = lstusuario.FirstOrDefault();
                usuario.SeAutentica = true;
            }

            return usuario;
        }

        public UsuarioEntity ValidarCorreo(string email)
        {
            UsuarioEntity usuario = new UsuarioEntity();
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuario.SeAutentica = false;
            //bool ingreso = false;

            //CRijndael MEncriptar = new CRijndael();
            //string contraseniaEncriptada = MEncriptar.Encriptar(password);

            DataTable vobjResultado = this.usuarioDao.ValidaCorreo(email);
            List<UsuarioEntity> lstusuario = Utilitario.ConvertTo<UsuarioEntity>(vobjResultado);

            if (lstusuario.Count > 0)
            {
                usuario = lstusuario.FirstOrDefault();
                usuario.SeAutentica = true;
            }

            return usuario;
        }

        public RespuestaAjax ActualizarBeneficiario(string IdRadicado, int IdEstado, string Observacion, string UsuarioModifica)
        {
            RespuestaAjax Respuesta = new RespuestaAjax();

            try
            {
                //UsuarioDao objUsuario = new UsuarioDao();
                this.usuarioDao.ActualizarBeneficiario(IdRadicado, IdEstado, Observacion, UsuarioModifica);
                Respuesta.Estado = EstadoRespuesta.OK;
                Respuesta.Mensage = "Los datos han sido actualizados exitosamente.";
            }
            catch (Exception e)
            {
                Respuesta.Estado = EstadoRespuesta.ERROR;
                Respuesta.Mensage = e.Message;

            }
            return Respuesta;
        }


    }
}
