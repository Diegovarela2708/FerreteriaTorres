using libConexionBD;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web.Clases
{
    public class clsLogin
    {
        #region "Atributos/Propiedades"
        private string strApp;

        

        private SqlDataReader myReader;

        public string Error { get; private set; }
        public string strUsuario { get; set; }

        public string strContrasena { get; set; }

        public string strNombreEmpleado { get; set; }

        public string strNroDocumento { get; set; }

        public bool Activo { get; set; }

        #endregion

        #region "Constructor"
        public clsLogin(string Aplicacion)
        {
            strApp = Aplicacion;

            Error = string.Empty;
            strUsuario = string.Empty;
            strContrasena = string.Empty;
            Activo = false;
        }

        public clsLogin(string Aplicacion, string strUsuario, string strContrasenia)
        {
            strApp = Aplicacion;
            Error = string.Empty;

            this.strUsuario = strUsuario;
            this.strContrasena = strContrasenia;
        }
        #endregion

        #region "Metodos Privados"

        private bool Validar()
        {

            if (strUsuario == string.Empty)
            {
                Error = "Nombre de usuario obligatorio!!";
                return false;
            }

            if (strContrasena == string.Empty)
            {
                Error = "Contraseña obligatoria!!";
                return false;
            }

            return true;
        }

        public bool Login()
        {



            if (string.IsNullOrEmpty(strApp))
            {
                Error = "falta el nombre de la aplicación";
                return false;
            }

            if (!Validar())
            {
                return false;
            }
            clsConexionBD ObjCnx = new clsConexionBD(strApp);
            ObjCnx.SQL = "ValidarUsuario '" + strUsuario +"','" + strContrasena + "';";

            if (!ObjCnx.Consultar(false))
            {
                Error = ObjCnx.Error;
                ObjCnx.cerrarCnx();
                ObjCnx = null;
                return false;
            }

            myReader = ObjCnx.dataReader_Lleno;
            if(!myReader.HasRows)
            {
                Error = "Usuario o Contraseña incorrecto";
                ObjCnx.cerrarCnx();
                ObjCnx = null;
                return false;
            }

            myReader.Read();
            Activo = myReader.GetBoolean(4);
            if (!Activo)
            {
                Error = "El usuario esta deshabilitado";
                ObjCnx.cerrarCnx();
                ObjCnx = null;
                return false;
            }
            strUsuario = myReader.GetString(0);
            strContrasena = myReader.GetString(1);
            strNroDocumento = myReader.GetString(2);
            strNombreEmpleado = myReader.GetString(3);
            
            myReader.Close();
            ObjCnx.cerrarCnx();
            ObjCnx = null;

            return true;
        }

        #endregion

    }
}