using libConexionBD;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web.Clases
{
    public class clsEntrada
    {
        #region "Atributos/Propiedades"
        private string strApp;
        private string strSQL;
        private SqlDataReader myReader;

        public string Error { get; private set; }
        public string strUsuario { get; set; }

        public string strContrasenia { get; set; }

        public string strNombreEmpleado { get; set; }

        public int idEmpleado { get; set; }

        #endregion

        #region "Constructor"
        public clsEntrada(string Aplicacion)
        {
            strApp = Aplicacion;

            Error = string.Empty;
            strUsuario = string.Empty;
            strContrasenia = string.Empty;

        }

        public clsEntrada(string Aplicacion, string strUsuario, string strContrasenia)
        {
            strApp = Aplicacion;
            Error = string.Empty;

            this.strUsuario = strUsuario;
            this.strContrasenia = strContrasenia;
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

            if (strContrasenia == string.Empty)
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
            ObjCnx.SQL = "USP_Login" + strUsuario +"," +strContrasenia + ";";

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

            idEmpleado = myReader.GetInt32(0);
            strNombreEmpleado = myReader.GetString(1);

            myReader.Close();
            ObjCnx.cerrarCnx();
            ObjCnx = null;

            return true;
        }

        #endregion

    }
}