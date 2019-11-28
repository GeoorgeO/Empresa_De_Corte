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
    public partial class Frm_CuadrillaCategoria : DevExpress.XtraEditors.XtraForm
    {

        public string IdCategoria { get; set; }
        public string Categoria { get; set; }
        public Boolean PaSel { get; set; }

        public Frm_CuadrillaCategoria()
        {
            InitializeComponent();
        }

        private void CargarCategoriasCuadrilla()
        {
            gridControl1.DataSource = null;
            CLS_CategoriasCuadrilla Clase = new CLS_CategoriasCuadrilla();

            Clase.MtdSeleccionarCategoriasCuadrilla();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }



        private void InsertarCategoriasCuadrilla()
        {
            CLS_CategoriasCuadrilla Clase = new CLS_CategoriasCuadrilla();
            Clase.Id_Categoria = textId.Text.Trim();
            Clase.Nombre_Categoria = textNombre.Text.Trim();
            Clase.MtdInsertarCategoriasCuadrilla();
            if (Clase.Exito)
            {

                CargarCategoriasCuadrilla();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarCategoriasCuadrilla()
        {
            CLS_CategoriasCuadrilla Clase = new CLS_CategoriasCuadrilla();
            Clase.Id_Categoria = textId.Text.Trim();
            Clase.MtdEliminarCategoriasCuadrilla();
            if (Clase.Exito)
            {
                CargarCategoriasCuadrilla();
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
                    textId.Text = row["Id_Categoria"].ToString();
                    textNombre.Text = row["Nombre_Categoria"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_CuadrillaCategoria_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarCategoriasCuadrilla();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {


                InsertarCategoriasCuadrilla();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre a la categoria.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarCategoriasCuadrilla();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar una categoria.");
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
            IdCategoria = textId.Text.Trim();
            Categoria = textNombre.Text.Trim();
            this.Close();
        }
    }
}