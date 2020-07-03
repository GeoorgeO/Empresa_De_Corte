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
    public partial class Frm_TiposCorte : DevExpress.XtraEditors.XtraForm
    {

        public string IdTipoCorte { get; set; }
        public string TipoCorte { get; set; }
        public Boolean PaSel { get; set; }

        public string UsuariosLogin { get; set; }

        public Frm_TiposCorte()
        {
            InitializeComponent();
        }

        private void CargarTiposCorte()
        {
            gridControl1.DataSource = null;
            CLS_TiposCorte Clase = new CLS_TiposCorte();

            Clase.MtdSeleccionarTiposCorte();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }



        private void InsertarTiposCorte()
        {
            CLS_TiposCorte Clase = new CLS_TiposCorte();
            Clase.Id_TipoCorte= textId.Text.Trim();
            Clase.Nombre_TipoCorte = textNombre.Text.Trim();
            Clase.Usuario = UsuariosLogin.Trim();
            Clase.MtdInsertarTiposCorte();
            if (Clase.Exito)
            {

                CargarTiposCorte();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarPais()
        {
            CLS_TiposCorte Clase = new CLS_TiposCorte();
            Clase.Id_TipoCorte = textId.Text.Trim();
            Clase.MtdEliminarTiposCorte();
            if (Clase.Exito)
            {
                CargarTiposCorte();
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
                    textId.Text = row["Id_TipoCorte"].ToString();
                    textNombre.Text = row["Nombre_TipoCorte"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_TiposCorte_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarTiposCorte();
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdTipoCorte = textId.Text.Trim();
            TipoCorte = textNombre.Text.Trim();
            this.Close();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarTiposCorte();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del Tipo de corte.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarPais();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un Tipo de corte.");
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
    }
}