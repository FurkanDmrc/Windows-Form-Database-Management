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
    public partial class MusteriFormu : Form
    {
        public MusteriFormu()
        {
            InitializeComponent();
        }

        MusteriContext context = new MusteriContext();

        public void musterilistele()
        {
            dgwmusteri.DataSource = context.Musteriler.ToList();

        }

        public void temizle()
        {
            lblmusteriıd.Text = txtad.Text = txtsoyad.Text = txttelefon.Text = txteposta.Text = txtyas.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblmusteriıd.Text);
            var musterisil = context.Musteriler.FirstOrDefault(y => y.MusteriId == id);
            context.Musteriler.Remove(musterisil);
            context.SaveChanges();
            MessageBox.Show("Müşteri Silindi");
            musterilistele();
            temizle();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
            yoneticiPaneli.Show();
            this.Hide();
        }

        private void btnmekle_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.MusteriAdı = txtad.Text;
            musteri.MusteriSoyad = txtsoyad.Text;
            musteri.MusteriTelefon = int.Parse(txttelefon.Text);
            musteri.MusteriEposta = txteposta.Text;
            musteri.MusteriYas = int.Parse((txtyas.Text));

            context.Musteriler.Add(musteri);
            context.SaveChanges();

            MessageBox.Show("Müşteri Kaydedildi");
            musterilistele();
            temizle();
        }

        private void MusteriFormu_Load(object sender, EventArgs e)
        {
            musterilistele();
        }

        private void btnmguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblmusteriıd.Text);
            var musteri = context.Musteriler.FirstOrDefault(x => x.MusteriId == id);
            musteri.MusteriAdı = txtad.Text;
            musteri.MusteriSoyad = txtsoyad.Text;
            musteri.MusteriTelefon = int.Parse(txttelefon.Text);
            musteri.MusteriEposta = txteposta.Text;
            musteri.MusteriYas = int.Parse(txtyas.Text);

            context.SaveChanges();
            MessageBox.Show("Müşteri Bilgisi Güncellendi");
            musterilistele();

        }

        private void dgwmusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblmusteriıd.Text = dgwmusteri.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dgwmusteri.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dgwmusteri.Rows[e.RowIndex].Cells[2].Value.ToString();
            txttelefon.Text = dgwmusteri.Rows[e.RowIndex].Cells[3].Value.ToString();
            txteposta.Text = dgwmusteri.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtyas.Text = dgwmusteri.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void txtadara_TextChanged(object sender, EventArgs e)
        {
            if (txtadara.Text != string.Empty)
            {
                var musteri_ara = context.Musteriler.Where(ara => ara.MusteriAdı.Contains(txtadara.Text));

                dgwmusteri.DataSource = musteri_ara.ToList();
            }
            else
            {
                dgwmusteri.DataSource = context.Musteriler.ToList();
            }
        }
    }
}
