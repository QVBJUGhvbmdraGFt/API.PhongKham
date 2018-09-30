namespace Schedure.APP.Views
{
    partial class frmChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.oldPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.repass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.newpass = new System.Windows.Forms.TextBox();
            this.oke = new System.Windows.Forms.Button();
            this.cancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // oldPass
            // 
            this.oldPass.Location = new System.Drawing.Point(237, 45);
            this.oldPass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.oldPass.Name = "oldPass";
            this.oldPass.Size = new System.Drawing.Size(282, 28);
            this.oldPass.TabIndex = 1;
            this.oldPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xác nhận mật khẩu";
            // 
            // repass
            // 
            this.repass.Location = new System.Drawing.Point(237, 151);
            this.repass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.repass.Name = "repass";
            this.repass.Size = new System.Drawing.Size(282, 28);
            this.repass.TabIndex = 1;
            this.repass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu mới";
            // 
            // newpass
            // 
            this.newpass.Location = new System.Drawing.Point(237, 97);
            this.newpass.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newpass.Name = "newpass";
            this.newpass.Size = new System.Drawing.Size(282, 28);
            this.newpass.TabIndex = 1;
            this.newpass.UseSystemPasswordChar = true;
            // 
            // oke
            // 
            this.oke.Location = new System.Drawing.Point(138, 214);
            this.oke.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.oke.Name = "oke";
            this.oke.Size = new System.Drawing.Size(151, 52);
            this.oke.TabIndex = 2;
            this.oke.Text = "Hoàn thành";
            this.oke.UseVisualStyleBackColor = true;
            this.oke.Click += new System.EventHandler(this.oke_Click);
            // 
            // cancle
            // 
            this.cancle.Location = new System.Drawing.Point(298, 214);
            this.cancle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancle.Name = "cancle";
            this.cancle.Size = new System.Drawing.Size(151, 52);
            this.cancle.TabIndex = 3;
            this.cancle.Text = "Hủy";
            this.cancle.UseVisualStyleBackColor = true;
            this.cancle.Click += new System.EventHandler(this.cancle_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 314);
            this.Controls.Add(this.cancle);
            this.Controls.Add(this.oke);
            this.Controls.Add(this.newpass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.repass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldPass);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmChangePassword";
            this.Text = "ĐỔI MẬT KHẨU";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.oldPass, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.repass, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.newpass, 0);
            this.Controls.SetChildIndex(this.oke, 0);
            this.Controls.SetChildIndex(this.cancle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox oldPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox repass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox newpass;
        private System.Windows.Forms.Button oke;
        private System.Windows.Forms.Button cancle;
    }
}