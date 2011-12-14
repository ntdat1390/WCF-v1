namespace Client
{
    partial class DangThucDon
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
            this.lv_dsketqua = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_dangbai = new System.Windows.Forms.Button();
            this.tb_gia = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_phuongphap = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_nguyenlieu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_monan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lv_menu = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_dsketqua
            // 
            this.lv_dsketqua.Location = new System.Drawing.Point(13, 36);
            this.lv_dsketqua.Name = "lv_dsketqua";
            this.lv_dsketqua.Size = new System.Drawing.Size(229, 127);
            this.lv_dsketqua.TabIndex = 15;
            this.lv_dsketqua.UseCompatibleStateImageBehavior = false;
            this.lv_dsketqua.View = System.Windows.Forms.View.List;
            this.lv_dsketqua.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lv_dsketqua_ItemSelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_cancel);
            this.groupBox1.Controls.Add(this.bt_dangbai);
            this.groupBox1.Controls.Add(this.tb_gia);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tb_phuongphap);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tb_nguyenlieu);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tb_monan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(13, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 156);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(96, 122);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 43;
            this.bt_cancel.Text = "Cancel";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_dangbai
            // 
            this.bt_dangbai.Location = new System.Drawing.Point(15, 122);
            this.bt_dangbai.Name = "bt_dangbai";
            this.bt_dangbai.Size = new System.Drawing.Size(75, 23);
            this.bt_dangbai.TabIndex = 42;
            this.bt_dangbai.Text = "Đăng bài";
            this.bt_dangbai.UseVisualStyleBackColor = true;
            this.bt_dangbai.Click += new System.EventHandler(this.bt_dangbai_Click);
            // 
            // tb_gia
            // 
            this.tb_gia.Location = new System.Drawing.Point(91, 96);
            this.tb_gia.Name = "tb_gia";
            this.tb_gia.Size = new System.Drawing.Size(247, 20);
            this.tb_gia.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(12, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Giá";
            // 
            // tb_phuongphap
            // 
            this.tb_phuongphap.Location = new System.Drawing.Point(91, 70);
            this.tb_phuongphap.Name = "tb_phuongphap";
            this.tb_phuongphap.Size = new System.Drawing.Size(247, 20);
            this.tb_phuongphap.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(12, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Phương pháp";
            // 
            // tb_nguyenlieu
            // 
            this.tb_nguyenlieu.Location = new System.Drawing.Point(91, 44);
            this.tb_nguyenlieu.Name = "tb_nguyenlieu";
            this.tb_nguyenlieu.Size = new System.Drawing.Size(247, 20);
            this.tb_nguyenlieu.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(12, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Nguyên liệu";
            // 
            // tb_monan
            // 
            this.tb_monan.Location = new System.Drawing.Point(91, 19);
            this.tb_monan.Name = "tb_monan";
            this.tb_monan.Size = new System.Drawing.Size(247, 20);
            this.tb_monan.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(12, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Món ăn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Danh sách nhà hàng cà phê";
            // 
            // lv_menu
            // 
            this.lv_menu.Location = new System.Drawing.Point(248, 36);
            this.lv_menu.Name = "lv_menu";
            this.lv_menu.Size = new System.Drawing.Size(294, 127);
            this.lv_menu.TabIndex = 44;
            this.lv_menu.UseCompatibleStateImageBehavior = false;
            this.lv_menu.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Thực đơn";
            // 
            // DangThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 337);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lv_menu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lv_dsketqua);
            this.Name = "DangThucDon";
            this.Text = "DangThucDon";
            this.Load += new System.EventHandler(this.DangThucDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_dsketqua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_dangbai;
        private System.Windows.Forms.TextBox tb_gia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_phuongphap;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_nguyenlieu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_monan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView lv_menu;
        private System.Windows.Forms.Label label2;
    }
}