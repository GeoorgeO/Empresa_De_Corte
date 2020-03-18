namespace CuttingBusiness.Control
{
    partial class Frm_AbrirHoja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id_HojaNomina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha_HojaNomina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id_Cuadrilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Empresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pago_Diario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Id_JefeCuadrilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nombre_Empleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Tope_pgo_x_dia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_corte_pgo_x_dia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Kgs_cortados_x_dia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cajas_cortados_x_dia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pago_jefe_cuadrilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Peso_promedio_caja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Precio_caja_1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Precio_caja_2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_cortadores = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_Cajas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total_Importe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pago_x_dia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pago_falso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Festivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(540, 545);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id_HojaNomina,
            this.Fecha_HojaNomina,
            this.Id_Cuadrilla,
            this.Empresa,
            this.Pago_Diario,
            this.Id_JefeCuadrilla,
            this.Nombre_Empleado,
            this.Tope_pgo_x_dia,
            this.Total_corte_pgo_x_dia,
            this.Kgs_cortados_x_dia,
            this.Cajas_cortados_x_dia,
            this.Pago_jefe_cuadrilla,
            this.Peso_promedio_caja,
            this.Precio_caja_1,
            this.Precio_caja_2,
            this.Total_cortadores,
            this.Total_Cajas,
            this.Total_Importe,
            this.Pago_x_dia,
            this.Pago_falso,
            this.Festivo,
            this.Estatus});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Id_HojaNomina
            // 
            this.Id_HojaNomina.Caption = "Id_HojaNomina";
            this.Id_HojaNomina.FieldName = "Id_HojaNomina";
            this.Id_HojaNomina.Name = "Id_HojaNomina";
            this.Id_HojaNomina.Visible = true;
            this.Id_HojaNomina.VisibleIndex = 0;
            // 
            // Fecha_HojaNomina
            // 
            this.Fecha_HojaNomina.Caption = "Fecha_HojaNomina";
            this.Fecha_HojaNomina.FieldName = "Fecha_HojaNomina";
            this.Fecha_HojaNomina.Name = "Fecha_HojaNomina";
            this.Fecha_HojaNomina.Visible = true;
            this.Fecha_HojaNomina.VisibleIndex = 1;
            // 
            // Id_Cuadrilla
            // 
            this.Id_Cuadrilla.Caption = "Id_Cuadrilla";
            this.Id_Cuadrilla.FieldName = "Id_Cuadrilla";
            this.Id_Cuadrilla.Name = "Id_Cuadrilla";
            this.Id_Cuadrilla.Visible = true;
            this.Id_Cuadrilla.VisibleIndex = 2;
            // 
            // Empresa
            // 
            this.Empresa.Caption = "Empresa";
            this.Empresa.FieldName = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.Visible = true;
            this.Empresa.VisibleIndex = 3;
            // 
            // Pago_Diario
            // 
            this.Pago_Diario.Caption = "Pago_Diario";
            this.Pago_Diario.FieldName = "Pago_Diario";
            this.Pago_Diario.Name = "Pago_Diario";
            this.Pago_Diario.Visible = true;
            this.Pago_Diario.VisibleIndex = 4;
            // 
            // Id_JefeCuadrilla
            // 
            this.Id_JefeCuadrilla.Caption = "Id_JefeCuadrilla";
            this.Id_JefeCuadrilla.FieldName = "Id_JefeCuadrilla";
            this.Id_JefeCuadrilla.Name = "Id_JefeCuadrilla";
            this.Id_JefeCuadrilla.Visible = true;
            this.Id_JefeCuadrilla.VisibleIndex = 5;
            // 
            // Nombre_Empleado
            // 
            this.Nombre_Empleado.Caption = "Nombre_Empleado";
            this.Nombre_Empleado.FieldName = "Nombre_Empleado";
            this.Nombre_Empleado.Name = "Nombre_Empleado";
            this.Nombre_Empleado.Visible = true;
            this.Nombre_Empleado.VisibleIndex = 6;
            // 
            // Tope_pgo_x_dia
            // 
            this.Tope_pgo_x_dia.Caption = "Tope_pgo_x_dia";
            this.Tope_pgo_x_dia.FieldName = "Tope_pgo_x_dia";
            this.Tope_pgo_x_dia.Name = "Tope_pgo_x_dia";
            this.Tope_pgo_x_dia.Visible = true;
            this.Tope_pgo_x_dia.VisibleIndex = 7;
            // 
            // Total_corte_pgo_x_dia
            // 
            this.Total_corte_pgo_x_dia.Caption = "Total_corte_pgo_x_dia";
            this.Total_corte_pgo_x_dia.FieldName = "Total_corte_pgo_x_dia";
            this.Total_corte_pgo_x_dia.Name = "Total_corte_pgo_x_dia";
            this.Total_corte_pgo_x_dia.Visible = true;
            this.Total_corte_pgo_x_dia.VisibleIndex = 8;
            // 
            // Kgs_cortados_x_dia
            // 
            this.Kgs_cortados_x_dia.Caption = "Kgs_cortados_x_dia";
            this.Kgs_cortados_x_dia.FieldName = "Kgs_cortados_x_dia";
            this.Kgs_cortados_x_dia.Name = "Kgs_cortados_x_dia";
            this.Kgs_cortados_x_dia.Visible = true;
            this.Kgs_cortados_x_dia.VisibleIndex = 9;
            // 
            // Cajas_cortados_x_dia
            // 
            this.Cajas_cortados_x_dia.Caption = "Cajas_cortados_x_dia";
            this.Cajas_cortados_x_dia.FieldName = "Cajas_cortados_x_dia";
            this.Cajas_cortados_x_dia.Name = "Cajas_cortados_x_dia";
            this.Cajas_cortados_x_dia.Visible = true;
            this.Cajas_cortados_x_dia.VisibleIndex = 10;
            // 
            // Pago_jefe_cuadrilla
            // 
            this.Pago_jefe_cuadrilla.Caption = "Pago_jefe_cuadrilla";
            this.Pago_jefe_cuadrilla.FieldName = "Pago_jefe_cuadrilla";
            this.Pago_jefe_cuadrilla.Name = "Pago_jefe_cuadrilla";
            this.Pago_jefe_cuadrilla.Visible = true;
            this.Pago_jefe_cuadrilla.VisibleIndex = 11;
            // 
            // Peso_promedio_caja
            // 
            this.Peso_promedio_caja.Caption = "Peso_promedio_caja";
            this.Peso_promedio_caja.FieldName = "Peso_promedio_caja";
            this.Peso_promedio_caja.Name = "Peso_promedio_caja";
            this.Peso_promedio_caja.Visible = true;
            this.Peso_promedio_caja.VisibleIndex = 12;
            // 
            // Precio_caja_1
            // 
            this.Precio_caja_1.Caption = "Precio_caja_1";
            this.Precio_caja_1.FieldName = "Precio_caja_1";
            this.Precio_caja_1.Name = "Precio_caja_1";
            this.Precio_caja_1.Visible = true;
            this.Precio_caja_1.VisibleIndex = 13;
            // 
            // Precio_caja_2
            // 
            this.Precio_caja_2.Caption = "Precio_caja_2";
            this.Precio_caja_2.FieldName = "Precio_caja_2";
            this.Precio_caja_2.Name = "Precio_caja_2";
            this.Precio_caja_2.Visible = true;
            this.Precio_caja_2.VisibleIndex = 14;
            // 
            // Total_cortadores
            // 
            this.Total_cortadores.Caption = "Total_cortadores";
            this.Total_cortadores.FieldName = "Total_cortadores";
            this.Total_cortadores.Name = "Total_cortadores";
            this.Total_cortadores.Visible = true;
            this.Total_cortadores.VisibleIndex = 15;
            // 
            // Total_Cajas
            // 
            this.Total_Cajas.Caption = "Total_Cajas";
            this.Total_Cajas.FieldName = "Total_Cajas";
            this.Total_Cajas.Name = "Total_Cajas";
            this.Total_Cajas.Visible = true;
            this.Total_Cajas.VisibleIndex = 16;
            // 
            // Total_Importe
            // 
            this.Total_Importe.Caption = "Total_Importe";
            this.Total_Importe.FieldName = "Total_Importe";
            this.Total_Importe.Name = "Total_Importe";
            this.Total_Importe.Visible = true;
            this.Total_Importe.VisibleIndex = 17;
            // 
            // Pago_x_dia
            // 
            this.Pago_x_dia.Caption = "Pago_x_dia";
            this.Pago_x_dia.FieldName = "Pago_x_dia";
            this.Pago_x_dia.Name = "Pago_x_dia";
            this.Pago_x_dia.Visible = true;
            this.Pago_x_dia.VisibleIndex = 18;
            // 
            // Pago_falso
            // 
            this.Pago_falso.Caption = "Pago_falso";
            this.Pago_falso.FieldName = "Pago_falso";
            this.Pago_falso.Name = "Pago_falso";
            this.Pago_falso.Visible = true;
            this.Pago_falso.VisibleIndex = 19;
            // 
            // Festivo
            // 
            this.Festivo.Caption = "Festivo";
            this.Festivo.FieldName = "Festivo";
            this.Festivo.Name = "Festivo";
            this.Festivo.Visible = true;
            this.Festivo.VisibleIndex = 20;
            // 
            // Estatus
            // 
            this.Estatus.Caption = "Estatus";
            this.Estatus.FieldName = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.Visible = true;
            this.Estatus.VisibleIndex = 21;
            // 
            // Frm_AbrirHoja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 545);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm_AbrirHoja";
            this.Text = "Frm_AbrirHoja";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Id_HojaNomina;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha_HojaNomina;
        private DevExpress.XtraGrid.Columns.GridColumn Id_Cuadrilla;
        private DevExpress.XtraGrid.Columns.GridColumn Empresa;
        private DevExpress.XtraGrid.Columns.GridColumn Pago_Diario;
        private DevExpress.XtraGrid.Columns.GridColumn Id_JefeCuadrilla;
        private DevExpress.XtraGrid.Columns.GridColumn Nombre_Empleado;
        private DevExpress.XtraGrid.Columns.GridColumn Tope_pgo_x_dia;
        private DevExpress.XtraGrid.Columns.GridColumn Total_corte_pgo_x_dia;
        private DevExpress.XtraGrid.Columns.GridColumn Kgs_cortados_x_dia;
        private DevExpress.XtraGrid.Columns.GridColumn Cajas_cortados_x_dia;
        private DevExpress.XtraGrid.Columns.GridColumn Pago_jefe_cuadrilla;
        private DevExpress.XtraGrid.Columns.GridColumn Peso_promedio_caja;
        private DevExpress.XtraGrid.Columns.GridColumn Precio_caja_1;
        private DevExpress.XtraGrid.Columns.GridColumn Precio_caja_2;
        private DevExpress.XtraGrid.Columns.GridColumn Total_cortadores;
        private DevExpress.XtraGrid.Columns.GridColumn Total_Cajas;
        private DevExpress.XtraGrid.Columns.GridColumn Total_Importe;
        private DevExpress.XtraGrid.Columns.GridColumn Pago_x_dia;
        private DevExpress.XtraGrid.Columns.GridColumn Pago_falso;
        private DevExpress.XtraGrid.Columns.GridColumn Festivo;
        private DevExpress.XtraGrid.Columns.GridColumn Estatus;
    }
}