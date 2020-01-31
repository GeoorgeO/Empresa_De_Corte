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
    public partial class Frm_BusqEntradas : DevExpress.XtraEditors.XtraForm
    {
        public Frm_BusqEntradas()
        {
            InitializeComponent();
        }

        public string IdEntrada { get; set; }
        public string IdSerie { get; set; }
        public string IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string IdTipoEntrada { get; set; }
        public string NombreTipoEntrada { get; set; }
        public string FechaEntrada { get; set; }
        public string NumeroArticulosEntrada { get; set; }
        public string Factura { get; set; }
        public string OrdenCompra { get; set; }
        public string IdEmpleado { get; set; }
        public string Empleado { get; set; }

        private void CargarEntradas()
        {
            gridControl1.DataSource = null;
            CLS_Entradas Clase = new CLS_Entradas();

            Clase.MtdSeleccionarEntradaEncabezado();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void Frm_BusqEntradas_Load(object sender, EventArgs e)
        {
            CargarEntradas();
            if (dtgValRutas.RowCount > 0)
            {
                DataRow row = this.dtgValRutas.GetDataRow(0);
                IdEntrada = row["Folio_Entrada"].ToString();
                IdSerie = row["Serie_Entrada"].ToString();
                IdProveedor =row["Id_Proveedor"].ToString();
                NombreProveedor = row["Nombre_Proveedor"].ToString();
                IdTipoEntrada= row["Id_TipoEntrada"].ToString();
                NombreTipoEntrada= row["Nombre_TipoEntrada"].ToString();
                FechaEntrada= row["Fecha_Entrada"].ToString();
                NumeroArticulosEntrada= row["Numero_ArticulosEntrada"].ToString();
                Factura = row["FacturaPDFNombre"].ToString();
                OrdenCompra = row["Orden_Compra"].ToString();
                IdEmpleado = row["Id_Empleado"].ToString();
                Empleado = row["Nombre_Empleado"].ToString();
            }
            else
            {
                IdEntrada = "";
                IdSerie = "";
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValRutas.GetSelectedRows())
                {
                    DataRow row = this.dtgValRutas.GetDataRow(i);
                    IdEntrada = row["Folio_Entrada"].ToString();
                    IdSerie = row["Serie_Entrada"].ToString();
                    IdProveedor = row["Id_Proveedor"].ToString();
                    NombreProveedor = row["Nombre_Proveedor"].ToString();
                    IdTipoEntrada = row["Id_TipoEntrada"].ToString();
                    NombreTipoEntrada = row["Nombre_TipoEntrada"].ToString();
                    FechaEntrada = row["Fecha_Entrada"].ToString();
                    NumeroArticulosEntrada = row["Numero_ArticulosEntrada"].ToString();
                    Factura = row["FacturaPDFNombre"].ToString();
                    OrdenCompra = row["Orden_Compra"].ToString();
                    IdEmpleado = row["Id_Empleado"].ToString();
                    Empleado = row["Nombre_Empleado"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IdSerie != null)
            {
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("No se selecciono ningun dato.");
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdSerie = "";
            IdEntrada = "";
            this.Close();
        }
    }
}