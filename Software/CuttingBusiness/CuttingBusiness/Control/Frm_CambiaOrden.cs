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
    public partial class Frm_CambiaOrden : DevExpress.XtraEditors.XtraForm
    {
        public Frm_CambiaOrden()
        {
            InitializeComponent();
        }
        public string Orden { get; set; }

        public string nuevaOrden;

        private void Frm_CambiaOrden_Load(object sender, EventArgs e)
        {
            textOrden.Text = Orden.Trim();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CLS_HojaNomina clase = new CLS_HojaNomina();
            clase.Id_HojaNomina = textOrden.Text.Trim();
            clase.Id_HojaNomina_New = textOrdenNew.Text.Trim();
            
            clase.MtdActuaizaOrdenHojaNomina();
            if (clase.Exito)
            {

                //CargarPais();
                
                //LimpiarCampos();
                if (Convert.ToInt32(clase.Datos.Rows[0][0]) == 0)
                {
                    XtraMessageBox.Show("Orden actualizada con exito");
                    nuevaOrden = textOrdenNew.Text.Trim();
                    this.Close();

                }else
                {
                    if(Convert.ToInt32(clase.Datos.Rows[0][0]) == -1)
                    XtraMessageBox.Show("Ocurrio un error Al intentar aplicar los cambios");
                }
                

            }
            else
            {
                XtraMessageBox.Show(clase.Mensaje);
            }
        }
    }
}