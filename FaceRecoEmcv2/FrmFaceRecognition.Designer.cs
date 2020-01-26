namespace FaceRecoEmcv2
{
    partial class FrmFaceRecognition
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
            this.TxtEigenEsikDegeri = new System.Windows.Forms.TextBox();
            this.imgKamera = new System.Windows.Forms.PictureBox();
            this.message_bar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTanimaTur = new System.Windows.Forms.Label();
            this.BtnEigenface = new System.Windows.Forms.Button();
            this.BtnLBPH = new System.Windows.Forms.Button();
            this.BtnFisherface = new System.Windows.Forms.Button();
            this.lblKisi = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMesaj = new System.Windows.Forms.Label();
            this.btnYenile = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.imgKamera)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtEigenEsikDegeri
            // 
            this.TxtEigenEsikDegeri.Location = new System.Drawing.Point(76, 21);
            this.TxtEigenEsikDegeri.Name = "TxtEigenEsikDegeri";
            this.TxtEigenEsikDegeri.Size = new System.Drawing.Size(39, 20);
            this.TxtEigenEsikDegeri.TabIndex = 1;
            this.TxtEigenEsikDegeri.Text = "2000";
            this.TxtEigenEsikDegeri.TextChanged += new System.EventHandler(this.Eigne_threshold_txtbx_TextChanged);
            // 
            // imgKamera
            // 
            this.imgKamera.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.imgKamera.Location = new System.Drawing.Point(15, 154);
            this.imgKamera.Name = "imgKamera";
            this.imgKamera.Size = new System.Drawing.Size(995, 470);
            this.imgKamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgKamera.TabIndex = 7;
            this.imgKamera.TabStop = false;
            // 
            // message_bar
            // 
            this.message_bar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.message_bar.AutoSize = true;
            this.message_bar.Location = new System.Drawing.Point(12, 627);
            this.message_bar.Name = "message_bar";
            this.message_bar.Size = new System.Drawing.Size(53, 13);
            this.message_bar.TabIndex = 6;
            this.message_bar.Text = "Message:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtEigenEsikDegeri);
            this.groupBox1.Controls.Add(this.lblTanimaTur);
            this.groupBox1.Controls.Add(this.BtnEigenface);
            this.groupBox1.Controls.Add(this.BtnLBPH);
            this.groupBox1.Controls.Add(this.BtnFisherface);
            this.groupBox1.Location = new System.Drawing.Point(1057, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 122);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algoritmalar";
            // 
            // lblTanimaTur
            // 
            this.lblTanimaTur.AutoSize = true;
            this.lblTanimaTur.Location = new System.Drawing.Point(17, 104);
            this.lblTanimaTur.Name = "lblTanimaTur";
            this.lblTanimaTur.Size = new System.Drawing.Size(35, 13);
            this.lblTanimaTur.TabIndex = 12;
            this.lblTanimaTur.Text = "label2";
            // 
            // BtnEigenface
            // 
            this.BtnEigenface.Location = new System.Drawing.Point(6, 21);
            this.BtnEigenface.Name = "BtnEigenface";
            this.BtnEigenface.Size = new System.Drawing.Size(63, 22);
            this.BtnEigenface.TabIndex = 11;
            this.BtnEigenface.Text = "Eigenface";
            this.BtnEigenface.UseVisualStyleBackColor = true;
            this.BtnEigenface.Click += new System.EventHandler(this.BtnEigenface_Click);
            // 
            // BtnLBPH
            // 
            this.BtnLBPH.Location = new System.Drawing.Point(6, 78);
            this.BtnLBPH.Name = "BtnLBPH";
            this.BtnLBPH.Size = new System.Drawing.Size(63, 23);
            this.BtnLBPH.TabIndex = 11;
            this.BtnLBPH.Text = "LBPH";
            this.BtnLBPH.UseVisualStyleBackColor = true;
            this.BtnLBPH.Click += new System.EventHandler(this.BtnLBPH_Click);
            // 
            // BtnFisherface
            // 
            this.BtnFisherface.Location = new System.Drawing.Point(6, 49);
            this.BtnFisherface.Name = "BtnFisherface";
            this.BtnFisherface.Size = new System.Drawing.Size(63, 23);
            this.BtnFisherface.TabIndex = 11;
            this.BtnFisherface.Text = "Fisherface";
            this.BtnFisherface.UseVisualStyleBackColor = true;
            this.BtnFisherface.Click += new System.EventHandler(this.BtnFisherface_Click);
            // 
            // lblKisi
            // 
            this.lblKisi.AutoSize = true;
            this.lblKisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKisi.ForeColor = System.Drawing.Color.Black;
            this.lblKisi.Location = new System.Drawing.Point(37, 2);
            this.lblKisi.Name = "lblKisi";
            this.lblKisi.Size = new System.Drawing.Size(198, 31);
            this.lblKisi.TabIndex = 11;
            this.lblKisi.Text = ".......................";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Controls.Add(this.lblKisi);
            this.panel2.Location = new System.Drawing.Point(396, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 35);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Controls.Add(this.lblMesaj);
            this.panel3.Location = new System.Drawing.Point(347, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(365, 45);
            this.panel3.TabIndex = 15;
            // 
            // lblMesaj
            // 
            this.lblMesaj.AutoSize = true;
            this.lblMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMesaj.ForeColor = System.Drawing.Color.Black;
            this.lblMesaj.Location = new System.Drawing.Point(83, 4);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(198, 31);
            this.lblMesaj.TabIndex = 11;
            this.lblMesaj.Text = ".......................";
            this.lblMesaj.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(1057, 37);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(75, 23);
            this.btnYenile.TabIndex = 16;
            this.btnYenile.Text = "YENİLE";
            this.btnYenile.UseSelectable = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // FrmFaceRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 649);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imgKamera);
            this.Controls.Add(this.message_bar);
            this.Name = "FrmFaceRecognition";
            this.Load += new System.EventHandler(this.FrmFaceRecognition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgKamera)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtEigenEsikDegeri;
        private System.Windows.Forms.PictureBox imgKamera;
        private System.Windows.Forms.Label message_bar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnEigenface;
        private System.Windows.Forms.Button BtnFisherface;
        private System.Windows.Forms.Button BtnLBPH;
        private System.Windows.Forms.Label lblTanimaTur;
        private System.Windows.Forms.Label lblKisi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMesaj;
        private MetroFramework.Controls.MetroButton btnYenile;
    }
}

