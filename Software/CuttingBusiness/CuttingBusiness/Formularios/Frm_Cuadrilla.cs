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

namespace CuttingBusiness.Formularios
{
    public partial class Frm_Cuadrilla : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Cuadrilla()
        {
            InitializeComponent();
        }

        private void CargarCuadrillas()
        {
            gridControl1.DataSource = null;
            CLS_Cuadrillas Clase = new CLS_Cuadrillas();

            Clase.MtdSeleccionarCuadrillas();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void CargarCategoriasCuadrilla()
        {
            gridControl1.DataSource = null;
            CLS_CategoriasCuadrilla Clase = new CLS_CategoriasCuadrilla();

            Clase.MtdSeleccionarCategoriasCuadrilla();
            if (Clase.Exito)
            {
                gleCategoria.Properties.DisplayMember = "Nombre_Categoria";
                gleCategoria.Properties.ValueMember = "Id_Categoria";
                gleCategoria.EditValue = null;
                gleCategoria.Properties.DataSource = Clase.Datos;
            }
        }

        private void InsertarCuadrillas()
        {
            CLS_Cuadrillas Clase = new CLS_Cuadrillas();
            Clase.Id_Cuadrilla = textId.Text.Trim();
            Clase.Id_Categoria = gleCategoria.EditValue.ToString();
            Clase.MtdInsertarCuadrillas();
            if (Clase.Exito)
            {

                CargarCuadrillas();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarCuadrillas()
        {
            CLS_Cuadrillas Clase = new CLS_Cuadrillas();
            Clase.Id_Cuadrilla = textId.Text.Trim();
            Clase.MtdEliminarCuadrillas();
            if (Clase.Exito)
            {
                CargarCuadrillas();
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
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textId.Text = row["Id_Cuadrilla"].ToString();
                    gleCategoria.EditValue = row["Id_Categoria"].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Cuadrilla_Load(object sender, EventArgs e)
        {
            CargarCuadrillas();
            CargarCategoriasCuadrilla();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.ToString().Trim().Length > 0)
            {
                InsertarCuadrillas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar una categoria.");
            }
        }
    }
}