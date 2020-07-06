using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaDeDatos;
using DevExpress.XtraEditors.Mask;

namespace CuttingBusiness
{
    public partial class Frm_Huertas : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }

        public string IdHuerta { get; set; }
        public string Huerta { get; set; }
        public string IdDuenio { get; set; }
        public string Duenio { get; set; }

        public string UsuariosLogin { get; set; }

        public Frm_Huertas()
        {
            InitializeComponent();
        }
        private static Frm_Huertas m_FormDefInstance;
        public static Frm_Huertas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Huertas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public void CargarEstado(string Valor)
        {
            CLS_Estado comboEstado = new CLS_Estado();
            comboEstado.MtdSeleccionarEstado();
            if (comboEstado.Exito)
            {
                CargarComboEstado(comboEstado.Datos, Valor);
            }
        }
        private void CargarComboEstado(DataTable Datos, string Valor)
        {
            cboEstado.Properties.DisplayMember = "Nombre_Estado";
            cboEstado.Properties.ValueMember = "Id_Estado";
            cboEstado.EditValue = Valor;
            cboEstado.Properties.DataSource = Datos;
        }
        public void CargarCiudad(string Valor)
        {
            CLS_Ciudades comboCiudad = new CLS_Ciudades();
            comboCiudad.MtdSeleccionarCiudad();
            if (comboCiudad.Exito)
            {
                CargarComboCiudad(comboCiudad.Datos, Valor);
            }
        }
        private void CargarComboCiudad(DataTable Datos, string Valor)
        {
            cboCiudad.Properties.DisplayMember = "Nombre_Ciudad";
            cboCiudad.Properties.ValueMember = "Id_Ciudad";
            cboCiudad.EditValue = Valor;
            cboCiudad.Properties.DataSource = Datos;
        }
        public void CargarCalidad(string Valor)
        {
            CLS_Calidades comboCalidad = new CLS_Calidades();
            comboCalidad.MtdSeleccionarCalidad();
            if (comboCalidad.Exito)
            {
                CargarComboCalidad(comboCalidad.Datos, Valor);
            }
        }
        private void CargarComboCalidad(DataTable Datos, string Valor)
        {
            cboCalidad.Properties.DisplayMember = "Nombre_Calidad";
            cboCalidad.Properties.ValueMember = "Id_Calidad";
            cboCalidad.EditValue = Valor;
            cboCalidad.Properties.DataSource = Datos;
        }
        public void CargarCultivo(string Valor)
        {
            CLS_Cultivo comboCultivo = new CLS_Cultivo();
            comboCultivo.MtdSeleccionarCultivo();
            if (comboCultivo.Exito)
            {
                CargarComboCultivo(comboCultivo.Datos, Valor);
            }
        }
        private void CargarComboCultivo(DataTable Datos, string Valor)
        {
            cboCultivo.Properties.DisplayMember = "Nombre_Cultivo";
            cboCultivo.Properties.ValueMember = "Id_Cultivo";
            cboCultivo.EditValue = Valor;
            cboCultivo.Properties.DataSource = Datos;
        }
        private void DarFormatoCampos()
        {
            txtZona.Text = "0";
            txtZona.Properties.Mask.MaskType = MaskType.Numeric;
            txtZona.Properties.Mask.EditMask = "###,###0.00";
            txtZona.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtEste.Text = "0";
            txtEste.Properties.Mask.MaskType = MaskType.Numeric;
            txtEste.Properties.Mask.EditMask = "###,###0.00";
            txtEste.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtNorte.Text = "0";
            txtNorte.Properties.Mask.MaskType = MaskType.Numeric;
            txtNorte.Properties.Mask.EditMask = "###,###0.00";
            txtNorte.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtASMN.Text = "0";
            txtASMN.Properties.Mask.MaskType = MaskType.Numeric;
            txtASMN.Properties.Mask.EditMask = "###,###0.00";
            txtASMN.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtLatitud.Text = "0";
            txtLatitud.Properties.Mask.MaskType = MaskType.Numeric;
            txtLatitud.Properties.Mask.EditMask = "###,###0.00000";
            txtLatitud.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtLonguitud.Text = "0";
            txtLonguitud.Properties.Mask.MaskType = MaskType.Numeric;
            txtLonguitud.Properties.Mask.EditMask = "###,###0.00000";
            txtLonguitud.Properties.Mask.UseMaskAsDisplayFormat = true;
        }
        private void Frm_Huertas_Shown(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarEstado(null);
            CargarCiudad(null);
            CargarCalidad(null);
            CargarCultivo(null);
            DarFormatoCampos();
            CargarHuertas();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            txtRegistro.Text = string.Empty;
            txtNombreHuerta.Text = string.Empty;
            txtNombreProductor.Text = string.Empty;
            cboCalidad.Text = null;
            cboCiudad.Text = null;
            cboCultivo.Text = null;
            cboEstado.Text = null;
            txtZona.Text = string.Empty;
            txtBanda.Text = string.Empty;
            txtEste.Text = string.Empty;
            txtNorte.Text = string.Empty;
            txtASMN.Text = string.Empty;
            txtLonguitud.Text = string.Empty;
            txtLatitud.Text = string.Empty;
        }

        private void btnProductor_Click(object sender, EventArgs e)
        {
            Frm_Productor frm = new Frm_Productor();
            frm.IdDuenio = string.Empty;
            frm.Duenio = string.Empty;
            frm.PaSel = true;
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.ShowDialog();
            txtNombreProductor.Tag = frm.IdDuenio;
            txtNombreProductor.Text = frm.Duenio;
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            Frm_Estado frm = new Frm_Estado();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.ShowDialog();
            CargarEstado(null);
        }

        private void btnCiudad_Click(object sender, EventArgs e)
        {
            Frm_Ciudad frm = new Frm_Ciudad();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.ShowDialog();
            CargarCiudad(null);
        }

        private void btnCalidad_Click(object sender, EventArgs e)
        {
            Frm_Calidad frm = new Frm_Calidad();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.ShowDialog();
            CargarCalidad(null);
        }

        private void btnCultivo_Click(object sender, EventArgs e)
        {
            Frm_Cultivo frm = new Frm_Cultivo();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.ShowDialog();
            CargarCultivo(null);
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(txtRegistro.Text!=string.Empty)
            {
                if (txtNombreHuerta.Text != string.Empty)
                {
                    if (txtNombreProductor.Text != string.Empty)
                    {
                        if (cboEstado.EditValue != null)
                        {
                            if (cboCiudad.EditValue != null)
                            {
                                if (cboCalidad.EditValue != null)
                                {
                                    if (cboCultivo.EditValue != null)
                                    {
                                        InsertarHuerta();
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("Falta de seleccionar un Cultivo");
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("Falta de seleccionar una Calidad");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("Falta de seleccionar una Ciudad");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Falta de seleccionar un Estado");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Falta de seleccionar un Productor");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Falta de colocar el nombre de la huerta");
                }
            }
            else
            {
                XtraMessageBox.Show("Falta de colocar un registro de huerta");
            }
        }
        void CargarHuertas()
        {
            dtgHuertas.DataSource = null;
            CLS_Huerta Clase = new CLS_Huerta();
            Clase.Activo = "1";
            Clase.MtdSeleccionarHuerta();
            if (Clase.Exito)
            {
                dtgHuertas.DataSource = Clase.Datos;
            }
        }
        private void InsertarHuerta()
        {
            CLS_Huerta Clase = new CLS_Huerta();
            Clase.Id_Huerta = txtCodigo.Text;
            Clase.Nombre_Huerta = txtNombreHuerta.Text;
            Clase.Registro_Huerta = txtRegistro.Text;
            Clase.Id_Duenio = txtNombreProductor.Tag.ToString();
            Clase.Id_Estado = cboEstado.EditValue.ToString();
            Clase.Id_Ciudad = cboCiudad.EditValue.ToString();
            Clase.Id_Calidad = cboCalidad.EditValue.ToString();
            Clase.Id_Cultivo = cboCultivo.EditValue.ToString();
            Clase.zona_Huerta =Convert.ToDecimal(txtZona.Text);
            Clase.banda_Huerta = txtBanda.Text;
            Clase.este_Huerta =Convert.ToDecimal(txtEste.Text);
            Clase.norte_Huerta =Convert.ToDecimal(txtNorte.Text);
            Clase.asnm_Huerta = Convert.ToDecimal(txtASMN.Text);
            Clase.latitud_Huerta = Convert.ToDecimal(txtLatitud.Text);
            Clase.longitud_Huerta = Convert.ToDecimal(txtLonguitud.Text);
            Clase.Activo = "1";

            Clase.Usuario = UsuariosLogin.Trim();

            Clase.MtdInsertarHuerta();

            if (Clase.Exito)
            {
                CargarHuertas();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        void Eliminarhuerta()
        {
            CLS_Huerta Clase = new CLS_Huerta();
            Clase.Id_Huerta = txtCodigo.Text.Trim();
            Clase.MtdEliminarHuerta();
            if (Clase.Exito)
            {
                CargarHuertas();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }
        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtCodigo.Text.Trim().Length > 0)
            {
                Eliminarhuerta();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un cultivo.");
            }
        }

        void bloquear(bool value)
        {
            txtCodigo.Enabled = value;
            txtNombreHuerta.Enabled = value;
            txtRegistro.Enabled = value;
            txtNombreProductor.Enabled = value;
            cboEstado.Enabled = value;
            cboCiudad.Enabled = value;
            cboCalidad.Enabled = value;
            cboCultivo.Enabled = value;
            txtZona.Enabled = value;
            txtBanda.Enabled = value;
            txtEste.Enabled = value;
            txtNorte.Enabled = value;
            txtASMN.Enabled = value;
            txtLatitud.Enabled = value;
            txtLonguitud.Enabled = value;
            btnGuardar.Enabled = value;
            btnEliminar.Enabled = value;
            if (PaSel == true)
            {
                if (value == true)
                {
                    btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        private void dtgHuertas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValHuertas.GetSelectedRows())
                {
                    DataRow row = this.dtgValHuertas.GetDataRow(i);
                    txtCodigo.Text= row["Id_Huerta"].ToString();
                    txtNombreHuerta.Text=row["Nombre_Huerta"].ToString(); 
                    txtRegistro.Text=row["Registro_Huerta"].ToString(); 
                    txtNombreProductor.Tag = row["Id_Duenio"].ToString();
                    txtNombreProductor.Text = row["Nombre_Duenio"].ToString();
                    cboEstado.EditValue = row["Id_Estado"].ToString();
                    cboCiudad.EditValue = row["Id_Ciudad"].ToString();
                    cboCalidad.EditValue = row["Id_Calidad"].ToString();
                    cboCultivo.EditValue = row["Id_Cultivo"].ToString();
                    txtZona.Text= row["zona_Huerta"].ToString();
                    txtBanda.Text = row["banda_Huerta"].ToString();
                    txtEste.Text= row["este_Huerta"].ToString();
                    txtNorte.Text= row["norte_Huerta"].ToString();
                    txtASMN.Text= row["asnm_Huerta"].ToString();
                    txtLatitud.Text = row["latitud_Huerta"].ToString();
                    txtLonguitud.Text = row["longitud_Huerta"].ToString();
                    if (row["Activa_Huerta"].ToString().Equals("True"))
                    {
                        labelActivo.Text = "Activo";
                        btnEliminar.Caption = "Dar de Baja";
                        labelActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        bloquear(true);
                    }
                    else
                    {
                        labelActivo.Text = "Inactivo";
                        btnEliminar.Caption = "Dar de Alta";
                        labelActivo.ForeColor = System.Drawing.Color.Maroon;
                        bloquear(false);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdHuerta = txtCodigo.Text.Trim();
            Huerta = txtNombreHuerta.Text.Trim();
            IdDuenio = txtNombreProductor.Tag.ToString().Trim();
            Duenio = txtNombreProductor.Text.Trim();
            this.Close();
        }
    }
}
