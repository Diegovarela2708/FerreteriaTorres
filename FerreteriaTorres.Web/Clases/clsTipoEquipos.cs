﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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

        public bool LlenarCombo(DropDownList Combo)
        {
            try
            {
                if (Combo == null)
                {
                    Error = "Error";
                    return false;
                }
                strSQL = "EXEC ComboTipoEquipo;";
                clsGenerales ObjGen = new clsGenerales();
                if (!ObjGen.llenarCombo(strApp,Combo,strSQL,"Clave","Dato"))
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