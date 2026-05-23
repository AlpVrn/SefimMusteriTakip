namespace SefimMusteriTakip
{
    partial class Notlar
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
            flpNotlar = new FlowLayoutPanel();
            rtxtNotMetni = new RichTextBox();
            dtpNotEkleme = new DateTimePicker();
            btn_Ekle = new Button();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btn_Geri = new Button();
            btn_Ileri = new Button();
            dtpNotTarihi = new DateTimePicker();
            label2 = new Label();
            SuspendLayout();
            // 
            // flpNotlar
            // 
            flpNotlar.AutoScroll = true;
            flpNotlar.FlowDirection = FlowDirection.TopDown;
            flpNotlar.Location = new Point(12, 12);
            flpNotlar.Name = "flpNotlar";
            flpNotlar.Size = new Size(423, 488);
            flpNotlar.TabIndex = 0;
            // 
            // rtxtNotMetni
            // 
            rtxtNotMetni.Location = new Point(515, 88);
            rtxtNotMetni.Name = "rtxtNotMetni";
            rtxtNotMetni.Size = new Size(389, 138);
            rtxtNotMetni.TabIndex = 1;
            rtxtNotMetni.Text = "";
            // 
            // dtpNotEkleme
            // 
            dtpNotEkleme.Format = DateTimePickerFormat.Short;
            dtpNotEkleme.Location = new Point(594, 238);
            dtpNotEkleme.Name = "dtpNotEkleme";
            dtpNotEkleme.Size = new Size(135, 27);
            dtpNotEkleme.TabIndex = 2;
            // 
            // btn_Ekle
            // 
            btn_Ekle.Location = new Point(810, 239);
            btn_Ekle.Name = "btn_Ekle";
            btn_Ekle.Size = new Size(94, 29);
            btn_Ekle.TabIndex = 3;
            btn_Ekle.Text = "Not Ekle";
            btn_Ekle.UseVisualStyleBackColor = true;
            btn_Ekle.Click += btn_Ekle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(791, 12);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // btn_Geri
            // 
            btn_Geri.Location = new Point(16, 518);
            btn_Geri.Name = "btn_Geri";
            btn_Geri.Size = new Size(94, 29);
            btn_Geri.TabIndex = 5;
            btn_Geri.Text = "Geri";
            btn_Geri.UseVisualStyleBackColor = true;
            btn_Geri.Click += btn_Geri_Click;
            // 
            // btn_Ileri
            // 
            btn_Ileri.Location = new Point(116, 518);
            btn_Ileri.Name = "btn_Ileri";
            btn_Ileri.Size = new Size(94, 29);
            btn_Ileri.TabIndex = 0;
            btn_Ileri.Text = "İleri";
            btn_Ileri.UseVisualStyleBackColor = true;
            btn_Ileri.Click += btn_Ileri_Click;
            // 
            // dtpNotTarihi
            // 
            dtpNotTarihi.Format = DateTimePickerFormat.Short;
            dtpNotTarihi.Location = new Point(216, 520);
            dtpNotTarihi.Name = "dtpNotTarihi";
            dtpNotTarihi.Size = new Size(126, 27);
            dtpNotTarihi.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(515, 238);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 7;
            label2.Text = "Not Tarihi";
            // 
            // Notlar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 563);
            Controls.Add(label2);
            Controls.Add(dtpNotTarihi);
            Controls.Add(btn_Ileri);
            Controls.Add(btn_Geri);
            Controls.Add(label1);
            Controls.Add(btn_Ekle);
            Controls.Add(dtpNotEkleme);
            Controls.Add(rtxtNotMetni);
            Controls.Add(flpNotlar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Notlar";
            Text = "Notlar";
            Load += Notlar_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpNotlar;
        private RichTextBox rtxtNotMetni;
        private DateTimePicker dtpNotEkleme;
        private Button btn_Ekle;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Button btn_Geri;
        private Button btn_Ileri;
        private DateTimePicker dtpNotTarihi;
        private Label label2;
    }
}