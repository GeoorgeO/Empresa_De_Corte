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
    public partial class Frm_Jefes_Area : DevExpress.XtraEditors.XtraForm
    {
        public string IdJefeArea { get; set; }
        public string JefeArea { get; set; }
        public Boolean PaSel { get; set; }

        public Frm_Jefes_Area()
        {
            InitializeComponent();
        }

        private void CargarJefesArea()
        {
            gridControl1.DataSource = null;
            CLS_Jefes_Area Clase = new CLS_Jefes_Area();

            Clase.MtdSeleccionarJefes_Area();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarJefesArea()
        {
            CLS_Jefes_Area Clase = new CLS_Jefes_Area();
            Clase.Id_Jefe_Area = textId.Text.Trim();
            Clase.Nombre_Jefe_Area = textNombre.Text.Trim();
            Clase.MtdInsertarJefes_Area();
            if (Clase.Exito)
            {

                CargarJefesArea();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarJefesArea()
        {
            CLS_Jefes_Area Clase = new CLS_Jefes_Area();
            Clase.Id_Jefe_Area = textId.Text.Trim();
            Clase.MtdEliminarJefes_Area();
            if (Clase.Exito)
            {
                CargarJefesArea();
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
                    textId.Text = row["Id_Jefe_Area"].ToString();
                    textNombre.Text = row["Nombre_Jefe_Area"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Jefes_Area_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarJefesArea();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarJefesArea();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del jefe de area.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarJefesArea();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un jefe de area.");
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
            IdJefeArea = textId.Text.Trim();
            JefeArea = textNombre.Text.Trim();
            this.Close();
        }
    }
}