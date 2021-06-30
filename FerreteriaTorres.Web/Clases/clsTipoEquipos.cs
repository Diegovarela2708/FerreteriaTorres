using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FerreteriaTorres.Web.Clases
{
    public class clsTipoEquipos
    {
        #region "Atributos / Propiedades"

        private string strApp;

        public string Error { get; private set; }

        private string strSQL;

        #endregion

        #region "Constructor"

        public clsTipoEquipos(string Aplicacion)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            Error = string.Empty;
        }

        #endregion

        #region "Metodos Pubicos"

        #endregion
    }
}