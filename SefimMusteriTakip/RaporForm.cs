using Microsoft.Data.SqlClient;
using SefimMusteriTakip.DBCodes;
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

        private object LoadData()
        {
            using (var context = new DBCodes.SefimDbContext())
            {
                object liste = null;

                liste = context.VerilenDestekler
                .Where(m => m.OlusturmaTarihi.Date == dateTimePicker1.Value.Date)
                .Select(m => new {
                m.Musterisi.Sirket,
                m.Aciklama,
                m.DestekVerenKisi
                }).ToList();
                return liste;
            }
        }

        public RaporForm()
        {
            InitializeComponent();
        }

        private void RaporForm_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dataGridView1.DataSource = LoadData();
            timer1.Start();
            this.Text = "Günlük Rapor";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime yeniTarih = dateTimePicker1.Value.AddDays(-1);
            dateTimePicker1.Value = yeniTarih;
            dataGridView1.DataSource = LoadData();
        }

        private void btn_ileri_Click(object sender, EventArgs e)
        {
            DateTime yeniTarih = dateTimePicker1.Value.AddDays(+1);
            dateTimePicker1.Value = yeniTarih;
            dataGridView1.DataSource = LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadData();
        }
    }
}
