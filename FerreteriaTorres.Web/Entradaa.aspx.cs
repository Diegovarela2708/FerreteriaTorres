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

                Clases.clsEntrada objEntrada = new Clases.clsEntrada(strApp, strUsuario, strContrasenia);

                if (!objEntrada.Login())
                {
                    lblError.Text = objEntrada.Error;
                    objEntrada = null;
                    txtUsuario.Text = string.Empty;
                    txtContraseña.Text = string.Empty;
                    txtUsuario.Focus();
                    return;

                }

                Session["idUsuario"] = objEntrada.idEmpleado;
                Session["Nombre Empleado"] = objEntrada.strNombreEmpleado;

                objEntrada = null;
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