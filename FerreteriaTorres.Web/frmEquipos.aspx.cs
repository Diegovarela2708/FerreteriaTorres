 using FerreteriaTorres.Web.Clases;
using System;
using System.Web.UI.WebControls;

namespace FerreteriaTorres.Web
{
    public partial class Formulario_web15 : System.Web.UI.Page
    {

        #region "Variables Globales"
        private static string strApp;
        private static int intOpcion;

        public string strIdEquipo;
        public string strDescripcion;
        public int intIdTipoEquipo;
        public float fltVrUnit;
        public float fltVrPrestamo;
        public int intImpuesto;
        public int intCantExistencia;
        public int intIdMarca;
        public bool Activo;
        public string strCaracteristicas;
        public string strCreadoPor;
        public DateTime FechaCreado;
        #endregion

        #region "Metodos Personalizados"

        private void Deshabilitar()
        {
            this.txtIdEquipo.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtVrUnitario.Enabled = false;
            this.txtVrPrestamo.Enabled = false;
            this.txtImpuesto.Enabled = false;
            this.txtCantExistencia.Enabled = false;
            this.txtCaracteristicas.Enabled = false;

            this.txtCreadoPor.Visible = false;
            this.txtFechaCreado.Visible = false;
            this.lblCreadoPor.Visible = false;
            lblFechaCreado.Visible = false;

            this.chkActivo.Enabled = false;

            this.rblTipoEquipo.Enabled = false;
            this.rblMarca.Enabled = false;

        }

        private void Habilitar()
        {
            this.txtIdEquipo.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtVrUnitario.Enabled = true;
            this.txtVrPrestamo.Enabled = true;
            this.txtImpuesto.Enabled = true;
            this.txtCantExistencia.Enabled = true;
            this.txtCaracteristicas.Enabled = true;

            this.txtCreadoPor.Visible = false;
            this.txtFechaCreado.Visible = false;
            this.lblCreadoPor.Visible = false;
            lblFechaCreado.Visible = false;

            this.chkActivo.Enabled = true;

            this.rblTipoEquipo.Enabled = true;
            this.rblMarca.Enabled = true;

        }

        private void Mensaje(string Texto)
        {
            this.lblMsj.Text = Texto.Trim();
        }

