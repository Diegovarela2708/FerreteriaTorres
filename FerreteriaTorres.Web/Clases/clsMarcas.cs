using System;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web.Clases
{
    public class clsMarcas
    {
        #region "Atributos / propiedades"
        private string strApp;
        public string Error { get; private set; }

        private string strSQL;
        #endregion

        #region "Constructor"
        public clsMarcas(string Aplicacion)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            Error = string.Empty;
        }
        #endregion

        #region "Metodos Publicos"

        public bool LlenarCombo(DropDownList Combo)
        {
            try
            {
                if (Combo == null)
                {
                    Error = "Error";
                    return false;
                }

                strSQL = "EXEC ComboMarcas;";
                clsGenerales ObjGen = new clsGenerales();
                if (!ObjGen.llenarCombo(strApp, Combo, strSQL, "Clave", "Dato"))
                {
                    Error = ObjGen.Error;
                    ObjGen = null;
                    return false;
                }
                ObjGen = null;
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        #endregion
    }
}