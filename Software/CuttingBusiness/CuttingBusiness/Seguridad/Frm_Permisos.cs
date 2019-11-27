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

        public string AddPantalla { get;  set; }
        public string RemovePantalla { get;  set; }

        public Frm_Permisos()
        {
            InitializeComponent();
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
        
        private void InsertarPerfilesPantallas()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Pantalla = AddPantalla;
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
            Clase.Id_Pantalla = RemovePantalla;
            Clase.Id_Perfil = gridLookUpEdit1.EditValue.ToString();
            Clase.MtdEliminarPerfilesPantallas();
            if (Clase.Exito)
            {
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