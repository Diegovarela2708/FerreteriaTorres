using System;
using FerreteriaTorres.Web.Clases;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        #region "Variables Globales"
        private static string strApp;
        private static int intOpcion;
        #endregion

        #region "Variables FRM"
        public string strNroDocumento;
        public DateTime FechaHoy;
        public string strDireCliente;
        public string strIdAlquiler;
        public string strIdEquipo;
        public string strDescripcion;
        public int intCantidad;
        public float fltVrUnitario;
        public int intCantAlquilada;
        public float fltPorcenDescuento;
        public DateTime FechaEntrega;
        public DateTime FechaDevolucion;
        #endregion

        #region "Metodos Personalizados"

        private void Mensaje(string Texto)
        {
            this.lblMsj.Text = Texto.Trim();
        }
        private void Deshabilitar()
        {
            this.txtNroDocumento.Enabled = false;
            this.txtFecha.Enabled = false;
            this.txtDireCliente.Enabled = false;
            this.txtIdAlquiler.Enabled = false;
            this.txtIdEquipo.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCantidad.Enabled = false;
            this.txtValorUnitario.Enabled = false;
            this.txtCantidadAlquilada.Enabled = false;
            this.txtPorcentajeDescuento.Enabled = false;
            this.txtFechaEntrega.Enabled = false;
            this.txtFechaDevolucion.Enabled = false;
        }

        private void Habilitar ()
        {
            this.txtNroDocumento.Enabled = true;
            this.txtFecha.Enabled = true;
            this.txtDireCliente.Enabled = true;
            this.txtIdAlquiler.Enabled = true;
            this.txtIdEquipo.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtCantidad.Enabled = true;
            this.txtValorUnitario.Enabled = true;
            this.txtCantidadAlquilada.Enabled = true;
            this.txtPorcentajeDescuento.Enabled = true;
            this.txtFechaEntrega.Enabled = true;
            this.txtFechaDevolucion.Enabled = true;
        }

        private void LlenarGridAlquiler()
        {
            try
            {
                clsAlquiler ObjclsAl = new clsAlquiler (strApp);
                if (!ObjclsAl.llenarGrid(this.grvDatos))
                {
                    Mensaje(ObjclsAl.Error);
                    ObjclsAl = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        public void Grabar ()
        {
            try
            {
                strNroDocumento = txtNroDocumento.Text.Trim();
                FechaHoy = System.DateTime.UtcNow.ToLocalTime();
                strDireCliente = txtDireCliente.Text.Trim();
                strIdAlquiler = txtIdAlquiler.Text.Trim();
                strIdEquipo = txtIdEquipo.Text.Trim();
                strDescripcion = txtDescripcion.Text.Trim();
                intCantidad = Convert.ToInt32(txtCantidad.Text.Trim());
                fltVrUnitario = Convert.ToSingle(txtValorUnitario.Text.Trim());
                intCantAlquilada = Convert.ToInt32(txtCantidadAlquilada.Text.Trim());
                fltPorcenDescuento = Convert.ToSingle(txtPorcentajeDescuento.Text.Trim());
                FechaEntrega = System.DateTime.UtcNow.ToLocalTime();
                FechaDevolucion = System.DateTime.UtcNow.ToLocalTime();

                clsAlquiler ObjclsAl = new clsAlquiler(strApp, strNroDocumento, FechaHoy,strDireCliente,strIdAlquiler,strIdEquipo,strDescripcion,intCantidad,
                                                       fltVrUnitario, intCantAlquilada,fltPorcenDescuento,FechaEntrega,FechaDevolucion);

                if(intOpcion == 1)
                {
                    if(!ObjclsAl.grabarMaestro())
                    {
                        Mensaje(ObjclsAl.Error);
                        ObjclsAl = null;
                        return;
                    }
                }

                /* Diego en esta parte sigue otra cosa que el man tiene en el formulario de el
                 pero no se como continuarlo, quedó faltando el page load y en los cls donde van
                las sentencias sql no las pude colocar debido a que no tengo sql y no puedo probar si las
                cosas van quedando bien*/

            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}