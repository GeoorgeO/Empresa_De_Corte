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
    public partial class Frm_UnidadesMedida : DevExpress.XtraEditors.XtraForm
    {

        public string IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public Boolean PaSel { get; set; }

        public string UsuariosLogin { get; set; }

        public Frm_UnidadesMedida()
        {
            InitializeComponent();
        }

        private void CargarUnidadesMedida()
        {
            gridControl1.DataSource = null;
            CLS_UnidadesMedida Clase = new CLS_UnidadesMedida();

            Clase.MtdSeleccionarUnidadesMedida();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }



        private void InsertarUnidadesMedida()
        {
            CLS_UnidadesMedida Clase = new CLS_UnidadesMedida();
            Clase.Id_UnidadMedida = textId.Text.Trim();
            Clase.Nombre_UnidadMedida = textNombre.Text.Trim();
            Clase.Abrevia_UnidadMedida = textAbrevia.Text.Trim();

            Clase.Usuario = UsuariosLogin.Trim(); 
            Clase.MtdInsertarUnidadesMedida();
            if (Clase.Exito)
            {

                CargarUnidadesMedida();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarUnidadesMedida()
        {
            CLS_UnidadesMedida Clase = new CLS_UnidadesMedida();
            Clase.Id_UnidadMedida = textId.Text.Trim();
            Clase.MtdEliminarUnidadesMedida();
            if (Clase.Exito)
            {
                CargarUnidadesMedida();
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
            textAbrevia.Text = "";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textId.Text = row["Id_UnidadMedida"].ToString();
                    textNombre.Text = row["Nombre_UnidadMedida"].ToString();
                    textAbrevia.Text = row["Abrevia_UnidadMedida"].ToString();
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
                InsertarUnidadesMedida();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del pais.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 )
            {
                EliminarUnidadesMedida();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un pais.");
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

        private void Frm_UnidadesMedida_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarUnidadesMedida();
            
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdUnidadMedida = textId.Text.Trim();
            UnidadMedida = textNombre.Text.Trim();
            this.Close();
        }
    }
}