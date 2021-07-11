using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web
{
    public partial class Entradaa : System.Web.UI.Page
    {
        #region "Variables Globales"
        private static string strApp;
        #endregion

        #region "Metodos Perzonalizados"
        private void Mensaje(string Texto)
        {
            this.lblError.Text = Texto.Trim();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string strUsuario, strContrasenia;

                strUsuario = txtUsuario.Text.Trim().ToLower();
                strContrasenia = txtContraseña.Text;

                Clases.clsLogin ObjclsL = new Clases.clsLogin(strApp, strUsuario, strContrasenia);

                if (!ObjclsL.Login())
                {
                    lblError.Text = ObjclsL.Error;
                    ObjclsL = null;
                    txtUsuario.Text = string.Empty;
                    txtContraseña.Text = string.Empty;
                    txtUsuario.Focus();
                    return;

                }

                Session["strNroDocumento"] = ObjclsL.strNroDocumento;
                Session["strNombreEmpleado"] = ObjclsL.strNombreEmpleado;

                ObjclsL = null;
                Response.Redirect("frmInicio.aspx");

            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            txtUsuario.Focus();
        }


    }
}