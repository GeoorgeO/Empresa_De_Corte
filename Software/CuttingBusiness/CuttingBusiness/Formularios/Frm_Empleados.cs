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
    public partial class Frm_Empleados : DevExpress.XtraEditors.XtraForm
    {
        public string UsuariosLogin { get; set; }

        const string idTipoPersona = "0001";

        private static Frm_Empleados m_FormDefInstance;
        public static Frm_Empleados DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Frm_Empleados();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Frm_Empleados()
        {
            InitializeComponent();
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

        private void CargarEmpleados()
        {
            gridControl1.DataSource = null;
            CLS_Empleados Clase = new CLS_Empleados();

            if (checkActivo.Checked)
            {
                Clase.Activo = "0";
            }
            else
            {
                Clase.Activo = "1";
            }

            Clase.MtdSeleccionarEmpleados();
            if (Clase.Exito)
            {
                gridControl1.DataSource = Clase.Datos;
            }
        }
        private void CargarPuesto()
        {
            CLS_Puestos Clase = new CLS_Puestos();

            Clase.MtdSeleccionarPuestos();
            if (Clase.Exito)
            {
                glePuesto.Properties.DisplayMember = "Nombre_Puesto";
                glePuesto.Properties.ValueMember = "Id_Puesto";
                glePuesto.EditValue = null;
                glePuesto.Properties.DataSource = Clase.Datos;
            }
        }

        private void CargarCuadrillas()
        {
            CLS_Cuadrillas Clase = new CLS_Cuadrillas();

            Clase.MtdSeleccionarCuadrillasJefes();
            if (Clase.Exito)
            {
                gleCuadrilla.Properties.DisplayMember = "Nombre_Categoria";
                gleCuadrilla.Properties.ValueMember = "Id_Cuadrilla";
                gleCuadrilla.EditValue = null;
                gleCuadrilla.Properties.DataSource = Clase.Datos;
            }
        }

        private void CargarDomicilio()
        {
            gridControl2.DataSource = null;
            CLS_Domicilios Domicilio = new CLS_Domicilios();
            Domicilio.Id_Empleado = textId.Text.Trim();
            Domicilio.id_TipoPersona = idTipoPersona;
            Domicilio.MtdSeleccionarDomicilio();
            if (Domicilio.Exito)
            {
                gridControl2.DataSource = Domicilio.Datos;
            }
        }

        private void InsertarEmpleados()
        {
            CLS_Empleados Clase = new CLS_Empleados();
            Clase.Id_Empleado = textId.Text.Trim();
            Clase.Nombre_Empleado = textEmpleado.Text.Trim();
            Clase.Fecha_Nacimiento = dateNacimiento.DateTime.Year.ToString() + DosCero(dateNacimiento.DateTime.Month.ToString()) + DosCero(dateNacimiento.DateTime.Day.ToString());
            Clase.NSS = textNSS.Text.Trim();
            if (dateAltaSegSocial.EditValue != null)
            {
                Clase.Fecha_Alta_Seg_Social = dateAltaSegSocial.DateTime.Year.ToString() + DosCero(dateAltaSegSocial.DateTime.Month.ToString()) + DosCero(dateAltaSegSocial.DateTime.Day.ToString());
            }
            else
            {
                Clase.Fecha_Alta_Seg_Social = string.Empty;
            }
            if (dateBajaSegSocial.EditValue != null)
            {
                Clase.Fecha_Baja_Seg_Social = dateBajaSegSocial.DateTime.Year.ToString() + DosCero(dateBajaSegSocial.DateTime.Month.ToString()) + DosCero(dateBajaSegSocial.DateTime.Day.ToString());
            }
            else
            {
                Clase.Fecha_Baja_Seg_Social = string.Empty;
            }
            Clase.Cuenta= textCuenta.Text.Trim();
            Clase.Tarjeta= textNoTarjeta.Text.Trim();
            if (dateAltaSegVida.EditValue != null)
            {
                Clase.Fecha_Alta_Seg_Vida = dateAltaSegVida.DateTime.Year.ToString() + DosCero(dateAltaSegVida.DateTime.Month.ToString()) + DosCero(dateAltaSegVida.DateTime.Day.ToString());
            } 
            else
            {
                Clase.Fecha_Alta_Seg_Vida = string.Empty;
            }
            if (dateBajaSegVida.EditValue != null)
            {
                Clase.Fecha_Baja_Seg_Vida = dateBajaSegVida.DateTime.Year.ToString() + DosCero(dateBajaSegVida.DateTime.Month.ToString()) + DosCero(dateBajaSegVida.DateTime.Day.ToString());
            }
            else
            {
                Clase.Fecha_Baja_Seg_Vida = string.Empty;
            }
            Clase.Id_Puesto= glePuesto.EditValue.ToString();
            if(gleCuadrilla.EditValue!=null)
            {
                Clase.Id_Cuadrilla = gleCuadrilla.EditValue.ToString();
            }
            else
            {
                Clase.Id_Cuadrilla = string.Empty;
            }
            Clase.Activo = "1";
            Clase.MtdInsertarEmpleados();
            if (Clase.Exito)
            {

                CargarEmpleados();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void InsertarDomicilio()
        {
            CLS_Domicilios Domicilio = new CLS_Domicilios();
            Domicilio.Id_Domicilio = textIdDomicilio.Text.Trim();
            Domicilio.Calle = textCalle.Text.Trim();
            Domicilio.NoInterior = textNoInterior.Text.Trim();
            Domicilio.NoExterior = textNoExterior.Text.Trim();
            Domicilio.Colonia = textColonia.Text.Trim();
            Domicilio.Codigo_Postal = textCodigoPostal.Text.Trim();
            Domicilio.Id_Ciudad = txtCiudad.Tag.ToString().Trim();
            Domicilio.Id_TipoDomicilio = textTipoDomicilio.Tag.ToString().Trim();
            Domicilio.Id_Empleado = textId.Text.Trim();
            Domicilio.id_TipoPersona = idTipoPersona;
            Domicilio.MtdInsertarDomicilio();
            if (Domicilio.Exito)
            {

                CargarDomicilio();
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
                LimpiarCamposDomicilio();
            }
            else
            {
                XtraMessageBox.Show(Domicilio.Mensaje);
            }
        }

        private void EliminarEmpleados()
        {
            CLS_Empleados Clase = new CLS_Empleados();
            Clase.Id_Empleado = textId.Text.Trim();

            Clase.MtdEliminarEmpleados();
            if (Clase.Exito)
            {
                CargarEmpleados();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCampos();
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

        private void EliminarDomicilio()
        {
            CLS_Domicilios Domicilio = new CLS_Domicilios();
            Domicilio.Id_Domicilio = textIdDomicilio.Text.Trim();
            Domicilio.MtdEliminarDomicilio();
            if (Domicilio.Exito)
            {
                CargarDomicilio();
                XtraMessageBox.Show("Se ha Eliminado el registro con exito");
                LimpiarCamposDomicilio();
            }
            else
            {
                XtraMessageBox.Show(Domicilio.Mensaje);
            }
        }

        private void LimpiarCampos()
        {
            textId.Text = "";
            textEmpleado.Text = "";
            textNoTarjeta.Text = "";
            textNSS.Text = "";
            textCuenta.Text = "";

            gleCuadrilla.EditValue = null;
            glePuesto.EditValue = null;
            labelActivo.Visible = false;
            inabilitar(true);

            gleCuadrilla.Visible = false;
            labelControl22.Visible = false;
            btnBusqCuadrilla.Visible = false;
        }

        private void LimpiarCamposDomicilio()
        {
            textIdDomicilio.Text = "";
            textCalle.Text = "";
            textNoInterior.Text = "";
            textNoExterior.Text = "";
            textEstado.Tag = "";
            textEstado.Text = "";
            txtCiudad.Tag = "";
            txtCiudad.Text = "";
            textCodigoPostal.Text = "";
            textColonia.Text = "";
            textTipoDomicilio.Tag = "";
            textTipoDomicilio.Text = "";
        }

        private void inabilitar(Boolean sino)
        {
            groupControl1.Enabled = sino;
            btnGuardar.Enabled = sino;
        }

        private void textIdProveedor_EditValueChanged(object sender, EventArgs e)
        {
            if (textId.Text == String.Empty)
            {
                xtraTabPage2.PageEnabled = false;
            }
            else
            {
                xtraTabPage2.PageEnabled = true;
            }
        }

        private void btnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                LimpiarCampos();
                LimpiarCamposDomicilio();
            }
            else
            {
                LimpiarCamposDomicilio();
            }
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                if (textId.Text.Trim().Length > 0)
                {
                    EliminarEmpleados();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario seleccionar un Empleado.");
                }
            }
            else
            {
                if (textIdDomicilio.Text.Trim().Length > 0)
                {
                    EliminarDomicilio();
                }
                else
                {
                    XtraMessageBox.Show("Es necesario seleccionar un Domicilio.");
                }
            }
        }

        private void btnBusqPuesto_Click(object sender, EventArgs e)
        {
            Frm_Puesto Clase = new Frm_Puesto();
            Clase.PaSel = true;
            Clase.ShowDialog();

            
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {
                if (textEmpleado.Text.ToString().Trim().Length > 0)
                {
                    if (glePuesto.EditValue != null)
                    {
                        if (dateNacimiento.EditValue != null)
                        {
                            InsertarEmpleados();
                        }
                        else
                        {
                            XtraMessageBox.Show("Debe colocar una fecha de Nacimiento");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Debe seleccionar un puesto");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Es necesario Agregar un nombre del Empleado");
                }
            }
            else
            {
                if (textCalle.Text.ToString().Trim().Length > 0)
                {
                    if (textNoExterior.Text.Trim().Length > 0 || textNoInterior.Text.Trim().Length > 0)
                    {
                        InsertarDomicilio();
                    }
                    else
                    {
                        XtraMessageBox.Show("Es necesario agregar un numero exterior o interior.");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Es necesario Agregar una calle.");
                }
            }
        }

        private void Frm_Empleados_Load(object sender, EventArgs e)
        {
            CargarPuesto();
            CargarEmpleados();
            CargarDomicilio();
            LimpiarCampos();
            LlenarFechas();
        }

        private void LlenarFechas()
        {
            DateTime Valor = DateTime.Now;
            dateNacimiento.EditValue = Valor.AddYears(-18);
            dateAltaSegVida.EditValue = DateTime.Now;
            dateAltaSegSocial.EditValue = DateTime.Now;
        }

        private void checkActivo_CheckedChanged(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void btnBusqEstado_Click(object sender, EventArgs e)
        {
            Frm_Ciudad Clase = new Frm_Ciudad();
            Clase.PaSel = true;
            Clase.ShowDialog();

            txtCiudad.Tag = Clase.IdCiudad;
            txtCiudad.Text = Clase.Ciudad;
            textEstado.Tag = Clase.IdEstado;
            textEstado.Text = Clase.Estado;
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView2.GetSelectedRows())
                {
                    DataRow row = this.gridView2.GetDataRow(i);
                    textIdDomicilio.Text = row["Id_Domicilio"].ToString();
                    textCalle.Text = row["Calle"].ToString();
                    textNoInterior.Text = row["NoInterior"].ToString();
                    textNoExterior.Text = row["NoExterior"].ToString();
                    textCodigoPostal.Text = row["Codigo_Postal"].ToString();
                    textColonia.Text = row["Colonia"].ToString();
                    textEstado.Tag = row["Id_Estado"].ToString();
                    textEstado.Text = row["Nombre_Estado"].ToString();
                    txtCiudad.Tag = row["Id_Ciudad"].ToString();
                    txtCiudad.Text = row["Nombre_Ciudad"].ToString();
                    textTipoDomicilio.Tag = row["Id_TipoDomicilio"].ToString();
                    textTipoDomicilio.Text = row["Nombre_TipoDomicilio"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnBusqTipoDomicilio_Click(object sender, EventArgs e)
        {
            Frm_Tipo_Domicilio tipoDomicilio = new Frm_Tipo_Domicilio();
            tipoDomicilio.PaSel = true;
            tipoDomicilio.ShowDialog();

            textTipoDomicilio.Tag = tipoDomicilio.IdTipoDomicilio;
            textTipoDomicilio.Text = tipoDomicilio.TipoDomicilio;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                labelActivo.Visible = true;
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);
                    textId.Text = row["Id_Empleado"].ToString();
                    textEmpleado.Text = row["Nombre_Empleado"].ToString();
                    dateNacimiento.EditValue = row["Fecha_Nacimiento"].ToString();
                    textNSS.Text = row["NSS"].ToString();
                    dateAltaSegSocial.EditValue = row["Fecha_Alta_Seg_Social"].ToString();
                    if (row["Fecha_Alta_Seg_Social"].ToString().Equals(""))
                    {
                        chkSinSSocial.Checked = true;
                        dateAltaSegSocial.EditValue = null;
                        dateBajaSegSocial.EditValue = null;
                        textNSS.Text = "";
                    }
                    dateBajaSegSocial.EditValue = row["Fecha_Baja_Seg_Social"].ToString();
                    textCuenta.Text = row["Cuenta"].ToString();
                    textNoTarjeta.Text = row["Tarjeta"].ToString();
                    dateAltaSegVida.EditValue = row["Fecha_Alta_Seg_Vida"].ToString();
                    dateBajaSegVida.EditValue = row["Fecha_Baja_Seg_Vida"].ToString();
                    if (row["Fecha_Alta_Seg_Vida"].ToString().Equals(""))
                    {
                        chkSinSVida.Checked = true;
                        dateAltaSegVida.EditValue = null;
                        dateBajaSegVida.EditValue = null;
                    }
                    
                    glePuesto.EditValue = row["Id_Puesto"].ToString();
                    //textEmpleado.Text = row["Nombre_Puesto"].ToString();
                    gleCuadrilla.EditValue = row["Id_Cuadrilla"].ToString();
                    //textEmpleado.Text = row["Nombre_Categoria"].ToString();
                    if(row["Activo"].ToString().Equals("True"))
                    {
                        labelActivo.Text = "Activo";
                        labelActivo.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        groupControl1.Enabled = true;
                        groupControl2.Enabled = true;
                        btnGuardar.Enabled = true;
                        btnEliminar.Caption = "Inabilitar";
                    }
                    else
                    {
                        labelActivo.Text = "Inactivo";
                        labelActivo.ForeColor = System.Drawing.Color.Maroon;
                        groupControl1.Enabled = false;
                        groupControl2.Enabled = false;
                        btnGuardar.Enabled = false;
                        btnEliminar.Caption = "Habilitar";
                    }
                }
                CargarDomicilio();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void glePuesto_EditValueChanged(object sender, EventArgs e)
        {
            if (glePuesto.EditValue != null)
            {
                if (glePuesto.EditValue.ToString().Trim().Equals("01"))
                {
                    gleCuadrilla.Visible = true;
                    labelControl22.Visible = true;
                    btnBusqCuadrilla.Visible = true;

                    CargarCuadrillas();
                }
                else
                {
                    gleCuadrilla.Visible = false;
                    labelControl22.Visible = false;
                    btnBusqCuadrilla.Visible = false;
                }
            }
            
        }

        private void btnBusqCuadrilla_Click(object sender, EventArgs e)
        {
            Frm_Cuadrilla Clase = new Frm_Cuadrilla();
            Clase.ShowDialog();
            CargarCuadrillas();
        }

        private void chkSinSSocial_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSinSSocial.Checked==true)
            {
                dateAltaSegSocial.Enabled = false;
                dateAltaSegSocial.EditValue = null;
                dateBajaSegSocial.Enabled = false;
                dateBajaSegSocial.EditValue = null;
                textNSS.Enabled = false;
            }
            else
            {
                dateAltaSegSocial.Enabled = true;
                dateAltaSegSocial.EditValue = DateTime.Now;
                dateBajaSegSocial.Enabled = true;
                dateBajaSegSocial.EditValue = null;
                textNSS.Enabled = true;
            }
        }

        private void chkSinSVida_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSinSVida.Checked == true)
            {
                dateAltaSegVida.Enabled = false;
                dateAltaSegVida.EditValue = null;
                dateBajaSegVida.Enabled = false;
                dateBajaSegVida.EditValue = null;
            }
            else
            {
                dateAltaSegVida.Enabled = true;
                dateAltaSegVida.EditValue = DateTime.Now;
                dateBajaSegVida.Enabled = true;
                dateBajaSegVida.EditValue = null;
            }
        }

       
    }
}