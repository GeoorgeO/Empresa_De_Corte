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
    public partial class Frm_BusqSalidas : DevExpress.XtraEditors.XtraForm
    {
        public Frm_BusqSalidas()
        {
            InitializeComponent();
        }


        public string IdSalida { get; set; }
        public string IdSerie { get; set; }
        public string IdJefeCuadrilla { get; set; }
        public string JefeCuadrilla { get; set; }
        public string IdTipoSalida { get; set; }
        public string NombreTipoSalida { get; set; }
        public string FechaSalida { get; set; }
        public string NumeroArticulosSalida { get; set; }

        private void CargarSalidas()
        {
            gridControl1.DataSource = null;
            CLS_Salidas Clase = new CLS_Salidas();

            Clase.MtdSeleccionarSalidasEncabezado();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }

        private void Frm_BusqSalidas_Load(object sender, EventArgs e)
        {
            CargarSalidas();
            if (dtgValRutas.RowCount > 0)
            {
                DataRow row = this.dtgValRutas.GetDataRow(0);
                IdSalida = row["Folio_Salida"].ToString();
                IdSerie = row["Serie_Salida"].ToString();
                IdJefeCuadrilla = row["Id_JefeCuadrilla"].ToString();
                JefeCuadrilla = row["Nombre_empleado"].ToString();
                IdTipoSalida = row["Id_TipoSalida"].ToString();
                NombreTipoSalida = row["Nombre_TipoSalida"].ToString();
                FechaSalida = row["Fecha_Salida"].ToString();
                NumeroArticulosSalida = row["Numero_ArticulosSalida"].ToString();
            }
            else
            {
                IdSalida = "";
                IdSerie = "";
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValRutas.GetSelectedRows())
                {
                    DataRow row = this.dtgValRutas.GetDataRow(i);
                    IdSalida = row["Folio_Salida"].ToString();
                    IdSerie = row["Serie_Salida"].ToString();
                    IdJefeCuadrilla = row["Id_JefeCuadrilla"].ToString();
                    JefeCuadrilla = row["Nombre_empleado"].ToString();
                    IdTipoSalida = row["Id_TipoSalida"].ToString();
                    NombreTipoSalida = row["Nombre_TipoSalida"].ToString();
                    FechaSalida = row["Fecha_Salida"].ToString();
                    NumeroArticulosSalida = row["Numero_ArticulosSalida"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IdSerie != null)
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
            IdSerie = "";
            IdSalida = "";
            this.Close();
        }
    }
}