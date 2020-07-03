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
    public partial class Frm_Cuadrilla : DevExpress.XtraEditors.XtraForm
    {

        public string UsuariosLogin { get; set; }

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

            Clase.Usuario = UsuariosLogin.Trim();
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
            gleCategoria.EditValue = null;
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
            if (gleCategoria.EditValue.ToString().Trim().Length > 0)
            {
                InsertarCuadrillas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar una Cuadrilla.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 )
            {
                EliminarCuadrillas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar una cuadrilla.");
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

        private void btnBusqCategoria_Click(object sender, EventArgs e)
        {
            Frm_CuadrillaCategoria Clase = new Frm_CuadrillaCategoria();
            Clase.UsuariosLogin = UsuariosLogin.Trim();
            Clase.ShowDialog();
            CargarCategoriasCuadrilla();
        }
    }
}