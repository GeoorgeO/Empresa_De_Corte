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
    public partial class Frm_Perfiles : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Perfiles()
        {
            InitializeComponent();
        }


        public string IdPerfil { get; set; }
        public string Perfil { get; set; }
        public Boolean PaSel { get; set; }

        

        private void CargarPerfiles()
        {
            gridControl1.DataSource = null;
            CLS_Perfiles Perfil = new CLS_Perfiles();

            Perfil.MtdSeleccionarPerfiles();
            if (Perfil.Exito)
            {
                gridControl1.DataSource = Perfil.Datos;
            }
        }



        private void InsertarPerfiles()
        {
            CLS_Perfiles Perfil = new CLS_Perfiles();
            Perfil.Id_Perfil = textId.Text.Trim();
            Perfil.Nombre_Perfil = textNombre.Text.Trim();
            Perfil.MtdInsertarPerfiles();
            if (Perfil.Exito)
            {

                CargarPerfiles();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Perfil.Mensaje);
            }
        }

        private void EliminarPerfiles()
        {
            CLS_Perfiles Perfil = new CLS_Perfiles();
            Perfil.Id_Perfil = textId.Text.Trim();
            Perfil.MtdEliminarPerfiles();
            if (Perfil.Exito)
            {
                CargarPerfiles();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Perfil.Mensaje);
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
                    textId.Text = row["Id_Perfil"].ToString();
                    textNombre.Text = row["Nombre_Perfil"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Perfiles_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarPerfiles();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {


                InsertarPerfiles();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del perfil.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarPerfiles();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un perfil.");
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
            IdPerfil = textId.Text.Trim();
            Perfil = textNombre.Text.Trim();
            this.Close();
        }
    }
}