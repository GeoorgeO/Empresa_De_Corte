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
using System.Net;

namespace CuttingBusiness
{
    public partial class Frm_Salidas : DevExpress.XtraEditors.XtraForm
    {

        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");

        public Frm_Salidas()
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
        public void CargarTiposdeSalida(string Valor)
        {
            CLS_TiposSalidas comboTipoSalida = new CLS_TiposSalidas();
            comboTipoSalida.MtdSeleccionarTiposSalidas();
            if (comboTipoSalida.Exito)
            {
                CargarComboTiposSalida(comboTipoSalida.Datos, Valor);
            }
        }
        private void CargarComboTiposSalida(DataTable Datos, string Valor)
        {
            cboTipoSalida.Properties.DisplayMember = "Nombre_TipoSalida";
            cboTipoSalida.Properties.ValueMember = "Id_TipoSalida";
            cboTipoSalida.EditValue = Valor;
            cboTipoSalida.Properties.DataSource = Datos;
        }

        private void FormatoDeColumnas()
        {
            gPrecio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gPrecio.DisplayFormat.FormatString = "$ ###,###0.00";
            gTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gTotal.DisplayFormat.FormatString = "$ ###,###0.00";
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

        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Serie_Salida";
            column.AutoIncrement = false;
            column.Caption = "Serie";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Folio_Salida";
            column.AutoIncrement = false;
            column.Caption = "Folio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Registro_SalidaDetalles";
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
            column.ColumnName = "Cantidad_SalidaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Cantidad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Precio_SalidaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Precio";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Total_SalidaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Total";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Observaciones_SalidaDetalles";
            column.AutoIncrement = false;
            column.Caption = "Observaciones";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(Boolean);
            column.ColumnName = "Guardado";
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

            gridSalidas.DataSource = table;
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
            CargarTiposdeSalida(null);
            CargarSeries(null);
            dateFecha.DateTime = DateTime.Now;
            progressBarControl1.Position = 0;
            txtFolio.Text = "";
            textJefeCuadrilla.Tag = "";
            textJefeCuadrilla.Text = "";
            gridSalidas.DataSource = null;
            bloquearSalida(true);
            deleteReserva();
        }

