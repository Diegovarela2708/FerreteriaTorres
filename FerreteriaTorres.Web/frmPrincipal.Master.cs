using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web
{
    public partial class frmPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["strNombreEmpleado"].ToString();
            }
        }

        protected void trvMenuPpal_SelectedNodeChanged()
        {

        }
    }
}