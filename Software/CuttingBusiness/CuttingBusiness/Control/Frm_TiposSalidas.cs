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
    public partial class Frm_TiposSalidas : DevExpress.XtraEditors.XtraForm
    {

        public Boolean PaSel { get; set; }

        public Frm_TiposSalidas()
        {
            InitializeComponent();
        }

        public string IdTipoSalida { get; set; }
        public string TipoSalida { get; set; }

        public string UsuariosLogin { get; set; }

        private void CargarTipoSalida()
        {
            gridControl1.DataSource = null;
            CLS_TiposSalidas Clase = new CLS_TiposSalidas ();

            Clase.MtdSeleccionarTiposSalidas();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void InsertarTipoSalida()
        {
            CLS_TiposSalidas Clase = new CLS_TiposSalidas();

            Clase.Id_TipoSalida = textId.Text.Trim();
            Clase.Nombre_TipoSalida = textNombre.Text.Trim();
            Clase.Usuario = UsuariosLogin.Trim();
            Clase.MtdInsertarTiposSalidas();

            if (Clase.Exito)
            {
                CargarTipoSalida();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarTipoSalida()
        {
            CLS_TiposSalidas Clase = new CLS_TiposSalidas();
            Clase.Id_TipoSalida = textId.Text.Trim();
            Clase.MtdEliminarTiposSalidas();
            if (Clase.Exito)
            {
                CargarTipoSalida();
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
                    textId.Text = row["Id_TipoSalida"].ToString();
                    textNombre.Text = row["Nombre_TipoSalida"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_TiposSalidas_Load(object sender, EventArgs e)
        {
           
            CargarTipoSalida();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {
                InsertarTipoSalida();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del tipo de salida.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarTipoSalida();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un tipo de salida.");
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

        

        private void Frm_TiposSalidas_Load_1(object sender, EventArgs e)
        {
            CargarTipoSalida();
        }
    }
}