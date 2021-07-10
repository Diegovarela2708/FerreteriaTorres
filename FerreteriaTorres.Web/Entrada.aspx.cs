using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace FerreteriaTorres.Web
{
    public partial class Entrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string Usuario = "Juan";
            string Clave = "12345";
            try
            {
                if(txtUsuario.Text==Usuario && txtContraseña.Text == Clave)
                {
                    Response.Redirect("frmInicio.aspx");
                    Session["User"] = Usuario;
                    Session["nroDoc"] = "1234";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}