using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SefimMusteriTakip
{
    public partial class MusteriYonetimi : Form
    {

        private string connectionString = @"Server=ALP\ALP;Database=SefimMusteriTakip;User Id=sa;Password=vega1234;Encrypt=false;TrustServerCertificate=true;";

        private void ClearDataText()
        {
            txtbox_SirketAdi.Text = "";
            mtxtbox_Anydesk.Text = "";
            dtimepicker_Sozlesme_Tarihi.Text = "";
            txtbox_SirketSahipAd.Text = "";
            rtxtbox_Adres.Text = "";
            mtxtbox_TelNo.Text = "";
            txtbox_mail.Text = "";
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

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = "";


                    connection.Open();
                    if (rd_btn_Alici.Checked)
                    {
                        query = "SELECT MusteriID, Sirket,Anydesk,FORMAT(SozlesmeTarihi, 'dd/MM/yyyy') AS SozlesmeTarihi,Ad,Adres,Telefon,Email,KayitTarihi, CASE WHEN DATEDIFF(year, SozlesmeTarihi, GETDATE()) >= 1 THEN 'Destek Verilemez' ELSE 'Destek Verilebilir' END AS Destek_Durumu FROM Musteriler WHERE Silindi = 0 AND CariTuru = 'S'";
                    }
                    else
                    {
                        query = "SELECT MusteriID,Sirket,Ad,TCVKN,Adres,Telefon,Email,KayitTarihi FROM Musteriler WHERE CariTuru = 'A' AND Silindi = 0";
                    }


                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "";
                    SqlCommand command = new(query, connection);

                    if (rd_btn_Alici.Checked)
                    {
                        query = "INSERT INTO Musteriler (Ad, Sirket, Email, Telefon, Adres, Anydesk, SozlesmeTarihi) VALUES (@Ad, @Sirket, @Email, @Telefon, @Adres, @Anydesk, @SozlesmeTarihi)";
                        command.Parameters.AddWithValue("@Ad", txtbox_SirketSahipAd.Text);
                        command.Parameters.AddWithValue("@Sirket", txtbox_SirketAdi.Text);
                        command.Parameters.AddWithValue("@Email", txtbox_mail.Text);
                        command.Parameters.AddWithValue("@Telefon", mtxtbox_TelNo.Text);
                        command.Parameters.AddWithValue("@Adres", rtxtbox_Adres.Text);
                        command.Parameters.AddWithValue("@Anydesk", mtxtbox_Anydesk.Text);
                        command.Parameters.AddWithValue("@SozlesmeTarihi", dtimepicker_Sozlesme_Tarihi.Text);
                        command.Parameters.AddWithValue("@CariTuru", "S");
                    }

                    else
                    {
                        query = "INSERT INTO Musteriler (Ad, Sirket, Email, Telefon, Adres, TCVKN, CariTuru) VALUES (@Ad, @Sirket, @Email, @Telefon, @Adres, @TCVKN, @CariTuru)";
                        command.Parameters.AddWithValue("@Ad", txtbox_SirketSahipAd.Text);
                        command.Parameters.AddWithValue("@Sirket", txtbox_SirketAdi.Text);
                        command.Parameters.AddWithValue("@Email", txtbox_mail.Text);
                        command.Parameters.AddWithValue("@Telefon", mtxtbox_TelNo.Text);
                        command.Parameters.AddWithValue("@Adres", rtxtbox_Adres.Text);
                        command.Parameters.AddWithValue("@TCVKN", txt_VKNTC.Text);
                        command.Parameters.AddWithValue("@CariTuru", "A");
                    }
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cari Eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Musteriler SET " +
                    "Ad = @Ad, " +
                    "Sirket = @Sirket, " +
                    "Email = @Email, " +
                    "Telefon = @Telefon, " +
                    "Adres = @Adres, " +
                    "Anydesk = @Anydesk, " +
                    "SozlesmeTarihi = @SozlesmeTarihi " +
                    "WHERE MusteriID = @ID";

                    SqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells[0]?.Value ?? "0");
                    command.Parameters.AddWithValue("@Ad", txtbox_SirketSahipAd.Text);
                    command.Parameters.AddWithValue("@Sirket", txtbox_SirketAdi.Text);
                    command.Parameters.AddWithValue("@Email", txtbox_mail.Text);
                    command.Parameters.AddWithValue("@Telefon", mtxtbox_TelNo.Text);
                    command.Parameters.AddWithValue("@Adres", rtxtbox_Adres.Text);
                    command.Parameters.AddWithValue("@Anydesk", mtxtbox_Anydesk.Text);
                    command.Parameters.AddWithValue("@SozlesmeTarihi", dtimepicker_Sozlesme_Tarihi.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Musteriler SET Silindi = 1 WHERE MusteriID = @ID";
                    SqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
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
            LoadData();
            timer1.Start();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbox_SirketAdi.Text = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? "";
            mtxtbox_Anydesk.Text = dataGridView1.CurrentRow.Cells[2].Value?.ToString() ?? "";
            dtimepicker_Sozlesme_Tarihi.Text = dataGridView1.CurrentRow.Cells[3].Value?.ToString() ?? "";
            txtbox_SirketSahipAd.Text = dataGridView1.CurrentRow.Cells[4].Value?.ToString() ?? "";
            rtxtbox_Adres.Text = dataGridView1.CurrentRow.Cells[5].Value?.ToString() ?? "";
            mtxtbox_TelNo.Text = dataGridView1.CurrentRow.Cells[6].Value?.ToString() ?? "";
            txtbox_mail.Text = dataGridView1.CurrentRow.Cells[7].Value?.ToString() ?? "";
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
            InsertData();
            ClearDataText();
            LoadData();
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            DeleteData();
            ClearDataText();
            LoadData();
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            UpdateData();
            ClearDataText();
            LoadData();
        }

        private void rd_btn_Alici_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_btn_Alici.Checked)
            {
                LoadData();
                mtxtbox_Anydesk.Visible = true;
                dtimepicker_Sozlesme_Tarihi.Visible = true;
                label4.Visible = true;
                label6.Visible = true;
            }
            else
            {
                LoadData();
            }
        }

        private void rd_btn_Satici_CheckedChanged(object sender, EventArgs e)
        {
            mtxtbox_Anydesk.Visible = false;
            dtimepicker_Sozlesme_Tarihi.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
        }
    }
}
