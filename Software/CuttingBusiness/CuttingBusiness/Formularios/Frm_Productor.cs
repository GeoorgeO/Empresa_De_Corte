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
    public partial class Frm_Productor : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }
        public Frm_Productor()
        {
          
            InitializeComponent();
        }

        public string IdDuenio { get; set; }
        public string Duenio { get; set; }

        public string UsuariosLogin { get; set; }

        private void CargarDuenio()
        {
            gridControl1.DataSource = null;
            CLS_Duenio Clase = new CLS_Duenio();

            Clase.MtdSeleccionarDuenio();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarDuenio()
        {
            CLS_Duenio Clase = new CLS_Duenio();

            Clase.Id_Duenio = textId.Text.Trim();
            Clase.Nombre_Duenio = textNombre.Text.Trim();
            Clase.Usuario = UsuariosLogin.Trim();
            Clase.MtdInsertarDuenio();

            if (Clase.Exito)
            {
                CargarDuenio();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarDuenio()
        {
            CLS_Duenio Clase = new CLS_Duenio();
            Clase.Id_Duenio = textId.Text.Trim();
            Clase.MtdEliminarDuenio();
            if (Clase.Exito)
            {
                CargarDuenio();
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
                    textId.Text = row["Id_Duenio"].ToString();
                    textNombre.Text = row["Nombre_Duenio"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Dueños_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarDuenio();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {


                InsertarDuenio();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del dueño.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 )
            {
                EliminarDuenio();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un dueño.");
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
            IdDuenio = textId.Text.Trim();
            Duenio = textNombre.Text.Trim();
            this.Close();
        }
    }
}