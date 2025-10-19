namespace Gym_System.Presence
{
    partial class frmSubscribersPresence
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvCheckinPresence = new System.Windows.Forms.DataGridView();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.dgvCheckoutPresence = new System.Windows.Forms.DataGridView();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRecordCheckout = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PersonInfoControl = new Gym_System.Controls.InfoControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckinPresence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckoutPresence)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(158)))));
            this.label2.Location = new System.Drawing.Point(37, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 36);
            this.label2.TabIndex = 118;
            this.label2.Text = "Subscribers Presence";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Location = new System.Drawing.Point(38, 449);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1719, 10);
            this.groupBox2.TabIndex = 117;
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
            this.btnClose.TabIndex = 116;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvCheckinPresence
            // 
            this.dgvCheckinPresence.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCheckinPresence.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCheckinPresence.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCheckinPresence.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvCheckinPresence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckinPresence.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCheckinPresence.Location = new System.Drawing.Point(68, 556);
            this.dgvCheckinPresence.Name = "dgvCheckinPresence";
            this.dgvCheckinPresence.RowHeadersWidth = 51;
            this.dgvCheckinPresence.RowTemplate.Height = 24;
            this.dgvCheckinPresence.Size = new System.Drawing.Size(720, 371);
            this.dgvCheckinPresence.TabIndex = 115;
            this.dgvCheckinPresence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckinPresence_CellClick);
            this.dgvCheckinPresence.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCheckinPresence_DataBindingComplete);
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
            "PersonID",
            "EnterID",
            "Checkin Time",
            "Checkout Time"});
            this.cbFilter.Location = new System.Drawing.Point(178, 511);
            this.cbFilter.MaxDropDownItems = 12;
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(171, 30);
            this.cbFilter.TabIndex = 114;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(63, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 29);
            this.label1.TabIndex = 112;
            this.label1.Text = "Filter By:";
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(355, 511);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(200, 30);
            this.tbSearch.TabIndex = 113;
            this.tbSearch.Visible = false;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // dgvCheckoutPresence
            // 
            this.dgvCheckoutPresence.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCheckoutPresence.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCheckoutPresence.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCheckoutPresence.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvCheckoutPresence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckoutPresence.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCheckoutPresence.Location = new System.Drawing.Point(947, 556);
            this.dgvCheckoutPresence.Name = "dgvCheckoutPresence";
            this.dgvCheckoutPresence.RowHeadersWidth = 51;
            this.dgvCheckoutPresence.RowTemplate.Height = 24;
            this.dgvCheckoutPresence.Size = new System.Drawing.Size(810, 371);
            this.dgvCheckoutPresence.TabIndex = 120;
            this.dgvCheckoutPresence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckoutPresence_CellClick);
            this.dgvCheckoutPresence.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCheckoutPresence_DataBindingComplete);
            // 
            // lblRecord
            // 
            this.lblRecord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(167, 930);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(19, 20);
            this.lblRecord.TabIndex = 125;
            this.lblRecord.Text = "..";
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
            this.label4.TabIndex = 124;
            this.label4.Text = "Records : ";
            // 
            // lblRecordCheckout
            // 
            this.lblRecordCheckout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRecordCheckout.AutoSize = true;
            this.lblRecordCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCheckout.Location = new System.Drawing.Point(1046, 930);
            this.lblRecordCheckout.Name = "lblRecordCheckout";
            this.lblRecordCheckout.Size = new System.Drawing.Size(19, 20);
            this.lblRecordCheckout.TabIndex = 127;
            this.lblRecordCheckout.Text = "..";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(943, 930);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 126;
            this.label6.Text = "Records : ";
            // 
            // PersonInfoControl
            // 
            this.PersonInfoControl.Location = new System.Drawing.Point(305, 94);
            this.PersonInfoControl.Name = "PersonInfoControl";
            this.PersonInfoControl.Size = new System.Drawing.Size(1355, 312);
            this.PersonInfoControl.TabIndex = 119;
            // 
            // frmSubscribersPresence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1800, 1102);
            this.Controls.Add(this.lblRecordCheckout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCheckoutPresence);
            this.Controls.Add(this.PersonInfoControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvCheckinPresence);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubscribersPresence";
            this.Text = "Subscribers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSubscribersPresence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckinPresence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckoutPresence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.InfoControl PersonInfoControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvCheckinPresence;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView dgvCheckoutPresence;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRecordCheckout;
        private System.Windows.Forms.Label label6;
    }
}