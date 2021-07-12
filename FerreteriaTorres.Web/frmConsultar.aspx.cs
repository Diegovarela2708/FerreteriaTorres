using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web
{
    public partial class Formulario_web110 : System.Web.UI.Page
    {
        #region "Global"
        private static string strApp;
        private int intIdAlquiler;
        #endregion
        #region "Metodos personalizados"

        private void Mensaje(string Texto)
        {
            this.lblMsj.Text = Texto.Trim();
        }
        private void Deshabilitar()
        {
            this.txtFecha.Enabled = false;
            this.txtNroDocumento.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtCreadoPor.Enabled = false;
        }

        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                Deshabilitar();
            }
        }



        protected void btnBuscarIdAlquiler_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Mensaje(string.Empty);
                
                
                
                if (txtIdAlquiler.Text == string.Empty)
                {
                    Mensaje("Numero de alquiler no valido.");
                    return;
                }
                if (!int.TryParse(txtIdAlquiler.Text,out intIdAlquiler))
                {
                    Mensaje("Solo se permiten numeros enteros.");
                    return;
                }
                if (intIdAlquiler < 1 )
                {
                    Mensaje("el numero debe de ser mayor a 0");
                    return;
                }
                Clases.clsAlquiler ObjclsA = new Clases.clsAlquiler(strApp);
                if (!ObjclsA.BuscarAlquiler(intIdAlquiler, this.grvDatos))
                {
                    Mensaje(ObjclsA.Error);
                    ObjclsA = null;
                    return;
                }
                this.txtIdAlquiler.Text = ObjclsA.intIdAlquiler.ToString();
                this.txtFecha.Text = ObjclsA.Fecha.ToShortDateString();
                this.txtNroDocumento.Text = ObjclsA.strNroDocumento.ToString();
                this.txtDireccion.Text = ObjclsA.strDireccion.ToString() ;
                this.txtCreadoPor.Text = ObjclsA.strCreadoPor;
                ObjclsA = null;
            }
            catch (Exception ex)
            { Mensaje(ex.Message); }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

        }
    }
}