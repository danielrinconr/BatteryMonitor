namespace BatteryMonitor.Forms
{
    partial class FormSettings
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
            this.TbCtrl = new System.Windows.Forms.TabControl();
            this.TpNotification = new System.Windows.Forms.TabPage();
            this.GbNotifyIconSett = new System.Windows.Forms.GroupBox();
            this.ChkBWinNot = new System.Windows.Forms.CheckBox();
            this.GbPcName = new System.Windows.Forms.GroupBox();
            this.TbPcName = new System.Windows.Forms.TextBox();
            this.LbPcName = new System.Windows.Forms.Label();
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
            this.TbVozSett = new System.Windows.Forms.TabPage();
            this.GbNotVol = new System.Windows.Forms.GroupBox();
            this.NudNotVol = new System.Windows.Forms.NumericUpDown();
            this.TbNotVol = new System.Windows.Forms.TrackBar();
            this.GbVoiceSettings = new System.Windows.Forms.GroupBox();
            this.GbTestVolume = new System.Windows.Forms.GroupBox();
            this.NudTestVol = new System.Windows.Forms.NumericUpDown();
            this.TbTestVol = new System.Windows.Forms.TrackBar();
            this.BtnRead = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TbTest = new System.Windows.Forms.TextBox();
            this.CbVoices = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.TbCtrl.SuspendLayout();
            this.TpNotification.SuspendLayout();
            this.GbNotifyIconSett.SuspendLayout();
            this.GbPcName.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GbBattLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudLowBattLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudHighBattLevel)).BeginInit();
            this.GbTimeSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudIdleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeNot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeChk)).BeginInit();
            this.TbVozSett.SuspendLayout();
            this.GbNotVol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudNotVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbNotVol)).BeginInit();
            this.GbVoiceSettings.SuspendLayout();
            this.GbTestVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbTestVol)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TbCtrl
            // 
            this.TbCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbCtrl.Controls.Add(this.TpNotification);
            this.TbCtrl.Controls.Add(this.TbVozSett);
            this.TbCtrl.Location = new System.Drawing.Point(16, 15);
            this.TbCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.TbCtrl.Name = "TbCtrl";
            this.TbCtrl.SelectedIndex = 0;
            this.TbCtrl.Size = new System.Drawing.Size(723, 428);
            this.TbCtrl.TabIndex = 0;
            // 
            // TpNotification
            // 
            this.TpNotification.Controls.Add(this.GbNotifyIconSett);
            this.TpNotification.Controls.Add(this.GbPcName);
            this.TpNotification.Controls.Add(this.groupBox1);
            this.TpNotification.Location = new System.Drawing.Point(4, 25);
            this.TpNotification.Margin = new System.Windows.Forms.Padding(4);
            this.TpNotification.Name = "TpNotification";
            this.TpNotification.Padding = new System.Windows.Forms.Padding(4);
            this.TpNotification.Size = new System.Drawing.Size(715, 399);
            this.TpNotification.TabIndex = 0;
            this.TpNotification.Text = "Notificaciones";
            this.TpNotification.UseVisualStyleBackColor = true;
            // 
            // GbNotifyIconSett
            // 
            this.GbNotifyIconSett.Controls.Add(this.ChkBWinNot);
            this.GbNotifyIconSett.Location = new System.Drawing.Point(359, 128);
            this.GbNotifyIconSett.Margin = new System.Windows.Forms.Padding(4);
            this.GbNotifyIconSett.Name = "GbNotifyIconSett";
            this.GbNotifyIconSett.Padding = new System.Windows.Forms.Padding(4);
            this.GbNotifyIconSett.Size = new System.Drawing.Size(339, 176);
            this.GbNotifyIconSett.TabIndex = 2;
            this.GbNotifyIconSett.TabStop = false;
            this.GbNotifyIconSett.Text = "Notificaciones de Windows";
            // 
            // ChkBWinNot
            // 
            this.ChkBWinNot.AutoSize = true;
            this.ChkBWinNot.Enabled = false;
            this.ChkBWinNot.Location = new System.Drawing.Point(13, 28);
            this.ChkBWinNot.Margin = new System.Windows.Forms.Padding(4);
            this.ChkBWinNot.Name = "ChkBWinNot";
            this.ChkBWinNot.Size = new System.Drawing.Size(230, 21);
            this.ChkBWinNot.TabIndex = 0;
            this.ChkBWinNot.Text = "Usar notificaciones de Windows";
            this.ChkBWinNot.UseVisualStyleBackColor = true;
            // 
            // GbPcName
            // 
            this.GbPcName.Controls.Add(this.TbPcName);
            this.GbPcName.Controls.Add(this.LbPcName);
            this.GbPcName.Location = new System.Drawing.Point(359, 10);
            this.GbPcName.Margin = new System.Windows.Forms.Padding(4);
            this.GbPcName.Name = "GbPcName";
            this.GbPcName.Padding = new System.Windows.Forms.Padding(4);
            this.GbPcName.Size = new System.Drawing.Size(339, 68);
            this.GbPcName.TabIndex = 1;
            this.GbPcName.TabStop = false;
            this.GbPcName.Text = "Nombre del usuario";
            // 
            // TbPcName
            // 
            this.TbPcName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbPcName.Location = new System.Drawing.Point(119, 23);
            this.TbPcName.Margin = new System.Windows.Forms.Padding(4);
            this.TbPcName.MaxLength = 24;
            this.TbPcName.Name = "TbPcName";
            this.TbPcName.Size = new System.Drawing.Size(211, 22);
            this.TbPcName.TabIndex = 1;
            this.TbPcName.Validating += new System.ComponentModel.CancelEventHandler(this.TbPcName_Validating);
            // 
            // LbPcName
            // 
            this.LbPcName.AutoSize = true;
            this.LbPcName.Location = new System.Drawing.Point(9, 30);
            this.LbPcName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbPcName.Name = "LbPcName";
            this.LbPcName.Size = new System.Drawing.Size(100, 17);
            this.LbPcName.TabIndex = 0;
            this.LbPcName.Text = "&Nombre actual";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GbBattLevel);
            this.groupBox1.Controls.Add(this.GbTimeSettings);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(349, 298);
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
            this.GbBattLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbBattLevel.Name = "GbBattLevel";
            this.GbBattLevel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbBattLevel.Size = new System.Drawing.Size(325, 92);
            this.GbBattLevel.TabIndex = 0;
            this.GbBattLevel.TabStop = false;
            this.GbBattLevel.Text = "Configuración niveles de batería";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "&Mínimo nivel de batería (%)";
            // 
            // NudLowBattLevel
            // 
            this.NudLowBattLevel.Location = new System.Drawing.Point(235, 25);
            this.NudLowBattLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.label4.Location = new System.Drawing.Point(5, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Má&ximo nivel de batería (%)";
            // 
            // NudHighBattLevel
            // 
            this.NudHighBattLevel.Location = new System.Drawing.Point(235, 63);
            this.NudHighBattLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.GbTimeSettings.Location = new System.Drawing.Point(7, 121);
            this.GbTimeSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbTimeSettings.Name = "GbTimeSettings";
            this.GbTimeSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbTimeSettings.Size = new System.Drawing.Size(325, 165);
            this.GbTimeSettings.TabIndex = 1;
            this.GbTimeSettings.TabStop = false;
            this.GbTimeSettings.Text = "Configuración temporizadores";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Tiempo para comprobar el nivel de batería (sec)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NudIdleTime
            // 
            this.NudIdleTime.Location = new System.Drawing.Point(235, 122);
            this.NudIdleTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NudIdleTime.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NudIdleTime.Name = "NudIdleTime";
            this.NudIdleTime.Size = new System.Drawing.Size(73, 22);
            this.NudIdleTime.TabIndex = 0;
            this.NudIdleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudIdleTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tiempo para &repetir la notificación (min)";
            // 
            // NudTimeNot
            // 
            this.NudTimeNot.Location = new System.Drawing.Point(235, 73);
            this.NudTimeNot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.NudTimeNot.TabIndex = 4;
            this.NudTimeNot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudTimeNot.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 41);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tiempo de &inactividad del equipo (min)";
            // 
            // NudTimeChk
            // 
            this.NudTimeChk.Location = new System.Drawing.Point(235, 26);
            this.NudTimeChk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // TbVozSett
            // 
            this.TbVozSett.Controls.Add(this.GbNotVol);
            this.TbVozSett.Controls.Add(this.GbVoiceSettings);
            this.TbVozSett.Location = new System.Drawing.Point(4, 25);
            this.TbVozSett.Margin = new System.Windows.Forms.Padding(4);
            this.TbVozSett.Name = "TbVozSett";
            this.TbVozSett.Padding = new System.Windows.Forms.Padding(4);
            this.TbVozSett.Size = new System.Drawing.Size(715, 399);
            this.TbVozSett.TabIndex = 1;
            this.TbVozSett.Text = "Sintetizador de voz";
            this.TbVozSett.UseVisualStyleBackColor = true;
            // 
            // GbNotVol
            // 
            this.GbNotVol.Controls.Add(this.NudNotVol);
            this.GbNotVol.Controls.Add(this.TbNotVol);
            this.GbNotVol.Location = new System.Drawing.Point(359, 6);
            this.GbNotVol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbNotVol.Name = "GbNotVol";
            this.GbNotVol.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbNotVol.Size = new System.Drawing.Size(315, 121);
            this.GbNotVol.TabIndex = 1;
            this.GbNotVol.TabStop = false;
            this.GbNotVol.Text = "&Volumen de la notificación";
            // 
            // NudNotVol
            // 
            this.NudNotVol.Location = new System.Drawing.Point(5, 30);
            this.NudNotVol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NudNotVol.Name = "NudNotVol";
            this.NudNotVol.Size = new System.Drawing.Size(299, 22);
            this.NudNotVol.TabIndex = 0;
            this.NudNotVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TbNotVol
            // 
            this.TbNotVol.Location = new System.Drawing.Point(4, 58);
            this.TbNotVol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TbNotVol.Maximum = 100;
            this.TbNotVol.Minimum = 1;
            this.TbNotVol.Name = "TbNotVol";
            this.TbNotVol.Size = new System.Drawing.Size(305, 56);
            this.TbNotVol.TabIndex = 1;
            this.TbNotVol.Value = 100;
            // 
            // GbVoiceSettings
            // 
            this.GbVoiceSettings.Controls.Add(this.GbTestVolume);
            this.GbVoiceSettings.Controls.Add(this.BtnRead);
            this.GbVoiceSettings.Controls.Add(this.label6);
            this.GbVoiceSettings.Controls.Add(this.TbTest);
            this.GbVoiceSettings.Controls.Add(this.CbVoices);
            this.GbVoiceSettings.Controls.Add(this.label7);
            this.GbVoiceSettings.Location = new System.Drawing.Point(7, 6);
            this.GbVoiceSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbVoiceSettings.Name = "GbVoiceSettings";
            this.GbVoiceSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbVoiceSettings.Size = new System.Drawing.Size(333, 377);
            this.GbVoiceSettings.TabIndex = 0;
            this.GbVoiceSettings.TabStop = false;
            this.GbVoiceSettings.Text = "Voice Settings";
            // 
            // GbTestVolume
            // 
            this.GbTestVolume.Controls.Add(this.NudTestVol);
            this.GbTestVolume.Controls.Add(this.TbTestVol);
            this.GbTestVolume.Location = new System.Drawing.Point(5, 246);
            this.GbTestVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbTestVolume.Name = "GbTestVolume";
            this.GbTestVolume.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GbTestVolume.Size = new System.Drawing.Size(315, 121);
            this.GbTestVolume.TabIndex = 5;
            this.GbTestVolume.TabStop = false;
            this.GbTestVolume.Text = "&Volumen de la prueba";
            // 
            // NudTestVol
            // 
            this.NudTestVol.Location = new System.Drawing.Point(5, 30);
            this.NudTestVol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NudTestVol.Name = "NudTestVol";
            this.NudTestVol.Size = new System.Drawing.Size(299, 22);
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
            this.TbTestVol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.BtnRead.Location = new System.Drawing.Point(5, 206);
            this.BtnRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRead.Name = "BtnRead";
            this.BtnRead.Size = new System.Drawing.Size(83, 34);
            this.BtnRead.TabIndex = 4;
            this.BtnRead.Text = "&Hablar";
            this.BtnRead.UseVisualStyleBackColor = true;
            this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 39);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ingrese un texto para escuchar la voz seleccionada";
            // 
            // TbTest
            // 
            this.TbTest.Location = new System.Drawing.Point(5, 121);
            this.TbTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.CbVoices.Location = new System.Drawing.Point(5, 50);
            this.CbVoices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CbVoices.Name = "CbVoices";
            this.CbVoices.Size = new System.Drawing.Size(305, 24);
            this.CbVoices.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Escoja una voz seleccionada";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.Location = new System.Drawing.Point(108, 6);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(99, 34);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "&Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnSave.Location = new System.Drawing.Point(7, 6);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(99, 34);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "&Guardar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Location = new System.Drawing.Point(291, 446);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 46);
            this.panel1.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TbCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(770, 537);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.TbCtrl.ResumeLayout(false);
            this.TpNotification.ResumeLayout(false);
            this.GbNotifyIconSett.ResumeLayout(false);
            this.GbNotifyIconSett.PerformLayout();
            this.GbPcName.ResumeLayout(false);
            this.GbPcName.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.GbBattLevel.ResumeLayout(false);
            this.GbBattLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudLowBattLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudHighBattLevel)).EndInit();
            this.GbTimeSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudIdleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeNot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTimeChk)).EndInit();
            this.TbVozSett.ResumeLayout(false);
            this.GbNotVol.ResumeLayout(false);
            this.GbNotVol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudNotVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbNotVol)).EndInit();
            this.GbVoiceSettings.ResumeLayout(false);
            this.GbVoiceSettings.PerformLayout();
            this.GbTestVolume.ResumeLayout(false);
            this.GbTestVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbTestVol)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbCtrl;
        private System.Windows.Forms.TabPage TpNotification;
        private System.Windows.Forms.TabPage TbVozSett;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox GbBattLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NudLowBattLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudHighBattLevel;
        private System.Windows.Forms.GroupBox GbTimeSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudIdleTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NudTimeNot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NudTimeChk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox GbVoiceSettings;
        private System.Windows.Forms.GroupBox GbNotVol;
        private System.Windows.Forms.NumericUpDown NudNotVol;
        private System.Windows.Forms.TrackBar TbNotVol;
        private System.Windows.Forms.GroupBox GbTestVolume;
        private System.Windows.Forms.NumericUpDown NudTestVol;
        private System.Windows.Forms.TrackBar TbTestVol;
        private System.Windows.Forms.Button BtnRead;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbTest;
        private System.Windows.Forms.ComboBox CbVoices;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox GbPcName;
        private System.Windows.Forms.TextBox TbPcName;
        private System.Windows.Forms.Label LbPcName;
        private System.Windows.Forms.GroupBox GbNotifyIconSett;
        private System.Windows.Forms.CheckBox ChkBWinNot;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}