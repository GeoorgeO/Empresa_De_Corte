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
    public partial class Frm_Parametros_Nomina : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Parametros_Nomina()
        {
            InitializeComponent();
        }

        Boolean modifico = false;
        string Formato, Tipo;

        private void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane1.SelectedPage== tabPageFormatoB)
            {
                Formato = "B";
            }else
            {
                Formato = "C";
            }
            if (modifico == true)
            {
                DialogResult = XtraMessageBox.Show("¿Cambios no guardados, desea Guardarlos?,Si selecciona que no, los cambios se perderan", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                    int elimina;
                        if (tabPane1.SelectedPage == tabPageFormatoB)
                        {

                            if (Tipo.Equals("C"))
                            {
                                for (int x = 0; x < gridView3.RowCount; x++)
                                {
                                if (x == 0)
                                {
                                    elimina = 1;

                                }
                                else
                                {
                                    elimina = 0;
                                }
                                int xRow = gridView3.GetVisibleRowHandle(x);
                                    InsertarParametrosC(Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Dias_Trabajo")), Tipo, Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Sueldo_Bruto")), Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "ISR")), Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Sueldo_Neto")),elimina);
                                }
                            }
                            else
                            {
                                for (int x = 0; x < gridView4.RowCount; x++)
                                {
                                    if (x == 0)
                                    {
                                        elimina = 1;

                                    }
                                    else
                                    {
                                        elimina = 0;
                                    }
                                int xRow = gridView4.GetVisibleRowHandle(x);
                                InsertarParametrosC(Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Dias_Trabajo")), Tipo, Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Sueldo_Bruto")), Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "ISR")), Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Sueldo_Neto")),elimina);
                                }
                            }
                        }
                        else
                        {
                            if (Tipo.Equals("C"))
                            {
                                for (int x = 0; x < gridView1.RowCount; x++)
                                {
                                    if (x == 0)
                                    {
                                        elimina = 1;

                                    }
                                    else
                                    {
                                        elimina = 0;
                                    }
                                    int xRow = gridView1.GetVisibleRowHandle(x);
                                    InsertarParametrosB(Convert.ToDecimal(gridView1.GetRowCellValue(xRow, "Dias_Trabajo")), Tipo, Convert.ToDecimal(gridView1.GetRowCellValue(xRow, "Sueldo_Bruto")),elimina);
                                }
                            }
                            else
                            {
                                for (int x = 0; x < gridView2.RowCount; x++)
                                {
                                    if (x == 0)
                                    {
                                        elimina = 1;

                                    }
                                    else
                                    {
                                        elimina = 0;
                                    }
                                    int xRow = gridView2.GetVisibleRowHandle(x);
                                    InsertarParametrosB(Convert.ToDecimal(gridView2.GetRowCellValue(xRow, "Dias_Trabajo")), Tipo, Convert.ToDecimal(gridView2.GetRowCellValue(xRow, "Sueldo_Bruto")),elimina);
                                }
                            }
                        }
                    


                }
            }
            
        }

        private void CargarParamtrosB(string Tipo_Empleado)
        {
            if (Tipo_Empleado.Equals("C"))
            {
                gridControl1.DataSource = null;
            }
            else
            {
                gridControl2.DataSource = null;
            }
           
            CLS_Parametros_Nomina Clase = new CLS_Parametros_Nomina();
            Clase.Tipo_Empleado = Tipo_Empleado;
            Clase.MtdSeleccionarParametrosB();
            if (Clase.Exito)
            {
                if (Tipo_Empleado.Equals("C"))
                {
                    gridControl1.DataSource = Clase.Datos;
                }
                else
                {
                    gridControl2.DataSource = Clase.Datos;
                }
            }
        }

        private void CargarParamtrosC(string Tipo_Empleado)
        {
            if (Tipo_Empleado.Equals("C"))
            {
                gridControl3.DataSource = null;
            }
            else
            {
                gridControl4.DataSource = null;
            }
           
            CLS_Parametros_Nomina Clase = new CLS_Parametros_Nomina();
            Clase.Tipo_Empleado = Tipo_Empleado;
            Clase.MtdSeleccionarParametrosC();
            if (Clase.Exito)
            {
                if (Tipo_Empleado.Equals("C"))
                {
                    gridControl3.DataSource = Clase.Datos;
                }
                else
                {
                    gridControl4.DataSource = Clase.Datos;
                }
            }
        }


        private void InsertarParametrosB(decimal Dias_trabajo, string Tipo_Empleado,decimal Sueldo_Bruto,int elimina)
        {
            CLS_Parametros_Nomina Clase = new CLS_Parametros_Nomina();
            Clase.Dias_trabajo = Dias_trabajo;
            Clase.Tipo_Empleado = Tipo_Empleado;
            Clase.Sueldo_Bruto = Sueldo_Bruto;
            Clase.elimina = elimina;
            Clase.MtdInsertarParametrosB();
            if (Clase.Exito)
            {

                modifico = false;
                XtraMessageBox.Show("Se ha Insertado el registro con exito");
               
            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

       

        private void btnRenglon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Formato.Equals("B"))
            {
                if (Tipo.Equals("C"))
                {
                    gridView1.AddNewRow();
                    int uno; 
                        uno = gridView1.RowCount;
                }
                else
                {
                    gridView2.AddNewRow();
                }
            }else
            {
                if (Tipo.Equals("C"))
                {
                    gridView3.AddNewRow();
                }
                else
                {
                    gridView4.AddNewRow();
                }
            }
          
        }

        

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (modifico == true)
            {
                decimal uno, dos;
                int elimina;
                if (tabPane1.SelectedPage == tabPageFormatoB)
                    {
                        if (Tipo.Equals("C"))
                        {
                        
                        for (int x = 0; x < gridView1.RowCount; x++)
                            {
                                int xRow = gridView1.GetVisibleRowHandle(x);

                            
                            if (x == 0)
                            {
                                elimina = 1;

                            }else
                            {
                                elimina = 0;
                            }
                                //uno = Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Dias_Trabajo_B_C"]).ToString());
                            //dos = Convert.ToDecimal(gridView1.GetRowCellValue(xRow, gridView1.Columns["Dias_Trabajo"]).ToString());
                                InsertarParametrosB(Convert.ToDecimal(gridView1.GetRowCellValue(xRow, "Dias_Trabajo_B_C")), Tipo, Convert.ToDecimal(gridView1.GetRowCellValue(xRow, "Sueldo_Bruto_B_C")),elimina);
                            }
                        }
                        else
                        {
                       
                        for (int x = 0; x < gridView2.RowCount; x++)
                            {
                            if (x == 0)
                            {
                                elimina = 1;

                            }
                            else
                            {
                                elimina = 0;
                            }

                            int xRow = gridView2.GetVisibleRowHandle(x);
                            InsertarParametrosB(Convert.ToDecimal(gridView2.GetRowCellValue(xRow, "Dias_Trabajo_B_J")), Tipo, Convert.ToDecimal(gridView2.GetRowCellValue(xRow, "Sueldo_Bruto_B_J")),elimina);
                            }
                        }
                       
                    }
                    else
                    {
                        if (Tipo.Equals("C"))
                        {
                            for (int x = 0; x < gridView3.RowCount; x++)
                            {
                            if (x == 0)
                            {
                                elimina = 1;

                            }
                            else
                            {
                                elimina = 0;
                            }
                            int xRow = gridView3.GetVisibleRowHandle(x);
                            InsertarParametrosC(Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Dias_Trabajo_C_C")), Tipo, Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Sueldo_Bruto_C_C")), Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "ISR_C_C")), Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Sueldo_Neto_C_C")),elimina);
                            }
                        }
                        else
                        {
                            for (int x = 0; x < gridView4.RowCount; x++)
                            {
                            if (x == 0)
                            {
                                elimina = 1;

                            }
                            else
                            {
                                elimina = 0;
                            }
                            int xRow = gridView4.GetVisibleRowHandle(x);
                            InsertarParametrosC(Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Dias_Trabajo_C_J")), Tipo, Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Sueldo_Bruto_C_J")), Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "ISR_C_J")), Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Sueldo_Neto_C_J")),elimina);
                            }
                        }
                           
                    }
                }
            
        }

        private void gridControl4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView4.GetSelectedRows())
                {
                    DataRow row = this.gridView4.GetDataRow(i);

                    gridView4.DeleteRow(i);
                    modifico = true;
                    Formato = "C";
                    Tipo = "J";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }

           
        }

        private void gridControl3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView3.GetSelectedRows())
                {
                    DataRow row = this.gridView3.GetDataRow(i);
                    
                    gridView3.DeleteRow(i);
                    modifico = true;
                    Formato = "C";
                    Tipo = "C";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView2.GetSelectedRows())
                {
                    DataRow row = this.gridView2.GetDataRow(i);
                    modifico = true;
                    Formato = "B";
                    Tipo = "J";
                    gridView2.DeleteRow(i);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (int i in this.gridView1.GetSelectedRows())
                {
                    DataRow row = this.gridView1.GetDataRow(i);

                    gridView1.DeleteRow(i);
                    modifico = true;
                    Formato = "B";
                    Tipo = "C";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void Frm_Parametros_Nomina_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (modifico == true)
            {
                int elimina;
                DialogResult = XtraMessageBox.Show("¿Cambios no guardados, desea Guardarlos?,Si selecciona que no, los cambios se perderan", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (DialogResult == DialogResult.Yes)
                {
                   
                        if (tabPane1.SelectedPage == tabPageFormatoB)
                        {
                            if (Tipo.Equals("C"))
                            {
                                for (int x = 0; x < gridView1.RowCount; x++)
                                {
                                    int xRow = gridView1.GetVisibleRowHandle(x);

                                    if (x == 0)
                                    {
                                        elimina = 1;

                                    }
                                    else
                                    {
                                        elimina = 0;
                                    }
                                    InsertarParametrosB(Convert.ToDecimal(gridView1.GetRowCellValue(xRow, "Dias_Trabajo")), Tipo, Convert.ToDecimal(gridView1.GetRowCellValue(xRow, "Sueldo_Bruto")), elimina);
                                }
                            }
                            else
                            {
                                for (int x = 0; x < gridView2.RowCount; x++)
                                {
                                    int xRow = gridView2.GetVisibleRowHandle(x);

                                    if (x == 0)
                                    {
                                        elimina = 1;

                                    }
                                    else
                                    {
                                        elimina = 0;
                                    }
                                    InsertarParametrosB(Convert.ToDecimal(gridView2.GetRowCellValue(xRow, "Dias_Trabajo")), Tipo, Convert.ToDecimal(gridView2.GetRowCellValue(xRow, "Sueldo_Bruto")),elimina);
                                }
                            }

                        }
                        else
                        {
                            if (Tipo.Equals("C"))
                            {
                                for (int x = 0; x < gridView3.RowCount; x++)
                                {
                                    int xRow = gridView3.GetVisibleRowHandle(x);

                                    if (x == 0)
                                    {
                                        elimina = 1;

                                    }
                                    else
                                    {
                                        elimina = 0;
                                    }
                                    InsertarParametrosC(Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Dias_Trabajo")), Tipo, Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Sueldo_Bruto")), Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "ISR")), Convert.ToDecimal(gridView3.GetRowCellValue(xRow, "Sueldo_Neto")),elimina);
                                }
                            }
                            else
                            {
                                for (int x = 0; x < gridView4.RowCount; x++)
                                {
                                    int xRow = gridView4.GetVisibleRowHandle(x);

                                    if (x == 0)
                                    {
                                        elimina = 1;

                                    }
                                    else
                                    {
                                        elimina = 0;
                                    }
                                    InsertarParametrosC(Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Dias_Trabajo")), Tipo, Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Sueldo_Bruto")), Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "ISR")), Convert.ToDecimal(gridView4.GetRowCellValue(xRow, "Sueldo_Neto")),elimina);
                                }
                            }

                           
                        }
                    


                }
            }
        }

        private void Frm_Parametros_Nomina_Load(object sender, EventArgs e)
        {
            CargarParamtrosB("C");
            CargarParamtrosB("J");
            CargarParamtrosC("C");
            CargarParamtrosC("J");

            Formato = "B";
            Tipo = "C";
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Formato = "B";
            Tipo = "C";
            modifico = true;
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Formato = "B";
            Tipo = "J";
            modifico = true;
        }

        private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Formato = "C";
            Tipo = "C";
            modifico = true;
        }

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Formato = "C";
            Tipo = "J";
            modifico = true;
        }

        private void tabPane2_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane2.SelectedPage == tabPageCortadores)
            {
                Tipo = "C";
            }
            else
            {
                Tipo = "J";
            }
        }

        private void gridView1_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Formato = "C";
            Tipo = "C";
            modifico = true;
        }

        private void InsertarParametrosC(decimal Dias_trabajo, string Tipo_Empleado, decimal Sueldo_Bruto,decimal ISR, decimal Sueldo_Neto,int elimina)
        {
            CLS_Parametros_Nomina Clase = new CLS_Parametros_Nomina();
            Clase.Dias_trabajo = Dias_trabajo;
            Clase.Tipo_Empleado = Tipo_Empleado;
            Clase.Sueldo_Bruto = Sueldo_Bruto;
            Clase.ISR = ISR;
            Clase.Sueldo_Neto = Sueldo_Neto;
            Clase.elimina = elimina;
            Clase.MtdInsertarParametrosC();
            if (Clase.Exito)
            {

                modifico = false;
                XtraMessageBox.Show("Se ha Insertado el registro con exito");

            }
            else
            {
                XtraMessageBox.Show(Clase.Mensaje);
            }
        }

    }
}