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
    public partial class Frm_Puesto : DevExpress.XtraEditors.XtraForm
    {

        public Boolean PaSel { get; set; }

        public Frm_Puesto()
        {
            InitializeComponent();
        }

        public string IdPuesto { get; set; }
        public string Puesto { get; set; }

        private void CargarPuestos()
        {
            gridControl1.DataSource = null;
            CLS_Puestos Clase = new CLS_Puestos();

            Clase.MtdSeleccionarPuestos();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarPuestos()
        {
            CLS_Puestos Clase = new CLS_Puestos();

            Clase.Id_Puesto = textId.Text.Trim();
            Clase.Nombre_Puesto = textNombre.Text.Trim();

            Clase.MtdInsertarPuestos();

            if (Clase.Exito)
            {
                CargarPuestos();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarPuestos()
        {
            CLS_Puestos Clase = new CLS_Puestos();
            Clase.Id_Puesto = textId.Text.Trim();
            Clase.MtdEliminarPuestos();
            if (Clase.Exito)
            {
                CargarPuestos();
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
                    textId.Text = row["Id_Puesto"].ToString();
                    textNombre.Text = row["Nombre_Puesto"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Puesto_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarPuestos();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarPuestos();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre de un Puesto.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarPuestos();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un Puesto.");
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
            IdPuesto = textId.Text.Trim();
            Puesto = textNombre.Text.Trim();
            this.Close();
        }
    }
}