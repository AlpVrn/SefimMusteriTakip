using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SefimMusteriTakip
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MusteriYonetimi MusteriYonetimi = new();
            MusteriYonetimi.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RaporForm raporForm = new();
            raporForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Notlar notlar = new();
            notlar.Show();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.KullaniciAdi))
            {
                GirisEkran girisEkran = new GirisEkran();
                girisEkran.ShowDialog();
            }
            else
            {
                label2.Text = "Giriş Yapılan : " + Properties.Settings.Default.KullaniciAdi;
            }
        }
    }
}
