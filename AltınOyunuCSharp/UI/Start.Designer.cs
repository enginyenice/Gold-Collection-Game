namespace AltınOyunuCSharp
{
    partial class Start
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
            this.CordXTxT = new System.Windows.Forms.TextBox();
            this.CordY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PrivateGoldTxT = new System.Windows.Forms.TextBox();
            this.GoldTxT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StartGoldTxT = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CostTxT = new System.Windows.Forms.TextBox();
            this.MoveLenghtTxT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.StartGameBtn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cGoldShowTxT = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oyun Genişliği";
            // 
            // CordXTxT
            // 
            this.CordXTxT.Location = new System.Drawing.Point(117, 29);
            this.CordXTxT.Name = "CordXTxT";
            this.CordXTxT.Size = new System.Drawing.Size(100, 20);
            this.CordXTxT.TabIndex = 1;
            this.CordXTxT.Text = "5";
            this.CordXTxT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CordXTxT_KeyPress);
            // 
            // CordY
            // 
            this.CordY.Location = new System.Drawing.Point(117, 55);
            this.CordY.Name = "CordY";
            this.CordY.Size = new System.Drawing.Size(100, 20);
            this.CordY.TabIndex = 3;
            this.CordY.Text = "5";
            this.CordY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CordYTxT_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Oyun Yüksekliği";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CordY);
            this.groupBox1.Controls.Add(this.CordXTxT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Oyun Boyutu";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.PrivateGoldTxT);
            this.groupBox2.Controls.Add(this.GoldTxT);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(256, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 94);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Altın Oranı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Altın                     %";
            // 
            // PrivateGoldTxT
            // 
            this.PrivateGoldTxT.Location = new System.Drawing.Point(117, 55);
            this.PrivateGoldTxT.Name = "PrivateGoldTxT";
            this.PrivateGoldTxT.Size = new System.Drawing.Size(100, 20);
            this.PrivateGoldTxT.TabIndex = 3;
            this.PrivateGoldTxT.Text = "50";
            this.PrivateGoldTxT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PrivateGoldTxT_KeyPress);
            // 
            // GoldTxT
            // 
            this.GoldTxT.Location = new System.Drawing.Point(117, 29);
            this.GoldTxT.Name = "GoldTxT";
            this.GoldTxT.Size = new System.Drawing.Size(100, 20);
            this.GoldTxT.TabIndex = 1;
            this.GoldTxT.Text = "90";
            this.GoldTxT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GoldTxT_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Gizli Altın              %";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.StartGoldTxT);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(12, 112);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 94);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Başlangıç Altını";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Başlangıç Altını";
            // 
            // StartGoldTxT
            // 
            this.StartGoldTxT.Location = new System.Drawing.Point(117, 29);
            this.StartGoldTxT.Name = "StartGoldTxT";
            this.StartGoldTxT.Size = new System.Drawing.Size(100, 20);
            this.StartGoldTxT.TabIndex = 1;
            this.StartGoldTxT.Text = "200";
            this.StartGoldTxT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartGoldTxT_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.CostTxT);
            this.groupBox4.Controls.Add(this.MoveLenghtTxT);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Location = new System.Drawing.Point(256, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 94);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hamle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Maksimum Adım";
            // 
            // CostTxT
            // 
            this.CostTxT.Location = new System.Drawing.Point(117, 55);
            this.CostTxT.Name = "CostTxT";
            this.CostTxT.Size = new System.Drawing.Size(100, 20);
            this.CostTxT.TabIndex = 3;
            this.CostTxT.Text = "5";
            this.CostTxT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CostTxT_KeyPress);
            // 
            // MoveLenghtTxT
            // 
            this.MoveLenghtTxT.Location = new System.Drawing.Point(117, 29);
            this.MoveLenghtTxT.Name = "MoveLenghtTxT";
            this.MoveLenghtTxT.Size = new System.Drawing.Size(100, 20);
            this.MoveLenghtTxT.TabIndex = 1;
            this.MoveLenghtTxT.Text = "3";
            this.MoveLenghtTxT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MoveLenghtTxT_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Hamle Maliyeti";
            // 
            // StartGameBtn
            // 
            this.StartGameBtn.Location = new System.Drawing.Point(500, 112);
            this.StartGameBtn.Name = "StartGameBtn";
            this.StartGameBtn.Size = new System.Drawing.Size(238, 94);
            this.StartGameBtn.TabIndex = 7;
            this.StartGameBtn.Text = "Oyunu Başlat";
            this.StartGameBtn.UseVisualStyleBackColor = true;
            this.StartGameBtn.Click += new System.EventHandler(this.StartGameBtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.cGoldShowTxT);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Location = new System.Drawing.Point(500, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(238, 94);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Oyuncu Özellikleri";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "C";
            // 
            // cGoldShowTxT
            // 
            this.cGoldShowTxT.Location = new System.Drawing.Point(117, 29);
            this.cGoldShowTxT.Name = "cGoldShowTxT";
            this.cGoldShowTxT.Size = new System.Drawing.Size(100, 20);
            this.cGoldShowTxT.TabIndex = 1;
            this.cGoldShowTxT.Text = "2";
            this.cGoldShowTxT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cGoldShowTxT_KeyPress);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 250);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.StartGameBtn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Start";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CordXTxT;
        private System.Windows.Forms.TextBox CordY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PrivateGoldTxT;
        private System.Windows.Forms.TextBox GoldTxT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StartGoldTxT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CostTxT;
        private System.Windows.Forms.TextBox MoveLenghtTxT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button StartGameBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cGoldShowTxT;
    }
}

