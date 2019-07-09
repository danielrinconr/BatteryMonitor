namespace BatteryMonitor.Forms
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.informeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ChBAutoRun = new System.Windows.Forms.CheckBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GbBatteryStatus = new System.Windows.Forms.GroupBox();
            this.PbCharge = new System.Windows.Forms.ProgressBar();
            this.LbNivelCharge = new System.Windows.Forms.Label();
            this.GbVoiceBtns = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.GbBatteryStatus.SuspendLayout();
            this.GbVoiceBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbChargeStatus
            // 
            this.LbChargeStatus.AutoSize = true;
            this.LbChargeStatus.Location = new System.Drawing.Point(6, 28);
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
            this.TbChargeStatus.Name = "TbChargeStatus";
            this.TbChargeStatus.ReadOnly = true;
            this.TbChargeStatus.Size = new System.Drawing.Size(156, 22);
            this.TbChargeStatus.TabIndex = 1;
            this.TbChargeStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TbFullLifetime
            // 
            this.TbFullLifetime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbFullLifetime.Location = new System.Drawing.Point(177, 54);
            this.TbFullLifetime.Name = "TbFullLifetime";
            this.TbFullLifetime.ReadOnly = true;
            this.TbFullLifetime.Size = new System.Drawing.Size(156, 22);
            this.TbFullLifetime.TabIndex = 3;
            this.TbFullLifetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbFullLifetime
            // 
            this.LbFullLifetime.Location = new System.Drawing.Point(6, 57);
            this.LbFullLifetime.Name = "LbFullLifetime";
            this.LbFullLifetime.Size = new System.Drawing.Size(148, 44);
            this.LbFullLifetime.TabIndex = 2;
            this.LbFullLifetime.Text = "Tiempo para carga completa (sec)";
            // 
            // LbCharge
            // 
            this.LbCharge.AutoSize = true;
            this.LbCharge.Location = new System.Drawing.Point(6, 107);
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
            this.TbLifeRemaining.Name = "TbLifeRemaining";
            this.TbLifeRemaining.ReadOnly = true;
            this.TbLifeRemaining.Size = new System.Drawing.Size(156, 22);
            this.TbLifeRemaining.TabIndex = 7;
            this.TbLifeRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LifeRemaining
            // 
            this.LifeRemaining.AutoSize = true;
            this.LifeRemaining.Location = new System.Drawing.Point(6, 146);
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
            this.TbLineStatus.Name = "TbLineStatus";
            this.TbLineStatus.ReadOnly = true;
            this.TbLineStatus.Size = new System.Drawing.Size(156, 22);
            this.TbLineStatus.TabIndex = 9;
            this.TbLineStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LineStatus
            // 
            this.LineStatus.AutoSize = true;
            this.LineStatus.Location = new System.Drawing.Point(6, 185);
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
            this.BtnSpeak.Enabled = false;
            this.BtnSpeak.Location = new System.Drawing.Point(6, 21);
            this.BtnSpeak.Name = "BtnSpeak";
            this.BtnSpeak.Size = new System.Drawing.Size(75, 29);
            this.BtnSpeak.TabIndex = 10;
            this.BtnSpeak.Text = "&Informe";
            this.BtnSpeak.UseVisualStyleBackColor = true;
            this.BtnSpeak.Click += new System.EventHandler(this.BtnSpeak_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Enabled = false;
            this.BtnPause.Location = new System.Drawing.Point(110, 21);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(75, 29);
            this.BtnPause.TabIndex = 11;
            this.BtnPause.Text = "&Pausar";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnResume
            // 
            this.BtnResume.Enabled = false;
            this.BtnResume.Location = new System.Drawing.Point(214, 21);
            this.BtnResume.Name = "BtnResume";
            this.BtnResume.Size = new System.Drawing.Size(80, 29);
            this.BtnResume.TabIndex = 12;
            this.BtnResume.Text = "&Continuar";
            this.BtnResume.UseVisualStyleBackColor = true;
            this.BtnResume.Click += new System.EventHandler(this.BtnResume_Click);
            // 
            // BtnChecked
            // 
            this.BtnChecked.BackColor = System.Drawing.SystemColors.Control;
            this.BtnChecked.Enabled = false;
            this.BtnChecked.Location = new System.Drawing.Point(12, 254);
            this.BtnChecked.Name = "BtnChecked";
            this.BtnChecked.Size = new System.Drawing.Size(86, 29);
            this.BtnChecked.TabIndex = 13;
            this.BtnChecked.Text = "&Entendido";
            this.BtnChecked.UseVisualStyleBackColor = true;
            this.BtnChecked.Click += new System.EventHandler(this.BtnChecked_Click);
            // 
            // TmWaitForResp
            // 
            this.TmWaitForResp.Interval = 60000;
            this.TmWaitForResp.Tick += new System.EventHandler(this.TmWaitForResp_Tick);
            // 
            // TbIdleTime
            // 
            this.TbIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TbIdleTime.Location = new System.Drawing.Point(277, 365);
            this.TbIdleTime.Name = "TbIdleTime";
            this.TbIdleTime.ReadOnly = true;
            this.TbIdleTime.Size = new System.Drawing.Size(56, 22);
            this.TbIdleTime.TabIndex = 3;
            // 
            // LbIdleTime
            // 
            this.LbIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LbIdleTime.AutoSize = true;
            this.LbIdleTime.Location = new System.Drawing.Point(18, 368);
            this.LbIdleTime.Name = "LbIdleTime";
            this.LbIdleTime.Size = new System.Drawing.Size(252, 17);
            this.LbIdleTime.TabIndex = 2;
            this.LbIdleTime.Text = "Tiempo de inactividad del equipo (Min)";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informeToolStripMenuItem,
            this.ShowToolStripMenuItem,
            this.CloseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(131, 76);
            // 
            // informeToolStripMenuItem
            // 
            this.informeToolStripMenuItem.Name = "informeToolStripMenuItem";
            this.informeToolStripMenuItem.Size = new System.Drawing.Size(130, 24);
            this.informeToolStripMenuItem.Text = "Informe";
            this.informeToolStripMenuItem.Click += new System.EventHandler(this.InformeToolStripMenuItem_Click);
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
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Settings";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // ChBAutoRun
            // 
            this.ChBAutoRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChBAutoRun.AutoSize = true;
            this.ChBAutoRun.Location = new System.Drawing.Point(12, 392);
            this.ChBAutoRun.Name = "ChBAutoRun";
            this.ChBAutoRun.Size = new System.Drawing.Size(179, 21);
            this.ChBAutoRun.TabIndex = 4;
            this.ChBAutoRun.Text = "Iniciar &automáticamente";
            this.ChBAutoRun.UseVisualStyleBackColor = true;
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(367, 28);
            this.MenuStrip.TabIndex = 5;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voiceToolStripMenuItem,
            this.notificationsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.settingsToolStripMenuItem.Text = "&Configuración";
            // 
            // voiceToolStripMenuItem
            // 
            this.voiceToolStripMenuItem.Name = "voiceToolStripMenuItem";
            this.voiceToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.voiceToolStripMenuItem.Text = "&Voz";
            this.voiceToolStripMenuItem.Click += new System.EventHandler(this.VoiceToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.notificationsToolStripMenuItem.Text = "&Notificationes";
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.NotificationsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.aboutToolStripMenuItem.Text = "&Acerca de";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // GbBatteryStatus
            // 
            this.GbBatteryStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbBatteryStatus.Controls.Add(this.PbCharge);
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
            this.GbBatteryStatus.Name = "GbBatteryStatus";
            this.GbBatteryStatus.Size = new System.Drawing.Size(348, 217);
            this.GbBatteryStatus.TabIndex = 0;
            this.GbBatteryStatus.TabStop = false;
            this.GbBatteryStatus.Text = "Estado de la batería";
            // 
            // PbCharge
            // 
            this.PbCharge.Location = new System.Drawing.Point(177, 104);
            this.PbCharge.Name = "PbCharge";
            this.PbCharge.Size = new System.Drawing.Size(124, 22);
            this.PbCharge.TabIndex = 14;
            this.PbCharge.Value = 50;
            // 
            // LbNivelCharge
            // 
            this.LbNivelCharge.AutoSize = true;
            this.LbNivelCharge.BackColor = System.Drawing.Color.Transparent;
            this.LbNivelCharge.Location = new System.Drawing.Point(221, 84);
            this.LbNivelCharge.Name = "LbNivelCharge";
            this.LbNivelCharge.Size = new System.Drawing.Size(36, 17);
            this.LbNivelCharge.TabIndex = 15;
            this.LbNivelCharge.Text = "50%";
            // 
            // GbVoiceBtns
            // 
            this.GbVoiceBtns.Controls.Add(this.BtnSpeak);
            this.GbVoiceBtns.Controls.Add(this.BtnPause);
            this.GbVoiceBtns.Controls.Add(this.BtnResume);
            this.GbVoiceBtns.Location = new System.Drawing.Point(12, 289);
            this.GbVoiceBtns.Name = "GbVoiceBtns";
            this.GbVoiceBtns.Size = new System.Drawing.Size(310, 66);
            this.GbVoiceBtns.TabIndex = 1;
            this.GbVoiceBtns.TabStop = false;
            this.GbVoiceBtns.Text = "Control de voz";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 421);
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
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Monitor de nivel de batería";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.Move += new System.EventHandler(this.FrmMain_Move);
            this.contextMenuStrip1.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.GbBatteryStatus.ResumeLayout(false);
            this.GbBatteryStatus.PerformLayout();
            this.GbVoiceBtns.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox ChBAutoRun;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.GroupBox GbBatteryStatus;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.GroupBox GbVoiceBtns;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informeToolStripMenuItem;
        private System.Windows.Forms.ProgressBar PbCharge;
        private System.Windows.Forms.Label LbNivelCharge;
    }
}

