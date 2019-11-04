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
    public partial class Frm_Tipo_Persona : DevExpress.XtraEditors.XtraForm
    {



        public Frm_Tipo_Persona()
        {
            InitializeComponent();
        }

        private void CargarTipoPersona()
        {
            gridControl1.DataSource = null;
            CLS_TipoPersona TipoPersona = new CLS_TipoPersona();

            TipoPersona.MtdSeleccionarTipoPersona();
            if (TipoPersona.Exito)
            {
                gridControl1.DataSource = TipoPersona.Datos;
            }
        }



        private void InsertarTipoPersona()
        {
            CLS_TipoPersona TipoPersona = new CLS_TipoPersona();
            TipoPersona.Id_TipoPersona = textId.Text.Trim();
            TipoPersona.TipoPersona = textNombre.Text.Trim();
            TipoPersona.MtdInsertarTipoPersona();
            if (TipoPersona.Exito)
            {

                CargarTipoPersona();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(TipoPersona.Mensaje);
            }
        }

        private void EliminarTipoPersona()
        {
            CLS_TipoPersona TipoPersona = new CLS_TipoPersona();
            TipoPersona.Id_TipoPersona = textId.Text.Trim();
            TipoPersona.MtdEliminarTipoPersona();
            if (TipoPersona.Exito)
            {
                CargarTipoPersona();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(TipoPersona.Mensaje);
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
                    textId.Text = row["Id_TipoPersona"].ToString();
                    textNombre.Text = row["TipoPersona"].ToString();


                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Tipo_Persona_Load(object sender, EventArgs e)
        {
            CargarTipoPersona();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {


                InsertarTipoPersona();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre al tipo persona.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0 && textNombre.Text.ToString().Trim().Length > 0)
            {
                EliminarTipoPersona();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un tipo de persona.");
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

        private void btnBusqTipoDomicilio_Click(object sender, EventArgs e)
        {

        }

        private void btnBusqEstado_Click(object sender, EventArgs e)
        {

        }
    }
}