namespace CuttingBusiness
{
    partial class Frm_DataBaseSQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DataBaseSQL));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSeleccionar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.dtgBaseDeDatos = new DevExpress.XtraGrid.GridControl();
            this.dtgValoresBaseDeDatos = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaseDeDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoresBaseDeDatos)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(303, 261);
            this.panelControl1.TabIndex = 1;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Appearance.Options.UseFont = true;
            this.btnSeleccionar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionar.ImageOptions.Image")));
            this.btnSeleccionar.Location = new System.Drawing.Point(100, 205);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(117, 44);
            this.btnSeleccionar.TabIndex = 16;
            this.btnSeleccionar.Text = "Selecionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dtgBaseDeDatos);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(12, 12);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl2.Size = new System.Drawing.Size(279, 187);
            this.panelControl2.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.dtgBaseDeDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgBaseDeDatos.Location = new System.Drawing.Point(12, 12);
            this.dtgBaseDeDatos.MainView = this.dtgValoresBaseDeDatos;
            this.dtgBaseDeDatos.Name = "dtgBaseDeDatos";
            this.dtgBaseDeDatos.Size = new System.Drawing.Size(255, 163);
            this.dtgBaseDeDatos.TabIndex = 0;
            this.dtgBaseDeDatos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dtgValoresBaseDeDatos});
            // 
            // gridView1
            // 
            this.dtgValoresBaseDeDatos.GridControl = this.dtgBaseDeDatos;
            this.dtgValoresBaseDeDatos.Name = "dtgValoresBaseDeDatos";
            // 
            // Frm_DataBaseSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 261);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_DataBaseSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bases de Datos";
            this.Load += new System.EventHandler(this.Frm_DataBaseSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaseDeDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgValoresBaseDeDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionar;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl dtgBaseDeDatos;
        private DevExpress.XtraGrid.Views.Grid.GridView dtgValoresBaseDeDatos;
        //private DevExpress.XtraGrid.GridControl dtgBaseDeDatos;
        //private DevExpress.XtraGrid.Views.Grid.GridView dtgValoresBaseDeDatos;
    }
}