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
using DevExpress.XtraGrid.Columns;

namespace CuttingBusiness
{
    public partial class Frm_AbrirHoja : DevExpress.XtraEditors.XtraForm
    {
        public string HojaSeleccionada { get; set; }

        public string fini { get; set; }
        public string ffin { get; set; }
        public string categoria { get; set; }

public Frm_AbrirHoja()
        {
            InitializeComponent();
        }

        private void Frm_AbrirHoja_Load(object sender, EventArgs e)
        {
            

            HojaSeleccionada = String.Empty;
            dateDel.EditValue = DateTime.Now.AddDays(-30);
            dateAl.EditValue = DateTime.Now;

            if (fini != null)
            {
                dateDel.EditValue = Convert.ToDateTime(fini);
            }
            if (ffin != null)
            {
                dateAl.EditValue = Convert.ToDateTime(ffin);
            }
            if (categoria != null)
            {
                lueCuadrillas.EditValue = categoria;
            }

            radioGroup1.EditValue = "A";

            CargarHojas();

            CargarCategoriasCuadrilla();

            
        }

        private void CargarCategoriasCuadrilla()
        {
            lueCuadrillas.Properties.DataSource = null;
            CLS_CategoriasCuadrilla Clase = new CLS_CategoriasCuadrilla();

            Clase.MtdSeleccionarCategoriasCuadrilla();
            if (Clase.Exito)
            {
                lueCuadrillas.Properties.DataSource = Clase.Datos;
            }
        }

        private void CargarHojas()
        {
            gridControl1.DataSource = null;
            CLS_HojaNomina Clase = new CLS_HojaNomina();
            DateTime Fecha;
            Fecha= Convert.ToDateTime(dateDel.EditValue);
            Clase.del= Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            Fecha = Convert.ToDateTime(dateAl.EditValue);
            Clase.al = Fecha.Year.ToString() + DosCeros(Fecha.Month.ToString()) + DosCeros(Fecha.Day.ToString());
            if (lueCuadrillas.EditValue == null)
            {
                Clase.todascategorias = "T";
                Clase.categoria = "";
            }else
            {
                Clase.todascategorias = "N";
                Clase.categoria = lueCuadrillas.EditValue.ToString();
            }
            
            
            Clase.MtdSeleccionarHojasNomina();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (radioGroup1.EditValue.ToString().Equals("A"))
            {
               
                gridView1.Columns["Estatus"].FilterInfo = new ColumnFilterInfo("[Estatus] LIKE '%A%'");
            }
            else
            {
                
                gridView1.Columns["Estatus"].FilterInfo = new ColumnFilterInfo("[Estatus] LIKE '%C%'");
            }

            fini = dateDel.EditValue.ToString();
            ffin = dateAl.EditValue.ToString();
            if (lueCuadrillas.EditValue != null)
            {
                categoria = lueCuadrillas.EditValue.ToString();
            }
            
            CargarHojas();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    HojaSeleccionada = row["Id_HojaNomina"].ToString();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }
    }
}