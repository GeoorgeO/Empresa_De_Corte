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
    public partial class Frm_Productos_Tipo : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }

        public Frm_Productos_Tipo()
        {
            InitializeComponent();
        }

        public string IdCultivo { get; set; }
        public string Cultivo { get; set; }

        private void CargarProductos_Tipo()
        {
            gridControl1.DataSource = null;
            CLS_ProductoTipo Clase = new CLS_ProductoTipo();

            Clase.MtdSeleccionarProductoTipo();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarProductos_Tipo()
        {
            CLS_ProductoTipo Clase = new CLS_ProductoTipo();

            Clase.Id_ProductoTipo = textId.Text.Trim();
            Clase.Nombre_ProductoTipo = textNombre.Text.Trim();

            Clase.MtdInsertarProductoTipo();

            if (Clase.Exito)
            {
                CargarProductos_Tipo();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarProductos_Tipo()
        {
            CLS_ProductoTipo Clase = new CLS_ProductoTipo();
            Clase.Id_ProductoTipo = textId.Text.Trim();
            Clase.MtdEliminarProductoTipo();
            if (Clase.Exito)
            {
                CargarProductos_Tipo();
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
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textId.Text = row["Id_ProductoTipo"].ToString();
                    textNombre.Text = row["Nombre_ProductoTipo"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Cultivo_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarProductos_Tipo();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarProductos_Tipo();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre de un cultivo.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarProductos_Tipo();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un cultivo.");
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

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdCultivo = textId.Text.Trim();
            Cultivo = textNombre.Text.Trim();
            this.Close();
        }
    }
}