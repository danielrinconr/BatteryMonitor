namespace BatteryMonitor.Forms
{
    partial class FormNotSetTime
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GbBattLevel = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NudLowBattLevel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.NudHighBattLevel = new System.Windows.Forms.NumericUpDown();
            this.GbTimeSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NudIdleTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NudTimeNot = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.NudTimeChk = new System.Windows.Forms.NumericUpDown();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.GbBattLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudLowBattLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudHighBattLevel)).BeginInit();
            this.GbTimeSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudIdleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeNot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeChk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.GbBattLevel);
            this.groupBox1.Controls.Add(this.GbTimeSettings);
            this.groupBox1.Controls.Add(this.BtnCancel);
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 340);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración de las notificaciones";
            // 
            // GbBattLevel
            // 
            this.GbBattLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbBattLevel.Controls.Add(this.label5);
            this.GbBattLevel.Controls.Add(this.NudLowBattLevel);
            this.GbBattLevel.Controls.Add(this.label4);
            this.GbBattLevel.Controls.Add(this.NudHighBattLevel);
            this.GbBattLevel.Location = new System.Drawing.Point(7, 22);
            this.GbBattLevel.Name = "GbBattLevel";
            this.GbBattLevel.Size = new System.Drawing.Size(344, 92);
            this.GbBattLevel.TabIndex = 0;
            this.GbBattLevel.TabStop = false;
            this.GbBattLevel.Text = "Configuración niveles de batería";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "&Mínimo nivel de batería (%)";
            // 
            // NudLowBattLevel
            // 
            this.NudLowBattLevel.Location = new System.Drawing.Point(235, 25);
            this.NudLowBattLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudLowBattLevel.Name = "NudLowBattLevel";
            this.NudLowBattLevel.Size = new System.Drawing.Size(73, 22);
            this.NudLowBattLevel.TabIndex = 1;
            this.NudLowBattLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudLowBattLevel.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NudLowBattLevel.Validating += new System.ComponentModel.CancelEventHandler(this.NudBattLevel_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Má&ximo nivel de batería (%)";
            // 
            // NudHighBattLevel
            // 
            this.NudHighBattLevel.Location = new System.Drawing.Point(235, 63);
            this.NudHighBattLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudHighBattLevel.Name = "NudHighBattLevel";
            this.NudHighBattLevel.Size = new System.Drawing.Size(73, 22);
            this.NudHighBattLevel.TabIndex = 3;
            this.NudHighBattLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudHighBattLevel.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.NudHighBattLevel.Validating += new System.ComponentModel.CancelEventHandler(this.NudBattLevel_Validating);
            // 
            // GbTimeSettings
            // 
            this.GbTimeSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbTimeSettings.Controls.Add(this.label1);
            this.GbTimeSettings.Controls.Add(this.NudIdleTime);
            this.GbTimeSettings.Controls.Add(this.label2);
            this.GbTimeSettings.Controls.Add(this.NudTimeNot);
            this.GbTimeSettings.Controls.Add(this.label3);
            this.GbTimeSettings.Controls.Add(this.NudTimeChk);
            this.GbTimeSettings.Location = new System.Drawing.Point(7, 120);
            this.GbTimeSettings.Name = "GbTimeSettings";
            this.GbTimeSettings.Size = new System.Drawing.Size(344, 165);
            this.GbTimeSettings.TabIndex = 1;
            this.GbTimeSettings.TabStop = false;
            this.GbTimeSettings.Text = "Configuración temporizadores";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Tiempo para comprobar el nivel de batería (sec)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NudIdleTime
            // 
            this.NudIdleTime.Location = new System.Drawing.Point(235, 122);
            this.NudIdleTime.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NudIdleTime.Name = "NudIdleTime";
            this.NudIdleTime.Size = new System.Drawing.Size(73, 22);
            this.NudIdleTime.TabIndex = 5;
            this.NudIdleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudIdleTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiempo para &repetir la notificación (min)";
            // 
            // NudTimeNot
            // 
            this.NudTimeNot.Location = new System.Drawing.Point(235, 73);
            this.NudTimeNot.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NudTimeNot.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTimeNot.Name = "NudTimeNot";
            this.NudTimeNot.Size = new System.Drawing.Size(73, 22);
            this.NudTimeNot.TabIndex = 3;
            this.NudTimeNot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudTimeNot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 41);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tiempo de &inactividad del equipo (min)";
            // 
            // NudTimeChk
            // 
            this.NudTimeChk.Location = new System.Drawing.Point(235, 26);
            this.NudTimeChk.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.NudTimeChk.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTimeChk.Name = "NudTimeChk";
            this.NudTimeChk.Size = new System.Drawing.Size(73, 22);
            this.NudTimeChk.TabIndex = 1;
            this.NudTimeChk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudTimeChk.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(108, 291);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(99, 34);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "&Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSave.Location = new System.Drawing.Point(7, 291);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(99, 34);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "&Guardar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmNotSetTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 359);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmNotSetTime";
            this.Text = "Configuración de las notificaciones";
            this.groupBox1.ResumeLayout(false);
            this.GbBattLevel.ResumeLayout(false);
            this.GbBattLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudLowBattLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudHighBattLevel)).EndInit();
            this.GbTimeSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudIdleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeNot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeChk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudTimeNot;
        private System.Windows.Forms.NumericUpDown NudTimeChk;
        private System.Windows.Forms.NumericUpDown NudIdleTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GbTimeSettings;
        private System.Windows.Forms.GroupBox GbBattLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NudLowBattLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudHighBattLevel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}