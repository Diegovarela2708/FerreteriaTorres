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
        public int intOpcion;

        //Alquiler
        public int intIdAlquiler;
        public DateTime FechaCreado;
        public string strNroDocumento;
        public string strNombreCliente;
        public string strDireccion;
        public string strCreadoPor;
        public float fltVrBruto;
        public float fltVrDescuentoEnca;
        public float fltVrIvaEnca;
        public float fltVrNeto;
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
        //Totales
        public float fltTotalBruto = 0, fltTotalIva = 0, fltTotalDescuento = 0, fltTotalNeto = 0;


        #region "Metodos Personalizados"

        private void Mensaje(string Texto)
        {
            this.lblMsj.Text = Texto.Trim();
        }

        private void CamposEnable()
        {
            //Mostrar
            txtIdAlquiler.Visible = false;
            lblIdAlquiler.Visible = false;
            //Aquiler
            this.txtIdAlquiler.Enabled = false;           
            this.txtNombreCliente.Enabled = false;
            this.txtFCreado.Enabled = false;            
            //Detalle
            
            txtDescripcion.Enabled = false;
            txtExistencia.Enabled = false;
            txtVrUnitario.Enabled = false;
            //fOCUS
            txtNroDocumento.Focus();
        }
        private void Deshabilitar()
        {
            //Mostrar
            txtIdAlquiler.Visible = true;
            lblIdAlquiler.Visible = true;
            //Aquiler
            this.txtIdAlquiler.Enabled = false;
            this.ddlDirecciones.Enabled = false;
            //Detalle
            txtIdEquipo.Enabled = false;
            txtCantidadAlquilada.Enabled = false;
            txtPorcentajeDescuento.Enabled = false;
            txtFechaEntrega.Enabled = false;
            txtFechaDevolucion.Enabled = false;
            //Botones
            btnBuscarCliente.Enabled = false;
            btnBuscarIdEquipo.Enabled = false;
            mnuOpciones.FindItem("opcGrabar").Enabled = false;
            

        }

        private void Habilitar()
        {
            //Aquiler
            
            this.txtNroDocumento.Enabled = true;
            this.ddlDirecciones.Enabled = true;
            //Detalle
            txtIdEquipo.Enabled = true;
            txtCantidadAlquilada.Enabled = true;
            txtPorcentajeDescuento.Enabled = true;
            txtFechaEntrega.Enabled = true;
            txtFechaDevolucion.Enabled = true;
            //Botones
            btnBuscarCliente.Enabled = true;
            btnBuscarIdEquipo.Enabled = true;
            mnuOpciones.FindItem("opcGrabar").Enabled = true;
            //Focus
            txtNroDocumento.Focus();
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

            //Aquiler
            this.txtIdAlquiler.Text = string.Empty;
            this.txtNroDocumento.Text = string.Empty;
            this.txtNombreCliente.Text = string.Empty;
            this.txtFCreado.Text = string.Empty;
            this.ddlDirecciones.Items.Clear();
            //Detalle
            
            txtDescripcion.Text = string.Empty;
            txtExistencia.Text = string.Empty;
            txtVrUnitario.Text = string.Empty;
            txtCantidadAlquilada.Text = string.Empty;
            txtPorcentajeDescuento.Text = string.Empty;
            txtFechaEntrega.Text = string.Empty;
            txtFechaDevolucion.Text = string.Empty;

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

        private void BuscarCliente()
        {
            clsCliente ObjclsC = new clsCliente(strApp);
            if (!ObjclsC.BuscarCliente(txtNroDocumento.Text.Trim()))
            {
                //Limpiar();
                Mensaje(ObjclsC.Error);
                ObjclsC = null;
                return;
            }

            txtNroDocumento.Text = ObjclsC.strNroDocumento;
            txtNombreCliente.Text = ObjclsC.strNombres;
            ObjclsC = null;
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
                Mensaje("seleccione un fecha devolución");
                txtFechaDevolucion.Focus();
                return false;
            }

            if (Convert.ToDateTime(txtFechaEntrega.Text) > Convert.ToDateTime(txtFechaDevolucion.Text))
            {
                Mensaje("La fecha de entrega no puede ser mayor a la de devolución.");
                txtFechaEntrega.Focus();
                return false;
            }
            string FechaSistema = DateTime.Now.ToString("yyyy/MM/dd");
            DateTime FechaSis = Convert.ToDateTime(FechaSistema);
            DateTime FechaENTRADA = Convert.ToDateTime(txtFechaEntrega.Text);
            if (FechaENTRADA < FechaSis)
            {
                Mensaje("Las fecha de entrega debe de ser mayor o igual a la fecha de hoy");
                txtFechaEntrega.Focus();
                return false;
            }

            return true;
        }

        private void ActualizarTotales()
        {
            
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
                FechaCreado = DateTime.Now;
                strNroDocumento = txtNroDocumento.Text.Trim();
                strDireccion = ddlDirecciones.SelectedValue;
                strCreadoPor = Session["strNroDocumento"].ToString();
                fltVrBruto = fltTotalBruto;
                fltVrDescuentoEnca = fltTotalDescuento;
                fltVrIvaEnca = fltTotalIva;
                fltVrNeto = fltTotalNeto;

                clsAlquiler ObjclsA = new clsAlquiler(strApp, FechaCreado, strNroDocumento, strDireccion, strCreadoPor,
                    fltVrBruto,fltVrDescuentoEnca,fltVrIvaEnca,fltVrNeto);

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

        private void LimpiarGrid()
        {
            MisDetalleAlquiler.Clear();
            Session["MisDetalleAlquiler"] = MisDetalleAlquiler;
            ActualizarTotales();
            grvDatos.DataBind();
            grvHistoria.DataBind();
            ddlDirecciones.Items.Clear();
            txtNroDocumento.Focus();
            txtNroDocumento.Text = string.Empty;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Al cargarse por primera vez

            {
                strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                MisDetalleAlquiler = new List<clsAlquilerDetalle>();
                txtFCreado.Text = Convert.ToString( DateTime.Now);
                Session["intOpcion"] = 1;
                CamposEnable();
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
                        intOpcion = Convert.ToInt32(Session["intOpcion"]);
                        if (intOpcion==1)
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
                            Session["intOpcion"] = 1;
                        }
                        else
                        {
                            Session["intOpcion"] = 1;
                            Habilitar();
                            LimpiarGrid();
                            txtIdAlquiler.Visible = false;
                            lblIdAlquiler.Visible = false;
                                
                        }
                        
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
                        Deshabilitar();
                        Session["intOpcion"] = 0;
                        txtIdAlquiler.Text = intIdAlquiler.ToString();
                        txtNroDocumento.Enabled = false;
                        //MisDetalleAlquiler.Clear();
                        //Session["MisDetalleAlquiler"] = MisDetalleAlquiler;
                        //ActualizarTotales();
                        //grvDatos.DataBind();
                        //grvHistoria.DataBind();
                        //ddlDirecciones.Items.Clear();
                        //txtNroDocumento.Focus();
                        //txtNroDocumento.Text = string.Empty;
                        Mensaje(string.Format("El alquiler # {0}, fue grabado exitosamente.", intIdAlquiler));
                    }
                    catch (Exception ex)
                    {

                        Mensaje(ex.Message);
                    }

                    break;

                case "opccancelar":
                    LimpiarGrid();
                    Habilitar();
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
                BuscarCliente();
                
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