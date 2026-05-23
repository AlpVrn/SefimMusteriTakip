namespace SefimMusteriTakip
{
    partial class MusteriYonetimi
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
            components = new System.ComponentModel.Container();
            txtbox_SirketSahipAd = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtbox_SirketAdi = new TextBox();
            label3 = new Label();
            txtbox_mail = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            mtxtbox_TelNo = new MaskedTextBox();
            mtxtbox_Anydesk = new MaskedTextBox();
            dtimepicker_Sozlesme_Tarihi = new DateTimePicker();
            rtxtbox_Adres = new RichTextBox();
            dataGridView1 = new DataGridView();
            btn_Ekle = new Button();
            btn_Sil = new Button();
            btn_Guncelle = new Button();
            btn_Temizle = new Button();
            label8 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtbox_SirketSahipAd
            // 
            txtbox_SirketSahipAd.Location = new Point(166, 49);
            txtbox_SirketSahipAd.Name = "txtbox_SirketSahipAd";
            txtbox_SirketSahipAd.Size = new Size(191, 27);
            txtbox_SirketSahipAd.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 55);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 1;
            label1.Text = "Şirket Sahibi Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(417, 52);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 3;
            label2.Text = "Şirket Adı";
            // 
            // txtbox_SirketAdi
            // 
            txtbox_SirketAdi.Location = new Point(496, 49);
            txtbox_SirketAdi.Name = "txtbox_SirketAdi";
            txtbox_SirketAdi.Size = new Size(192, 27);
            txtbox_SirketAdi.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(417, 85);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 5;
            label3.Text = "e-Mail";
            // 
            // txtbox_mail
            // 
            txtbox_mail.Location = new Point(498, 82);
            txtbox_mail.Name = "txtbox_mail";
            txtbox_mail.Size = new Size(190, 27);
            txtbox_mail.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(733, 56);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 7;
            label4.Text = "Anydesk";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(733, 85);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 9;
            label5.Text = "Telefon";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(31, 82);
            label6.Name = "label6";
            label6.Size = new Size(111, 20);
            label6.TabIndex = 11;
            label6.Text = "Sözleşme Tarihi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 134);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 13;
            label7.Text = "Adres Tarifi";
            // 
            // mtxtbox_TelNo
            // 
            mtxtbox_TelNo.Location = new Point(805, 82);
            mtxtbox_TelNo.Mask = "(999) 000-0000";
            mtxtbox_TelNo.Name = "mtxtbox_TelNo";
            mtxtbox_TelNo.Size = new Size(116, 27);
            mtxtbox_TelNo.TabIndex = 14;
            // 
            // mtxtbox_Anydesk
            // 
            mtxtbox_Anydesk.Location = new Point(805, 49);
            mtxtbox_Anydesk.Mask = "0 000 000 000";
            mtxtbox_Anydesk.Name = "mtxtbox_Anydesk";
            mtxtbox_Anydesk.Size = new Size(116, 27);
            mtxtbox_Anydesk.TabIndex = 15;
            // 
            // dtimepicker_Sozlesme_Tarihi
            // 
            dtimepicker_Sozlesme_Tarihi.Checked = false;
            dtimepicker_Sozlesme_Tarihi.Format = DateTimePickerFormat.Short;
            dtimepicker_Sozlesme_Tarihi.Location = new Point(166, 82);
            dtimepicker_Sozlesme_Tarihi.Name = "dtimepicker_Sozlesme_Tarihi";
            dtimepicker_Sozlesme_Tarihi.Size = new Size(191, 27);
            dtimepicker_Sozlesme_Tarihi.TabIndex = 16;
            dtimepicker_Sozlesme_Tarihi.Value = new DateTime(2026, 5, 7, 14, 52, 45, 0);
            // 
            // rtxtbox_Adres
            // 
            rtxtbox_Adres.Location = new Point(166, 134);
            rtxtbox_Adres.Name = "rtxtbox_Adres";
            rtxtbox_Adres.Size = new Size(213, 80);
            rtxtbox_Adres.TabIndex = 17;
            rtxtbox_Adres.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 291);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1148, 249);
            dataGridView1.TabIndex = 18;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btn_Ekle
            // 
            btn_Ekle.Location = new Point(497, 185);
            btn_Ekle.Name = "btn_Ekle";
            btn_Ekle.Size = new Size(94, 29);
            btn_Ekle.TabIndex = 19;
            btn_Ekle.Text = "Ekle";
            btn_Ekle.UseVisualStyleBackColor = true;
            btn_Ekle.Click += btn_Ekle_Click;
            // 
            // btn_Sil
            // 
            btn_Sil.Location = new Point(599, 185);
            btn_Sil.Name = "btn_Sil";
            btn_Sil.Size = new Size(94, 29);
            btn_Sil.TabIndex = 20;
            btn_Sil.Text = "Sil";
            btn_Sil.UseVisualStyleBackColor = true;
            btn_Sil.Click += btn_Sil_Click;
            // 
            // btn_Guncelle
            // 
            btn_Guncelle.Location = new Point(701, 185);
            btn_Guncelle.Name = "btn_Guncelle";
            btn_Guncelle.Size = new Size(94, 29);
            btn_Guncelle.TabIndex = 21;
            btn_Guncelle.Text = "Güncelle";
            btn_Guncelle.UseVisualStyleBackColor = true;
            btn_Guncelle.Click += btn_Guncelle_Click;
            // 
            // btn_Temizle
            // 
            btn_Temizle.Location = new Point(805, 185);
            btn_Temizle.Name = "btn_Temizle";
            btn_Temizle.Size = new Size(94, 29);
            btn_Temizle.TabIndex = 22;
            btn_Temizle.Text = "Temizle";
            btn_Temizle.UseVisualStyleBackColor = true;
            btn_Temizle.Click += btn_Temizle_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(980, 9);
            label8.Name = "label8";
            label8.Size = new Size(50, 20);
            label8.TabIndex = 23;
            label8.Text = "label8";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // MusteriYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1138, 542);
            Controls.Add(label8);
            Controls.Add(btn_Temizle);
            Controls.Add(btn_Guncelle);
            Controls.Add(btn_Sil);
            Controls.Add(btn_Ekle);
            Controls.Add(dataGridView1);
            Controls.Add(rtxtbox_Adres);
            Controls.Add(dtimepicker_Sozlesme_Tarihi);
            Controls.Add(mtxtbox_Anydesk);
            Controls.Add(mtxtbox_TelNo);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtbox_mail);
            Controls.Add(label2);
            Controls.Add(txtbox_SirketAdi);
            Controls.Add(label1);
            Controls.Add(txtbox_SirketSahipAd);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MusteriYonetimi";
            Text = "MusteriYonetimi";
            Load += MusteriYonetimi_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbox_SirketSahipAd;
        private Label label1;
        private Label label2;
        private TextBox txtbox_SirketAdi;
        private Label label3;
        private TextBox txtbox_mail;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private MaskedTextBox mtxtbox_TelNo;
        private MaskedTextBox mtxtbox_Anydesk;
        private DateTimePicker dtimepicker_Sozlesme_Tarihi;
        private RichTextBox rtxtbox_Adres;
        private DataGridView dataGridView1;
        private Button btn_Ekle;
        private Button btn_Sil;
        private Button btn_Guncelle;
        private Button btn_Temizle;
        private Label label8;
        private System.Windows.Forms.Timer timer1;
    }
}