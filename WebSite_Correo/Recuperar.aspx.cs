using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Website_Correo.DACL;
using WebSite_Correo.Entities;
using WebSite_Correo.Buusiness;

public partial class Recuperar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Enviar_Click(object sender, EventArgs e)
    {
        UsuarioDAO usuarioact = new UsuarioDAO();
        UsuarioEntity usuaentyty = new UsuarioEntity();
        usuariobusiness usubusiness = new usuariobusiness();
        

        string clave1 = txtclave.Text;
        string claveconf = txtvalidaclave.Text;
        string correo = txtcorreo.Text;

        usuaentyty = usubusiness.ValidarCorreo(correo);

        if (!string.IsNullOrEmpty(usuaentyty.email) && clave1 == claveconf)
           {
            this.usuarioact.ActualizarUsuario(correo, claveconf);
            Label1.Text = "Su clave fue actualizada correctamente en la BD";
           }
        else
           {
            Label1.Text = "Confirme su clave dont match";
        }
    }
}