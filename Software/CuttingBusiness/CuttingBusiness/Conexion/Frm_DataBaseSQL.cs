using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CuttingBusiness
{
    public partial class Frm_DataBaseSQL : DevExpress.XtraEditors.XtraForm
    {
        public string CadenaBaseDatos { get; set; }
        public string Instancia { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string DataBase { get; set; }
        
        public Frm_DataBaseSQL()
        {
            InitializeComponent();
        }

        private void Frm_DataBaseSQL_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            BasesDeDatos(Instancia, User, Pass, DataBase);
            Application.DoEvents();
        }

        private void BasesDeDatos(string instancia, string User, string Pass, string DataBase)
        {
            // Las bases de datos propias de SQL Server
            string[] basesSys = { "master", "model", "msdb", "tempdb" };
            DataTable dt = new DataTable();
            // Usamos la seguridad integrada de Windows
            string sCnn = String.Format("Server = {0}; database = {1}; User Id ={2}; Password = {3}", instancia, DataBase, User, Pass);

            // La orden T-SQL para recuperar las bases de master
            string sel = "SELECT name FROM sysdatabases";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sel, sCnn);
                da.Fill(dt);
                dtgBaseDeDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgBaseDeDatos_DoubleClick(object sender, EventArgs e)
        {
            CadenaBaseDatos = string.Empty;
            foreach (int i in dtgValoresBaseDeDatos.GetSelectedRows())
            {
                if (dtgValoresBaseDeDatos.RowCount > 0)
                {
                    int FilaSelect = i;
                    DataRow row = dtgValoresBaseDeDatos.GetDataRow(FilaSelect);
                    CadenaBaseDatos = row[0].ToString();
                    Close();
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            CadenaBaseDatos = string.Empty;
            foreach (int i in dtgValoresBaseDeDatos.GetSelectedRows())
            {
                if (dtgValoresBaseDeDatos.RowCount > 0)
                {
                    int FilaSelect = i;
                    DataRow row = dtgValoresBaseDeDatos.GetDataRow(FilaSelect);
                    CadenaBaseDatos = row[0].ToString();
                    Close();
                }
            }
        }
    }
}