namespace Gym_System
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblClock = new System.Windows.Forms.Label();
            this.pnlNavBar = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Button();
            this.Presence = new System.Windows.Forms.Button();
            this.btnLogout1 = new System.Windows.Forms.Button();
            this.btnSubInfo1 = new System.Windows.Forms.Button();
            this.btnEmployee1 = new System.Windows.Forms.Button();
            this.btnSubscriber1 = new System.Windows.Forms.Button();
            this.btnUser1 = new System.Windows.Forms.Button();
            this.lblClock1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnSubs = new System.Windows.Forms.Button();
            this.btnEmp = new System.Windows.Forms.Button();
            this.btnsubInfo = new System.Windows.Forms.Button();
            this.btnPresence = new System.Windows.Forms.Button();
            this.pnlNavBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.Snow;
            this.lblClock.Location = new System.Drawing.Point(30, 24);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(44, 18);
            this.lblClock.TabIndex = 0;
            this.lblClock.Text = "00:00";
            // 
            // pnlNavBar
            // 
            this.pnlNavBar.BackColor = System.Drawing.Color.Black;
            this.pnlNavBar.Controls.Add(this.lblUserName);
            this.pnlNavBar.Controls.Add(this.Add);
            this.pnlNavBar.Controls.Add(this.Presence);
            this.pnlNavBar.Controls.Add(this.btnLogout1);
            this.pnlNavBar.Controls.Add(this.btnSubInfo1);
            this.pnlNavBar.Controls.Add(this.btnEmployee1);
            this.pnlNavBar.Controls.Add(this.btnSubscriber1);
            this.pnlNavBar.Controls.Add(this.btnUser1);
            this.pnlNavBar.Controls.Add(this.lblClock1);
            this.pnlNavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavBar.Location = new System.Drawing.Point(0, 0);
            this.pnlNavBar.Name = "pnlNavBar";
            this.pnlNavBar.Size = new System.Drawing.Size(1338, 65);
            this.pnlNavBar.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(12, 12);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(20, 18);
            this.lblUserName.TabIndex = 9;
            this.lblUserName.Text = "...";
            // 
            // Add
            // 
            this.Add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Add.BackColor = System.Drawing.Color.Transparent;
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add.ForeColor = System.Drawing.Color.White;
            this.Add.Image = global::Gym_System.Properties.Resources.Add;
            this.Add.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Add.Location = new System.Drawing.Point(1030, 6);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(142, 45);
            this.Add.TabIndex = 8;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Presence
            // 
            this.Presence.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Presence.BackColor = System.Drawing.Color.Transparent;
            this.Presence.FlatAppearance.BorderSize = 0;
            this.Presence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Presence.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Presence.ForeColor = System.Drawing.Color.White;
            this.Presence.Image = global::Gym_System.Properties.Resources.Presence;
            this.Presence.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Presence.Location = new System.Drawing.Point(858, 7);
            this.Presence.Name = "Presence";
            this.Presence.Size = new System.Drawing.Size(166, 45);
            this.Presence.TabIndex = 7;
            this.Presence.Text = "    Presence";
            this.Presence.UseVisualStyleBackColor = false;
            this.Presence.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogout1
            // 
            this.btnLogout1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout1.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout1.BackgroundImage = global::Gym_System.Properties.Resources.Logout;
            this.btnLogout1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogout1.FlatAppearance.BorderSize = 0;
            this.btnLogout1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout1.Location = new System.Drawing.Point(1285, 10);
            this.btnLogout1.Name = "btnLogout1";
            this.btnLogout1.Size = new System.Drawing.Size(50, 47);
            this.btnLogout1.TabIndex = 6;
            this.btnLogout1.UseVisualStyleBackColor = false;
            this.btnLogout1.Click += new System.EventHandler(this.btnLogout1_Click);
            // 
            // btnSubInfo1
            // 
            this.btnSubInfo1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubInfo1.BackColor = System.Drawing.Color.Transparent;
            this.btnSubInfo1.FlatAppearance.BorderSize = 0;
            this.btnSubInfo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubInfo1.ForeColor = System.Drawing.Color.White;
            this.btnSubInfo1.Image = global::Gym_System.Properties.Resources.SubInfo;
            this.btnSubInfo1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubInfo1.Location = new System.Drawing.Point(650, 11);
            this.btnSubInfo1.Name = "btnSubInfo1";
            this.btnSubInfo1.Size = new System.Drawing.Size(202, 37);
            this.btnSubInfo1.TabIndex = 4;
            this.btnSubInfo1.Text = "      Subscription Info";
            this.btnSubInfo1.UseVisualStyleBackColor = false;
            this.btnSubInfo1.Click += new System.EventHandler(this.btnSubInfo1_Click);
            // 
            // btnEmployee1
            // 
            this.btnEmployee1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEmployee1.BackColor = System.Drawing.Color.Transparent;
            this.btnEmployee1.FlatAppearance.BorderSize = 0;
            this.btnEmployee1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployee1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee1.ForeColor = System.Drawing.Color.White;
            this.btnEmployee1.Image = global::Gym_System.Properties.Resources.Employee;
            this.btnEmployee1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnEmployee1.Location = new System.Drawing.Point(484, 12);
            this.btnEmployee1.Name = "btnEmployee1";
            this.btnEmployee1.Size = new System.Drawing.Size(160, 37);
            this.btnEmployee1.TabIndex = 2;
            this.btnEmployee1.Text = "       Employees";
            this.btnEmployee1.UseVisualStyleBackColor = false;
            this.btnEmployee1.Click += new System.EventHandler(this.btnEmployee1_Click);
            // 
            // btnSubscriber1
            // 
            this.btnSubscriber1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubscriber1.BackColor = System.Drawing.Color.Transparent;
            this.btnSubscriber1.FlatAppearance.BorderSize = 0;
            this.btnSubscriber1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubscriber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubscriber1.ForeColor = System.Drawing.Color.White;
            this.btnSubscriber1.Image = global::Gym_System.Properties.Resources.Subscribers;
            this.btnSubscriber1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSubscriber1.Location = new System.Drawing.Point(314, 12);
            this.btnSubscriber1.Name = "btnSubscriber1";
            this.btnSubscriber1.Size = new System.Drawing.Size(164, 37);
            this.btnSubscriber1.TabIndex = 1;
            this.btnSubscriber1.Text = "      Subscribers";
            this.btnSubscriber1.UseVisualStyleBackColor = false;
            this.btnSubscriber1.Click += new System.EventHandler(this.btnSubscriber1_Click);
            // 
            // btnUser1
            // 
            this.btnUser1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUser1.BackColor = System.Drawing.Color.Transparent;
            this.btnUser1.FlatAppearance.BorderSize = 0;
            this.btnUser1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser1.ForeColor = System.Drawing.Color.White;
            this.btnUser1.Image = global::Gym_System.Properties.Resources.User;
            this.btnUser1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnUser1.Location = new System.Drawing.Point(204, 11);
            this.btnUser1.Name = "btnUser1";
            this.btnUser1.Size = new System.Drawing.Size(104, 37);
            this.btnUser1.TabIndex = 0;
            this.btnUser1.Text = "      User";
            this.btnUser1.UseVisualStyleBackColor = false;
            this.btnUser1.Click += new System.EventHandler(this.btnUser1_Click);
            // 
            // lblClock1
            // 
            this.lblClock1.AutoSize = true;
            this.lblClock1.BackColor = System.Drawing.Color.Transparent;
            this.lblClock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock1.ForeColor = System.Drawing.Color.White;
            this.lblClock1.Location = new System.Drawing.Point(12, 34);
            this.lblClock1.Name = "lblClock1";
            this.lblClock1.Size = new System.Drawing.Size(44, 18);
            this.lblClock1.TabIndex = 0;
            this.lblClock1.Text = "00:00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1338, 585);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Gym_System.Properties.Resources.MainMenuBG;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1338, 585);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Image = global::Gym_System.Properties.Resources.Logout;
            this.btnLogout.Location = new System.Drawing.Point(1155, 11);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(64, 42);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnUser
            // 
            this.btnUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUser.FlatAppearance.BorderSize = 0;
            this.btnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Image = global::Gym_System.Properties.Resources.User1;
            this.btnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Location = new System.Drawing.Point(154, 8);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(104, 32);
            this.btnUser.TabIndex = 3;
            this.btnUser.Text = "      User";
            this.btnUser.UseVisualStyleBackColor = true;
            // 
            // btnSubs
            // 
            this.btnSubs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubs.FlatAppearance.BorderSize = 0;
            this.btnSubs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSubs.ForeColor = System.Drawing.Color.White;
            this.btnSubs.Image = global::Gym_System.Properties.Resources.Subscribers;
            this.btnSubs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubs.Location = new System.Drawing.Point(269, 8);
            this.btnSubs.Name = "btnSubs";
            this.btnSubs.Size = new System.Drawing.Size(161, 32);
            this.btnSubs.TabIndex = 4;
            this.btnSubs.Text = "     Subscribers";
            this.btnSubs.UseVisualStyleBackColor = true;
            // 
            // btnEmp
            // 
            this.btnEmp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEmp.FlatAppearance.BorderSize = 0;
            this.btnEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmp.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnEmp.ForeColor = System.Drawing.Color.White;
            this.btnEmp.Image = global::Gym_System.Properties.Resources.Employee;
            this.btnEmp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmp.Location = new System.Drawing.Point(446, 8);
            this.btnEmp.Name = "btnEmp";
            this.btnEmp.Size = new System.Drawing.Size(152, 32);
            this.btnEmp.TabIndex = 5;
            this.btnEmp.Text = "       Employees";
            this.btnEmp.UseVisualStyleBackColor = true;
            // 
            // btnsubInfo
            // 
            this.btnsubInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsubInfo.FlatAppearance.BorderSize = 0;
            this.btnsubInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubInfo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnsubInfo.ForeColor = System.Drawing.Color.White;
            this.btnsubInfo.Image = global::Gym_System.Properties.Resources.SubInfo;
            this.btnsubInfo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnsubInfo.Location = new System.Drawing.Point(604, 5);
            this.btnsubInfo.Name = "btnsubInfo";
            this.btnsubInfo.Size = new System.Drawing.Size(220, 39);
            this.btnsubInfo.TabIndex = 6;
            this.btnsubInfo.Text = "     Subsicription Info";
            this.btnsubInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnsubInfo.UseVisualStyleBackColor = true;
            // 
            // btnPresence
            // 
            this.btnPresence.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPresence.FlatAppearance.BorderSize = 0;
            this.btnPresence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresence.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnPresence.ForeColor = System.Drawing.Color.White;
            this.btnPresence.Image = global::Gym_System.Properties.Resources.Presence;
            this.btnPresence.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPresence.Location = new System.Drawing.Point(830, 8);
            this.btnPresence.Name = "btnPresence";
            this.btnPresence.Size = new System.Drawing.Size(141, 32);
            this.btnPresence.TabIndex = 4;
            this.btnPresence.Text = "     Presence";
            this.btnPresence.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1338, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlNavBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlNavBar.ResumeLayout(false);
            this.pnlNavBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnSubs;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnEmp;
        private System.Windows.Forms.Button btnsubInfo;
        private System.Windows.Forms.Button btnPresence;
        private System.Windows.Forms.Panel pnlNavBar;
        private System.Windows.Forms.Label lblClock1;
        private System.Windows.Forms.Button btnSubInfo1;
        private System.Windows.Forms.Button btnEmployee1;
        private System.Windows.Forms.Button btnSubscriber1;
        private System.Windows.Forms.Button btnUser1;
        private System.Windows.Forms.Button btnLogout1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Presence;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUserName;
    }
}

