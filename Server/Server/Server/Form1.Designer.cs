﻿namespace Server
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
            this.button1 = new System.Windows.Forms.Button();
            this.btSaveConfig = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbContract1 = new System.Windows.Forms.ComboBox();
            this.cbContract3 = new System.Windows.Forms.ComboBox();
            this.cbContract2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbEndPointAdd3 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.txbEndPointAdd2 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbEndPointAdd1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbShowMEX = new System.Windows.Forms.CheckBox();
            this.txbMessageCarrent = new System.Windows.Forms.TextBox();
            this.txbBaseAddress = new System.Windows.Forms.TextBox();
            this.lbBaseAddress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(607, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "Load Config";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.Location = new System.Drawing.Point(527, 38);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btSaveConfig.TabIndex = 41;
            this.btSaveConfig.Text = "Save Config";
            this.btSaveConfig.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            this.btStop.Enabled = false;
            this.btStop.Location = new System.Drawing.Point(447, 38);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 40;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(368, 38);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 39;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cbContract1);
            this.groupBox1.Controls.Add(this.cbContract3);
            this.groupBox1.Controls.Add(this.cbContract2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbEndPointAdd3);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.txbEndPointAdd2);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txbEndPointAdd1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 108);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "End Point";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(101, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(160, 20);
            this.textBox3.TabIndex = 18;
            this.textBox3.Text = "NetTcpBinding";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(160, 20);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "WSHttpBinding";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "BasicHTTPBinding";
            // 
            // cbContract1
            // 
            this.cbContract1.FormattingEnabled = true;
            this.cbContract1.Items.AddRange(new object[] {
            "IService1",
            "IService2"});
            this.cbContract1.Location = new System.Drawing.Point(320, 20);
            this.cbContract1.Name = "cbContract1";
            this.cbContract1.Size = new System.Drawing.Size(121, 21);
            this.cbContract1.TabIndex = 15;
            this.cbContract1.Text = "IService1";
            // 
            // cbContract3
            // 
            this.cbContract3.FormattingEnabled = true;
            this.cbContract3.Items.AddRange(new object[] {
            "IService1",
            "IService2"});
            this.cbContract3.Location = new System.Drawing.Point(320, 70);
            this.cbContract3.Name = "cbContract3";
            this.cbContract3.Size = new System.Drawing.Size(121, 21);
            this.cbContract3.TabIndex = 14;
            this.cbContract3.Text = "IService1";
            // 
            // cbContract2
            // 
            this.cbContract2.FormattingEnabled = true;
            this.cbContract2.Items.AddRange(new object[] {
            "IService1",
            "IService2"});
            this.cbContract2.Location = new System.Drawing.Point(320, 45);
            this.cbContract2.Name = "cbContract2";
            this.cbContract2.Size = new System.Drawing.Size(121, 21);
            this.cbContract2.TabIndex = 13;
            this.cbContract2.Text = "IService1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(452, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(452, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Address";
            // 
            // txbEndPointAdd3
            // 
            this.txbEndPointAdd3.Location = new System.Drawing.Point(503, 70);
            this.txbEndPointAdd3.Name = "txbEndPointAdd3";
            this.txbEndPointAdd3.Size = new System.Drawing.Size(172, 20);
            this.txbEndPointAdd3.TabIndex = 12;
            this.txbEndPointAdd3.Text = "NetTcpBinding";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(26, 73);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // txbEndPointAdd2
            // 
            this.txbEndPointAdd2.Location = new System.Drawing.Point(503, 44);
            this.txbEndPointAdd2.Name = "txbEndPointAdd2";
            this.txbEndPointAdd2.Size = new System.Drawing.Size(172, 20);
            this.txbEndPointAdd2.TabIndex = 12;
            this.txbEndPointAdd2.Text = "WSHttpBinding";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(26, 47);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "3.";
            // 
            // txbEndPointAdd1
            // 
            this.txbEndPointAdd1.Location = new System.Drawing.Point(503, 19);
            this.txbEndPointAdd1.Name = "txbEndPointAdd1";
            this.txbEndPointAdd1.Size = new System.Drawing.Size(172, 20);
            this.txbEndPointAdd1.TabIndex = 12;
            this.txbEndPointAdd1.Text = "BasicHttpBinding";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "2.";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(26, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Bindding";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "1.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Bindding";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Contract";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contract";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bindding";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Contract";
            // 
            // ckbShowMEX
            // 
            this.ckbShowMEX.AutoSize = true;
            this.ckbShowMEX.Checked = true;
            this.ckbShowMEX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShowMEX.Location = new System.Drawing.Point(11, 55);
            this.ckbShowMEX.Name = "ckbShowMEX";
            this.ckbShowMEX.Size = new System.Drawing.Size(79, 17);
            this.ckbShowMEX.TabIndex = 37;
            this.ckbShowMEX.Text = "Show MEX";
            this.ckbShowMEX.UseVisualStyleBackColor = true;
            // 
            // txbMessageCarrent
            // 
            this.txbMessageCarrent.Location = new System.Drawing.Point(367, 12);
            this.txbMessageCarrent.Name = "txbMessageCarrent";
            this.txbMessageCarrent.ReadOnly = true;
            this.txbMessageCarrent.Size = new System.Drawing.Size(315, 20);
            this.txbMessageCarrent.TabIndex = 36;
            this.txbMessageCarrent.Text = "Message Carrent";
            // 
            // txbBaseAddress
            // 
            this.txbBaseAddress.Location = new System.Drawing.Point(87, 12);
            this.txbBaseAddress.Name = "txbBaseAddress";
            this.txbBaseAddress.Size = new System.Drawing.Size(262, 20);
            this.txbBaseAddress.TabIndex = 35;
            this.txbBaseAddress.Text = "localhost:8000";
            // 
            // lbBaseAddress
            // 
            this.lbBaseAddress.AutoSize = true;
            this.lbBaseAddress.Location = new System.Drawing.Point(8, 20);
            this.lbBaseAddress.Name = "lbBaseAddress";
            this.lbBaseAddress.Size = new System.Drawing.Size(72, 13);
            this.lbBaseAddress.TabIndex = 34;
            this.lbBaseAddress.Text = "Base Address";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 202);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btSaveConfig);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ckbShowMEX);
            this.Controls.Add(this.txbMessageCarrent);
            this.Controls.Add(this.txbBaseAddress);
            this.Controls.Add(this.lbBaseAddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btSaveConfig;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbContract1;
        private System.Windows.Forms.ComboBox cbContract3;
        private System.Windows.Forms.ComboBox cbContract2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbEndPointAdd3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox txbEndPointAdd2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbEndPointAdd1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbShowMEX;
        private System.Windows.Forms.TextBox txbMessageCarrent;
        private System.Windows.Forms.TextBox txbBaseAddress;
        private System.Windows.Forms.Label lbBaseAddress;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
    }
}

