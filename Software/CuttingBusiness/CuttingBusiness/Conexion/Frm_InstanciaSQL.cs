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
    public partial class Frm_InstanciaSQL : DevExpress.XtraEditors.XtraForm
    {
        public string CadenaServer { get; set; }
        public Frm_InstanciaSQL()
        {
            InitializeComponent();
        }

        private void Frm_InstanciaSQL_Load(object sender, EventArgs e)
        {
            CadenaServer = string.Empty;
            Application.DoEvents();
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;

            Application.DoEvents();
            Tabla_Instancias.DataSource = instance.GetDataSources();
            // Display the contents of the table.
            this.Text = "Instancias SQL ";
            Application.DoEvents();
        }

        

        private void dtgValoresInstancia_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            e.RepositoryItem.ReadOnly = true;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            CadenaServer = string.Empty;
            foreach (int i in dtgValoresInstancia.GetSelectedRows())
            {
                if (dtgValoresInstancia.RowCount > 0)
                {
                    int FilaSelect = i;
                    DataRow row = dtgValoresInstancia.GetDataRow(FilaSelect);
                    if (row[1].ToString() != string.Empty)
                    {
                        CadenaServer = string.Format("{0}\\{1}", row[0], row[1]);
                    }
                    else
                    {
                        CadenaServer = row[0].ToString();
                    }
                    Close();
                }
            }
        }

        private void Tabla_Instancias_DoubleClick(object sender, EventArgs e)
        {
            CadenaServer = string.Empty;
            foreach (int i in dtgValoresInstancia.GetSelectedRows())
            {
                if (dtgValoresInstancia.RowCount > 0)
                {
                    int FilaSelect = i;
                    DataRow row = dtgValoresInstancia.GetDataRow(FilaSelect);
                    if (row[1].ToString() != string.Empty)
                    {
                        CadenaServer = string.Format("{0}\\{1}", row[0], row[1]);
                    }
                    else
                    {
                        CadenaServer = row[0].ToString();
                    }
                    Close();
                }
            }
        }

        
    }
}