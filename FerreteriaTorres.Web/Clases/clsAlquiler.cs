using libConexionBD;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web.Clases
{
    public class clsAlquiler
    {
        #region "Atributos/Propiedades"
        private string strApp;
        private string strSQL;
       

        public string Error { get; private set; }

        public int intIdAlquiler { get; set; }
        public DateTime Fecha { get; set; }
        public string strNroDocumento { get; set; }
        public string strDireccion { get; set; }
        public string strCreadoPor { get; set; }
        public float fltVrBruto { get; set; }
        public float fltVrDescuento { get; set; }
        public float fltVrIva { get; set; }
        public float fltVrNeto { get; set; }
        public string strNombreCliente { get; set; }
        public DataSet Myds { get; private set; }
        public DataTable Mydt { get; private set; }

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
            strNombreCliente = string.Empty;
            fltVrBruto = 0;
            fltVrDescuento = 0;
            fltVrIva = 0;
            fltVrNeto = 0;

        }

        public clsAlquiler(string Aplicacion, DateTime fecha,
            string strNroDocumento, string strDireccion,
            string strCreadoPor,float fltVrBruto,float fltVrDescuento,float fltVrIva,float fltVrNeto)
        {
            strApp = Aplicacion;
            Error = string.Empty;
            Fecha = fecha;
            this.strNroDocumento = strNroDocumento;
            this.strDireccion = strDireccion;
            this.strCreadoPor = strCreadoPor;
            this.fltVrBruto = fltVrBruto;
            this.fltVrDescuento = fltVrDescuento;
            this.fltVrIva = fltVrIva;
            this.fltVrNeto = fltVrNeto;
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
                intIdAlquiler = Convert.ToInt32( ObjCnx.vrUnico.ToString());
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
            strSQL = "EXEC GrabarArquiler '" + Fecha + "', '" 
                + strNroDocumento + "', '" + strDireccion + "', '" + strCreadoPor
                + "', " + fltVrBruto+", "+ fltVrDescuento + ", " + fltVrIva+ ", "+fltVrNeto + " ;";
            return Grabar();
        }

        public bool BuscarAlquiler(int StrIdEquipo, GridView grid)
        {
            try
            {
                if (StrIdEquipo <= 0 || grid == null)
                {
                    Error = "Nro. de Caso no Válido";
                    return false;
                }
                strSQL = "EXEC BuscarAlquiler " + StrIdEquipo + ";";
                clsConexionBD objCnx = new clsConexionBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.llenarDataSet(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }

                Myds = objCnx.dataSet_Lleno;
                objCnx = null;
                Mydt = Myds.Tables[0];
                if (Mydt.Rows.Count <= 0)
                {
                    Error = "No existe el caso nro.: " + StrIdEquipo;
                    Myds.Clear();
                    Myds = null;
                    return false;
                }
                DataRow dr = Mydt.Rows[0];
                intIdAlquiler = Convert.ToInt32(dr["intIdAlquiler"]); // ó dr[0]
                if (dr["TipoCliente"].ToString() == "N")
                {
                    strNombreCliente = dr["Apellidos"] + " " + dr["strNombres"];
                }
                else
                {
                    strNombreCliente = dr["strRazonSocial"].ToString();
                }
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                strNroDocumento = dr["strNroDocumento"].ToString();
                strDireccion = dr["strDireccion"].ToString();
                strCreadoPor = dr["strCreadoPor"].ToString();
                fltVrBruto = Convert.ToSingle(dr["fltVrBruto"]);
                fltVrDescuento = Convert.ToSingle(dr["fltVrDescuento"]);
                fltVrIva = Convert.ToSingle(dr["fltVrIva"]);
                fltVrNeto = Convert.ToSingle(dr["fltVrNeto"]);

                Mydt.Clear();
                //Llenar el grid y darle formato
                Mydt = Myds.Tables[1];
                grid.DataSource = Mydt;
                grid.DataBind();
                grid.GridLines = GridLines.Both;
                grid.CellPadding = 1;
                grid.ForeColor = System.Drawing.Color.Black;
                grid.BackColor = System.Drawing.Color.Beige;
                grid.AlternatingRowStyle.BackColor = System.Drawing.Color.Gainsboro;
                grid.HeaderStyle.BackColor = System.Drawing.Color.Aqua;
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