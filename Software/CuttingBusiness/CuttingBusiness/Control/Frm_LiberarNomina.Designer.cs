namespace CuttingBusiness
{
    partial class Frm_LiberarNomina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LiberarNomina));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bIconos = new DevExpress.XtraBars.Bar();
            this.btnBuscarNominas = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnLiberar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnLimpiar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnSalir = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bEstado = new DevExpress.XtraBars.Bar();
            this.lblProveedor = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnImportar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnParametros = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtFin = new DevExpress.XtraEditors.DateEdit();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgNominas = new DevExpress.XtraGrid.GridControl();
            this.dtgValNominas = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNominas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValNominas)).BeginInit();
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
            this.btnEliminar,
            this.btnBuscarNominas,
            this.btnLiberar});
            this.barManager1.MainMenu = this.bIconos;
            this.barManager1.MaxItemId = 81;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnBuscarNominas),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLiberar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLimpiar),
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
            // btnBuscarNominas
            // 
            this.btnBuscarNominas.Caption = "  Buscar \r\nNominas";
            this.btnBuscarNominas.Id = 79;
            this.btnBuscarNominas.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarNominas.ImageOptions.Image")));
            this.btnBuscarNominas.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarNominas.ImageOptions.LargeImage")));
            this.btnBuscarNominas.Name = "btnBuscarNominas";
            this.btnBuscarNominas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBuscarNominas_ItemClick);
            // 
            // btnLiberar
            // 
            this.btnLiberar.Caption = " Liberar \r\nNominas";
            this.btnLiberar.Id = 80;
            this.btnLiberar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLiberar.ImageOptions.Image")));
            this.btnLiberar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLiberar.ImageOptions.LargeImage")));
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLiberar_ItemClick);
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
            // btnSalir
            // 
            this.btnSalir.Caption = "Salir";
            this.btnSalir.Id = 63;
            this.btnSalir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.Image")));
            this.btnSalir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.ImageOptions.LargeImage")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSalir_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(894, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 544);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(894, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(55, 544);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(894, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 544);
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
            // btnEliminar
            // 
            this.btnEliminar.Caption = "Eliminar";
            this.btnEliminar.Id = 67;
            this.btnEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.Image")));
            this.btnEliminar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.LargeImage")));
            this.btnEliminar.Name = "btnEliminar";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(55, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl1.Size = new System.Drawing.Size(839, 123);
            this.panelControl1.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dtFin);
            this.groupControl1.Controls.Add(this.dtInicio);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(815, 99);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Opciones de Busqueda";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Fecha Fin:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Fecha Inicio:";
            // 
            // dtFin
            // 
            this.dtFin.EditValue = null;
            this.dtFin.Location = new System.Drawing.Point(84, 58);
            this.dtFin.MenuManager = this.barManager1;
            this.dtFin.Name = "dtFin";
            this.dtFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtFin.Size = new System.Drawing.Size(170, 20);
            this.dtFin.TabIndex = 5;
            // 
            // dtInicio
            // 
            this.dtInicio.EditValue = null;
            this.dtInicio.Location = new System.Drawing.Point(84, 32);
            this.dtInicio.MenuManager = this.barManager1;
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dtInicio.Size = new System.Drawing.Size(170, 20);
            this.dtInicio.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgNominas);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(55, 123);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(839, 421);
            this.panelControl2.TabIndex = 5;
            // 
            // dtgNominas
            // 
            this.dtgNominas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgNominas.Location = new System.Drawing.Point(12, 12);
            this.dtgNominas.MainView = this.dtgValNominas;
            this.dtgNominas.Name = "dtgNominas";
            this.dtgNominas.Size = new System.Drawing.Size(815, 397);
            this.dtgNominas.TabIndex = 10;
            this.dtgNominas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValNominas});
            // 
            // dtgValNominas
            // 
            this.dtgValNominas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.dtgValNominas.GridControl = this.dtgNominas;
            this.dtgValNominas.Name = "dtgValNominas";
            this.dtgValNominas.OptionsBehavior.Editable = false;
            this.dtgValNominas.OptionsFind.AlwaysVisible = true;
            this.dtgValNominas.OptionsView.ShowGroupPanel = false;
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
            this.Nombre_Empleado.Caption = "Jefe Cuadrilla";
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
            // Frm_LiberarNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 571);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_LiberarNomina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liberar Nomina";
            this.Shown += new System.EventHandler(this.Frm_LiberarNomina_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNominas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValNominas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.Bar bIconos;
        private DevExpress.XtraBars.BarLargeButtonItem btnBuscarNominas;
        private DevExpress.XtraBars.BarLargeButtonItem btnLiberar;
        private DevExpress.XtraBars.BarLargeButtonItem btnLimpiar;
        private DevExpress.XtraBars.BarLargeButtonItem btnSalir;
        private DevExpress.XtraBars.Bar bEstado;
        private DevExpress.XtraBars.BarStaticItem lblProveedor;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraBars.BarLargeButtonItem btnImportar;
        private DevExpress.XtraBars.BarLargeButtonItem btnParametros;
        private DevExpress.XtraBars.BarLargeButtonItem btnEliminar;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtFin;
        private DevExpress.XtraEditors.DateEdit dtInicio;
        private DevExpress.XtraGrid.GridControl dtgNominas;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValNominas;
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
        private DevExpress.XtraGrid.Columns.GridColumn Nombre_Categoria;
    }
}