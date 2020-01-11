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
    public partial class Frm_Areas : DevExpress.XtraEditors.XtraForm
    {

        public string IdArea { get; set; }
        public string Area { get; set; }
        public Boolean PaSel { get; set; }


        public Frm_Areas()
        {
            InitializeComponent();
        }

        private void CargarAreas()
        {
            gridControl1.DataSource = null;
            CLS_Areas Clase = new CLS_Areas();

            Clase.MtdSeleccionarAreas();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarAreas()
        {
            CLS_Areas Clase = new CLS_Areas();
            Clase.Id_Area = textId.Text.Trim();
            Clase.Nombre_Area = textNombre.Text.Trim();
            Clase.MtdInsertarAreas();
            if (Clase.Exito)
            {

                CargarAreas();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarAreas()
        {
            CLS_Areas Clase = new CLS_Areas();
            Clase.Id_Area = textId.Text.Trim();
            Clase.MtdEliminarAreas();
            if (Clase.Exito)
            {
                CargarAreas();
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
                    textId.Text = row["Id_Area"].ToString();
                    textNombre.Text = row["Nombre_Area"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Areas_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarAreas();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarAreas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del area.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarAreas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un area.");
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
            IdArea = textId.Text.Trim();
            Area = textNombre.Text.Trim();
            this.Close();
        }
    }
}