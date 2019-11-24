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
    public partial class Frm_Empleados : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }

        private static Frm_Empleados m_FormDefInstance;
        public static Frm_Empleados DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Empleados();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Empleados()
        {
            InitializeComponent();
        }

        private string DosCero(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }

        private void CargarEmpleados()
        {
            gridControl1.DataSource = null;
            CLS_Empleados Clase = new CLS_Empleados();

            if (checkActivo.Checked)
            {
                Clase.Activo = "0";
            }
            else
            {
                Clase.Activo = "1";
            }

            Clase.MtdSeleccionarEmpleados();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }
        private void CargarPuesto()
        {
           /* CLS_Perfiles Clase = new CLS_Perfiles();

            Clase.MtdSeleccionarPerfiles();
            if (Clase.Exito)
            {
                gridLookUpEdit1.Properties.DisplayMember = "Nombre_Perfil";
                gridLookUpEdit1.Properties.ValueMember = "Id_Perfil";
                gridLookUpEdit1.EditValue = null;
                gridLookUpEdit1.Properties.DataSource = Clase.Datos;
            }*/
        }
        private void InsertarEmpleados()
        {
            CLS_Empleados Clase = new CLS_Empleados();
            Clase.Id_Empleado = textId.Text.Trim();
            Clase.Nombre_Empleado = textEmpleado.Text.Trim();
            Clase.Fecha_Nacimiento = dateNacimiento.DateTime.Year.ToString() + DosCero(dateNacimiento.DateTime.Month.ToString()) + DosCero(dateNacimiento.DateTime.Day.ToString());
            Clase.NSS = textNSS.Text.Trim();
            Clase.Fecha_Alta_Seg_Social = dateAltaSegSocial.DateTime.Year.ToString() + DosCero(dateAltaSegSocial.DateTime.Month.ToString()) + DosCero(dateAltaSegSocial.DateTime.Day.ToString());
            Clase.Fecha_Baja_Seg_Social = dateBajaSegSocial.DateTime.Year.ToString() + DosCero(dateBajaSegSocial.DateTime.Month.ToString()) + DosCero(dateBajaSegSocial.DateTime.Day.ToString());
            Clase.Cuenta= textCuenta.Text.Trim();
            Clase.Tarjeta= textNoTarjeta.Text.Trim();
            Clase.Fecha_Alta_Seg_Vida= dateAltaSegVida.DateTime.Year.ToString() + DosCero(dateAltaSegVida.DateTime.Month.ToString()) + DosCero(dateAltaSegVida.DateTime.Day.ToString());
            Clase.Fecha_Baja_Seg_Vida= dateBajaSegVida.DateTime.Year.ToString() + DosCero(dateBajaSegVida.DateTime.Month.ToString()) + DosCero(dateBajaSegVida.DateTime.Day.ToString());
            Clase.Id_Puesto= glePuesto.EditValue.ToString();
            Clase.Id_Cuadrilla= gleCuadrilla.EditValue.ToString();
            Clase.Activo = "1";
            Clase.MtdInsertarEmpleados();
            if (Clase.Exito)
            {

                CargarEmpleados();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarEmpleados()
        {
            CLS_Empleados Clase = new CLS_Empleados();
            Clase.Id_Empleado = textId.Text.Trim();

            Clase.MtdEliminarEmpleados();
            if (Clase.Exito)
            {
                CargarEmpleados();
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
            textEmpleado.Text = "";
            textNoTarjeta.Text = "";
            textNSS.Text = "";
            textCuenta.Text = "";

            gleCuadrilla.EditValue = null;
            glePuesto.EditValue = null;
            labelActivo.Visible = false;
            inabilitar(true);
        }

        private void inabilitar(Boolean sino)
        {
            groupControl1.Enabled = sino;
            btnGuardar.Enabled = sino;
        }

        private void textIdProveedor_EditValueChanged(object sender, EventArgs e)
        {
            if (textId.Text == String.Empty)
            {
                xtraTabPage2.PageEnabled = false;
            }
            else
            {
                xtraTabPage2.PageEnabled = true;
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}