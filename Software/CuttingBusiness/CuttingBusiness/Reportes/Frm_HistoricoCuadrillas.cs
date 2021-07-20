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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Globalization;

namespace CuttingBusiness
{
    public partial class Frm_HistoricoCuadrillas : DevExpress.XtraEditors.XtraForm
    {
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        Excel.Range oRng;
        private static Frm_HistoricoCuadrillas m_FormDefInstance;
        public static Frm_HistoricoCuadrillas DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_HistoricoCuadrillas();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public string UsuariosLogin { get; set; }
        public string vId_Empleado { get; private set; }

        public Frm_HistoricoCuadrillas()
        {
            InitializeComponent();
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id_Empleado";
            column.AutoIncrement = false;
            column.Caption = "Id Empleado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Nombre_Empleado";
            column.AutoIncrement = false;
            column.Caption = "Nombre Empleado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Nombre_Puesto";
            column.AutoIncrement = false;
            column.Caption = "Nombre Puesto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgEmpleados.DataSource = table;
        }
        private void CreatNewRowEmpleados(string vId_Empleado, string vNombre_Empleado, string vNombre_Puesto)
        {
            dtgValEmpleados.AddNewRow();
            int rowHandle = dtgValEmpleados.GetRowHandle(dtgValEmpleados.DataRowCount);
            if (dtgValEmpleados.IsNewItemRow(rowHandle))
            {
                dtgValEmpleados.SetRowCellValue(rowHandle, dtgValEmpleados.Columns["Id_Empleado"], vId_Empleado);
                dtgValEmpleados.SetRowCellValue(rowHandle, dtgValEmpleados.Columns["Nombre_Empleado"], vNombre_Empleado);
                dtgValEmpleados.SetRowCellValue(rowHandle, dtgValEmpleados.Columns["Nombre_Puesto"], vNombre_Puesto);
            }
        }
        public void CargarEmpleado(string Valor)
        {
            CLS_Empleados CBEmpleados = new CLS_Empleados();
            CBEmpleados.Activo = "1";
            CBEmpleados.MtdSeleccionarEmpleadosHis();
            if (CBEmpleados.Exito)
            {
                cmbEmpleado.Properties.DisplayMember = "Nombre_Empleado";
                cmbEmpleado.Properties.ValueMember = "Id_Empleado";
                cmbEmpleado.EditValue = Valor;
                cmbEmpleado.Properties.DataSource = CBEmpleados.Datos;
            }
        }
        public void CargarEmpleadosRep()
        {
            CLS_EmpleadosHis sel = new CLS_EmpleadosHis();
            sel.MtdSeleccionarEmpleadosGridHis();
            if(sel.Exito)
            {
                dtgEmpleados.DataSource = sel.Datos;
            }
        }
        private void Frm_DiasTrabajados_Shown(object sender, EventArgs e)
        {
            dtInicio.DateTime = DateTime.Now;
            dtFin.DateTime = DateTime.Now;
            
            dtgValEmpleados.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValEmpleados.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValEmpleados.OptionsSelection.MultiSelect = true;
            dtgValEmpleados.OptionsView.ShowGroupPanel = false;
            dtgValEmpleados.OptionsBehavior.AutoPopulateColumns = true;
            dtgValEmpleados.OptionsView.ColumnAutoWidth = true;
            dtgValEmpleados.BestFitColumns();

            dtgValEmpleadosReporte.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValEmpleadosReporte.OptionsSelection.EnableAppearanceHideSelection = false;
            dtgValEmpleadosReporte.OptionsSelection.MultiSelect = true;
            dtgValEmpleadosReporte.OptionsView.ShowGroupPanel = false;
            dtgValEmpleadosReporte.OptionsBehavior.AutoPopulateColumns = true;
            dtgValEmpleadosReporte.OptionsView.ColumnAutoWidth = true;
            dtgValEmpleadosReporte.BestFitColumns();

            LimpiarCampos();
            CargarEmpleado(null);
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            dtgEmpleados.DataSource = null;
            dtgEmpleadosReporte.DataSource = null;
            dtInicio.DateTime = DateTime.Now;
            dtFin.DateTime = DateTime.Now;
            cmbEmpleado.EditValue = null;
            EliminarEmpleadosRep();
        }

