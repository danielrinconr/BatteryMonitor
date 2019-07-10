namespace BatteryMonitor.Forms
{
    partial class FormPcName
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
            this.GbPcName = new System.Windows.Forms.GroupBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAcept = new System.Windows.Forms.Button();
            this.TbPcName = new System.Windows.Forms.TextBox();
            this.LbPcName = new System.Windows.Forms.Label();
            this.GbPcName.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbPcName
            // 
            this.GbPcName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbPcName.Controls.Add(this.BtnCancel);
            this.GbPcName.Controls.Add(this.BtnAcept);
            this.GbPcName.Controls.Add(this.TbPcName);
            this.GbPcName.Controls.Add(this.LbPcName);
            this.GbPcName.Location = new System.Drawing.Point(12, 12);
            this.GbPcName.Name = "GbPcName";
            this.GbPcName.Size = new System.Drawing.Size(254, 90);
            this.GbPcName.TabIndex = 0;
            this.GbPcName.TabStop = false;
            this.GbPcName.Text = "Nombre del usuario";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(170, 54);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "&Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnAcept
            // 
            this.BtnAcept.Enabled = false;
            this.BtnAcept.Location = new System.Drawing.Point(89, 54);
            this.BtnAcept.Name = "BtnAcept";
            this.BtnAcept.Size = new System.Drawing.Size(75, 23);
            this.BtnAcept.TabIndex = 2;
            this.BtnAcept.Text = "&Aceptar";
            this.BtnAcept.UseVisualStyleBackColor = true;
            this.BtnAcept.Click += new System.EventHandler(this.BtnAcept_Click);
            // 
            // TbPcName
            // 
            this.TbPcName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbPcName.Location = new System.Drawing.Point(89, 19);
            this.TbPcName.MaxLength = 24;
            this.TbPcName.Name = "TbPcName";
            this.TbPcName.Size = new System.Drawing.Size(159, 20);
            this.TbPcName.TabIndex = 1;
            this.TbPcName.TextChanged += new System.EventHandler(this.TbPcName_TextChanged);
            // 
            // LbPcName
            // 
            this.LbPcName.AutoSize = true;
            this.LbPcName.Location = new System.Drawing.Point(7, 24);
            this.LbPcName.Name = "LbPcName";
            this.LbPcName.Size = new System.Drawing.Size(76, 13);
            this.LbPcName.TabIndex = 0;
            this.LbPcName.Text = "&Nombre actual";
            // 
            // FormPcName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 108);
            this.Controls.Add(this.GbPcName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPcName";
            this.Text = "Configuración nombre del usuario";
            this.GbPcName.ResumeLayout(false);
            this.GbPcName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbPcName;
        private System.Windows.Forms.Button BtnAcept;
        private System.Windows.Forms.TextBox TbPcName;
        private System.Windows.Forms.Label LbPcName;
        private System.Windows.Forms.Button BtnCancel;
    }
}