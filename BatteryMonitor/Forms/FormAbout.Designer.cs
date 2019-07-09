namespace BatteryMonitor.Forms
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.lb_InfoAuthor = new System.Windows.Forms.Label();
            this.lnklb_emailAuthor = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbVersionTxt = new System.Windows.Forms.Label();
            this.LbVersion = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_InfoAuthor
            // 
            this.lb_InfoAuthor.AutoSize = true;
            this.lb_InfoAuthor.Location = new System.Drawing.Point(178, 25);
            this.lb_InfoAuthor.Name = "lb_InfoAuthor";
            this.lb_InfoAuthor.Size = new System.Drawing.Size(175, 17);
            this.lb_InfoAuthor.TabIndex = 0;
            this.lb_InfoAuthor.Text = "Creado por: Daniel Rincón";
            // 
            // lnklb_emailAuthor
            // 
            this.lnklb_emailAuthor.AutoSize = true;
            this.lnklb_emailAuthor.Location = new System.Drawing.Point(178, 45);
            this.lnklb_emailAuthor.Name = "lnklb_emailAuthor";
            this.lnklb_emailAuthor.Size = new System.Drawing.Size(232, 17);
            this.lnklb_emailAuthor.TabIndex = 1;
            this.lnklb_emailAuthor.TabStop = true;
            this.lnklb_emailAuthor.Text = "danielrinconr@usantotomas.edu.co";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 51);
            this.label1.TabIndex = 6;
            this.label1.Text = "Esta es una aplicación que monitorea el estado de la batería y notifica cuando no" +
    " esté en los niveles óptimos de funcionamiento.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // LbVersionTxt
            // 
            this.LbVersionTxt.AutoSize = true;
            this.LbVersionTxt.Location = new System.Drawing.Point(181, 113);
            this.LbVersionTxt.Name = "LbVersionTxt";
            this.LbVersionTxt.Size = new System.Drawing.Size(60, 17);
            this.LbVersionTxt.TabIndex = 4;
            this.LbVersionTxt.Text = "Versión:";
            // 
            // LbVersion
            // 
            this.LbVersion.AutoSize = true;
            this.LbVersion.Location = new System.Drawing.Point(243, 113);
            this.LbVersion.Name = "LbVersion";
            this.LbVersion.Size = new System.Drawing.Size(29, 17);
            this.LbVersion.TabIndex = 5;
            this.LbVersion.Text = "V.1";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(178, 93);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(284, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://danielrinconr.github.io/BatteryStatus/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Página Web";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 210);
            this.Controls.Add(this.LbVersion);
            this.Controls.Add(this.LbVersionTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lnklb_emailAuthor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_InfoAuthor);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAbout";
            this.Text = "Acerca de";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_InfoAuthor;
        private System.Windows.Forms.LinkLabel lnklb_emailAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbVersionTxt;
        private System.Windows.Forms.Label LbVersion;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
    }
}