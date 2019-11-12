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
    public partial class Frm_Pantallas : DevExpress.XtraEditors.XtraForm
    {

        public string IdPantalla { get; set; }
        public string Pantalla { get; set; }
        public Boolean PaSel { get; set; }

        public Frm_Pantallas()
        {
            InitializeComponent();
        }

        private void CargarPantallas()
        {
            gridControl1.DataSource = null;
            CLS_Pantallas Clase = new CLS_Pantallas();

            Clase.MtdSeleccionarPantallas();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }



        private void InsertarPantallas()
        {
            CLS_Pantallas Clase = new CLS_Pantallas();
            Clase.Id_Pantalla = textId.Text.Trim();
            Clase.Nombre_Pantalla = textNombre.Text.Trim();
            Clase.MtdInsertarPantallas();
            if (Clase.Exito)
            {

                CargarPantallas();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarPantallas()
        {
            CLS_Pantallas Clase = new CLS_Pantallas();
            Clase.Id_Pantalla = textId.Text.Trim();
            Clase.MtdEliminarPantallas();
            if (Clase.Exito)
            {
                CargarPantallas();
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
                    textId.Text = row["Id_Pantalla"].ToString();
                    textNombre.Text = row["Nombre_Pantalla"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Pantallas_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarPantallas();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarPantallas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre de la pantalla.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarPantallas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar una pantalla.");
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
            IdPantalla = textId.Text.Trim();
            Pantalla = textNombre.Text.Trim();
            this.Close();
        }
    }
}