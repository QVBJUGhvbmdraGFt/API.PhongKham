namespace Schedure.APP.Views
{
    partial class frmConfirm
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblFullName = new DevComponents.DotNetBar.LabelX();
            this.lblMayte = new DevComponents.DotNetBar.LabelX();
            this.lblsdt = new DevComponents.DotNetBar.LabelX();
            this.lblmesage = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbllichlamviec = new DevComponents.DotNetBar.LabelX();
            this.lblngaykham = new DevComponents.DotNetBar.LabelX();
            this.lblbacsi = new DevComponents.DotNetBar.LabelX();
            this.lblphongkham = new DevComponents.DotNetBar.LabelX();
            this.lblchuyenkhoa = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBaseMain
            // 
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(372, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Xác nhận thông tin với bệnh nhân.";
            // 
            // lblFullName
            // 
            // 
            // 
            // 
            this.lblFullName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblFullName.Location = new System.Drawing.Point(26, 37);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(595, 23);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Tag = "Họ tên bệnh nhân: {0}";
            this.lblFullName.Text = "Họ tên bệnh nhân: {0}";
            // 
            // lblMayte
            // 
            // 
            // 
            // 
            this.lblMayte.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMayte.Location = new System.Drawing.Point(26, 74);
            this.lblMayte.Name = "lblMayte";
            this.lblMayte.Size = new System.Drawing.Size(595, 23);
            this.lblMayte.TabIndex = 1;
            this.lblMayte.Tag = "Mã y tế: {0}";
            this.lblMayte.Text = "Mã y tế: {0}";
            // 
            // lblsdt
            // 
            // 
            // 
            // 
            this.lblsdt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblsdt.Location = new System.Drawing.Point(26, 111);
            this.lblsdt.Name = "lblsdt";
            this.lblsdt.Size = new System.Drawing.Size(595, 23);
            this.lblsdt.TabIndex = 1;
            this.lblsdt.Tag = "SDT: {0}";
            this.lblsdt.Text = "SDT: {0}";
            // 
            // lblmesage
            // 
            // 
            // 
            // 
            this.lblmesage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblmesage.Location = new System.Drawing.Point(26, 148);
            this.lblmesage.Name = "lblmesage";
            this.lblmesage.Size = new System.Drawing.Size(595, 62);
            this.lblmesage.TabIndex = 1;
            this.lblmesage.Tag = "Tin nhắn: {0}";
            this.lblmesage.Text = "Tin nhắn: {0}";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFullName);
            this.groupBox1.Controls.Add(this.lblmesage);
            this.groupBox1.Controls.Add(this.lblMayte);
            this.groupBox1.Controls.Add(this.lblsdt);
            this.groupBox1.Location = new System.Drawing.Point(31, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 215);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin bệnh nhân";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbllichlamviec);
            this.groupBox2.Controls.Add(this.lblngaykham);
            this.groupBox2.Controls.Add(this.lblbacsi);
            this.groupBox2.Controls.Add(this.lblphongkham);
            this.groupBox2.Controls.Add(this.lblchuyenkhoa);
            this.groupBox2.Location = new System.Drawing.Point(31, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(648, 199);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đăng kí";
            // 
            // lbllichlamviec
            // 
            // 
            // 
            // 
            this.lbllichlamviec.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbllichlamviec.Location = new System.Drawing.Point(27, 167);
            this.lbllichlamviec.Name = "lbllichlamviec";
            this.lbllichlamviec.Size = new System.Drawing.Size(595, 23);
            this.lbllichlamviec.TabIndex = 2;
            this.lbllichlamviec.Tag = "Lịch làm việc: {0}";
            this.lbllichlamviec.Text = "Lịch làm việc: {0}";
            // 
            // lblngaykham
            // 
            // 
            // 
            // 
            this.lblngaykham.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblngaykham.Location = new System.Drawing.Point(27, 132);
            this.lblngaykham.Name = "lblngaykham";
            this.lblngaykham.Size = new System.Drawing.Size(595, 23);
            this.lblngaykham.TabIndex = 2;
            this.lblngaykham.Tag = "Ngày khám: {0}";
            this.lblngaykham.Text = "Ngày khám: {0}";
            // 
            // lblbacsi
            // 
            // 
            // 
            // 
            this.lblbacsi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblbacsi.Location = new System.Drawing.Point(27, 97);
            this.lblbacsi.Name = "lblbacsi";
            this.lblbacsi.Size = new System.Drawing.Size(595, 23);
            this.lblbacsi.TabIndex = 2;
            this.lblbacsi.Tag = "Bác sĩ: {0}";
            this.lblbacsi.Text = "Bác sĩ: {0}";
            // 
            // lblphongkham
            // 
            // 
            // 
            // 
            this.lblphongkham.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblphongkham.Location = new System.Drawing.Point(27, 62);
            this.lblphongkham.Name = "lblphongkham";
            this.lblphongkham.Size = new System.Drawing.Size(595, 23);
            this.lblphongkham.TabIndex = 2;
            this.lblphongkham.Tag = "Phòng khám: {0}";
            this.lblphongkham.Text = "Phòng khám: {0}";
            // 
            // lblchuyenkhoa
            // 
            // 
            // 
            // 
            this.lblchuyenkhoa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblchuyenkhoa.Location = new System.Drawing.Point(27, 27);
            this.lblchuyenkhoa.Name = "lblchuyenkhoa";
            this.lblchuyenkhoa.Size = new System.Drawing.Size(595, 23);
            this.lblchuyenkhoa.TabIndex = 2;
            this.lblchuyenkhoa.Tag = "Chuyên khoa: {0}";
            this.lblchuyenkhoa.Text = "Chuyên khoa: {0}";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(46, 492);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(199, 50);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "Đã xác nhận (ACTIVE)";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(251, 492);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(199, 50);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 4;
            this.buttonX2.Text = "Hủy khám (CANCLE)";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(456, 492);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(199, 50);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 4;
            this.buttonX3.Text = "Hủy";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // frmConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 577);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmConfirm";
            this.Text = "XÁC NHẬN";
            this.Load += new System.EventHandler(this.frmConfirm_Load);
            this.Controls.SetChildIndex(this.labelX1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.buttonX1, 0);
            this.Controls.SetChildIndex(this.buttonX2, 0);
            this.Controls.SetChildIndex(this.buttonX3, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblFullName;
        private DevComponents.DotNetBar.LabelX lblMayte;
        private DevComponents.DotNetBar.LabelX lblsdt;
        private DevComponents.DotNetBar.LabelX lblmesage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.LabelX lblchuyenkhoa;
        private DevComponents.DotNetBar.LabelX lblphongkham;
        private DevComponents.DotNetBar.LabelX lblbacsi;
        private DevComponents.DotNetBar.LabelX lblngaykham;
        private DevComponents.DotNetBar.LabelX lbllichlamviec;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
    }
}