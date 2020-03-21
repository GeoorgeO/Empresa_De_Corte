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

namespace CuttingBusiness
{
    public partial class Frm_AbrirHoja : DevExpress.XtraEditors.XtraForm
    {
        public string HojaSeleccionada { get; set; }

        public Frm_AbrirHoja()
        {
            InitializeComponent();
        }

        private void Frm_AbrirHoja_Load(object sender, EventArgs e)
        {
            HojaSeleccionada = String.Empty;
            dateDel.EditValue = DateTime.Now.AddDays(-30);
            dateAl.EditValue = DateTime.Now;
            CargarHojas();
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
    }
}