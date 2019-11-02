using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Configuration;

namespace CapaDeDatos
{
    
    public class ConexionSQL
    {
        const string NombreProyecto = "CuttingBusiness";
        static public string LeerConexion()
        {
            string StrConexion = string.Empty;
            string valServer = string.Empty;
            string valDB = string.Empty;
            string valLogin = string.Empty;
            string valPass = string.Empty;
            string ProyectName = string.Empty;
            try
            {
                StrConexion = string.Empty;
                valServer = ConfigurationManager.AppSettings["ServerName"].ToString();
                valDB = ConfigurationManager.AppSettings["DataBase"].ToString();
                valLogin = ConfigurationManager.AppSettings["UserName"].ToString();
                valPass = ConfigurationManager.AppSettings["Password"].ToString();
                ProyectName = ConfigurationManager.AppSettings["ProyectName"].ToString();

                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                //SqlConnection conn = new SqlConnection(StrConexion);
                //conn.Open();
                return StrConexion;
            }
            catch
            {
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();

                valServer = RegOut.GetSetting("ConexionSQL", "Server");
                valDB = RegOut.GetSetting("ConexionSQL", "DBase");
                valLogin = RegOut.GetSetting("ConexionSQL", "User");
                valPass = RegOut.GetSetting("ConexionSQL", "Password");

                if (valServer != string.Empty && valDB != string.Empty && valLogin != string.Empty && valPass != string.Empty)
                {
                    valServer = DesencriptarTexto.Desencriptar(valServer);
                    valDB = DesencriptarTexto.Desencriptar(valDB);
                    valLogin = DesencriptarTexto.Desencriptar(valLogin);
                    valPass = DesencriptarTexto.Desencriptar(valPass);
                }
                else
                {
                    valServer = string.Empty;
                    valDB = string.Empty;
                    valLogin = string.Empty;
                    valPass = string.Empty;
                    ProyectName = string.Empty;
                    throw new Exception("Faltan datos de Conexion");
                }
                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                return StrConexion;
            }
        }
        static public string LeerConexionC()
        {
            string StrConexion = string.Empty;
            string valServer = string.Empty;
            string valDB = string.Empty;
            string valLogin = string.Empty;
            string valPass = string.Empty;
            string ProyectName = string.Empty;
            try
            {
                StrConexion = string.Empty;
                valServer = ConfigurationManager.AppSettings["ServerName"].ToString();
                valDB = ConfigurationManager.AppSettings["DataBase"].ToString();
                valLogin = ConfigurationManager.AppSettings["UserName"].ToString();
                valPass = ConfigurationManager.AppSettings["Password"].ToString();
                ProyectName = ConfigurationManager.AppSettings["ProyectName"].ToString();

                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                //SqlConnection conn = new SqlConnection(StrConexion);
                //conn.Open();
                return StrConexion;
            }
            catch
            {
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();

                valServer = RegOut.GetSetting("ConexionSQL", "ServerC");
                valDB = RegOut.GetSetting("ConexionSQL", "DBaseC");
                valLogin = RegOut.GetSetting("ConexionSQL", "UserC");
                valPass = RegOut.GetSetting("ConexionSQL", "PasswordC");

                if (valServer != string.Empty && valDB != string.Empty && valLogin != string.Empty && valPass != string.Empty)
                {
                    valServer = DesencriptarTexto.Desencriptar(valServer);
                    valDB = DesencriptarTexto.Desencriptar(valDB);
                    valLogin = DesencriptarTexto.Desencriptar(valLogin);
                    valPass = DesencriptarTexto.Desencriptar(valPass);
                }
                else
                {
                    valServer = string.Empty;
                    valDB = string.Empty;
                    valLogin = string.Empty;
                    valPass = string.Empty;
                    ProyectName = string.Empty;
                    throw new Exception("Faltan datos de Conexion");
                }
                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                return StrConexion;
            }

        }
        static public string LeerConexionR()
        {
            string StrConexion = string.Empty;
            string valServer = string.Empty;
            string valDB = string.Empty;
            string valLogin = string.Empty;
            string valPass = string.Empty;
            string ProyectName = string.Empty;
            try
            {
                StrConexion = string.Empty;
                valServer = ConfigurationManager.AppSettings["ServerName"].ToString();
                valDB = ConfigurationManager.AppSettings["DataBase"].ToString();
                valLogin = ConfigurationManager.AppSettings["UserName"].ToString();
                valPass = ConfigurationManager.AppSettings["Password"].ToString();
                ProyectName = ConfigurationManager.AppSettings["ProyectName"].ToString();

                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                //SqlConnection conn = new SqlConnection(StrConexion);
                //conn.Open();
                return StrConexion;
            }
            catch
            {
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();

                valServer = RegOut.GetSetting("ConexionSQL", "ServerR");
                valDB = RegOut.GetSetting("ConexionSQL", "DBaseR");
                valLogin = RegOut.GetSetting("ConexionSQL", "UserR");
                valPass = RegOut.GetSetting("ConexionSQL", "PasswordR");

                if (valServer != string.Empty && valDB != string.Empty && valLogin != string.Empty && valPass != string.Empty)
                {
                    valServer = DesencriptarTexto.Desencriptar(valServer);
                    valDB = DesencriptarTexto.Desencriptar(valDB);
                    valLogin = DesencriptarTexto.Desencriptar(valLogin);
                    valPass = DesencriptarTexto.Desencriptar(valPass);
                }
                else
                {
                    valServer = string.Empty;
                    valDB = string.Empty;
                    valLogin = string.Empty;
                    valPass = string.Empty;
                    ProyectName = string.Empty;
                    throw new Exception("Faltan datos de Conexion");
                }
                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", valServer, valDB, valLogin, valPass);
                return StrConexion;
            }

        }
        static public string LeerConexionRC(string ServerC, string DBaseC, string UserC, string PasswordC)
        {
            try
            {
                string StrConexion;
                string ValServerC = string.Empty;
                string ValDBaseC = string.Empty;
                string ValUserC = string.Empty;
                string ValPassC = string.Empty;

                if (ServerC != null && DBaseC != null && UserC != null && PasswordC != null)
                {
                    MSRegistro RegOut = new MSRegistro();
                    Crypto DesencriptarTexto = new Crypto();
                    ValServerC = DesencriptarTexto.Desencriptar(ServerC);
                    ValDBaseC = DesencriptarTexto.Desencriptar(DBaseC);
                    ValUserC = DesencriptarTexto.Desencriptar(UserC);
                    ValPassC = DesencriptarTexto.Desencriptar(PasswordC);

                }
                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", ValServerC, ValDBaseC, ValUserC, ValPassC);
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string LeerConexionL()
        {
            try
            {
                string StrConexion;
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "ServerL"));
                ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBaseL"));
                ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "UserL"));
                ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "PasswordL"));


                StrConexion = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", ValServer, ValDBase, ValUser, ValPass);
                return StrConexion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Boolean ValidaConexion()
        {
            try
            {
                string ValServer;
                string ValDBase;
                string ValUser;
                string ValPass;
                MSRegistro RegOut = new MSRegistro();
                Crypto DesencriptarTexto = new Crypto();
                try
                {
                    ValServer = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Server"));
                    ValDBase = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "DBase"));
                    ValUser = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "User"));
                    ValPass = DesencriptarTexto.Desencriptar(RegOut.GetSetting(NombreProyecto, "ConexionSQL", "Password"));
                }
                catch
                {
                    ValServer = string.Empty;
                    ValDBase = string.Empty;
                    ValUser = string.Empty;
                    ValPass = string.Empty;
                }

                if (ValServer != string.Empty && ValDBase != string.Empty && ValUser != string.Empty && ValPass != string.Empty)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", ValServer, ValDBase, ValUser, ValPass));
                        conn.Open();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                { 
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        
    }
}
