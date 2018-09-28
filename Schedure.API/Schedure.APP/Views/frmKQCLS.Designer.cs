﻿namespace Schedure.APP.Views
{
    partial class frmKQCLS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numSearch = new DevComponents.Editors.IntegerInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.dateend = new System.Windows.Forms.DateTimePicker();
            this.datestart = new System.Windows.Forms.DateTimePicker();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mDataGridView1 = new Schedure.APP.UC.MDataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSearch)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numSearch);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.dateend);
            this.panel1.Controls.Add(this.datestart);
            this.panel1.Controls.Add(this.labelX5);
            this.panel1.Controls.Add(this.buttonX2);
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1238, 107);
            this.panel1.TabIndex = 0;
            // 
            // numSearch
            // 
            this.numSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.numSearch.BackgroundStyle.Class = "DateTimeInputBackground";
            this.numSearch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.numSearch.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.numSearch.Location = new System.Drawing.Point(775, 40);
            this.numSearch.Name = "numSearch";
            this.numSearch.ShowUpDown = true;
            this.numSearch.Size = new System.Drawing.Size(130, 28);
            this.numSearch.TabIndex = 26;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(635, 44);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(134, 23);
            this.labelX3.TabIndex = 24;
            this.labelX3.Text = "ID Bệnh nhân: ";
            // 
            // labelX6
            // 
            this.labelX6.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(331, 44);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(118, 23);
            this.labelX6.TabIndex = 23;
            this.labelX6.Text = "Đến ngày (*): ";
            // 
            // dateend
            // 
            this.dateend.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateend.Location = new System.Drawing.Point(455, 40);
            this.dateend.Name = "dateend";
            this.dateend.Size = new System.Drawing.Size(143, 28);
            this.dateend.TabIndex = 19;
            // 
            // datestart
            // 
            this.datestart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.datestart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datestart.Location = new System.Drawing.Point(156, 40);
            this.datestart.Name = "datestart";
            this.datestart.Size = new System.Drawing.Size(143, 28);
            this.datestart.TabIndex = 20;
            // 
            // labelX5
            // 
            this.labelX5.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(54, 44);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(96, 23);
            this.labelX5.TabIndex = 18;
            this.labelX5.Text = "Từ ngày (*): ";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(1083, 27);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(117, 45);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 16;
            this.buttonX2.Text = "Reload";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(960, 27);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(117, 45);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 17;
            this.buttonX1.Text = "Lọc";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mDataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 107);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1238, 588);
            this.panel3.TabIndex = 2;
            // 
            // mDataGridView1
            // 
            this.mDataGridView1.AllowUserToAddRows = false;
            this.mDataGridView1.AllowUserToDeleteRows = false;
            this.mDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mDataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.mDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column2,
            this.Column1,
            this.Column7,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mDataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.mDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mDataGridView1.EnableHeadersVisualStyles = false;
            this.mDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.mDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.mDataGridView1.Name = "mDataGridView1";
            this.mDataGridView1.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.mDataGridView1.RowTemplate.Height = 24;
            this.mDataGridView1.Size = new System.Drawing.Size(1238, 588);
            this.mDataGridView1.TabIndex = 0;
            this.mDataGridView1.MyCellClick += new Schedure.APP.UC.MDataGridView.Mdata(this.mDataGridView1_MyCellClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "THỜI GIAN KHÁM";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "PHÒNG BAN";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "MÃ Y TẾ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "TÊN BỆNH NHÂN";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "TRIỆU CHỨNG";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "HẸN TÁI KHÁM";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Chi tiết";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Text = "Chi tiết";
            this.Column6.UseColumnTextForButtonValue = true;
            // 
            // frmKQCLS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 695);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmKQCLS";
            this.Text = "KẾT QUẢ KHÁM BỆNH";
            this.Load += new System.EventHandler(this.frmKQCLS_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSearch)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.DateTimePicker dateend;
        private System.Windows.Forms.DateTimePicker datestart;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private UC.MDataGridView mDataGridView1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn Column6;
        private DevComponents.Editors.IntegerInput numSearch;
    }
}