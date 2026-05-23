using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SefimMusteriTakip
{
    public partial class Notlar : Form
    {
        private string connectionString = @"Server=ALP\ALP;Database=SefimMusteriTakip;User Id=sa;Password=vega1234;Encrypt=false;TrustServerCertificate=true;";



        private void ClearTextData()
        {
            rtxtNotMetni.Text = "";
            dtpNotEkleme.Value = DateTime.Now;
        }

        private void InsertNote(string notMetni, DateTime notTarihi)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO FrmNotlar (NotMetni, NotTarihi, YapildiMi) VALUES (@NotMetni, @NotTarihi, 0)";
                    SqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@NotMetni", notMetni);
                    command.Parameters.AddWithValue("@NotTarihi", notTarihi);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not ekleme hatası: " + ex.Message);
            }
        }




        private void UpdateNoteStatus(int id, bool durum)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE FrmNotlar SET YapildiMi = @Durum WHERE NotID = @ID";
                    SqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@Durum", durum);
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        private void LoadNotesAsCards(DateTime secilenTarih)
        {
            try
            {
                flpNotlar.Controls.Clear();

                flpNotlar.FlowDirection = FlowDirection.TopDown;
                flpNotlar.WrapContents = false;
                flpNotlar.AutoScroll = true;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT NotID, YapildiMi, NotMetni FROM FrmNotlar WHERE NotTarihi = @Tarih";
                    SqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@Tarih", secilenTarih);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int notID = reader.GetInt32(0);
                            bool yapildiMi = reader.GetBoolean(1);
                            string notMetni = reader.GetString(2);

                            Panel card = new Panel();
                            card.Width = 385;
                            card.MinimumSize = new Size(385, 55);
                            card.BorderStyle = BorderStyle.FixedSingle;
                            card.Margin = new Padding(10, 0, 0, 10);
                            card.BackColor = yapildiMi ? Color.LightGreen : Color.MistyRose;

                            card.Padding = new Padding(12, 12, 12, 12);

                            card.AutoSize = true;
                            card.AutoSizeMode = AutoSizeMode.GrowAndShrink;

                            CheckBox chk = new CheckBox();
                            chk.Text = "";
                            chk.Checked = yapildiMi;
                            chk.Size = new Size(20, 20);
                            chk.Margin = new Padding(0);

                            chk.Dock = DockStyle.Left;

                            Label lbl = new Label();
                            lbl.Text = notMetni;
                            lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                            lbl.ForeColor = Color.Black;
                            lbl.Margin = new Padding(0);

                            lbl.Dock = DockStyle.Fill;

                            lbl.Padding = new Padding(10, 0, 0, 0);

                            lbl.AutoSize = true;
                            lbl.MaximumSize = new Size(330, 0);

                            chk.CheckedChanged += (s, e) =>
                            {
                                bool yeniDurum = chk.Checked;
                                UpdateNoteStatus(notID, yeniDurum);
                                card.BackColor = yeniDurum ? Color.LightGreen : Color.MistyRose;
                            };

                            card.Controls.Add(lbl);
                            card.Controls.Add(chk);

                            flpNotlar.Controls.Add(card);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not kartları yüklenirken hata: " + ex.Message);
            }
        }

        public Notlar()
        {
            InitializeComponent();
        }

        private void Notlar_Load_1(object sender, EventArgs e)
        {
            LoadNotesAsCards(dtpNotTarihi.Value.Date);
            timer1.Start();
        }

        private void btn_Geri_Click(object sender, EventArgs e)
        {
            DateTime yeniTarih = dtpNotTarihi.Value.AddDays(-1);
            dtpNotTarihi.Value = yeniTarih;
            LoadNotesAsCards(dtpNotTarihi.Value.Date);
        }

        private void btn_Ileri_Click(object sender, EventArgs e)
        {
            DateTime yeniTarih = dtpNotTarihi.Value.AddDays(+1);
            dtpNotTarihi.Value = yeniTarih;
            LoadNotesAsCards(dtpNotTarihi.Value.Date);
        }

        private void btn_Ekle_Click(object sender, EventArgs e)
        {
            InsertNote(rtxtNotMetni.Text, dtpNotEkleme.Value.Date);
            LoadNotesAsCards(dtpNotTarihi.Value.Date);
            ClearTextData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}