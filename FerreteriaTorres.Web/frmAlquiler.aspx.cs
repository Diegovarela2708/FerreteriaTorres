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
        public float fltVrIva;
        public DateTime FechaEntrega;
        public DateTime FechaDevolucion;
        //Equipo
        public float intImpuesto;
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

     

        private void Limpiar()
        {
            
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

            Session["ObjclsE"] = ObjclsE;

            ObjclsE = null;
        }

        private bool ValidarDetalle()
        {
            if (txtCantidadAlquilada.Text == string.Empty)
            {
                Mensaje("Debe de ingresar la cantidad");
                txtCantidadAlquilada.Focus();
                return false;
            }
            long Cantidad;
            if (!long.TryParse(txtCantidadAlquilada.Text, out Cantidad))
            {
                Mensaje("Debe de ingresar un numero entero");
                txtCantidadAlquilada.Focus();
                return false;
            }
            if (Cantidad < 1)
            {
                Mensaje("La cantidad debe de ser mayor a 0");
                txtCantidadAlquilada.Focus();
                return false;
            }
            if (Cantidad > Convert.ToInt32(txtExistencia.Text))
            {
                Mensaje("La cantidad es mayor a la del inventario");
                txtCantidadAlquilada.Focus();
                return false;
            }
            if (txtPorcentajeDescuento.Text == string.Empty)
            {

                if (!float.TryParse(txtPorcentajeDescuento.Text, out fltPorcentajeDes))
                {
                    Mensaje("Debe de ingresar un numero entero");
                    txtPorcentajeDescuento.Focus();
                    return false;
                }
                if (fltPorcentajeDes < 0 || fltPorcentajeDes > 100)
                {
                    Mensaje("Verifique el Descuento");
                    txtPorcentajeDescuento.Focus();
                    return false;
                }

            }
            fltPorcentajeDes /= 100f;

            if (txtFechaEntrega.Text == string.Empty)
            {
                Mensaje("seleccione un fecha de entrega");
                txtFechaEntrega.Focus();
                return false;
            }
            if (txtFechaDevolucion.Text == string.Empty)
            {
                Mensaje("seleccione un fecha de entrega");
                txtFechaDevolucion.Focus();
                return false;
            }

            if (Convert.ToDateTime(txtFechaEntrega.Text) > Convert.ToDateTime(txtFechaDevolucion.Text))
            {
                Mensaje("La fecha de entrega no puede ser mayor a la de devolución.");
                txtFechaEntrega.Focus();
                return false;
            }
            if (Convert.ToDateTime(txtFechaEntrega.Text) >= DateTime.UtcNow)
            {
                Mensaje("Las fecha deben de ser a la fecha de hoy");
                txtFechaEntrega.Focus();
                return false;
            }

            return true;
        }
        private void ActualizarTotales()
        {
            float fltTotalBruto = 0, fltTotalIva = 0, fltTotalDescuento = 0, fltTotalNeto = 0;
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

        private void Grabar()
        {
            try
            {
                Fecha = DateTime.Now.ToUniversalTime();
                strNroDocumento = txtNroDocumento.Text.Trim();
                strDireccion = ddlDirecciones.SelectedValue;
                strCreadoPor = "Pendiente";

                clsAlquiler ObjclsA = new clsAlquiler(strApp, Fecha, strNroDocumento, strDireccion, strCreadoPor);

                if (!ObjclsA.grabarMaestro())
                {
                    Mensaje(ObjclsA.Error);
                    ObjclsA = null;
                    return;
                }


                intIdAlquiler = ObjclsA.intIdAlquiler;
                //ObjclsA = null;
                foreach (clsAlquilerDetalle MiDetalle in MisDetalleAlquiler)
                {

                    strIdEquipo = MiDetalle.strIdEquipo;
                    intCantidad = MiDetalle.intCantidad;
                    fltVrUnit = MiDetalle.fltVrUnit;
                    fltPorcentajeDes = MiDetalle.fltPorcentajeDes;
                    fltVrDescuento = MiDetalle.fltVrDescuento;
                    fltVrIva = MiDetalle.fltVrIva;
                    FechaEntrega = MiDetalle.FechaEntrega;
                    FechaDevolucion = MiDetalle.FechaDevolucion;

                    clsDetalleArquiler Objclsad = new clsDetalleArquiler(strApp, intIdAlquiler, strIdEquipo, intCantidad,
                        fltVrUnit, fltPorcentajeDes, fltVrDescuento, fltVrIva, FechaEntrega, FechaDevolucion);

                    if (!Objclsad.grabarMaestro())
                    {
                        Mensaje(ObjclsA.Error);
                        Objclsad = null;
                        return;
                    }
                }


            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }

        }

        private bool ValidarEncabezado()
        {
            if (txtNroDocumento.Text.Trim() == string.Empty)
            {
                Mensaje("Debe de ingresar numero de documento.");
                txtNroDocumento.Focus();
                return false;
            }
            if (MisDetalleAlquiler.Count == 0)
            {
                Mensaje("Debe de ingresar detalle.");
                txtIdEquipo.Focus();
                return false;
            }
            return true;
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
                txtDescripcion.Enabled = false;
                txtExistencia.Enabled = false;
                txtVrUnitario.Enabled = false;
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
                    try
                    {
                        if (!ValidarDetalle()) return;




                        clsEquipos ObjclsE = (clsEquipos)Session["ObjclsE"];
                        clsAlquilerDetalle Midetalle = new clsAlquilerDetalle();

                        Midetalle.strIdEquipo = txtIdEquipo.Text;
                        Midetalle.strDescripcion = txtDescripcion.Text;
                        Midetalle.intCantidad = Convert.ToInt32(txtCantidadAlquilada.Text);
                        Midetalle.intImpuesto = ObjclsE.intImpuesto / 100f;
                        Midetalle.fltVrUnit = ObjclsE.fltVrUnit;
                        Midetalle.fltPorcentajeDes = Convert.ToSingle(txtPorcentajeDescuento.Text) / 100f;
                        Midetalle.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
                        Midetalle.FechaDevolucion = Convert.ToDateTime(txtFechaDevolucion.Text);

                        MisDetalleAlquiler.Add(Midetalle);
                        Session["MisDetalleAlquiler"] = MisDetalleAlquiler;
                        ActualizarTotales();
                        grvDatos.DataSource = MisDetalleAlquiler;
                        grvDatos.DataBind();
                        LimpiarDetalle();
                        Mensaje("Producto Agregado");
                    }
                    catch (Exception ex)
                    {

                        Mensaje(ex.Message);
                    }

                    break;

                case "opcgrabar":
                    try
                    {
                        if (!ValidarEncabezado()) return;

                        Grabar();

                        MisDetalleAlquiler.Clear();
                        Session["MisDetalleAlquiler"] = MisDetalleAlquiler;
                        ActualizarTotales();
                        grvDatos.DataBind();
                        grvHistoria.DataBind();
                        ddlDirecciones.Items.Clear();
                        txtNroDocumento.Focus();
                        txtNroDocumento.Text = string.Empty;
                        Mensaje(string.Format("El alquiler:{0},fue grabado de forma exitosa", intIdAlquiler));
                    }
                    catch (Exception ex)
                    {

                        Mensaje(ex.Message);
                    }

                    break;

                case "opccancelar":
                    MisDetalleAlquiler.Clear();
                    Session["MisDetalleAlquiler"] = MisDetalleAlquiler;
                    ActualizarTotales();
                    grvDatos.DataBind();
                    grvHistoria.DataBind();
                    ddlDirecciones.Items.Clear();
                    txtNroDocumento.Focus();
                    txtNroDocumento.Text = string.Empty;
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

            }
            catch (Exception ex)
            { Mensaje(ex.Message); }
        }
    }
}