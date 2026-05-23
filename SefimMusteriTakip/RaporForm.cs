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
    public partial class RaporForm : Form
    {

        private string connectionString = @"Server=ALP\ALP;Database=SefimMusteriTakip;User Id=sa;Password=vega1234;Encrypt=false;TrustServerCertificate=true;";

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT MusteriID, Sirket, Anydesk, FORMAT(SozlesmeTarihi, 'dd/MM/yyyy') AS SozlesmeTarihi, Ad, Adres, Telefon, Email, FORMAT(KayitTarihi, 'dd/MM/yyyy') AS KayitTarihi " +
                                   "FROM Musteriler WHERE CAST(KayitTarihi AS DATE) = @Tarih";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.Date);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    if (dataGridView1.Columns.Count > 0)
                        dataGridView1.Columns[0].Visible = false;
                    
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public RaporForm()
        {
            InitializeComponent();
        }

        private void RaporForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            timer1.Start();
            this.Text = "Günlük Rapor";
            LoadData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime yeniTarih = dateTimePicker1.Value.AddDays(-1);
            dateTimePicker1.Value = yeniTarih;
            LoadData();
        }

        private void btn_ileri_Click(object sender, EventArgs e)
        {
            DateTime yeniTarih = dateTimePicker1.Value.AddDays(+1);
            dateTimePicker1.Value = yeniTarih;
            LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
