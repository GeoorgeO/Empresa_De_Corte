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
    public partial class Frm_CambiaOrden : DevExpress.XtraEditors.XtraForm
    {
        public Frm_CambiaOrden()
        {
            InitializeComponent();
        }
        public string Orden { get; set; }

        private void Frm_CambiaOrden_Load(object sender, EventArgs e)
        {
            textOrden.Text = Orden.Trim();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CLS_HojaNomina clase = new CLS_HojaNomina();
            clase.Id_HojaNomina = textOrden.Text;
        }
    }
}