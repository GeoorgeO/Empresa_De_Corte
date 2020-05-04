namespace CuttingBusiness
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
            this.PrecioCaja = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.Nombre_Categoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.lueCuadrillas = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.dateAl = new DevExpress.XtraEditors.DateEdit();
            this.dateDel = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCuadrillas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAl.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDel.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDel.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(930, 502);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
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
            this.PrecioCaja,
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
            this.Estatus,
            this.Nombre_Categoria});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Id_HojaNomina
            // 
            this.Id_HojaNomina.Caption = "ODC";
            this.Id_HojaNomina.FieldName = "Id_HojaNomina";
            this.Id_HojaNomina.Name = "Id_HojaNomina";
            this.Id_HojaNomina.Visible = true;
            this.Id_HojaNomina.VisibleIndex = 0;
            this.Id_HojaNomina.Width = 83;
            // 
            // Fecha_HojaNomina
            // 
            this.Fecha_HojaNomina.Caption = "Fecha";
            this.Fecha_HojaNomina.FieldName = "Fecha_HojaNomina";
            this.Fecha_HojaNomina.Name = "Fecha_HojaNomina";
            this.Fecha_HojaNomina.Visible = true;
            this.Fecha_HojaNomina.VisibleIndex = 1;
            this.Fecha_HojaNomina.Width = 54;
            // 
            // Id_Cuadrilla
            // 
            this.Id_Cuadrilla.Caption = "Cuadrilla";
            this.Id_Cuadrilla.FieldName = "Id_Cuadrilla";
            this.Id_Cuadrilla.Name = "Id_Cuadrilla";
            this.Id_Cuadrilla.Visible = true;
            this.Id_Cuadrilla.VisibleIndex = 2;
            this.Id_Cuadrilla.Width = 54;
            // 
            // Empresa
            // 
            this.Empresa.Caption = "Empresa";
            this.Empresa.FieldName = "Empresa";
            this.Empresa.Name = "Empresa";
            // 
            // Pago_Diario
            // 
            this.Pago_Diario.Caption = "Pago_Diario";
            this.Pago_Diario.FieldName = "Pago_Diario";
            this.Pago_Diario.Name = "Pago_Diario";
            this.Pago_Diario.Width = 51;
            // 
            // Id_JefeCuadrilla
            // 
            this.Id_JefeCuadrilla.Caption = "Id_JefeCuadrilla";
            this.Id_JefeCuadrilla.FieldName = "Id_JefeCuadrilla";
            this.Id_JefeCuadrilla.Name = "Id_JefeCuadrilla";
            // 
            // Nombre_Empleado
            // 
            this.Nombre_Empleado.Caption = "Jfe Cuadrilla";
            this.Nombre_Empleado.FieldName = "Nombre_Empleado";
            this.Nombre_Empleado.Name = "Nombre_Empleado";
            this.Nombre_Empleado.Visible = true;
            this.Nombre_Empleado.VisibleIndex = 3;
            // 
            // PrecioCaja
            // 
            this.PrecioCaja.Caption = "Precio Caja";
            this.PrecioCaja.FieldName = "PrecioCaja";
            this.PrecioCaja.Name = "PrecioCaja";
            // 
            // Total_corte_pgo_x_dia
            // 
            this.Total_corte_pgo_x_dia.Caption = "Total_corte_pgo_x_dia";
            this.Total_corte_pgo_x_dia.FieldName = "Total_corte_pgo_x_dia";
            this.Total_corte_pgo_x_dia.Name = "Total_corte_pgo_x_dia";
            // 
            // Kgs_cortados_x_dia
            // 
            this.Kgs_cortados_x_dia.Caption = "Kgs_cortados_x_dia";
            this.Kgs_cortados_x_dia.FieldName = "Kgs_cortados_x_dia";
            this.Kgs_cortados_x_dia.Name = "Kgs_cortados_x_dia";
            // 
            // Cajas_cortados_x_dia
            // 
            this.Cajas_cortados_x_dia.Caption = "Cajas_cortados_x_dia";
            this.Cajas_cortados_x_dia.FieldName = "Cajas_cortados_x_dia";
            this.Cajas_cortados_x_dia.Name = "Cajas_cortados_x_dia";
            // 
            // Pago_jefe_cuadrilla
            // 
            this.Pago_jefe_cuadrilla.Caption = "Pago_jefe_cuadrilla";
            this.Pago_jefe_cuadrilla.FieldName = "Pago_jefe_cuadrilla";
            this.Pago_jefe_cuadrilla.Name = "Pago_jefe_cuadrilla";
            // 
            // Peso_promedio_caja
            // 
            this.Peso_promedio_caja.Caption = "Peso_promedio_caja";
            this.Peso_promedio_caja.FieldName = "Peso_promedio_caja";
            this.Peso_promedio_caja.Name = "Peso_promedio_caja";
            // 
            // Precio_caja_1
            // 
            this.Precio_caja_1.Caption = "Precio_caja_1";
            this.Precio_caja_1.FieldName = "Precio_caja_1";
            this.Precio_caja_1.Name = "Precio_caja_1";
            // 
            // Precio_caja_2
            // 
            this.Precio_caja_2.Caption = "Precio_caja_2";
            this.Precio_caja_2.FieldName = "Precio_caja_2";
            this.Precio_caja_2.Name = "Precio_caja_2";
            // 
            // Total_cortadores
            // 
            this.Total_cortadores.Caption = "Cortadores";
            this.Total_cortadores.FieldName = "Total_cortadores";
            this.Total_cortadores.Name = "Total_cortadores";
            this.Total_cortadores.Visible = true;
            this.Total_cortadores.VisibleIndex = 4;
            this.Total_cortadores.Width = 68;
            // 
            // Total_Cajas
            // 
            this.Total_Cajas.Caption = "Cajas";
            this.Total_Cajas.FieldName = "Total_Cajas";
            this.Total_Cajas.Name = "Total_Cajas";
            this.Total_Cajas.Visible = true;
            this.Total_Cajas.VisibleIndex = 5;
            this.Total_Cajas.Width = 81;
            // 
            // Total_Importe
            // 
            this.Total_Importe.Caption = "Total";
            this.Total_Importe.FieldName = "Total_Importe";
            this.Total_Importe.Name = "Total_Importe";
            this.Total_Importe.Visible = true;
            this.Total_Importe.VisibleIndex = 6;
            this.Total_Importe.Width = 87;
            // 
            // Pago_x_dia
            // 
            this.Pago_x_dia.Caption = "Pago_x_dia";
            this.Pago_x_dia.FieldName = "Pago_x_dia";
            this.Pago_x_dia.Name = "Pago_x_dia";
            // 
            // Pago_falso
            // 
            this.Pago_falso.Caption = "Pago_falso";
            this.Pago_falso.FieldName = "Pago_falso";
            this.Pago_falso.Name = "Pago_falso";
            // 
            // Festivo
            // 
            this.Festivo.Caption = "Festivo";
            this.Festivo.FieldName = "Festivo";
            this.Festivo.Name = "Festivo";
            // 
            // Estatus
            // 
            this.Estatus.Caption = "Estatus";
            this.Estatus.FieldName = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.Visible = true;
            this.Estatus.VisibleIndex = 7;
            // 
            // Nombre_Categoria
            // 
            this.Nombre_Categoria.Caption = "Categoria";
            this.Nombre_Categoria.FieldName = "Nombre_Categoria";
            this.Nombre_Categoria.Name = "Nombre_Categoria";
            this.Nombre_Categoria.Visible = true;
            this.Nombre_Categoria.VisibleIndex = 8;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.radioGroup1);
            this.panelControl1.Controls.Add(this.lueCuadrillas);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(this.dateAl);
            this.panelControl1.Controls.Add(this.dateDel);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(930, 37);
            this.panelControl1.TabIndex = 10;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(494, 5);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("A", "Abiertas"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("C", "Cerradas"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("T", "Todas")});
            this.radioGroup1.Size = new System.Drawing.Size(204, 27);
            this.radioGroup1.TabIndex = 8;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // lueCuadrillas
            // 
            this.lueCuadrillas.Location = new System.Drawing.Point(348, 8);
            this.lueCuadrillas.Name = "lueCuadrillas";
            this.lueCuadrillas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCuadrillas.Properties.DisplayMember = "Nombre_Categoria";
            this.lueCuadrillas.Properties.ValueMember = "Id_Categoria";
            this.lueCuadrillas.Size = new System.Drawing.Size(80, 20);
            this.lueCuadrillas.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(289, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Categoria:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(717, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateAl
            // 
            this.dateAl.EditValue = null;
            this.dateAl.Location = new System.Drawing.Point(169, 9);
            this.dateAl.Name = "dateAl";
            this.dateAl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAl.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAl.Size = new System.Drawing.Size(100, 20);
            this.dateAl.TabIndex = 3;
            // 
            // dateDel
            // 
            this.dateDel.EditValue = null;
            this.dateDel.Location = new System.Drawing.Point(34, 9);
            this.dateDel.Name = "dateDel";
            this.dateDel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDel.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateDel.Size = new System.Drawing.Size(100, 20);
            this.dateDel.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(150, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(13, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Al:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(19, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Del:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 502);
            this.panel1.TabIndex = 11;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(450, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Estatus:";
            // 
            // Frm_AbrirHoja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 539);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_AbrirHoja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abrir Hoja de Nomina";
            this.Load += new System.EventHandler(this.Frm_AbrirHoja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCuadrillas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAl.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDel.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateDel.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn PrecioCaja;
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.DateEdit dateAl;
        private DevExpress.XtraEditors.DateEdit dateDel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Columns.GridColumn Nombre_Categoria;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lueCuadrillas;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}