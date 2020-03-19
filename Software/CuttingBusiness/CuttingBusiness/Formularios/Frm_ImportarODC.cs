using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CapaDeDatos;
using SpreadsheetLight;
using System.Data;
using CapaDeDatos;

namespace CuttingBusiness
{

    public partial class Frm_ImportarODC : DevExpress.XtraEditors.XtraForm
    {
        int rCnt = 0;
        int cCnt = 0;
        public int Col_PSC_Fecha { get; set; }
        public int Col_PSC_ODC { get; set; }
        public int Col_PSC_Ubicacion { get; set; }
        public int Col_PSC_Pesada { get; set; }
        public int Col_PSC_Placas { get; set; }
        public int Col_PSC_Huertas { get; set; } 
        public int Col_PSC_Productor { get; set; }
        public int Col_PSC_Cajas { get; set; }
        public int Col_PSC_Kilos { get; set; }
        public int Col_PSC_Variedad { get; set; }
        public int Col_PSC_JefeCuadrilla { get; set; }
        public int Col_PSC_CajasZ { get; set; }
        public int Col_PSC_FolioZ { get; set; }
        public int Col_PSC_JefeArea { get; set; }
        public int Col_PSC_ClaveDia { get; set; }

        
        public Frm_ImportarODC()
        {
            InitializeComponent();
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
        private void CreatNewRowArticulo(string Col_PSC_Fecha ,string Col_PSC_ODC,string Col_PSC_Ubicacion ,string Col_PSC_Pesada , string Col_PSC_Placas , string Col_PSC_Huertas,
                                         string Col_PSC_Productor , string Col_PSC_Cajas , string Col_PSC_Kilos , string Col_PSC_Variedad , string Col_PSC_JefeCuadrilla , string Col_PSC_CajasZ ,
                                         string Col_PSC_FolioZ , string Col_PSC_JefeArea )
        {
            dtgValServicios.AddNewRow();

            int rowHandle = dtgValServicios.GetRowHandle(dtgValServicios.DataRowCount);
            if (dtgValServicios.IsNewItemRow(rowHandle))
            {
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Fecha"], Col_PSC_Fecha);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_ODC"], Col_PSC_ODC);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Ubicacion"], Col_PSC_Ubicacion);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Pesada"], Col_PSC_Pesada);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Placas"], Col_PSC_Placas);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Huertas"], Col_PSC_Huertas);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Productor"], Col_PSC_Productor);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Cajas"], Col_PSC_Cajas);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Kilos"], Col_PSC_Kilos);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_Variedad"], Col_PSC_Variedad);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_JefeCuadrilla"], Col_PSC_JefeCuadrilla);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_CajasZ"], Col_PSC_CajasZ);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_FolioZ"], Col_PSC_FolioZ);
                dtgValServicios.SetRowCellValue(rowHandle, dtgValServicios.Columns["col_JefeArea"], Col_PSC_JefeArea);
            }
        }

        private void spreadsheetCommandBarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Frm_ImportarODC_Shown(object sender, EventArgs e)
        {
            MakeTablaPedidos();
        }

        private void btnCargarExcel_Click(object sender, EventArgs e)
        {
            
        }
        private Boolean CargarPosicionColumnas()
        {
            Boolean Valor = false;
            ColumnasExcel sel = new ColumnasExcel();
            sel.MtdSeleccionar();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    Col_PSC_Fecha = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Fecha"].ToString());
                    Col_PSC_ODC = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_ODC"].ToString());
                    Col_PSC_Ubicacion = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Ubicacion"].ToString());
                    Col_PSC_Pesada = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Pesada"].ToString());
                    Col_PSC_Pesada = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Pesada"].ToString());
                    Col_PSC_Placas = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Placas"].ToString());
                    Col_PSC_Huertas = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Huertas"].ToString());
                    Col_PSC_Productor = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Productor"].ToString());
                    Col_PSC_Cajas = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Cajas"].ToString());
                    Col_PSC_Kilos = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Kilos"].ToString());
                    Col_PSC_Variedad = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_Variedad"].ToString());
                    Col_PSC_JefeCuadrilla = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_JefeCuadrilla"].ToString());
                    Col_PSC_CajasZ = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_CajasZ"].ToString());
                    Col_PSC_FolioZ = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_FolioZ"].ToString());
                    Col_PSC_JefeArea = Convert.ToInt32(sel.Datos.Rows[0]["Col_PSC_JefeArea"].ToString());
                    Valor = true;
                }
            }
            return Valor;
        }

        private void btnParametros_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_Parametros_PSC frm = new Frm_Parametros_PSC();
            frm.ShowDialog();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MakeTablaPedidos();
            txtHoja.Text = string.Empty;
            txtClave.Text = string.Empty;
        }

        private void btnImportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int contadorins = 0;
            if (txtHoja.Text!=string.Empty && txtClave.Text!=string.Empty)
            {
                if (dtgValServicios.RowCount > 0)
                {
                    pgbProgreso.Properties.Maximum = dtgValServicios.RowCount;
                    pgbProgreso.Position = 0;
                    
                    for (int x = 0; x < dtgValServicios.RowCount; x++)
                    {
                        int xRow = dtgValServicios.GetVisibleRowHandle(x);
                        pgbProgreso.Position = x + 1;
                        Application.DoEvents();
                        string vFecha = dtgValServicios.GetRowCellValue(xRow, "col_Fecha").ToString();
                        string vODC = dtgValServicios.GetRowCellValue(xRow, "col_ODC").ToString();
                        string vUbicacion = dtgValServicios.GetRowCellValue(xRow, "col_Ubicacion").ToString();
                        string vPesada = dtgValServicios.GetRowCellValue(xRow, "col_Pesada").ToString();
                        string vPlacas = dtgValServicios.GetRowCellValue(xRow, "col_Placas").ToString();
                        string vHuertas = dtgValServicios.GetRowCellValue(xRow, "col_Huertas").ToString();
                        string vProductor = dtgValServicios.GetRowCellValue(xRow, "col_Productor").ToString();
                        string vCajas = dtgValServicios.GetRowCellValue(xRow, "col_Cajas").ToString();
                        string vKilos = dtgValServicios.GetRowCellValue(xRow, "col_Kilos").ToString();
                        string vVariedad = dtgValServicios.GetRowCellValue(xRow, "col_Variedad").ToString();
                        string vJefeCuadrilla = dtgValServicios.GetRowCellValue(xRow, "col_JefeCuadrilla").ToString();
                        string vCajasZ = dtgValServicios.GetRowCellValue(xRow, "col_CajasZ").ToString();
                        string vFolioZ = dtgValServicios.GetRowCellValue(xRow, "col_FolioZ").ToString();
                        string vJefeArea = dtgValServicios.GetRowCellValue(xRow, "col_JefeArea").ToString();
                        if (!BuscarRegistro(vFecha, vODC))
                        {
                            CLS_ServiciosCortes ins = new CLS_ServiciosCortes();
                            DateTime DFecha = Convert.ToDateTime(vFecha);
                            vFecha = DFecha.Year.ToString() + DosCeros(DFecha.Month.ToString()) + DosCeros(DFecha.Day.ToString());
                            ins.PSC_Fecha = vFecha;
                            ins.PSC_ODC = vODC;
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
                            ins.PSC_ClaveDia = txtHoja.Text + txtClave.Text;
                            ins.MtdInsertarServiciosCortes();
                            if (!ins.Exito)
                            {
                                XtraMessageBox.Show(ins.Mensaje);
                            }
                            else
                            {
                                contadorins++;
                            }
                        }
                    }
                    XtraMessageBox.Show("Se importaron " + contadorins + " de " + dtgValServicios.RowCount);
                    btnLimpiar.PerformClick();
                }
                else
                {
                    XtraMessageBox.Show("No existen registros para importar");
                }
            }
            else
            {
                XtraMessageBox.Show("Se debe capturar Hoja y Clave");
            }
        }

        private bool BuscarRegistro(string vFecha, string vODC)
        {
            Boolean Valor = false;
            DateTime fecha = Convert.ToDateTime(vFecha);
            vFecha = fecha.Year.ToString() + DosCeros(fecha.Month.ToString()) + DosCeros(fecha.Day.ToString());
            CLS_ServiciosCortes sel = new CLS_ServiciosCortes();
            sel.PSC_Fecha = vFecha;
            sel.PSC_ODC = vODC;
            sel.MtdSeleccionarServicioCorteODC();
            if(sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0)
                {
                    Valor = true;
                }
            }
            return Valor;
        }

        private void btnExaminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CargarPosicionColumnas())
            {
                OpenDialog.Filter = "Formato de Excel XLSX (*.xlsx)|*.xlsx|Formato de Excel XLS (*.xls)|*.xls";
                OpenDialog.FilterIndex = 1;
                OpenDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); ;
                OpenDialog.Title = "Cargar Documento Excel";
                OpenDialog.CheckFileExists = false;
                OpenDialog.Multiselect = false;
                DialogResult result = OpenDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtRutaArchivo.Text = OpenDialog.FileName;
                    var str = string.Empty;
                    rCnt = 0;
                    cCnt = 0;
                    try
                    {
                        rCnt = 2;
                        SLDocument s1 = new SLDocument(OpenDialog.FileName);
                        int celdas = 0;
                        while (!String.IsNullOrEmpty(s1.GetCellValueAsString(rCnt, 1)))
                        {
                            celdas++;
                            rCnt++;
                        }
                        pgbProgreso.Properties.Maximum = celdas;
                        rCnt = 2;
                        while (!String.IsNullOrEmpty(s1.GetCellValueAsString(rCnt, 1)))
                        {
                            pgbProgreso.Position = rCnt;
                            Application.DoEvents();
                            string vFecha = s1.GetCellValueAsDateTime(rCnt, Col_PSC_Fecha).ToString();
                            string vODC = s1.GetCellValueAsString(rCnt, Col_PSC_ODC);
                            string vUbicacion = s1.GetCellValueAsString(rCnt, Col_PSC_Ubicacion);
                            string vPesada = s1.GetCellValueAsString(rCnt, Col_PSC_Pesada);
                            string vPlacas = s1.GetCellValueAsString(rCnt, Col_PSC_Placas);
                            string vHuertas = s1.GetCellValueAsString(rCnt, Col_PSC_Huertas);
                            string vProductor = s1.GetCellValueAsString(rCnt, Col_PSC_Productor);
                            string vCajas = s1.GetCellValueAsString(rCnt, Col_PSC_Cajas);
                            string vKilos = s1.GetCellValueAsString(rCnt, Col_PSC_Kilos);
                            string vVariedad = s1.GetCellValueAsString(rCnt, Col_PSC_Variedad);
                            string vJefeCuadrilla = s1.GetCellValueAsString(rCnt, Col_PSC_JefeCuadrilla);
                            string vCajasZ = s1.GetCellValueAsString(rCnt, Col_PSC_CajasZ);
                            string vFolioZ = s1.GetCellValueAsString(rCnt, Col_PSC_FolioZ);
                            string vJefeArea = s1.GetCellValueAsString(rCnt, Col_PSC_JefeArea);
                            CreatNewRowArticulo(vFecha, vODC, vUbicacion, vPesada, vPlacas, vHuertas, vProductor, vCajas, vKilos, vVariedad, vJefeCuadrilla, vCajasZ, vFolioZ, vJefeArea);
                            rCnt++;
                        }
                        pgbProgreso.Position = 0;
                    }
                    catch (Exception EX)
                    {
                        XtraMessageBox.Show(EX.Message);
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("No se pudo tener acceso a los parametros para las posiciones de Excel");
            }
        }

        private void btnBuscarServicios_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_ServiciosODC frm = new Frm_ServiciosODC();
            frm.Show();
        }
    }
}