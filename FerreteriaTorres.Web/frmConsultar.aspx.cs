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

        #region "Deshabilitar"
        private void Deshabilitar()
        {
            this.txtIdAlquiler.Enabled = false;
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
                Deshabilitar();
            }
        }



        protected void btnBuscarIdAlquiler_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}