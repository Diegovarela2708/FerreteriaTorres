using libConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FerreteriaTorres.Web.Clases
{
    public class clsDetalleArquiler
    {
        #region "Atributos/ propiedades"

        private string strApp;
        private string strSQL;



        public string Error { get; private set; }

        public int intIdAlquilerDetalle { get; set; }
        public int intIdAlquiler { get; set; }
        public string strIdEquipo { get; set; }
        public int intCantidad { get; set; }
        public float fltVrUnit { get; set; }
        public float fltPorcentajeDes { get; set; }
        public float fltVrDescuento { get; set; }
        public float fltVrIva { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaDevolucion { get; set; }



        #endregion

        #region "Constructor"
        public clsDetalleArquiler(string Aplicacion)
        {
            strApp = Aplicacion;
            Error = string.Empty;

            intIdAlquiler = 0;
            strIdEquipo = string.Empty;
            intCantidad = 0;
            fltVrUnit = 0;
            fltPorcentajeDes = 0;
            fltVrDescuento = 0;
            fltVrIva = 0;
        }

        public clsDetalleArquiler(string Aplicacion, int intIdAlquiler, string strIdEquipo, int intCantidad, float fltVrUnit, float fltPorcentajeDes, float fltVrDescuento, float fltVrIva, DateTime fechaEntrega, DateTime fechaDevolucion)
        {
            strApp = Aplicacion;
            Error = string.Empty;

            this.intIdAlquiler = intIdAlquiler;
            this.strIdEquipo = strIdEquipo;
            this.intCantidad = intCantidad;
            this.fltVrUnit = fltVrUnit;
            this.fltPorcentajeDes = fltPorcentajeDes;
            this.fltVrDescuento = fltVrDescuento;
            this.fltVrIva = fltVrIva;
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
                intIdAlquilerDetalle = Convert.ToInt32(ObjCnx.vrUnico.ToString());
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

        //private bool Validar()
        //{

        //    if (strNroDocumento == string.Empty)
        //    {
        //        Error = "Numero de documento obligatorio!!";
        //        return false;
        //    }

        //    if (strDireccion == string.Empty)
        //    {
        //        Error = "Ingrese la dirección de el cliente";
        //        return false;
        //    }

        //    if (strCreadoPor == string.Empty)
        //    {
        //        Error = "Usuario no logueado";
        //        return false;
        //    }

        //    return true;
        //}
        #endregion

        #region "Metodos Publicos"

        public bool grabarMaestro()
        {
            //if (!Validar())
            //    return false;
            strSQL = "EXEC GrabarArquilerDetalle " + intIdAlquiler + ", '" + strIdEquipo + "',"
                + intCantidad + ", " + fltVrUnit + ", " + fltPorcentajeDes + ", " +
                fltVrDescuento + ", " + fltVrIva + ", '" + FechaEntrega + "', '" + FechaDevolucion + "';";
            return Grabar();
        }
        #endregion
    }
}