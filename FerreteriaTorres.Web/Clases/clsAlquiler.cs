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

        public string Error { get; set; }
        public string strNroDocumento { get; set; }
        public DateTime FechaHoy { get; set; }
        public string strDireCliente { get; set; }
        public string strIdAlquiler { get; set; }
        public string strIdEquipo { get; set; }
        public string strDescripcion { get; set; }
        public int intCantidad { get; set; }
        public float fltVrUnitario { get; set; }
        public int intCantAlquilada { get; set; }
        public float fltPorcenDescuento { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaDevolucion { get; set; }
        #endregion

        #region "Constructor"

        public clsAlquiler(string Aplicacion)
        {
            strApp = Aplicacion;

            Error = string.Empty;
            strNroDocumento = string.Empty;
            FechaHoy = DateTime.Now.Date;
            strDireCliente = string.Empty;
            strIdAlquiler = string.Empty;
            strIdEquipo = string.Empty;
            strDescripcion = string.Empty;
            intCantidad = 0;
            fltVrUnitario = 0;
            intCantAlquilada = 0;
            fltPorcenDescuento = 0;
            FechaEntrega = DateTime.Now.Date;
            FechaDevolucion = DateTime.Now.Date;
        }

        public clsAlquiler (string strApp, string strNroDocumento, DateTime fechaHoy, string strDireCliente,
                            string IdAlquiler, string strIdEquipo, string strDescripcion, int intCantidad,
                            float fltVrUnitario, int intCantAlquilada, float fltPorcenDescuento, DateTime fechaEntrega,
                            DateTime fechaDevolucion)
        {
            Error = string.Empty;
            this.strNroDocumento = strNroDocumento;
            FechaHoy = fechaHoy;
            this.strDireCliente = strDireCliente;
            this.strIdAlquiler = strIdAlquiler;
            this.strIdEquipo = strIdEquipo;
            this.strDescripcion = strDescripcion;
            this.intCantAlquilada = intCantAlquilada;
            this.intCantidad = intCantidad;
            this.fltVrUnitario = fltVrUnitario;
            this.fltPorcenDescuento = fltPorcenDescuento;
            FechaEntrega = fechaEntrega;
            FechaDevolucion = fechaDevolucion;            
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

        private bool Validar ()
        {
            if (strNroDocumento == string.Empty)
            {
                Error = "Numero de documento obligatorio!!";
                return false;
            }

            if (strDireCliente == string.Empty)
            {
                Error = "Ingrese la dirección de el cliente";
                return false;
            }

            if (strIdAlquiler == string.Empty)
            {
                Error = "Es necesario la identificación de el alquiler";
                return false;
            }

            if (strIdEquipo == string.Empty)
            {
                Error = "Es necesario la identificación de el Equipo";
                return false;
            }

            if (strDescripcion == string.Empty)
            {
                Error = "Hace falta la descripción de el producto";
                return false;
            }

            if (fltVrUnitario <= 0)
            {
                Error = "El valor de el producto debe se mayor a 0";
                return false;
            }

            if (Convert.ToString(fltVrUnitario) == string.Empty)
            {
                Error = "Debe ingresar el valor de el producto";
                return false;
            }

            if ( intCantidad < 0)
            {
                Error = "Verifique la cantidad";
                return false;
            }

            if (Convert.ToString(intCantidad) == string.Empty)
            {
                Error = "Debe ingresar la cantidad";
                return false;
            }

            if ( intCantAlquilada < 0)
            {
                Error = "Verique la cantidad";
                return false;
            }

            if (Convert.ToString(intCantAlquilada) == string.Empty)
            {
                Error = "Debe ingresar la cantidad alquilada";
                return false;
            }

            if ( fltPorcenDescuento < 0)
            {
                Error = "Verifique el porcentaje de descuento";
                return false;
            }

            if (Convert.ToString(fltPorcenDescuento) == string.Empty)
            {
                Error = "Debe ingresar el porcentaje de descuento";
                return false;
            }
            return true;
        }
        #endregion

        #region "Metodos Publicos"

        public bool llenarGrid(GridView Grid)
        {
            strSQL = "Falta colocar la sentencia";
            clsGenerales ObjGen = new clsGenerales();
            if (!ObjGen.llenarGrid(strApp, Grid, strSQL))
            {
                Error = ObjGen.Error;
                ObjGen = null;
                return false;
            }
            ObjGen = null;
            return true;
        }

        public bool grabarMaestro()
        {
            if (!Validar())
                return false;
            strSQL = "Falta la sentencia SQL '" + strNroDocumento + "', '" + FechaHoy + "', '" + strDireCliente + "', '" + strIdAlquiler + "', '" +
            strIdEquipo + "', '" + strDescripcion + "', '" + intCantidad + "', '" + intCantAlquilada + "', '" +
            fltVrUnitario + "', '" + fltPorcenDescuento + "', '" + FechaEntrega + "', '" + FechaDevolucion + "';";
            return Grabar();
        }

        #endregion
    }
}