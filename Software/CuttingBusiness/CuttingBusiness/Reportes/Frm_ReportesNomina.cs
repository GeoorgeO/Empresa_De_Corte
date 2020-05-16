﻿using System;
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
using GridControlEditCBMultipleSelection;
using DevExpress.XtraGrid;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Globalization;

namespace CuttingBusiness
{
    public partial class Frm_ReportesNomina : DevExpress.XtraEditors.XtraForm
    {
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        int FilaActual = 0;
        public string ColFinal { get; set; }

        public string JefeCuadrilla { get; set; }
        GridControlCheckMarksSelection gridCheckMarksODC;
        string CadenaCodigos = null;
        StringBuilder sb = new StringBuilder();
        private static Frm_ReportesNomina m_FormDefInstance;
        public static Frm_ReportesNomina DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_ReportesNomina();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public decimal vPagoJefeCuadrilla { get; set; }

        public Frm_ReportesNomina()
        {
            InitializeComponent();
        }
        private void MakeTablaReportes()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;
            column.DataType = typeof(string);
            column.ColumnName = "Total_Cortes";
            column.AutoIncrement = false;
            column.Caption = "Orden de Corte";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Nombre_empleado";
            column.AutoIncrement = false;
            column.Caption = "Jefe Cuadrilla";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id_Cuadrilla";
            column.AutoIncrement = false;
            column.Caption = "Cuadrilla";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Nombre_Categoria";
            column.AutoIncrement = false;
            column.Caption = "Categoria";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Promedio_cortadores";
            column.AutoIncrement = false;
            column.Caption = "Total cortadores";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Promedio_Cajas";
            column.AutoIncrement = false;
            column.Caption = "Total cajas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Total_Importe";
            column.AutoIncrement = false;
            column.Caption = "Total Importe";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Total_Jefe";
            column.AutoIncrement = false;
            column.Caption = "Precio Caja";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);
            dtgReporteNomina.DataSource = table;
        }
        private void CargarFormatos()
        {
            lueFormatos.Properties.DataSource = null;
            CLS_Reportes_Nomina Clase = new CLS_Reportes_Nomina();

            Clase.MtdSeleccionarFormatos();
            if (Clase.Exito)
            {
                lueFormatos.Properties.DataSource = Clase.Datos;
            }
        }

        private void lueFormatos_QueryPopUp(object sender, CancelEventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            for (int i = 0; i < edit.Properties.Columns.Count; i++)
            {
                if (i < 1)
                {
                    edit.Properties.Columns[i].Width = 60;
                }
                else
                {
                    edit.Properties.Columns[i].Width = 250;
                }
            }
            edit.Properties.PopupFormMinSize = new Size(300 * edit.Properties.Columns.Count, edit.Properties.PopupFormMinSize.Height);
        }

        private void Frm_ReportesNomina_Shown(object sender, EventArgs e)
        {
            GridMultipleODC();
            Limpiar();
        }
        private void Limpiar()
        {
            dtInicio.DateTime = DateTime.Now;
            dtFin.DateTime = DateTime.Now;
            CargarFormatos();
            MakeTablaReportes();
            Prom_Cortadores.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            Prom_Cortadores.DisplayFormat.FormatString = "###,###0";
            Prom_Cajas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            Prom_Cajas.DisplayFormat.FormatString = "###,###0";
            Tot_Importe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            Tot_Importe.DisplayFormat.FormatString = "$ ###,###0.00";
            Tot_Jefe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            Tot_Jefe.DisplayFormat.FormatString = "$ ###,###0.00";
            gridCheckMarksODC.ClearSelection();

        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Limpiar();
        }
        private void GridMultipleODC()
        {
            gridCheckMarksODC = new GridControlCheckMarksSelection(dtgValReporteNomina);
            gridCheckMarksODC.SelectionChanged += gridCheckMarksAcuerdos_SelectionChanged;
        }
        void gridCheckMarksAcuerdos_SelectionChanged(object sender, EventArgs e)
        {
            CadenaCodigos = string.Empty;
            if (ActiveControl is GridControl)
            {

                foreach (DataRowView rv in (sender as GridControlCheckMarksSelection).selection)
                {
                    if (sb.ToString().Length > 0) { sb.Append(", "); }
                    sb.AppendFormat("{0}", rv["Id_Cuadrilla"]);

                    if (CadenaCodigos != string.Empty)
                    {
                        CadenaCodigos = string.Format("{0},{1}", CadenaCodigos, rv["Id_Cuadrilla"]);
                    }
                    else
                    {
                        CadenaCodigos = rv["Id_Cuadrilla"].ToString();
                    }
                }
            }
            if (CadenaCodigos == string.Empty)
            {
                btnExportar.Enabled = false;
            }
            else
            {
                btnExportar.Enabled = true;
            }
        }
        public string DosCeros(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }
        private void btnBuscar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridCheckMarksODC.ClearSelection();
            CLS_Reportes_Nomina Clase = new CLS_Reportes_Nomina();
            DateTime Fecha;
            Fecha = Convert.ToDateTime(dtInicio.EditValue);
            Clase.FechaInicio = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            Fecha = Convert.ToDateTime(dtFin.EditValue);
            Clase.FechaFin = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            Clase.MtdSeleccionarNominas();
            if (Clase.Exito)
            {
                dtgReporteNomina.DataSource = Clase.Datos;
            }
        }

        private void Frm_ReportesNomina_Load(object sender, EventArgs e)
        {

        }
        private string obtenerNombreMesNumero(int numeroMes)
        {
            try
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(numeroMes);
                return nombreMes;
            }
            catch
            {
                return "Desconocido";
            }
        }
        private void btnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!string.IsNullOrEmpty(CadenaCodigos))
            {
                if(lueFormatos.EditValue!=null)
                {
                    switch (lueFormatos.EditValue.ToString())
                    {
                        case "001":
                            Formato_A();
                            break;
                        case "002":
                            break;
                        case "003":
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Debe seleccionar un formato");
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado una cuadrilla para generar el reporte");
            }
        }

        private void Formato_A()
        {
            CreaLibro();
            int cont = 0;
            string[] vCuadrilla = CadenaCodigos.Split(',');
            foreach (string cuadrilla in vCuadrilla)
            {
                string IdCuadrillaCategoria = BuscarCuadrilla(cuadrilla);
                if (cont == 0)
                {
                    oSheet = CreaHoja(IdCuadrillaCategoria);
                    cont++;
                }
                else
                {
                    oSheet = CreaHoja2(IdCuadrillaCategoria, oSheet);
                }
                Colocar_encabezado(oSheet, IdCuadrillaCategoria);
                Colocar_Dias(oSheet);
                Colocar_Ordenes(oSheet, cuadrilla);
                Colocar_Empleados(oSheet, cuadrilla);
                Colocar_Encabezados_Sub(oSheet);
                Colocar_Subtotales(oSheet, cuadrilla);
            }
        }

        private void Colocar_Encabezados_Sub(Excel._Worksheet oSheet)
        {
            int Fila = FilaActual + 1;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "TOTAL CUADRILLA POR DIA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();
            Fila++;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "CORTE PAGADO POR DIA TOTAL";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();
            Fila++;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "TOTAL DE CAJAS DEL DIA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();
            Fila++;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "PROMEDIO POR DIA POR CAJA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();
            Fila++;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "KILOS CORTADOS POR DIA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();
            Fila++;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "TOTAL DE KILOS CORTADOS POR DIA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();

            Fila =Fila+2;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "Caso Espqciales";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();

            Fila = Fila + 2;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "Descuento Jefe de Cuadrilla";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();

            Fila = Fila + 2;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble;

            Fila++;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = "RECIBO DE CONFROMIDAD";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();

            Fila++;
            oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
            oRng.Value2 = JefeCuadrilla.ToUpper();
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.EntireColumn.AutoFit();
            
        }

        private void Colocar_Subtotales(Excel._Worksheet oSheet, string cuadrilla)
        {
            DateTime FInicio = dtInicio.DateTime;
            DateTime FFin = dtFin.DateTime;
            TimeSpan DiferenciaD = FFin - FInicio;
            DateTime FActual = FInicio;
            vPagoJefeCuadrilla = 0;
            CLS_Reportes_Nomina sel = new CLS_Reportes_Nomina();
            sel.FechaInicio = FInicio.Year + DosCero(FInicio.Month.ToString()) + DosCero(FInicio.Day.ToString());
            sel.FechaFin = FInicio.Year + DosCero(FFin.Month.ToString()) + DosCero(FFin.Day.ToString());
            sel.Id_Cuadrilla = cuadrilla;
            sel.MtdSeleccionarNominaSubTotales();
            if (!sel.Exito)
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
            
            string R_1 = "D";
            string R_2 = "E";
            int Fila = FilaActual+1;
            FActual = Convert.ToDateTime(FInicio.Day + "/" + FInicio.Month + "/" + FInicio.Year);
            for (int i = 0; i < DiferenciaD.Days + 1; i++)
            {
                Fila = FilaActual + 1;
                for (int x = 0; x < sel.Datos.Rows.Count; x++)
                {
                    if (FActual == Convert.ToDateTime(sel.Datos.Rows[x]["Fecha_HojaNomina"].ToString()))
                    {
                        oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
                        oRng.Formula = "=IF(COUNT(" + R_1 + "13:" + R_1 + FilaActual.ToString() + ")>0,COUNT(" + R_1 + "13:" + R_1 + FilaActual.ToString() + "),0)";
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        Fila++;
                        oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
                        oRng.Value2 = sel.Datos.Rows[x]["Tope_pgo_x_dia"].ToString();
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.NumberFormat = "$#,##0.00";
                        Fila++;
                        oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
                        oRng.Formula = "=SUM(" + R_1 + "13:" + R_1 + FilaActual.ToString() + ")";
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;

                        oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
                        oRng.Value2 = sel.Datos.Rows[x]["TotalImporte"].ToString();
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.NumberFormat = "$#,##0";
                        Fila++;

                        oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
                        decimal Valor = decimal.Round(Convert.ToDecimal(sel.Datos.Rows[x]["Precio_caja_1"].ToString()), 2);
                        oRng.Value2 = Valor;
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.NumberFormat = "$#,##0.00";

                        oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
                        Valor = decimal.Round(Convert.ToDecimal(sel.Datos.Rows[x]["Precio_caja_2"].ToString()), 2);
                        oRng.Value2 = Valor;
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.NumberFormat = "$#,##0.00";
                        Fila++;

                        oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
                        oRng.Value2 = sel.Datos.Rows[x]["Kgs_cortados_x_dia"].ToString();
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.NumberFormat = "#,##0";

                        oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
                        oRng.Value2 = sel.Datos.Rows[x]["Pago_jefe_cuadrilla"].ToString();
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.NumberFormat = "$#,##0";
                        vPagoJefeCuadrilla = vPagoJefeCuadrilla + Convert.ToDecimal(sel.Datos.Rows[x]["Pago_jefe_cuadrilla"].ToString());
                        Fila++;

                        oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
                        oRng.Value2 = sel.Datos.Rows[x]["Peso_promedio_caja"].ToString();
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        break;
                    }
                }
                FActual = FActual.AddDays(1);
                if (i < DiferenciaD.Days)
                {
                    R_1 = AumentaColumna(R_1);
                    R_1 = AumentaColumna(R_1);
                    R_2 = AumentaColumna(R_2);
                    ColFinal = R_2;
                    R_2 = AumentaColumna(R_2);
                }
                else
                {
                    R_1 = AumentaColumna(R_1);
                    R_1 = AumentaColumna(R_1);
                    ColFinal = R_2;
                    R_2 = AumentaColumna(R_2);
                }
            }
            Fila = FilaActual + 3;
            oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Formula = "=SUM(" + R_1 + "13:" + R_1 + FilaActual.ToString() + ")";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "#,##0";

            R_1 = AumentaColumna(R_1);
            R_2 = AumentaColumna(R_2);
            R_2 = AumentaColumna(R_2);

            int filt = FilaActual + 6;
            oRng = oSheet.get_Range("A" + FilaActual.ToString(), R_2 + filt.ToString());
            oRng.Borders.Weight = Excel.XlBorderWeight.xlThin;

            Fila = FilaActual + 3;
            oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Formula =  "=SUM(" + R_1 + "13:" + R_1 + FilaActual.ToString() + ")";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "#,##0";

            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Formula = "=SUM(" + R_2 + "13:" + R_2 + FilaActual.ToString() + ")";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0";
            Fila = Fila+5;

            oRng = oSheet.get_Range(ColFinal + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Merge();
            oRng.Value2 = "TOTAL CORTADORES";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            


            int filatemp = Fila - 5;
            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Formula = "=" + R_2 + filatemp.ToString();
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0.00";

            Fila = Fila + 2;
            oRng = oSheet.get_Range(ColFinal + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Merge();
            oRng.Value2 = "CASOS ESPECIALES";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;

            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Value2 = "0";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0.00";

            Fila = Fila + 2;
            oRng = oSheet.get_Range(ColFinal + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Merge();
            oRng.Value2 = "PAGO JEFE CUADRILLA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;

            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Value2 = vPagoJefeCuadrilla;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0.00";

            Fila++;
            oRng = oSheet.get_Range(ColFinal + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Merge();
            oRng.Value2 = "DESCUENTOS";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;

            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Value2 = "0";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0.00";

            Fila++;
            oRng = oSheet.get_Range(ColFinal + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Merge();
            oRng.Value2 = "CASOS ESPECIALES";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;

            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Value2 = "0";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0.00";

            Fila++;
            oRng = oSheet.get_Range(ColFinal + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Merge();
            oRng.Value2 = "TOTAL PAGO JEFE CUADRILLA";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;

            filatemp = Fila - 3;
            int filatemp2 = Fila - 1;
            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Value2 = "=SUM(" + R_2 + filatemp.ToString() + ":" + R_2 + filatemp2.ToString() + ")";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0.00";

            Fila=Fila+2;
            oRng = oSheet.get_Range(ColFinal + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Merge();
            oRng.Value2 = "TOTAL A PAGAR";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;

            filatemp = Fila - 9;
            filatemp2 = Fila - 2;
            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Value2 = "="+R_2+filatemp.ToString()+"+"+R_2+filatemp2.ToString();
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0.00";
        }

        private void Colocar_Empleados(Excel._Worksheet oSheet, string cuadrilla)
        {
            DateTime FInicio = dtInicio.DateTime;
            DateTime FFin = dtFin.DateTime;
            TimeSpan DiferenciaD = FFin - FInicio;
            DateTime FActual = FInicio;
            CLS_Reportes_Nomina sel = new CLS_Reportes_Nomina();
            sel.FechaInicio = FInicio.Year + DosCero(FInicio.Month.ToString()) + DosCero(FInicio.Day.ToString());
            sel.FechaFin = FInicio.Year + DosCero(FFin.Month.ToString()) + DosCero(FFin.Day.ToString());
            sel.Id_Cuadrilla = cuadrilla;
            sel.MtdSeleccionarNominaCortadores();
            if (!sel.Exito)
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
            string R_1 = "D";
            string R_2 = "E";
            int Fila = 12;
            int DiasTrabajados = 0;
            FActual = Convert.ToDateTime(FInicio.Day + "/" + FInicio.Month + "/" + FInicio.Year);
            string vId_Empleado = string.Empty;
            int N_Empleado = 1;
            decimal T_Cajas = 0;
            decimal T_Importe = 0;
            for (int x = 0; x < sel.Datos.Rows.Count; x++)
            {
                for (int i = 0; i < DiferenciaD.Days + 1; i++)
                {
                    if (vId_Empleado != sel.Datos.Rows[x]["Id_Empleado"].ToString())
                    {
                        if(vId_Empleado!=string.Empty)
                        {
                            R_1 = AumentaColumna(R_1);
                            R_1 = AumentaColumna(R_1);
                            R_2 = AumentaColumna(R_2);
                            R_1 = AumentaColumna(R_1);
                            R_2 = AumentaColumna(R_2);
                            R_2 = AumentaColumna(R_2);

                            oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
                            oRng.Merge();
                            oRng.Value2 = T_Cajas;
                            oRng.Font.FontStyle = "Calibri";
                            oRng.Font.Size = 11;
                            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            oRng.Font.Bold = false;
                            oRng.NumberFormat = "#,##0";

                            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
                            oRng.Merge();
                            oRng.Value2 = T_Importe;
                            oRng.Font.FontStyle = "Calibri";
                            oRng.Font.Size = 11;
                            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            oRng.Font.Bold = false;
                            oRng.NumberFormat = "$#,##0";

                            oRng = oSheet.get_Range("C" + Fila.ToString(), "C" + Fila.ToString());
                            oRng.Merge();
                            oRng.Value2 = DiasTrabajados;
                            oRng.Font.FontStyle = "Calibri";
                            oRng.Font.Size = 11;
                            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            oRng.Font.Bold = false;
                            oRng.NumberFormat = "#,##0";
                        }
                        Fila++;
                        R_1 = "D";
                        R_2 = "E";
                        oRng = oSheet.get_Range("A" + Fila.ToString(), "A" + Fila.ToString());
                        oRng.Value2 = N_Empleado;
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.EntireColumn.AutoFit();

                        oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
                        oRng.Value2 = sel.Datos.Rows[x]["Nombre_Empleado"].ToString();
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.Font.Bold = false;
                        oRng.EntireColumn.AutoFit();

                        N_Empleado++;
                        vId_Empleado = sel.Datos.Rows[x]["Id_Empleado"].ToString();
                        FActual = Convert.ToDateTime(FInicio.Day + "/" + FInicio.Month + "/" + FInicio.Year);
                        T_Cajas = 0;
                        T_Importe = 0;
                        DiasTrabajados = 0;
                    }
                    if (FActual == Convert.ToDateTime(sel.Datos.Rows[x]["Fecha_HojaNomina"].ToString()))
                    {
                        oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
                        oRng.Value2 = sel.Datos.Rows[x]["Cajas"].ToString();
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.NumberFormat = "#,##0";
                        T_Cajas = T_Cajas + decimal.Round(Convert.ToDecimal(sel.Datos.Rows[x]["Cajas"].ToString()), 0);

                        oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
                        int Valor = Convert.ToInt32(decimal.Round(Convert.ToDecimal(sel.Datos.Rows[x]["Importe"].ToString()), 0));
                        oRng.Value2 = Valor;
                        oRng.Font.FontStyle = "Calibri";
                        oRng.Font.Size = 11;
                        oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        oRng.Font.Bold = false;
                        oRng.NumberFormat = "$#,##0";
                        T_Importe =T_Importe+ decimal.Round(Convert.ToDecimal(sel.Datos.Rows[x]["Importe"].ToString()), 0);
                        DiasTrabajados++;
                        break;
                    }
                    FActual = FActual.AddDays(1);
                    if (i < DiferenciaD.Days)
                    {
                        R_1 = AumentaColumna(R_1);
                        R_1 = AumentaColumna(R_1);
                        R_2 = AumentaColumna(R_2);
                        R_2 = AumentaColumna(R_2);
                    }
                }
            }
            R_1 = AumentaColumna(R_1);
            R_1 = AumentaColumna(R_1);
            R_2 = AumentaColumna(R_2);
            R_1 = AumentaColumna(R_1);
            R_2 = AumentaColumna(R_2);
            R_2 = AumentaColumna(R_2);

            oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_1 + Fila.ToString());
            oRng.Value2 = T_Cajas;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = false;

            oRng = oSheet.get_Range(R_2 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Value2 = T_Importe;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "$#,##0";

            oRng = oSheet.get_Range("C" + Fila.ToString(), "C" + Fila.ToString());
            oRng.Value2 = DiasTrabajados;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = false;
            oRng.NumberFormat = "#,##0";

            oRng = oSheet.get_Range("A13", R_2 + Fila.ToString());
            oRng.Borders.Weight = Excel.XlBorderWeight.xlThin;

            Fila++;

            oRng = oSheet.get_Range("A" + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Interior.ColorIndex = 1;
            FilaActual = Fila;
            Fila = Fila + 5;
            oRng = oSheet.get_Range("A" + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Interior.ColorIndex = 1;
            oRng.Font.Color = Color.White;
            
        }

        private void Colocar_Ordenes(Excel._Worksheet oSheet, string cuadrilla)
        {
            DateTime FInicio = dtInicio.DateTime;
            DateTime FFin = dtFin.DateTime;
            TimeSpan DiferenciaD = FFin - FInicio;
            DateTime FActual = FInicio;
            CLS_Reportes_Nomina sel = new CLS_Reportes_Nomina();
            sel.FechaInicio = FInicio.Year + DosCero(FInicio.Month.ToString()) + DosCero(FInicio.Day.ToString());
            sel.FechaFin = FInicio.Year + DosCero(FFin.Month.ToString()) + DosCero(FFin.Day.ToString());
            sel.Id_Cuadrilla = cuadrilla;
            sel.MtdSeleccionarNominaOrdenes();
            if(!sel.Exito)
            {
                XtraMessageBox.Show(sel.Mensaje);
            }
            //string DiaCorto = string.Empty;
            string R_1 = "D";
            string R_2 = "E";
            string OrdenCorte = string.Empty;
            int Fila = 10;
            FActual = Convert.ToDateTime(FInicio.Day+ "/"+FInicio.Month+"/"+FInicio.Year);
            for (int i = 0; i < DiferenciaD.Days + 1; i++)
            {
                OrdenCorte = string.Empty;
                //DiaCorto = dayOfWeek(FActual).ToUpper();
                for (int x = 0; x < sel.Datos.Rows.Count; x++)
                {
                    if (FActual ==Convert.ToDateTime(sel.Datos.Rows[x]["Fecha_HojaNomina"].ToString()))
                    {
                        OrdenCorte = sel.Datos.Rows[x]["Id_HojaNomina"].ToString();
                        break;
                    }
                } 
                
                oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_2 + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = OrdenCorte;
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oRng.Font.Bold = true;

                FActual = FActual.AddDays(1);
                if (i < DiferenciaD.Days)
                {
                    R_1 = AumentaColumna(R_1);
                    R_1 = AumentaColumna(R_1);
                    R_2 = AumentaColumna(R_2);
                    R_2 = AumentaColumna(R_2);
                }
                else
                {
                    R_1 = AumentaColumna(R_1);
                    R_1 = AumentaColumna(R_1);
                    R_2 = AumentaColumna(R_2);
                }
            }
        }

        private void Colocar_Dias(Excel._Worksheet oSheet)
        {
            DateTime FInicio = dtInicio.DateTime;
            DateTime FFin = dtFin.DateTime;
            TimeSpan DiferenciaD = FFin - FInicio;
            DateTime FActual = FInicio;
            string DiaCorto = string.Empty;
            string R_1 = "D";
            string R_2 = "E";
            int Fila = 11;
            int Fila2 = 12;
            for (int i = 0; i < DiferenciaD.Days + 1; i++)
            {
                DiaCorto = dayOfWeek(FActual).ToUpper();
                oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_2 + Fila.ToString());
                oRng.Merge();
                oRng.Value2 = DiaCorto + " " + DosCero(FActual.Day.ToString());
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oRng.Font.Bold = true;

                oRng = oSheet.get_Range(R_1 + Fila2.ToString(), R_1 + Fila2.ToString());
                oRng.Merge();
                oRng.Value2 = "CJS";
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oRng.Font.Bold = true;
                oRng.EntireColumn.ColumnWidth = 9;

                oRng = oSheet.get_Range(R_2 + Fila2.ToString(), R_2 + Fila2.ToString());
                oRng.Merge();
                oRng.Value2 = "$";
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oRng.Font.Bold = true;
                oRng.EntireColumn.ColumnWidth = 9;

                FActual = FActual.AddDays(1);
                if (i < DiferenciaD.Days )
                {
                    R_1 = AumentaColumna(R_1);
                    R_1 = AumentaColumna(R_1);
                    R_2 = AumentaColumna(R_2);
                    R_2 = AumentaColumna(R_2);
                }
                else
                {
                    R_1 = AumentaColumna(R_1);
                    R_1 = AumentaColumna(R_1);
                    R_2 = AumentaColumna(R_2);
                }
            }
            Fila--;
            oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_2 + Fila2.ToString());
            oRng.Merge();
            oRng.Value2 = "DESCUENTO";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 9;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.EntireColumn.AutoFit();

            R_1 = AumentaColumna(R_1);
            R_2 = AumentaColumna(R_2);
            R_2 = AumentaColumna(R_2);

            oRng = oSheet.get_Range(R_1 + "10", R_2 + "11");
            oRng.Merge();
            oRng.Value2 = "TOTAL";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range(R_1 + Fila2.ToString(), R_1 + Fila2.ToString());
            oRng.Merge();
            oRng.Value2 = "CJS";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.EntireColumn.ColumnWidth = 9;

            oRng = oSheet.get_Range(R_2 + Fila2.ToString(), R_2 + Fila2.ToString());
            oRng.Merge();
            oRng.Value2 = "$";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.EntireColumn.ColumnWidth = 11;

            oRng = oSheet.get_Range("A10", R_2 + Fila2.ToString());
            oRng.Borders.Weight = Excel.XlBorderWeight.xlThin;
        }

        private string AumentaColumna(string r_1)
        {
            string Valor = string.Empty;
            switch (r_1)
            {
                case "A":
                    Valor = "B";
                    break;
                case "B":
                    Valor = "C";
                    break;
                case "C":
                    Valor = "D";
                    break;
                case "D":
                    Valor = "E";
                    break;
                case "E":
                    Valor = "F";
                    break;
                case "F":
                    Valor = "G";
                    break;
                case "G":
                    Valor = "H";
                    break;
                case "H":
                    Valor = "I";
                    break;
                case "I":
                    Valor = "J";
                    break;
                case "J":
                    Valor = "K";
                    break;
                case "K":
                    Valor = "L";
                    break;
                case "L":
                    Valor = "M";
                    break;
                case "M":
                    Valor = "N";
                    break;
                case "N":
                    Valor = "O";
                    break;
                case "O":
                    Valor = "P";
                    break;
                case "P":
                    Valor = "Q";
                    break;
                case "Q":
                    Valor = "R";
                    break;
                case "R":
                    Valor = "S";
                    break;
                case "S":
                    Valor = "T";
                    break;
                case "T":
                    Valor = "U";
                    break;
                case "U":
                    Valor = "V";
                    break;
                case "V":
                    Valor = "W";
                    break;
                case "W":
                    Valor = "X";
                    break;
                case "X":
                    Valor = "Y";
                    break;
                case "Y":
                    Valor = "Z";
                    break;
                case "Z":
                    Valor = "AA";
                    break;
                case "AA":
                    Valor = "AB";
                    break;
                case "AB":
                    Valor = "AC";
                    break;
                case "AC":
                    Valor = "AD";
                    break;
                case "AD":
                    Valor = "AE";
                    break;
                case "AE":
                    Valor = "AF";
                    break;
                case "AF":
                    Valor = "AG";
                    break;
                case "AG":
                    Valor = "AH";
                    break;
                case "AH":
                    Valor = "AI";
                    break;
                case "AI":
                    Valor = "AJ";
                    break;
                case "AJ":
                    Valor = "AK";
                    break;
                case "AK":
                    Valor = "AL";
                    break;
                case "AL":
                    Valor = "AM";
                    break;
                case "AM":
                    Valor = "AN";
                    break;
                case "AN":
                    Valor = "AO";
                    break;
                case "AO":
                    Valor = "AP";
                    break;
                case "AP":
                    Valor = "AQ";
                    break;
                case "AQ":
                    Valor = "AR";
                    break;
                case "AR":
                    Valor = "AS";
                    break;
                case "AS":
                    Valor = "AT";
                    break;
                case "AT":
                    Valor = "AU";
                    break;
                case "AU":
                    Valor = "AV";
                    break;
                case "AV":
                    Valor = "W";
                    break;
                case "AW":
                    Valor = "AX";
                    break;
                case "AX":
                    Valor = "AY";
                    break;
                case "AY":
                    Valor = "AZ";
                    break;
                case "AZ":
                    Valor = "BA";
                    break;
                default:
                    break;
            }
            return Valor;
        }

        public String dayOfWeek(DateTime? date)
        {
            return date.Value.ToString("ddd", new CultureInfo("es-MX"));
        }
        private void Colocar_encabezado(Excel._Worksheet oSheet,string IdCuadrillaCategoria)
        {
            //Format A1:D1 as bold, vertical alignment = center.
            oRng = oSheet.get_Range("A6", "U6");
            oRng.Merge();
            oRng.Value2 = "RELACIÓN DE CORTE DEL "+ DosCero(dtInicio.DateTime.Day.ToString()) + " DE "+ obtenerNombreMesNumero(dtInicio.DateTime.Month).ToUpper() +" AL "+ DosCero(dtFin.DateTime.Day.ToString()) + " DE "+ obtenerNombreMesNumero(dtFin.DateTime.Month).ToUpper() + " DEL "+ dtFin.DateTime.Year;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 14;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("A7", "U7");
            oRng.Merge();
            oRng.Value2 = "CUADRILLA No. "+ IdCuadrillaCategoria;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = false;

            oRng = oSheet.get_Range("A8", "U8");
            oRng.Merge();
            oRng.Value2 = "JEFE DE CUADRILLA: "+JefeCuadrilla.ToUpper();
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = false;

            oRng = oSheet.get_Range("A10", "A12");
            oRng.Merge();
            oRng.Value2 = "No.";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("B10", "B12");
            oRng.Merge();
            oRng.Value2 = "NOMBRE";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("C10", "C12");
            oRng.Merge();
            oRng.Value2 = "DIAS TRABAJADOS";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 11.71;
        }

        private string BuscarCuadrilla(string cuadrilla)
        {
            string Valor = string.Empty;
            int xRow = 0;
            for (int i = 0; i < dtgValReporteNomina.RowCount; i++)
            {
                xRow = dtgValReporteNomina.GetVisibleRowHandle(i);
                if(dtgValReporteNomina.GetRowCellValue(xRow, "Id_Cuadrilla").ToString()==cuadrilla)
                {
                    Valor = dtgValReporteNomina.GetRowCellValue(xRow, "Id_Cuadrilla").ToString() + " " + dtgValReporteNomina.GetRowCellValue(xRow, "Nombre_Categoria").ToString();
                    JefeCuadrilla = dtgValReporteNomina.GetRowCellValue(xRow, "Nombre_Empleado").ToString();
                    break;
                }
            }
            return Valor;
        }

        private Excel._Worksheet CreaHoja(string IdCuadrillaCategoria)
        {
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            oSheet = oWB.ActiveSheet as Excel.Worksheet;
            oSheet.Name = IdCuadrillaCategoria;
            return oSheet;
        }
        private Excel._Worksheet CreaHoja2(string IdCuadrillaCategoria, Excel._Worksheet Hoja_actual)
        {
            oSheet = oWB.Sheets.Add(Missing.Value, Hoja_actual, 1, Missing.Value) as Excel.Worksheet;

            oSheet = oWB.ActiveSheet as Excel.Worksheet;
            oSheet.Name = IdCuadrillaCategoria;
            return oSheet;
        }

        private void CreaLibro()
        {
            //Start Excel and get Application object.
            oXL = new Excel.Application();
            oXL.Visible = true;
            oXL.Application.WindowState = Excel.XlWindowState.xlMaximized;
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
    }
}