using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace CapaDeDatos
{
    class MSRegistro
    {
        const string NombreProyecto = "CuttingBusiness";
        public string GetSetting(string section, string key, string sDefault)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\" + NombreProyecto + "\\" + section);
            string s = sDefault;
            if (rk != null) s = (string)rk.GetValue(key);
            return s;
        }
        public string GetSetting(string section, string key)
        {
            return GetSetting(section, key, "");
        }
        public void SaveSetting(string section, string key, string setting)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\" + NombreProyecto + "\\" + section);
            rk.SetValue(key, setting);
        }
    }
}
