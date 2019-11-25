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

namespace CuttingBusiness
{
    public partial class Frm_Huertas : DevExpress.XtraEditors.XtraForm
    {
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
        private void Frm_Huertas_Shown(object sender, EventArgs e)
        {
            CargarEstado(null);
            CargarCiudad(null);
            CargarCalidad(null);
            CargarCultivo(null);
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
            frm.ShowDialog();
            txtNombreProductor.Tag = frm.IdDuenio;
            txtNombreProductor.Text = frm.Duenio;
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            Frm_Estado frm = new Frm_Estado();
            frm.ShowDialog();
            CargarEstado(null);
        }

        private void btnCiudad_Click(object sender, EventArgs e)
        {
            Frm_Ciudad frm = new Frm_Ciudad();
            frm.ShowDialog();
            CargarCiudad(null);
        }

        private void btnCalidad_Click(object sender, EventArgs e)
        {
            Frm_Calidad frm = new Frm_Calidad();
            frm.ShowDialog();
            CargarCalidad(null);
        }

        private void btnCultivo_Click(object sender, EventArgs e)
        {
            Frm_Cultivo frm = new Frm_Cultivo();
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
    }
}
