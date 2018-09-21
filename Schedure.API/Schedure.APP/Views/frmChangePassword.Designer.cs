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
            this.label1.Location = new System.Drawing.Point(66, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // oldPass
            // 
            this.oldPass.Location = new System.Drawing.Point(211, 34);
            this.oldPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oldPass.Name = "oldPass";
            this.oldPass.Size = new System.Drawing.Size(251, 22);
            this.oldPass.TabIndex = 1;
            this.oldPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xác nhận mật khẩu";
            // 
            // repass
            // 
            this.repass.Location = new System.Drawing.Point(211, 115);
            this.repass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.repass.Name = "repass";
            this.repass.Size = new System.Drawing.Size(251, 22);
            this.repass.TabIndex = 1;
            this.repass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu mới";
            // 
            // newpass
            // 
            this.newpass.Location = new System.Drawing.Point(211, 74);
            this.newpass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newpass.Name = "newpass";
            this.newpass.Size = new System.Drawing.Size(251, 22);
            this.newpass.TabIndex = 1;
            this.newpass.UseSystemPasswordChar = true;
            // 
            // oke
            // 
            this.oke.Location = new System.Drawing.Point(123, 165);
            this.oke.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.oke.Name = "oke";
            this.oke.Size = new System.Drawing.Size(134, 52);
            this.oke.TabIndex = 2;
            this.oke.Text = "Hoàn thành";
            this.oke.UseVisualStyleBackColor = true;
            this.oke.Click += new System.EventHandler(this.oke_Click);
            // 
            // cancle
            // 
            this.cancle.Location = new System.Drawing.Point(265, 163);
            this.cancle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancle.Name = "cancle";
            this.cancle.Size = new System.Drawing.Size(134, 52);
            this.cancle.TabIndex = 3;
            this.cancle.Text = "Hủy";
            this.cancle.UseVisualStyleBackColor = true;
            this.cancle.Click += new System.EventHandler(this.cancle_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 239);
            this.Controls.Add(this.cancle);
            this.Controls.Add(this.oke);
            this.Controls.Add(this.newpass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.repass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldPass);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐỔI MẬT KHẨU";
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