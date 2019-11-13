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
    public partial class Frm_Usuarios : DevExpress.XtraEditors.XtraForm
    {
      
        public Frm_Usuarios()
        {
            InitializeComponent();
        }

        private void CargarUsuarios()
        {
            gridControl1.DataSource = null;
            CLS_Usuarios Clase = new CLS_Usuarios();

            Clase.MtdSeleccionarUsuarios();
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
        private void InsertarUsuarios()
        {
            CLS_Usuarios Clase = new CLS_Usuarios();
            Clase.Id_Usuario = textUsuario.Text.Trim();
            Clase.Nombre_Usuario =textNombre.Text.Trim();
            Clase.Contrasena = textContrasena.Text.Trim();
            Clase.Id_Perfil = gridLookUpEdit1.EditValue.ToString();
            Clase.MtdInsertarUsuarios();
            if (Clase.Exito)
            {
               
                    CargarUsuarios();
                    XtraMessageBox.Show("Se ha Insertado el registro con exito");
                    LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarUsuarios()
        {
            CLS_Usuarios Clase = new CLS_Usuarios();
            Clase.Id_Usuario = textUsuario.Text.Trim();

            Clase.MtdEliminarUsuarios();
            if (Clase.Exito)
            {
                CargarUsuarios();
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
            textUsuario.Text = "";
            textNombre.Text = "";
            textContrasena.Text = "";
            textConfirmaContra.Text = "";
            gridLookUpEdit1.EditValue = null;
        }

        private void Frm_Usuarios_Load(object sender, EventArgs e)
        {
            
            CargarPerfiles();
            CargarUsuarios();
            
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textUsuario.Text = row["Id_Usuario"].ToString();
                    textNombre.Text = row["Nombre_Usuario"].ToString();
                    textContrasena.Text = row["Contrasena"].ToString();
                    gridLookUpEdit1.EditValue = row["Id_Perfil"].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textUsuario.Text!=String.Empty)
            {
                if (textContrasena.Text.Trim().Equals(textConfirmaContra.Text.Trim()))
                {
                    InsertarUsuarios();
                }
                else
                {
                    XtraMessageBox.Show("La contraseña no coincide con la ingresada");
                }
                
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un usuario.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textUsuario.Text!=String.Empty)
            {
                EliminarUsuarios();
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
    }
}