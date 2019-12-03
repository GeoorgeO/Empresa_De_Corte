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
    public partial class Frm_Series : DevExpress.XtraEditors.XtraForm
    {

        public Boolean PaSel { get; set; }

        public Frm_Series()
        {
            InitializeComponent();
        }

        public string IdSerie { get; set; }
        public string Serie { get; set; }

        private void CargarSerie()
        {
            gridControl1.DataSource = null;
            CLS_Series Clase = new CLS_Series();

            Clase.MtdSeleccionarSerie();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarSerie()
        {
            CLS_Series Clase = new CLS_Series();

            Clase.Id_Serie = textId.Text.Trim();
            Clase.Nombre_Serie = textNombre.Text.Trim();

            Clase.MtdInsertarSerie();

            if (Clase.Exito)
            {
                CargarSerie();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarSerie()
        {
            CLS_Series Clase = new CLS_Series();
            Clase.Id_Serie = textId.Text.Trim();
            Clase.MtdEliminarSerie();
            if (Clase.Exito)
            {
                CargarSerie();
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
                    textId.Text = row["Id_Serie"].ToString();
                    textNombre.Text = row["Nombre_Serie"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Series_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarSerie();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarSerie();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre de la Serie.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarSerie();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar una Serie.");
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
            IdSerie = textId.Text.Trim();
            Serie = textNombre.Text.Trim();
            this.Close();
        }
    }
}