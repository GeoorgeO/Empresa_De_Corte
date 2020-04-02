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

namespace CuttingBusiness.Control
{
    public partial class Frm_LiberarNomina : DevExpress.XtraEditors.XtraForm
    {
        GridControlCheckMarksSelection gridCheckMarksODC;
        string CadenaCodigos = null;
        StringBuilder sb = new StringBuilder();
        public Frm_LiberarNomina()
        {
            InitializeComponent();
        }
        private void MakeTablaPedidos()
        {
            DataTable table = new DataTable("FirstTable");
            DataColumn column = new DataColumn();
            table.Reset();

            // DataRow row;
            column.DataType = typeof(string);
            column.ColumnName = "Id_HojaNomina";
            column.AutoIncrement = false;
            column.Caption = "Fecha";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(DateTime);
            column.ColumnName = "Fecha_HojaNomina";
            column.AutoIncrement = false;
            column.Caption = "ODC";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Id_Cuadrilla";
            column.AutoIncrement = false;
            column.Caption = "Ubicacion";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Nombre_Empleado";
            column.AutoIncrement = false;
            column.Caption = "Pesada";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Total_cortadores";
            column.AutoIncrement = false;
            column.Caption = "Placas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Total_Cajas";
            column.AutoIncrement = false;
            column.Caption = "Huertas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Total_Importe";
            column.AutoIncrement = false;
            column.Caption = "Productor";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Estatus";
            column.AutoIncrement = false;
            column.Caption = "Cajas";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = "Nombre_Categoria";
            column.AutoIncrement = false;
            column.Caption = "Kilos";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);
            dtgNominas.DataSource = table;
        }
        private void btnBuscarNominas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarHojas();
        }
        private void CargarHojas()
        {
            dtgNominas.DataSource = null;
            CLS_HojaNomina Clase = new CLS_HojaNomina();
            DateTime Fecha;
            Fecha = Convert.ToDateTime(dtInicio.EditValue);
            Clase.del = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            Fecha = Convert.ToDateTime(dtFin.EditValue);
            Clase.al = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            Clase.MtdSeleccionarHojasNomina();
            if (Clase.Exito)
            {
                dtgNominas.DataSource = Clase.Datos;
            }
        }

        private void Frm_LiberarNomina_Shown(object sender, EventArgs e)
        {
            dtInicio.DateTime = DateTime.Now;
            dtFin.DateTime = DateTime.Now;
            GridMultipleODC();
            CadenaCodigos = string.Empty;
            gridCheckMarksODC.ClearSelection();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtInicio.DateTime = DateTime.Now;
            dtFin.DateTime = DateTime.Now;
            dtgNominas.DataSource = null;
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
        private void GridMultipleODC()
        {
            gridCheckMarksODC = new GridControlCheckMarksSelection(dtgValNominas);
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
                btnLiberar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
                btnLiberar.Enabled = true;
            }
        }
    }
}