        private void Grabar()
        {
            try
            {
                strIdEquipo = txtIdEquipo.Text.Trim();
                strDescripcion = txtDescripcion.Text.ToUpperInvariant().Trim();
                intIdTipoEquipo = Convert.ToInt32(rblTipoEquipo.SelectedValue);
                fltVrUnit = Convert.ToSingle(txtVrUnitario.Text.Trim());
                fltVrPrestamo = Convert.ToSingle(txtVrPrestamo.Text.Trim());
                intImpuesto = Convert.ToInt32(txtImpuesto.Text.Trim());
                intCantExistencia = Convert.ToInt32(txtCantExistencia.Text.Trim());
                intIdMarca = Convert.ToInt32(rblMarca.SelectedValue);
                Activo = chkActivo.Checked;
                strCaracteristicas = txtCaracteristicas.Text.ToUpperInvariant().Trim();
                strCreadoPor = "Pendiente";
                FechaCreado = System.DateTime.UtcNow.ToLocalTime();

                clsEquipos ObjclsE = new clsEquipos(strApp, strIdEquipo, strDescripcion,
                 intIdTipoEquipo, fltVrUnit, fltVrPrestamo, intImpuesto, intCantExistencia, intIdMarca,
                 Activo, strCaracteristicas, strCreadoPor, FechaCreado);
                if (intOpcion == 1)
                {
                    if (!ObjclsE.grabarMaestro())
                    {
                        Mensaje(ObjclsE.Error);
                        ObjclsE = null;
                        return;
                    }
                }


                strIdEquipo = ObjclsE.strIdEquipo;
                ObjclsE = null;
                if (strIdEquipo == "-1")
                {
                    Mensaje("Ya existe un registro con dichos valores");
                    return;
                }
                else if (strIdEquipo == "0")
                {
                    Mensaje("Error al procesar registro, Consultar con el Admón del sistema");
                    return;
                }
                Mensaje("Rgtro. Grabado con éxito");
                LlenarGridAsoc();


            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
            
        }
        private void LlenarComboTipoEquipo()
        {
            try
            {
                clsTipoEquipos ObjclsTE = new clsTipoEquipos(strApp);
                if (!ObjclsTE.LlenarCombo(this.rblTipoEquipo))
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

        private void LLenarComboMarcas()
        {
            try
            {
                clsMarcas ObjclsM = new clsMarcas(strApp);
                if (!ObjclsM.LlenarCombo(this.rblMarca))
                {
                    Mensaje(ObjclsM.Error);
                    return;
                }
            }
            catch (Exception ex)
            {

                Mensaje(ex.Message);
            }
        }

        private void LlenarGridAsoc()
        {
            try
            {
                clsEquipos ObjclsE = new clsEquipos(strApp);
                if (!ObjclsE.llenarGrid(this.grvDatos))
                {
                    Mensaje(ObjclsE.Error);
                    ObjclsE = null;
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
            this.txtIdEquipo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtVrUnitario.Text = string.Empty;
            this.txtVrPrestamo.Text = string.Empty;
            this.txtImpuesto.Text = string.Empty;
            this.txtCantExistencia.Text = string.Empty;
            this.txtCaracteristicas.Text = string.Empty;

            this.txtCreadoPor.Visible = false;
            this.txtFechaCreado.Visible = false;
            this.lblCreadoPor.Visible = false;
            lblFechaCreado.Visible = false;

            this.chkActivo.Text = string.Empty;
            this.rblTipoEquipo.SelectedIndex = 0;
            this.rblMarca.SelectedIndex = 0;
        }


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //cuando se cargue por primera ves 
            {
                strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                //intOpcion = 0;
                LlenarComboTipoEquipo();
                LLenarComboMarcas();
                Deshabilitar();
                LlenarGridAsoc();
                this.rblTipoEquipo.SelectedIndex = 0;
                this.rblMarca.SelectedIndex = 0;

                mnuOpciones.FindItem("opcConsultar").Enabled = true;
                mnuOpciones.FindItem("opcEliminar").Enabled = true;
                mnuOpciones.FindItem("opcModificar").Enabled = true;
                mnuOpciones.FindItem("opcAgregar").Enabled = true;
                mnuOpciones.FindItem("opcGrabar").Enabled = false;
                mnuOpciones.FindItem("opcCancelar").Enabled = false;

            }
        }

        protected void mnuOpciones_MenuItemClick(object sender, MenuEventArgs e)
        {
            Mensaje(string.Empty);
            switch (mnuOpciones.SelectedValue.ToLower())
            {
                case "opcagregar":
                    intOpcion = 1;
                    Habilitar();
                    Limpiar();
                    mnuOpciones.FindItem("opcConsultar").Enabled = false;
                    mnuOpciones.FindItem("opcEliminar").Enabled = false;
                    mnuOpciones.FindItem("opcModificar").Enabled = false;
                    mnuOpciones.FindItem("opcGrabar").Enabled = true;
                    mnuOpciones.FindItem("opcAgregar").Enabled = false;
                    mnuOpciones.FindItem("opcCancelar").Enabled = true;
                    break;
                case "opcmodificar":
                    break;
                case "opceliminar":
                    break;
                case "opcconsultar":
                    break;
                case "opcgrabar":
                    Grabar();
                    break;

                case "opccancelar":
                    mnuOpciones.FindItem("opcConsultar").Enabled = true;
                    mnuOpciones.FindItem("opcEliminar").Enabled = true;
                    mnuOpciones.FindItem("opcModificar").Enabled = true;
                    mnuOpciones.FindItem("opcGrabar").Enabled = true;
                    mnuOpciones.FindItem("opcAgregar").Enabled = true;
                    break;
            }
        }
    }
}