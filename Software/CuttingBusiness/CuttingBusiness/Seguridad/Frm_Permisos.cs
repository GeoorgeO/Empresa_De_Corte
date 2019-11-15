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
    public partial class Frm_Permisos : DevExpress.XtraEditors.XtraForm
    {

        public string IdPantalla { get; set; }
        public string IdPerfil { get; set; }
        public Boolean PaSel { get; set; }

        private static Frm_Permisos m_FormDefInstance;
        public static Frm_Permisos DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Permisos();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public Frm_Permisos()
        {
            InitializeComponent();
        }

        private void CargarPerfilesPantallas()
        {
            gridControl1.DataSource = null;
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();

            Clase.MtdSeleccionarPerfilesPantallas();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }
        private void CargarPerfiles()
        {
            CLS_Perfiles Clase = new CLS_Perfiles();

            Clase.MtdSeleccionarPerfiles();
            if (Clase.Exito)
            {
                gridLookUpEdit1.Properties.DisplayMember = "Nombre_Perfil";
                gridLookUpEdit1.Properties.ValueMember = "Id_Perfil";
                gridLookUpEdit1.EditValue = null;
                gridLookUpEdit1.Properties.DataSource = Clase.Datos;
            }
        }
        private void CargarPantallas()
        {
            CLS_Pantallas Clase = new CLS_Pantallas();

            Clase.MtdSeleccionarPantallas();
            if (Clase.Exito)
            {
                gridLookUpEdit2.Properties.DisplayMember = "Nombre_Pantalla";
                gridLookUpEdit2.Properties.ValueMember = "Id_Pantalla";
                gridLookUpEdit2.EditValue = null;
                gridLookUpEdit2.Properties.DataSource = Clase.Datos;
            }
        }
        private void InsertarPerfilesPantallas()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Pantalla = gridLookUpEdit2.EditValue.ToString();
            Clase.Id_Perfil = gridLookUpEdit1.EditValue.ToString();
            Clase.MtdInsertarPerfilesPantallas();
            if (Clase.Exito)
            {
                if (Clase.Datos.Rows[0][0].ToString()== "Ya existe")
                {
                    XtraMessageBox.Show("Ya Se encuentra esta ventana en el perfil seleccionado");
                }
                else
                {
                    CargarPerfilesPantallas();
                    XtraMessageBox.Show("Se ha Insertado el registro con exito");
                    LimpiarCampos();
                }
               
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarPerfilesPantallas()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Pantalla = gridLookUpEdit2.EditValue.ToString();
            Clase.Id_Perfil = gridLookUpEdit1.EditValue.ToString();
            Clase.MtdEliminarPerfilesPantallas();
            if (Clase.Exito)
            {
                CargarPerfilesPantallas();
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
            CargarPantallas();
            CargarPerfiles();
        }

        private void Frm_Permisos_Load(object sender, EventArgs e)
        {
            if (PaSel == true)
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            CargarPerfiles();
            CargarPantallas();
            CargarPerfilesPantallas();
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    gridLookUpEdit1.EditValue = row["Id_Perfil"].ToString();
                    gridLookUpEdit2.EditValue = row["Id_Pantalla"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridLookUpEdit1.EditValue != null && gridLookUpEdit2.EditValue != null)
            {
                InsertarPerfilesPantallas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un perfil y pantalla.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridLookUpEdit1.EditValue != null && gridLookUpEdit2.EditValue != null)
            {
                EliminarPerfilesPantallas();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un registro de la lista.");
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
            IdPantalla = gridLookUpEdit2.EditValue.ToString();
            IdPerfil = gridLookUpEdit1.EditValue.ToString();
            this.Close();
        }
    }
}