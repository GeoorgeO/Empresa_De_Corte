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

namespace CuttingBusiness.Control
{
    public partial class Frm_Entradas : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Entradas()
        {
            InitializeComponent();
        }

        private void btnTipoEntrada_Click(object sender, EventArgs e)
        {
            Frm_Series frm = new Frm_Series();
            frm.ShowDialog();
            CargarSeries(null);
        }
        public void CargarSeries(string Valor)
        {
            CLS_Series comboEstado = new CLS_Series();
            comboEstado.MtdSeleccionarSerie();
            if (comboEstado.Exito)
            {
                CargarComboSerie(comboEstado.Datos, Valor);
            }
        }
        private void CargarComboSerie(DataTable Datos, string Valor)
        {
            cboSerie.Properties.DisplayMember = "Nombre_Serie";
            cboSerie.Properties.ValueMember = "Id_Serie";
            cboSerie.EditValue = Valor;
            cboSerie.Properties.DataSource = Datos;
        }
    }
}