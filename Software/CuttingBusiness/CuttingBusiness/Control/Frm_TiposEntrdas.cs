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
    public partial class Frm_TiposEntradas : DevExpress.XtraEditors.XtraForm
    {

        public Boolean PaSel { get; set; }

        public Frm_TiposEntradas()
        {
            InitializeComponent();
        }

        public string IdTipoEntrada { get; set; }
        public string TipoEntrada { get; set; }

        private void CargarTipoEntrada()
        {
            gridControl1.DataSource = null;
            CLS_TiposEntradas Clase = new CLS_TiposEntradas();

            Clase.MtdSeleccionarTiposEntradas();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarTipoEntrada()
        {
            CLS_TiposEntradas Clase = new CLS_TiposEntradas();

            Clase.Id_TipoEntrada = textId.Text.Trim();
            Clase.Nombre_TipoEntrada = textNombre.Text.Trim();
            Clase.MtdInsertarTiposEntradas();

            if (Clase.Exito)
            {
                CargarTipoEntrada();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarTipoEntrada()
        {
            CLS_TiposEntradas Clase = new CLS_TiposEntradas();
            Clase.Id_TipoEntrada = textId.Text.Trim();
            Clase.MtdEliminarTiposEntradas();
            if (Clase.Exito)
            {
                CargarTipoEntrada();
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
                    textId.Text = row["Id_TipoEntrada"].ToString();
                    textNombre.Text = row["Nombre_TipoEntrada"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_TiposEntradas_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarTipoEntrada();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarTipoEntrada();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del tipo de Entrada.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarTipoEntrada();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un tipo de Entrada.");
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
            IdTipoEntrada = textId.Text.Trim();
            TipoEntrada = textNombre.Text.Trim();
            this.Close();
        }

        private void Frm_TiposEntradas_Shown(object sender, EventArgs e)
        {
            CargarTipoEntrada();
        }

        private void Frm_TiposEntradas_Load_1(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
    }
}