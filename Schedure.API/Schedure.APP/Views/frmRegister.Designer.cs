namespace Schedure.APP.Views
{
    partial class frmRegister
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmbChuyenKhoa = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cmbPhongKham = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbBacSi = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dateNgayKham = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaYTe = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.mDataGridView1 = new Schedure.APP.UC.MDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(92, 17);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(117, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Chuyên khoa";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cmbChuyenKhoa
            // 
            this.cmbChuyenKhoa.DisplayMember = "Text";
            this.cmbChuyenKhoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChuyenKhoa.FormattingEnabled = true;
            this.cmbChuyenKhoa.ItemHeight = 22;
            this.cmbChuyenKhoa.Location = new System.Drawing.Point(215, 12);
            this.cmbChuyenKhoa.Name = "cmbChuyenKhoa";
            this.cmbChuyenKhoa.Size = new System.Drawing.Size(249, 28);
            this.cmbChuyenKhoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbChuyenKhoa.TabIndex = 2;
            this.cmbChuyenKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbChuyenKhoa_SelectedIndexChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(92, 51);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(117, 23);
            this.labelX3.TabIndex = 1;
            this.labelX3.Text = "Phòng khám";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(92, 85);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(117, 23);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "Bác sĩ";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cmbPhongKham
            // 
            this.cmbPhongKham.DisplayMember = "Text";
            this.cmbPhongKham.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPhongKham.FormattingEnabled = true;
            this.cmbPhongKham.ItemHeight = 22;
            this.cmbPhongKham.Location = new System.Drawing.Point(215, 46);
            this.cmbPhongKham.Name = "cmbPhongKham";
            this.cmbPhongKham.Size = new System.Drawing.Size(249, 28);
            this.cmbPhongKham.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPhongKham.TabIndex = 2;
            this.cmbPhongKham.SelectedIndexChanged += new System.EventHandler(this.cmbPhongKham_SelectedIndexChanged);
            // 
            // cmbBacSi
            // 
            this.cmbBacSi.DisplayMember = "Text";
            this.cmbBacSi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBacSi.FormattingEnabled = true;
            this.cmbBacSi.ItemHeight = 22;
            this.cmbBacSi.Location = new System.Drawing.Point(215, 80);
            this.cmbBacSi.Name = "cmbBacSi";
            this.cmbBacSi.Size = new System.Drawing.Size(249, 28);
            this.cmbBacSi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbBacSi.TabIndex = 2;
            this.cmbBacSi.SelectedIndexChanged += new System.EventHandler(this.cmbBacSi_SelectedIndexChanged);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(69, 153);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(140, 23);
            this.labelX6.TabIndex = 1;
            this.labelX6.Text = "Số điện thoại BN";
            this.labelX6.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(27, 118);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(182, 23);
            this.labelX7.TabIndex = 1;
            this.labelX7.Text = "Ngày đăng kí khám";
            this.labelX7.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(215, 148);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(249, 28);
            this.txtPhone.TabIndex = 4;
            // 
            // dateNgayKham
            // 
            this.dateNgayKham.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateNgayKham.Location = new System.Drawing.Point(215, 114);
            this.dateNgayKham.Name = "dateNgayKham";
            this.dateNgayKham.Size = new System.Drawing.Size(249, 28);
            this.dateNgayKham.TabIndex = 5;
            this.dateNgayKham.ValueChanged += new System.EventHandler(this.dateNgayKham_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelX7);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cmbBacSi);
            this.panel1.Controls.Add(this.dateNgayKham);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.cmbPhongKham);
            this.panel1.Controls.Add(this.labelX6);
            this.panel1.Controls.Add(this.cmbChuyenKhoa);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Controls.Add(this.labelX2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 202);
            this.panel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaYTe);
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.labelX10);
            this.groupBox1.Controls.Add(this.labelX9);
            this.groupBox1.Controls.Add(this.labelX8);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Location = new System.Drawing.Point(498, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 190);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bệnh nhân";
            // 
            // txtMaYTe
            // 
            this.txtMaYTe.Location = new System.Drawing.Point(141, 22);
            this.txtMaYTe.Name = "txtMaYTe";
            this.txtMaYTe.Size = new System.Drawing.Size(162, 28);
            this.txtMaYTe.TabIndex = 10;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(141, 123);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(242, 61);
            this.txtMessage.TabIndex = 9;
            this.txtMessage.Text = "";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(141, 90);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(242, 28);
            this.txtStatus.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(141, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(242, 28);
            this.txtName.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 45);
            this.button1.TabIndex = 6;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Location = new System.Drawing.Point(6, 115);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(129, 23);
            this.labelX10.TabIndex = 1;
            this.labelX10.Text = "Tin nhắn: ";
            this.labelX10.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(6, 86);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(129, 23);
            this.labelX9.TabIndex = 1;
            this.labelX9.Text = "Trạng thái: ";
            this.labelX9.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(6, 57);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(129, 23);
            this.labelX8.TabIndex = 1;
            this.labelX8.Text = "Tên bệnh nhân: ";
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(6, 27);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(129, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Mã y tế: ";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mDataGridView1);
            this.panel2.Controls.Add(this.labelX5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(912, 440);
            this.panel2.TabIndex = 8;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX5.Location = new System.Drawing.Point(0, 0);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(912, 28);
            this.labelX5.TabIndex = 1;
            this.labelX5.Text = "- Lịch làm việc";
            // 
            // mDataGridView1
            // 
            this.mDataGridView1.AllowUserToAddRows = false;
            this.mDataGridView1.AllowUserToDeleteRows = false;
            this.mDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mDataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.mDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mDataGridView1.Enabled = false;
            this.mDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.mDataGridView1.IsCellFormatting = true;
            this.mDataGridView1.Location = new System.Drawing.Point(0, 28);
            this.mDataGridView1.Name = "mDataGridView1";
            this.mDataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mDataGridView1.RowTemplate.Height = 24;
            this.mDataGridView1.Size = new System.Drawing.Size(912, 412);
            this.mDataGridView1.TabIndex = 8;
            this.mDataGridView1.MyCellClick += new Schedure.APP.UC.MDataGridView.Mdata(this.mDataGridView1_MyCellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "BÁC SĨ";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "NGÀY";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "THỜI GIAN LÀM";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ĐĂNG KÍ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Text = "ĐĂNG KÍ";
            this.Column4.UseColumnTextForButtonValue = true;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 667);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "frmRegister";
            this.Text = "ĐĂNG KÍ KHÁM BỆNH";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbChuyenKhoa;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPhongKham;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbBacSi;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dateNgayKham;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX10;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.TextBox txtMaYTe;
        private UC.MDataGridView mDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}