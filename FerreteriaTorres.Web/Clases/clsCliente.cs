using libConexionBD;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web.Clases
{
    public class clsCliente
    {
        #region "Atributos / propiedades"
        private string strApp;
        public string Error { get; private set; }

        private string strSQL;
        public string strNroDocumento { get; set; }
        public string strNombres { get; set; }
        

        private SqlDataReader myReader;
        #endregion

        #region "Constructor"
        public clsCliente(string Aplicacion)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            Error = string.Empty;
        }
        #endregion

        #region "Metodos Publicos"
        public bool llenarGrid(GridView Grid, string NroDocumento)
        {
            try
            {
                strSQL = "EXEC ConsultaHistoriaPorCliente '" + NroDocumento + "';";
                clsConexionBD objCnx = new clsConexionBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.Consultar(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                myReader = objCnx.dataReader_Lleno;
                if (!myReader.HasRows)
                {
                    Error = "No existe registro con Nro. de documento: " + NroDocumento;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                clsGenerales ObjGen = new clsGenerales();
                if (!ObjGen.llenarGrid(strApp, Grid, strSQL))
                {
                    Error = ObjGen.Error;
                    ObjGen = null;
                    return false;
                }
                ObjGen = null;
                myReader.Close();
                objCnx.cerrarCnx();
                objCnx = null;
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool BuscarCliente(string NroDocumento)
        {
            try
            {
                strSQL = "EXEC BuscarClienteNroDocumento '" + NroDocumento + "';";
                clsConexionBD objCnx = new clsConexionBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.Consultar(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                myReader = objCnx.dataReader_Lleno;
                if (!myReader.HasRows)
                {
                    Error = "No existe registro con Nro. de documento: " + NroDocumento;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }

                myReader.Read();
                this.strNroDocumento = myReader.GetString(0);
                 
                if (myReader.GetString(4) == "N")
                {
                    this.strNombres = myReader.GetString(2) + " " + myReader.GetString(3);

                    myReader.Close();
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return true;
                }
                else
                {

                    this.strNombres = myReader.GetString(1);

                    myReader.Close();
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return true;
                }
                
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