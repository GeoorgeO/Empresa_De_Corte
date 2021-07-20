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
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;

namespace CuttingBusiness
{
    public partial class Frm_Paramatros_ReportesNom : DevExpress.XtraEditors.XtraForm
    {
        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");

        public string vIdTemp { get;  set; }
        public int vDias_Trabajo=0;
        public decimal vSueldo_Bruto=0;
        private decimal vISR=0;
        private decimal vSueldo_Neto=0;

        public bool PrimeraEdicionBC { get; private set; }
        public bool PrimeraEdicionBJ { get; private set; }
        public bool PrimeraEdicionCC { get; private set; }
        public bool PrimeraEdicionCJ { get; private set; }
        public string DiaAnterior { get;  set; }

        public Frm_Paramatros_ReportesNom()
        {
            InitializeComponent();
        }
        private void MakeTablaReportesBC()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id";
            column.AutoIncrement = false;
            column.Caption = "Id";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Tipo_Empleado";
            column.AutoIncrement = false;
            column.Caption = "Tipo Empleado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Dias_trabajo";
            column.AutoIncrement = false;
            column.Caption = "Dias trabajo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Sueldo_Bruto";
            column.AutoIncrement = false;
            column.Caption = "Sueldo_Bruto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgFormatBC.DataSource = table;
        }
        private void MakeTablaReportesBJ()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id";
            column.AutoIncrement = false;
            column.Caption = "Id";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Tipo_Empleado";
            column.AutoIncrement = false;
            column.Caption = "Tipo Empleado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Dias_trabajo";
            column.AutoIncrement = false;
            column.Caption = "Dias trabajo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Sueldo_Bruto";
            column.AutoIncrement = false;
            column.Caption = "Sueldo_Bruto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgFormatBJ.DataSource = table;
        }
        private void MakeTablaReportesCC()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id";
            column.AutoIncrement = false;
            column.Caption = "Id";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Tipo_Empleado";
            column.AutoIncrement = false;
            column.Caption = "Tipo Empleado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Dias_trabajo";
            column.AutoIncrement = false;
            column.Caption = "Dias trabajo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Sueldo_Bruto";
            column.AutoIncrement = false;
            column.Caption = "Sueldo Bruto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "ISR";
            column.AutoIncrement = false;
            column.Caption = "ISR";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Sueldo_Neto";
            column.AutoIncrement = false;
            column.Caption = "Sueldo Neto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgFormatCC.DataSource = table;
        }
        private void MakeTablaReportesCJ()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            table.Reset();

            // DataRow row;
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id";
            column.AutoIncrement = false;
            column.Caption = "Id";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Tipo_Empleado";
            column.AutoIncrement = false;
            column.Caption = "Tipo Empleado";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "Dias_trabajo";
            column.AutoIncrement = false;
            column.Caption = "Dias trabajo";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Sueldo_Bruto";
            column.AutoIncrement = false;
            column.Caption = "Sueldo Bruto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "ISR";
            column.AutoIncrement = false;
            column.Caption = "ISR";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(decimal);
            column.ColumnName = "Sueldo_Neto";
            column.AutoIncrement = false;
            column.Caption = "Sueldo Neto";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgFormatCJ.DataSource = table;
        }
        private void Frm_Paramatros_ReportesNom_Shown(object sender, EventArgs e)
        {
            MakeTablaReportesBC();
            MakeTablaReportesBJ();
            MakeTablaReportesCC();
            MakeTablaReportesCJ();
            DarFormatoColumnas();
            dtgFormatBC.DataSource = Cargar_FormatoB("C");
            dtgFormatBJ.DataSource = Cargar_FormatoB("J");
            dtgFormatCC.DataSource = Cargar_FormatoC("C");
            dtgFormatCJ.DataSource = Cargar_FormatoC("J");
            PrimeraEdicionBC = false;
            PrimeraEdicionBJ = false;
            PrimeraEdicionCC = false;
            PrimeraEdicionCJ = false;
        }

        private void DarFormatoColumnas()
        {
            colDiasTBC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiasTBC.DisplayFormat.FormatString = "n0";
            colDiasTBJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiasTBJ.DisplayFormat.FormatString = "n0";
            colDiasTCC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiasTCC.DisplayFormat.FormatString = "n0";
            colDiasTCJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colDiasTCJ.DisplayFormat.FormatString = "n0";
            dtgSueldoBBC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            dtgSueldoBBC.DisplayFormat.FormatString = "c2";
            dtgSueldoBBJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            dtgSueldoBBJ.DisplayFormat.FormatString = "c2";
            dtgSueldoBCC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            dtgSueldoBCC.DisplayFormat.FormatString = "c2";
            dtgSueldoBCJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            dtgSueldoBCJ.DisplayFormat.FormatString = "c2";
            dtgISRCC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            dtgISRCC.DisplayFormat.FormatString = "c2";
            dtgISRCJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            dtgISRCJ.DisplayFormat.FormatString = "c2";
            colSueldoNCC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSueldoNCC.DisplayFormat.FormatString = "c2";
            colSueldoNCJ.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colSueldoNCJ.DisplayFormat.FormatString = "c2";
            dtgValFormatBC.OptionsBehavior.Editable = true;
            dtgValFormatBC.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValFormatBC.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            dtgValFormatBJ.OptionsBehavior.Editable = true;
            dtgValFormatBJ.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValFormatBJ.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            dtgValFormatCC.OptionsBehavior.Editable = true;
            dtgValFormatCC.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValFormatCC.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            dtgValFormatCJ.OptionsBehavior.Editable = true;
            dtgValFormatCJ.OptionsSelection.EnableAppearanceFocusedCell = false;
            dtgValFormatCJ.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        }

        private DataTable Cargar_FormatoB(string TipoEmpleado)
        {
            DataTable Valor= null;
            CLS_Parametros_Reportes sel = new CLS_Parametros_Reportes();
            sel.Tipo_Empleado = TipoEmpleado;
            sel.MtdSeleccionarParametrosB();
            if(sel.Exito)
            {
                Valor = sel.Datos;
            }
            return Valor;
        }
        private DataTable Cargar_FormatoC(string TipoEmpleado)
        {
            DataTable Valor = null;
            CLS_Parametros_Reportes sel = new CLS_Parametros_Reportes();
            sel.Tipo_Empleado = TipoEmpleado;
            sel.MtdSeleccionarParametrosC();
            if (sel.Exito)
            {
                Valor = sel.Datos;
            }
            return Valor;
        }

        private void dtgValFormatBC_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFormatBC.GetSelectedRows())
                {
                    DataRow row = dtgValFormatBC.GetDataRow(i);
                    vIdTemp = row["Id"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgValFormatBJ_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFormatBJ.GetSelectedRows())
                {
                    DataRow row = dtgValFormatBJ.GetDataRow(i);
                    vIdTemp = row["Id"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgValFormatCC_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFormatCC.GetSelectedRows())
                {
                    DataRow row = dtgValFormatCC.GetDataRow(i);
                    vIdTemp = row["Id"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgValFormatCJ_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFormatCJ.GetSelectedRows())
                {
                    DataRow row = dtgValFormatCJ.GetDataRow(i);
                    vIdTemp = row["Id"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgValFormatBC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicionBC == true)
            {
                if (e.Column.FieldName == "Dias_trabajo" || e.Column.FieldName == "Sueldo_Bruto")
                {

                    PrimeraEdicionBC = true;
                    GridView gv = sender as GridView;
                    int.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Dias_trabajo"]).ToString(), style, culture, out vDias_Trabajo);
                    decimal.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Sueldo_Bruto"]).ToString(), style, culture, out vSueldo_Bruto);
                    string vId=gv.GetRowCellValue(e.RowHandle, gv.Columns["Id"]).ToString();
                    Boolean ValidaDato = true;
                    if (e.Column.FieldName == "Dias_trabajo")
                    {
                        ValidaDato = ValidaDiasBC(vDias_Trabajo,vId);
                    }
                    if (ValidaDato)
                    {
                        CLS_Parametros_Reportes udp = new CLS_Parametros_Reportes();
                        udp.Dias_trabajo = vDias_Trabajo;
                        udp.Sueldo_Bruto = vSueldo_Bruto;
                        udp.Tipo_Empleado = "C";
                        udp.Id = vIdTemp;
                        udp.MtdUpdateParametrosB();
                        if (!udp.Exito)
                        {
                            XtraMessageBox.Show(udp.Mensaje);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ya existe este dia de trabajo");
                        gv.SetRowCellValue(e.RowHandle, gv.Columns["Dias_trabajo"], DiaAnterior);
                    }
                    PrimeraEdicionBC = false;
                }
            }
        }

        private bool ValidaDiasBC(int VDia, string Id)
        {
            Boolean Valor = true;
            CLS_Parametros_Reportes sel = new CLS_Parametros_Reportes();
            sel.Tipo_Empleado = "C";
            sel.MtdSeleccionarParametrosB();
            if (sel.Exito)
            {
                for (int i = 0; i < sel.Datos.Rows.Count; i++)
                {
                    if (sel.Datos.Rows[i]["Id"].ToString() != Id)
                    {
                        if (sel.Datos.Rows[i]["Dias_trabajo"].ToString() == VDia.ToString())
                        {
                            Valor = false;
                            break;
                        }
                    }
                }
            }
            return Valor;
        }

        private void dtgValFormatBJ_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicionBJ == true)
            {
                if (e.Column.FieldName == "Dias_trabajo" || e.Column.FieldName == "Sueldo_Bruto")
                {
                    PrimeraEdicionBJ = true;
                    GridView gv = sender as GridView;
                    int.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Dias_trabajo"]).ToString(), style, culture, out vDias_Trabajo);
                    decimal.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Sueldo_Bruto"]).ToString(), style, culture, out vSueldo_Bruto);
                    string vId = gv.GetRowCellValue(e.RowHandle, gv.Columns["Id"]).ToString();
                    Boolean ValidaDato = true;
                    if (e.Column.FieldName == "Dias_trabajo")
                    {
                        ValidaDato = ValidaDiasBJ(vDias_Trabajo,vId);
                    }
                    if (ValidaDato)
                    {
                        CLS_Parametros_Reportes udp = new CLS_Parametros_Reportes();
                        udp.Dias_trabajo = vDias_Trabajo;
                        udp.Sueldo_Bruto = vSueldo_Bruto;
                        udp.Tipo_Empleado = "J";
                        udp.Id = vIdTemp;
                        udp.MtdUpdateParametrosB();
                        if (!udp.Exito)
                        {
                            XtraMessageBox.Show(udp.Mensaje);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ya existe este dia de trabajo");
                        gv.SetRowCellValue(e.RowHandle, gv.Columns["Dias_trabajo"], DiaAnterior);
                    }
                    PrimeraEdicionBJ = false;
                }
            }
        }

        private bool ValidaDiasBJ(int VDia, string Id)
        {
            Boolean Valor = true;
            CLS_Parametros_Reportes sel = new CLS_Parametros_Reportes();
            sel.Tipo_Empleado = "J";
            sel.MtdSeleccionarParametrosB();
            if (sel.Exito)
            {
                for (int i = 0; i < sel.Datos.Rows.Count; i++)
                {
                    if (sel.Datos.Rows[i]["Id"].ToString() != Id)
                    {
                        if (sel.Datos.Rows[i]["Dias_trabajo"].ToString() == VDia.ToString())
                        {
                            Valor = false;
                            break;
                        }
                    }
                }
            }
            return Valor;
        }

        private void dtgValFormatCC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicionCC == true)
            {
                if (e.Column.FieldName == "Dias_trabajo" || e.Column.FieldName == "Sueldo_Bruto" || e.Column.FieldName == "ISR")
                {
                    PrimeraEdicionCC = true;
                    GridView gv = sender as GridView;
                    int.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Dias_trabajo"]).ToString(), style, culture, out vDias_Trabajo);
                    decimal.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Sueldo_Bruto"]).ToString(), style, culture, out vSueldo_Bruto);
                    decimal.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["ISR"]).ToString(), style, culture, out vISR);
                    string vId = gv.GetRowCellValue(e.RowHandle, gv.Columns["Id"]).ToString();
                    vSueldo_Neto = vSueldo_Bruto - vISR;
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["Sueldo_Neto"], vSueldo_Neto);
                    Boolean ValidaDato = true;
                    if (e.Column.FieldName == "Dias_trabajo")
                    {
                        ValidaDato = ValidaDiasCC(vDias_Trabajo,vId);
                    }
                    if (ValidaDato)
                    {
                        CLS_Parametros_Reportes udp = new CLS_Parametros_Reportes();
                        udp.Dias_trabajo = vDias_Trabajo;
                        udp.Sueldo_Bruto = vSueldo_Bruto;
                        udp.ISR = vISR;
                        udp.Sueldo_Neto = vSueldo_Neto;
                        udp.Tipo_Empleado = "C";
                        udp.Id = vIdTemp;
                        udp.MtdUpdateParametrosC();
                        if (!udp.Exito)
                        {
                            XtraMessageBox.Show(udp.Mensaje);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ya existe este dia de trabajo");
                        gv.SetRowCellValue(e.RowHandle, gv.Columns["Dias_trabajo"], DiaAnterior);
                    }
                    PrimeraEdicionCC = false;
                }
            }
        }

        private bool ValidaDiasCC(int vDia, string Id)
        {
            Boolean Valor = true;
            CLS_Parametros_Reportes sel = new CLS_Parametros_Reportes();
            sel.Tipo_Empleado = "C";
            sel.MtdSeleccionarParametrosB();
            if (sel.Exito)
            {
                for (int i = 0; i < sel.Datos.Rows.Count; i++)
                {
                    if (sel.Datos.Rows[i]["Id"].ToString() != Id)
                    {
                        if (sel.Datos.Rows[i]["Dias_trabajo"].ToString() == vDia.ToString())
                        {
                            Valor = false;
                            break;
                        }
                    }
                }
            }
            return Valor;
        }

        private void dtgValFormatCJ_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (!PrimeraEdicionCJ == true)
            {
                if (e.Column.FieldName == "Dias_trabajo" || e.Column.FieldName == "Sueldo_Bruto" || e.Column.FieldName == "ISR")
                {
                    
                    PrimeraEdicionCJ = true;
                    GridView gv = sender as GridView;
                    int.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Dias_trabajo"]).ToString(), style, culture, out vDias_Trabajo);
                    decimal.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["Sueldo_Bruto"]).ToString(), style, culture, out vSueldo_Bruto);
                    decimal.TryParse(gv.GetRowCellValue(e.RowHandle, gv.Columns["ISR"]).ToString(), style, culture, out vISR);
                    string vId = gv.GetRowCellValue(e.RowHandle, gv.Columns["Id"]).ToString();
                    vSueldo_Neto = vSueldo_Bruto - vISR;
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["Sueldo_Neto"], vSueldo_Neto);
                    Boolean ValidaDato = true;
                    if (e.Column.FieldName == "Dias_trabajo")
                    {
                        ValidaDato = ValidaDiasCJ(vDias_Trabajo,vId);
                    }
                    if (ValidaDato)
                    {
                        CLS_Parametros_Reportes udp = new CLS_Parametros_Reportes();
                        udp.Dias_trabajo = vDias_Trabajo;
                        udp.Sueldo_Bruto = vSueldo_Bruto;
                        udp.ISR = vISR;
                        udp.Sueldo_Neto = vSueldo_Neto;
                        udp.Tipo_Empleado = "J";
                        udp.Id = vIdTemp;
                        udp.MtdUpdateParametrosC();
                        if (!udp.Exito)
                        {
                            XtraMessageBox.Show(udp.Mensaje);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ya existe este dia de trabajo");
                        gv.SetRowCellValue(e.RowHandle, gv.Columns["Dias_trabajo"], DiaAnterior);
                    }
                    PrimeraEdicionCJ = false;
                }
            }
        }

        private bool ValidaDiasCJ(int vDia, string Id)
        {
            Boolean Valor = true;
            CLS_Parametros_Reportes sel = new CLS_Parametros_Reportes();
            sel.Tipo_Empleado = "J";
            sel.MtdSeleccionarParametrosB();
            if (sel.Exito)
            {
                for (int i = 0; i < sel.Datos.Rows.Count; i++)
                {
                    if (sel.Datos.Rows[i]["Id"].ToString() != Id)
                    {
                        if (sel.Datos.Rows[i]["Dias_trabajo"].ToString() == vDia.ToString())
                        {
                            Valor = false;
                            break;
                        }
                    }
                }
            }
            return Valor;
        }

        private void dtgFormatBC_ShowingEditor(object sender, CancelEventArgs e)
        {

        }

        private void dtgFormatBJ_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFormatBJ.GetSelectedRows())
                {
                    DataRow row = this.dtgValFormatBJ.GetDataRow(i);
                    DiaAnterior = row["Dias_trabajo"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgFormatCC_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFormatCC.GetSelectedRows())
                {
                    DataRow row = this.dtgValFormatCC.GetDataRow(i);
                    DiaAnterior = row["Dias_trabajo"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgFormatCJ_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFormatCJ.GetSelectedRows())
                {
                    DataRow row = this.dtgValFormatCJ.GetDataRow(i);
                    DiaAnterior = row["Dias_trabajo"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void dtgValFormatBC_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValFormatBC.GetSelectedRows())
                {
                    DataRow row = this.dtgValFormatBC.GetDataRow(i);
                    DiaAnterior = row["Dias_trabajo"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }
    }
}