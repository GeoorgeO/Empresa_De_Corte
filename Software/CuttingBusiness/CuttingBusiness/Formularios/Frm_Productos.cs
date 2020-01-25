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
    public partial class Frm_Productos : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Productos()
        {
            InitializeComponent();
        }
        private static Frm_Productos m_FormDefInstance;
        public static Frm_Productos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Productos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public string IdProducto { get; set; }
        public string Producto { get; set; }
        public string UnidadMedida { get;  set; }
        public bool PaSel { get; set; }
        private void CargarProductos(String Activo)
        {
            gridControl1.DataSource = null;
            CLS_Productos Clase = new CLS_Productos();
            Clase.Activo = Activo;
            Clase.MtdSeleccionarProductos();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }
        private void InsertarProductos()
        {
            string inventa = "";
            CLS_Productos Clase = new CLS_Productos();
            Clase.Id_Producto = textId.Text.Trim();
            Clase.Nombre_Producto = textNombre.Text.Trim();
            Clase.Id_UnidadMedida = textUnidad.Tag.ToString().Trim();
            if (checkInventa.Checked)
            {
                inventa = "1";
            }else
            {
                inventa = "0";
            }
            Clase.Inventariable = inventa;
            Clase.Stock_Min = Convert.ToInt32(textMin.Text.Trim());
            Clase.Stock_Max = Convert.ToInt32(textMax.Text.Trim());
            Clase.Pasillo = textPasillo.Text.Trim();
            Clase.Repisa = textRepisa.Text.Trim();
            Clase.Anaquel = textAnaquel.Text.Trim();
            Clase.Id_ProductoTipo = cboProductoTipo.EditValue.ToString();
            Clase.MtdInsertarProductos();
            if (Clase.Exito)
            {

                CargarProductos("1");
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarProductos()
        {
            CLS_Productos Clase = new CLS_Productos();
            Clase.Id_Producto = textId.Text.Trim();
            Clase.MtdEliminarProductos();
            if (Clase.Exito)
            {
                if (checkActivo.Checked)
                {
                    CargarProductos("0");
                }
                else
                {
                    CargarProductos("1");
                }
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void LimpiarCampos()
        {
            textId.Text = "";
            textNombre.Text = "";
            textUnidad.Text = "";
            textUnidad.Tag = "";
            textMax.Text = "0";
            textMin.Text = "0";
            checkInventa.Checked = false;
            textAnaquel.Text = "";
            textPasillo.Text = "";
            textRepisa.Text = "";
            labelActivo.Visible = false;
            bloquear(true);
            textCantidad.Text = "0";

        }

        private void iniciarTags()
        {
            textUnidad.Tag = "";
            labelActivo.Visible = false;
        }

        private void bloquear(Boolean sino)
        {
            checkInventa.Enabled = sino;
            textUnidad.Enabled = sino;
            btnbuscar.Enabled = sino;
            textNombre.Enabled = sino;
            textMax.Enabled = sino;
            textMin.Enabled = sino;
            textPasillo.Enabled = sino;
            textAnaquel.Enabled = sino;
            textRepisa.Enabled = sino;
            cboProductoTipo.Enabled = sino;
            btnTipoProducto.Enabled = sino;
            btnGuardar.Enabled = sino;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                labelActivo.Visible = true;
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textId.Text = row["Id_Producto"].ToString();
                    textNombre.Text = row["Nombre_Producto"].ToString();
                    textUnidad.Tag = row["Id_UnidadMedida"].ToString();
                    textUnidad.Text = row["Nombre_UnidadMedida"].ToString();
                    if (row["Inventariable"].ToString().Equals("True"))
                    {
                        checkInventa.Checked = true;
                    }
                    else
                    {
                        checkInventa.Checked = false;
                    }
                    textMin.Text = row["Stock_Min"].ToString();
                    textMax.Text = row["Stock_Max"].ToString();
                    textAnaquel.Text = row["Anaquel"].ToString();
                    textPasillo.Text = row["Pasillo"].ToString();
                    textRepisa.Text = row["Repisa"].ToString();
                    textCantidad.Text = row["Stock"].ToString();
                    if (row["Activo"].ToString().Equals("True"))
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

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarProductos();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del producto");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarProductos();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un producto.");
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Frm_Productos_Load(object sender, EventArgs e)
        {
            CargarProductos("1");
            CargarProductoTipo(null);
            iniciarTags();
        }
        public void CargarProductoTipo(string Valor)
        {
            CLS_ProductoTipo comboCiudad = new CLS_ProductoTipo();
            comboCiudad.MtdSeleccionarProductoTipo();
            if (comboCiudad.Exito)
            {
                CargarComboProductoTipo(comboCiudad.Datos, Valor);
            }
        }
        private void CargarComboProductoTipo(DataTable Datos, string Valor)
        {
            cboProductoTipo.Properties.DisplayMember = "Nombre_ProductoTipo";
            cboProductoTipo.Properties.ValueMember = "Id_ProductoTipo";
            cboProductoTipo.EditValue = Valor;
            cboProductoTipo.Properties.DataSource = Datos;
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Frm_UnidadesMedida Uni = new Frm_UnidadesMedida();
            Uni.PaSel = true;
            Uni.ShowDialog();

            textUnidad.Tag = Uni.IdUnidadMedida;
            textUnidad.Text = Uni.UnidadMedida;
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkActivo.Checked)
            {
                CargarProductos("0");
            }else
            {
                CargarProductos("1");
            }
        }

        private void btnTipoProducto_Click(object sender, EventArgs e)
        {
            Frm_Productos_Tipo frm = new Frm_Productos_Tipo();
            frm.ShowDialog();
            CargarProductoTipo(null);
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdProducto = textId.Text;
            Producto = textNombre.Text;
            UnidadMedida = textUnidad.Text;
            this.Close();
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.ShowDialog();
            if (xtraSaveFileDialog1.FileName.Length > 0)
            {
                gridControl1.ExportToXlsx(xtraSaveFileDialog1.FileName + ".xlsx");
                
            }
            
        }
    }
}