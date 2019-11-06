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
    public partial class Frm_Calidad : DevExpress.XtraEditors.XtraForm
    {

        public Boolean PaSel { get; set; }

        public Frm_Calidad()
        {
            InitializeComponent();
        }

        public string IdCalidad { get; set; }
        public string Calidad { get; set; }

        private void CargarCalidad()
        {
            gridControl1.DataSource = null;
            CLS_Calidades Clase = new CLS_Calidades();

            Clase.MtdSeleccionarCalidad();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarCalidad()
        {
            CLS_Calidades Clase = new CLS_Calidades();

            Clase.Id_Calidad = textId.Text.Trim();
            Clase.Nombre_Calidad = textNombre.Text.Trim();

            Clase.MtdInsertarCalidad();

            if (Clase.Exito)
            {
                CargarCalidad();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarCalidad()
        {
            CLS_Calidades Clase = new CLS_Calidades();
            Clase.Id_Calidad = textId.Text.Trim();
            Clase.MtdEliminarCalidad();
            if (Clase.Exito)
            {
                CargarCalidad();
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
                    textId.Text = row["Id_Calidad"].ToString();
                    textNombre.Text = row["Nombre_Calidad"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Calidad_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarCalidad();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {


                InsertarCalidad();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre de la calidad.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarCalidad();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar una calidad.");
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
            IdCalidad = textId.Text.Trim();
            Calidad = textNombre.Text.Trim();
            this.Close();
        }
    }
}