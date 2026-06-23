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
    public partial class Notlar : Form
    {
        
        private void ClearTextData()
        {
            rtxtNotMetni.Text = "";
            dtpNotEkleme.Value = DateTime.Now;
        }



        private void InsertNote(string notMetni, DateTime notTarihi)
        {
            try
            {
                using (var context = new DBCodes.SefimDbContext())
                {

                    var newNote = new FrmNotlar
                    {
                        NotMetni = notMetni,
                        NotTarihi = notTarihi,
                        YapildiMi = false
                    };
                    context.FrmNotlars.Add(newNote);
                    context.SaveChanges();
                    MessageBox.Show("Not Eklendi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not ekleme hatası: " + ex.Message);
            }

        }


        private void UpdateNoteStatus(int notID, bool yapildiMi)
        {
            try
            {
                using (var context = new DBCodes.SefimDbContext())
                {
                    int SeciliNot = notID;
                    var secilenID = context.FrmNotlars.FirstOrDefault(m => m.NotID == SeciliNot);
                    DBCodes.FrmNotlar Nots = secilenID;
                    
                    Nots.YapildiMi = yapildiMi;

                    context.SaveChanges();
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

                using (var context = new DBCodes.SefimDbContext())
                {
                    var liste = context.FrmNotlars.Where(n => n.NotTarihi == secilenTarih).ToList();


                        foreach (var not in liste)
                        {
                            int notID = not.NotID ?? 0;
                            bool yapildiMi = not.YapildiMi ?? false;
                            string notMetni = not.NotMetni ?? "Not Yüklenemedi!";

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