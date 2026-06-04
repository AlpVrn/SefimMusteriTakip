using Microsoft.Data.SqlClient;
using SefimMusteriTakip.DBCodes;
using System.Data;

namespace SefimMusteriTakip
{

    public partial class Form1 : Form
    {
        private string connectionString = @"Server=ALP\ALP;Database=SefimMusteriTakip;User Id=sa;Password=vega1234;Encrypt=false;TrustServerCertificate=true;";
        private int selectedMusteriID = 0;

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var durumValue = dataGridView1.Rows[e.RowIndex].Cells["Destek_Durumu"].Value;

                if (durumValue != null)
                {
                    string durum = durumValue.ToString();

                    if (durum == "Destek Verilebilir")
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                    }
                    else if (durum == "Destek Verilemez")
                    {
                        e.CellStyle.BackColor = Color.MistyRose;
                    }
                }
            }
        }

        public object LoadData()
        {
            try
            {
                using (var context = new DBCodes.SefimDbContext())
                {
                    var liste = context.Musteriler
                        .Where(m => m.Silindi == false && m.CariTuru == "S")
                        .Select(m => new {
                            m.MusteriID,
                            m.Sirket,
                            m.Anydesk,
                            SozlesmeTarihi = m.SozlesmeTarihi.HasValue ? m.SozlesmeTarihi.Value.ToString("dd/MM/yyyy") : "",
                            m.Ad,
                            m.Adres,
                            m.Telefon,
                            Destek_Durumu = m.SozlesmeTarihi.HasValue && (DateTime.Now - m.SozlesmeTarihi.Value).TotalDays >= 365 ? "Destek Verilemez" : "Destek Verilebilir"
                        })
                        .ToList();
                    return liste;
                }
            }
            catch (Exception ex)
            {
                return MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public object SearchData(string Sirket)
        {
            try
            {
                using (var context = new DBCodes.SefimDbContext())
                {
                    string arananSirket = Sirket;

                    var liste = context.Musteriler
                            .Where(m => m.Silindi == false && m.CariTuru == "S" && m.Sirket.Contains(arananSirket))
                            .Select(m => new {
                                m.MusteriID,
                                m.Sirket,
                                m.Anydesk,
                                SozlesmeTarihi = m.SozlesmeTarihi.HasValue ? m.SozlesmeTarihi.Value.ToString("dd/MM/yyyy") : "",
                                m.Ad,
                                m.Adres,
                                m.Telefon,
                                Destek_Durumu = m.SozlesmeTarihi.HasValue && (DateTime.Now - m.SozlesmeTarihi.Value).TotalDays >= 365 ? "Destek Verilemez" : "Destek Verilebilir"
                            })
                            .ToList();
                    return liste;
                }

            }
            catch (Exception ex)
            {
                return MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void VeriyiYapistir(int MusteriID,string Aciklama, DateTime OlusturmaTarihi,string DestekVerenKisi)
        {
            try
            {
                using (var context = new DBCodes.SefimDbContext())
                {

                    VerilenDestek destek = new VerilenDestek
                    {

                        MusteriID = MusteriID,
                        Aciklama = Aciklama,
                        OlusturmaTarihi = OlusturmaTarihi,
                        DestekVerenKisi = DestekVerenKisi,
                    };

                    context.VerilenDestekler.Add(destek);
                    context.SaveChanges();
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

        private void InsertData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Verilen_Destek (MusteriID, Aciklama, DestekVerenKisi) VALUES (@MusteriID, @Aciklama, @DestekVerenKisi)";

                    SqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@MusteriID", selectedMusteriID);
                    command.Parameters.AddWithValue("@Aciklama", rtxtbox_VerilenDestek.Text);
                    command.Parameters.AddWithValue("@DestekVerenKisi", "yapılcak");         //buraya bak

                    command.ExecuteNonQuery();
                    MessageBox.Show("Destek kaydı başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    rtxtbox_VerilenDestek.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txtbox_Sirket.Text = "";
            txtbox_Anydesk.Text = "";
            txtBox_Ad.Text = "";
            txtbox_telNo.Text = "";
            rtxtbox_VerilenDestek.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Müsteri Hizmet";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedMusteriID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value ?? 0);
            txtbox_Sirket.Text = dataGridView1.CurrentRow.Cells[1].Value?.ToString() ?? "";
            txtbox_Anydesk.Text = dataGridView1.CurrentRow.Cells[2].Value?.ToString() ?? "";
            txtBox_Ad.Text = dataGridView1.CurrentRow.Cells[4].Value?.ToString() ?? "";
            txtbox_telNo.Text = dataGridView1.CurrentRow.Cells[6].Value?.ToString() ?? "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SearchData();
            dataGridView1.DataSource = SearchData(txtbox_Ara.Text);
        }

        private void txtbox_Ara_TextChanged(object sender, EventArgs e)
        {
            if (txtbox_Ara.Text == "")
            {
                LoadData();
                dataGridView1.DataSource = LoadData();
            }
            else
            {
                dataGridView1.DataSource = SearchData(txtbox_Ara.Text);
            }
        }

        private void btn_Destek_Click(object sender, EventArgs e)
        {
            if (txtbox_Sirket.Text == "")
            {
                MessageBox.Show("Lütfen Müşteri Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Clear();
            }
            else {
                VeriyiYapistir(selectedMusteriID, rtxtbox_VerilenDestek.Text, DateTime.Now, Properties.Settings.Default.KullaniciAdi);
                Clear();
                MessageBox.Show("Destek Kaydı Eklenmiştir", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            LoadData();
            dataGridView1.DataSource = LoadData();
            dataGridView1.Columns["MusteriID"].Visible = false;
        }
    }
}
