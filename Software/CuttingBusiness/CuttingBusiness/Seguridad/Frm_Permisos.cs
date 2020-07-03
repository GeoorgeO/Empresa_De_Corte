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

        public string UsuariosLogin { get; set; }

        public string InventarioPantallaIdDisponible { get; set; }
        public string InventarioPantallaIdAsignada { get; set; }
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
                cmbPerfiles.Properties.DisplayMember = "Nombre_Perfil";
                cmbPerfiles.Properties.ValueMember = "Id_Perfil";
                cmbPerfiles.EditValue = null;
                cmbPerfiles.Properties.DataSource = Clase.Datos;
            }
        }
        
        private void InsertarPerfilesPantallas()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Pantalla = AddPantalla;
            Clase.Id_Perfil = cmbPerfiles.EditValue.ToString();

            Clase.Usuario = UsuariosLogin.Trim();
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
            Clase.Id_Perfil = cmbPerfiles.EditValue.ToString();
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
            cmbPerfiles.EditValue = null;
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
        private void CargarAsignadas()
        {
            if (cmbPerfiles.EditValue != null)
            {
                CLS_Perfiles_Pantallas conPerfiles = new CLS_Perfiles_Pantallas();
                conPerfiles.Id_Perfil = cmbPerfiles.EditValue.ToString();
                conPerfiles.MtdSeleccionarPantallasAsignadas();
                if (conPerfiles.Exito)
                {
                    dtgAsignadas.DataSource = conPerfiles.Datos;
                    dtgValAsignadas.ClearSelection();
                    InventarioPantallaIdAsignada = string.Empty;
                }
            }
            else
            {
                dtgAsignadas.DataSource = null;
            }
        }

        private void CargarDisponible()
        {
            if (cmbPerfiles.EditValue != null)
            {
                CLS_Perfiles_Pantallas conPerfiles = new CLS_Perfiles_Pantallas();
                conPerfiles.Id_Perfil = cmbPerfiles.EditValue.ToString();
                conPerfiles.MtdSeleccionarPantallasDisponibles();
                if (conPerfiles.Exito)
                {
                    dtgDisponibles.DataSource = conPerfiles.Datos;
                    dtgValDisponibles.ClearSelection();
                    InventarioPantallaIdDisponible = string.Empty;
                }
            }
            else
            {
                dtgDisponibles.DataSource = null;
            }
        }

        private void cmbPerfiles_EditValueChanged(object sender, EventArgs e)
        {
            CargarDisponible();
            CargarAsignadas();
        }

        private void btnAsignaTodos_Click(object sender, EventArgs e)
        {
            if (dtgValDisponibles.RowCount > 0)
            {
                Boolean Exito = true;
                for (int i = 0; i < dtgValDisponibles.RowCount; i++)
                {
                    int xRow = dtgValDisponibles.GetVisibleRowHandle(i);
                    //Inserta Detalles
                    CLS_Perfiles_Pantallas ins = new CLS_Perfiles_Pantallas();
                    ins.Id_Perfil = cmbPerfiles.EditValue.ToString();
                    ins.Id_Pantalla = dtgValDisponibles.GetRowCellValue(xRow, dtgValDisponibles.Columns["Id_Pantalla"]).ToString();
                    ins.MtdInsertarPerfilesPantallas();
                    if (!ins.Exito)
                    {
                        Exito = false;
                        XtraMessageBox.Show(ins.Mensaje);
                    }
                }
                if (Exito)
                {
                    CargarAsignadas();
                    CargarDisponible();
                    XtraMessageBox.Show("Se han asignado los permisos con exito");
                }
            }
            else
            {
                XtraMessageBox.Show("Todos los permisos ya estan asignados");
            }
        }

        private void btnDisponeTodos_Click(object sender, EventArgs e)
        {
            if (dtgValAsignadas.RowCount > 0)
            {
                Boolean Exito = true;
                for (int i = 0; i < dtgValAsignadas.RowCount; i++)
                {
                    int xRow = dtgValAsignadas.GetVisibleRowHandle(i);
                    //Inserta Detalles
                    CLS_Perfiles_Pantallas del = new CLS_Perfiles_Pantallas();
                    del.Id_Perfil = cmbPerfiles.EditValue.ToString();
                    del.Id_Pantalla = dtgValAsignadas.GetRowCellValue(xRow, dtgValAsignadas.Columns["Id_Pantalla"]).ToString();
                    del.MtdEliminarPerfilesPantallas();
                    if (!del.Exito)
                    {
                        Exito = false;
                        XtraMessageBox.Show(del.Mensaje);
                    }
                }
                if (Exito)
                {
                    CargarAsignadas();
                    CargarDisponible();
                    XtraMessageBox.Show("Se han quitado los permisos con exito");
                }
            }
            else
            {
                XtraMessageBox.Show("Todos los permisos ya estan disponibles");
            }
        }

        private void btnAsigna_Click(object sender, EventArgs e)
        {
            if (cmbPerfiles.EditValue != null && InventarioPantallaIdDisponible !=string.Empty)
            {
                CLS_Perfiles_Pantallas del = new CLS_Perfiles_Pantallas();
                del.Id_Perfil = cmbPerfiles.EditValue.ToString();
                del.Id_Pantalla = InventarioPantallaIdDisponible;
                del.MtdInsertarPerfilesPantallas();
                if (del.Exito)
                {
                    XtraMessageBox.Show("Se ha asignado el permiso con exito");
                    CargarAsignadas();
                    CargarDisponible();
                }
                else
                {
                    XtraMessageBox.Show(del.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado Usuario o pantalla a asignar");
            }
        }

        private void btnDispone_Click(object sender, EventArgs e)
        {
            if (cmbPerfiles.EditValue != null && InventarioPantallaIdAsignada !=string.Empty)
            {
                CLS_Perfiles_Pantallas del = new CLS_Perfiles_Pantallas();
                del.Id_Perfil = cmbPerfiles.EditValue.ToString();
                del.Id_Pantalla = InventarioPantallaIdAsignada;
                del.MtdEliminarPerfilesPantallas();
                if (del.Exito)
                {
                    XtraMessageBox.Show("Se ha quitado el permiso con exito");
                    CargarAsignadas();
                    CargarDisponible();
                }
                else
                {
                    XtraMessageBox.Show(del.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado Usuario o pantalla a quitar");
            }
        }

        private void dtgAsignadas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValAsignadas.GetSelectedRows())
                {
                    DataRow row = this.dtgValAsignadas.GetDataRow(i);
                    InventarioPantallaIdAsignada = row["Id_Pantalla"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgDisponibles_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValDisponibles.GetSelectedRows())
                {
                    DataRow row = this.dtgValDisponibles.GetDataRow(i);
                    InventarioPantallaIdDisponible = row["Id_Pantalla"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            Frm_Perfiles frm = new Frm_Perfiles();
            frm.ShowDialog();
            CargarPerfiles();
        }
    }
}