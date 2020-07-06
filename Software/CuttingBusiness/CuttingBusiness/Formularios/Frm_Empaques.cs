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
    public partial class Frm_Empaques : DevExpress.XtraEditors.XtraForm
    {
        public string IdEmpaque { get; set; }
        public string Empaque { get; set; }
        public Boolean PaSel { get; set; }

        public string UsuariosLogin { get; set; }

        public Frm_Empaques()
        {
            InitializeComponent();
        }

        private void CargarEmpaques()
        {
            gridControl1.DataSource = null;
            CLS_Empaques Clase = new CLS_Empaques();

            Clase.MtdSeleccionarEmpaques();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarEmpaques()
        {
            CLS_Empaques Clase = new CLS_Empaques();
            Clase.Id_Empaque = textId.Text.Trim();
            Clase.Nombre_Empaque = textNombre.Text.Trim();
            Clase.Usuario = UsuariosLogin.Trim();
            Clase.MtdInsertarEmpaques();
            if (Clase.Exito)
            {

                CargarEmpaques();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarEmpaques()
        {
            CLS_Empaques Clase = new CLS_Empaques();
            Clase.Id_Empaque = textId.Text.Trim();
            Clase.MtdEliminarEmpaques();
            if (Clase.Exito)
            {
                CargarEmpaques();
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
                    textId.Text = row["Id_Empaque"].ToString();
                    textNombre.Text = row["Nombre_Empaque"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Empaques_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarEmpaques();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarEmpaques();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del empaque.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarEmpaques();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un empaque.");
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
            IdEmpaque = textId.Text.Trim();
            Empaque = textNombre.Text.Trim();
            this.Close();
        }
    }
}