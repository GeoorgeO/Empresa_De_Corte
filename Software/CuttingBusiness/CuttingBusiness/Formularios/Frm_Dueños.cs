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
    public partial class Frm_Dueños : DevExpress.XtraEditors.XtraForm
    {
        public Boolean PaSel { get; set; }
        public Frm_Dueños()
        {
          
            InitializeComponent();
        }

    }
}