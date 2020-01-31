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
    public partial class Frm_ViewPDFs : DevExpress.XtraEditors.XtraForm
    {
        public string Id_Entrada { get; set; }
        public string serie { get; set; }
        public string ruta { get; set; }

        public Frm_ViewPDFs()
        {
            InitializeComponent();
        }



        private void Frm_ViewPDFs_Load(object sender, EventArgs e)
        {
            CLS_Entradas sel = new CLS_Entradas();
            sel.Folio_Entrada = Id_Entrada;
            sel.Serie_Entrada = serie;
            sel.MtdSeleccionarEntradaPDF();
            if (sel.Exito)
            {
                if (sel.Datos.Rows.Count > 0 && sel.Datos.Rows[0]["FacturaPDF"] != null)
                {
                    byte[] bytes = (byte[])sel.Datos.Rows[0]["FacturaPDF"];

                    System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf", bytes);
                    this.pdfViewer1.LoadDocument(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ViewPDF.pdf");
                }
            }
            else
            {
                if (ruta.Length > 0)
                {
                    this.pdfViewer1.LoadDocument(ruta);
                }
            }
        }
    }
}