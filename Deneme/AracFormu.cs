using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme
{
    public partial class AracFormu : Form
    {
        public AracFormu()
        {
            InitializeComponent();
        }

        ProjeEntities ProjeEF = new ProjeEntities();

        public void araclistele()
        {
            dgwaraclar.DataSource = ProjeEF.Araclar.ToList();

        }

        public void temizle()
        {
            txtmarka.Text = txtkasa.Text = txtucret.Text = txtyakit.Text = txtyil.Text = txtmodel.Text = txtvites.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Araclar araclar = new Araclar();
            araclar.ArabaMarkası = txtmarka.Text;
            araclar.ArabaModeli = txtmodel.Text;
            araclar.ArabaVites = txtvites.Text;
            araclar.ArabaYılı = txtyil.Text;
            araclar.ArabaYakıt = txtyakit.Text;
            araclar.ArabaKasa = txtkasa.Text;
            araclar.ArabaUcret = int.Parse(txtucret.Text);

            ProjeEF.Araclar.Add(araclar);
            ProjeEF.SaveChanges();
            MessageBox.Show("Yeni Araç Kaydı Yapıldı");
            araclistele();
            temizle();
            
        }

        private void AracFormu_Load(object sender, EventArgs e)
        {
            araclistele();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            if (txtara.Text != string.Empty)
            {
                var araba_ara = ProjeEF.Araclar.Where(ara => ara.ArabaMarkası.Contains(txtara.Text));
                dgwaraclar.DataSource = araba_ara.ToList();
            }
            else
            {
                dgwaraclar.DataSource = ProjeEF.Araclar.ToList();
            }
        }

        private void dgwaraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblıd.Text = dgwaraclar.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtmarka.Text = dgwaraclar.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmodel.Text = dgwaraclar.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtvites.Text = dgwaraclar.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtyil.Text = dgwaraclar.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtyakit.Text = dgwaraclar.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtkasa.Text = dgwaraclar.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtucret.Text = dgwaraclar.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int araba_ıd = int.Parse(lblıd.Text);

            var arabasil = ProjeEF.Araclar.First(cs => cs.ArabaId == araba_ıd);

            ProjeEF.Araclar.Remove(arabasil);
            ProjeEF.SaveChanges();
            MessageBox.Show("Araç Bilgisi Silindi");
            araclistele();
            temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int araba_ıd = int.Parse(lblıd.Text);

            var guncelle = ProjeEF.Araclar.First(ag => ag.ArabaId == araba_ıd);

            guncelle.ArabaMarkası = txtmarka.Text;
            guncelle.ArabaUcret = int.Parse(txtucret.Text);
            guncelle.ArabaVites = txtvites.Text;
            guncelle.ArabaYakıt = txtyakit.Text;
            guncelle.ArabaKasa = txtkasa.Text;
            guncelle.ArabaModeli = txtmodel.Text;

            ProjeEF.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
            araclistele();
            temizle();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
             yoneticiPaneli.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