        private void EliminarEmpleadosRep()
        {
            CLS_EmpleadosHis del = new CLS_EmpleadosHis();
            del.MtdEliminarEmpleadosHisT();
            if(del.Exito)
            {
                CargarEmpleadosRep();
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbEmpleado.EditValue.ToString()))
                {
                    CLS_EmpleadosHis ins = new CLS_EmpleadosHis();
                    ins.Id_Empleado = cmbEmpleado.EditValue.ToString();
                    ins.MtdInsertarEmpleadosHis();
                    if(!ins.Exito)
                    {
                        XtraMessageBox.Show(ins.Mensaje);
                    }
                    else
                    {
                        CargarEmpleado(null);
                        CargarEmpleadosRep();
                    }
                }
            }
            catch (Exception)
            {


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
            if (dtgValEmpleados.RowCount > 0)
            {
                CLS_EmpleadosHis del = new CLS_EmpleadosHis();
                del.MtdEliminarEmpleadosHisCuadrilla();
                if (del.Exito)
                {
                    if (DateTime.Compare(dtInicio.DateTime, dtFin.DateTime) < 1)
                    {
                        CLS_EmpleadosHis ins = new CLS_EmpleadosHis();
                        DateTime vFechaInicio = Convert.ToDateTime(dtInicio.EditValue.ToString());
                        DateTime vFechaFin = Convert.ToDateTime(dtFin.EditValue.ToString());
                        ins.FechaInicio = vFechaInicio.Year.ToString() + DosCeros(vFechaInicio.Month.ToString()) + DosCeros(vFechaInicio.Day.ToString());
                        ins.FechaFin = vFechaFin.Year.ToString() + DosCeros(vFechaFin.Month.ToString()) + DosCeros(vFechaFin.Day.ToString());
                        ins.MtdInsertarEmpleadosHisCuadrilla();
                        if (ins.Exito)
                        {
                            CLS_EmpleadosHis sel = new CLS_EmpleadosHis();
                            sel.MtdSeleccionarEmpleadosHisCuadrilla();
                            if (sel.Exito)
                            {
                                dtgEmpleadosReporte.DataSource = sel.Datos;
                                dtgValEmpleadosReporte.OptionsView.ColumnAutoWidth = true;
                                dtgValEmpleadosReporte.BestFitColumns();
                            }
                            XtraMessageBox.Show("Reporte generado");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("La fecha inicio no puede ser mayor a la fecha fin");
                    }
                }
                dtgValEmpleadosReporte.OptionsView.ColumnAutoWidth = true;
                dtgValEmpleadosReporte.BestFitColumns();
            }
            else
            {
                XtraMessageBox.Show("no se han agregado empleados a buscar");
            }
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(vId_Empleado))
            {
                CLS_EmpleadosHis del = new CLS_EmpleadosHis();
                del.Id_Empleado = vId_Empleado;
                del.MtdEliminarEmpleadosHis();
                if (del.Exito)
                {
                    CargarEmpleado(null);
                    CargarEmpleadosRep();
                    XtraMessageBox.Show("Se ha eliminado el dato con exito");
                }
                else
                {
                    XtraMessageBox.Show(del.Mensaje);
                }
            }
            else
            {
                XtraMessageBox.Show("No se ha seleccionado Empleado para quitar");
            }
        }

        private void dtgEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValEmpleados.GetSelectedRows())
                {
                    DataRow row = this.dtgValEmpleados.GetDataRow(i);
                    vId_Empleado = row["Id_Empleado"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnExportarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtgValEmpleadosReporte.RowCount > 0)
            {
                CreaLibro();
                oSheet = CreaHoja("DiasTrabajados");
                Colocar_encabezado(oSheet);
                CargarEmpleados(oSheet);
            }
            else
            {
                XtraMessageBox.Show("No existe empleadpos a exportar a Excel");
            }
        }
        private void CreaLibro()
        {
            //Start Excel and get Application object.
            oXL = new Excel.Application();
            oXL.Visible = true;
            oXL.Application.WindowState = Excel.XlWindowState.xlMaximized;
        }
        private Excel._Worksheet CreaHoja(string NombreHoja)
        {
            oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            oSheet = oWB.ActiveSheet as Excel.Worksheet;
            oSheet.Name = NombreHoja;
            return oSheet;
        }
        private void Colocar_encabezado(Excel._Worksheet oSheet)
        {
            //Format A1:D1 as bold, vertical alignment = center.
            oRng = oSheet.get_Range("A2", "B2");
            oRng.Merge();
            oRng.Value2 = "DIAS LABORADOS POR TRABAJADOR";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 14;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("A3", "B3");
            oRng.Merge();
            oRng.Value2 = "DEL "+DosCero(dtInicio.DateTime.Day.ToString()) + " DE " + obtenerNombreMesNumero(dtInicio.DateTime.Month).ToUpper() + " DEL " + dtInicio.DateTime.Year + " AL " + DosCero(dtFin.DateTime.Day.ToString()) + " DE " + obtenerNombreMesNumero(dtFin.DateTime.Month).ToUpper() + " DEL " + dtFin.DateTime.Year;
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;

            oRng = oSheet.get_Range("A5", "A5");
            oRng.Merge();
            oRng.Value2 = "NOMBRE";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;
            oRng.WrapText = true;
            oRng.EntireColumn.ColumnWidth = 57.86;

            oRng = oSheet.get_Range("B5", "B5");
            oRng.Merge();
            oRng.Value2 = "DÍAS";
            oRng.Font.FontStyle = "Calibri";
            oRng.Font.Size = 11;
            oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
            oRng.Font.Bold = true;


            oRng = oSheet.get_Range("A5", "B5");
            oRng.Borders.Item[Excel.XlBordersIndex.xlEdgeBottom].LineStyle= Excel.XlLineStyle.xlContinuous;
            oRng.Borders.Item[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
        }
        private void CargarEmpleados(Excel._Worksheet oSheet)
        {
            CLS_EmpleadosHis sel = new CLS_EmpleadosHis();
            sel.MtdSeleccionarEmpleadosHisCuadrilla();
            if (sel.Exito && sel.Datos.Rows.Count>0)
            {
                int Fila = 6;
                for (int i = 0; i < sel.Datos.Rows.Count; i++)
                {
                    oRng = oSheet.get_Range("A" + Fila.ToString(), "A" + Fila.ToString());
                    oRng.Merge();
                    oRng.Value2 = sel.Datos.Rows[i]["Nombre_Empleado"].ToString();
                    oRng.Font.FontStyle = "Calibri";
                    oRng.Font.Size = 11;
                    oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    oRng.Font.Bold = false;
                    

                    oRng = oSheet.get_Range("B" + Fila.ToString(), "B" + Fila.ToString());
                    oRng.Merge();
                    oRng.Value2 = sel.Datos.Rows[i]["Dias_Trabajados"].ToString();
                    oRng.Font.FontStyle = "Calibri";
                    oRng.Font.Size = 11;
                    oRng.HorizontalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    oRng.Font.Bold = false;
                    oRng.NumberFormat = "#,##0";
                    Fila++;
                }
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
    }
}