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

        private void FormatoDeColumnas()
        {
            gPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gPrecio.DisplayFormat.FormatString = "$ ###,###0.00";
            gTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gTotal.DisplayFormat.FormatString = "$ ###,###0.00";
        }
        private void Frm_Entradas_Shown(object sender, EventArgs e)
        {
            FormatoDeCampos();
            FormatoDeColumnas();
            LimpiarCampos();
            MakeTablaPedidos();
        }

        private void FormatoDeCampos()
        {
            txtPrecio.Properties.Mask.MaskType = MaskType.Numeric;
            txtPrecio.Properties.Mask.EditMask = "$ ###,###0.00";
            txtPrecio.Properties.Mask.UseMaskAsDisplayFormat = true;
            txtTotal.Properties.Mask.MaskType = MaskType.Numeric;
            txtTotal.Properties.Mask.EditMask = "$ ###,###0.00";
            txtTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
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
            if(txtCodigo.Text!=string.Empty&& txtDescripcion.Text!=string.Empty&& txtUnidaddeMedida.Text!=string.Empty)
            {
                txtCantidad.Focus();
            }
            else
            {
                txtCodigo.Focus();
            }
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
            progressBarControl1.Position = 0;
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
            column.DataType = typeof(string);
            column.ColumnName = "Observaciones_EntradaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Observaciones";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "AplicadoInventario";
            column.AutoIncrement = false;
            column.Caption = "Guardado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "AplicadoInventario";
            column.AutoIncrement = false;
            column.Caption = "Aplicado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgEntradas.DataSource = table;
        }
        private void CreatNewRowArticulo(string vSerie_Entrada, string vFolio_Entrada, string vRegistro_EntradaDetalles, string vId_Producto, string vNombre_Producto, string vNombre_UnidadMedida, string vCantidad_EntradaDetalles, string vPrecio_EntradaDetalles, string vTotal_EntradaDetalles, string vObservaciones_EntradaDetalles)
        {
            dtgValEntradas.AddNewRow();
            int rowHandle = dtgValEntradas.GetRowHandle(dtgValEntradas.DataRowCount);
            if (dtgValEntradas.IsNewItemRow(rowHandle))
            {
                decimal Precio = 0;
                decimal Total = 0;
                decimal.TryParse(txtPrecio.Text, style, culture, out Precio);
                decimal.TryParse(txtTotal.Text, style, culture, out Total);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Serie_Entrada"], vSerie_Entrada);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Folio_Entrada"], vFolio_Entrada);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Registro_EntradaDetalles"], vRegistro_EntradaDetalles);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Id_Producto"], vId_Producto);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Nombre_Producto"], vNombre_Producto);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Nombre_UnidadMedida"], vNombre_UnidadMedida);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Cantidad_EntradaDetalles"], vCantidad_EntradaDetalles);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Precio_EntradaDetalles"], Precio);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Total_EntradaDetalles"], Total);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["Observaciones_EntradaDetalles"], vObservaciones_EntradaDetalles);
                dtgValEntradas.SetRowCellValue(rowHandle, dtgValEntradas.Columns["AplicadoInventario"], 0);
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

        private bool ValidarCampos()
        {
            if(txtCodigo.Text!=string.Empty && txtDescripcion.Text!=string.Empty && txtUnidaddeMedida.Text!=string.Empty)
            {
                if(Convert.ToInt32(txtCantidad.Text)>0)
                {
                    decimal Precio = 0;
                    if(decimal.TryParse(txtPrecio.Text,style,culture,out Precio))
                    {
                        if(Precio>0)
                        {
                            return true;
                        }
                        else
                        {
                            XtraMessageBox.Show("el precio debe ser mayor a 0");
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    XtraMessageBox.Show("la cantidad debe ser mayor a 0");
                    return false;
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan datos del producto");
                return false;
            }
        }
        private void LimpiarDetalles()
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtUnidaddeMedida.Text = string.Empty;
            txtCantidad.Text = "0";
            txtPrecio.Text = "0";
            txtTotal.Text = "0";
            txtObservaciones.Text = string.Empty;
            txtCodigo.Focus();
        }
        private bool ExisteCodigo()
        {
            Boolean Valor = false;
            for (int x = 0; x < dtgValEntradas.RowCount; x++)
            {
                int xRow = dtgValEntradas.GetVisibleRowHandle(x);
                string ArticuloCodigo = dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString();
                if (txtCodigo.Text.TrimEnd() == ArticuloCodigo.TrimEnd())
                {
                    string ArticuloCantidad = dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Cantidad_EntradaDetalles"]).ToString();
                    int vCantidad = Convert.ToInt32(ArticuloCantidad) + Convert.ToInt32(txtCantidad.Text);
                    dtgValEntradas.SetRowCellValue(xRow, dtgValEntradas.Columns["Cantidad_EntradaDetalles"], vCantidad);

                    decimal Precio = 0;
                    decimal Total = 0;
                    decimal.TryParse(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Precio_EntradaDetalles"]).ToString(), style, culture, out Precio);
                    Total = vCantidad * Precio;
                    dtgValEntradas.SetRowCellValue(xRow, dtgValEntradas.Columns["Total_EntradaDetalles"], Total);
                    Valor = true;
                    LimpiarDetalles();
                    dtgValEntradas.Focus();
                    dtgValEntradas.UpdateTotalSummary();
                    dtgValEntradas.UpdateSummary();
                    dtgValEntradas.UpdateGroupSummary();
                    txtCodigo.Focus();
                }
            }
            return Valor;
        }
       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (!ExisteCodigo())
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
                    CreatNewRowArticulo(vSerie_Entrada, vFolio_Entrada, vRegistro_EntradaDetalles, vId_Producto, vNombre_Producto, vNombre_UnidadMedida, vCantidad_EntradaDetalles, vPrecio_EntradaDetalles, vTotal_EntradaDetalles, vObservaciones_EntradaDetalles);
                   
                    dtgValEntradas.Focus();
                    dtgValEntradas.UpdateTotalSummary();
                    dtgValEntradas.UpdateSummary();
                    dtgValEntradas.UpdateGroupSummary();
                    txtCodigo.Focus();
                    LimpiarDetalles();
                }
                NumerarReg();
            }
        }
        private void dtgEntradas_DoubleClick(object sender, EventArgs e)
        {
            if (dtgValEntradas.RowCount > 0)
            {
                try
                {
                    DialogResult = XtraMessageBox.Show("¿Desea Eliminar este articulo de la Entrada?", "Elimnar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    if (DialogResult == DialogResult.Yes)
                    {
                        dtgValEntradas.DeleteRow(dtgValEntradas.FocusedRowHandle);
                        NumerarReg();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCodigo.Text == string.Empty && e.KeyValue == 13)
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
                if (txtCodigo.Text != string.Empty && txtDescripcion.Text != string.Empty && txtUnidaddeMedida.Text != string.Empty)
                {
                    txtCantidad.Focus();
                }
                else
                {
                    txtCodigo.Focus();
                }
            }
            else if (txtCodigo.Text != string.Empty && e.KeyValue == 13)
            {
                BuscarCodigo();
            }
        }
        private Boolean BuscarCodigo()
        {
            Boolean Valor = false;
            CLS_Productos sel = new CLS_Productos();
            sel.Id_Producto = txtCodigo.Text;
            sel.Activo = "1";
            sel.MtdSeleccionarProductosId();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    txtCodigo.Text = sel.Datos.Rows[0]["Id_Producto"].ToString().TrimEnd();
                    txtDescripcion.Text = sel.Datos.Rows[0]["Nombre_Producto"].ToString().TrimEnd();
                    txtUnidaddeMedida.Text = sel.Datos.Rows[0]["Nombre_UnidadMedida"].ToString().TrimEnd();
                    Valor = true;
                    txtCantidad.Focus();
                }
                else
                {
                    XtraMessageBox.Show("El producto a buscar no existe o se encuentra inactivo");
                }
            }
            else
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
            return Valor;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.I))
            {
                btnAgregar.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(ValidaEncabezado())
            {
                if(ValidaDetalles())
                {
                    if (txtFolio.Text.Trim().Length > 0)
                    {
                        Guardadosecundario();
                        Afectacionsecundario();
                    }else
                    {
                        GuardarEntrada();
                    }
                   
                }
                else
                {
                    XtraMessageBox.Show("No existe articulos a ingresar en la entrada");
                }
            }
            else
            {
                XtraMessageBox.Show("Faltan datos en el encabezado de la entrada");
            }
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

        private void Guardadosecundario()
        {
            progressBarControl1.Properties.Maximum = dtgValEntradas.RowCount;

            lblStatus.Text = "Guardando Entradas faltantes";
            for (int x = 0; x < dtgValEntradas.RowCount; x++)
            {
                Application.DoEvents();
                int xRow = dtgValEntradas.GetVisibleRowHandle(x);
                if (dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Guardados"]).ToString().Equals("False"))
                {
                    if (GuardarEntradaDetalle(
                   cboSerie.EditValue.ToString().Trim(),
                   txtFolio.Text,
                   Convert.ToInt32(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Registro_EntradaDetalles"])),
                   dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString(),
                   dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Nombre_Producto"]).ToString(),
                   dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Nombre_UnidadMedida"]).ToString(),
                   Convert.ToInt32(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Cantidad_EntradaDetalles"])),
                   Convert.ToDecimal(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Precio_EntradaDetalles"])),
                    Convert.ToDecimal(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Total_EntradaDetalles"])),
                   dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Observaciones_EntradaDetalles"]).ToString()
                   ))
                    {
                        
                        dtgValEntradas.SetRowCellValue(xRow, dtgValEntradas.Columns["Guardados"], true);
                    }
                    else
                    {
                        lblStatus.Text = "Problema al intentar guardar el producto: " + dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString();
                       
                    }
                }
                progressBarControl1.Position = x + 1;

            }
        }

        private void Afectacionsecundario()
        {
            progressBarControl1.Position = 0;
            progressBarControl1.Properties.Maximum = dtgValEntradas.RowCount;
            lblStatus.Text = "Afectando Inventario";
            for (int x = 0; x < dtgValEntradas.RowCount; x++)
            {
                Application.DoEvents();
                int xRow = dtgValEntradas.GetVisibleRowHandle(x);
                if (dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["AplicadoInventario"]).ToString().Equals("False"))
                {
                    if (AfectarEntradaDetalle(
                    cboSerie.EditValue.ToString().Trim(),
                    txtFolio.Text,
                    dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString(),
                    Convert.ToInt32(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Cantidad_EntradaDetalles"]))
                    ))
                    {
                        
                        dtgValEntradas.SetRowCellValue(xRow, dtgValEntradas.Columns["AplicadoInventario"], true);
                    }
                    else
                    {
                        lblStatus.Text = "Problema al afectar inventario en el producto: " + dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString() + " . Intente realizar el proceso de forma manual";
                      
                    }
                }
                progressBarControl1.Position = x + 1;
            }
            
        }


        private Boolean GuardarEntrada()
        {
            CLS_Entradas Clase = new CLS_Entradas();
            Clase.Folio_Entrada = txtFolio.Text.Trim();
            Clase.Serie_Entrada = cboSerie.EditValue.ToString().Trim();
            Clase.Id_Proveedor = txtNombreProveedor.Tag.ToString().Trim();
            Clase.Id_TipoEntrada = cboTipoEntrada.EditValue.ToString().Trim();
            DateTime Fecha = Convert.ToDateTime(dtFecha.Text.Trim());
            Clase.Fecha_Entrada = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            Clase.Numero_ArticulosEntrada = SumarCantidadArticulos();
            Clase.MtdInsertarEntradaEncabezado();
            if (Clase.Exito)
            {
                progressBarControl1.Properties.Maximum = dtgValEntradas.RowCount;
                txtFolio.Text = Clase.Datos.Rows[0][0].ToString();
                lblStatus.Text = "Guardando Entrada";
                for (int x = 0; x < dtgValEntradas.RowCount; x++)
                {
                    Application.DoEvents();
                    int xRow = dtgValEntradas.GetVisibleRowHandle(x);
                    if (GuardarEntradaDetalle(
                        cboSerie.EditValue.ToString().Trim(),
                        txtFolio.Text,
                        Convert.ToInt32(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Registro_EntradaDetalles"])),
                        dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString(),
                        dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Nombre_Producto"]).ToString(),
                        dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Nombre_UnidadMedida"]).ToString(),
                        Convert.ToInt32(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Cantidad_EntradaDetalles"])),
                        Convert.ToDecimal(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Precio_EntradaDetalles"])),
                         Convert.ToDecimal(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Total_EntradaDetalles"])),
                        dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Observaciones_EntradaDetalles"]).ToString()
                        ))
                    {
                        progressBarControl1.Position = x + 1;
                    }
                    else
                    {
                        lblStatus.Text = "Problema al intentar guardar el producto: "+ dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString();
                        return false;

                    }
                    
                }

                progressBarControl1.Position = 0;
                progressBarControl1.Properties.Maximum = dtgValEntradas.RowCount;
                lblStatus.Text = "Afectando Inventario";
                for (int x = 0; x < dtgValEntradas.RowCount; x++)
                {
                    Application.DoEvents();
                    int xRow = dtgValEntradas.GetVisibleRowHandle(x);
                    if (AfectarEntradaDetalle(
                        cboSerie.EditValue.ToString().Trim(),
                        txtFolio.Text,
                        dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString(),
                        Convert.ToInt32(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Cantidad_EntradaDetalles"]))
                        ))
                    {
                        progressBarControl1.Position = x + 1;
                        dtgValEntradas.SetRowCellValue(xRow, dtgValEntradas.Columns["AplicadoInventario"], true);
                    }
                    else
                    {
                        lblStatus.Text = "Problema al afectar inventario en el producto: " + dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Id_Producto"]).ToString()+" . Intente realizar el proceso de forma manual";
                        return false;
                    }
                    
                }


                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
                return true;
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
                return false;
            }
        }

        private Boolean AfectarEntradaDetalle(string Serie_Entrada, string Folio_Entrada, string Id_Producto, int Cantidad_EntradaDetalles)
        {
            CLS_Entradas Clase = new CLS_Entradas();
            Clase.Serie_Entrada = Serie_Entrada;
            Clase.Folio_Entrada = Folio_Entrada;
            Clase.Id_Producto = Id_Producto;
            Clase.Cantidad_EntradaDetalles = Cantidad_EntradaDetalles;
            Clase.MtdAfectarInventario();
            if (Clase.Exito)
            {
                return true;
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
                return false;
            }
        }

        private int SumarCantidadArticulos()
        {
            int Total;
            Total = 0;
            for(int x=0; x<dtgValEntradas.RowCount; x++)
            {
                int xRow = dtgValEntradas.GetVisibleRowHandle(x);
                Total = Total + Convert.ToInt32(dtgValEntradas.GetRowCellValue(xRow, dtgValEntradas.Columns["Cantidad_EntradaDetalles"]).ToString());
            }

            return Total;
        }

        private Boolean GuardarEntradaDetalle(string Serie_Entrada,string Folio_Entrada,int Registro_EntradaDetalles, string Id_Producto,string Nombre_Producto,string Nombre_UnidadMedida, int Cantidad_EntradaDetalles,decimal Precio_EntradaDetalles, decimal Total_EntradaDetalles,string Observaciones_EntradaDetalles)
        {
            CLS_Entradas Clase = new CLS_Entradas();
            Clase.Serie_Entrada = Serie_Entrada;
            Clase.Folio_Entrada = Folio_Entrada;
            Clase.Registro_EntradaDetalles = Registro_EntradaDetalles;
            Clase.Id_Producto = Id_Producto;
            Clase.Nombre_Producto = Nombre_Producto;
            Clase.Nombre_UnidadMedida = Nombre_UnidadMedida;
            Clase.Cantidad_EntradaDetalles = Cantidad_EntradaDetalles;
            Clase.Precio_EntradaDetalles = Precio_EntradaDetalles;
            Clase.Total_EntradaDetalles = Total_EntradaDetalles;
            Clase.Observaciones_EntradaDetalles = Observaciones_EntradaDetalles;
            Clase.MtdInsertarEntradaDetalles();
            if (Clase.Exito)
            {
                return true;
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
                return false;
            }
        }

        private bool ValidaEncabezado()
        {
            Boolean Valor = false;
            if(txtNombreProveedor.Text!=string.Empty)
            {
                if(cboTipoEntrada.EditValue!=null)
                {
                    if(cboSerie.EditValue!=null)
                    {
                        Valor = true;
                    }
                    else
                    {
                        Valor = false;
                    }
                }
                else
                {
                    Valor = false;
                }
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }
        private bool ValidaDetalles()
        {
            Boolean Valor = false;
            if(dtgValEntradas.RowCount>0)
            {
                Valor = true;
            }
            return Valor;
        }

        private void btnBuscarFolio_Click(object sender, EventArgs e)
        {

        }
    }
}