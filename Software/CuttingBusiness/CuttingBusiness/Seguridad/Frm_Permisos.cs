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
            gridControl1.DataSource = null;
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
            gridControl1.DataSource = null;
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

                CargarPerfilesPantallas();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
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
                CargarPantallas();
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
            CargarPerfilesPantallas();
            CargarPerfiles();
            CargarPantallas();
        }
    }
}