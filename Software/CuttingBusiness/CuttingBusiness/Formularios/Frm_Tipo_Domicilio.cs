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
    public partial class Frm_Tipo_Domicilio : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }
        public Frm_Tipo_Domicilio()
        {
          
            InitializeComponent();
        }

        public string IdTipoDomicilio { get; set; }
        public string TipoDomicilio { get; set; }

        public string UsuariosLogin { get; set; }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            textId.Text = "";
            textNombre.Text = "";

        }
        private void CargarTipoDomicilio()
        {
            gridControl1.DataSource = null;
            CLS_Tipo_Domicilio TipoDomicilio = new CLS_Tipo_Domicilio();

            TipoDomicilio.MtdSeleccionarTipoDomicilio();
            if (TipoDomicilio.Exito)
            {
                gridControl1.DataSource = TipoDomicilio.Datos;
            }
        }



        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarTipoDomicilio();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre al tipo de Domicilio.");
            }
        }
        private void InsertarTipoDomicilio()
        {
            CLS_Tipo_Domicilio TipoDomicilio = new CLS_Tipo_Domicilio();
            TipoDomicilio.Id_Tipo_Domicilio = textId.Text.Trim();
            TipoDomicilio.Nombre_Tipo_Domicilio = textNombre.Text.Trim();
            TipoDomicilio.Usuario = UsuariosLogin.Trim();
            TipoDomicilio.MtdInsertarTipoDomicilio();
            if (TipoDomicilio.Exito)
            {

                CargarTipoDomicilio();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(TipoDomicilio.Mensaje);
            }
        }


        private void EliminarDomicilio()
        {
            CLS_Tipo_Domicilio TipoDomicilio = new CLS_Tipo_Domicilio();
            TipoDomicilio.Id_Tipo_Domicilio = textId.Text.Trim();
            TipoDomicilio.MtdEliminarTipoDomicilio();
            if (TipoDomicilio.Exito)
            {
                CargarTipoDomicilio();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(TipoDomicilio.Mensaje);
            }
        }


        private void Frm_Tipo_Domicilio_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarTipoDomicilio();
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdTipoDomicilio = textId.Text.Trim();
            TipoDomicilio = textNombre.Text.Trim();
            this.Close();
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarDomicilio();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar una licencia.");
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textId.Text = row["Id_TipoDomicilio"].ToString();
                    textNombre.Text = row["Nombre_TipoDomicilio"].ToString();
                    

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}