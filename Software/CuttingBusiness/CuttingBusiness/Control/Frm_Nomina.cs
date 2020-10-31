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
using System.Globalization;

namespace CuttingBusiness
{
    public partial class Frm_Nomina : DevExpress.XtraEditors.XtraForm
    {
        public string tempFechaInicio { get; set; }
        public string tempFechaFin { get; set; }
        public string tempIndexSel { get; set; }
        public string tempEstaus { get; set; }
        public decimal tempPagoMinCortador { get; set; }
        public decimal tempPagoMinBanero { get; set; }


        string vtId_JefeCuadrilla = "";
        int vtSecuencia = 0;
        decimal vtTotalImporte = 0;
        int vtCortadores;

        DateTime fechaactual;

        public Boolean accesoEmpleados { get; set; }

        Boolean Abrir=false,Bandera=false,CambioDetalle=false;

        decimal valor;

        decimal precio_maniobra;

        public string UsuariosLogin { get; set; }

        public NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        public CultureInfo culture = CultureInfo.CreateSpecificCulture("es-MX");

        public Frm_Nomina()
        {
            InitializeComponent();
        }

        private void Frm_Nomina_Load(object sender, EventArgs e)
        {
            radioGroup1.EditValue = "C";
            cargarEmpleados();
            tempFechaInicio = string.Empty;
            tempFechaFin = string.Empty;
            tempIndexSel = string.Empty;
            cargarCuadrillas();
            dateFecha.EditValue = DateTime.Today;
            fechaactual = DateTime.Today;
            cargarParametros();
            
            Importe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            Importe.DisplayFormat.FormatString = "n0";

            if (accesoEmpleados)
            {
                btn_Empleados.Enabled = true;
            }
            else
            {
                btn_Empleados.Enabled = false;
            }
            tempEstaus = "T";
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
        private void lueCuadrillas_QueryPopUp(object sender, CancelEventArgs e)
        {
            LookUpEdit edit = sender as LookUpEdit;
            for (int i = 0; i < edit.Properties.Columns.Count; i++)
            {
                if (i < 3)
                {
                    edit.Properties.Columns[i].Width = 60;
                }
                else
                {
                    edit.Properties.Columns[i].Width = 180;
                }
            }
            edit.Properties.PopupFormMinSize = new Size(100 * edit.Properties.Columns.Count, edit.Properties.PopupFormMinSize.Height);
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
                if (radioGroup1.EditValue.ToString().Equals("S"))
                {
                    Clase.Id_Tipo = "S";
                }
                else
                {
                    Clase.Id_Tipo = "N";
                }
               
            }
            Clase.MtdSeleccionarParametrosHoja();
            if (Clase.Exito)
            {
                labelEmpresa.Text = Clase.Datos.Rows[0][0].ToString();
                labelPagoDiario.Text = Clase.Datos.Rows[0][1].ToString();
                vtId_JefeCuadrilla = Clase.Datos.Rows[0][2].ToString();
                labelNombreJefeCuadrilla.Text = Clase.Datos.Rows[0][3].ToString();
                textTopepgoxDia.Text = Clase.Datos.Rows[0][4].ToString();
                textPrecioCaja.Text = Clase.Datos.Rows[0][5].ToString();
                if(Convert.ToDecimal(textKgcortadosxdia.Text)>= Convert.ToDecimal(Clase.Datos.Rows[0][6]) && Convert.ToDecimal(textKgcortadosxdia.Text) <= Convert.ToDecimal(Clase.Datos.Rows[0][7]))
                {
                    textPagoJefeCuadrilla.Text = (Convert.ToDecimal(Clase.Datos.Rows[0][8]) + Convert.ToDecimal(Clase.Datos.Rows[0][9])).ToString();
                    precio_maniobra = Convert.ToDecimal(Clase.Datos.Rows[0][9]);
                }
                if (Convert.ToDecimal(textKgcortadosxdia.Text) >= Convert.ToDecimal(Clase.Datos.Rows[0][10]) && Convert.ToDecimal(textKgcortadosxdia.Text) <= Convert.ToDecimal(Clase.Datos.Rows[0][11]))
                {
                    textPagoJefeCuadrilla.Text = (Convert.ToDecimal(Clase.Datos.Rows[0][12]) + Convert.ToDecimal(Clase.Datos.Rows[0][13])).ToString();
                    precio_maniobra = Convert.ToDecimal(Clase.Datos.Rows[0][13]);
                }
                if (Convert.ToDecimal(textKgcortadosxdia.Text) >= Convert.ToDecimal(Clase.Datos.Rows[0][14]) && Convert.ToDecimal(textKgcortadosxdia.Text) <= Convert.ToDecimal(Clase.Datos.Rows[0][15]))
                {
                    textPagoJefeCuadrilla.Text = (Convert.ToDecimal(Clase.Datos.Rows[0][16]) + Convert.ToDecimal(Clase.Datos.Rows[0][17])).ToString();
                    precio_maniobra = Convert.ToDecimal(Clase.Datos.Rows[0][17]);
                }
                vtCortadores = Convert.ToInt32(Clase.Datos.Rows[0][18]);
                //vtTope = vtCortadores * Convert.ToDecimal(Clase.Datos.Rows[0][1]);
                tempPagoMinCortador = Convert.ToDecimal(Clase.Datos.Rows[0][19]);
                tempPagoMinBanero = Convert.ToDecimal(Clase.Datos.Rows[0][20]);
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void ReCalculoPagoMinxCaja()
        {
            DialogResult = XtraMessageBox.Show("El importe de la hoja es menor al monto minimo configurado ["+tempPagoMinCortador.ToString()+"], Desea recalcular para su ajuste?, Esta accion no se puede revertir ", "Importe Inferior a Pago Minimo, Recalcular Importe?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                textPromedioCaja2.Text = (tempPagoMinCortador / Convert.ToDecimal(labelContadorCajas.Text)).ToString();
                this.Update();
            }
            
        }

        private void verificaimportes()
        {
            if (gridView1.RowCount > 0)
            {
                int xRow = gridView1.GetVisibleRowHandle(0);
                int tcajas = Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"]));
                Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                double tprecio = Convert.ToDouble(valor);
                double tImporte = Convert.ToDouble(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]));
                if (Convert.ToInt32(tcajas * tprecio) == Convert.ToInt32(tImporte))
                {

                }
                else
                {
                    calculanuevosvalores('A');
                    insertanuevosvalores();
                }
            }
            
           
        }

