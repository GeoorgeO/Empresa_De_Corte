namespace CuttingBusiness
{
    partial class Frm_InstanciaSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_InstanciaSQL));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Tabla_Instancias = new DevExpress.XtraGrid.GridControl();
            this.dtgValoresInstancia = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla_Instancias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoresInstancia)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSeleccionar);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 60);
            this.panelControl1.Size = new System.Drawing.Size(542, 284);
            this.panelControl1.TabIndex = 0;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Appearance.Options.UseFont = true;
            this.btnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.Image")));
            this.btnSeleccionar.Location = new System.Drawing.Point(218, 231);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(117, 44);
            this.btnSeleccionar.TabIndex = 16;
            this.btnSeleccionar.Text = "Selecionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.Tabla_Instancias);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(12, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(518, 210);
            this.panelControl2.TabIndex = 0;
            // 
            // Tabla_Instancias
            // 
            this.Tabla_Instancias.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.Tabla_Instancias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabla_Instancias.Location = new System.Drawing.Point(12, 12);
            this.Tabla_Instancias.MainView = this.dtgValoresInstancia;
            this.Tabla_Instancias.Name = "Tabla_Instancias";
            this.Tabla_Instancias.Size = new System.Drawing.Size(494, 186);
            this.Tabla_Instancias.TabIndex = 4;
            this.Tabla_Instancias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValoresInstancia});
            this.Tabla_Instancias.DoubleClick += new System.EventHandler(this.Tabla_Instancias_DoubleClick);
            // 
            // dtgValoresInstancia
            // 
            this.dtgValoresInstancia.GridControl = this.Tabla_Instancias;
            this.dtgValoresInstancia.Name = "dtgValoresInstancia";
            this.dtgValoresInstancia.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dtgValoresInstancia.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dtgValoresInstancia.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.dtgValoresInstancia.OptionsBehavior.Editable = false;
            this.dtgValoresInstancia.OptionsBehavior.ReadOnly = true;
            this.dtgValoresInstancia.OptionsCustomization.AllowColumnMoving = false;
            this.dtgValoresInstancia.OptionsCustomization.AllowColumnResizing = false;
            this.dtgValoresInstancia.OptionsHint.ShowColumnHeaderHints = false;
            this.dtgValoresInstancia.OptionsLayout.Columns.AddNewColumns = false;
            this.dtgValoresInstancia.OptionsLayout.Columns.RemoveOldColumns = false;
            this.dtgValoresInstancia.OptionsSelection.MultiSelect = true;
            this.dtgValoresInstancia.OptionsView.ShowGroupPanel = false;
            // 
            // Frm_InstanciaSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 284);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_InstanciaSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_InstanciaSQL";
            this.Load += new System.EventHandler(this.Frm_InstanciaSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tabla_Instancias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoresInstancia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraGrid.GridControl Tabla_Instancias;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValoresInstancia;
    }
}