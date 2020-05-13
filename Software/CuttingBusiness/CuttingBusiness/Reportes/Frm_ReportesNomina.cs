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
            Limpiar();
            GridMultipleODC();
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
            }
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
            string DiaCorto = string.Empty;
            string R_1 = "D";
            string R_2 = "E";
            string OrdenCorte = string.Empty;
            int Fila = 10;
            FActual = Convert.ToDateTime(FInicio.Day+ "/"+FInicio.Month+"/"+FInicio.Year);
            for (int i = 0; i < DiferenciaD.Days + 1; i++)
            {
                OrdenCorte = string.Empty;
                DiaCorto = dayOfWeek(FActual).ToUpper();
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

                oRng = oSheet.get_Range(R_2 + Fila2.ToString(), R_2 + Fila2.ToString());
                oRng.Merge();
                oRng.Value2 = "$";
                oRng.Font.FontStyle = "Calibri";
                oRng.Font.Size = 11;
                oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                oRng.Font.Bold = true;

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
            oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_2 + Fila2.ToString());
            oRng.Merge();
            oRng.Value2 = "DESCUENTO";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;

            R_1 = AumentaColumna(R_1);
            R_2 = AumentaColumna(R_2);
            R_2 = AumentaColumna(R_2);

            oRng = oSheet.get_Range(R_1 + Fila.ToString(), R_2 + Fila.ToString());
            oRng.Merge();
            oRng.Value2 = "TOTAL";
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

            oRng = oSheet.get_Range(R_2 + Fila2.ToString(), R_2 + Fila2.ToString());
            oRng.Merge();
            oRng.Value2 = "$";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;

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