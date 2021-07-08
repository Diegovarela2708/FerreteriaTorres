using libConexionBD;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web.Clases
{
    public class clsAlquiler
    {
        #region "Atributos/Propiedades"
        private string strApp;
        private string strSQL;

        private SqlDataReader myReader;

        public string Error { get; private set; }
        public DateTime Fecha { get; set; }
        public string strNroDocumento { get; set; }
        public string strDireccion { get; set; }
        public string strCreadoPor { get; set; }

        #endregion

        #region "Constructor"

        public clsAlquiler(string Aplicacion)
        {
            strApp = Aplicacion;

            Error = string.Empty;
            Fecha = DateTime.Now;
            strNroDocumento = string.Empty;
            strDireccion = string.Empty;
            strCreadoPor = string.Empty;

        }

        public clsAlquiler(string error, DateTime fecha,
            string strNroDocumento, string strDireccion,
            string strCreadoPor) : this(error)
        {
            Fecha = fecha;
            this.strNroDocumento = strNroDocumento;
            this.strDireccion = strDireccion;
            this.strCreadoPor = strCreadoPor;
        }


        #endregion

        #region "Metodos Privados"
        private bool Grabar()
        {
            try
            {
                if (string.IsNullOrEmpty(strApp))
                {
                    Error = "Falta el nombre de la aplicación";
                    return false;
                }
                clsConexionBD ObjCnx = new clsConexionBD(strApp);
                ObjCnx.SQL = strSQL;
                if (!ObjCnx.consultarValorUnico(false))
                {
                    Error = ObjCnx.Error;
                    ObjCnx.cerrarCnx();
                    ObjCnx = null;
                    return false;
                }
                strNroDocumento = ObjCnx.vrUnico.ToString();
                ObjCnx.cerrarCnx();
                ObjCnx = null;
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        private bool Validar()
        {
            
            if (strNroDocumento == string.Empty)
            {
                Error = "Numero de documento obligatorio!!";
                return false;
            }

            if (strDireccion == string.Empty)
            {
                Error = "Ingrese la dirección de el cliente";
                return false;
            }

            if (strCreadoPor == string.Empty)
            {
                Error = "Usuario no logueado";
                return false;
            }

            return true;
        }
        #endregion

        #region "Metodos Publicos"

        public bool grabarMaestro()
        {
            if (!Validar())
                return false;
            strSQL = "Falta la sentencia SQL '" + Fecha + "', '" 
                + strNroDocumento + "', '" + strDireccion + "', '" + strCreadoPor + "';";
            return Grabar();
        }

        #endregion
    }
}