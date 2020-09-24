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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GbBatteryStatus = new System.Windows.Forms.GroupBox();
            this.tabLayPanelBatteryInfo = new System.Windows.Forms.TableLayoutPanel();
            this.ProgBarCharge = new System.Windows.Forms.ProgressBar();
            this.LbNivelCharge = new System.Windows.Forms.Label();
            this.GbVoiceBtns = new System.Windows.Forms.GroupBox();
            this.GbNextNot = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LbTime = new System.Windows.Forms.Label();
            this.ProgBarNextAlert = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ContMenuStrip.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.GbBatteryStatus.SuspendLayout();
            this.tabLayPanelBatteryInfo.SuspendLayout();
            this.GbVoiceBtns.SuspendLayout();
            this.GbNextNot.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbChargeStatus
            // 
            this.LbChargeStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LbChargeStatus.AutoSize = true;
            this.LbChargeStatus.Location = new System.Drawing.Point(3, 6);
            this.LbChargeStatus.Name = "LbChargeStatus";
            this.LbChargeStatus.Size = new System.Drawing.Size(127, 17);
            this.LbChargeStatus.TabIndex = 0;
            this.LbChargeStatus.Text = "Estado de la carga";
            // 
            // TbChargeStatus
            // 
            this.TbChargeStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbChargeStatus.Location = new System.Drawing.Point(179, 4);
            this.TbChargeStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbChargeStatus.Name = "TbChargeStatus";
            this.TbChargeStatus.ReadOnly = true;
            this.TbChargeStatus.Size = new System.Drawing.Size(218, 22);
            this.TbChargeStatus.TabIndex = 1;
            this.TbChargeStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbCharge
            // 
            this.LbCharge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LbCharge.AutoSize = true;
            this.LbCharge.Location = new System.Drawing.Point(3, 45);
            this.LbCharge.Name = "LbCharge";
            this.tabLayPanelBatteryInfo.SetRowSpan(this.LbCharge, 2);
            this.LbCharge.Size = new System.Drawing.Size(111, 17);
            this.LbCharge.TabIndex = 4;
            this.LbCharge.Text = "Nivel de batería:";
            // 
            // TbLifeRemaining
            // 
            this.TbLifeRemaining.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbLifeRemaining.Location = new System.Drawing.Point(179, 81);
            this.TbLifeRemaining.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbLifeRemaining.Name = "TbLifeRemaining";
            this.TbLifeRemaining.ReadOnly = true;
            this.TbLifeRemaining.Size = new System.Drawing.Size(218, 22);
            this.TbLifeRemaining.TabIndex = 7;
            this.TbLifeRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LifeRemaining
            // 
            this.LifeRemaining.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LifeRemaining.AutoSize = true;
            this.LifeRemaining.Location = new System.Drawing.Point(3, 83);
            this.LifeRemaining.Name = "LifeRemaining";
            this.LifeRemaining.Size = new System.Drawing.Size(167, 17);
            this.LifeRemaining.TabIndex = 6;
            this.LifeRemaining.Text = "Tiempo restante (hh:mm)";
            // 
            // TbLineStatus
            // 
            this.TbLineStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbLineStatus.Location = new System.Drawing.Point(179, 114);
            this.TbLineStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbLineStatus.Name = "TbLineStatus";
            this.TbLineStatus.ReadOnly = true;
            this.TbLineStatus.Size = new System.Drawing.Size(218, 22);
            this.TbLineStatus.TabIndex = 9;
            this.TbLineStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LineStatus
            // 
            this.LineStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LineStatus.AutoSize = true;
            this.LineStatus.Location = new System.Drawing.Point(3, 117);
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
            this.BtnSpeak.Location = new System.Drawing.Point(50, 32);
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
            this.BtnPause.Location = new System.Drawing.Point(170, 32);
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
            this.BtnResume.Location = new System.Drawing.Point(290, 32);
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
            this.BtnChecked.Location = new System.Drawing.Point(10, 26);
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
            this.TbIdleTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbIdleTime.Enabled = false;
            this.TbIdleTime.Location = new System.Drawing.Point(269, 6);
            this.TbIdleTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbIdleTime.Name = "TbIdleTime";
            this.TbIdleTime.ReadOnly = true;
            this.TbIdleTime.Size = new System.Drawing.Size(44, 22);
            this.TbIdleTime.TabIndex = 6;
            this.TbIdleTime.Text = "0";
            this.TbIdleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LbIdleTime
            // 
            this.LbIdleTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LbIdleTime.AutoSize = true;
            this.LbIdleTime.Location = new System.Drawing.Point(3, 9);
            this.LbIdleTime.Name = "LbIdleTime";
            this.LbIdleTime.Size = new System.Drawing.Size(256, 17);
            this.LbIdleTime.TabIndex = 5;
            this.LbIdleTime.Text = "Tiempo de inactividad del equipo (min):";
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
            this.GbBatteryStatus.Controls.Add(this.tabLayPanelBatteryInfo);
            this.GbBatteryStatus.Location = new System.Drawing.Point(12, 31);
            this.GbBatteryStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbBatteryStatus.Name = "GbBatteryStatus";
            this.GbBatteryStatus.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbBatteryStatus.Size = new System.Drawing.Size(420, 174);
            this.GbBatteryStatus.TabIndex = 3;
            this.GbBatteryStatus.TabStop = false;
            this.GbBatteryStatus.Text = "Estado de la batería";
            // 
            // tabLayPanelBatteryInfo
            // 
            this.tabLayPanelBatteryInfo.ColumnCount = 2;
            this.tabLayPanelBatteryInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tabLayPanelBatteryInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tabLayPanelBatteryInfo.Controls.Add(this.LineStatus, 0, 4);
            this.tabLayPanelBatteryInfo.Controls.Add(this.LifeRemaining, 0, 3);
            this.tabLayPanelBatteryInfo.Controls.Add(this.TbLineStatus, 1, 4);
            this.tabLayPanelBatteryInfo.Controls.Add(this.ProgBarCharge, 1, 2);
            this.tabLayPanelBatteryInfo.Controls.Add(this.TbLifeRemaining, 1, 3);
            this.tabLayPanelBatteryInfo.Controls.Add(this.TbChargeStatus, 1, 0);
            this.tabLayPanelBatteryInfo.Controls.Add(this.LbNivelCharge, 1, 1);
            this.tabLayPanelBatteryInfo.Controls.Add(this.LbChargeStatus, 0, 0);
            this.tabLayPanelBatteryInfo.Controls.Add(this.LbCharge, 0, 1);
            this.tabLayPanelBatteryInfo.Location = new System.Drawing.Point(10, 20);
            this.tabLayPanelBatteryInfo.Name = "tabLayPanelBatteryInfo";
            this.tabLayPanelBatteryInfo.RowCount = 5;
            this.tabLayPanelBatteryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabLayPanelBatteryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tabLayPanelBatteryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabLayPanelBatteryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabLayPanelBatteryInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabLayPanelBatteryInfo.Size = new System.Drawing.Size(400, 144);
            this.tabLayPanelBatteryInfo.TabIndex = 8;
            // 
            // ProgBarCharge
            // 
            this.ProgBarCharge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProgBarCharge.Location = new System.Drawing.Point(179, 51);
            this.ProgBarCharge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgBarCharge.Name = "ProgBarCharge";
            this.ProgBarCharge.Size = new System.Drawing.Size(218, 22);
            this.ProgBarCharge.TabIndex = 14;
            this.ProgBarCharge.Value = 50;
            // 
            // LbNivelCharge
            // 
            this.LbNivelCharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LbNivelCharge.AutoSize = true;
            this.LbNivelCharge.BackColor = System.Drawing.Color.Transparent;
            this.LbNivelCharge.Location = new System.Drawing.Point(270, 30);
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
            this.GbVoiceBtns.Location = new System.Drawing.Point(12, 352);
            this.GbVoiceBtns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbVoiceBtns.Name = "GbVoiceBtns";
            this.GbVoiceBtns.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbVoiceBtns.Size = new System.Drawing.Size(420, 66);
            this.GbVoiceBtns.TabIndex = 1;
            this.GbVoiceBtns.TabStop = false;
            this.GbVoiceBtns.Text = "Control de voz";
            // 
            // GbNextNot
            // 
            this.GbNextNot.Controls.Add(this.tableLayoutPanel2);
            this.GbNextNot.Controls.Add(this.BtnChecked);
            this.GbNextNot.Enabled = false;
            this.GbNextNot.Location = new System.Drawing.Point(12, 216);
            this.GbNextNot.Margin = new System.Windows.Forms.Padding(4);
            this.GbNextNot.Name = "GbNextNot";
            this.GbNextNot.Padding = new System.Windows.Forms.Padding(4);
            this.GbNextNot.Size = new System.Drawing.Size(420, 125);
            this.GbNextNot.TabIndex = 4;
            this.GbNextNot.TabStop = false;
            this.GbNextNot.Text = "Próxima notificacion";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.LbTime, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ProgBarNextAlert, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(11, 61);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(400, 53);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // LbTime
            // 
            this.LbTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LbTime.AutoSize = true;
            this.LbTime.BackColor = System.Drawing.Color.Transparent;
            this.LbTime.Location = new System.Drawing.Point(178, 4);
            this.LbTime.Name = "LbTime";
            this.LbTime.Size = new System.Drawing.Size(44, 17);
            this.LbTime.TabIndex = 17;
            this.LbTime.Text = "01:00";
            // 
            // ProgBarNextAlert
            // 
            this.ProgBarNextAlert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProgBarNextAlert.Location = new System.Drawing.Point(3, 28);
            this.ProgBarNextAlert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgBarNextAlert.Maximum = 60;
            this.ProgBarNextAlert.Name = "ProgBarNextAlert";
            this.ProgBarNextAlert.Size = new System.Drawing.Size(394, 22);
            this.ProgBarNextAlert.TabIndex = 16;
            this.ProgBarNextAlert.Value = 60;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LbIdleTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TbIdleTime, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 437);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(316, 35);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 496);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.GbNextNot);
            this.Controls.Add(this.GbVoiceBtns);
            this.Controls.Add(this.GbBatteryStatus);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monitor de batería";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.Move += new System.EventHandler(this.FrmMain_Move);
            this.ContMenuStrip.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.GbBatteryStatus.ResumeLayout(false);
            this.tabLayPanelBatteryInfo.ResumeLayout(false);
            this.tabLayPanelBatteryInfo.PerformLayout();
            this.GbVoiceBtns.ResumeLayout(false);
            this.GbNextNot.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbChargeStatus;
        private System.Windows.Forms.TextBox TbChargeStatus;
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
        private System.Windows.Forms.TableLayoutPanel tabLayPanelBatteryInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

