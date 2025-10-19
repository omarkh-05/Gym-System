namespace Gym_System.Subscription_Info
{
    partial class frmSubscription_Info
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
            this.btnClose = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSupscriptionInfo = new System.Windows.Forms.DataGridView();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSubscriptionInfoEdit = new System.Windows.Forms.Panel();
            this.tbMinAge = new Gym_System.NumberTextBox();
            this.tbSubscriptionDuration = new Gym_System.NumberTextBox();
            this.tbFees = new Gym_System.NumberTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbDepartmentName = new Gym_System.RequiredTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbendTime = new Gym_System.RequiredTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbstartTime = new Gym_System.RequiredTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupscriptionInfo)).BeginInit();
            this.pnlSubscriptionInfoEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(819, 1010);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(172, 51);
            this.btnClose.TabIndex = 106;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbFilter.BackColor = System.Drawing.Color.White;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.ItemHeight = 25;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "SubTime ID",
            "Department Name",
            "Min Age",
            "Fees"});
            this.cbFilter.Location = new System.Drawing.Point(177, 500);
            this.cbFilter.MaxDropDownItems = 12;
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(171, 33);
            this.cbFilter.TabIndex = 104;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(55, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 29);
            this.label1.TabIndex = 102;
            this.label1.Text = "Filter By:";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(354, 499);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(200, 34);
            this.tbSearch.TabIndex = 103;
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
            this.label2.Size = new System.Drawing.Size(419, 36);
            this.label2.TabIndex = 107;
            this.label2.Text = "Subscription Info And Settings";
            // 
            // dgvSupscriptionInfo
            // 
            this.dgvSupscriptionInfo.AllowUserToAddRows = false;
            this.dgvSupscriptionInfo.AllowUserToDeleteRows = false;
            this.dgvSupscriptionInfo.AllowUserToOrderColumns = true;
            this.dgvSupscriptionInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvSupscriptionInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSupscriptionInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSupscriptionInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvSupscriptionInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupscriptionInfo.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSupscriptionInfo.Location = new System.Drawing.Point(68, 556);
            this.dgvSupscriptionInfo.Name = "dgvSupscriptionInfo";
            this.dgvSupscriptionInfo.ReadOnly = true;
            this.dgvSupscriptionInfo.RowHeadersWidth = 51;
            this.dgvSupscriptionInfo.RowTemplate.Height = 24;
            this.dgvSupscriptionInfo.Size = new System.Drawing.Size(1687, 385);
            this.dgvSupscriptionInfo.TabIndex = 105;
            this.dgvSupscriptionInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubscriptionInfo_CellClick);
            this.dgvSupscriptionInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSupscriptionInfo_DataBindingComplete);
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(153, 943);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(19, 20);
            this.lblRecord.TabIndex = 109;
            this.lblRecord.Text = "..";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(56, 943);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 20);
            this.label4.TabIndex = 108;
            this.label4.Text = "Records : ";
            // 
            // pnlSubscriptionInfoEdit
            // 
            this.pnlSubscriptionInfoEdit.Controls.Add(this.tbMinAge);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.tbSubscriptionDuration);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.tbFees);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.btnSave);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.label9);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.label8);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.label7);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.tbDepartmentName);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.label5);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.tbendTime);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.label3);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.tbstartTime);
            this.pnlSubscriptionInfoEdit.Controls.Add(this.label6);
            this.pnlSubscriptionInfoEdit.Location = new System.Drawing.Point(43, 77);
            this.pnlSubscriptionInfoEdit.Name = "pnlSubscriptionInfoEdit";
            this.pnlSubscriptionInfoEdit.Size = new System.Drawing.Size(1706, 285);
            this.pnlSubscriptionInfoEdit.TabIndex = 110;
            this.pnlSubscriptionInfoEdit.Visible = false;
            // 
            // tbMinAge
            // 
            this.tbMinAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tbMinAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMinAge.ErrorMessage = "This Field Is Required";
            this.tbMinAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMinAge.IsRequired = true;
            this.tbMinAge.Location = new System.Drawing.Point(772, 122);
            this.tbMinAge.Multiline = true;
            this.tbMinAge.Name = "tbMinAge";
            this.tbMinAge.Size = new System.Drawing.Size(200, 30);
            this.tbMinAge.TabIndex = 93;
            // 
            // tbSubscriptionDuration
            // 
            this.tbSubscriptionDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tbSubscriptionDuration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSubscriptionDuration.ErrorMessage = "This Field Is Required";
            this.tbSubscriptionDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSubscriptionDuration.IsRequired = true;
            this.tbSubscriptionDuration.Location = new System.Drawing.Point(1278, 39);
            this.tbSubscriptionDuration.Multiline = true;
            this.tbSubscriptionDuration.Name = "tbSubscriptionDuration";
            this.tbSubscriptionDuration.Size = new System.Drawing.Size(200, 30);
            this.tbSubscriptionDuration.TabIndex = 92;
            // 
            // tbFees
            // 
            this.tbFees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tbFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFees.ErrorMessage = "This Field Is Required";
            this.tbFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFees.IsRequired = true;
            this.tbFees.Location = new System.Drawing.Point(1278, 122);
            this.tbFees.Multiline = true;
            this.tbFees.Name = "tbFees";
            this.tbFees.Size = new System.Drawing.Size(200, 30);
            this.tbFees.TabIndex = 91;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(127)))), ((int)(((byte)(154)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(776, 215);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 51);
            this.btnSave.TabIndex = 90;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label9.Location = new System.Drawing.Point(1098, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 29);
            this.label9.TabIndex = 88;
            this.label9.Text = "Sub Duration : ";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label8.Location = new System.Drawing.Point(1182, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 29);
            this.label8.TabIndex = 86;
            this.label8.Text = "Fees : ";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label7.Location = new System.Drawing.Point(638, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 29);
            this.label7.TabIndex = 84;
            this.label7.Text = "Min Age : ";
            // 
            // tbDepartmentName
            // 
            this.tbDepartmentName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbDepartmentName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tbDepartmentName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDepartmentName.ErrorMessage = "Required";
            this.tbDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDepartmentName.IsRequired = true;
            this.tbDepartmentName.Location = new System.Drawing.Point(772, 36);
            this.tbDepartmentName.Multiline = true;
            this.tbDepartmentName.Name = "tbDepartmentName";
            this.tbDepartmentName.Size = new System.Drawing.Size(200, 30);
            this.tbDepartmentName.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label5.Location = new System.Drawing.Point(530, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 29);
            this.label5.TabIndex = 82;
            this.label5.Text = "Department Name : ";
            // 
            // tbendTime
            // 
            this.tbendTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbendTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tbendTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbendTime.ErrorMessage = "Required";
            this.tbendTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbendTime.IsRequired = false;
            this.tbendTime.Location = new System.Drawing.Point(233, 122);
            this.tbendTime.Multiline = true;
            this.tbendTime.Name = "tbendTime";
            this.tbendTime.Size = new System.Drawing.Size(200, 30);
            this.tbendTime.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label3.Location = new System.Drawing.Point(80, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 29);
            this.label3.TabIndex = 80;
            this.label3.Text = "End Time : ";
            // 
            // tbstartTime
            // 
            this.tbstartTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbstartTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.tbstartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbstartTime.ErrorMessage = "Required";
            this.tbstartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbstartTime.IsRequired = false;
            this.tbstartTime.Location = new System.Drawing.Point(233, 38);
            this.tbstartTime.Multiline = true;
            this.tbstartTime.Name = "tbstartTime";
            this.tbstartTime.Size = new System.Drawing.Size(200, 30);
            this.tbstartTime.TabIndex = 79;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.label6.Location = new System.Drawing.Point(74, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 29);
            this.label6.TabIndex = 78;
            this.label6.Text = "Start Time : ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSubscription_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1800, 1102);
            this.Controls.Add(this.pnlSubscriptionInfoEdit);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvSupscriptionInfo);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubscription_Info";
            this.Text = "Subscription_Info";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSubscription_Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupscriptionInfo)).EndInit();
            this.pnlSubscriptionInfoEdit.ResumeLayout(false);
            this.pnlSubscriptionInfoEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSupscriptionInfo;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlSubscriptionInfoEdit;
        private System.Windows.Forms.Label label7;
        private RequiredTextBox tbDepartmentName;
        private System.Windows.Forms.Label label5;
        private RequiredTextBox tbendTime;
        private System.Windows.Forms.Label label3;
        private RequiredTextBox tbstartTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private NumberTextBox tbMinAge;
        private NumberTextBox tbSubscriptionDuration;
        private NumberTextBox tbFees;
    }
}