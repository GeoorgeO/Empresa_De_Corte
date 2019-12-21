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
    public partial class Frm_BusqJefeCuadrillas : DevExpress.XtraEditors.XtraForm
    {
        public string IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }

        public Frm_BusqJefeCuadrillas()
        {
            InitializeComponent();
        }

        private void CargarJefeCuadrilla()
        {
            gridControl1.DataSource = null;
            CLS_Salidas Clase = new CLS_Salidas();

            Clase.MtdSeleccionarJefeCuadrillas();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void Frm_BusqJefeCuadrillas_Load(object sender, EventArgs e)
        {
            CargarJefeCuadrilla();
            if (dtgValRutas.RowCount > 0)
            {
                DataRow row = this.dtgValRutas.GetDataRow(0);
                IdEmpleado = row["Id_Empleado"].ToString();
                NombreEmpleado = row["Nombre_Empleado"].ToString();
                
            }
            else
            {
                IdEmpleado = "";
                NombreEmpleado = "";
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValRutas.GetSelectedRows())
                {
                    DataRow row = this.dtgValRutas.GetDataRow(i);
                    IdEmpleado = row["Id_Empleado"].ToString();
                    NombreEmpleado = row["Nombre_Empleado"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IdEmpleado != null)
            {
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("No se selecciono ningun dato.");
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IdEmpleado = "";
            IdEmpleado = "";
            this.Close();
        }
    }
}