        private void CreatNewRowArticulo(string vSerie_Entrada, string vFolio_Entrada, string vRegistro_EntradaDetalles, string vId_Producto, string vNombre_Producto, string vNombre_UnidadMedida, string vCantidad_EntradaDetalles, string vPrecio_EntradaDetalles, string vTotal_EntradaDetalles, string vObservaciones_EntradaDetalles)
        {
            gridViewSalidas.AddNewRow();
            int rowHandle = gridViewSalidas.GetRowHandle(gridViewSalidas.DataRowCount);
            if (gridViewSalidas.IsNewItemRow(rowHandle))
            {
                decimal Precio = 0;
                decimal Total = 0;
                decimal.TryParse(txtPrecio.Text, style, culture, out Precio);
                decimal.TryParse(txtTotal.Text, style, culture, out Total);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Serie_Salida"], vSerie_Entrada);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Folio_Salida"], vFolio_Entrada);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Registro_SalidaDetalles"], vRegistro_EntradaDetalles);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Id_Producto"], vId_Producto);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Nombre_Producto"], vNombre_Producto);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Nombre_UnidadMedida"], vNombre_UnidadMedida);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Cantidad_SalidaDetalles"], vCantidad_EntradaDetalles);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Precio_SalidaDetalles"], Precio);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Total_SalidaDetalles"], Total);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Observaciones_SalidaDetalles"], vObservaciones_EntradaDetalles);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["Guardado"], 0);
                gridViewSalidas.SetRowCellValue(rowHandle, gridViewSalidas.Columns["AplicadoInventario"], 0);
            }
            InsertReserva();
        }

        private void CargarSalidasDetalles()
        {
            gridSalidas.DataSource = null;
            CLS_Salidas Clase = new CLS_Salidas();
            Clase.Folio_Salida = txtFolio.Text;
            Clase.Serie_Salida = cboSerie.EditValue.ToString();
            Clase.MtdSeleccionarSalidasDetalles();
            if (Clase.Exito)
            {
                gridSalidas.DataSource = Clase.Datos;
            }
        }

        private void NumerarReg()
        {
            for (int x = 0; x < gridViewSalidas.RowCount; x++)
            {
                int xRow = gridViewSalidas.GetVisibleRowHandle(x);
                gridViewSalidas.SetRowCellValue(xRow, gridViewSalidas.Columns["Registro_SalidaDetalles"], x + 1);
            }
        }

        private bool ValidarCampos()
        {
            if (txtCodigo.Text != string.Empty && txtDescripcion.Text != string.Empty && txtUnidaddeMedida.Text != string.Empty)
            {
                if (Convert.ToInt32(txtCantidad.Text) > 0)
                {
                    decimal Precio = 0;
                    if (decimal.TryParse(txtPrecio.Text, style, culture, out Precio))
                    {
                        if (SelectReserva(txtCodigo.Text)>=Convert.ToInt32(txtCantidad.Text))
                        {
                            return true;
                        }else
                        {
                            XtraMessageBox.Show("No existe la cantidad necesaria en almacen, Solo se encuentran " + SelectReserva(txtCodigo.Text.Trim()).ToString() + " en stock");
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
            for (int x = 0; x < gridViewSalidas.RowCount; x++)
            {
                int xRow = gridViewSalidas.GetVisibleRowHandle(x);
                string ArticuloCodigo = gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString();
                if (txtCodigo.Text.TrimEnd() == ArticuloCodigo.TrimEnd())
                {
                    string ArticuloCantidad = gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Cantidad_SalidaDetalles"]).ToString();
                    int vCantidad = Convert.ToInt32(ArticuloCantidad) + Convert.ToInt32(txtCantidad.Text);
                    gridViewSalidas.SetRowCellValue(xRow, gridViewSalidas.Columns["Cantidad_SalidaDetalles"], vCantidad);

                    decimal Precio = 0;
                    decimal Total = 0;
                    decimal.TryParse(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Precio_SalidaDetalles"]).ToString(), style, culture, out Precio);
                    Total = vCantidad * Precio;

                    InsertReserva();

                    gridViewSalidas.SetRowCellValue(xRow, gridViewSalidas.Columns["Total_SalidaDetalles"], Total);
                    Valor = true;
                    LimpiarDetalles();
                    gridViewSalidas.Focus();
                    gridViewSalidas.UpdateTotalSummary();
                    gridViewSalidas.UpdateSummary();
                    gridViewSalidas.UpdateGroupSummary();
                    txtCodigo.Focus();
                }
            }
            return Valor;
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
            progressBarControl1.Properties.Maximum = gridViewSalidas.RowCount;

            lblStatus.Text = "Guardando Salidas faltantes";
            for (int x = 0; x < gridViewSalidas.RowCount; x++)
            {
                Application.DoEvents();
                int xRow = gridViewSalidas.GetVisibleRowHandle(x);
                if (gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Guardado"]).ToString().Equals("False"))
                {
                    if (GuardarSalidaDetalle(
                   cboSerie.EditValue.ToString().Trim(),
                   txtFolio.Text,
                   Convert.ToInt32(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Registro_SalidaDetalles"])),
                   gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString(),
                   gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Nombre_Producto"]).ToString(),
                   gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Nombre_UnidadMedida"]).ToString(),
                   Convert.ToInt32(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Cantidad_SalidaDetalles"])),
                   Convert.ToDecimal(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Precio_SalidaDetalles"])),
                    Convert.ToDecimal(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Total_SalidaDetalles"])),
                   gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Observaciones_SalidaDetalles"]).ToString()
                   ))
                    {

                        gridViewSalidas.SetRowCellValue(xRow, gridViewSalidas.Columns["Guardado"], true);
                    }
                    else
                    {
                        lblStatus.Text = "Problema al intentar guardar el producto: " + gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString();

                    }
                }
                progressBarControl1.Position = x + 1;

            }
        }

        private void Afectacionsecundario()
        {
            progressBarControl1.Position = 0;
            progressBarControl1.Properties.Maximum = gridViewSalidas.RowCount;
            lblStatus.Text = "Afectando Inventario";
            for (int x = 0; x < gridViewSalidas.RowCount; x++)
            {
                Application.DoEvents();
                int xRow = gridViewSalidas.GetVisibleRowHandle(x);
                if (gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Guardado"]).ToString().Equals("True") && gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["AplicadoInventario"]).ToString().Equals("False"))
                {
                    if (AfectarSalidaDetalle(
                    cboSerie.EditValue.ToString().Trim(),
                    txtFolio.Text,
                    gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString(),
                    Convert.ToInt32(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Cantidad_SalidaDetalles"]))
                    ))
                    {

                        gridViewSalidas.SetRowCellValue(xRow, gridViewSalidas.Columns["AplicadoInventario"], true);
                    }
                    else
                    {
                        lblStatus.Text = "Problema al afectar inventario en el producto: " + gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString() + " . Intente realizar el proceso de forma manual";

                    }
                }
                progressBarControl1.Position = x + 1;
            }

        }


        private Boolean GuardarSalida()
        {
            CLS_Salidas Clase = new CLS_Salidas();
            Clase.Folio_Salida = txtFolio.Text.Trim();
            Clase.Serie_Salida = cboSerie.EditValue.ToString().Trim();
            Clase.Id_JefeCuadrilla = textJefeCuadrilla.Tag.ToString().Trim();
            Clase.Id_TipoSalida = cboTipoSalida.EditValue.ToString().Trim();
            DateTime Fecha = Convert.ToDateTime(dateFecha.Text.Trim());
            Clase.Fecha_Salida = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            Clase.Numero_Articulossalida = SumarCantidadArticulos();
            Clase.MtdInsertarSalidasEncabezado();
            if (Clase.Exito)
            {
                bloquearSalidaError(false);
                progressBarControl1.Properties.Maximum = gridViewSalidas.RowCount;
                txtFolio.Text = Clase.Datos.Rows[0][0].ToString();
                lblStatus.Text = "Guardando Salida";
                for (int x = 0; x < gridViewSalidas.RowCount; x++)
                {
                    Application.DoEvents();
                    int xRow = gridViewSalidas.GetVisibleRowHandle(x);
                    if (GuardarSalidaDetalle(
                        cboSerie.EditValue.ToString().Trim(),
                        txtFolio.Text,
                        Convert.ToInt32(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Registro_SalidaDetalles"])),
                        gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString(),
                        gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Nombre_Producto"]).ToString(),
                        gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Nombre_UnidadMedida"]).ToString(),
                        Convert.ToInt32(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Cantidad_SalidaDetalles"])),
                        Convert.ToDecimal(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Precio_SalidaDetalles"])),
                         Convert.ToDecimal(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Total_SalidaDetalles"])),
                        gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Observaciones_SalidaDetalles"]).ToString()
                        ))
                    {
                        progressBarControl1.Position = x + 1;
                        gridViewSalidas.SetRowCellValue(xRow, gridViewSalidas.Columns["Guardado"], true);
                    }
                    else
                    {
                        lblStatus.Text = "Problema al intentar guardar el producto: " + gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString();
                        return false;

                    }

                }

                progressBarControl1.Position = 0;
                progressBarControl1.Properties.Maximum = gridViewSalidas.RowCount;
                lblStatus.Text = "Afectando Inventario";
                for (int x = 0; x < gridViewSalidas.RowCount; x++)
                {
                    Application.DoEvents();
                    int xRow = gridViewSalidas.GetVisibleRowHandle(x);
                    if (AfectarSalidaDetalle(
                        cboSerie.EditValue.ToString().Trim(),
                        txtFolio.Text,
                        gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString(),
                        Convert.ToInt32(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Cantidad_SalidaDetalles"]))
                        ))
                    {
                        progressBarControl1.Position = x + 1;
                        gridViewSalidas.SetRowCellValue(xRow, gridViewSalidas.Columns["AplicadoInventario"], true);
                    }
                    else
                    {
                        lblStatus.Text = "Problema al afectar inventario en el producto: " + gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Id_Producto"]).ToString() + " . Intente realizar el proceso de forma manual";
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

        private Boolean AfectarSalidaDetalle(string Serie_Salida, string Folio_Salida, string Id_Producto, int Cantidad_SalidaDetalles)
        {
            CLS_Salidas Clase = new CLS_Salidas();
            Clase.Serie_Salida = Serie_Salida;
            Clase.Folio_Salida = Folio_Salida;
            Clase.Id_Producto = Id_Producto;
            Clase.Cantidad_SalidaDetalles = Cantidad_SalidaDetalles;
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
            for (int x = 0; x < gridViewSalidas.RowCount; x++)
            {
                int xRow = gridViewSalidas.GetVisibleRowHandle(x);
                Total = Total + Convert.ToInt32(gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["Cantidad_SalidaDetalles"]).ToString());
            }

            return Total;
        }

        private Boolean GuardarSalidaDetalle(string Serie_Salida, string Folio_Salida, int Registro_SalidaDetalles, string Id_Producto, string Nombre_Producto, string Nombre_UnidadMedida, int Cantidad_SalidaDetalles, decimal Precio_SalidaDetalles, decimal Total_SalidaDetalles, string Observaciones_SalidaDetalles)
        {
            CLS_Salidas Clase = new CLS_Salidas();
            Clase.Serie_Salida = Serie_Salida;
            Clase.Folio_Salida = Folio_Salida;
            Clase.Registro_SalidaDetalles = Registro_SalidaDetalles;
            Clase.Id_Producto = Id_Producto;
            Clase.Nombre_Producto = Nombre_Producto;
            Clase.Nombre_UnidadMedida = Nombre_UnidadMedida;
            Clase.Cantidad_SalidaDetalles = Cantidad_SalidaDetalles;
            Clase.Precio_SalidaDetalles = Precio_SalidaDetalles;
            Clase.Total_SalidaDetalles = Total_SalidaDetalles;
            Clase.Observaciones_SalidaDetalles = Observaciones_SalidaDetalles;
            Clase.MtdInsertarSalidasDetalles();
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
            if (textJefeCuadrilla.Text != string.Empty)
            {
                if (cboTipoSalida.EditValue != null)
                {
                    if (cboSerie.EditValue != null)
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
            if (gridViewSalidas.RowCount > 0)
            {
                Valor = true;
            }
            return Valor;
        }

        private void bloquearSalida(Boolean sino)
        {
            groupControl1.Enabled = sino;
            dateFecha.Enabled = sino;
            txtFolio.Enabled = sino;
            textJefeCuadrilla.Enabled = sino;
            cboSerie.Enabled = sino;
            cboTipoSalida.Enabled = sino;
            btnProveedor.Enabled = sino;
            btnTipoSalida.Enabled = sino;
            btnSeries.Enabled = sino;

            btnGuardar.Enabled = sino;
            btnAfectarInventario.Enabled = sino;
        }
        private void bloquearSalidaError(Boolean sino)
        {
            groupControl1.Enabled = sino;
            dateFecha.Enabled = sino;
            txtFolio.Enabled = sino;
            textJefeCuadrilla.Enabled = sino;
            cboSerie.Enabled = sino;
            cboTipoSalida.Enabled = sino;
            btnProveedor.Enabled = sino;
            btnTipoSalida.Enabled = sino;
            btnSeries.Enabled = sino;

   
        }

        private void Frm_Salidas_Load(object sender, EventArgs e)
        {
            FormatoDeCampos();
            FormatoDeColumnas();
            LimpiarCampos();
            MakeTablaPedidos();
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
            if (txtCodigo.Text != string.Empty && txtDescripcion.Text != string.Empty && txtUnidaddeMedida.Text != string.Empty)
            {
                txtCantidad.Focus();
            }
            else
            {
                txtCodigo.Focus();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (!ExisteCodigo())
                {
                    string vSerie_Salida = "0";
                    string vFolio_Salida = "0";
                    string vRegistro_SalidaDetalles = Convert.ToString(gridViewSalidas.RowCount + 1);
                    string vId_Producto = txtCodigo.Text;
                    string vNombre_Producto = txtDescripcion.Text;
                    string vNombre_UnidadMedida = txtUnidaddeMedida.Text;
                    string vCantidad_SalidaDetalles = txtCantidad.Text;
                    string vPrecio_SalidaDetalles = txtPrecio.Text;
                    string vTotal_SalidaDetalles = txtTotal.Text;
                    string vObservaciones_SalidaDetalles = txtObservaciones.Text;
                    CreatNewRowArticulo(vSerie_Salida, vFolio_Salida, vRegistro_SalidaDetalles, vId_Producto, vNombre_Producto, vNombre_UnidadMedida, vCantidad_SalidaDetalles, vPrecio_SalidaDetalles, vTotal_SalidaDetalles, vObservaciones_SalidaDetalles);

                    gridViewSalidas.Focus();
                    gridViewSalidas.UpdateTotalSummary();
                    gridViewSalidas.UpdateSummary();
                    gridViewSalidas.UpdateGroupSummary();
                    gridViewSalidas.FocusedRowHandle = 0;
                    gridViewSalidas.SelectRow(0);
                    txtCodigo.Focus();
                    LimpiarDetalles();

                }
                NumerarReg();
            }
        }

        private void gridSalidas_DoubleClick(object sender, EventArgs e)
        {
            if (txtFolio.Text.Trim().Length == 0)
            {
                if (gridViewSalidas.RowCount > 0)
                {
                    try
                    {
                        DialogResult = XtraMessageBox.Show("¿Desea Eliminar este articulo de la Entrada?", "Elimnar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (DialogResult == DialogResult.Yes)
                        {
                            gridViewSalidas.DeleteRow(gridViewSalidas.FocusedRowHandle);
                            NumerarReg();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void btnTipoSalida_Click(object sender, EventArgs e)
        {
            Frm_TiposSalidas frm = new Frm_TiposSalidas();

            frm.ShowDialog();
            CargarTiposdeSalida(null);
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidaEncabezado())
            {
                if (ValidaDetalles())
                {
                    if (txtFolio.Text.Trim().Length > 0)
                    {
                        Guardadosecundario();
                        Afectacionsecundario();
                    }
                    else
                    {
                        GuardarSalida();
                    }
                    verificaParaLiberarReserva();

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

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnAfectarInventario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFolio.Text.Trim().Length > 0)
            {
                if (gridViewSalidas.RowCount > 0)
                {
                    Afectacionsecundario();
                }
            }
        }

        private void btnBuscarFolio_Click(object sender, EventArgs e)
        {
            Frm_BusqSalidas frm = new Frm_BusqSalidas();

            LimpiarCampos();

            frm.ShowDialog();

            if (frm.IdSalida.Trim().Length > 0)
            {
                txtFolio.Text = frm.IdSalida;
                cboSerie.EditValue = frm.IdSerie;
                cboTipoSalida.EditValue = frm.IdTipoSalida;
                textJefeCuadrilla.Tag = frm.IdJefeCuadrilla;
                textJefeCuadrilla.Text = frm.JefeCuadrilla;
                dateFecha.EditValue = Convert.ToDateTime(frm.FechaSalida);
                CargarSalidasDetalles();
                bloquearSalida(false);
            }
            
        }

        
        private int SelectReserva(string Producto)
        {
            CLS_ReservaProductoSalida Clase = new CLS_ReservaProductoSalida();
            Clase.Id_Producto = Producto;
            Clase.MtdSeleccionarReserva();
            if (Clase.Exito)
            {
                return Convert.ToInt32(Clase.Datos.Rows[0][0]);
            }else
            {
                return 0;
            }
        
        }
        private void InsertReserva()
        {
            CLS_ReservaProductoSalida Clase = new CLS_ReservaProductoSalida();

            String hostName = string.Empty;
            hostName = Dns.GetHostName();

            Clase.Id_Producto = txtCodigo.Text.Trim();
            Clase.Cantidad = Convert.ToUInt32(txtCantidad.Text.Trim());
            Clase.EquipoReservo = hostName.Trim();

            Clase.MtdInsertarReserva();

            if (Clase.Exito)
            {
              
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void deleteReserva()
        {
            CLS_ReservaProductoSalida Clase = new CLS_ReservaProductoSalida();
            String hostName = string.Empty;
            hostName = Dns.GetHostName();

            
            Clase.EquipoReservo = hostName.Trim();

            Clase.MtdEliminarReserva();

            if (Clase.Exito)
            {

            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void verificaParaLiberarReserva()
        {
            Boolean Completo = true;
            for (int x = 0; x < gridViewSalidas.RowCount; x++)
            {
                int xRow = gridViewSalidas.GetVisibleRowHandle(x);
                if (gridViewSalidas.GetRowCellValue(xRow, gridViewSalidas.Columns["AplicadoInventario"]).ToString().Equals("True"))
                {

                }else
                {
                    Completo = false;
                    break;
                }
            }
            if (Completo)
            {
                deleteReserva();
                if (txtFolio.Text.Trim().Length > 0)
                {
                    bloquearSalida(false);
                }
            }
            
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Frm_BusqJefeCuadrillas frm = new Frm_BusqJefeCuadrillas();

            frm.ShowDialog();

            textJefeCuadrilla.Tag = frm.IdEmpleado;
            textJefeCuadrilla.Text = frm.NombreEmpleado;

        }

      

        private void Frm_Salidas_FormClosed(object sender, FormClosedEventArgs e)
        {
            deleteReserva();
        }
    }


}