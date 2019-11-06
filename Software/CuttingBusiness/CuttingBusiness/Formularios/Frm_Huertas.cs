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

namespace CuttingBusiness.Formularios
{
    public partial class Frm_Huertas : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Huertas()
        {
            InitializeComponent();
        }

        public void CargarEstado(string Valor)
        {
            CLS_Estado comboEstado = new CLS_Estado();
            comboEstado.MtdSeleccionarEstado();
            if (comboEstado.Exito)
            {
                CargarComboEstado(comboEstado.Datos, Valor);
            }
        }
        private void CargarComboEstado(DataTable Datos, string Valor)
        {
            cboEstado.Properties.DisplayMember = "Nombre_Estado";
            cboEstado.Properties.ValueMember = "Id_Estado";
            cboEstado.EditValue = Valor;
            cboEstado.Properties.DataSource = Datos;
        }

        private void Frm_Huertas_Shown(object sender, EventArgs e)
        {
            CargarEstado(null);
        }
    }
}
