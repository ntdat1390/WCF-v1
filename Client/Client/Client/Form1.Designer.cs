namespace Client
{
    partial class Form1
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
            this.bt_DangNhap = new System.Windows.Forms.Button();
            this.bt_DangKy = new System.Windows.Forms.Button();
            this.tb_Pass = new System.Windows.Forms.TextBox();
            this.tb_User = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_DangNhap
            // 
            this.bt_DangNhap.Location = new System.Drawing.Point(93, 58);
            this.bt_DangNhap.Name = "bt_DangNhap";
            this.bt_DangNhap.Size = new System.Drawing.Size(75, 23);
            this.bt_DangNhap.TabIndex = 17;
            this.bt_DangNhap.Text = "Đăng nhập";
            this.bt_DangNhap.UseVisualStyleBackColor = true;
            this.bt_DangNhap.Click += new System.EventHandler(this.bt_DangNhap_Click);
            // 
            // bt_DangKy
            // 
            this.bt_DangKy.Location = new System.Drawing.Point(7, 58);
            this.bt_DangKy.Name = "bt_DangKy";
            this.bt_DangKy.Size = new System.Drawing.Size(75, 23);
            this.bt_DangKy.TabIndex = 16;
            this.bt_DangKy.Text = "Đăng ký";
            this.bt_DangKy.UseVisualStyleBackColor = true;
            this.bt_DangKy.Click += new System.EventHandler(this.bt_DangKy_Click);
            // 
            // tb_Pass
            // 
            this.tb_Pass.Location = new System.Drawing.Point(68, 33);
            this.tb_Pass.Name = "tb_Pass";
            this.tb_Pass.PasswordChar = '*';
            this.tb_Pass.Size = new System.Drawing.Size(100, 20);
            this.tb_Pass.TabIndex = 15;
            // 
            // tb_User
            // 
            this.tb_User.Location = new System.Drawing.Point(68, 6);
            this.tb_User.Name = "tb_User";
            this.tb_User.Size = new System.Drawing.Size(100, 20);
            this.tb_User.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "User";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 90);
            this.Controls.Add(this.bt_DangNhap);
            this.Controls.Add(this.bt_DangKy);
            this.Controls.Add(this.tb_Pass);
            this.Controls.Add(this.tb_User);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Đăng Nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_DangNhap;
        private System.Windows.Forms.Button bt_DangKy;
        private System.Windows.Forms.TextBox tb_Pass;
        private System.Windows.Forms.TextBox tb_User;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;



    }
}

