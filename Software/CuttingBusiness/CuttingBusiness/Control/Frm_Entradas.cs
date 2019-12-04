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
using DevExpress.XtraEditors.Mask;
using System.Globalization;

namespace CuttingBusiness
{
    public partial class Frm_Entradas : DevExpress.XtraEditors.XtraForm
    {
        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");
        public Frm_Entradas()
        {
            InitializeComponent();
        }

        
        public void CargarSeries(string Valor)
        {
            CLS_Series comboEstado = new CLS_Series();
            comboEstado.MtdSeleccionarSerie();
            if (comboEstado.Exito)
            {
                CargarComboSerie(comboEstado.Datos, Valor);
            }
        }
        private void CargarComboSerie(DataTable Datos, string Valor)
        {
            cboSerie.Properties.DisplayMember = "Nombre_Serie";
            cboSerie.Properties.ValueMember = "Id_Serie";
            cboSerie.EditValue = Valor;
            cboSerie.Properties.DataSource = Datos;
        }
        public void CargarTiposdeEntrada(string Valor)
        {
            CLS_TiposEntradas comboTipoEntrada = new CLS_TiposEntradas();
            comboTipoEntrada.MtdSeleccionarTiposEntradas();
            if (comboTipoEntrada.Exito)
            {
                CargarComboTiposEntrada(comboTipoEntrada.Datos, Valor);
            }
        }
        private void CargarComboTiposEntrada(DataTable Datos, string Valor)
        {
            cboTipoEntrada.Properties.DisplayMember = "Nombre_TipoEntrada";
            cboTipoEntrada.Properties.ValueMember = "Id_TipoEntrada";
            cboTipoEntrada.EditValue = Valor;
            cboTipoEntrada.Properties.DataSource = Datos;
        }
        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Frm_Proveedores frm = new Frm_Proveedores();
            frm.IdProveedor = string.Empty;
            frm.Proveedor = string.Empty;
            frm.PaSel = true;
            frm.ShowDialog();
            txtNombreProveedor.Tag = frm.IdProveedor;
            txtNombreProveedor.Text = frm.Proveedor;
        }

        private void Frm_Entradas_Shown(object sender, EventArgs e)
        {
            txtPrecio.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecio.Properties.Mask.EditMask = "$ ###,###0.00";
            txtPrecio.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtTotal.Properties.Mask.MaskType = MaskType.Numeric;
            txtTotal.Properties.Mask.EditMask = "$ ###,###0.00";
            txtTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            LimpiarCampos();
        }
        private void btnTipoEntrada_Click(object sender, EventArgs e)
        {
            Frm_TiposEntradas frm = new Frm_TiposEntradas();
            frm.PaSel = false;
            frm.ShowDialog();
            CargarTiposdeEntrada(null);
        }
        private void btnSeries_Click(object sender, EventArgs e)
        {
            Frm_Series frm = new Frm_Series();
            frm.PaSel = false;
            frm.ShowDialog();
            CargarSeries(null);
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            Frm_Productos frm = new Frm_Productos();
            frm.IdProducto = string.Empty;
            frm.Producto = string.Empty;
            frm.UnidadMedida = string.Empty;
            frm.PaSel = true;
            frm.ShowDialog();
            txtCodigo.Text = frm.IdProducto;
            txtDescripcion.Text = frm.Producto;
            txtUnidaddeMedida.Text = frm.UnidadMedida;
        }

        void LimpiarCampos()
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtUnidaddeMedida.Text = string.Empty;
            txtCantidad.Text = "0";
            txtPrecio.Text = "0";
            txtTotal.Text = "0";
            txtObservaciones.Text = string.Empty;
            CargarTiposdeEntrada(null);
            CargarSeries(null);
            dtFecha.DateTime = DateTime.Now;
        }
        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();

        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            decimal Precio = 0;
            decimal.TryParse(txtPrecio.Text, style, culture, out Precio);
            txtTotal.Text =Convert.ToString(Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(Precio));
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            decimal Precio = 0;
            decimal.TryParse(txtPrecio.Text, style, culture, out Precio);
            txtTotal.Text = Convert.ToString(Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(Precio));
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Serie_Entrada";
            column.AutoIncrement = false;
            column.Caption = "Serie";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Folio_Entrada";
            column.AutoIncrement = false;
            column.Caption = "Folio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Registro_EntradaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Registro";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id_Producto";
            column.AutoIncrement = false;
            column.Caption = "Id";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Nombre_Producto";
            column.AutoIncrement = false;
            column.Caption = "Nombre";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Nombre_UnidadMedida";
            column.AutoIncrement = false;
            column.Caption = "UMedida";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Int32);
            column.ColumnName = "Cantidad_EntradaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Precio_EntradaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Precio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Total_EntradaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Total";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Observaciones_EntradaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Observaciones";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgEntradas.DataSource = table;
        }
        private void CreatNewRowArticulo(string Numero, string ArticuloCodigo, string ArticuloDescripcion, string ArticuloCosto, string ArticuloCantidad, string ArticuloSub0, string ArticuloSub16,
                                    string ArticuloTotal, string ArticuloTotalLinea, string ArticuloCostoAdquisicion)
        {
            dtgValEntradas.AddNewRow();
            int rowHandle = dtgValEntradas.GetRowHandle(dtgValEntradas.DataRowCount);
            if (dtgValEntradas.IsNewItemRow(rowHandle))
            {
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Serie_Entrada"], Numero);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Folio_Entrada"], ArticuloCodigo);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Registro_EntradaDetalles"], ArticuloDescripcion);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Id_Producto"], ArticuloCosto);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Nombre_Producto"], ArticuloCantidad);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Nombre_UnidadMedida"], ArticuloSub0);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Cantidad_EntradaDetalles"], ArticuloSub16);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Precio_EntradaDetalles"], ArticuloTotal);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Total_EntradaDetalles"], ArticuloTotalLinea);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["ArticuloCostoAdquisicion"], ArticuloTotalLinea);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Observaciones_EntradaDetalles"], ArticuloCostoAdquisicion);
            }
        }
        private void NumerarReg()
        {
            for (int x = 0; x < dtgValEntradas.RowCount; x++)
            {
                int xRow = dtgValEntradas.GetVisibleRowHandle(x);
                dtgValEntradas.SetRowCellValue(xRow, dtgValEntradas.Columns["Registro_EntradaDetalles"], x + 1);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string vSerie_Entrada = "0";
            string vFolio_Entrada = "0";
            string vRegistro_EntradaDetalles = Convert.ToString(dtgValEntradas.RowCount + 1);
            string vId_Producto = txtCodigo.Text;
            string vNombre_Producto = txtDescripcion.Text;
            string vNombre_UnidadMedida = txtUnidaddeMedida.Text;
            string vCantidad_EntradaDetalles = txtCantidad.Text;
            string vPrecio_EntradaDetalles = txtPrecio.Text;
            string vTotal_EntradaDetalles = txtTotal.Text;
            string vObservaciones_EntradaDetalles = txtObservaciones.Text;
            CreatNewRowArticulo(vNumero, vArticuloCodigo, vArticuloDescripcion, vArticuloCosto, vCantidad, vSub0, vSub16, vTotal, vTotalLinea, vCostoAdquisicion);
            NumerarReg();
        }
    }
}