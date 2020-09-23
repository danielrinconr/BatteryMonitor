﻿namespace BatteryMonitor.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.LbChargeStatus = new System.Windows.Forms.Label();
            this.TbChargeStatus = new System.Windows.Forms.TextBox();
            this.TbFullLifetime = new System.Windows.Forms.TextBox();
            this.LbFullLifetime = new System.Windows.Forms.Label();
            this.LbCharge = new System.Windows.Forms.Label();
            this.TbLifeRemaining = new System.Windows.Forms.TextBox();
            this.LifeRemaining = new System.Windows.Forms.Label();
            this.TbLineStatus = new System.Windows.Forms.TextBox();
            this.LineStatus = new System.Windows.Forms.Label();
            this.TmCheckPower = new System.Windows.Forms.Timer(this.components);
            this.BtnSpeak = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnResume = new System.Windows.Forms.Button();
            this.BtnChecked = new System.Windows.Forms.Button();
            this.TmWaitForResp = new System.Windows.Forms.Timer(this.components);
            this.TbIdleTime = new System.Windows.Forms.TextBox();
            this.LbIdleTime = new System.Windows.Forms.Label();
            this.ContMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.informeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ChBAutoRun = new System.Windows.Forms.CheckBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GbBatteryStatus = new System.Windows.Forms.GroupBox();
            this.ProgBarCharge = new System.Windows.Forms.ProgressBar();
            this.LbNivelCharge = new System.Windows.Forms.Label();
            this.GbVoiceBtns = new System.Windows.Forms.GroupBox();
            this.GbNextNot = new System.Windows.Forms.GroupBox();
            this.ProgBarNextAlert = new System.Windows.Forms.ProgressBar();
            this.LbTime = new System.Windows.Forms.Label();
            this.ContMenuStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.GbBatteryStatus.SuspendLayout();
            this.GbVoiceBtns.SuspendLayout();
            this.GbNextNot.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbChargeStatus
            // 
            this.LbChargeStatus.AutoSize = true;
            this.LbChargeStatus.Location = new System.Drawing.Point(5, 28);
            this.LbChargeStatus.Name = "LbChargeStatus";
            this.LbChargeStatus.Size = new System.Drawing.Size(127, 17);
            this.LbChargeStatus.TabIndex = 0;
            this.LbChargeStatus.Text = "Estado de la carga";
            // 
            // TbChargeStatus
            // 
            this.TbChargeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbChargeStatus.Location = new System.Drawing.Point(177, 25);
            this.TbChargeStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbChargeStatus.Name = "TbChargeStatus";
            this.TbChargeStatus.ReadOnly = true;
            this.TbChargeStatus.Size = new System.Drawing.Size(235, 22);
            this.TbChargeStatus.TabIndex = 1;
            this.TbChargeStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TbFullLifetime
            // 
            this.TbFullLifetime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbFullLifetime.Location = new System.Drawing.Point(177, 54);
            this.TbFullLifetime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbFullLifetime.Name = "TbFullLifetime";
            this.TbFullLifetime.ReadOnly = true;
            this.TbFullLifetime.Size = new System.Drawing.Size(235, 22);
            this.TbFullLifetime.TabIndex = 3;
            this.TbFullLifetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbFullLifetime
            // 
            this.LbFullLifetime.Location = new System.Drawing.Point(5, 57);
            this.LbFullLifetime.Name = "LbFullLifetime";
            this.LbFullLifetime.Size = new System.Drawing.Size(148, 44);
            this.LbFullLifetime.TabIndex = 2;
            this.LbFullLifetime.Text = "Tiempo para carga completa (sec)";
            // 
            // LbCharge
            // 
            this.LbCharge.AutoSize = true;
            this.LbCharge.Location = new System.Drawing.Point(5, 107);
            this.LbCharge.Name = "LbCharge";
            this.LbCharge.Size = new System.Drawing.Size(50, 17);
            this.LbCharge.TabIndex = 4;
            this.LbCharge.Text = "Carga:";
            // 
            // TbLifeRemaining
            // 
            this.TbLifeRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbLifeRemaining.Location = new System.Drawing.Point(177, 143);
            this.TbLifeRemaining.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbLifeRemaining.Name = "TbLifeRemaining";
            this.TbLifeRemaining.ReadOnly = true;
            this.TbLifeRemaining.Size = new System.Drawing.Size(235, 22);
            this.TbLifeRemaining.TabIndex = 7;
            this.TbLifeRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LifeRemaining
            // 
            this.LifeRemaining.AutoSize = true;
            this.LifeRemaining.Location = new System.Drawing.Point(5, 146);
            this.LifeRemaining.Name = "LifeRemaining";
            this.LifeRemaining.Size = new System.Drawing.Size(167, 17);
            this.LifeRemaining.TabIndex = 6;
            this.LifeRemaining.Text = "Tiempo restante (hh:mm)";
            // 
            // TbLineStatus
            // 
            this.TbLineStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbLineStatus.Location = new System.Drawing.Point(177, 182);
            this.TbLineStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbLineStatus.Name = "TbLineStatus";
            this.TbLineStatus.ReadOnly = true;
            this.TbLineStatus.Size = new System.Drawing.Size(235, 22);
            this.TbLineStatus.TabIndex = 9;
            this.TbLineStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LineStatus
            // 
            this.LineStatus.AutoSize = true;
            this.LineStatus.Location = new System.Drawing.Point(5, 185);
            this.LineStatus.Name = "LineStatus";
            this.LineStatus.Size = new System.Drawing.Size(147, 17);
            this.LineStatus.TabIndex = 8;
            this.LineStatus.Text = "Estado de la conexión";
            // 
            // TmCheckPower
            // 
            this.TmCheckPower.Interval = 1000;
            this.TmCheckPower.Tick += new System.EventHandler(this.TmCheckPower_Tick);
            // 
            // BtnSpeak
            // 
            this.BtnSpeak.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSpeak.Enabled = false;
            this.BtnSpeak.Location = new System.Drawing.Point(61, 25);
            this.BtnSpeak.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSpeak.Name = "BtnSpeak";
            this.BtnSpeak.Size = new System.Drawing.Size(75, 30);
            this.BtnSpeak.TabIndex = 0;
            this.BtnSpeak.Text = "&Informe";
            this.BtnSpeak.UseVisualStyleBackColor = true;
            this.BtnSpeak.Click += new System.EventHandler(this.BtnSpeak_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnPause.Enabled = false;
            this.BtnPause.Location = new System.Drawing.Point(165, 25);
            this.BtnPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(75, 30);
            this.BtnPause.TabIndex = 1;
            this.BtnPause.Text = "&Pausar";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnResume
            // 
            this.BtnResume.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnResume.Enabled = false;
            this.BtnResume.Location = new System.Drawing.Point(269, 25);
            this.BtnResume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnResume.Name = "BtnResume";
            this.BtnResume.Size = new System.Drawing.Size(80, 30);
            this.BtnResume.TabIndex = 2;
            this.BtnResume.Text = "&Continuar";
            this.BtnResume.UseVisualStyleBackColor = true;
            this.BtnResume.Click += new System.EventHandler(this.BtnResume_Click);
            // 
            // BtnChecked
            // 
            this.BtnChecked.BackColor = System.Drawing.SystemColors.Control;
            this.BtnChecked.Enabled = false;
            this.BtnChecked.Location = new System.Drawing.Point(12, 254);
            this.BtnChecked.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnChecked.Name = "BtnChecked";
            this.BtnChecked.Size = new System.Drawing.Size(85, 30);
            this.BtnChecked.TabIndex = 0;
            this.BtnChecked.Text = "&Entendido";
            this.BtnChecked.UseVisualStyleBackColor = true;
            this.BtnChecked.Click += new System.EventHandler(this.BtnChecked_Click);
            // 
            // TmWaitForResp
            // 
            this.TmWaitForResp.Interval = 1000;
            this.TmWaitForResp.Tick += new System.EventHandler(this.TmWaitForResp_Tick);
            // 
            // TbIdleTime
            // 
            this.TbIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TbIdleTime.Enabled = false;
            this.TbIdleTime.Location = new System.Drawing.Point(277, 441);
            this.TbIdleTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbIdleTime.Name = "TbIdleTime";
            this.TbIdleTime.ReadOnly = true;
            this.TbIdleTime.Size = new System.Drawing.Size(56, 22);
            this.TbIdleTime.TabIndex = 6;
            this.TbIdleTime.Text = "0";
            this.TbIdleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbIdleTime
            // 
            this.LbIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LbIdleTime.AutoSize = true;
            this.LbIdleTime.Location = new System.Drawing.Point(19, 443);
            this.LbIdleTime.Name = "LbIdleTime";
            this.LbIdleTime.Size = new System.Drawing.Size(252, 17);
            this.LbIdleTime.TabIndex = 5;
            this.LbIdleTime.Text = "Tiempo de inactividad del equipo (Min)";
            // 
            // ContMenuStrip
            // 
            this.ContMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informeToolStripMenuItem,
            this.ShowToolStripMenuItem,
            this.CloseToolStripMenuItem});
            this.ContMenuStrip.Name = "contextMenuStrip1";
            this.ContMenuStrip.Size = new System.Drawing.Size(131, 76);
            // 
            // informeToolStripMenuItem
            // 
            this.informeToolStripMenuItem.Name = "informeToolStripMenuItem";
            this.informeToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.informeToolStripMenuItem.Text = "Informe";
            this.informeToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // ShowToolStripMenuItem
            // 
            this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
            this.ShowToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.ShowToolStripMenuItem.Text = "Mostart";
            this.ShowToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.CloseToolStripMenuItem.Text = "Cerrar";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.ContMenuStrip;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "Settings";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon1_OnClick);
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
            // 
            // ChBAutoRun
            // 
            this.ChBAutoRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChBAutoRun.AutoSize = true;
            this.ChBAutoRun.Location = new System.Drawing.Point(12, 466);
            this.ChBAutoRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChBAutoRun.Name = "ChBAutoRun";
            this.ChBAutoRun.Size = new System.Drawing.Size(301, 21);
            this.ChBAutoRun.TabIndex = 2;
            this.ChBAutoRun.Text = "Cargar &automáticamente al iniciar Windows";
            this.ChBAutoRun.UseVisualStyleBackColor = true;
            this.ChBAutoRun.CheckedChanged += new System.EventHandler(this.ChBAutoRun_CheckedChanged);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(442, 28);
            this.MenuStrip.TabIndex = 7;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // OptionsToolStripMenuItem
            // 
            this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem});
            this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
            this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.OptionsToolStripMenuItem.Text = "&Opciones";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.SettingsToolStripMenuItem.Text = "Configuración";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.aboutToolStripMenuItem.Text = "&Acerca de";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // GbBatteryStatus
            // 
            this.GbBatteryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbBatteryStatus.Controls.Add(this.ProgBarCharge);
            this.GbBatteryStatus.Controls.Add(this.LbNivelCharge);
            this.GbBatteryStatus.Controls.Add(this.LbChargeStatus);
            this.GbBatteryStatus.Controls.Add(this.TbChargeStatus);
            this.GbBatteryStatus.Controls.Add(this.LbFullLifetime);
            this.GbBatteryStatus.Controls.Add(this.TbFullLifetime);
            this.GbBatteryStatus.Controls.Add(this.LbCharge);
            this.GbBatteryStatus.Controls.Add(this.LifeRemaining);
            this.GbBatteryStatus.Controls.Add(this.TbLifeRemaining);
            this.GbBatteryStatus.Controls.Add(this.LineStatus);
            this.GbBatteryStatus.Controls.Add(this.TbLineStatus);
            this.GbBatteryStatus.Location = new System.Drawing.Point(12, 31);
            this.GbBatteryStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbBatteryStatus.Name = "GbBatteryStatus";
            this.GbBatteryStatus.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbBatteryStatus.Size = new System.Drawing.Size(418, 217);
            this.GbBatteryStatus.TabIndex = 3;
            this.GbBatteryStatus.TabStop = false;
            this.GbBatteryStatus.Text = "Estado de la batería";
            // 
            // ProgBarCharge
            // 
            this.ProgBarCharge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgBarCharge.Location = new System.Drawing.Point(177, 103);
            this.ProgBarCharge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgBarCharge.Name = "ProgBarCharge";
            this.ProgBarCharge.Size = new System.Drawing.Size(235, 22);
            this.ProgBarCharge.TabIndex = 14;
            this.ProgBarCharge.Value = 50;
            // 
            // LbNivelCharge
            // 
            this.LbNivelCharge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LbNivelCharge.AutoSize = true;
            this.LbNivelCharge.BackColor = System.Drawing.Color.Transparent;
            this.LbNivelCharge.Location = new System.Drawing.Point(285, 84);
            this.LbNivelCharge.Name = "LbNivelCharge";
            this.LbNivelCharge.Size = new System.Drawing.Size(36, 17);
            this.LbNivelCharge.TabIndex = 15;
            this.LbNivelCharge.Text = "50%";
            // 
            // GbVoiceBtns
            // 
            this.GbVoiceBtns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbVoiceBtns.Controls.Add(this.BtnSpeak);
            this.GbVoiceBtns.Controls.Add(this.BtnPause);
            this.GbVoiceBtns.Controls.Add(this.BtnResume);
            this.GbVoiceBtns.Location = new System.Drawing.Point(12, 365);
            this.GbVoiceBtns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbVoiceBtns.Name = "GbVoiceBtns";
            this.GbVoiceBtns.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbVoiceBtns.Size = new System.Drawing.Size(418, 66);
            this.GbVoiceBtns.TabIndex = 1;
            this.GbVoiceBtns.TabStop = false;
            this.GbVoiceBtns.Text = "Control de voz";
            // 
            // GbNextNot
            // 
            this.GbNextNot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbNextNot.Controls.Add(this.ProgBarNextAlert);
            this.GbNextNot.Controls.Add(this.LbTime);
            this.GbNextNot.Enabled = false;
            this.GbNextNot.Location = new System.Drawing.Point(12, 290);
            this.GbNextNot.Margin = new System.Windows.Forms.Padding(4);
            this.GbNextNot.Name = "GbNextNot";
            this.GbNextNot.Padding = new System.Windows.Forms.Padding(4);
            this.GbNextNot.Size = new System.Drawing.Size(425, 69);
            this.GbNextNot.TabIndex = 4;
            this.GbNextNot.TabStop = false;
            this.GbNextNot.Text = "Próxima notificacion";
            // 
            // ProgBarNextAlert
            // 
            this.ProgBarNextAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgBarNextAlert.Location = new System.Drawing.Point(11, 41);
            this.ProgBarNextAlert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgBarNextAlert.Maximum = 60;
            this.ProgBarNextAlert.Name = "ProgBarNextAlert";
            this.ProgBarNextAlert.Size = new System.Drawing.Size(406, 22);
            this.ProgBarNextAlert.TabIndex = 16;
            this.ProgBarNextAlert.Value = 60;
            // 
            // LbTime
            // 
            this.LbTime.AutoSize = true;
            this.LbTime.BackColor = System.Drawing.Color.Transparent;
            this.LbTime.Location = new System.Drawing.Point(196, 19);
            this.LbTime.Name = "LbTime";
            this.LbTime.Size = new System.Drawing.Size(44, 17);
            this.LbTime.TabIndex = 17;
            this.LbTime.Text = "01:00";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 496);
            this.Controls.Add(this.GbNextNot);
            this.Controls.Add(this.GbVoiceBtns);
            this.Controls.Add(this.GbBatteryStatus);
            this.Controls.Add(this.BtnChecked);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.ChBAutoRun);
            this.Controls.Add(this.TbIdleTime);
            this.Controls.Add(this.LbIdleTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de nivel de batería";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.Move += new System.EventHandler(this.FrmMain_Move);
            this.ContMenuStrip.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.GbBatteryStatus.ResumeLayout(false);
            this.GbBatteryStatus.PerformLayout();
            this.GbVoiceBtns.ResumeLayout(false);
            this.GbNextNot.ResumeLayout(false);
            this.GbNextNot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbChargeStatus;
        private System.Windows.Forms.TextBox TbChargeStatus;
        private System.Windows.Forms.TextBox TbFullLifetime;
        private System.Windows.Forms.Label LbFullLifetime;
        private System.Windows.Forms.Label LbCharge;
        private System.Windows.Forms.TextBox TbLifeRemaining;
        private System.Windows.Forms.Label LifeRemaining;
        private System.Windows.Forms.TextBox TbLineStatus;
        private System.Windows.Forms.Label LineStatus;
        private System.Windows.Forms.Timer TmCheckPower;
        private System.Windows.Forms.Button BtnSpeak;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnResume;
        private System.Windows.Forms.Button BtnChecked;
        private System.Windows.Forms.Timer TmWaitForResp;
        private System.Windows.Forms.TextBox TbIdleTime;
        private System.Windows.Forms.Label LbIdleTime;
        private System.Windows.Forms.ContextMenuStrip ContMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.CheckBox ChBAutoRun;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.GroupBox GbBatteryStatus;
        private System.Windows.Forms.ToolStripMenuItem OptionsToolStripMenuItem;
        private System.Windows.Forms.GroupBox GbVoiceBtns;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeToolStripMenuItem;
        private System.Windows.Forms.ProgressBar ProgBarCharge;
        private System.Windows.Forms.Label LbNivelCharge;
        private System.Windows.Forms.GroupBox GbNextNot;
        private System.Windows.Forms.ProgressBar ProgBarNextAlert;
        private System.Windows.Forms.Label LbTime;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
    }
}

