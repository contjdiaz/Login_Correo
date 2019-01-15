using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite_Correo.Buusiness;
using Website_Correo.DACL;
using WebSite_Correo.Entities;


public partial class Inicio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Enviar classe = new Enviar();
        string file = FileUpload1.PostedFile.FileName;
        classe.email(txtemail.Text, txtasunto.Text, txtmensaje.Text, file);

        if (Enviar.teste == true)
        {
            Label1.Text = "Se envio correctamente";
            Label1.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            Label1.Text = "No se pudo enviar";
            Label1.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void Anexar_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileextension = System.IO.Path.GetExtension(FileUpload1.FileName);

            if(fileextension.ToLower() !=".doc" && fileextension.ToLower() != ".docx")
            {
                Label1.Text = "Only files with doc extension can be loaded";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                int filesize = FileUpload1.PostedFile.ContentLength;
                if (filesize>2897152)
                {
                    Label1.Text = "Maximum 2MB";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                    Label1.Text = "File Uploaded";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
            }
            
        }

        else
        {
            Label1.Text= "Please select file to upload";
            Label1.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void Validar_Click(object sender, EventArgs e)
    {
        usuariobusiness usua = new usuariobusiness();
        UsuarioEntity usuaentity = new UsuarioEntity();

        usuaentity = usua.ValidarUsuario2(txtcorreo.Text, txtcontra.Text);

        if (usuaentity.SeAutentica == true)
        {
            ////http://localhost:54706/Default.aspx
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            Response.Write("<script> alert(" + "'Datos Incorrectos'" + ")</script>");
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Registro.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Recuperar.aspx");
    }
}