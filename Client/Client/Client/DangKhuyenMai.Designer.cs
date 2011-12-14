namespace Client
{
    partial class DangKhuyenMai
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
            this.label20 = new System.Windows.Forms.Label();
            this.lv_dsketqua = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_thoigianstart = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tb_thoigianend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_thongtin = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tb_tenkhuyenmai = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_dangbai = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "Danh sách nhà hàng cà phê";
            // 
            // lv_dsketqua
            // 
            this.lv_dsketqua.Location = new System.Drawing.Point(23, 36);
            this.lv_dsketqua.Name = "lv_dsketqua";
            this.lv_dsketqua.Size = new System.Drawing.Size(366, 127);
            this.lv_dsketqua.TabIndex = 47;
            this.lv_dsketqua.UseCompatibleStateImageBehavior = false;
            this.lv_dsketqua.View = System.Windows.Forms.View.List;
            this.lv_dsketqua.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_dsketqua_ItemSelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_cancel);
            this.groupBox1.Controls.Add(this.bt_dangbai);
            this.groupBox1.Controls.Add(this.tb_thoigianstart);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.tb_thoigianend);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_thongtin);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.tb_tenkhuyenmai);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Location = new System.Drawing.Point(23, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 270);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // tb_thoigianstart
            // 
            this.tb_thoigianstart.Location = new System.Drawing.Point(113, 45);
            this.tb_thoigianstart.Name = "tb_thoigianstart";
            this.tb_thoigianstart.Size = new System.Drawing.Size(247, 20);
            this.tb_thoigianstart.TabIndex = 36;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(12, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "Thời Gian Bắt Đầu";
            // 
            // tb_thoigianend
            // 
            this.tb_thoigianend.Location = new System.Drawing.Point(113, 72);
            this.tb_thoigianend.Name = "tb_thoigianend";
            this.tb_thoigianend.Size = new System.Drawing.Size(247, 20);
            this.tb_thoigianend.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Thời Gian Kết Thúc";
            // 
            // tb_thongtin
            // 
            this.tb_thongtin.Location = new System.Drawing.Point(113, 98);
            this.tb_thongtin.Multiline = true;
            this.tb_thongtin.Name = "tb_thongtin";
            this.tb_thongtin.Size = new System.Drawing.Size(247, 133);
            this.tb_thongtin.TabIndex = 32;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(12, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 13);
            this.label21.TabIndex = 31;
            this.label21.Text = "Thông Tin";
            // 
            // tb_tenkhuyenmai
            // 
            this.tb_tenkhuyenmai.Location = new System.Drawing.Point(113, 19);
            this.tb_tenkhuyenmai.Name = "tb_tenkhuyenmai";
            this.tb_tenkhuyenmai.Size = new System.Drawing.Size(247, 20);
            this.tb_tenkhuyenmai.TabIndex = 30;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(12, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 13);
            this.label22.TabIndex = 29;
            this.label22.Text = "Chương Trình";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(285, 237);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 45;
            this.bt_cancel.Text = "Cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_dangbai
            // 
            this.bt_dangbai.Location = new System.Drawing.Point(204, 237);
            this.bt_dangbai.Name = "bt_dangbai";
            this.bt_dangbai.Size = new System.Drawing.Size(75, 23);
            this.bt_dangbai.TabIndex = 44;
            this.bt_dangbai.Text = "Đăng bài";
            this.bt_dangbai.UseVisualStyleBackColor = true;
            this.bt_dangbai.Click += new System.EventHandler(this.bt_dangbai_Click);
            // 
            // DangKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lv_dsketqua);
            this.Name = "DangKhuyenMai";
            this.Text = "DangKhuyenMai";
            this.Load += new System.EventHandler(this.DangKhuyenMai_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListView lv_dsketqua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_thoigianstart;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tb_thoigianend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_thongtin;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tb_tenkhuyenmai;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_dangbai;

    }
}