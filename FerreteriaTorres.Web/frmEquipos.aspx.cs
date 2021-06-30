using FerreteriaTorres.Web.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {

        #region "Variables Globales"
        private static string strApp;
        #endregion

        #region "Metodos Personalizados"
        private void Mensaje(string Texto)
        { 
            //this.lblMsj.Text = Texto.Trim(); 
        }

        private void LlenarComboTipoEquipo()
        {
            try
            {
                clsTipoEquipos ObjclsTE = new clsTipoEquipos(strApp);
                if (!ObjclsTE.LlenarCombo(this.rblTipoEquipo))
                {
                    Mensaje(ObjclsTE.Error);
                    return;
                }
            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //cuando se cargue por primera ves 
            {
                strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                //intOpcion = 0;
                LlenarComboTipoEquipo();
                this.rblTipoEquipo.SelectedIndex = 0;
                


            }
        }
    }
}