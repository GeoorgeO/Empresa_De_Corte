namespace CuttingBusiness
{
    partial class Frm_ServiciosODC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ServiciosODC));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bIconos = new DevExpress.XtraBars.Bar();
            this.btnBuscarServicios = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnGenerarApoyo = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bEstado = new DevExpress.XtraBars.Bar();
            this.lblProveedor = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnImportar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnParametros = new DevExpress.XtraBars.BarLargeButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtFin = new DevExpress.XtraEditors.DateEdit();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            this.col_Pesada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgServicios = new DevExpress.XtraGrid.GridControl();
            this.dtgValServicios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ODC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Ubicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.col_ClaveDia = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValServicios)).BeginInit();
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
            this.btnGenerarApoyo,
            this.btnImportar,
            this.btnParametros,
            this.btnSalir,
            this.btnEliminar,
            this.btnBuscarServicios});
            this.barManager1.MainMenu = this.bIconos;
            this.barManager1.MaxItemId = 80;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBuscarServicios),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenerarApoyo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEliminar),
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
            // btnBuscarServicios
            // 
            this.btnBuscarServicios.Caption = "  Buscar \r\nServicios";
            this.btnBuscarServicios.Id = 79;
            this.btnBuscarServicios.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarServicios.ImageOptions.Image")));
            this.btnBuscarServicios.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarServicios.ImageOptions.LargeImage")));
            this.btnBuscarServicios.Name = "btnBuscarServicios";
            this.btnBuscarServicios.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuscarServicios_ItemClick);
            // 
            // btnGenerarApoyo
            // 
            this.btnGenerarApoyo.Caption = "Generar\r\n Apoyo";
            this.btnGenerarApoyo.Id = 50;
            this.btnGenerarApoyo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarApoyo.ImageOptions.Image")));
            this.btnGenerarApoyo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGenerarApoyo.ImageOptions.LargeImage")));
            this.btnGenerarApoyo.Name = "btnGenerarApoyo";
            this.btnGenerarApoyo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenerarApoyo_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 67;
            this.btnEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.Image")));
            this.btnEliminar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.LargeImage")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(922, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 475);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(922, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(59, 475);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(922, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 475);
            // 
            // btnImportar
            // 
            this.btnImportar.Caption = "Importar";
            this.btnImportar.Id = 53;
            this.btnImportar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.ImageOptions.Image")));
            this.btnImportar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnImportar.ImageOptions.LargeImage")));
            this.btnImportar.Name = "btnImportar";
            // 
            // btnParametros
            // 
            this.btnParametros.Caption = "Parametros";
            this.btnParametros.Id = 57;
            this.btnParametros.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnParametros.ImageOptions.Image")));
            this.btnParametros.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnParametros.ImageOptions.LargeImage")));
            this.btnParametros.Name = "btnParametros";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dtFin);
            this.panelControl1.Controls.Add(this.dtInicio);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(59, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(863, 80);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Fecha Fin:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Fecha Inicio:";
            // 
            // dtFin
            // 
            this.dtFin.EditValue = null;
            this.dtFin.Location = new System.Drawing.Point(96, 42);
            this.dtFin.MenuManager = this.barManager1;
            this.dtFin.Name = "dtFin";
            this.dtFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Size = new System.Drawing.Size(170, 20);
            this.dtFin.TabIndex = 1;
            // 
            // dtInicio
            // 
            this.dtInicio.EditValue = null;
            this.dtInicio.Location = new System.Drawing.Point(96, 16);
            this.dtInicio.MenuManager = this.barManager1;
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Size = new System.Drawing.Size(170, 20);
            this.dtInicio.TabIndex = 0;
            // 
            // col_Pesada
            // 
            this.col_Pesada.Caption = "Pesada";
            this.col_Pesada.FieldName = "col_Pesada";
            this.col_Pesada.Name = "col_Pesada";
            this.col_Pesada.Visible = true;
            this.col_Pesada.VisibleIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgServicios);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(59, 80);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(863, 395);
            this.panelControl2.TabIndex = 10;
            // 
            // dtgServicios
            // 
            this.dtgServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgServicios.Location = new System.Drawing.Point(12, 12);
            this.dtgServicios.MainView = this.dtgValServicios;
            this.dtgServicios.MenuManager = this.barManager1;
            this.dtgServicios.Name = "dtgServicios";
            this.dtgServicios.Size = new System.Drawing.Size(839, 371);
            this.dtgServicios.TabIndex = 1;
            this.dtgServicios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValServicios});
            // 
            // dtgValServicios
            // 
            this.dtgValServicios.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Fecha,
            this.col_ODC,
            this.col_Ubicacion,
            this.gridColumn1,
            this.col_Placas,
            this.col_Huertas,
            this.col_Productor,
            this.col_Cajas,
            this.col_Kilos,
            this.col_Variedad,
            this.col_JefeCuadrilla,
            this.col_CajasZ,
            this.col_FolioZ,
            this.col_JefeArea,
            this.col_ClaveDia});
            this.dtgValServicios.GridControl = this.dtgServicios;
            this.dtgValServicios.Name = "dtgValServicios";
            this.dtgValServicios.OptionsFind.AlwaysVisible = true;
            this.dtgValServicios.OptionsView.ShowFooter = true;
            this.dtgValServicios.OptionsView.ShowGroupPanel = false;
            // 
            // col_Fecha
            // 
            this.col_Fecha.Caption = "Fecha";
            this.col_Fecha.FieldName = "PSC_Fecha";
            this.col_Fecha.Name = "col_Fecha";
            this.col_Fecha.OptionsColumn.AllowEdit = false;
            this.col_Fecha.Visible = true;
            this.col_Fecha.VisibleIndex = 0;
            // 
            // col_ODC
            // 
            this.col_ODC.Caption = "ODC";
            this.col_ODC.FieldName = "PSC_ODC";
            this.col_ODC.Name = "col_ODC";
            this.col_ODC.OptionsColumn.AllowEdit = false;
            this.col_ODC.Visible = true;
            this.col_ODC.VisibleIndex = 1;
            // 
            // col_Ubicacion
            // 
            this.col_Ubicacion.Caption = "Ubicacion";
            this.col_Ubicacion.FieldName = "PSC_Ubicacion";
            this.col_Ubicacion.Name = "col_Ubicacion";
            this.col_Ubicacion.OptionsColumn.AllowEdit = false;
            this.col_Ubicacion.Visible = true;
            this.col_Ubicacion.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Pesada";
            this.gridColumn1.FieldName = "PSC_Pesada";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // col_Placas
            // 
            this.col_Placas.Caption = "Placas";
            this.col_Placas.FieldName = "PSC_Placas";
            this.col_Placas.Name = "col_Placas";
            this.col_Placas.OptionsColumn.AllowEdit = false;
            this.col_Placas.Visible = true;
            this.col_Placas.VisibleIndex = 4;
            // 
            // col_Huertas
            // 
            this.col_Huertas.Caption = "Huertas";
            this.col_Huertas.FieldName = "PSC_Huertas";
            this.col_Huertas.Name = "col_Huertas";
            this.col_Huertas.OptionsColumn.AllowEdit = false;
            this.col_Huertas.Visible = true;
            this.col_Huertas.VisibleIndex = 5;
            // 
            // col_Productor
            // 
            this.col_Productor.Caption = "Productor";
            this.col_Productor.FieldName = "PSC_Productor";
            this.col_Productor.Name = "col_Productor";
            this.col_Productor.OptionsColumn.AllowEdit = false;
            this.col_Productor.Visible = true;
            this.col_Productor.VisibleIndex = 6;
            // 
            // col_Cajas
            // 
            this.col_Cajas.Caption = "Cajas";
            this.col_Cajas.FieldName = "PSC_Cajas";
            this.col_Cajas.Name = "col_Cajas";
            this.col_Cajas.OptionsColumn.AllowEdit = false;
            this.col_Cajas.Visible = true;
            this.col_Cajas.VisibleIndex = 7;
            // 
            // col_Kilos
            // 
            this.col_Kilos.Caption = "Kilos";
            this.col_Kilos.FieldName = "PSC_Kilos";
            this.col_Kilos.Name = "col_Kilos";
            this.col_Kilos.OptionsColumn.AllowEdit = false;
            this.col_Kilos.Visible = true;
            this.col_Kilos.VisibleIndex = 8;
            // 
            // col_Variedad
            // 
            this.col_Variedad.Caption = "Variedad";
            this.col_Variedad.FieldName = "PSC_Variedad";
            this.col_Variedad.Name = "col_Variedad";
            this.col_Variedad.OptionsColumn.AllowEdit = false;
            this.col_Variedad.Visible = true;
            this.col_Variedad.VisibleIndex = 9;
            // 
            // col_JefeCuadrilla
            // 
            this.col_JefeCuadrilla.Caption = "Jefe Cuadrilla";
            this.col_JefeCuadrilla.FieldName = "PSC_JefeCuadrilla";
            this.col_JefeCuadrilla.Name = "col_JefeCuadrilla";
            this.col_JefeCuadrilla.OptionsColumn.AllowEdit = false;
            this.col_JefeCuadrilla.Visible = true;
            this.col_JefeCuadrilla.VisibleIndex = 10;
            // 
            // col_CajasZ
            // 
            this.col_CajasZ.Caption = "CajasZ";
            this.col_CajasZ.FieldName = "PSC_CajasZ";
            this.col_CajasZ.Name = "col_CajasZ";
            this.col_CajasZ.OptionsColumn.AllowEdit = false;
            this.col_CajasZ.Visible = true;
            this.col_CajasZ.VisibleIndex = 11;
            // 
            // col_FolioZ
            // 
            this.col_FolioZ.Caption = "FolioZ";
            this.col_FolioZ.FieldName = "PSC_FolioZ";
            this.col_FolioZ.Name = "col_FolioZ";
            this.col_FolioZ.OptionsColumn.AllowEdit = false;
            this.col_FolioZ.Visible = true;
            this.col_FolioZ.VisibleIndex = 12;
            // 
            // col_JefeArea
            // 
            this.col_JefeArea.Caption = "Jefe Area";
            this.col_JefeArea.FieldName = "PSC_JefeArea";
            this.col_JefeArea.Name = "col_JefeArea";
            this.col_JefeArea.OptionsColumn.AllowEdit = false;
            this.col_JefeArea.Visible = true;
            this.col_JefeArea.VisibleIndex = 13;
            // 
            // col_ClaveDia
            // 
            this.col_ClaveDia.Caption = "ClaveDia";
            this.col_ClaveDia.FieldName = "PSC_ClaveDia";
            this.col_ClaveDia.Name = "col_ClaveDia";
            this.col_ClaveDia.Visible = true;
            this.col_ClaveDia.VisibleIndex = 14;
            // 
            // Frm_ServiciosODC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 500);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_ServiciosODC";
            this.Text = "Servicios Orden de Corte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Frm_ServiciosODC_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.Bar bIconos;
        private DevExpress.XtraBars.BarLargeButtonItem btnGenerarApoyo;
        private DevExpress.XtraBars.BarLargeButtonItem btnBuscarServicios;
        private DevExpress.XtraBars.BarLargeButtonItem btnEliminar;
        private DevExpress.XtraBars.BarLargeButtonItem btnImportar;
        private DevExpress.XtraBars.BarLargeButtonItem btnParametros;
        private DevExpress.XtraBars.BarLargeButtonItem btnSalir;
        private DevExpress.XtraBars.Bar bEstado;
        private DevExpress.XtraBars.BarStaticItem lblProveedor;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtFin;
        private DevExpress.XtraEditors.DateEdit dtInicio;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn col_Pesada;
        private DevExpress.XtraGrid.GridControl dtgServicios;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValServicios;
        private DevExpress.XtraGrid.Columns.GridColumn col_Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn col_ODC;
        private DevExpress.XtraGrid.Columns.GridColumn col_Ubicacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
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
        private DevExpress.XtraGrid.Columns.GridColumn col_ClaveDia;
    }
}