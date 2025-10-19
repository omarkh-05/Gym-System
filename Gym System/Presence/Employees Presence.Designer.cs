namespace Gym_System.Presence
{
    partial class frmEmployeesPresence
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordCheckout = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRecordCheckin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvEmployeeCheckoutPresence = new System.Windows.Forms.DataGridView();
            this.dgvEmployeeCheckinPresence = new System.Windows.Forms.DataGridView();
            this.PersonInfoControl = new Gym_System.Controls.InfoControl();
            this.infoControl1 = new Gym_System.Controls.InfoControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeCheckoutPresence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeCheckinPresence)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Location = new System.Drawing.Point(38, 452);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1719, 10);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(813, 979);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(172, 51);
            this.btnClose.TabIndex = 108;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbFilter.BackColor = System.Drawing.Color.White;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.ItemHeight = 22;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "EmployeeID",
            "PersonID",
            "Presence Time",
            "EnterID"});
            this.cbFilter.Location = new System.Drawing.Point(188, 513);
            this.cbFilter.MaxDropDownItems = 12;
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(171, 30);
            this.cbFilter.TabIndex = 106;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(63, 511);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 29);
            this.label1.TabIndex = 104;
            this.label1.Text = "Filter By:";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(365, 511);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(200, 32);
            this.tbSearch.TabIndex = 105;
            this.tbSearch.Visible = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(158)))));
            this.label2.Location = new System.Drawing.Point(37, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 36);
            this.label2.TabIndex = 110;
            this.label2.Text = "Employees Presence";
            // 
            // lblRecordCheckout
            // 
            this.lblRecordCheckout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordCheckout.AutoSize = true;
            this.lblRecordCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCheckout.Location = new System.Drawing.Point(1077, 930);
            this.lblRecordCheckout.Name = "lblRecordCheckout";
            this.lblRecordCheckout.Size = new System.Drawing.Size(19, 20);
            this.lblRecordCheckout.TabIndex = 133;
            this.lblRecordCheckout.Text = "..";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(974, 930);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 132;
            this.label6.Text = "Records : ";
            // 
            // lblRecordCheckin
            // 
            this.lblRecordCheckin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordCheckin.AutoSize = true;
            this.lblRecordCheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCheckin.Location = new System.Drawing.Point(167, 930);
            this.lblRecordCheckin.Name = "lblRecordCheckin";
            this.lblRecordCheckin.Size = new System.Drawing.Size(19, 20);
            this.lblRecordCheckin.TabIndex = 131;
            this.lblRecordCheckin.Text = "..";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(64, 930);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 130;
            this.label4.Text = "Records : ";
            // 
            // dgvEmployeeCheckoutPresence
            // 
            this.dgvEmployeeCheckoutPresence.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvEmployeeCheckoutPresence.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEmployeeCheckoutPresence.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmployeeCheckoutPresence.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvEmployeeCheckoutPresence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeCheckoutPresence.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEmployeeCheckoutPresence.Location = new System.Drawing.Point(978, 556);
            this.dgvEmployeeCheckoutPresence.Name = "dgvEmployeeCheckoutPresence";
            this.dgvEmployeeCheckoutPresence.RowHeadersWidth = 51;
            this.dgvEmployeeCheckoutPresence.RowTemplate.Height = 24;
            this.dgvEmployeeCheckoutPresence.Size = new System.Drawing.Size(810, 371);
            this.dgvEmployeeCheckoutPresence.TabIndex = 129;
            this.dgvEmployeeCheckoutPresence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeCheckoutPresence_CellClick);
            this.dgvEmployeeCheckoutPresence.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvEmployeeCheckoutPresence_DataBindingComplete);
            // 
            // dgvEmployeeCheckinPresence
            // 
            this.dgvEmployeeCheckinPresence.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvEmployeeCheckinPresence.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEmployeeCheckinPresence.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmployeeCheckinPresence.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvEmployeeCheckinPresence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeCheckinPresence.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvEmployeeCheckinPresence.Location = new System.Drawing.Point(68, 556);
            this.dgvEmployeeCheckinPresence.Name = "dgvEmployeeCheckinPresence";
            this.dgvEmployeeCheckinPresence.RowHeadersWidth = 51;
            this.dgvEmployeeCheckinPresence.RowTemplate.Height = 24;
            this.dgvEmployeeCheckinPresence.Size = new System.Drawing.Size(810, 371);
            this.dgvEmployeeCheckinPresence.TabIndex = 128;
            this.dgvEmployeeCheckinPresence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeCheckinPresence_CellClick);
            this.dgvEmployeeCheckinPresence.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvEmployeeCheckinPresence_DataBindingComplete);
            // 
            // PersonInfoControl
            // 
            this.PersonInfoControl.Location = new System.Drawing.Point(305, 94);
            this.PersonInfoControl.Name = "PersonInfoControl";
            this.PersonInfoControl.Size = new System.Drawing.Size(1355, 312);
            this.PersonInfoControl.TabIndex = 111;
            // 
            // infoControl1
            // 
            this.infoControl1.Location = new System.Drawing.Point(380, 115);
            this.infoControl1.Name = "infoControl1";
            this.infoControl1.Size = new System.Drawing.Size(1268, 312);
            this.infoControl1.TabIndex = 134;
            // 
            // frmEmployeesPresence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1800, 1102);
            this.Controls.Add(this.infoControl1);
            this.Controls.Add(this.lblRecordCheckout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRecordCheckin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvEmployeeCheckoutPresence);
            this.Controls.Add(this.dgvEmployeeCheckinPresence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmployeesPresence";
            this.Text = "Employees";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployeesPresence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeCheckoutPresence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeCheckinPresence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private Controls.InfoControl PersonInfoControl;
        private System.Windows.Forms.Label lblRecordCheckout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRecordCheckin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvEmployeeCheckoutPresence;
        private System.Windows.Forms.DataGridView dgvEmployeeCheckinPresence;
        private Controls.InfoControl infoControl1;
    }
}