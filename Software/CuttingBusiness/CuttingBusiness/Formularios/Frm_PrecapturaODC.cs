﻿using System;
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
    public partial class Frm_PrecapturaODC : DevExpress.XtraEditors.XtraForm
    {

        private static Frm_PrecapturaODC m_FormDefInstance;
        public static Frm_PrecapturaODC DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_PrecapturaODC();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public string UsuariosLogin { get; set; }

        public Frm_PrecapturaODC()
        {
            InitializeComponent();
        }

        private void CargarPrecapturaODC()
        {
            dtgPreCaptura.DataSource = null;
            CLS_PrecapturaODC Clase = new CLS_PrecapturaODC();

            Clase.MtdSeleccionarPrecapturaODC();
            if (Clase.Exito)
            {
                dtgPreCaptura.DataSource = Clase.Datos;
            }
        }

        private void InsertarPrecapturaODC()
        {
            CLS_PrecapturaODC Clase = new CLS_PrecapturaODC();
            Clase.Id_PrecapturaODC = textId.Text.Trim();
            Clase.JefeCuadrilla = textJefeCuadrilla.Text.Trim();
            Clase.Id_Huerta = textHuerta.Tag.ToString();
            Clase.Transportista = textTransportista.Text.Trim();
            Clase.Placas = textPlacas.Text.Trim();
            Clase.Id_TipoCorte = textTipoCorte.Tag.ToString();
            Clase.Id_Empaque = textEmpaque.Tag.ToString().Trim();
            Clase.Id_Jefe_Area = textJefeArea.Tag.ToString().Trim();
            Clase.ODC = textODC.Text.Trim();
            Clase.Candado = textCandado.Text.Trim();
            if (checkPSobreBanda.Checked)
            {
                Clase.PSobreBanda = "1";
                Clase.Precio = 0;
            }
            else
            {
                Clase.PSobreBanda = "0";
                Clase.Precio = Convert.ToDouble(textPrecio.Text.Trim()) ;
            }
            Clase.Id_Area = textArea.Tag.ToString().Trim();
            Clase.Id_Duenio = textProductor.Tag.ToString().Trim();

            Clase.Usuario = UsuariosLogin.Trim();

            Clase.MtdInsertarPrecapturaODC();
            if (Clase.Exito)
            {

                CargarPrecapturaODC();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarPrecapturaODC()
        {
            CLS_PrecapturaODC Clase = new CLS_PrecapturaODC();
            Clase.Id_PrecapturaODC = textId.Text.Trim();
            Clase.MtdEliminarPrecapturaODC();
            if (Clase.Exito)
            {
                CargarPrecapturaODC();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void LimpiarCampos()
        {
            textId.Text = "";
            textJefeCuadrilla.Text = "";
            textHuerta.Tag = "";
            textHuerta.Text = "";
            textTransportista.Text = "";
            textPlacas.Text = "";
            textCandado.Text = "";
            textODC.Text = "";
            textTipoCorte.Text = "";
            textTipoCorte.Text = "";
            textPrecio.Text = "0";
            textArea.Tag = "";
            textArea.Text = "";
            textJefeArea.Tag = "";
            textJefeArea.Text = "";
            textEmpaque.Tag = "";
            textEmpaque.Text = "";
        }

        private void inicialisarTags()
        {
            textHuerta.Tag = "";
            textTipoCorte.Tag = "";
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.dtgValPreCaptura.GetSelectedRows())
                {
                    DataRow row = this.dtgValPreCaptura.GetDataRow(i);
                    textId.Text = row["Id_PrecapturaODC"].ToString();
                    textJefeCuadrilla.Text = row["JefeCuadrilla"].ToString();
                    textHuerta.Tag = row["Id_Huerta"].ToString();
                    textHuerta.Text = row["Nombre_Huerta"].ToString();
                    textTransportista.Text = row["Transportista"].ToString();
                    textPlacas.Text = row["Placas"].ToString();
                    textCandado.Text = row["Candado"].ToString();
                    textODC.Text = row["ODC"].ToString();
                    textTipoCorte.Tag = row["Id_TipoCorte"].ToString();
                    textTipoCorte.Text = row["Nombre_TipoCorte"].ToString();
                    if (row["PSobreBanda"].ToString().Equals("True"))
                    {
                        checkPSobreBanda.Checked = true;
                    }else
                    {
                        checkPSobreBanda.Checked = false;
                    }
                    textPrecio.Text = row["Precio"].ToString();
                    textEmpaque.Tag = row["Id_Empaque"].ToString();
                    textEmpaque.Text = row["Nombre_Empaque"].ToString();
                    textJefeArea.Tag = row["Id_Jefe_Area"].ToString();
                    textJefeArea.Text = row["Nombre_Jefe_Area"].ToString();
                    textArea.Tag= row["Id_Area"].ToString();
                    textArea.Text = row["Nombre_Area"].ToString();
                    textProductor.Tag = row["Id_Duenio"].ToString();
                    textProductor.Text = row["Nombre_Duenio"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_PrecapturaODC_Load(object sender, EventArgs e)
        {
            /* if (PaSel == true)
             {
                 btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
             }
             else
             {
                 btnSeleccionar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
             }*/
            LimpiarCampos();
            CargarPrecapturaODC();
            inicialisarTags();
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textJefeCuadrilla.Text.ToString().Trim().Length > 0)
            {
                if(textHuerta.Text.ToString().Trim().Length > 0)
                {
                    if (checkPSobreBanda.Checked)
                    {
                        InsertarPrecapturaODC();
                    }
                    else
                    {
                        if (Convert.ToDouble(textPrecio.Text)> 0)
                        {
                            InsertarPrecapturaODC();
                        }
                        else
                        {
                            XtraMessageBox.Show("Es necesario ingresar el precio, sino marcar que es sobre banda.");
                        }
                    }
                    
                }
                else
                {
                    XtraMessageBox.Show("Es necesario selecionar una huerta.");
                }
            }
            else
            {
                XtraMessageBox.Show("Es necesario selecionar un jefe de cuadrilla.");
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textId.Text.Trim().Length > 0)
            {
                EliminarPrecapturaODC();
            }
            else
            {
                XtraMessageBox.Show("Es necesario seleccionar un pais.");
            }
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnJefeCuadrilla_Click(object sender, EventArgs e)
        {
            Frm_BusqJefeCuadrillas frm = new Frm_BusqJefeCuadrillas();

            frm.ShowDialog();

            textJefeCuadrilla.Tag = frm.IdEmpleado;
            textJefeCuadrilla.Text = frm.NombreEmpleado;
        }

        private void btnHuertas_Click(object sender, EventArgs e)
        {
            Frm_Huertas frm = new Frm_Huertas();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.PaSel = true;
            frm.ShowDialog();

            textHuerta.Tag = frm.IdHuerta;
            textHuerta.Text = frm.Huerta;
            textProductor.Tag = frm.IdDuenio;
            textProductor.Text = frm.Duenio;
        }

        private void btnTiposCorte_Click(object sender, EventArgs e)
        {
            Frm_TiposCorte frm = new Frm_TiposCorte();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.PaSel = true;
            frm.ShowDialog();

            textTipoCorte.Tag = frm.IdTipoCorte;
            textTipoCorte.Text = frm.TipoCorte;
        }

        private void checkPSobreBanda_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPSobreBanda.Checked)
            {
                textPrecio.Text = "0";
                textPrecio.Enabled = false;
            }else
            {
                textPrecio.Enabled = true;
            }
        }

        private void btnBusqEmpaques_Click(object sender, EventArgs e)
        {
            Frm_Empaques frm = new Frm_Empaques();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.PaSel = true;
            frm.ShowDialog();

            textEmpaque.Tag = frm.IdEmpaque;
            textEmpaque.Text = frm.Empaque;
        }

        private void btnBusqJefesArea_Click(object sender, EventArgs e)
        {
            Frm_Jefes_Area frm = new Frm_Jefes_Area();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.PaSel = true;
            frm.ShowDialog();

            textJefeArea.Tag = frm.IdJefeArea;
            textJefeArea.Text = frm.JefeArea;
        }

        private void btnBusqAreas_Click(object sender, EventArgs e)
        {
            Frm_Areas frm = new Frm_Areas();
            frm.UsuariosLogin = UsuariosLogin.Trim();
            frm.PaSel = true;
            frm.ShowDialog();

            textArea.Tag = frm.IdArea;
            textArea.Text = frm.Area;
        }
    }
}