        private void verificaimportesEspecial()
        {
            if (gridView1.RowCount > 0)
            {
                int xRow = gridView1.GetVisibleRowHandle(0);
                int tcajas = Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"]));
                Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                double tprecio = Convert.ToDouble(valor);
                double tImporte = Convert.ToDouble(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]));
                if (Convert.ToInt32(tcajas * tprecio) == Convert.ToInt32(tImporte))
                {

                }
                else
                {
                    calculanuevosvaloresEspecial('A');
                    insertanuevosvalores();
                }
            }


        }

        private void abrirHoja()
        {
            CLS_HojaNomina Clase = new CLS_HojaNomina();
            Clase.Id_HojaNomina = textIdHojaNomina.Text.Trim();
            Clase.MtdSeleccionarHojaNomina();
            if (Clase.Exito)
            {
                Abrir = true;
                dateFecha.EditValue = Convert.ToDateTime(Clase.Datos.Rows[0][1]);
                fechaactual= Convert.ToDateTime(Clase.Datos.Rows[0][1]);
                lueCuadrillas.EditValue = Clase.Datos.Rows[0][2].ToString();
                labelEmpresa.Text = Clase.Datos.Rows[0][3].ToString();
                labelPagoDiario.Text = Clase.Datos.Rows[0][4].ToString();
                vtId_JefeCuadrilla = Clase.Datos.Rows[0][5].ToString();
                labelNombreJefeCuadrilla.Text = Clase.Datos.Rows[0][6].ToString();
               // textPrecioCaja.Text = Clase.Datos.Rows[0][7].ToString();
                textTotalCortePgoxDia.Text = Clase.Datos.Rows[0][8].ToString();
                textCajasxdia.Text = Clase.Datos.Rows[0][10].ToString();
                textKgcortadosxdia.Text = Clase.Datos.Rows[0][9].ToString();

                textPagoJefeCuadrilla.Text = Clase.Datos.Rows[0][11].ToString();
                textPromedioCaja.Text = Clase.Datos.Rows[0][12].ToString();
                textPromedioCaja1.Text = Clase.Datos.Rows[0][13].ToString();
                textPromedioCaja2.Text = Clase.Datos.Rows[0][14].ToString();
                if (Clase.Datos.Rows[0][18].ToString().Equals("True"))
                {
                    radioGroup1.EditValue = "D";//checkPagoxDia.Checked = true;
                }
                else
                {
                    if (Clase.Datos.Rows[0][19].ToString().Equals("True"))
                    {
                        radioGroup1.EditValue = "S";//checkPagoFalso.Checked = true;
                    }
                    else
                    {
                        radioGroup1.EditValue = "C";//checkPagoFalso.Checked = false;
                    }//checkPagoxDia.Checked = false;
                }
                
                if (Clase.Datos.Rows[0][20].ToString().Equals("True"))
                {
                    checkFestivo.Checked = true;
                }
                else
                {
                    checkFestivo.Checked = false;
                }
                textPrecioCaja.Text = Clase.Datos.Rows[0][22].ToString();
                CargarDetalle();
                ContadorTotal();
                verificaimportes();
                if (Clase.Datos.Rows[0]["Estatus"].ToString() == "C")
                {
                    labelEstatus.Text = "Estatus: Nomina Cerrada";
                    bloquerHoja(false);
                    btnCerrarNomina.Visible = false;
                    
                }
                else
                {
                    RecargarInfoCaptura();
                    ContadorTotal();
                    lueCuadrillas.Focus();
                    if (textIdHojaNomina.Text.Trim().Length >= 6)
                    {
                        guardarHoja();
                    }
                }

               

                Abrir = false;
                
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
                                radioGroup1.EditValue = "D";/*checkPagoxDia.Checked = true;*/
                            }
                            else
                            {
                                if (Clase.Datos.Rows[0][19].ToString().Equals("True"))
                                {
                                    radioGroup1.EditValue = "S"; //checkPagoFalso.Checked = true;
                                }
                                else
                                {
                                    radioGroup1.EditValue = "C";// checkPagoFalso.Checked = false;
                                }// checkPagoxDia.Checked = false;
                            }
                           
                            if (Clase.Datos.Rows[0][20].ToString().Equals("True"))
                            {
                                checkFestivo.Checked = true;
                            }
                            else
                            {
                                checkFestivo.Checked = false;
                            }
                            if (Clase.Datos.Rows[0][21].ToString().Trim().Equals("C"))
                            {
                                labelEstatus.Text = "Estatus: Nomina Cerrada";
                                bloquerHoja(false);
                            }
                            textPrecioCaja.Text= Clase.Datos.Rows[0][22].ToString();
                            CargarDetalle();
                            ContadorTotal();
                            verificaimportes();
                            if (Clase.Datos.Rows[0]["Estatus"].ToString() == "C")
                            {
                                labelEstatus.Text = "Estatus: Nomina Cerrada";
                                bloquerHoja(false);
                                btnCerrarNomina.Visible = false;

                            }
                            else
                            {
                                RecargarInfoCaptura();
                                ContadorTotal();
                                lueCuadrillas.Focus();
                                if (textIdHojaNomina.Text.Trim().Length >= 6)
                                {
                                    guardarHoja();
                                }
                            }

                            Abrir = false;
                            //RecargarInfoCaptura();
                            //ContadorTotal();
                            //lueCuadrillas.Focus();
                            textIdHojaNomina.Enabled = false;

                            

                        }
                    }else
                    {
                        CLS_ServicioCortes Clase2 = new CLS_ServicioCortes();
                        Clase2.PSC_ODC = textIdHojaNomina.Text.Trim();
                        Clase2.MtdSeleccionarServicioCorte();
                        if (Clase2.Exito)
                        {
                            if (Clase2.Datos.Rows.Count > 0)
                            {
                                textCajasxdia.Text = Clase2.Datos.Rows[0][7].ToString();
                                textKgcortadosxdia.Text = Clase2.Datos.Rows[0][8].ToString();
                            }


                        }
                        else
                        {

                        }
                        guardarHoja();
                    }
                }
            }
        }

        private void RecargarInfoCaptura()
        {
            CLS_ServicioCortes Clase2 = new CLS_ServicioCortes();
            Clase2.PSC_ODC = textIdHojaNomina.Text.Trim();
            Clase2.MtdSeleccionarServicioCorte();
            if (Clase2.Exito)
            {
                if (Clase2.Datos.Rows.Count > 0)
                {
                    textCajasxdia.Text = Clase2.Datos.Rows[0][7].ToString();
                    textKgcortadosxdia.Text = Clase2.Datos.Rows[0][8].ToString();

                    calculanuevosvalores('A');
                    insertanuevosvalores();

                }


            }
            else
            {

            }
        }

        private void bloquerHoja(Boolean sino)
        {
            dateFecha.Enabled = sino;
            lueCuadrillas.Enabled = sino;
            lueEmpleados.Enabled = sino;
            textCajas.Enabled = sino;
            btnAgregar.Enabled = sino;
            btnNuevo.Enabled = sino;
            btnELiminar.Enabled = sino;
            checkPagoxDia.Enabled = sino;
            checkPagoFalso.Enabled = sino;
            btnIncluirApoyo.Enabled = sino;
            checkFestivo.Enabled = sino;
            radioGroup1.Enabled = sino;
        }

        private void guardarHoja()
        {
            if (textIdHojaNomina.Text.Trim().Length >= 6)
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
                Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                Clase.Tope_pgo_x_dia = valor;
                Clase.Total_corte_pgo_x_dia = Convert.ToDecimal(textTotalCortePgoxDia.Text);
                Clase.Kgs_cortados_x_dia = Convert.ToDecimal(textKgcortadosxdia.Text);
                Clase.Cajas_cortados_x_dia = Convert.ToDecimal(textCajasxdia.Text);
                Decimal.TryParse(textPagoJefeCuadrilla.Text, style, culture, out valor);
                Clase.Pago_jefe_cuadrilla = valor;
                Decimal.TryParse(textPromedioCaja.Text, style, culture, out valor);
                Clase.Peso_promedio_caja = valor;
                Decimal.TryParse(textPromedioCaja1.Text, style, culture, out valor);
                Clase.Precio_caja_1 = valor;
                Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                Clase.Precio_caja_2 = valor;
                Clase.Total_cortadores = Convert.ToDecimal(labelContadorCortador.Text);
                Clase.Total_Cajas = Convert.ToDecimal(labelContadorCajas.Text);
                Decimal.TryParse(labelImporte.Text, style, culture, out valor);
                Clase.Total_Importe = valor;
                if (radioGroup1.EditValue.ToString().Equals("D")/*checkPagoxDia.Checked*/)
                {
                    Clase.Pago_x_dia = "1";
                }
                else
                {
                    Clase.Pago_x_dia = "0";
                }
                if (radioGroup1.EditValue.ToString().Equals("S")/*checkPagoFalso.Checked*/)
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
                if (labelEstatus.Text.Trim().Length > 0)
                {
                    Clase.Estatus = "C";
                }
                else
                {
                    Clase.Estatus = "A";
                }
                Decimal.TryParse(textPrecioCaja.Text, style, culture, out valor);
                Clase.Precio_caja = valor;
                Clase.Pago_Maniobra = precio_maniobra;
                Clase.Usuario = UsuariosLogin.Trim();
                Clase.MtdInsertarHojaNomina();
                if (Clase.Exito)
                {


                    //XtraMessageBox.Show("Se ha Insertado el registro con exito");

                }
                else
                {
                    XtraMessageBox.Show(Clase.Mensaje);
                }
            }else
            {
                XtraMessageBox.Show("Se requieren mas digitos minimo 6 digitos");
            }
            
        }

        private void ContadorTotal()
        {
            labelContadorTotal.Text = gridView1.RowCount.ToString();
            labelContadorCortador.Text = "0";
            labelImporteCortador.Text = "0";
            labelContadorCajas.Text = "0";
            labelImporte.Text = "0";
            decimal TotalC = 0,Total=0;
            if (gridView1.RowCount > 0)
            {
                for (int x = 0; x < gridView1.RowCount; x++)
                {

                    int xRow = gridView1.GetVisibleRowHandle(x);
                    if (gridView1.GetRowCellValue(xRow, gridView1.Columns["Id_Puesto"]).ToString().Trim().Equals("02"))
                    {
                        labelContadorCortador.Text = (Convert.ToInt32(labelContadorCortador.Text) + 1).ToString();
                        Decimal.TryParse(labelImporteCortador.Text, style, culture, out valor);

                        TotalC = TotalC + decimal.Round(Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"])));
                        //labelImporteCortador.Text = (valor + Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]))).ToString();
                        labelImporteCortador.Text = TotalC.ToString();
                        
                    }
                    labelContadorCajas.Text = (Convert.ToInt32(labelContadorCajas.Text) + Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"]))).ToString();
                    Decimal.TryParse(labelImporte.Text, style, culture, out valor);
                    Total = Total + Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]));
                    //labelImporte.Text = (valor + Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]))).ToString();
                    labelImporte.Text = Total.ToString();
                }
                
            }
            if (Convert.ToDecimal(textKgcortadosxdia.Text) > 0 && Convert.ToInt32(labelContadorCajas.Text)>0)
            {
                textPromedioCaja.Text = (Convert.ToDecimal(textKgcortadosxdia.Text) / Convert.ToInt32(labelContadorCajas.Text)).ToString();
            }

            if (Abrir == false)
            {
                guardarHoja();
            }
            
        }

        private void guardarDetalle(string Hoja,string secuencia,string empleado,int cajas,decimal importe, Boolean recarga)
        {
            CLS_HojaNominaDetalle Clase = new CLS_HojaNominaDetalle();

            Clase.Id_HojaNomina = Hoja.Trim();
            Clase.Id_secuencia = DosCero(secuencia.ToString());
            Clase.Id_empleado = empleado;
            Clase.Cajas = cajas;

            Clase.Importe = importe;

            Clase.Usuario = UsuariosLogin.Trim();
            Clase.MtdInsertarHojaNominaDetalle();
            if (Clase.Exito)
            {
                if (recarga == true)
                {
                    CargarDetalle();
                }
                ContadorTotal();

               // XtraMessageBox.Show("Se ha Insertado el registro con exito");
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void calculanuevosvalores(char accion)
        {
            if (gridView1.RowCount > 0)
            {
                if (Convert.ToDecimal(textKgcortadosxdia.Text) == 0 && Convert.ToDecimal(labelContadorCortador.Text) <= vtCortadores)
                {
                    if (accion == 'B')
                    {
                        
                    }
                    else
                    {
                        if (radioGroup1.EditValue.ToString().Equals("C"))
                        {
                            Decimal.TryParse(textPrecioCaja.Text, style, culture, out valor);
                            if (Convert.ToDecimal(textKgcortadosxdia.Text) > 0)
                            {
                                vtTotalImporte = Convert.ToDecimal(textKgcortadosxdia.Text) * valor;
                            }
                            else
                            {
                                Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                                vtTotalImporte = valor;

                            }
                            if (Convert.ToDecimal(labelContadorCortador.Text) > vtCortadores)
                            {
                                decimal laquesea = decimal.Round(vtTotalImporte / Convert.ToDecimal(labelContadorCortador.Text), 4);
                                textPromedioCaja2.Text = (laquesea).ToString();
                            }else
                            {
                                decimal laquesea = (((vtTotalImporte / vtCortadores) * (Convert.ToDecimal(labelContadorCortador.Text) )) / ( Convert.ToDecimal(labelContadorCajas.Text)));
                               // decimal laquesea = decimal.Round(((Convert.ToDecimal(labelPagoDiario.Text)/ Convert.ToDecimal(labelContadorCortador.Text))/ Convert.ToDecimal(textCajas.Text)) / vtCortadores , 4);
                                textPromedioCaja2.Text = (laquesea).ToString();
                            }
                            
                        }
                    }
                    
                }
                else
                {
                    if (accion == 'B')
                    {
                        //textPromedioCaja2.Text = (vtTotalImporte / Convert.ToDecimal(labelContadorCajas.Text)).ToString();
                    }
                    else
                    {
                        if (radioGroup1.EditValue.ToString().Equals("C")) //Agrege esto para nuevos tipos de pago----------
                        {
                            Decimal.TryParse(textPrecioCaja.Text, style, culture, out valor);
                            if (Convert.ToDecimal(textKgcortadosxdia.Text) > 0)
                            {
                                vtTotalImporte = Convert.ToDecimal(textKgcortadosxdia.Text) * valor;
                            }
                            else
                            {
                                Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                                vtTotalImporte = valor;

                            }
                        }
                        if (radioGroup1.EditValue.ToString().Equals("D"))
                        {
                            decimal laquesea = decimal.Round(vtTotalImporte / Convert.ToDecimal(labelContadorCortador.Text) / vtCortadores, 4);
                            textPromedioCaja2.Text = (laquesea).ToString();
                        }else
                        {//----------------------------------------------------------------------------------------------------------------------
                            if (Convert.ToDecimal(labelContadorCajas.Text) > 0)
                            {
                                decimal laquesea = decimal.Round(vtTotalImporte / Convert.ToDecimal(labelContadorCajas.Text), 4);
                                textPromedioCaja2.Text = (laquesea).ToString();
                            }
                        }
                       
                    }
                    
                   
                }
                for (int x = 0; x < gridView1.RowCount; x++)
                {
                    int xRow = gridView1.GetVisibleRowHandle(x);
                    Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                    if ((/*Convert.ToDecimal(textKgcortadosxdia.Text) == 0 || checkPagoxDia.Checked==true*/ radioGroup1.EditValue.ToString().Equals("D")) && Convert.ToDecimal(labelContadorCortador.Text) <= vtCortadores) //Nuevo Cambio (comentado) para tipos de pago
                    {
                        if (Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"]))!= vtTotalImporte / vtCortadores)
                        { 
                            gridView1.SetRowCellValue(xRow, "Importe", vtTotalImporte / vtCortadores);
                            CambioDetalle = true;
                        }
                       
                    }
                    else
                    {
                        if (gridView1.GetRowCellValue(xRow, gridView1.Columns["Id_Puesto"]).ToString().Trim().Equals("03"))
                        {
                            if (Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"])) != Convert.ToDecimal(labelPagoDiario.Text))
                            {
                                gridView1.SetRowCellValue(xRow, "Importe", Convert.ToDecimal(labelPagoDiario.Text));
                                CambioDetalle = true;
                            }
                                
                        }
                        else
                        {
                            if (radioGroup1.EditValue.ToString().Equals("D")) //egrego cambio para nuevo tipo de pago --------------------------------------------------
                            {
                                if (Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"])) != valor / vtCortadores)
                                {
                                    gridView1.SetRowCellValue(xRow, "Importe", valor * vtCortadores);
                                    CambioDetalle = true;
                                }
                            }
                            else
                            { //-----------------------------------------------------------------------------------------------------------------------
                                if (Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"])) != valor * Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"])))
                                {
                                    gridView1.SetRowCellValue(xRow, "Importe", valor * Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"])));
                                    CambioDetalle = true;
                                }
                            }

                            
                                
                        }
                        
                    }
                        
                }

            }
        }

        private void calculanuevosvaloresEspecial(char accion)
        {
            if (gridView1.RowCount > 0)
            {
                if (Convert.ToDecimal(textKgcortadosxdia.Text) == 0 && Convert.ToDecimal(labelContadorCortador.Text) <= vtCortadores)
                {
                    if (accion == 'B')
                    {

                    }
                    else
                    {
                        if (radioGroup1.EditValue.ToString().Equals("C"))
                        {
                            Decimal.TryParse(textPrecioCaja.Text, style, culture, out valor);
                            if (Convert.ToDecimal(textKgcortadosxdia.Text) > 0)
                            {
                                vtTotalImporte = Convert.ToDecimal(textKgcortadosxdia.Text) * valor;
                            }
                            else
                            {
                                Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                                vtTotalImporte = valor;

                            }
                            if (Convert.ToDecimal(labelContadorCortador.Text) > vtCortadores)
                            {
                                decimal laquesea = decimal.Round(vtTotalImporte / Convert.ToDecimal(labelContadorCortador.Text), 4);
                                //textPromedioCaja2.Text = (laquesea).ToString();
                            }
                            else
                            {
                                decimal laquesea = (((vtTotalImporte / vtCortadores) * (Convert.ToDecimal(labelContadorCortador.Text))) / (Convert.ToDecimal(labelContadorCajas.Text)));
                                // decimal laquesea = decimal.Round(((Convert.ToDecimal(labelPagoDiario.Text)/ Convert.ToDecimal(labelContadorCortador.Text))/ Convert.ToDecimal(textCajas.Text)) / vtCortadores , 4);
                                //textPromedioCaja2.Text = (laquesea).ToString();
                            }

                        }
                    }

                }
                else
                {
                    if (accion == 'B')
                    {
                        //textPromedioCaja2.Text = (vtTotalImporte / Convert.ToDecimal(labelContadorCajas.Text)).ToString();
                    }
                    else
                    {
                        if (radioGroup1.EditValue.ToString().Equals("C")) //Agrege esto para nuevos tipos de pago----------
                        {
                            Decimal.TryParse(textPrecioCaja.Text, style, culture, out valor);
                            if (Convert.ToDecimal(textKgcortadosxdia.Text) > 0)
                            {
                                vtTotalImporte = Convert.ToDecimal(textKgcortadosxdia.Text) * valor;
                            }
                            else
                            {
                                Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                                vtTotalImporte = valor;

                            }
                        }
                        if (radioGroup1.EditValue.ToString().Equals("D"))
                        {
                            decimal laquesea = decimal.Round(vtTotalImporte / Convert.ToDecimal(labelContadorCortador.Text) / vtCortadores, 4);
                            //textPromedioCaja2.Text = (laquesea).ToString();
                        }
                        else
                        {//----------------------------------------------------------------------------------------------------------------------
                            if (Convert.ToDecimal(labelContadorCajas.Text) > 0)
                            {
                                decimal laquesea = decimal.Round(vtTotalImporte / Convert.ToDecimal(labelContadorCajas.Text), 4);
                                //textPromedioCaja2.Text = (laquesea).ToString();
                            }
                        }

                    }


                }
                for (int x = 0; x < gridView1.RowCount; x++)
                {
                    int xRow = gridView1.GetVisibleRowHandle(x);
                    Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                    if ((/*Convert.ToDecimal(textKgcortadosxdia.Text) == 0 || checkPagoxDia.Checked==true*/ radioGroup1.EditValue.ToString().Equals("D")) && Convert.ToDecimal(labelContadorCortador.Text) <= vtCortadores) //Nuevo Cambio (comentado) para tipos de pago
                    {
                        if (Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"])) != vtTotalImporte / vtCortadores)
                        {
                            gridView1.SetRowCellValue(xRow, "Importe", vtTotalImporte / vtCortadores);
                            CambioDetalle = true;
                        }

                    }
                    else
                    {
                        if (gridView1.GetRowCellValue(xRow, gridView1.Columns["Id_Puesto"]).ToString().Trim().Equals("03"))
                        {
                            if (Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"])) != Convert.ToDecimal(labelPagoDiario.Text))
                            {
                                gridView1.SetRowCellValue(xRow, "Importe", Convert.ToDecimal(labelPagoDiario.Text));
                                CambioDetalle = true;
                            }

                        }
                        else
                        {
                            if (radioGroup1.EditValue.ToString().Equals("D")) //egrego cambio para nuevo tipo de pago --------------------------------------------------
                            {
                                if (Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"])) != valor / vtCortadores)
                                {
                                    gridView1.SetRowCellValue(xRow, "Importe", valor * vtCortadores);
                                    CambioDetalle = true;
                                }
                            }
                            else
                            { //-----------------------------------------------------------------------------------------------------------------------
                                if (Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Importe"])) != valor * Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"])))
                                {
                                    gridView1.SetRowCellValue(xRow, "Importe", valor * Convert.ToInt32(gridView1.GetRowCellValue(xRow, gridView1.Columns["Cajas"])));
                                    CambioDetalle = true;
                                }
                            }



                        }

                    }

                }

            }
        }

        private void NuevaHoja()
        {
            textIdHojaNomina.Enabled = true;
            vtId_JefeCuadrilla = "";
            vtSecuencia = 0;
            vtTotalImporte = 0;
            vtCortadores=0;
            Abrir = false;
            Bandera = false;
            
            CambioDetalle = false;
            valor=0;

            labelEstatus.Text = "";
            bloquerHoja(true);
            btnCerrarNomina.Visible = true;
            textIdHojaNomina.Text = "";

            dateFecha.EditValue = DateTime.Now;
            labelEmpresa.Text = "";
            labelPagoDiario.Text = "0";
            labelNombreJefeCuadrilla.Text = "0";

            textTopepgoxDia.Text = "0";
            textTotalCortePgoxDia.Text = "0";
            textKgcortadosxdia.Text = "0";
            textCajasxdia.Text = "0";
            textPagoJefeCuadrilla.Text = "0";
            textPromedioCaja.Text = "0";
            textPromedioCaja1.Text = "0";
            textPromedioCaja2.Text = "0";
            textPrecioCaja.Text = "0";

            labelContadorCortador.Text = "0";
            labelContadorTotal.Text = "0";
            labelContadorCajas.Text = "0";
            labelImporteCortador.Text = "0";
            labelImporte.Text = "0";

            checkFestivo.Checked = false;
            checkPagoxDia.Checked = false;
            checkPagoFalso.Checked = false;

            limpiarCamposDetalle();
            gridControl1.DataSource = null;

            lueCuadrillas.EditValue = null;

            radioGroup1.EditValue = "C";

            cargarParametros();

        }

        private void insertanuevosvalores()
        {
            if (gridView1.RowCount > 0 && CambioDetalle==true)
            {
                for (int y = 0; y < gridView1.RowCount; y++)
                {

                    int xRow2 = gridView1.GetVisibleRowHandle(y);
                    string hoja, secuencia, empleado;
                    int cajas;
                    decimal importe;
                    hoja = gridView1.GetRowCellValue(xRow2, gridView1.Columns["Id_HojaNomina"]).ToString();
                    secuencia = gridView1.GetRowCellValue(xRow2, gridView1.Columns["Id_secuencia"]).ToString();
                    empleado = gridView1.GetRowCellValue(xRow2, gridView1.Columns["Id_empleado"]).ToString();
                    cajas = Convert.ToInt32(gridView1.GetRowCellValue(xRow2, gridView1.Columns["Cajas"]));
                    importe = Convert.ToDecimal(gridView1.GetRowCellValue(xRow2, gridView1.Columns["Importe"]));
                    guardarDetalle(hoja, secuencia, empleado, cajas, importe,false);
                    textIdHojaNomina.Enabled = false;
                }
                CambioDetalle = false;
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
                if (verificajefecuadrillaxfecha() || Abrir==true)
                {
                    cargarParametros();
                    if (Abrir == false)
                    {
                        if (textIdHojaNomina.Text.Trim().Length >= 6)
                        {
                            guardarHoja();
                        }

                    }
                }
                else
                {
                    XtraMessageBox.Show("Esta cuadrilla ya se encuentra en otra Hoja de la misma fecha, Favor de verificar.");
                    lueCuadrillas.EditValue = null;
                }
                
            }
        }

        private Boolean verificajefecuadrillaxfecha()
        {
            CLS_HojaNomina Clase = new CLS_HojaNomina();
            Clase.Id_Cuadrilla = lueCuadrillas.EditValue.ToString();
            DateTime Fecha = Convert.ToDateTime(dateFecha.Text.Trim());
            Clase.Fecha_HojaNomina = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            Clase.MtdVerificaCuadrillaxFecha();
            if (Clase.Exito)
            {
                if (Convert.ToInt32(Clase.Datos.Rows[0][0]) > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
                return false;
            }

        }

        private string VerificarPuesto()
        {
            
            CLS_Empleados Clase = new CLS_Empleados();
            Clase.Id_Empleado = lueEmpleados.EditValue.ToString();
            Clase.MtdSeleccionarPuestoEmpleado();
            if (Clase.Exito)
            {
                 return Clase.Datos.Rows[0][0].ToString().Trim();
            }
            return "99";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (textIdHojaNomina.Text.Trim().Length > 0)
            {
                if (lueEmpleados.EditValue != null)
                {
                    if (verificaEmpleado())
                    {
                        if (verificaxfecha(lueEmpleados.EditValue.ToString()))
                        {

                        
                            int vtNcortador=0;

                            if (VerificarPuesto().Equals("02"))
                            {
                                vtNcortador = 1;
                            }else
                            {
                                vtNcortador = 0;
                            }
                            if (Convert.ToDecimal(textCajas.Text) >= 0)
                            {
                                if (vtTotalImporte == 0 || Convert.ToDecimal(textKgcortadosxdia.Text) == 0 || /*checkPagoxDia.Checked == true*/ radioGroup1.EditValue.ToString().Equals("D")) //cambio por nuevo tipo de pago
                                {
                                    Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                                    vtTotalImporte = valor;
                                }

                                Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                                if (valor == 0 || Convert.ToDecimal(labelContadorCortador.Text) + vtNcortador > vtCortadores)
                                {
                                   if (Convert.ToDecimal(labelContadorCortador.Text) + vtNcortador > vtCortadores)
                                    {
                                        if (vtNcortador > 0)
                                        {
                                            if (radioGroup1.EditValue.ToString().Equals("D"))//agrege para nuevo tipo pago-----------------------
                                            {
                                                textPromedioCaja2.Text = ((vtTotalImporte / (Convert.ToDecimal(labelContadorCortador.Text) + vtNcortador)) / vtCortadores).ToString();
                                            }
                                            else
                                            {
                                                if (radioGroup1.EditValue.ToString().Equals("C"))//agrege para nuevo tipo pago-----------------------
                                                {
                                                    textPromedioCaja2.Text = (((vtTotalImporte / (Convert.ToDecimal(labelContadorCortador.Text) + vtNcortador)) / Convert.ToDecimal(textCajas.Text))/vtCortadores).ToString();
                                                }
                                                else
                                                {
                                                    textPromedioCaja2.Text = ((vtTotalImporte / (Convert.ToDecimal(labelContadorCortador.Text) + vtNcortador)) / Convert.ToDecimal(textCajas.Text)).ToString();
                                                }
                                               
                                            }
                                            
                                        }
                                    
                                    }else
                                    {
                                        textPromedioCaja2.Text = ((vtTotalImporte / vtCortadores) / vtCortadores).ToString();//Convert.ToDecimal(textCajas.Text)).ToString();
                                    }
                                
                                }
                                else
                                {
                                    if (radioGroup1.EditValue.ToString().Equals("D"))//agrege para nuevo tipo pago-----------------------
                                    {
                                        textPromedioCaja2.Text = ((vtTotalImporte / vtCortadores) / vtCortadores).ToString();
                                    }
                                    if (radioGroup1.EditValue.ToString().Equals("C"))
                                    {
                                        textPromedioCaja2.Text = (((vtTotalImporte/vtCortadores)* (Convert.ToDecimal(labelContadorCortador.Text) + vtNcortador))/(Convert.ToDecimal(textCajas.Text)+Convert.ToDecimal(labelContadorCajas.Text) )).ToString();
                                    }//---------------------------------------------------------------------------------------------------

                                }
                                Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                                if ( Convert.ToDecimal(labelContadorCortador.Text) + vtNcortador <= vtCortadores)
                                {
                                    guardarDetalle(textIdHojaNomina.Text.Trim(), DosCero(vtSecuencia.ToString()), lueEmpleados.EditValue.ToString(), Convert.ToInt32(Convert.ToDecimal(textCajas.Text)), (vtTotalImporte / vtCortadores), true);
                                    
                                }
                                else
                                {
                                    if (radioGroup1.EditValue.ToString().Equals("D"))//agrege para nuevo tipo pago-----------------------
                                    {
                                        guardarDetalle(textIdHojaNomina.Text.Trim(), DosCero(vtSecuencia.ToString()), lueEmpleados.EditValue.ToString(), Convert.ToInt32(Convert.ToDecimal(textCajas.Text)), (vtCortadores * valor), true);
                                        
                                    }
                                    else
                                    {
                                        guardarDetalle(textIdHojaNomina.Text.Trim(), DosCero(vtSecuencia.ToString()), lueEmpleados.EditValue.ToString(), Convert.ToInt32(Convert.ToDecimal(textCajas.Text)), (Convert.ToDecimal(textCajas.Text) * valor), true);
                                        
                                    }
                                    
                                }
                            
                                if (gridView1.RowCount > 1)
                                {
                                    calculanuevosvalores('A');
                                    insertanuevosvalores();
                                }
                                limpiarCamposDetalle();

                            }
                            else
                            {
                                XtraMessageBox.Show("Falta ingresar el numero de cajas");
                                textCajas.Focus();
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Este empleado ya se encuentra en otra Hoja con la misma fecha. Verifique por favor.");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Este empleado ya se encuentra en el detalle. Verifique por favor.");
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
            if (textIdHojaNomina.Text.Trim().Length>0)
            {
                cargarParametros();
                RefrescaPrecioPromedioCaja();
            }
            
        }

        private void  RefrescaPrecioPromedioCaja()
        {
            if (textPrecioCaja.Text.Trim().Length > 0)
            {

                Decimal.TryParse(textPrecioCaja.Text, style, culture, out valor);
                if (Convert.ToDecimal(textKgcortadosxdia.Text) > 0)
                {
                    if (radioGroup1.EditValue.ToString().Equals("D")) //Agrege para nuevo tipo de pago
                    {
                        Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                        vtTotalImporte = valor;
                    }
                    else
                    {//-------------------------------------------------------------------------------------
                        vtTotalImporte = Convert.ToDecimal(textKgcortadosxdia.Text) * valor;
                    }
                   
                }else
                {
                  
                        Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                        vtTotalImporte = valor;
                    
                }
                
                if (vtTotalImporte > 0 && Convert.ToDecimal(textCajasxdia.Text) > 0)
                {
                    textPromedioCaja2.Text = (vtTotalImporte / Convert.ToDecimal(textCajasxdia.Text)).ToString();
                    textPromedioCaja.Text = (Convert.ToDecimal(textKgcortadosxdia.Text) / Convert.ToDecimal(textCajasxdia.Text)).ToString();
                }

            }
        }

        private void checkFestivo_CheckedChanged(object sender, EventArgs e)
        {
            if (Abrir == false )
            {
                cargarParametros();
                RefrescaPrecioPromedioCaja();
                if (textIdHojaNomina.Text.Trim().Length >= 6)
                {
                    calculanuevosvalores('A');
                    insertanuevosvalores();
                    ContadorTotal();
                    guardarHoja();
                }
                
            }
           
        }

        private void btnAbrirHoja_Click(object sender, EventArgs e)
        {
            Frm_AbrirHoja Ventana = new Frm_AbrirHoja();
           
            if (tempFechaInicio!= string.Empty)
            {
                Ventana.fini = tempFechaInicio;
                Ventana.ffin = tempFechaFin;
                Ventana.categoria = tempIndexSel;
               
            }
            Ventana.TEstatus = tempEstaus;
            Ventana.ShowDialog();
            if (Ventana.HojaSeleccionada!=String.Empty)
            {
                NuevaHoja();
                textIdHojaNomina.Text = Ventana.HojaSeleccionada.Trim();
                abrirHoja();
                lueCuadrillas.Focus();
                textIdHojaNomina.Enabled = false;
            }

            tempFechaInicio= Ventana.fini;
            tempFechaFin= Ventana.ffin;
            tempIndexSel= Ventana.categoria;
            tempEstaus = Ventana.TEstatus;
            
        }

        private void Frm_Nomina_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                btnAbrirHoja.PerformClick();
            }
        }

        private void labelContadorTotal_EditValueChanged(object sender, EventArgs e)
        {
            if (Abrir == false)
            {
                if (textIdHojaNomina.Text.Trim().Length >= 6)
                {
                    guardarHoja();
                }
            }
            
        }

        private void textCajas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnAgregar.PerformClick();
            }
        }

        private void limpiarCamposDetalle()
        {
            lueEmpleados.EditValue = null;
            textCajas.Text = "0";
            vtSecuencia = 0;
            lueEmpleados.Focus();
        }

        private Boolean verificaEmpleado()
        {
            if (gridView1.RowCount > 0)
            {
                for (int y = 0; y < gridView1.RowCount; y++)
                {

                    int xRow2 = gridView1.GetVisibleRowHandle(y);
                   
                    if (gridView1.GetRowCellValue(xRow2, gridView1.Columns["Id_empleado"]).ToString().Equals(lueEmpleados.EditValue) && Convert.ToInt32(gridView1.GetRowCellValue(xRow2, gridView1.Columns["Id_secuencia"]))!=vtSecuencia)
                    {
                        return false;
                    }
                   
                }
                return true;
            }
            return true;
        }

        private Boolean verificaxfecha(string empleado)
        {
            CLS_Empleados clase = new CLS_Empleados();
            clase.Id_Empleado = empleado;
            DateTime Fecha = Convert.ToDateTime(dateFecha.Text.Trim());
            clase.Fecha_HojaNomina = Fecha.Year.ToString() + DosCero(Fecha.Month.ToString()) + DosCero(Fecha.Day.ToString());
            clase.MtdSeleccionarEmpleadoxfecha();
            if (clase.Exito)
            {
                if (Convert.ToInt32(clase.Datos.Rows[0][0]) > 0)
                {
                    return false;
                }else
                {
                    return true;
                }
                
            }
            else
            {
                XtraMessageBox.Show(clase.Mensaje);
                return false;
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    lueEmpleados.EditValue = row["Id_empleado"].ToString();
                    textCajas.Text = row["Cajas"].ToString();
                    vtSecuencia = Convert.ToInt32(row["Id_secuencia"]);
                    
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void checkPagoxDia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPagoxDia.Checked)
            {
                if (Convert.ToDecimal(textCajasxdia.Text) == 0)
                {

                    textCajas.Text = vtCortadores.ToString();
                }
                else
                {
                    decimal a = Convert.ToDecimal(textCajasxdia.Text);
                    decimal b = vtCortadores;
                    decimal valor = (a / b);
                    textCajas.Text = valor.ToString();
                }
                
                textCajas.ReadOnly = true;
                
            }
            else
            {
                textCajas.ReadOnly = false;
                textCajas.Text = "0";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCamposDetalle();
        }

        private void lueEmpleados_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (lueEmpleados.EditValue != null)
                {
                    textCajas.Focus();
                }
            }
        }

        private void btnELiminar_Click(object sender, EventArgs e)
        {
            if (vtSecuencia > 0)
            {

                if (Convert.ToDecimal(textKgcortadosxdia.Text) > 0)
                {
                    EliminarDetalle();
                    limpiarCamposDetalle();
                }
                else
                {
                    DataRow rowg = null;
                    foreach (int i in this.gridView1.GetSelectedRows())
                    {

                        DataRow rowt = this.gridView1.GetDataRow(i - 1);
                        rowg = rowt;
                    }

                    int vtNcortador = 0;
                    if (VerificarPuesto().Equals("02"))
                    {
                        vtNcortador = 1;
                    }
                    else
                    {
                        vtNcortador = 0;
                    }

                    EliminarDetalle();
                    if (vtTotalImporte == 0 || Convert.ToDecimal(textKgcortadosxdia.Text) == 0 || checkPagoxDia.Checked == true)
                    {
                        Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
                        vtTotalImporte = valor;
                    }

                    Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                    if (valor == 0 || Convert.ToDecimal(labelContadorCortador.Text) - vtNcortador > vtCortadores)
                    {
                        if (Convert.ToDecimal(labelContadorCortador.Text) - vtNcortador > vtCortadores)
                        {

                            decimal vtCajas = Convert.ToDecimal(rowg["Cajas"]);
                            textPromedioCaja2.Text = ((vtTotalImporte / (Convert.ToDecimal(labelContadorCortador.Text) - vtNcortador)) / Convert.ToDecimal(rowg["Cajas"])).ToString();
                        }
                        else
                        { 
                            textPromedioCaja2.Text = ((vtTotalImporte / (vtCortadores)) / Convert.ToDecimal(rowg["Cajas"])).ToString();
                        }

                    }
                    else
                    {
                        if (rowg != null)
                        {
                        textPromedioCaja2.Text = ((vtTotalImporte / (vtCortadores)) / Convert.ToDecimal(rowg["Cajas"])).ToString();
                        }
                    }


                    if (gridView1.RowCount > 1)
                    {
                        calculanuevosvalores('B');
                        insertanuevosvalores();
                    }
                    limpiarCamposDetalle();
                }


                ContadorTotal(); 

            }
        }

        private void EliminarDetalle()
        {
            CLS_HojaNominaDetalle Clase = new CLS_HojaNominaDetalle();
            Clase.Id_HojaNomina = textIdHojaNomina.Text.Trim();
            Clase.Id_secuencia = DosCero( vtSecuencia.ToString());
            Clase.MtdEliminarHojaNominaDetalle();
            if (Clase.Exito)
            {
                CargarDetalle();
               // XtraMessageBox.Show("Se ha Eliminado el registro seleccionado con exito");
                limpiarCamposDetalle();

            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void btnCerrarNomina_Click(object sender, EventArgs e)
        {
            decimal vimporte = 0;
            decimal vtope = 0;
            Decimal.TryParse(labelImporteCortador.Text, style, culture, out valor);
            vimporte = valor;
            Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
            vtope = valor;
            if (vimporte < vtope)
            {
                ReCalculoPagoMinxCaja();
                verificaimportesEspecial();
            }
            else
            {
                verificaimportes();
            }
            
            if (textIdHojaNomina.Text.Trim().Length >= 6)
            {
                DialogResult = XtraMessageBox.Show("¿Esta Seguro que desea Cerrar esta hoja?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    labelEstatus.Text = "NOMINA CERRADA";
                    guardarHoja();
                    bloquerHoja(false);
                    btnCerrarNomina.Visible = false;
                }
                
            }
            
        }

        

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView vista = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            try
            {
                if( vista.GetRowCellValue(e.RowHandle, vista.Columns["Id_Puesto"]).ToString().Trim().Equals("03"))
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
            }
            //controlamos cualquier excepcion
            catch { };
        }

        private string GeneraConsecutivo(string Folio)
        {
            string FolioOriginal = "";
            FolioOriginal = Folio.Substring(0, Folio.IndexOf("_"));
            switch (Folio.Substring(Folio.Length - 1))
            {
                case "A":
                    return FolioOriginal + "_B";
                    
                case "B":
                    return FolioOriginal + "_C";
                    
                case "C":
                    return FolioOriginal + "_D";
                   
                case "D":
                    return FolioOriginal + "_E";
                   
                case "E":
                    return FolioOriginal + "_F";
                   
                case "F":
                    return FolioOriginal + "_G";
                   
                case "G":
                    return FolioOriginal + "_H";
                    
                case "H":
                    return FolioOriginal + "_I";
                   
                case "I":
                    return FolioOriginal + "_J";
                    
            }
            return "";
        }

        private void btnIncluirApoyo_Click(object sender, EventArgs e)
        {
            if (textIdHojaNomina.Text.Trim().Length >= 6)
            {
                string FolioNuevo = "", FolioOriginal = "";

                FolioNuevo = textIdHojaNomina.Text;

                Boolean SecuenciaAprovada = false;

                do
                {
                    if (FolioNuevo.IndexOf("_") >= 0)
                    {
                        if (FolioOriginal.Trim().Length == 0)
                        {
                            FolioOriginal = FolioNuevo.Substring(0, FolioNuevo.IndexOf("_"));
                        }

                        FolioNuevo = GeneraConsecutivo(FolioNuevo);
                    }
                    else
                    {
                        if (FolioOriginal.Trim().Length == 0)
                        {
                            FolioOriginal = textIdHojaNomina.Text;
                        }

                        FolioNuevo = FolioNuevo + "_A";


                    }

                    CLS_HojaNomina Clase = new CLS_HojaNomina();

                    Clase.Id_HojaNomina = FolioNuevo;
                    Clase.MtdSeleccionarHojaNomina();
                    if (Clase.Exito)
                    {
                        if (Clase.Datos.Rows.Count > 0)
                        {

                        }
                        else
                        {
                            SecuenciaAprovada = true;
                        }

                    }
                } while (SecuenciaAprovada == false);
                NuevaHoja();
                textIdHojaNomina.Text = FolioNuevo;
                guardarHoja();
            }
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            NuevaHoja();
        }

        private void btn_Empleados_Click(object sender, EventArgs e)
        {
            Frm_Empleados vusuarios = new Frm_Empleados();
            vusuarios.UsuariosLogin = UsuariosLogin.Trim();
            vusuarios.ShowDialog();
            cargarEmpleados();
        }

        private void btnCambiaOrden_Click(object sender, EventArgs e)
        {
            Frm_CambiaOrden Ventana = new Frm_CambiaOrden();
            Ventana.Orden = textIdHojaNomina.Text.Trim();
            Ventana.UsuariosLogin = UsuariosLogin.Trim();
            Ventana.ShowDialog();
            if (Ventana.nuevaOrden!=null)
            {
                textIdHojaNomina.Text = Ventana.nuevaOrden;
                RecargarInfoCaptura();
                ContadorTotal();
                lueCuadrillas.Focus();
                textIdHojaNomina.Enabled = false;
            }
            
        }

        private void textPromedioCaja2_TextChanged(object sender, EventArgs e)
        {
            textPromedioCaja3.Text = textPromedioCaja2.Text;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
       {
            if (textIdHojaNomina.Text.Trim().Length > 0)
            {
                if (radioGroup1.EditValue.ToString().Equals("D"))
                {
                    actualizapagoxdia();

                }
                if (radioGroup1.EditValue.ToString().Equals("C"))
                {
                    calculanuevosvalores('A');
                }
                if (radioGroup1.EditValue.ToString().Equals("S"))
                {
                    actualizapagoxdia();
                }
                ContadorTotal();
            }
            
        }

        private void actualizapagoxdia()
        {

            

            cargarParametros();

            Decimal.TryParse(textTopepgoxDia.Text, style, culture, out valor);
            vtTotalImporte = valor;

            for (int x = 0; x < gridView1.RowCount; x++)
            {
                

                int xRow = gridView1.GetVisibleRowHandle(x);
                //gridView1.SetRowCellValue(xRow, "Cajas", vtCortadores);

               
             
                    if (Convert.ToDecimal(labelContadorCortador.Text)  > vtCortadores)
                    {
                        if (radioGroup1.EditValue.ToString().Equals("D"))
                        {
                            textPromedioCaja2.Text = ((vtTotalImporte / (Convert.ToDecimal(labelContadorCortador.Text))) / vtCortadores).ToString();
                        }
                        if (radioGroup1.EditValue.ToString().Equals("C"))
                        {
                            textPromedioCaja2.Text = ((vtTotalImporte / (Convert.ToDecimal(labelContadorCortador.Text))) / Convert.ToDecimal(textCajas.Text)).ToString();
                        }
                        if (radioGroup1.EditValue.ToString().Equals("S"))
                        {
                            textPromedioCaja2.Text = ((vtTotalImporte / (Convert.ToDecimal(labelContadorCortador.Text))) / vtCortadores).ToString();
                        }

                }
                    else
                    {
                        textPromedioCaja2.Text = ((vtTotalImporte / vtCortadores) / vtCortadores).ToString();//Convert.ToDecimal(textCajas.Text)).ToString();
                    }

                Decimal.TryParse(textPromedioCaja2.Text, style, culture, out valor);
                if (Convert.ToDecimal(labelContadorCortador.Text) > vtCortadores)
                {
                    gridView1.SetRowCellValue(xRow, "Importe", valor*vtCortadores);
                }
                else
                {
                    gridView1.SetRowCellValue(xRow, "Importe", Convert.ToDecimal(labelPagoDiario.Text));
                }
                   
            }
        }

     

        private void lueCuadrillas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                lueEmpleados.Focus();
            }

        }

        private void dateFecha_EditValueChanged(object sender, EventArgs e)
        {
            if (textIdHojaNomina.Text.Trim().Length >= 6)
            {
                if (Abrir == false)
                {
                    if (Bandera == false)
                    {
                        if (verificajefecuadrillaxfecha()){
                            bool banda = false;
                            for (int x = 0; x < gridView1.RowCount; x++)
                            {
                                int xRow = gridView1.GetVisibleRowHandle(x);

                                if (verificaxfecha(gridView1.GetRowCellValue(xRow, "Id_empleado").ToString())==false)
                                {
                                    banda = true;
                                    break;
                                }
                            }

                            if (banda==false)
                            {
                                Bandera = true;
                                guardarHoja();
                            }
                            else
                            {
                                XtraMessageBox.Show("Nose puede cambiar de fecha, ya que existen empleados en otra Hoja con esa fecha, Favor de verificar");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Nose puede cambiar de fecha, ya que existe ese jefe de cuadrilla en otra Hoja con esa fecha, Favor de verificar");
                            dateFecha.EditValue = fechaactual;
                        }
                        
                    }
                    else
                    {
                        if (textIdHojaNomina.Text.Trim().Length >= 6)
                        {
                            if (verificajefecuadrillaxfecha())
                            {
                                bool banda = false;
                                for (int x = 0; x < gridView1.RowCount; x++)
                                {
                                    int xRow = gridView1.GetVisibleRowHandle(x);

                                    if (verificaxfecha(gridView1.GetRowCellValue(xRow, "Id_empleado").ToString()) == false)
                                    {
                                        banda = true;
                                        break;
                                    }
                                }

                                if (banda == false)
                                {
                                    guardarHoja();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Nose puede cambiar de fecha, ya que existen empleados en otra Hoja con esa fecha, Favor de verificar");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("Nose puede cambiar de fecha, ya que existe ese jefe de cuadrilla en otra Hoja con esa fecha, Favor de verificar");
                            }

                        }
                            
                    }
                }
            }
        }
    }
}