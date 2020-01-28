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
    public partial class Frm_Marcas : DevExpress.XtraEditors.XtraForm
    {
        public string IdMarca { get; set; }
        public string Marca { get; set; }
        public Boolean PaSel { get; set; }

        public Frm_Marcas()
        {
            InitializeComponent();
        }

        private void CargarMarcas()
        {
            gridControl1.DataSource = null;
            CLS_Marcas Clase = new CLS_Marcas();

            Clase.MtdSeleccionarMarcas();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarMarcas()
        {
            CLS_Marcas Clase = new CLS_Marcas();
            Clase.Id_Marca = textId.Text.Trim();
            Clase.Nombre_Marca = textNombre.Text.Trim();
            Clase.MtdInsertarMarcas();
            if (Clase.Exito)
            {

                CargarMarcas();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarMarcas()
        {
            CLS_Marcas Clase = new CLS_Marcas();
            Clase.Id_Marca = textId.Text.Trim();
            Clase.MtdEliminarMarcas();
            if (Clase.Exito)
            {
                CargarMarcas();
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
                    textId.Text = row["Id_Marca"].ToString();
                    textNombre.Text = row["Nombre_Marca"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Marcas_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarMarcas();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarMarcas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre de la marca.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarMarcas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar una marca.");
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
            IdMarca = textId.Text.Trim();
            Marca = textNombre.Text.Trim();
            this.Close();
        }
    }
}