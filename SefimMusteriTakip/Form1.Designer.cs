namespace SefimMusteriTakip
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            txtbox_Ara = new TextBox();
            btn_Ara = new Button();
            txtbox_Sirket = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtbox_Anydesk = new TextBox();
            label3 = new Label();
            rtxtbox_VerilenDestek = new RichTextBox();
            label4 = new Label();
            btn_Destek = new Button();
            label5 = new Label();
            txtbox_telNo = new TextBox();
            label6 = new Label();
            txtBox_Ad = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            btn_Temizle = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(799, 188);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // txtbox_Ara
            // 
            txtbox_Ara.Location = new Point(255, 23);
            txtbox_Ara.Name = "txtbox_Ara";
            txtbox_Ara.Size = new Size(183, 27);
            txtbox_Ara.TabIndex = 1;
            txtbox_Ara.TextChanged += txtbox_Ara_TextChanged;
            // 
            // btn_Ara
            // 
            btn_Ara.Location = new Point(462, 22);
            btn_Ara.Name = "btn_Ara";
            btn_Ara.Size = new Size(94, 29);
            btn_Ara.TabIndex = 2;
            btn_Ara.Text = "Ara";
            btn_Ara.UseVisualStyleBackColor = true;
            btn_Ara.Click += button1_Click;
            // 
            // txtbox_Sirket
            // 
            txtbox_Sirket.Location = new Point(170, 269);
            txtbox_Sirket.Name = "txtbox_Sirket";
            txtbox_Sirket.ReadOnly = true;
            txtbox_Sirket.Size = new Size(200, 27);
            txtbox_Sirket.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 272);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 4;
            label1.Text = "Şirket";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(405, 275);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 6;
            label2.Text = "Anydesk";
            // 
            // txtbox_Anydesk
            // 
            txtbox_Anydesk.Location = new Point(502, 272);
            txtbox_Anydesk.Name = "txtbox_Anydesk";
            txtbox_Anydesk.ReadOnly = true;
            txtbox_Anydesk.Size = new Size(200, 27);
            txtbox_Anydesk.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(669, 9);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 7;
            label3.Text = "label3";
            // 
            // rtxtbox_VerilenDestek
            // 
            rtxtbox_VerilenDestek.Location = new Point(121, 358);
            rtxtbox_VerilenDestek.Name = "rtxtbox_VerilenDestek";
            rtxtbox_VerilenDestek.Size = new Size(585, 150);
            rtxtbox_VerilenDestek.TabIndex = 8;
            rtxtbox_VerilenDestek.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 428);
            label4.Name = "label4";
            label4.Size = new Size(103, 20);
            label4.TabIndex = 9;
            label4.Text = "Verilen Destek";
            // 
            // btn_Destek
            // 
            btn_Destek.Location = new Point(593, 514);
            btn_Destek.Name = "btn_Destek";
            btn_Destek.Size = new Size(109, 37);
            btn_Destek.TabIndex = 10;
            btn_Destek.Text = "Destek Verildi";
            btn_Destek.UseVisualStyleBackColor = true;
            btn_Destek.Click += btn_Destek_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(91, 305);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 12;
            label5.Text = "Telefon No";
            // 
            // txtbox_telNo
            // 
            txtbox_telNo.Location = new Point(170, 302);
            txtbox_telNo.Name = "txtbox_telNo";
            txtbox_telNo.ReadOnly = true;
            txtbox_telNo.Size = new Size(200, 27);
            txtbox_telNo.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(405, 308);
            label6.Name = "label6";
            label6.Size = new Size(91, 20);
            label6.TabIndex = 14;
            label6.Text = "Şirket Sahibi";
            // 
            // txtBox_Ad
            // 
            txtBox_Ad.Location = new Point(502, 305);
            txtBox_Ad.Name = "txtBox_Ad";
            txtBox_Ad.ReadOnly = true;
            txtBox_Ad.Size = new Size(200, 27);
            txtBox_Ad.TabIndex = 13;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // btn_Temizle
            // 
            btn_Temizle.Location = new Point(715, 308);
            btn_Temizle.Name = "btn_Temizle";
            btn_Temizle.Size = new Size(68, 29);
            btn_Temizle.TabIndex = 15;
            btn_Temizle.Text = "Temizle";
            btn_Temizle.UseVisualStyleBackColor = true;
            btn_Temizle.Click += btn_Temizle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 582);
            Controls.Add(btn_Temizle);
            Controls.Add(label6);
            Controls.Add(txtBox_Ad);
            Controls.Add(label5);
            Controls.Add(txtbox_telNo);
            Controls.Add(btn_Destek);
            Controls.Add(label4);
            Controls.Add(rtxtbox_VerilenDestek);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtbox_Anydesk);
            Controls.Add(label1);
            Controls.Add(txtbox_Sirket);
            Controls.Add(btn_Ara);
            Controls.Add(txtbox_Ara);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtbox_Ara;
        private Button btn_Ara;
        private TextBox txtbox_Sirket;
        private Label label1;
        private Label label2;
        private TextBox txtbox_Anydesk;
        private Label label3;
        private RichTextBox rtxtbox_VerilenDestek;
        private Label label4;
        private Button btn_Destek;
        private Label label5;
        private TextBox txtbox_telNo;
        private Label label6;
        private TextBox txtBox_Ad;
        private System.Windows.Forms.Timer timer1;
        private Button btn_Temizle;
    }
}
