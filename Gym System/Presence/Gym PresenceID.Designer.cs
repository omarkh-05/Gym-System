namespace Gym_System.Presence
{
    partial class frmPresenceID
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.pbFingerPrintImg = new System.Windows.Forms.PictureBox();
            this.lblCheckinClock1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOut = new System.Windows.Forms.Button();
            this.lblCheckoutClock1 = new System.Windows.Forms.Label();
            this.tbCheckoutID = new Gym_System.RequiredTextBox();
            this.tbCheckinID = new Gym_System.RequiredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerPrintImg)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gym fingerprint";
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnEnter.FlatAppearance.BorderSize = 0;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Location = new System.Drawing.Point(210, 742);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(172, 51);
            this.btnEnter.TabIndex = 75;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbFingerPrintImg
            // 
            this.pbFingerPrintImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbFingerPrintImg.Image = global::Gym_System.Properties.Resources.finger_print_icon_234151;
            this.pbFingerPrintImg.Location = new System.Drawing.Point(33, 130);
            this.pbFingerPrintImg.Name = "pbFingerPrintImg";
            this.pbFingerPrintImg.Size = new System.Drawing.Size(516, 516);
            this.pbFingerPrintImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFingerPrintImg.TabIndex = 2;
            this.pbFingerPrintImg.TabStop = false;
            // 
            // lblCheckinClock1
            // 
            this.lblCheckinClock1.AutoSize = true;
            this.lblCheckinClock1.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckinClock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckinClock1.ForeColor = System.Drawing.Color.Black;
            this.lblCheckinClock1.Location = new System.Drawing.Point(237, 79);
            this.lblCheckinClock1.Name = "lblCheckinClock1";
            this.lblCheckinClock1.Size = new System.Drawing.Size(98, 38);
            this.lblCheckinClock1.TabIndex = 76;
            this.lblCheckinClock1.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(887, 936);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(172, 51);
            this.btnClose.TabIndex = 79;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(212, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 38);
            this.label2.TabIndex = 80;
            this.label2.Text = "Check In";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbFingerPrintImg);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbCheckinID);
            this.panel1.Controls.Add(this.btnEnter);
            this.panel1.Controls.Add(this.lblCheckinClock1);
            this.panel1.Location = new System.Drawing.Point(143, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 904);
            this.panel1.TabIndex = 81;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbCheckoutID);
            this.panel2.Controls.Add(this.btnOut);
            this.panel2.Controls.Add(this.lblCheckoutClock1);
            this.panel2.Location = new System.Drawing.Point(1157, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 904);
            this.panel2.TabIndex = 82;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Gym_System.Properties.Resources.finger_print_icon_234151;
            this.pictureBox1.Location = new System.Drawing.Point(33, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(516, 516);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(212, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 38);
            this.label3.TabIndex = 80;
            this.label3.Text = "Check Out";
            // 
            // btnOut
            // 
            this.btnOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOut.FlatAppearance.BorderSize = 0;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOut.ForeColor = System.Drawing.Color.White;
            this.btnOut.Location = new System.Drawing.Point(210, 742);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(172, 51);
            this.btnOut.TabIndex = 75;
            this.btnOut.Text = "Leave";
            this.btnOut.UseVisualStyleBackColor = false;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // lblCheckoutClock1
            // 
            this.lblCheckoutClock1.AutoSize = true;
            this.lblCheckoutClock1.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckoutClock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckoutClock1.ForeColor = System.Drawing.Color.Black;
            this.lblCheckoutClock1.Location = new System.Drawing.Point(237, 79);
            this.lblCheckoutClock1.Name = "lblCheckoutClock1";
            this.lblCheckoutClock1.Size = new System.Drawing.Size(98, 38);
            this.lblCheckoutClock1.TabIndex = 76;
            this.lblCheckoutClock1.Text = "00:00";
            // 
            // tbCheckoutID
            // 
            this.tbCheckoutID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tbCheckoutID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCheckoutID.ErrorMessage = "Required";
            this.tbCheckoutID.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCheckoutID.IsRequired = true;
            this.tbCheckoutID.Location = new System.Drawing.Point(169, 669);
            this.tbCheckoutID.Multiline = true;
            this.tbCheckoutID.Name = "tbCheckoutID";
            this.tbCheckoutID.Size = new System.Drawing.Size(246, 47);
            this.tbCheckoutID.TabIndex = 74;
            this.tbCheckoutID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCheckinID
            // 
            this.tbCheckinID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tbCheckinID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCheckinID.ErrorMessage = "Required";
            this.tbCheckinID.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCheckinID.IsRequired = true;
            this.tbCheckinID.Location = new System.Drawing.Point(169, 669);
            this.tbCheckinID.Multiline = true;
            this.tbCheckinID.Name = "tbCheckinID";
            this.tbCheckinID.Size = new System.Drawing.Size(246, 47);
            this.tbCheckinID.TabIndex = 74;
            this.tbCheckinID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmPresenceID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1800, 1102);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPresenceID";
            this.Text = "PresenceID";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPresenceID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFingerPrintImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbFingerPrintImg;
        private RequiredTextBox tbCheckinID;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblCheckinClock1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private RequiredTextBox tbCheckoutID;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Label lblCheckoutClock1;
    }
}