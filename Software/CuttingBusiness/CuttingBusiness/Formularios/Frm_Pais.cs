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
    public partial class Frm_Pais : DevExpress.XtraEditors.XtraForm
    {

        public string IdPais { get; set; }
        public string Pais { get; set; }
        public Boolean PaSel { get; set; }

        public string UsuariosLogin { get; set; }

        public Frm_Pais(Boolean BPasel)
        {
            this.PaSel = BPasel;
            InitializeComponent();
        }

        private void CargarPais()
        {
            gridControl1.DataSource = null;
            CLS_Pais Pais = new CLS_Pais();

            Pais.MtdSeleccionarPais();
            if (Pais.Exito)
            {
                gridControl1.DataSource = Pais.Datos;
            }
        }



        private void InsertarPais()
        {
            CLS_Pais Pais = new CLS_Pais();
            Pais.Id_Pais = textId.Text.Trim();
            Pais.Nombre_Pais = textNombre.Text.Trim();
            Pais.Usuario = UsuariosLogin.Trim();
            Pais.MtdInsertarPais();
            if (Pais.Exito)
            {

                CargarPais();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Pais.Mensaje);
            }
        }

        private void EliminarPais()
        {
            CLS_Pais Pais = new CLS_Pais();
            Pais.Id_Pais = textId.Text.Trim();
            Pais.MtdEliminarPais();
            if (Pais.Exito)
            {
                CargarPais();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Pais.Mensaje);
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
                    textId.Text = row["Id_Pais"].ToString();
                    textNombre.Text = row["Nombre_Pais"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Pais_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarPais();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textNombre.Text.ToString().Trim().Length > 0)
            {


                InsertarPais();
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre del pais.");
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
                XtraMessageBox.Show("Es necesario seleccionar un pais.");
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

        private void btnSeleecionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdPais = textId.Text.Trim();
            Pais = textNombre.Text.Trim();
            this.Close();
        }
    }
}