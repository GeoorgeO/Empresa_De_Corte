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
    public partial class Frm_Parametros_PSC : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Parametros_PSC()
        {
            InitializeComponent();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (spFilaInicio.Value > 0)
            {
                if (spFecha.Value > 0)
                {
                    if (spODC.Value > 0)
                    {
                        if (spUbicacion.Value > 0)
                        {
                            if (spPesada.Value > 0)
                            {
                                if (spPlacas.Value > 0)
                                {
                                    if (spHuertas.Value > 0)
                                    {
                                        if (spProductor.Value > 0)
                                        {
                                            if (spCajas.Value > 0)
                                            {
                                                if (spKilos.Value > 0)
                                                {
                                                    if (spVariedad.Value > 0)
                                                    {
                                                        if (spJefeCuadrilla.Value > 0)
                                                        {
                                                            if (spCajasZ.Value > 0)
                                                            {
                                                                if (spFolioZ.Value > 0)
                                                                {
                                                                    if (spJefeArea.Value > 0)
                                                                    {
                                                                        ColumnasExcel modparam = new ColumnasExcel();
                                                                        //Tab Carga Excel
                                                                        modparam.Row_PSC_Inicio = Convert.ToInt32(spFilaInicio.Value);
                                                                        modparam.Col_PSC_Fecha = Convert.ToInt32(spFecha.Value);
                                                                        modparam.Col_PSC_ODC = Convert.ToInt32(spODC.Value);
                                                                        modparam.Col_PSC_Ubicacion = Convert.ToInt32(spUbicacion.Value);
                                                                        modparam.Col_PSC_Pesada = Convert.ToInt32(spPesada.Value);
                                                                        modparam.Col_PSC_Placas = Convert.ToInt32(spPlacas.Value);
                                                                        modparam.Col_PSC_Huertas = Convert.ToInt32(spHuertas.Value);
                                                                        modparam.Col_PSC_Productor = Convert.ToInt32(spProductor.Value);
                                                                        modparam.Col_PSC_Cajas = Convert.ToInt32(spCajas.Value);
                                                                        modparam.Col_PSC_Kilos = Convert.ToInt32(spKilos.Value);
                                                                        modparam.Col_PSC_Variedad = Convert.ToInt32(spVariedad.Value);
                                                                        modparam.Col_PSC_JefeCuadrilla = Convert.ToInt32(spJefeCuadrilla.Value);
                                                                        modparam.Col_PSC_CajasZ = Convert.ToInt32(spCajasZ.Value);
                                                                        modparam.Col_PSC_FolioZ = Convert.ToInt32(spFolioZ.Value);
                                                                        modparam.Col_PSC_JefeArea = Convert.ToInt32(spJefeArea.Value);
                                                                        modparam.MtdModificar();
                                                                        if (modparam.Exito)
                                                                        {
                                                                            XtraMessageBox.Show("Los Parametros fueron Cargados con Exito");
                                                                        }
                                                                        else
                                                                        {
                                                                            XtraMessageBox.Show(modparam.Mensaje);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        XtraMessageBox.Show("La columna del JefeArea debe ser mayor a 0");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    XtraMessageBox.Show("La columna del FolioZ debe ser mayor a 0");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                XtraMessageBox.Show("La columna de la CajasZ debe ser mayor a 0");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            XtraMessageBox.Show("La columna del JefeCuadrilla debe ser mayor a 0");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        XtraMessageBox.Show("La columna de la Variedad debe ser mayor a 0");
                                                    }
                                                }
                                                else
                                                {
                                                    XtraMessageBox.Show("La columna de los Kilos debe ser mayor a 0");
                                                }
                                            }
                                            else
                                            {
                                                XtraMessageBox.Show("La columna de las Cajas debe ser mayor a 0");
                                            }
                                        }
                                        else
                                        {
                                            XtraMessageBox.Show("La columna del Productor debe ser mayor a 0");
                                        }
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("La columna de las Huertas debe ser mayor a 0");
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("La columna de las Placas debe ser mayor a 0");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("La columna de la Pesada debe ser mayor a 0");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("La columna de la Ubicacion debe ser mayor a 0");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("La columna de la Fecha debe ser mayor a 0");
                    }
                }
                else
                {
                    XtraMessageBox.Show("La columna del Registro Patronal debe ser mayor a 0");
                }
            }
            else
            {
                XtraMessageBox.Show("La fila de inico debe ser mayor a 0");
            }
        }

        private void Frm_Parametros_Shown(object sender, EventArgs e)
        {
            CargarParametros();
        }
        private void CargarParametros()
        {
            ColumnasExcel param = new ColumnasExcel();
            param.MtdSeleccionar();
            if (param.Exito)
            {
                if (param.Datos.Rows.Count > 0)
                {
                    Crypto encry = new Crypto();
                    spFecha.Value =Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Fecha"].ToString());
                    spODC.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_ODC"].ToString());
                    spFilaInicio.Value= Convert.ToInt32(param.Datos.Rows[0]["Row_PSC_Inicio"].ToString());
                    spUbicacion.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Ubicacion"].ToString());
                    spPesada.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Pesada"].ToString());
                    spPlacas.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Placas"].ToString());
                    spHuertas.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Huertas"].ToString());
                    spProductor.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Productor"].ToString());
                    spCajas.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Cajas"].ToString());
                    spKilos.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Kilos"].ToString());
                    spVariedad.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_Variedad"].ToString());
                    spJefeCuadrilla.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_JefeCuadrilla"].ToString());
                    spCajasZ.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_CajasZ"].ToString());
                    spFolioZ.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_FolioZ"].ToString());
                    spJefeArea.Value = Convert.ToInt32(param.Datos.Rows[0]["Col_PSC_JefeArea"].ToString());
                }
            }
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}