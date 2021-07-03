using libConexionBD;
using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web.Clases
{
    public class clsEquipos
    {
        #region "Atributos/ propiedades"

        private string strApp;

        private string strSQL;


        private SqlDataReader myReader;

        public string Error { get; private set; }
        public string strIdEquipo { get; set; }
        public string strDescripcion { get; set; }
        public int intIdTipoEquipo { get; set; }
        public float fltVrUnit { get; set; }
        public float fltVrPrestamo { get; set; }
        public int intImpuesto { get; set; }
        public int intCantExistencia { get; set; }
        public int intIdMarca { get; set; }
        public bool Activo { get; set; }
        public string strCaracteristicas { get; set; }
        public string strCreadoPor { get; set; }
        public DateTime FechaCreado { get; set; }
        #endregion

        #region "Constructor"
        public clsEquipos(string Aplicacion)
        {
            strApp = Aplicacion;

            Error = string.Empty;
            strIdEquipo = string.Empty;
            strDescripcion = string.Empty;
            intIdTipoEquipo = 0;
            fltVrUnit = 0;
            fltVrPrestamo = 0;
            intImpuesto = 0;
            intCantExistencia = 0;
            intIdMarca = 0;
            Activo = true;
            strCaracteristicas = string.Empty;
            strCreadoPor = string.Empty;


        }

        public clsEquipos(string strApp, string strIdEquipo, string strDescripcion, int intIdTipoEquipo,
            float fltVrUnit, float fltVrPrestamo, int intImpuesto, int intCantExistencia, int intIdMarca, bool activo,
            string strCaracteristicas, string strCreadoPor, DateTime fechaCreado) : this(strApp)
        {
            Error = string.Empty;
            this.strIdEquipo = strIdEquipo;
            this.strDescripcion = strDescripcion;
            this.intIdTipoEquipo = intIdTipoEquipo;
            this.fltVrUnit = fltVrUnit;
            this.fltVrPrestamo = fltVrPrestamo;
            this.intImpuesto = intImpuesto;
            this.intCantExistencia = intCantExistencia;
            this.intIdMarca = intIdMarca;
            Activo = activo;
            this.strCaracteristicas = strCaracteristicas;
            this.strCreadoPor = strCreadoPor;
            FechaCreado = fechaCreado;
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
                strIdEquipo = ObjCnx.vrUnico.ToString();
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
            if (strIdEquipo == string.Empty)
            {
                Error = "Falta Id Del producto";
                return false;
            }
            if (strDescripcion == string.Empty)
            {
                Error = "Falta la descripcion del producto";
                return false;
            }
            if (intIdTipoEquipo == 0)
            {
                Error = "Debe de seleccionar un Tipo de equipo";
                return false;
            }
            if (fltVrUnit <= 0)
            {
                Error = "El valor del producto debe de ser mayor a 0";
                return false;
            }

            if (Convert.ToString(fltVrUnit) == string.Empty)
            {
                Error = "Debe de ingresar el valor unitario";
                return false;
            }
            if (fltVrPrestamo <= 0)
            {
                Error = "El valor del prestamo debe de ser mayor a 0";
                return false;
            }

            if (Convert.ToString(fltVrPrestamo) == string.Empty)
            {
                Error = "Debe de ingresar el valor de prestamo";
                return false;
            }
            if (intImpuesto < 0 || intImpuesto > 100 || Convert.ToString(intImpuesto) == string.Empty)
            {
                Error = "Verifique el impuesto";
                return false;
            }

            if (intCantExistencia < 0 || intCantExistencia > 100 || Convert.ToString(intCantExistencia) == string.Empty)
            {
                Error = "Verifique La cantidad";
                return false;
            }

            return true;
        }

        #endregion

        #region "Metodos Publicos"
        public bool llenarGrid(GridView Grid)
        {
            strSQL = "EXEC BuscarGeneral;";
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
            int intAct = Activo ? 1 : 0;
            strSQL = "EXEC GrabarEquipo '" + strIdEquipo + "', '" + strDescripcion + "', '" + intIdTipoEquipo + "', '" + fltVrUnit + "', '" +
            fltVrPrestamo + "', '" + intImpuesto + "', '" + intCantExistencia + "', '" + intIdMarca + "', '" +
            intAct + "', '" + strCaracteristicas + "', '" + strCreadoPor + "', '" + FechaCreado+"';";
            return Grabar();
        }
        #endregion

    }
}