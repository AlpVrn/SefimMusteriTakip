using System.Data;
using Microsoft.Data.SqlClient;

namespace SefimMusteriTakip
{

    public partial class Form1 : Form
    {
        private string connectionString = @"Server=ALP\ALP;Database=SefimMusteriTakip;User Id=sa;Password=vega1234;Encrypt=false;TrustServerCertificate=true;";
        private int selectedMusteriID = 0;

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    var durumValue = dataGridView1.Rows[e.RowIndex].Cells["Destek_Durumu"].Value;

            //    if (durumValue != null)
            //    {
            //        string durum = durumValue.ToString();

            //        if (durum == "Destek Verilebilir")
            //        {
            //            e.CellStyle.BackColor = Color.LightGreen;
            //        }
            //        else if (durum == "Destek Verilemez")
            //        {
            //            e.CellStyle.BackColor = Color.MistyRose;
            //        }
            //    }
            //}
        }

        public object LoadData()
        {
            try
            {
                using (var context = new SefimDbContext())
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

        public object SearchData()
        {
            using (var context = new SefimDbContext()) {
                
                
                return null;
            }
        }

        //private void SearchData()
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            string query = "SELECT MusteriID, Sirket,Anydesk,FORMAT(SozlesmeTarihi, 'dd/MM/yyyy') AS SozlesmeTarihi,Ad,Adres,Telefon, CASE WHEN DATEDIFF(year, SozlesmeTarihi, GETDATE()) >= 1 THEN 'Destek Verilemez' ELSE 'Destek Verilebilir' END AS Destek_Durumu FROM Musteriler WHERE Sirket LIKE @AramaMetni";

        //            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
        //            adapter.SelectCommand.Parameters.AddWithValue("@AramaMetni", "%" + txtbox_Ara.Text + "%");
        //            DataTable dataTable = new();
        //            adapter.Fill(dataTable);

        //            dataGridView1.DataSource = dataTable;
        //            connection.Close();
        //            dataGridView1.Columns[0].Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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
            MessageBox.Show("Test");
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
                MessageBox.Show("Test");
                //SearchData();
            }
        }

        private void btn_Destek_Click(object sender, EventArgs e)
        {
            InsertData();
            Clear();
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
