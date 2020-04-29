using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaDeDatos;
using DevExpress.XtraEditors;

namespace CuttingBusiness
{
    public partial class Frm_Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string UsuariosLogin { get; set; }
        public string IdPerfil { get; set; }

        List<string> Lista = new List<string>();

        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void CargarAccesos()
        {
            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Perfil = IdPerfil;
            Clase.MtdSeleccionarAccesosPermisos();
            if (Clase.Exito)
            {

                for (int x = 0; x < Clase.Datos.Rows.Count; x++)
                {
                    Lista.Add(Clase.Datos.Rows[x][0].ToString());
                }
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private Boolean TieneAcceso(String valor)
        {
            foreach (string x in Lista)
            {
                if (x == valor)
                {
                    return true;
                }

            }
            return false;
        }


        private void btnEmpleados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("001"))
            {
                Frm_Empleados vusuarios = new Frm_Empleados();
                Frm_Empleados.DefInstance.MdiParent = this;
                Frm_Empleados.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Empleados.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [001]");
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("026"))
            {
                Frm_Usuarios Ventana = new Frm_Usuarios();
                Frm_Usuarios.DefInstance.MdiParent = this;
                Frm_Usuarios.DefInstance.UsuariosLogin = UsuariosLogin;
                Frm_Usuarios.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [026]");
            }
        }

        private void btnUnidaddeMedida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("007"))
            {
                Frm_UnidadesMedida Ventana = new Frm_UnidadesMedida();
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [007]");
            }
        }

        private void btnClientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("003"))
            {
                Frm_Clientes Ventana = new Frm_Clientes();
                Frm_Clientes.DefInstance.MdiParent = this;
                Frm_Clientes.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [003]");
            }
        }

        private void btnProveedores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("002"))
            {
                Frm_Proveedores Ventana = new Frm_Proveedores();
                Frm_Proveedores.DefInstance.MdiParent = this;
                Frm_Proveedores.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [002]");
            }
        }

        private void btnPerfiles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("027"))
            {
                Frm_Perfiles Ventana = new Frm_Perfiles();
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [027]");
            }
        }

        private void btnPantallas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("030"))
            {
                Frm_Pantallas Ventana = new Frm_Pantallas();
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [030]");
            }
        }

        private void btnPermisos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("028"))
            {
                Frm_Permisos Ventana = new Frm_Permisos();
                Frm_Permisos.DefInstance.MdiParent = this;
                Frm_Permisos.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [028]");
            }
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            CargarAccesos();
        }

        private void btnCuadrilla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("004"))
            {
                Frm_Cuadrilla frm = new Frm_Cuadrilla();
                frm.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [004]");
            }
        }

        private void btnHerramientas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("005"))
            {
                Frm_Productos Ventana = new Frm_Productos();
                Frm_Productos.DefInstance.MdiParent = this;
                Frm_Productos.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [005]");
            }
        }

        private void btnInsumos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("006"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [006]");
            }
        }

        private void btnEntradas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("008"))
            {
                Frm_Entradas Ventana = new Frm_Entradas();
                Frm_Entradas.DefInstance.MdiParent = this;
                Frm_Entradas.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [008]");
            }
        }

        private void btnSalidas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("009"))
            {
                Frm_Salidas Ventana = new Frm_Salidas();
                Frm_Salidas.DefInstance.MdiParent = this;
                Frm_Salidas.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [009]");
            }
        }

        private void btnImportarODC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("010"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [010]");
            }
        }

        private void btnCobros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("011"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [011]");
            }
        }

        private void btnImportarRendimientoODC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("012"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [012]");
            }
        }

        private void btnCapturaODC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("013"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [013]");
            }
        }

        private void btnControlAlmacen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("015"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [015]");
            }
        }

        private void btnNomina_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("014"))
            {
                Frm_Nomina Ventana = new Frm_Nomina();
                if (TieneAcceso("001"))
                {
                    Ventana.accesoEmpleados = true;
                }
                else
                {
                    Ventana.accesoEmpleados = false;
                }
                Ventana.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [014]");
            }
        }

        private void btnFormatoODC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("016"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [016]");
            }
        }

        private void btnCatalogos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("017"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [017]");
            }
        }

        private void btnNominaporFecha_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("018"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [018]");
            }
        }

        private void btnAcumuladoNomina_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("019"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [019]");
            }
        }

        private void btnRendimientoODC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("020"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [020]");
            }
        }

        private void btnTrabajadores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("021"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [021]");
            }
        }

        private void btnSegurodeVida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("022"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [021]");
            }
        }

        private void btnSeguroSocial_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("023"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [023]");
            }
        }

        private void btnAlmacen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("024"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [024]");
            }
        }

        private void btnRtpCobros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("025"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [025]");
            }
        }

        private void btnRespaldoBD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("029"))
            {
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [029]");
            }
        }

        private void btnHuertas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("031"))
            {
                Frm_Huertas Ventana = new Frm_Huertas();
                Frm_Huertas.DefInstance.MdiParent = this;
                Frm_Huertas.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [029]");
            }
        }

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            MSRegistro RegIn = new MSRegistro();
            RegIn.SaveSetting("ConexionSQL", "Sking", SkinForm.LookAndFeel.SkinName);
        }

        private void Frm_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTiposEntradas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("032"))
            {
                Frm_TiposEntradas Ventana = new Frm_TiposEntradas();
                Ventana.PaSel = false;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [032]");
            }
        }

        private void btnTiposSalidas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("033"))
            {
                Frm_TiposSalidas Ventana = new Frm_TiposSalidas();
                Ventana.PaSel = false;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [033]");
            }
        }

        private void btnSeries_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("034"))
            {
                Frm_Series Ventana = new Frm_Series();
                Ventana.PaSel = false;
                Ventana.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [034]");
            }
        }

        private void btnPreODC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            Frm_PrecapturaODC Ventana = new Frm_PrecapturaODC();
            Frm_PrecapturaODC.DefInstance.MdiParent = this;
            Frm_PrecapturaODC.DefInstance.Show();
        }

        private void btnImportarServicios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TieneAcceso("010"))
            {
                Frm_ImportarODC Ventana = new Frm_ImportarODC();
                Frm_ImportarODC.DefInstance.MdiParent = this;
                Frm_ImportarODC.DefInstance.Show();
            }
            else
            {
                XtraMessageBox.Show("No Cuentas con acceso a esta Opcion [010]");
            }
        }
    }
}
