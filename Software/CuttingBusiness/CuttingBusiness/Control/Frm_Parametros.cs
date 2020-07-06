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
    public partial class Frm_Parametros : DevExpress.XtraEditors.XtraForm
    {

        string IdParametro;

        public string UsuariosLogin { get; set; }

        public Frm_Parametros()
        {
            InitializeComponent();
        }

        private void Frm_Parametros_Load(object sender, EventArgs e)
        {
            IdParametro = "001";
            radioGroup1.EditValue = "N";
            CargarParametros();
        }

        private void CargarParametros()
        {
            
            CLS_Parametros Clase = new CLS_Parametros();
            if (radioGroup1.EditValue.ToString().Equals("N"))
            {
               
                IdParametro = "001";
            }
            if (radioGroup1.EditValue.ToString().Equals("F"))
            {
               
                IdParametro = "002";
            }
            if (radioGroup1.EditValue.ToString().Equals("S"))
            {
                
                IdParametro = "003";
            }

            Clase.Id_Tipo = radioGroup1.EditValue.ToString();

            Clase.MtdSeleccionarParametros();
            if (Clase.Exito)
            {
                textPagoxDiaMission.Text=Clase.Datos.Rows[0][1].ToString();
                textPagoxDia.Text = Clase.Datos.Rows[0][2].ToString();
                textNCortadoresMission.Text = Clase.Datos.Rows[0][3].ToString();
                textNCortadores.Text = Clase.Datos.Rows[0][4].ToString();
                textTopePagoMission.Text = Clase.Datos.Rows[0][5].ToString();
                textTopePago.Text = Clase.Datos.Rows[0][6].ToString();
                textLimInfCort.Text = Clase.Datos.Rows[0][7].ToString();
                textLimSupCort.Text = Clase.Datos.Rows[0][8].ToString();
                textPagoxCaja.Text = Clase.Datos.Rows[0][9].ToString();
                textPagoxCajaInf.Text = Clase.Datos.Rows[0][10].ToString();
                textPagoxCajaSup.Text = Clase.Datos.Rows[0][11].ToString();
                textKgxDiaInf1.Text = Clase.Datos.Rows[0][12].ToString();
                textKgxDiaSup1.Text = Clase.Datos.Rows[0][13].ToString();
                textPagoInf1.Text = Clase.Datos.Rows[0][14].ToString();
                textPagoSup1.Text = Clase.Datos.Rows[0][15].ToString();
                textPagoInf1Mission.Text = Clase.Datos.Rows[0][16].ToString();
                textPagoSup1Mission.Text = Clase.Datos.Rows[0][17].ToString();
                textKgxDiaInf2.Text = Clase.Datos.Rows[0][18].ToString();
                textKgxDiaSup2.Text = Clase.Datos.Rows[0][19].ToString();
                textPagoInf2.Text = Clase.Datos.Rows[0][20].ToString();
                textPagoSup2.Text = Clase.Datos.Rows[0][21].ToString();
                textPagoInf2Mission.Text = Clase.Datos.Rows[0][22].ToString();
                textPagoSup2Mission.Text = Clase.Datos.Rows[0][23].ToString();
                textKgxDiaInf3.Text = Clase.Datos.Rows[0][24].ToString();
                textKgxDiaSup3.Text = Clase.Datos.Rows[0][25].ToString();
                textPagoInf3.Text = Clase.Datos.Rows[0][26].ToString();
                textPagoSup3.Text = Clase.Datos.Rows[0][27].ToString();
                textPagoInf3Mission.Text = Clase.Datos.Rows[0][28].ToString();
                textPagoSup3Mission.Text = Clase.Datos.Rows[0][29].ToString();
               
            }
        }

        private void InsertarParametros()
        {
            CLS_Parametros Clase = new CLS_Parametros();
            Clase.Id_Parametro = IdParametro;
            Clase.Pago_x_Dia_Mission = Convert.ToDecimal(textPagoxDiaMission.Text);
            Clase.Pago_x_Dia = Convert.ToDecimal(textPagoxDia.Text);
            Clase.N_Cortadores_Mission = Convert.ToDecimal(textNCortadoresMission.Text);
            Clase.N_Cortadores = Convert.ToDecimal(textNCortadores.Text);
            Clase.Tope_Pago_Mission = Convert.ToDecimal(textTopePagoMission.Text);
            Clase.Tope_Pago = Convert.ToDecimal(textTopePago.Text);
            Clase.Lim_Inf_Cort= Convert.ToDecimal(textLimInfCort.Text);
            Clase.Lim_Sup_Cort= Convert.ToDecimal(textLimSupCort.Text);
            Clase.Pago_x_caja = Convert.ToDecimal(textPagoxCaja.Text);
            Clase.Pago_x_caja_Inf = Convert.ToDecimal(textPagoxCajaInf.Text);
            Clase.Pago_x_caja_Sup= Convert.ToDecimal(textPagoxCajaSup.Text);
            Clase.Kg_x_Dia_Inf_1= Convert.ToDecimal(textKgxDiaInf1.Text);
            Clase.Kg_x_Dia_Sup_1 = Convert.ToDecimal(textKgxDiaSup1.Text);
            Clase.Pago_Inf_1 = Convert.ToDecimal(textPagoInf1.Text);
            Clase.Pago_Sup_1 = Convert.ToDecimal(textPagoSup1.Text);
            Clase.Pago_Inf_1_Mission = Convert.ToDecimal(textPagoInf1Mission.Text);
            Clase.Pago_Sup_1_Mission = Convert.ToDecimal(textPagoSup1Mission.Text);
            Clase.Kg_x_Dia_Inf_2 = Convert.ToDecimal(textKgxDiaInf2.Text);
            Clase.Kg_x_Dia_Sup_2= Convert.ToDecimal(textKgxDiaSup2.Text);
            Clase.Pago_Inf_2= Convert.ToDecimal(textPagoInf2.Text);
            Clase.Pago_Sup_2 = Convert.ToDecimal(textPagoSup2.Text);
            Clase.Pago_Inf_2_Mission = Convert.ToDecimal(textPagoInf2Mission.Text);
            Clase.Pago_Sup_2_Mission = Convert.ToDecimal(textPagoSup2Mission.Text);
            Clase.Kg_x_Dia_Inf_3 = Convert.ToDecimal(textKgxDiaInf3.Text);
            Clase.Kg_x_Dia_Sup_3 = Convert.ToDecimal(textKgxDiaSup3.Text);
            Clase.Pago_Inf_3 = Convert.ToDecimal(textPagoInf3.Text);
            Clase.Pago_Sup_3 = Convert.ToDecimal(textPagoSup3.Text);
            Clase.Pago_Inf_3_Mission = Convert.ToDecimal(textPagoInf3Mission.Text);
            Clase.Pago_Sup_3_Mission= Convert.ToDecimal(textPagoSup3Mission.Text);

            Clase.Id_Tipo = radioGroup1.EditValue.ToString(); ;

            Clase.Usuario = UsuariosLogin.Trim();
            Clase.MtdInsertarParametros();
            if (Clase.Exito)
            {
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarParametros();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            InsertarParametros();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}