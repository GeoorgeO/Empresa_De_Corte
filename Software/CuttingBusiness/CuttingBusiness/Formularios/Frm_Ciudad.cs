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
    public partial class Frm_Ciudad : DevExpress.XtraEditors.XtraForm
    {

        public Boolean PaSel { get; set; }

        
        public Frm_Ciudad()
        {
            InitializeComponent();
        }


        public string IdCiudad { get; set; }
        public string Ciudad { get; set; }
        public string IdEstado { get; set; }
        public string Estado { get; set; }

        private void CargarCiudad()
        {
            gridControl1.DataSource = null;
            CLS_Ciudades Clase = new CLS_Ciudades();

            Clase.MtdSeleccionarCiudad();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarCiudad()
        {
            CLS_Ciudades Clase = new CLS_Ciudades();

            Clase.Id_Ciudad = textId.Text.Trim();
            Clase.Nombre_Ciudad = textNombre.Text.Trim();
            Clase.Id_Estado = textEstado.Tag.ToString();

            Clase.MtdInsertarCiudad();

            if (Clase.Exito)
            {
                CargarCiudad();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarCiudad()
        {
            CLS_Ciudades Clase = new CLS_Ciudades();
            Clase.Id_Ciudad = textId.Text.Trim();
            Clase.MtdEliminarCiudad();
            if (Clase.Exito)
            {
                CargarCiudad();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void iniciarTags()
        {
            textEstado.Tag = "";
        }

        private void LimpiarCampos()
        {
            textId.Text = "";
            textNombre.Text = "";
            textEstado.Text = "";
            textEstado.Tag = "";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textId.Text = row["Id_Ciudad"].ToString();
                    textNombre.Text = row["Nombre_Ciudad"].ToString();
                    textEstado.Tag = row["Id_Estado"].ToString();
                    textEstado.Text = row["Nombre_Estado"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Ciudad_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarCiudad();
            iniciarTags();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarCiudad();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre de una ciudad.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarCiudad();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar una ciudad.");
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
            IdCiudad = textId.Text.Trim();
            Ciudad = textNombre.Text.Trim();
            IdEstado = textEstado.Tag.ToString();
            Estado = textEstado.Text.Trim();
            this.Close();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Frm_Estado Estado = new Frm_Estado();
            Estado.PaSel = true;
            Estado.ShowDialog();

            textEstado.Tag = Estado.IdEstado;
            textEstado.Text = Estado.Estado;
        }
    }
}