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

namespace CuttingBusiness
{
    public partial class Frm_ServiciosODC : DevExpress.XtraEditors.XtraForm
    {
        GridControlCheckMarksSelection gridCheckMarksODC;
        string CadenaCodigos = null;
        StringBuilder sb = new StringBuilder();
        public Frm_ServiciosODC()
        {
            InitializeComponent();
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;
            column.DataType = typeof(DateTime);
            column.ColumnName = "col_Fecha";
            column.AutoIncrement = false;
            column.Caption = "Fecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_ODC";
            column.AutoIncrement = false;
            column.Caption = "ODC";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_Ubicacion";
            column.AutoIncrement = false;
            column.Caption = "Ubicacion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_Pesada";
            column.AutoIncrement = false;
            column.Caption = "Pesada";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_Placas";
            column.AutoIncrement = false;
            column.Caption = "Placas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_Huertas";
            column.AutoIncrement = false;
            column.Caption = "Huertas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_Productor";
            column.AutoIncrement = false;
            column.Caption = "Productor";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_Cajas";
            column.AutoIncrement = false;
            column.Caption = "Cajas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_Kilos";
            column.AutoIncrement = false;
            column.Caption = "Kilos";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_Variedad";
            column.AutoIncrement = false;
            column.Caption = "Variedad";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_JefeCuadrilla";
            column.AutoIncrement = false;
            column.Caption = "Jefe Cuadrilla";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_CajasZ";
            column.AutoIncrement = false;
            column.Caption = "CajasZ";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_FolioZ";
            column.AutoIncrement = false;
            column.Caption = "FolioZ";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "col_JefeArea";
            column.AutoIncrement = false;
            column.Caption = "Jefe Area";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            dtgServicios.DataSource = table;
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
        private void Frm_ServiciosODC_Shown(object sender, EventArgs e)
        {
            dtInicio.EditValue = DateTime.Now;
            dtFin.EditValue = DateTime.Now;
            GridMultipleODC();
            CadenaCodigos = string.Empty;
            gridCheckMarksODC.ClearSelection();
        }
        private void GridMultipleODC()
        {
            gridCheckMarksODC = new GridControlCheckMarksSelection(dtgValServicios);
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
                    sb.AppendFormat("{0}", rv["PSC_ODC"]);

                    if (CadenaCodigos != string.Empty)
                    {
                        CadenaCodigos = string.Format("{0},{1}", CadenaCodigos, rv["PSC_ODC"]);
                    }
                    else
                    {
                        CadenaCodigos = rv["PSC_ODC"].ToString();
                    }
                }
            }
            if (CadenaCodigos == string.Empty)
            {
                btnEliminar.Enabled = false;
                btnGenerarApoyo.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
                btnGenerarApoyo.Enabled = true;
            }
        }
        private void btnBuscarServicios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_ServiciosCortes sel = new CLS_ServiciosCortes();
            DateTime vFechaInicio = Convert.ToDateTime(dtInicio.EditValue.ToString());
            DateTime vFechaFin = Convert.ToDateTime(dtFin.EditValue.ToString());
            sel.Fecha_Inicio = vFechaInicio.Year.ToString() + DosCeros(vFechaInicio.Month.ToString()) + DosCeros(vFechaInicio.Day.ToString());
            sel.Fecha_Fin = vFechaFin.Year.ToString() + DosCeros(vFechaFin.Month.ToString()) + DosCeros(vFechaFin.Day.ToString());
            sel.MtdSeleccionarServicioCorteODC_Fechas();
            if (sel.Exito)
            {
                dtgServicios.DataSource = sel.Datos;
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea Eliminar los servicios seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                string[] ODC = CadenaCodigos.Split(',');
                int t = 0;
                foreach (string vOrden in ODC)
                {
                    for (int i = 0; i < dtgValServicios.RowCount; i++)
                    {
                        int xRow = dtgValServicios.GetVisibleRowHandle(i);
                        if (dtgValServicios.GetRowCellValue(xRow, "PSC_ODC").ToString() == vOrden)
                        {
                            string vfecha = dtgValServicios.GetRowCellValue(xRow, "PSC_Fecha").ToString();
                            DateTime DFecha = Convert.ToDateTime(vfecha);
                            vfecha = DFecha.Year.ToString() + DosCeros(DFecha.Month.ToString()) + DosCeros(DFecha.Day.ToString());
                            CLS_ServiciosCortes del = new CLS_ServiciosCortes();
                            del.PSC_Fecha = vfecha;
                            del.PSC_ODC = vOrden;
                            del.MtdEliminarServicioCorte();
                            if (!del.Exito)
                            {
                                XtraMessageBox.Show(del.Mensaje);
                            }
                            break;
                        }
                    }
                }
                btnBuscarServicios.PerformClick();
                CadenaCodigos = string.Empty;
                gridCheckMarksODC.ClearSelection();
            }
        }

        private void btnGenerarApoyo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea generar una cuadrilla de apoyo de los elementos seleccionados?", "Genera Cuadrilla", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                string[] ODC = CadenaCodigos.Split(',');
                int t = 0;
                foreach (string vOrden in ODC)
                {
                    for (int i = 0; i < dtgValServicios.RowCount; i++)
                    {
                        int xRow = dtgValServicios.GetVisibleRowHandle(i);
                        if (dtgValServicios.GetRowCellValue(xRow, "PSC_ODC").ToString() == vOrden)
                        {
                            string vFecha = dtgValServicios.GetRowCellValue(xRow, "PSC_Fecha").ToString();
                            string vODC = dtgValServicios.GetRowCellValue(xRow, "PSC_ODC").ToString();
                            string vUbicacion = dtgValServicios.GetRowCellValue(xRow, "PSC_Ubicacion").ToString();
                            string vPesada = dtgValServicios.GetRowCellValue(xRow, "PSC_Pesada").ToString();
                            string vPlacas = dtgValServicios.GetRowCellValue(xRow, "PSC_Placas").ToString();
                            string vHuertas = dtgValServicios.GetRowCellValue(xRow, "PSC_Huertas").ToString();
                            string vProductor = dtgValServicios.GetRowCellValue(xRow, "PSC_Productor").ToString();
                            string vCajas = dtgValServicios.GetRowCellValue(xRow, "PSC_Cajas").ToString();
                            string vKilos = dtgValServicios.GetRowCellValue(xRow, "PSC_Kilos").ToString();
                            string vVariedad = dtgValServicios.GetRowCellValue(xRow, "PSC_Variedad").ToString();
                            string vJefeCuadrilla = dtgValServicios.GetRowCellValue(xRow, "PSC_JefeCuadrilla").ToString();
                            string vCajasZ = dtgValServicios.GetRowCellValue(xRow, "PSC_CajasZ").ToString();
                            string vFolioZ = dtgValServicios.GetRowCellValue(xRow, "PSC_FolioZ").ToString();
                            string vJefeArea = dtgValServicios.GetRowCellValue(xRow, "PSC_JefeArea").ToString();
                            string vClaveDia = dtgValServicios.GetRowCellValue(xRow, "PSC_ClaveDia").ToString();

                            int Registros = BuscarOrdendeCorte(vODC);
                            CLS_ServiciosCortes ins = new CLS_ServiciosCortes();
                            DateTime DFecha = Convert.ToDateTime(vFecha);
                            vFecha = DFecha.Year.ToString() + DosCeros(DFecha.Month.ToString()) + DosCeros(DFecha.Day.ToString());
                            ins.PSC_Fecha = vFecha;
                            ins.PSC_ODC = vODC + "_" + Letra(Registros);
                            ins.PSC_Ubicacion = vUbicacion;
                            ins.PSC_Pesada = vPesada;
                            ins.PSC_Placas = vPlacas;
                            ins.PSC_Huertas = vHuertas;
                            ins.PSC_Productor = vProductor;
                            ins.PSC_Cajas = vCajas;
                            ins.PSC_Kilos = vKilos;
                            ins.PSC_Variedad = vVariedad;
                            ins.PSC_JefeCuadrilla = vJefeCuadrilla;
                            ins.PSC_CajasZ = vCajasZ;
                            ins.PSC_FolioZ = vFolioZ;
                            ins.PSC_JefeArea = vJefeArea;
                            ins.PSC_ClaveDia = vClaveDia;
                            ins.MtdInsertarServiciosCortes();
                            if (!ins.Exito)
                            {
                                XtraMessageBox.Show(ins.Mensaje);
                            }
                        }
                    }
                }
                btnBuscarServicios.PerformClick();
                CadenaCodigos = string.Empty;
                gridCheckMarksODC.ClearSelection();
            }
        }

        private int BuscarOrdendeCorte(string vODC)
        {
            int valor = 0;
            CLS_ServiciosCortes sel = new CLS_ServiciosCortes();
            sel.PSC_ODC = vODC;
            sel.MtdSeleccionarServicioCorteODCCont();
            if (sel.Exito)
            {
                valor = Convert.ToInt32(sel.Datos.Rows[0]["Registros"].ToString());
            }
            return valor;
        }

        private string Letra(int registros)
        {
            string valor = string.Empty;
            switch (registros)
            {
                case 1:
                    valor = "A";
                    break;
                case 2:
                    valor = "B";
                    break;
                case 3:
                    valor = "C";
                    break;
                case 4:
                    valor = "D";
                    break;
                case 5:
                    valor = "E";
                    break;
                case 6:
                    valor = "F";
                    break;
            }
            return valor;
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dtgValServicios.RowCount > 0)
            {
                //pgbProgreso.Properties.Maximum = dtgValServicios.RowCount;
                //pgbProgreso.Position = 0;

                for (int x = 0; x < dtgValServicios.RowCount; x++)
                {
                    int xRow = dtgValServicios.GetVisibleRowHandle(x);
                    //pgbProgreso.Position = x + 1;
                    Application.DoEvents();

                    CLS_ServiciosCortes ins = new CLS_ServiciosCortes();
                    DateTime DFecha = Convert.ToDateTime(dtgValServicios.GetRowCellValue(xRow, "PSC_Fecha").ToString());
                    string vFecha = DFecha.Year.ToString() + DosCeros(DFecha.Month.ToString()) + DosCeros(DFecha.Day.ToString());
                    ins.PSC_Fecha = vFecha;
                    ins.PSC_ODC = dtgValServicios.GetRowCellValue(xRow, "PSC_ODC").ToString();
                    ins.PSC_Ubicacion = dtgValServicios.GetRowCellValue(xRow, "PSC_Ubicacion").ToString();
                    ins.PSC_Pesada = dtgValServicios.GetRowCellValue(xRow, "PSC_Pesada").ToString();
                    ins.PSC_Placas = dtgValServicios.GetRowCellValue(xRow, "PSC_Placas").ToString();
                    ins.PSC_Huertas = dtgValServicios.GetRowCellValue(xRow, "PSC_Huertas").ToString();
                    ins.PSC_Productor = dtgValServicios.GetRowCellValue(xRow, "PSC_Productor").ToString();
                    ins.PSC_Cajas = dtgValServicios.GetRowCellValue(xRow, "PSC_Cajas").ToString();
                    ins.PSC_Kilos = dtgValServicios.GetRowCellValue(xRow, "PSC_Kilos").ToString();
                    ins.PSC_Variedad = dtgValServicios.GetRowCellValue(xRow, "PSC_Variedad").ToString();
                    ins.PSC_JefeCuadrilla = dtgValServicios.GetRowCellValue(xRow, "PSC_JefeCuadrilla").ToString();
                    ins.PSC_CajasZ = dtgValServicios.GetRowCellValue(xRow, "PSC_CajasZ").ToString();
                    ins.PSC_FolioZ = dtgValServicios.GetRowCellValue(xRow, "PSC_FolioZ").ToString();
                    ins.PSC_JefeArea = dtgValServicios.GetRowCellValue(xRow, "PSC_JefeArea").ToString();
                    ins.PSC_ClaveDia = dtgValServicios.GetRowCellValue(xRow, "PSC_ClaveDia").ToString();
                    ins.MtdUpdateServiciosCortes();
                    if (!ins.Exito)
                    {
                        XtraMessageBox.Show(ins.Mensaje);
                    }
                    else
                    {
                        XtraMessageBox.Show("Se ha modificado el registro con Exito");
                    }
                }
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}

