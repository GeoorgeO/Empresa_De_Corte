using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaDeDatos;

namespace CuttingBusiness
{
    public partial class Frm_Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string UsuariosLogin { get; set; }
        public string IdPerfil { get; set; }
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void ControlPermisos()
        {

            ocultaMenus();

            CLS_Perfiles_Pantallas Clase = new CLS_Perfiles_Pantallas();
            Clase.Id_Perfil = IdPerfil;
            Clase.MtdSeleccionarAccesosPermisos();
            if (Clase.Exito)
            {

                for(int x=0; x<Clase.Datos.Rows.Count; x++)
                {
                    switch (Clase.Datos.Rows[x][0].ToString().ToUpper())
                    {
                        case "EMPLEADOS":
                            btnEmpleados.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        case "PROVEEDORES":
                            btnProveedores.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        case "CLIENTES":
                            btnClientes.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        case "CUADRILLAS":
                            btnCuadrilla.Visibility= DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        case "HERRAMIENTAS":
                            btnHerramientas.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        case "INSUMOS":
                            btnInsumos.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        case "UNIDAD DE MEDIDA":
                            btnUnidaddeMedida.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        case "ENTRADAS":
                            btnEntradas.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                        case "SALIDAS":
                            btnSalidas.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            break;
                    }
                }
            }
        }

        private void ocultaMenus()
        {
            btnEmpleados.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnProveedores.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnClientes.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnCuadrilla.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnHerramientas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnInsumos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnUnidaddeMedida.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnEntradas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnSalidas.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void btnEmpleados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Empleados vusuarios = new Frm_Empleados();
            Frm_Empleados.DefInstance.MdiParent = this;
            Frm_Empleados.DefInstance.UsuariosLogin = UsuariosLogin;
            Frm_Empleados.DefInstance.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnUsuarios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Usuarios Ventana = new Frm_Usuarios();
            Frm_Usuarios.DefInstance.MdiParent = this;
            Frm_Usuarios.DefInstance.UsuariosLogin = UsuariosLogin;
            Frm_Usuarios.DefInstance.Show();
        }

        private void btnUnidaddeMedida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_UnidadesMedida Ventana = new Frm_UnidadesMedida();
            Ventana.ShowDialog();
        }

        private void btnClientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Clientes Ventana = new Frm_Clientes();
            Frm_Clientes.DefInstance.MdiParent = this;
            Frm_Clientes.DefInstance.Show();
        }

        private void btnProveedores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Proveedores Ventana = new Frm_Proveedores();
            Frm_Proveedores.DefInstance.MdiParent = this;
            Frm_Proveedores.DefInstance.Show();
        }

        private void btnPerfiles_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Perfiles Ventana = new Frm_Perfiles();
            Ventana.ShowDialog();
        }

        private void btnPantallas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Pantallas Ventana = new Frm_Pantallas();
            Ventana.ShowDialog();
        }

        private void btnPermisos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Permisos Ventana = new Frm_Permisos();
            Frm_Permisos.DefInstance.MdiParent = this;
            Frm_Permisos.DefInstance.Show();
        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {
            ControlPermisos();
        }
    }
}
