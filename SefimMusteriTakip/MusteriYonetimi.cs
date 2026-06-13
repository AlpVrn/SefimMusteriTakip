using Microsoft.Data.SqlClient;
using SefimMusteriTakip.DBCodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SefimMusteriTakip
{
    public partial class MusteriYonetimi : Form
    {
        private void ClearDataText()
        {
            txtbox_SirketAdi.Text = "";
            mtxtbox_Anydesk.Text = "";
            dtimepicker_Sozlesme_Tarihi.Text = "";
            txtbox_SirketSahipAd.Text = "";
            rtxtbox_Adres.Text = "";
            mtxtbox_TelNo.Text = "";
            txtbox_mail.Text = "";
            txt_VKNTC.Text = "";
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Destek_Durumu" && e.Value != null)
            {
                string durum = e.Value.ToString();

                if (durum == "Destek Verilebilir")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (durum == "Destek Verilemez")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }
        }


        private object LoadData()
        {
            using (var context = new DBCodes.SefimDbContext())
            {
                object liste = null;
                try
                {

                    if (rd_btn_Alici.Checked)
                    {
                        liste = context.Musteriler
                        .Where(m => m.Silindi == false && m.CariTuru == "A")
                        .Select(m => new
                        {
                            m.MusteriID,
                            m.Sirket,
                            Yetkili = m.Ad,
                            m.Anydesk,
                            Sozlesme_Tarihi = m.SozlesmeTarihi.HasValue ? m.SozlesmeTarihi.Value.ToString("dd/MM/yyyy") : "",
                            m.Adres,
                            TC_VKN = m.TCVKN,
                            m.Telefon,
                            m.Email,
                            Kayit_Tarihi = m.KayitTarihi,
                            Destek_Durumu = m.SozlesmeTarihi.HasValue && (DateTime.Now - m.SozlesmeTarihi.Value).TotalDays >= 365 ? "Destek Verilemez" : "Destek Verilebilir"
                        }).ToList();

                    }
                    else if (rd_btn_Satici.Checked)
                    {
                        liste = context.Musteriler
                        .Where(m => m.Silindi == false && m.CariTuru == "S")
                        .Select(m => new
                        {
                            m.MusteriID,
                            m.Sirket,
                            Yetkili = m.Ad,
                            TC_VKN = m.TCVKN,
                            m.Adres,
                            m.Telefon,
                            m.Email,
                            Kayit_Tarihi = m.KayitTarihi
                        }).ToList();
                    }
                    return liste;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }

        }



        private object SearchData()
        {
            using (var context = new DBCodes.SefimDbContext())
            {
                object liste = null;
                try
                {

                    if (rd_btn_Alici.Checked)
                    {
                        liste = context.Musteriler
                        .Where(m => m.Silindi == false && m.CariTuru == "A" && m.Sirket.Contains(txt_SirketAra.Text))
                        .Select(m => new
                        {
                            m.MusteriID,
                            m.Sirket,
                            Yetkili = m.Ad,
                            m.Anydesk,
                            Sozlesme_Tarihi = m.SozlesmeTarihi.HasValue ? m.SozlesmeTarihi.Value.ToString("dd/MM/yyyy") : "",
                            m.Adres,
                            TC_VKN = m.TCVKN,
                            m.Telefon,
                            m.Email,
                            Kayit_Tarihi = m.KayitTarihi,
                            Destek_Durumu = m.SozlesmeTarihi.HasValue && (DateTime.Now - m.SozlesmeTarihi.Value).TotalDays >= 365 ? "Destek Verilemez" : "Destek Verilebilir"
                        }).ToList();

                    }
                    else if (rd_btn_Satici.Checked)
                    {
                        liste = context.Musteriler
                        .Where(m => m.Silindi == false && m.CariTuru == "S" && m.Sirket.Contains(txt_SirketAra.Text))
                        .Select(m => new
                        {
                            m.MusteriID,
                            m.Sirket,
                            Yetkili = m.Ad,
                            TC_VKN = m.TCVKN,
                            m.Adres,
                            m.Telefon,
                            m.Email,
                            Kayit_Tarihi = m.KayitTarihi
                        }).ToList();
                    }
                    return liste;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }

        }


        public void InsertData(string Ad, string Sirket, string Email, string Telefon, string Adres, string Anydesk, DateTime SozlesmeTarihi, string TCVKN)
        {
            try
            {
                using (var context = new DBCodes.SefimDbContext())
                {
                    Musteri Musteriler = null;
                    if (rd_btn_Alici.Checked)
                    {
                        Musteriler = new Musteri
                        {
                            Ad = Ad,
                            Sirket = Sirket,
                            Email = Email,
                            Telefon = Telefon,
                            Adres = Adres,
                            Anydesk = Anydesk,
                            SozlesmeTarihi = SozlesmeTarihi,
                            CariTuru = "A",
                            TCVKN = TCVKN
                        };
                    }
                    else if (rd_btn_Satici.Checked)
                    {
                        Musteriler = new Musteri
                        {
                            Ad = Ad,
                            Sirket = Sirket,
                            Email = Email,
                            Telefon = Telefon,
                            Adres = Adres,
                            CariTuru = "S",
                            TCVKN = TCVKN
                        };
                    }

                    context.Musteriler.Add(Musteriler);
                    context.SaveChanges();
                    MessageBox.Show("Cari eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string hataDetayi = ex.Message;
                if (ex.InnerException != null)
                {
                    hataDetayi += "\n\nDetay: " + ex.InnerException.Message;
                }

                MessageBox.Show("Veritabanı hatası: " + hataDetayi);
            }

        }



        private void UpdateData(string Ad, string Sirket, string Email, string Telefon, string Adres, string Anydesk, DateTime Sozlesme_Tarihi, string TCVKN)
        {
            try
            {
                using (var context = new DBCodes.SefimDbContext())
                {
                    int SeciliMusteriID = Convert.ToInt16(dataGridView1.CurrentRow.Cells["MusteriID"].Value);
                    var secilenID = context.Musteriler.FirstOrDefault(m => m.MusteriID == SeciliMusteriID);
                    Musteri Musteriler = secilenID;

                    if (rd_btn_Alici.Checked)
                    {
                        Musteriler.Ad = Ad;
                        Musteriler.Sirket = Sirket;
                        Musteriler.Email = Email;
                        Musteriler.Telefon = Telefon;
                        Musteriler.Adres = Adres;
                        Musteriler.Anydesk = Anydesk;
                        Musteriler.SozlesmeTarihi = Sozlesme_Tarihi;
                        Musteriler.TCVKN = TCVKN;
                    }

                    else if (rd_btn_Satici.Checked)
                    {
                        Musteriler.Ad = Ad;
                        Musteriler.Sirket = Sirket;
                        Musteriler.Email = Email;
                        Musteriler.Telefon = Telefon;
                        Musteriler.Adres = Adres;
                        Musteriler.TCVKN = TCVKN;
                    }

                    context.SaveChanges();
                    MessageBox.Show("Müşteri Güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void DeleteData()
        {
            try
            {
                using (var context = new DBCodes.SefimDbContext())
                {
                    int SeciliMusteriID = Convert.ToInt16(dataGridView1.CurrentRow.Cells["MusteriID"].Value);
                    var secilenID = context.Musteriler.FirstOrDefault(m => m.MusteriID == SeciliMusteriID);

                    Musteri Musteriler = secilenID;
                    Musteriler.Silindi = true;
                    MessageBox.Show("Müşteri Silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public MusteriYonetimi()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void MusteriYonetimi_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadData();
            timer1.Start();
            dataGridView1.Columns["MusteriID"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rd_btn_Alici.Checked)
            {
                txtbox_SirketAdi.Text = dataGridView1.CurrentRow.Cells["Sirket"].Value?.ToString() ?? "";
                mtxtbox_Anydesk.Text = dataGridView1.CurrentRow.Cells["Anydesk"].Value?.ToString() ?? "";
                dtimepicker_Sozlesme_Tarihi.Text = dataGridView1.CurrentRow.Cells["Sozlesme_Tarihi"].Value?.ToString() ?? "";
                txtbox_SirketSahipAd.Text = dataGridView1.CurrentRow.Cells["Yetkili"].Value?.ToString() ?? "";
                rtxtbox_Adres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value?.ToString() ?? "";
                mtxtbox_TelNo.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value?.ToString() ?? "";
                txtbox_mail.Text = dataGridView1.CurrentRow.Cells["Email"].Value?.ToString() ?? "";
                txt_VKNTC.Text = dataGridView1.CurrentRow.Cells["TC_VKN"].Value?.ToString() ?? "";
            }
            else
            {
                txtbox_SirketAdi.Text = dataGridView1.CurrentRow.Cells["Sirket"].Value?.ToString() ?? "";
                txtbox_SirketSahipAd.Text = dataGridView1.CurrentRow.Cells["Yetkili"].Value?.ToString() ?? "";
                rtxtbox_Adres.Text = dataGridView1.CurrentRow.Cells["Adres"].Value?.ToString() ?? "";
                mtxtbox_TelNo.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value?.ToString() ?? "";
                txtbox_mail.Text = dataGridView1.CurrentRow.Cells["Email"].Value?.ToString() ?? "";
                txt_VKNTC.Text = dataGridView1.CurrentRow.Cells["TC_VKN"].Value?.ToString() ?? "";
            }
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            ClearDataText();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            InsertData(txtbox_SirketSahipAd.Text, txtbox_SirketAdi.Text, txtbox_mail.Text, mtxtbox_TelNo.Text, rtxtbox_Adres.Text, mtxtbox_Anydesk.Text, dtimepicker_Sozlesme_Tarihi.Value, txt_VKNTC.Text);
            ClearDataText();
            dataGridView1.DataSource = LoadData();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            DeleteData();
            ClearDataText();
            dataGridView1.DataSource = LoadData();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            UpdateData(txtbox_SirketSahipAd.Text, txtbox_SirketAdi.Text, txtbox_mail.Text, mtxtbox_TelNo.Text, rtxtbox_Adres.Text, mtxtbox_Anydesk.Text, dtimepicker_Sozlesme_Tarihi.Value, txt_VKNTC.Text);
            dataGridView1.DataSource = LoadData();
            ClearDataText();
        }

        private void rd_btn_Alici_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadData();
            mtxtbox_Anydesk.Visible = true;
            dtimepicker_Sozlesme_Tarihi.Visible = true;
            label4.Visible = true;
            label6.Visible = true;
        }

        private void rd_btn_Satici_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadData();
            mtxtbox_Anydesk.Visible = false;
            dtimepicker_Sozlesme_Tarihi.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
        }

        private void txt_SirketAra_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SearchData();
        }
    }
}
