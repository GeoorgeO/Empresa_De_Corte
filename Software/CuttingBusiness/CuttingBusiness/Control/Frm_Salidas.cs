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
using System.Net;

namespace CuttingBusiness
{
    public partial class Frm_Salidas : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Salidas()
        {
            InitializeComponent();
        }

        private void Frm_Salidas_Load(object sender, EventArgs e)
        {
            String hostName = string.Empty;
            hostName = Dns.GetHostName();
            
        }
    }
}