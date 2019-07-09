namespace BatteryMonitor.Forms
{
    partial class FormVoiceSettings
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
            this.GbVoiceSettings = new System.Windows.Forms.GroupBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.GbNotVol = new System.Windows.Forms.GroupBox();
            this.NudNotVol = new System.Windows.Forms.NumericUpDown();
            this.TbNotVol = new System.Windows.Forms.TrackBar();
            this.GbTestVolume = new System.Windows.Forms.GroupBox();
            this.NudTestVol = new System.Windows.Forms.NumericUpDown();
            this.TbTestVol = new System.Windows.Forms.TrackBar();
            this.BtnRead = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TbTest = new System.Windows.Forms.TextBox();
            this.CbVoices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GbVoiceSettings.SuspendLayout();
            this.GbNotVol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudNotVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbNotVol)).BeginInit();
            this.GbTestVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbTestVol)).BeginInit();
            this.SuspendLayout();
            // 
            // GbVoiceSettings
            // 
            this.GbVoiceSettings.Controls.Add(this.BtnCancel);
            this.GbVoiceSettings.Controls.Add(this.BtnSave);
            this.GbVoiceSettings.Controls.Add(this.GbNotVol);
            this.GbVoiceSettings.Controls.Add(this.GbTestVolume);
            this.GbVoiceSettings.Controls.Add(this.BtnRead);
            this.GbVoiceSettings.Controls.Add(this.label2);
            this.GbVoiceSettings.Controls.Add(this.TbTest);
            this.GbVoiceSettings.Controls.Add(this.CbVoices);
            this.GbVoiceSettings.Controls.Add(this.label1);
            this.GbVoiceSettings.Location = new System.Drawing.Point(12, 12);
            this.GbVoiceSettings.Name = "GbVoiceSettings";
            this.GbVoiceSettings.Size = new System.Drawing.Size(328, 548);
            this.GbVoiceSettings.TabIndex = 0;
            this.GbVoiceSettings.TabStop = false;
            this.GbVoiceSettings.Text = "Voice Settings";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(114, 508);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(99, 34);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "&Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSave.Location = new System.Drawing.Point(13, 508);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(99, 34);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "&Guardar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // GbNotVol
            // 
            this.GbNotVol.Controls.Add(this.NudNotVol);
            this.GbNotVol.Controls.Add(this.TbNotVol);
            this.GbNotVol.Location = new System.Drawing.Point(5, 373);
            this.GbNotVol.Name = "GbNotVol";
            this.GbNotVol.Size = new System.Drawing.Size(315, 121);
            this.GbNotVol.TabIndex = 6;
            this.GbNotVol.TabStop = false;
            this.GbNotVol.Text = "&Volumen de la notificación";
            // 
            // NudNotVol
            // 
            this.NudNotVol.Location = new System.Drawing.Point(6, 30);
            this.NudNotVol.Name = "NudNotVol";
            this.NudNotVol.Size = new System.Drawing.Size(298, 22);
            this.NudNotVol.TabIndex = 0;
            this.NudNotVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TbNotVol
            // 
            this.TbNotVol.Location = new System.Drawing.Point(4, 58);
            this.TbNotVol.Maximum = 100;
            this.TbNotVol.Minimum = 1;
            this.TbNotVol.Name = "TbNotVol";
            this.TbNotVol.Size = new System.Drawing.Size(305, 56);
            this.TbNotVol.TabIndex = 1;
            this.TbNotVol.Value = 100;
            // 
            // GbTestVolume
            // 
            this.GbTestVolume.Controls.Add(this.NudTestVol);
            this.GbTestVolume.Controls.Add(this.TbTestVol);
            this.GbTestVolume.Location = new System.Drawing.Point(6, 246);
            this.GbTestVolume.Name = "GbTestVolume";
            this.GbTestVolume.Size = new System.Drawing.Size(315, 121);
            this.GbTestVolume.TabIndex = 5;
            this.GbTestVolume.TabStop = false;
            this.GbTestVolume.Text = "&Volumen de la prueba";
            // 
            // NudTestVol
            // 
            this.NudTestVol.Location = new System.Drawing.Point(6, 30);
            this.NudTestVol.Name = "NudTestVol";
            this.NudTestVol.Size = new System.Drawing.Size(298, 22);
            this.NudTestVol.TabIndex = 0;
            this.NudTestVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudTestVol.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // TbTestVol
            // 
            this.TbTestVol.Location = new System.Drawing.Point(4, 58);
            this.TbTestVol.Maximum = 100;
            this.TbTestVol.Minimum = 1;
            this.TbTestVol.Name = "TbTestVol";
            this.TbTestVol.Size = new System.Drawing.Size(305, 56);
            this.TbTestVol.TabIndex = 1;
            this.TbTestVol.Value = 100;
            // 
            // BtnRead
            // 
            this.BtnRead.Enabled = false;
            this.BtnRead.Location = new System.Drawing.Point(6, 206);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(83, 34);
            this.BtnRead.TabIndex = 4;
            this.BtnRead.Text = "&Hablar";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese un texto para escuchar la voz seleccionada";
            // 
            // TbTest
            // 
            this.TbTest.Location = new System.Drawing.Point(6, 120);
            this.TbTest.Multiline = true;
            this.TbTest.Name = "TbTest";
            this.TbTest.Size = new System.Drawing.Size(305, 80);
            this.TbTest.TabIndex = 3;
            this.TbTest.Text = "Esta es una prueba";
            this.TbTest.TextChanged += new System.EventHandler(this.TbTest_TextChanged);
            // 
            // CbVoices
            // 
            this.CbVoices.FormattingEnabled = true;
            this.CbVoices.Location = new System.Drawing.Point(6, 50);
            this.CbVoices.Name = "CbVoices";
            this.CbVoices.Size = new System.Drawing.Size(305, 24);
            this.CbVoices.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escoja una voz seleccionada";
            // 
            // FormVoiceSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 562);
            this.Controls.Add(this.GbVoiceSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormVoiceSettings";
            this.Text = "Configuración sintetizador de voz";
            this.Load += new System.EventHandler(this.VoiceSettings_Load);
            this.GbVoiceSettings.ResumeLayout(false);
            this.GbVoiceSettings.PerformLayout();
            this.GbNotVol.ResumeLayout(false);
            this.GbNotVol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudNotVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbNotVol)).EndInit();
            this.GbTestVolume.ResumeLayout(false);
            this.GbTestVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbTestVol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbVoiceSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TbTest;
        private System.Windows.Forms.ComboBox CbVoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.TrackBar TbTestVol;
        private System.Windows.Forms.GroupBox GbTestVolume;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.NumericUpDown NudTestVol;
        private System.Windows.Forms.GroupBox GbNotVol;
        private System.Windows.Forms.NumericUpDown NudNotVol;
        private System.Windows.Forms.TrackBar TbNotVol;
    }
}