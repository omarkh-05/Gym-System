namespace Gym_System.Controls
{
    partial class EmployeeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEndDuration = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEmpRank = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmpType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbEmpImage = new Gym_System.CircleBackGroundImage();
            this.PersonInfoControl = new Gym_System.Controls.InfoControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(158)))));
            this.label1.Location = new System.Drawing.Point(1555, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Employee Info";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbEmpImage);
            this.panel1.Controls.Add(this.lblEndDuration);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblEmpRank);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblEmpType);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(1143, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 312);
            this.panel1.TabIndex = 3;
            // 
            // lblEndDuration
            // 
            this.lblEndDuration.AutoSize = true;
            this.lblEndDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDuration.Location = new System.Drawing.Point(188, 239);
            this.lblEndDuration.Name = "lblEndDuration";
            this.lblEndDuration.Size = new System.Drawing.Size(20, 22);
            this.lblEndDuration.TabIndex = 90;
            this.lblEndDuration.Text = "..";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 30);
            this.label3.TabIndex = 89;
            this.label3.Text = "End Duration :";
            // 
            // lblEmpRank
            // 
            this.lblEmpRank.AutoSize = true;
            this.lblEmpRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpRank.Location = new System.Drawing.Point(188, 144);
            this.lblEmpRank.Name = "lblEmpRank";
            this.lblEmpRank.Size = new System.Drawing.Size(20, 22);
            this.lblEmpRank.TabIndex = 88;
            this.lblEmpRank.Text = "..";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 30);
            this.label2.TabIndex = 87;
            this.label2.Text = "Employee Rank :";
            // 
            // lblEmpType
            // 
            this.lblEmpType.AutoSize = true;
            this.lblEmpType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpType.Location = new System.Drawing.Point(188, 47);
            this.lblEmpType.Name = "lblEmpType";
            this.lblEmpType.Size = new System.Drawing.Size(20, 22);
            this.lblEmpType.TabIndex = 86;
            this.lblEmpType.Text = "..";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 30);
            this.label5.TabIndex = 85;
            this.label5.Text = "Employee Type :";
            // 
            // pbEmpImage
            // 
            this.pbEmpImage.Image = global::Gym_System.Properties.Resources.image;
            this.pbEmpImage.Location = new System.Drawing.Point(418, 40);
            this.pbEmpImage.Name = "pbEmpImage";
            this.pbEmpImage.Size = new System.Drawing.Size(206, 221);
            this.pbEmpImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEmpImage.TabIndex = 91;
            this.pbEmpImage.TabStop = false;
            // 
            // PersonInfoControl
            // 
            this.PersonInfoControl.Location = new System.Drawing.Point(-60, 3);
            this.PersonInfoControl.Name = "PersonInfoControl";
            this.PersonInfoControl.Size = new System.Drawing.Size(1197, 312);
            this.PersonInfoControl.TabIndex = 0;
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PersonInfoControl);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(1817, 396);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEmpImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InfoControl PersonInfoControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private CircleBackGroundImage pbEmpImage;
        private System.Windows.Forms.Label lblEndDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEmpRank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmpType;
        private System.Windows.Forms.Label label5;
    }
}
