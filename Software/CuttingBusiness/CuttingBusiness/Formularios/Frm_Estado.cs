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
    public partial class Frm_Estado : DevExpress.XtraEditors.XtraForm
    {

        private static Frm_Estado m_FormDefInstance;
        public static Frm_Estado DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Estado();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public Boolean PaSel { get; set; }

        public string UsuariosLogin { get; set; }

        public Frm_Estado()
        {
            InitializeComponent();
        }

        public string IdEstado { get; set; }
        public string Estado { get; set; }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Frm_Pais Pais = new Frm_Pais(true);
            Pais.UsuariosLogin = UsuariosLogin.Trim();
            Pais.ShowDialog();

            textIdPais.Text = Pais.IdPais;
            textPais.Text = Pais.Pais;
        }

        private void CargarEstado()
        {
            gridControl1.DataSource = null;
            CLS_Estado Estado = new CLS_Estado();

            Estado.MtdSeleccionarEstado();
            if (Estado.Exito)
            {
                gridControl1.DataSource = Estado.Datos;
            }
        }



        private void InsertarEstado()
        {
            CLS_Estado Estado = new CLS_Estado();
            Estado.Id_Estado = textIdEstado.Text.Trim();
            Estado.Nombre_Estado = textEstado.Text.Trim();
            Estado.Id_Pais = textIdPais.Text.Trim();
            Estado.Usuario = UsuariosLogin.Trim();
            Estado.MtdInsertarEstado();
            if (Estado.Exito)
            {

                CargarEstado();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Estado.Mensaje);
            }
        }

        private void EliminarEstado()
        {
            CLS_Estado Estado = new CLS_Estado();
            Estado.Id_Estado = textIdEstado.Text.Trim();
            Estado.MtdEliminarEstado();
            if (Estado.Exito)
            {
                CargarEstado();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Estado.Mensaje);
            }
        }

        private void LimpiarCampos()
        {
            textIdEstado.Text = "";
            textEstado.Text = "";
            textIdPais.Text = "";
            textPais.Text = "";
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textIdEstado.Text = row["Id_Estado"].ToString();
                    textEstado.Text = row["Nombre_Estado"].ToString();
                    textIdPais.Text = row["Id_Pais"].ToString();
                    textPais.Text=row["Nombre_Pais"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textEstado.Text.ToString().Trim().Length > 0)
            {
                if (textPais.Text.ToString().Trim().Length > 0)
                {

                    InsertarEstado();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario seleccionar un nombre del pais.");
                }
            }
            else
            {
                XtraMessageBox.Show("Es necesario Agregar un nombre al estado.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textIdEstado.Text.Trim().Length > 0 )
            {
                EliminarEstado();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un Estado.");
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

        private void Frm_Estado_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarEstado();
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdEstado = textIdEstado.Text.Trim();
            Estado = textEstado.Text.Trim();
            this.Close();
        }
    }
}