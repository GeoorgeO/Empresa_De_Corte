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
using DevExpress.XtraBars.Helpers;

namespace CuttingBusiness
{
    public partial class Frm_Login : DevExpress.XtraEditors.XtraForm
    {
        string vIdUsuario = string.Empty;
        int vIdActivo = 0;
        string IdPerfil = "";
        public Boolean habilitado = true;
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = XtraMessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (DialogResult == DialogResult.Yes)
            {
                Close();
            }
        }
        private void btnAcceso_Click(object sender, EventArgs e)
        {
            if (btnAcceso.Text == "Acceso")
            {
                if (txtUser.Text != string.Empty && txtPass.Text != string.Empty)
                {
                    Crypto claseencripta = new Crypto();
                    SEG_Login sLogin = new SEG_Login() { Id_Usuario = txtUser.Text, Contrasena = txtPass.Text };
                    sLogin.MtdSeleccionarUsuarioLogin();
                    if (sLogin.Exito)
                    {
                        if (sLogin.Datos.Rows.Count > 0)
                        {
                            vIdUsuario = sLogin.Datos.Rows[0]["Id_Usuario"].ToString();
                            if (sLogin.Datos.Rows[0]["Activo"].ToString() == "True")
                            {
                                vIdActivo = 1;
                            }
                            else
                            {
                                vIdActivo = 0;
                            }
                            IdPerfil = sLogin.Datos.Rows[0]["Id_Perfil"].ToString();
                            Frm_Principal frmP = new Frm_Principal();
                            MSRegistro RegIn = new MSRegistro();
                            
                            if (vIdActivo == 1)
                            {
                                frmP.IdPerfil = IdPerfil;
                                frmP.UsuariosLogin = txtUser.Text;
                                frmP.Show();
                                this.Hide();
                            }
                            else
                            {
                                XtraMessageBox.Show("Este usuario esta inactivo en el sistema");
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Usuario o Contraseña Incorrectos o El Usuario Esta Inactivo");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show(sLogin.Mensaje);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Faltan Datos por Capturar Usuario y/o Password");
                }
            }
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            Frm_Conexiones frm = new Frm_Conexiones();
            frm.ShowDialog();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13 && txtUser.Text!=string.Empty)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txtPass.Text != string.Empty)
            {
                btnAcceso.Focus();
            }
        }
        
        private void Frm_Login_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
            MSRegistro RegOut = new MSRegistro();
            SkinForm.LookAndFeel.SetSkinStyle(RegOut.GetSetting("ConexionSQL", "Sking"));
        }

        private void Frm_Login_Shown(object sender, EventArgs e)
        {
            txtUser.Focus();
            MSRegistro RegOut = new MSRegistro();
            SkinForm.LookAndFeel.SetSkinStyle(RegOut.GetSetting("ConexionSQL", "Sking"));
        }
    }
}