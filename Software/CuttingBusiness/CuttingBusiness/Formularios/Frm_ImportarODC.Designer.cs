namespace CuttingBusiness
{
    partial class Frm_ImportarODC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImportarODC));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bIconos = new DevExpress.XtraBars.Bar();
            this.btnLimpiar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnImportar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnParametros = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bEstado = new DevExpress.XtraBars.Bar();
            this.lblProveedor = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnSeleccionar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtClave = new DevExpress.XtraEditors.TextEdit();
            this.txtHoja = new DevExpress.XtraEditors.TextEdit();
            this.pgbProgreso = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtRutaArchivo = new DevExpress.XtraEditors.TextEdit();
            this.btnCargarExcel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgServicios = new DevExpress.XtraGrid.GridControl();
            this.dtgValServicios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ubicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Pesada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Placas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Huertas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Productor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Cajas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Kilos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Variedad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_JefeCuadrilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CajasZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FolioZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_JefeArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spreadsheetBarController1 = new DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController();
            this.OpenDialog = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgbProgreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaArchivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bIconos,
            this.bEstado});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblProveedor,
            this.btnLimpiar,
            this.btnImportar,
            this.btnParametros,
            this.btnSalir,
            this.btnSeleccionar});
            this.barManager1.MainMenu = this.bIconos;
            this.barManager1.MaxItemId = 79;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.barManager1.StatusBar = this.bEstado;
            // 
            // bIconos
            // 
            this.bIconos.BarName = "Menú principal";
            this.bIconos.DockCol = 0;
            this.bIconos.DockRow = 0;
            this.bIconos.DockStyle = DevExpress.XtraBars.BarDockStyle.Left;
            this.bIconos.FloatLocation = new System.Drawing.Point(42, 184);
            this.bIconos.FloatSize = new System.Drawing.Size(1106, 535);
            this.bIconos.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLimpiar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImportar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnParametros),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSalir)});
            this.bIconos.OptionsBar.AllowCollapse = true;
            this.bIconos.OptionsBar.AllowQuickCustomization = false;
            this.bIconos.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.bIconos.OptionsBar.DisableClose = true;
            this.bIconos.OptionsBar.DisableCustomization = true;
            this.bIconos.OptionsBar.DrawBorder = false;
            this.bIconos.OptionsBar.DrawDragBorder = false;
            this.bIconos.OptionsBar.RotateWhenVertical = false;
            this.bIconos.OptionsBar.UseWholeRow = true;
            this.bIconos.Text = "Menú principal";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Caption = "Limpiar";
            this.btnLimpiar.Id = 50;
            this.btnLimpiar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.Image")));
            this.btnLimpiar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.ImageOptions.LargeImage")));
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLimpiar_ItemClick);
            // 
            // btnImportar
            // 
            this.btnImportar.Caption = "Importar";
            this.btnImportar.Id = 53;
            this.btnImportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.ImageOptions.Image")));
            this.btnImportar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.ImageOptions.LargeImage")));
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImportar_ItemClick);
            // 
            // btnParametros
            // 
            this.btnParametros.Caption = "Parametros";
            this.btnParametros.Id = 57;
            this.btnParametros.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnParametros.ImageOptions.Image")));
            this.btnParametros.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnParametros.ImageOptions.LargeImage")));
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnParametros_ItemClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Id = 63;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.LargeImage")));
            this.btnSalir.Name = "btnSalir";
            // 
            // bEstado
            // 
            this.bEstado.BarName = "Barra de estado";
            this.bEstado.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bEstado.DockCol = 0;
            this.bEstado.DockRow = 0;
            this.bEstado.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bEstado.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblProveedor)});
            this.bEstado.OptionsBar.AllowQuickCustomization = false;
            this.bEstado.OptionsBar.DrawDragBorder = false;
            this.bEstado.OptionsBar.UseWholeRow = true;
            this.bEstado.Text = "Barra de estado";
            // 
            // lblProveedor
            // 
            this.lblProveedor.Caption = "Servicios de Corte:";
            this.lblProveedor.Id = 48;
            this.lblProveedor.Name = "lblProveedor";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(982, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 534);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(982, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(72, 534);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(982, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 534);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Caption = "Seleccionar";
            this.btnSeleccionar.Id = 67;
            this.btnSeleccionar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.ImageOptions.Image")));
            this.btnSeleccionar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.ImageOptions.LargeImage")));
            this.btnSeleccionar.Name = "btnSeleccionar";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtClave);
            this.panelControl1.Controls.Add(this.txtHoja);
            this.panelControl1.Controls.Add(this.pgbProgreso);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtRutaArchivo);
            this.panelControl1.Controls.Add(this.btnCargarExcel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(72, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(910, 78);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(583, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Clave:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(584, 18);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Nombre de la hoja:";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(681, 39);
            this.txtClave.MenuManager = this.barManager1;
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(100, 20);
            this.txtClave.TabIndex = 5;
            // 
            // txtHoja
            // 
            this.txtHoja.Location = new System.Drawing.Point(681, 14);
            this.txtHoja.MenuManager = this.barManager1;
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.Size = new System.Drawing.Size(100, 20);
            this.txtHoja.TabIndex = 4;
            // 
            // pgbProgreso
            // 
            this.pgbProgreso.Location = new System.Drawing.Point(111, 40);
            this.pgbProgreso.MenuManager = this.barManager1;
            this.pgbProgreso.Name = "pgbProgreso";
            this.pgbProgreso.Properties.ShowTitle = true;
            this.pgbProgreso.Size = new System.Drawing.Size(463, 18);
            this.pgbProgreso.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "% Importado";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Enabled = false;
            this.txtRutaArchivo.Location = new System.Drawing.Point(111, 14);
            this.txtRutaArchivo.MenuManager = this.barManager1;
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Size = new System.Drawing.Size(463, 20);
            this.txtRutaArchivo.TabIndex = 1;
            // 
            // btnCargarExcel
            // 
            this.btnCargarExcel.Location = new System.Drawing.Point(25, 12);
            this.btnCargarExcel.Name = "btnCargarExcel";
            this.btnCargarExcel.Size = new System.Drawing.Size(75, 23);
            this.btnCargarExcel.TabIndex = 0;
            this.btnCargarExcel.Text = "Examinar";
            this.btnCargarExcel.Click += new System.EventHandler(this.btnCargarExcel_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgServicios);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(72, 78);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(5);
            this.panelControl2.Size = new System.Drawing.Size(910, 456);
            this.panelControl2.TabIndex = 5;
            // 
            // dtgServicios
            // 
            this.dtgServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgServicios.Location = new System.Drawing.Point(7, 7);
            this.dtgServicios.MainView = this.dtgValServicios;
            this.dtgServicios.MenuManager = this.barManager1;
            this.dtgServicios.Name = "dtgServicios";
            this.dtgServicios.Size = new System.Drawing.Size(896, 442);
            this.dtgServicios.TabIndex = 0;
            this.dtgServicios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValServicios});
            // 
            // dtgValServicios
            // 
            this.dtgValServicios.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Fecha,
            this.col_ODC,
            this.col_Ubicacion,
            this.col_Pesada,
            this.col_Placas,
            this.col_Huertas,
            this.col_Productor,
            this.col_Cajas,
            this.col_Kilos,
            this.col_Variedad,
            this.col_JefeCuadrilla,
            this.col_CajasZ,
            this.col_FolioZ,
            this.col_JefeArea});
            this.dtgValServicios.GridControl = this.dtgServicios;
            this.dtgValServicios.Name = "dtgValServicios";
            this.dtgValServicios.OptionsView.ShowFooter = true;
            this.dtgValServicios.OptionsView.ShowGroupPanel = false;
            // 
            // col_Fecha
            // 
            this.col_Fecha.Caption = "Fecha";
            this.col_Fecha.FieldName = "col_Fecha";
            this.col_Fecha.Name = "col_Fecha";
            this.col_Fecha.Visible = true;
            this.col_Fecha.VisibleIndex = 0;
            // 
            // col_ODC
            // 
            this.col_ODC.Caption = "ODC";
            this.col_ODC.FieldName = "col_ODC";
            this.col_ODC.Name = "col_ODC";
            this.col_ODC.Visible = true;
            this.col_ODC.VisibleIndex = 1;
            // 
            // col_Ubicacion
            // 
            this.col_Ubicacion.Caption = "Ubicacion";
            this.col_Ubicacion.FieldName = "col_Ubicacion";
            this.col_Ubicacion.Name = "col_Ubicacion";
            this.col_Ubicacion.Visible = true;
            this.col_Ubicacion.VisibleIndex = 2;
            // 
            // col_Pesada
            // 
            this.col_Pesada.Caption = "Pesada";
            this.col_Pesada.FieldName = "col_Pesada";
            this.col_Pesada.Name = "col_Pesada";
            this.col_Pesada.Visible = true;
            this.col_Pesada.VisibleIndex = 3;
            // 
            // col_Placas
            // 
            this.col_Placas.Caption = "Placas";
            this.col_Placas.FieldName = "col_Placas";
            this.col_Placas.Name = "col_Placas";
            this.col_Placas.Visible = true;
            this.col_Placas.VisibleIndex = 4;
            // 
            // col_Huertas
            // 
            this.col_Huertas.Caption = "Huertas";
            this.col_Huertas.FieldName = "col_Huertas";
            this.col_Huertas.Name = "col_Huertas";
            this.col_Huertas.Visible = true;
            this.col_Huertas.VisibleIndex = 5;
            // 
            // col_Productor
            // 
            this.col_Productor.Caption = "Productor";
            this.col_Productor.FieldName = "col_Productor";
            this.col_Productor.Name = "col_Productor";
            this.col_Productor.Visible = true;
            this.col_Productor.VisibleIndex = 6;
            // 
            // col_Cajas
            // 
            this.col_Cajas.Caption = "Cajas";
            this.col_Cajas.FieldName = "col_Cajas";
            this.col_Cajas.Name = "col_Cajas";
            this.col_Cajas.Visible = true;
            this.col_Cajas.VisibleIndex = 7;
            // 
            // col_Kilos
            // 
            this.col_Kilos.Caption = "Kilos";
            this.col_Kilos.FieldName = "col_Kilos";
            this.col_Kilos.Name = "col_Kilos";
            this.col_Kilos.Visible = true;
            this.col_Kilos.VisibleIndex = 8;
            // 
            // col_Variedad
            // 
            this.col_Variedad.Caption = "Variedad";
            this.col_Variedad.FieldName = "col_Variedad";
            this.col_Variedad.Name = "col_Variedad";
            this.col_Variedad.Visible = true;
            this.col_Variedad.VisibleIndex = 9;
            // 
            // col_JefeCuadrilla
            // 
            this.col_JefeCuadrilla.Caption = "Jefe Cuadrilla";
            this.col_JefeCuadrilla.FieldName = "col_JefeCuadrilla";
            this.col_JefeCuadrilla.Name = "col_JefeCuadrilla";
            this.col_JefeCuadrilla.Visible = true;
            this.col_JefeCuadrilla.VisibleIndex = 10;
            // 
            // col_CajasZ
            // 
            this.col_CajasZ.Caption = "CajasZ";
            this.col_CajasZ.FieldName = "col_CajasZ";
            this.col_CajasZ.Name = "col_CajasZ";
            this.col_CajasZ.Visible = true;
            this.col_CajasZ.VisibleIndex = 11;
            // 
            // col_FolioZ
            // 
            this.col_FolioZ.Caption = "FolioZ";
            this.col_FolioZ.FieldName = "col_FolioZ";
            this.col_FolioZ.Name = "col_FolioZ";
            this.col_FolioZ.Visible = true;
            this.col_FolioZ.VisibleIndex = 12;
            // 
            // col_JefeArea
            // 
            this.col_JefeArea.Caption = "Jefe Area";
            this.col_JefeArea.FieldName = "col_JefeArea";
            this.col_JefeArea.Name = "col_JefeArea";
            this.col_JefeArea.Visible = true;
            this.col_JefeArea.VisibleIndex = 13;
            // 
            // OpenDialog
            // 
            this.OpenDialog.FileName = "xtraOpenFileDialog1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Fecha";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // Frm_ImportarODC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 559);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_ImportarODC";
            this.Text = "Frm_ImportarODC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Frm_ImportarODC_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtClave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgbProgreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaArchivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spreadsheetBarController1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.Bar bIconos;
        private DevExpress.XtraBars.BarLargeButtonItem btnLimpiar;
        private DevExpress.XtraBars.BarLargeButtonItem btnImportar;
        private DevExpress.XtraBars.BarLargeButtonItem btnSalir;
        private DevExpress.XtraBars.Bar bEstado;
        private DevExpress.XtraBars.BarStaticItem lblProveedor;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtClave;
        private DevExpress.XtraEditors.TextEdit txtHoja;
        private DevExpress.XtraEditors.ProgressBarControl pgbProgreso;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtRutaArchivo;
        private DevExpress.XtraEditors.SimpleButton btnCargarExcel;
        private DevExpress.XtraBars.BarLargeButtonItem btnParametros;
        private DevExpress.XtraBars.BarLargeButtonItem btnSeleccionar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraSpreadsheet.UI.SpreadsheetBarController spreadsheetBarController1;
        private DevExpress.XtraEditors.XtraOpenFileDialog OpenDialog;
        private DevExpress.XtraGrid.GridControl dtgServicios;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValServicios;
        private DevExpress.XtraGrid.Columns.GridColumn col_Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODC;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ubicacion;
        private DevExpress.XtraGrid.Columns.GridColumn col_Pesada;
        private DevExpress.XtraGrid.Columns.GridColumn col_Placas;
        private DevExpress.XtraGrid.Columns.GridColumn col_Huertas;
        private DevExpress.XtraGrid.Columns.GridColumn col_Productor;
        private DevExpress.XtraGrid.Columns.GridColumn col_Cajas;
        private DevExpress.XtraGrid.Columns.GridColumn col_Kilos;
        private DevExpress.XtraGrid.Columns.GridColumn col_Variedad;
        private DevExpress.XtraGrid.Columns.GridColumn col_JefeCuadrilla;
        private DevExpress.XtraGrid.Columns.GridColumn col_CajasZ;
        private DevExpress.XtraGrid.Columns.GridColumn col_FolioZ;
        private DevExpress.XtraGrid.Columns.GridColumn col_JefeArea;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}