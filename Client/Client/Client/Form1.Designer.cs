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
            this.tb_KetNoiTuDong = new System.Windows.Forms.TextBox();
            this.bt_TuDongKetNoi = new System.Windows.Forms.Button();
            this.bt_Start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ds_KetNoi = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_KetNoiTuDong
            // 
            this.tb_KetNoiTuDong.Location = new System.Drawing.Point(351, 8);
            this.tb_KetNoiTuDong.Name = "tb_KetNoiTuDong";
            this.tb_KetNoiTuDong.ReadOnly = true;
            this.tb_KetNoiTuDong.Size = new System.Drawing.Size(100, 20);
            this.tb_KetNoiTuDong.TabIndex = 26;
            // 
            // bt_TuDongKetNoi
            // 
            this.bt_TuDongKetNoi.Location = new System.Drawing.Point(253, 6);
            this.bt_TuDongKetNoi.Name = "bt_TuDongKetNoi";
            this.bt_TuDongKetNoi.Size = new System.Drawing.Size(92, 23);
            this.bt_TuDongKetNoi.TabIndex = 25;
            this.bt_TuDongKetNoi.Text = "Asynchronous";
            this.bt_TuDongKetNoi.UseVisualStyleBackColor = true;
            // 
            // bt_Start
            // 
            this.bt_Start.Location = new System.Drawing.Point(198, 6);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(49, 23);
            this.bt_Start.TabIndex = 24;
            this.bt_Start.Text = "Start";
            this.bt_Start.UseVisualStyleBackColor = true;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Kiểu kết nối";
            // 
            // ds_KetNoi
            // 
            this.ds_KetNoi.FormattingEnabled = true;
            this.ds_KetNoi.Items.AddRange(new object[] {
            "BasicHttpBinding",
            "WSHttpBinding",
            "NetTcpBinding"});
            this.ds_KetNoi.Location = new System.Drawing.Point(81, 6);
            this.ds_KetNoi.Name = "ds_KetNoi";
            this.ds_KetNoi.Size = new System.Drawing.Size(110, 21);
            this.ds_KetNoi.TabIndex = 22;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 33);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(447, 96);
            this.textBox1.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 134);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tb_KetNoiTuDong);
            this.Controls.Add(this.bt_TuDongKetNoi);
            this.Controls.Add(this.bt_Start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ds_KetNoi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_KetNoiTuDong;
        private System.Windows.Forms.Button bt_TuDongKetNoi;
        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ds_KetNoi;
        private System.Windows.Forms.TextBox textBox1;


    }
}

