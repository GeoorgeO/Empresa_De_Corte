namespace CuttingBusiness
{
    partial class Frm_CambiaOrden
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textOrden = new DevExpress.XtraEditors.TextEdit();
            this.textOrdenNew = new DevExpress.XtraEditors.TextEdit();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOrdenNew.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "N° de Orden:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Nueva Orden:";
            // 
            // textOrden
            // 
            this.textOrden.Location = new System.Drawing.Point(82, 9);
            this.textOrden.Name = "textOrden";
            this.textOrden.Properties.ReadOnly = true;
            this.textOrden.Size = new System.Drawing.Size(100, 20);
            this.textOrden.TabIndex = 2;
            // 
            // textOrdenNew
            // 
            this.textOrdenNew.Location = new System.Drawing.Point(82, 37);
            this.textOrdenNew.Name = "textOrdenNew";
            this.textOrdenNew.Size = new System.Drawing.Size(100, 20);
            this.textOrdenNew.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(56, 77);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(77, 21);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Frm_CambiaOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 106);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.textOrdenNew);
            this.Controls.Add(this.textOrden);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Frm_CambiaOrden";
            this.Text = "Frm_CambiaOrden";
            this.Load += new System.EventHandler(this.Frm_CambiaOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textOrdenNew.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textOrden;
        private DevExpress.XtraEditors.TextEdit textOrdenNew;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
    }
}