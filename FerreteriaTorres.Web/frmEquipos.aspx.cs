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
            this.txtFechaCreado.Visible = false ;
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
            this.txtFechaCreado.Visible = false ;
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
                strCreadoPor = Session["strNroDocumento"].ToString();
                FechaCreado = System.DateTime.UtcNow.ToLocalTime();

                clsEquipos ObjclsE = new clsEquipos(strApp, strIdEquipo, strDescripcion,
                 intIdTipoEquipo, fltVrUnit, fltVrPrestamo, intImpuesto, intCantExistencia, intIdMarca,
                 Activo, strCaracteristicas, strCreadoPor, FechaCreado);
                if (intOpcion == 1)
                {
                    if (!ObjclsE.GrabarMaestro())
                    {
                        Mensaje(ObjclsE.Error);
                        ObjclsE = null;
                        return;
                    }
                }
                else if (!ObjclsE.ModificarMaestro())
                {
                    Mensaje(ObjclsE.Error);
                    ObjclsE = null;
                    return;
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
                LlenarGridEquipos();


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

        private void LlenarGridEquipos()
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
            this.txtFechaCreado.Visible = false ;
            this.lblCreadoPor.Visible = false;
            lblFechaCreado.Visible = false;

            this.chkActivo.Text = string.Empty;
            this.rblTipoEquipo.SelectedIndex = 0;
            this.rblMarca.SelectedIndex = 0;
        }

        private void Buscar()
        {
            clsEquipos ObjclsE = new clsEquipos(strApp);
            if (!ObjclsE.Buscar(strIdEquipo))
            {
                Limpiar();
                Mensaje(ObjclsE.Error);
                ObjclsE = null;
                return;
            }
            this.txtIdEquipo.Text = ObjclsE.strIdEquipo;
            this.txtDescripcion.Text = ObjclsE.strDescripcion;
            this.rblTipoEquipo.SelectedValue = ObjclsE.intIdTipoEquipo.ToString();
            this.chkActivo.Checked = ObjclsE.Activo;
            this.txtVrUnitario.Text = ObjclsE.fltVrUnit.ToString();
            this.txtVrPrestamo.Text = ObjclsE.fltVrPrestamo.ToString();
            this.txtImpuesto.Text = ObjclsE.intImpuesto.ToString();
            this.txtCantExistencia.Text = ObjclsE.intCantExistencia.ToString();
            this.rblMarca.SelectedValue = ObjclsE.intIdMarca.ToString();
            this.txtCaracteristicas.Text = ObjclsE.strCaracteristicas;
            this.txtCreadoPor.Text = ObjclsE.strCreadoPor;
            this.txtFechaCreado.Text = ObjclsE.FechaCreado.ToString();
            ObjclsE = null;
        }

        private void Eliminar()
        {
            clsEquipos ObjclsE = new clsEquipos(strApp);
            if (!ObjclsE.Eliminar(strIdEquipo))
            {
                Limpiar();
                Mensaje(ObjclsE.Error);
                ObjclsE = null;
                return;
            }
            strIdEquipo = ObjclsE.strIdEquipo;
            ObjclsE = null;
            if (strIdEquipo == "-1")
            {
                Mensaje("El Equipo no se puede eliminar");
                return;
            }
            else if (strIdEquipo == "0")
            {
                Mensaje("Error al procesar registro, Consultar con el Admón del sistema");
                return;
            }
            Limpiar();
            Deshabilitar();
            Mensaje("Equipo Eliminado con exito");
            LlenarGridEquipos();
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
                LlenarGridEquipos();
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
                    if (intOpcion == 0)
                    {
                        intOpcion = 2;
                        Habilitar();
                        txtIdEquipo.Enabled = false;
                    }
                    else
                    {
                        intOpcion = 2;
                        Deshabilitar();
                        txtIdEquipo.Enabled = true;
                        mnuOpciones.FindItem("opcConsultar").Enabled = false;
                        mnuOpciones.FindItem("opcEliminar").Enabled = false;
                        mnuOpciones.FindItem("opcModificar").Enabled = false;
                        mnuOpciones.FindItem("opcGrabar").Enabled = true;
                        mnuOpciones.FindItem("opcAgregar").Enabled = false;
                        mnuOpciones.FindItem("opcCancelar").Enabled = true;
                        txtIdEquipo.Focus();
                    }
                    
                    break;
                case "opceliminar":
                    try
                    {

                        Mensaje(string.Empty);
                        strIdEquipo = this.txtIdEquipo.Text.Trim();
                        if (string.IsNullOrEmpty(strIdEquipo))
                        {
                            Mensaje("Número de documento no válido");
                            return;
                        }                        
                        Eliminar();
                        mnuOpciones.FindItem("opcConsultar").Enabled = true;
                        mnuOpciones.FindItem("opcEliminar").Enabled = true;
                        mnuOpciones.FindItem("opcModificar").Enabled = true;
                        mnuOpciones.FindItem("opcGrabar").Enabled = true;
                        mnuOpciones.FindItem("opcAgregar").Enabled = true;
                        mnuOpciones.FindItem("opcCancelar").Enabled = false;

                    }
                    catch (Exception ex)
                    { Mensaje(ex.Message); }
                    break;
                case "opcconsultar":
                    intOpcion = 0;
                    Deshabilitar();
                    Limpiar();
                    txtIdEquipo.Enabled = true;
                    txtIdEquipo.Focus();
                    mnuOpciones.FindItem("opcConsultar").Enabled = false;
                    mnuOpciones.FindItem("opcEliminar").Enabled = true;
                    mnuOpciones.FindItem("opcModificar").Enabled = true;
                    mnuOpciones.FindItem("opcGrabar").Enabled = false;
                    mnuOpciones.FindItem("opcAgregar").Enabled = false;
                    mnuOpciones.FindItem("opcCancelar").Enabled = true;
                    break;
                case "opcgrabar":
                    Grabar();
                    Limpiar();
                    Deshabilitar();
                    mnuOpciones.FindItem("opcConsultar").Enabled = true;
                    mnuOpciones.FindItem("opcEliminar").Enabled = true;
                    mnuOpciones.FindItem("opcModificar").Enabled = true;
                    mnuOpciones.FindItem("opcGrabar").Enabled = true;
                    mnuOpciones.FindItem("opcAgregar").Enabled = true;
                    mnuOpciones.FindItem("opcCancelar").Enabled = false;
                    break;

                case "opccancelar":
                    Deshabilitar();
                    mnuOpciones.FindItem("opcConsultar").Enabled = true;
                    mnuOpciones.FindItem("opcEliminar").Enabled = true;
                    mnuOpciones.FindItem("opcModificar").Enabled = true;
                    mnuOpciones.FindItem("opcGrabar").Enabled = true;
                    mnuOpciones.FindItem("opcAgregar").Enabled = true;
                    mnuOpciones.FindItem("opcCancelar").Enabled = false;
                    break;
            }
        }

        protected void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

        protected void grvDatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string opcion = e.CommandName.ToLower();
            int index = Convert.ToInt32(e.CommandArgument);
            if (index >= 0)
            {
                strIdEquipo = grvDatos.Rows[index].Cells[1].Text;
                switch (opcion)
                {
                    case "select":
                        Buscar();
                        break;
                }
            }
        }
    }
}