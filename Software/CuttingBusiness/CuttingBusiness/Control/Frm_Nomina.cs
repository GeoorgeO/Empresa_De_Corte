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
    public partial class Frm_Nomina : DevExpress.XtraEditors.XtraForm
    {

        string vtId_JefeCuadrilla="";
        int vtSecuencia = 0;
        decimal vtTotalImporte = 0;
       
        Boolean Abrir=false,Bandera=false;


        public Frm_Nomina()
        {
            InitializeComponent();
        }

        private void Frm_Nomina_Load(object sender, EventArgs e)
        {
            cargarEmpleados();
            cargarCuadrillas();
            dateFecha.EditValue = DateTime.Today;
            cargarParametros();
        }

        private void cargarEmpleados()
        {
           lueEmpleados.Properties.DataSource = null;
            CLS_Empleados_Nomina Clase = new CLS_Empleados_Nomina();

            Clase.MtdSeleccionarEmpleados();
            if (Clase.Exito)
            {
                lueEmpleados.Properties.DataSource = Clase.Datos;
            }
        }

        private void cargarCuadrillas()
        {
            lueCuadrillas.Properties.DataSource = null;
            CLS_HojaNomina Clase = new CLS_HojaNomina();

            Clase.MtdSeleccionarCuadrillaNomina();
            if (Clase.Exito)
            {
                lueCuadrillas.Properties.DataSource = Clase.Datos;
            }
        }

        private void cargarParametros()
        {

            CLS_HojaNomina Clase = new CLS_HojaNomina();
            if (lueCuadrillas.EditValue != null )
            {
                if(lueCuadrillas.EditValue.ToString().Trim().Length > 0)
                {
                    Clase.Id_Cuadrilla = lueCuadrillas.EditValue.ToString();
                }
                else
                {
                    Clase.Id_Cuadrilla = "-1";
                }
            }
            else
            {
                Clase.Id_Cuadrilla = "-1";
            }
            
            if (checkFestivo.Checked)
            {
                Clase.Id_Tipo = "F";
            }
            else
            {
                Clase.Id_Tipo = "N";
            }
            Clase.MtdSeleccionarParametrosHoja();
            if (Clase.Exito)
            {
                labelEmpresa.Text = Clase.Datos.Rows[0][0].ToString();
                labelPagoDiario.Text = Clase.Datos.Rows[0][1].ToString();
                vtId_JefeCuadrilla = Clase.Datos.Rows[0][2].ToString();
                labelNombreJefeCuadrilla.Text = Clase.Datos.Rows[0][3].ToString();
                textTotalCortePgoxDia.Text = Clase.Datos.Rows[0][4].ToString();
                textPrecioCaja.Text = Clase.Datos.Rows[0][5].ToString();
                if(Convert.ToDecimal(textKgcortadosxdia.Text)>= Convert.ToDecimal(Clase.Datos.Rows[0][6]) && Convert.ToDecimal(textKgcortadosxdia.Text) <= Convert.ToDecimal(Clase.Datos.Rows[0][7]))
                {
                    textPagoJefeCuadrilla.Text = (Convert.ToDecimal(Clase.Datos.Rows[0][8]) + Convert.ToDecimal(Clase.Datos.Rows[0][9])).ToString();
                }
                if (Convert.ToDecimal(textKgcortadosxdia.Text) >= Convert.ToDecimal(Clase.Datos.Rows[0][10]) && Convert.ToDecimal(textKgcortadosxdia.Text) <= Convert.ToDecimal(Clase.Datos.Rows[0][11]))
                {
                    textPagoJefeCuadrilla.Text = (Convert.ToDecimal(Clase.Datos.Rows[0][12]) + Convert.ToDecimal(Clase.Datos.Rows[0][13])).ToString();
                }
                if (Convert.ToDecimal(textKgcortadosxdia.Text) >= Convert.ToDecimal(Clase.Datos.Rows[0][14]) && Convert.ToDecimal(textKgcortadosxdia.Text) <= Convert.ToDecimal(Clase.Datos.Rows[0][15]))
                {
                    textPagoJefeCuadrilla.Text = (Convert.ToDecimal(Clase.Datos.Rows[0][16]) + Convert.ToDecimal(Clase.Datos.Rows[0][17])).ToString();
                }
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void textEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                CLS_HojaNomina Clase = new CLS_HojaNomina();
                Clase.Id_HojaNomina = textIdHojaNomina.Text.Trim();
                Clase.MtdSeleccionarHojaNomina();
                if (Clase.Exito)
                {
                    if (Clase.Datos.Rows.Count > 0)
                    {
                        DialogResult = XtraMessageBox.Show("Esta orden ya esta capturada, ¿deseas modificarla?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        if (DialogResult == DialogResult.Yes)
                        {
                            Abrir = true;
                            dateFecha.EditValue= Convert.ToDateTime(Clase.Datos.Rows[0][1]);
                            lueCuadrillas.EditValue = Clase.Datos.Rows[0][2].ToString();
                            labelEmpresa.Text = Clase.Datos.Rows[0][3].ToString();
                            labelPagoDiario.Text = Clase.Datos.Rows[0][4].ToString();
                            vtId_JefeCuadrilla= Clase.Datos.Rows[0][5].ToString();
                            labelNombreJefeCuadrilla.Text = Clase.Datos.Rows[0][6].ToString();
                            textPrecioCaja.Text = Clase.Datos.Rows[0][7].ToString();
                            textTotalCortePgoxDia.Text= Clase.Datos.Rows[0][8].ToString();
                            textCajasxdia.Text = Clase.Datos.Rows[0][10].ToString();
                            textKgcortadosxdia.Text= Clase.Datos.Rows[0][9].ToString();
                            
                            textPagoJefeCuadrilla.Text = Clase.Datos.Rows[0][11].ToString();
                            textPromedioCaja.Text= Clase.Datos.Rows[0][12].ToString();
                            textPromedioCaja1.Text= Clase.Datos.Rows[0][13].ToString();
                            textPromedioCaja2.Text = Clase.Datos.Rows[0][14].ToString();
                            if (Clase.Datos.Rows[0][18].ToString().Equals("True"))
                            {
                                checkPagoxDia.Checked = true;
                            }
                            else
                            {
                                checkPagoxDia.Checked = false;
                            }
                            if (Clase.Datos.Rows[0][19].ToString().Equals("True"))
                            {
                                checkPagoFalso.Checked = true;
                            }
                            else
                            {
                                checkPagoFalso.Checked = false;
                            }
                            if (Clase.Datos.Rows[0][20].ToString().Equals("True"))
                            {
                                checkFestivo.Checked = true;
                            }
                            else
                            {
                                checkFestivo.Checked = false;
                            }
                            CargarDetalle();
                            Abrir = false;
                        }
                    }else
                    {
                        CLS_ServicioCortes Clase2 = new CLS_ServicioCortes();
                        Clase2.PSC_ODC = textIdHojaNomina.Text.Trim();
                        Clase2.MtdSeleccionarServicioCorte();
                        if (Clase.Exito)
                        {
                            textCajasxdia.Text = Clase2.Datos.Rows[0][7].ToString();
                            textKgcortadosxdia.Text = Clase2.Datos.Rows[0][8].ToString();

                        }
                        else
                        {

                        }
                        guardarHoja();
                    }
                }
            }
        }

        private void guardarHoja()
        {
            CLS_HojaNomina Clase = new CLS_HojaNomina();

            Clase.Id_HojaNomina = textIdHojaNomina.Text.Trim();

            DateTime Fecha = Convert.ToDateTime(dateFecha.Text.Trim());
            Clase.Fecha_HojaNomina = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            if (lueCuadrillas.EditValue == null)
            {
                Clase.Id_Cuadrilla = "";
            }
            else
            {
                Clase.Id_Cuadrilla = lueCuadrillas.EditValue.ToString();
            }

            Clase.Empresa = labelEmpresa.Text;
            Clase.Pago_Diario = Convert.ToDecimal(labelPagoDiario.Text);
            Clase.Id_JefeCuadrilla = vtId_JefeCuadrilla;
            Clase.Tope_pgo_x_dia = Convert.ToDecimal(textPrecioCaja.Text);
            Clase.Total_corte_pgo_x_dia = Convert.ToDecimal(textTotalCortePgoxDia.Text);
            Clase.Kgs_cortados_x_dia = Convert.ToDecimal(textKgcortadosxdia.Text);
            Clase.Cajas_cortados_x_dia = Convert.ToDecimal(textCajasxdia.Text);
            Clase.Pago_jefe_cuadrilla = Convert.ToDecimal(textPagoJefeCuadrilla.Text);
            Clase.Peso_promedio_caja = Convert.ToDecimal(textPromedioCaja.Text);
            Clase.Precio_caja_1 = Convert.ToDecimal(textPromedioCaja1.Text);
            Clase.Precio_caja_2 = Convert.ToDecimal(textPromedioCaja2.Text);
            Clase.Total_cortadores = Convert.ToDecimal(0);
            Clase.Total_Cajas = Convert.ToDecimal(0);
            Clase.Total_Importe = Convert.ToDecimal(0);
            if (checkPagoxDia.Checked)
            {
                Clase.Pago_x_dia = "1";
            }
            else
            {
                Clase.Pago_x_dia = "0";
            }
            if (checkPagoFalso.Checked)
            {
                Clase.Pago_falso = "1";
            }
            else
            {
                Clase.Pago_falso = "0";
            }
            if (checkFestivo.Checked)
            {
                Clase.Festivo = "1";
            }
            else
            {
                Clase.Festivo = "0";
            }
            Clase.MtdInsertarHojaNomina();
            if (Clase.Exito)
            {


                XtraMessageBox.Show("Se ha Insertado el registro con exito");

            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void ContadorTotal()
        {
            labelContadorTotal.Text = gridView1.RowCount.ToString();
            if (gridView1.RowCount > 0)
            {
                for (int x = 0; x < gridView1.RowCount; x++)
                {

                    int xRow = gridView1.GetVisibleRowHandle(x);
                    if (gridView1.GetRowCellValue(xRow, gridView1.Columns["Id_Puesto"]).ToString().Trim().Equals("02"))
                    {
                        labelContadorCortador.Text = (Convert.ToInt32(labelContadorCortador.Text) + 1).ToString();
                        labelImporteCortador.Text = (Convert.ToDecimal(labelImporteCortador.Text) + Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]))).ToString();
                    }

                    labelContadorCajas.Text = (Convert.ToInt32(labelContadorCajas.Text) + Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"]))).ToString();
                    decimal valortemp = Convert.ToDecimal(labelImporte.Text) + Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]));
                    labelImporte.Text = (Convert.ToDecimal(labelImporte.Text) + Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]))).ToString();

                }
            }
            
        }

        private void guardarDetalle(string Hoja,string secuencia,string empleado,int cajas,decimal importe)
        {
            CLS_HojaNominaDetalle Clase = new CLS_HojaNominaDetalle();

            Clase.Id_HojaNomina = textIdHojaNomina.Text.Trim();
            Clase.Id_secuencia = DosCero(vtSecuencia.ToString());
            Clase.Id_empleado = lueEmpleados.EditValue.ToString();
            Clase.Cajas = Convert.ToDecimal(textCajas.Text);

            Clase.Importe = (Convert.ToDecimal(textCajas.Text) * Convert.ToDecimal(textPromedioCaja2.Text));


            Clase.MtdInsertarHojaNominaDetalle();
            if (Clase.Exito)
            {

                CargarDetalle();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        

        private void reCargaImporteyprecioCaja()
        {
            if (gridView1.RowCount > 0)
            {
                textPromedioCaja2.Text = (vtTotalImporte / Convert.ToInt32(labelContadorCajas.Text)).ToString();
                for (int x = 0; x < gridView1.RowCount; x++)
                {

                    int xRow = gridView1.GetVisibleRowHandle(x);

                    gridView1.SetRowCellValue(xRow, "Importe", Convert.ToDecimal(textPromedioCaja2.Text) * Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"])));
                    

                }
      
                for (int y = 0; y < gridView1.RowCount; y++)
                {

                    int xRow2 = gridView1.GetVisibleRowHandle(y);
                    string hoja, secuencia, empleado;
                    int cajas;
                    decimal importe;
                    hoja= gridView1.GetRowCellValue(xRow2, gridView1.Columns["Id_HojaNomina"]).ToString();
                    secuencia = gridView1.GetRowCellValue(xRow2, gridView1.Columns["Id_secuencia"]).ToString();
                    empleado = gridView1.GetRowCellValue(xRow2, gridView1.Columns["Id_Empleado"]).ToString();
                    cajas = Convert.ToInt32(gridView1.GetRowCellValue(xRow2, gridView1.Columns["Cajas"]));
                    importe = Convert.ToDecimal(gridView1.GetRowCellValue(xRow2, gridView1.Columns["Importe"]));
                    guardarDetalle(hoja, secuencia, empleado, cajas, importe);
                }
            }
        }

        private void CargarDetalle()
        {
            gridControl1.DataSource = null;
            CLS_HojaNominaDetalle Clase = new CLS_HojaNominaDetalle();
            Clase.Id_HojaNomina = textIdHojaNomina.Text.Trim();
            Clase.MtdSeleccionarHojaNominaDetalle();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
            ContadorTotal();
        }

        private string DosCero(string sVal)
        {
            string str = "";
            if (sVal.Length == 1)
            {
                return (str = "0" + sVal);
            }
            return sVal;
        }

        private void lueCuadrillas_EditValueChanged(object sender, EventArgs e)
        {
            if (lueCuadrillas.EditValue!=null && lueCuadrillas.EditValue.ToString().Trim().Length > 0)
            {
                cargarParametros();
                if (Abrir == false)
                {
                    guardarHoja();
                }
                
            }
         

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (textIdHojaNomina.Text.Trim().Length > 0)
            {
                if (lueEmpleados.EditValue != null)
                {
                    if (Convert.ToDecimal(textCajas.Text) > 0)
                    {
                      
                        guardarDetalle(textIdHojaNomina.Text.Trim(), DosCero(vtSecuencia.ToString()), lueEmpleados.EditValue.ToString(), Convert.ToInt32(textCajas.Text), (Convert.ToDecimal(textCajas.Text) * Convert.ToDecimal(textPromedioCaja2.Text)));
                        if (gridView1.RowCount > 1)
                        {
                            reCargaImporteyprecioCaja();
                        }
                        
                    }else
                    {
                        XtraMessageBox.Show("Falta ingresar el numero de cajas");
                        textCajas.Focus();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Falta Seleccionar el trabajador");
                    lueEmpleados.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Ingrese el numero de Orden y de ENTER");
                textIdHojaNomina.Focus();
            }
        
        }

       

        private void textKgcortadosxdia_EditValueChanged(object sender, EventArgs e)
        {
            cargarParametros();
            if (textPrecioCaja.Text.Trim().Length > 0)
            {
                vtTotalImporte = Convert.ToDecimal(textKgcortadosxdia.Text) * Convert.ToDecimal(textPrecioCaja.Text);
                textPromedioCaja2.Text = (vtTotalImporte / Convert.ToDecimal(textCajasxdia.Text)).ToString();
                textPromedioCaja.Text=(Convert.ToDecimal(textKgcortadosxdia.Text)/ Convert.ToDecimal(textCajasxdia.Text)).ToString();
            }
        }

        private void checkFestivo_CheckedChanged(object sender, EventArgs e)
        {
            cargarParametros();
        }

        private void dateFecha_EditValueChanged(object sender, EventArgs e)
        {
            if (textIdHojaNomina.Text.Trim().Length >= 6)
            {
                if (Abrir == false)
                {
                    if (Bandera == false)
                    {
                        Bandera = true;
                    }
                    else
                    {
                        guardarHoja();
                    }

                }
            }
            
                
           
            
        }
    }
}