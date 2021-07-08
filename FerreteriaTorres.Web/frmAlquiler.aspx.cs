using FerreteriaTorres.Web.Clases;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        #region "Variables Globales"

        private List<clsAlquilerDetalle> MisDetalleAlquiler;

        private static string strApp;
        private static int intOpcion;

        //Alquiler
        public int intIdAlquiler;
        public DateTime Fecha;
        public string strNroDocumento;
        public string strDireccion;
        public string strCreadoPor;
        //AlquilerDetaller
        public string intIdArquilerDetalle;
        public string strIdEquipo;
        public int intCantidad;
        public float fltVrUnit;
        public float fltPorcentajeDes;
        public float fltVrDescuento;
        public string fltVrIva;
        public string FechaEntrega;
        public string FechaDevolucion;
        //Equipo
        public int intImpuesto;
        public string Descripcion;
        public float VrUnitario;
        public int Existencia;
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
            this.ddlDirecciones.Enabled = false;
            this.txtIdAlquiler.Enabled = false;
            this.txtIdEquipo.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtExistencia.Enabled = false;
            this.txtVrUnitario.Enabled = false;
            this.txtCantidadAlquilada.Enabled = false;
            this.txtPorcentajeDescuento.Enabled = false;
            this.txtFechaEntrega.Enabled = false;
            this.txtFechaDevolucion.Enabled = false;
        }

        private void Habilitar()
        {
            this.txtNroDocumento.Enabled = true;
            this.txtFecha.Enabled = true;
            this.ddlDirecciones.Enabled = true;
            this.txtIdAlquiler.Enabled = true;
            this.txtIdEquipo.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtExistencia.Enabled = true;
            this.txtVrUnitario.Enabled = true;
            this.txtCantidadAlquilada.Enabled = true;
            this.txtPorcentajeDescuento.Enabled = true;
            this.txtFechaEntrega.Enabled = true;
            this.txtFechaDevolucion.Enabled = true;
        }

        private void LlenarGridAlquiler()
        {
            try
            {
                clsCliente ObjclsC = new clsCliente(strApp);
                if (!ObjclsC.llenarGrid(this.grvHistoria, strNroDocumento))
                {
                    Mensaje(ObjclsC.Error);
                    ObjclsC = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        public void Grabar()
        {
            try
            {
                //strNroDocumento = txtNroDocumento.Text.Trim();
                //FechaHoy = System.DateTime.UtcNow.ToLocalTime();
                //strDireCliente = txtDireCliente.Text.Trim();
                //strIdAlquiler = txtIdAlquiler.Text.Trim();
                //strIdEquipo = txtIdEquipo.Text.Trim();
                //strDescripcion = txtDescripcion.Text.Trim();
                //intCantidad = Convert.ToInt32(txtCantidad.Text.Trim());
                //fltVrUnitario = Convert.ToSingle(txtValorUnitario.Text.Trim());
                //intCantAlquilada = Convert.ToInt32(txtCantidadAlquilada.Text.Trim());
                //fltPorcenDescuento = Convert.ToSingle(txtPorcentajeDescuento.Text.Trim());
                //FechaEntrega = System.DateTime.UtcNow.ToLocalTime();
                //FechaDevolucion = System.DateTime.UtcNow.ToLocalTime();

                //clsAlquiler ObjclsAl = new clsAlquiler(strApp, strNroDocumento, FechaHoy,strDireCliente,strIdAlquiler,strIdEquipo,strDescripcion,intCantidad,
                //                                       fltVrUnitario, intCantAlquilada,fltPorcenDescuento,FechaEntrega,FechaDevolucion);

                //if(intOpcion == 1)
                //{
                //    if(!ObjclsAl.grabarMaestro())
                //    {
                //        Mensaje(ObjclsAl.Error);
                //        ObjclsAl = null;
                //        return;
                //    }
                //}

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

        private void Limpiar()
        {
            this.txtNroDocumento.Text = string.Empty;
            this.txtFecha.Text = string.Empty;
            this.txtIdAlquiler.Text = string.Empty;
            this.txtIdEquipo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtExistencia.Text = string.Empty;
            this.txtVrUnitario.Text = string.Empty;
            this.txtCantidadAlquilada.Text = string.Empty;
            this.txtPorcentajeDescuento.Text = string.Empty;
            this.txtFechaEntrega.Text = string.Empty;
            this.txtFechaDevolucion.Text = string.Empty;
            this.grvHistoria.DataBind();
        }

        private void LimpiarDetalle()
        {
            this.txtIdEquipo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtExistencia.Text = string.Empty;
            this.txtVrUnitario.Text = string.Empty;
            this.txtCantidadAlquilada.Text = string.Empty;
            this.txtPorcentajeDescuento.Text = string.Empty;
            this.txtFechaEntrega.Text = string.Empty;
            this.txtFechaDevolucion.Text = string.Empty;
            txtIdEquipo.Focus();
        }

        private void LlenarComboDirecciones()
        {
            try
            {
                clsDireccion ObjclsTE = new clsDireccion(strApp);
                if (!ObjclsTE.LlenarCombo(this.ddlDirecciones, strNroDocumento))
                {
                    Mensaje(ObjclsTE.Error);
                    return;

                }
            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }

        private void Buscar()
        {
            clsEquipos ObjclsE = new clsEquipos(strApp);
            if (!ObjclsE.BuscarAct(strIdEquipo))
            {
                Limpiar();
                Mensaje(ObjclsE.Error);
                ObjclsE = null;
                return;
            }

            Descripcion = ObjclsE.strDescripcion;
            VrUnitario = ObjclsE.fltVrUnit;
            intImpuesto = ObjclsE.intImpuesto;
            Existencia = ObjclsE.intCantExistencia;

            txtDescripcion.Text = Descripcion;
            txtVrUnitario.Text = VrUnitario.ToString();
            txtExistencia.Text = Existencia.ToString();

            Session["txtDescripcion"] = ObjclsE.strDescripcion;
            Session["txtVrUnitario"] = ObjclsE.fltVrUnit.ToString();
            Session["intImpuesto"] = ObjclsE.intImpuesto;
            Session["txtExistencia"] = ObjclsE.intCantExistencia.ToString();
            Session["ObjclsE"] = ObjclsE;

            ObjclsE = null;
        }

        private void ValidarDetalle()
        {
            if (txtCantidadAlquilada.Text == string.Empty)
            {
                Mensaje("Debe de ingresar la cantidad");
                txtCantidadAlquilada.Focus();
                return;
            }
            long Cantidad;
            if (!long.TryParse(txtCantidadAlquilada.Text, out Cantidad))
            {
                Mensaje("Debe de ingresar un numero entero");
                txtCantidadAlquilada.Focus();
                return;
            }
            if (Cantidad < 1)
            {
                Mensaje("La cantidad debe de ser mayor a 0");
                txtCantidadAlquilada.Focus();
                return;
            }
            if (Cantidad > Convert.ToInt32(txtCantidadAlquilada.Text))
            {
                Mensaje("La cantidad es mayor a la del inventario");
                txtCantidadAlquilada.Focus();
                return;
            }
            if (txtPorcentajeDescuento.Text == string.Empty)
            {
                
                if (!float.TryParse(txtPorcentajeDescuento.Text, out fltPorcentajeDes))
                {
                    Mensaje("Debe de ingresar un numero entero");
                    txtPorcentajeDescuento.Focus();
                    return;
                }
                if (fltPorcentajeDes < 0 || fltPorcentajeDes > 100)
                {
                    Mensaje("Verifique el Descuento");
                    txtPorcentajeDescuento.Focus();
                    return;
                }

            }
            fltPorcentajeDes /= 100;

            if (txtFechaEntrega.Text == string.Empty)
            {
                Mensaje("seleccione un fecha de entrega");
                txtFechaEntrega.Focus();
                return;
            }
            if (txtFechaDevolucion.Text == string.Empty)
            {
                Mensaje("seleccione un fecha de entrega");
                txtFechaDevolucion.Focus();
                return;
            }

            if (Convert.ToDateTime( txtFechaEntrega.Text) > Convert.ToDateTime(txtFechaDevolucion.Text))
            {
                Mensaje("La fecha de entrega no puede ser mayor a la de devolución.");
                txtFechaEntrega.Focus();
                return;
            }
            if (Convert.ToDateTime(txtFechaEntrega.Text) < DateTime.UtcNow || Convert.ToDateTime(txtFechaDevolucion.Text) < DateTime.UtcNow)
            {
                Mensaje("Verifique las fechas");
                txtFechaEntrega.Focus();
                return;
            }


        }
        private void ActualizarTotales()
        {
            float fltTotalBruto=0,fltTotalIva=0,fltTotalDescuento=0,fltTotalNeto=0;
            foreach (clsAlquilerDetalle MiDetalle in MisDetalleAlquiler)
            {
                fltTotalBruto += MiDetalle.fltVrBruto;
                fltTotalIva += MiDetalle.fltVrIva;
                fltTotalDescuento += MiDetalle.fltVrDescuento;
                fltTotalNeto += MiDetalle.fltVrNeto;
            }
            lblfltTotalBruto.Text = string.Format("{0:C2}", fltTotalBruto);
            lblfltTotalIva.Text = string.Format("{0:C2}", fltTotalIva);
            lblfltTotaDescuento.Text = string.Format("{0:C2}", fltTotalDescuento);
            lblfltTotalNeto.Text = string.Format("{0:C2}", fltTotalNeto);
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Al cargarse por primera vez

            {
                strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                MisDetalleAlquiler = new List<clsAlquilerDetalle>();

                this.txtIdAlquiler.Visible = false;
                this.lblIdAlquiler.Visible = false;
                this.txtNroDocumento.ReadOnly = false;
                this.txtNroDocumento.Focus();
            }
            MisDetalleAlquiler = (List<clsAlquilerDetalle>)Session["MisDetalleAlquiler"];
            if (MisDetalleAlquiler == null)
            {
                MisDetalleAlquiler = new List<clsAlquilerDetalle>();
            }
            grvDatos.DataSource = MisDetalleAlquiler;
            grvDatos.DataBind();
            ActualizarTotales();


        }

        

        protected void mnuOpciones_MenuItemClick(object sender, MenuEventArgs e)
        {
            Mensaje(string.Empty);
            switch (this.mnuOpciones.SelectedValue.ToLower())
            {
                case "opcagregar":
                    ValidarDetalle();

                    clsEquipos ObjclsE = (clsEquipos)Session["ObjclsE"];

                    clsAlquilerDetalle Midetalle = new clsAlquilerDetalle();

                    Midetalle.strIdEquipo = txtIdEquipo.Text;
                    Midetalle.strDescripcion = txtDescripcion.Text;
                    Midetalle.intCantidad = Convert.ToInt32(txtCantidadAlquilada.Text);
                    Midetalle.intImpuesto = ObjclsE.intImpuesto;
                    Midetalle.fltVrUnit = ObjclsE.fltVrUnit;
                    Midetalle.fltPorcentajeDes = Convert.ToInt32(txtPorcentajeDescuento.Text);
                    Midetalle.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                    Midetalle.FechaDevolucion = Convert.ToDateTime(txtFechaDevolucion.Text);

                    MisDetalleAlquiler.Add(Midetalle);
                    Session["MisDetalleAlquiler"] = MisDetalleAlquiler;
                    ActualizarTotales();
                    grvDatos.DataSource = MisDetalleAlquiler;
                    grvDatos.DataBind();
                    LimpiarDetalle();
                    Mensaje("Producto Agregado");
                    break;
            }
        }

        protected void btnBuscarCliente_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                strNroDocumento = txtNroDocumento.Text.Trim();
                if (string.IsNullOrEmpty(strNroDocumento))
                {
                    Mensaje("Debe de ingresar el codigo del Cliente");
                    txtNroDocumento.Focus();
                    return;
                }
                LlenarGridAlquiler();
                LlenarComboDirecciones();
            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }

        protected void btnBuscarIdEquipo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                Mensaje(string.Empty);
                strIdEquipo = this.txtIdEquipo.Text.Trim();
                if (string.IsNullOrEmpty(strIdEquipo))
                {
                    Mensaje("Número de documento no válido");
                    return;
                }
                Buscar();
                if (intOpcion != 0)
                {
                    Habilitar();
                    txtIdEquipo.Enabled = false;
                }
            }
            catch (Exception ex)
            { Mensaje(ex.Message); }
        }
    }
}