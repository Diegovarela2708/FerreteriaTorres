using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FerreteriaTorres.Web.Clases
{
    public class clsAlquilerDetalle
    {
        #region "Atributos/ propiedades"
        
        public string strIdEquipo { get; set; }
        public string strDescripcion { get; set; }
        public int intCantidad { get; set; }

        public int intImpuesto { get; set; }
        public float fltVrUnit { get; set; }
        public int fltPorcentajeDes { get; set; }
        public float fltVrDescuento { get { return fltVrBruto * fltPorcentajeDes; } }
        public float fltVrIva { get { return fltVrUnit * intCantidad - fltVrBruto; } }

        public DateTime FechaEntrega { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public float fltVrBruto { get { return fltVrUnit * intCantidad / (1 + intImpuesto); } }

        public float fltVrNeto { get { return fltVrUnit * intCantidad-fltVrDescuento; } }


        #endregion
    }
}