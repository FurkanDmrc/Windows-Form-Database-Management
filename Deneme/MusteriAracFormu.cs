using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme
{
    public partial class MusteriAracFormu : Form
    {
        public MusteriAracFormu()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-V4PRQL1\\SQLEXPRESS;Initial Catalog=Proje;Integrated Security=True");

        public void araclistele()
        {
            baglan.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select *from Araclar", baglan);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgwaraclar.DataSource = dt;
            baglan.Close();

        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void MusteriAracFormu_Load(object sender, EventArgs e)
        {
            araclistele();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            araclistele();
        }

        private void btnkirala_Click(object sender, EventArgs e)
        {
            if (txtmarka.Text != null)
            {
                MessageBox.Show("Kiraladığınız Aracın Özellikleri:" + txtmarka.Text + " " + txtmodel.Text + " " + txtvites.Text + " " + txtyil.Text + " " + txtyakit.Text + " " + txtkasa.Text + " " + txtucret.Text + "TL");
            }
            else
            {
                MessageBox.Show("Lütfen Bir Araç Seçin");
            }

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtmarka.Text = txtkasa.Text = txtucret.Text = txtyakit.Text = txtyil.Text = txtmodel.Text = txtvites.Text = "";
        }

        private void dgwaraclar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblaracıd.Text = dgwaraclar.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtmarka.Text = dgwaraclar.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmodel.Text = dgwaraclar.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtvites.Text = dgwaraclar.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtyil.Text = dgwaraclar.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtyakit.Text = dgwaraclar.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtkasa.Text = dgwaraclar.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtucret.Text = dgwaraclar.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select *from Araclar Where ArabaMarkası like '%" + txtara.Text + "%' ", baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgwaraclar.DataSource = dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                baglan.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisFormu girisFormu = new GirisFormu();
            girisFormu.Show();
            this.Hide();
        }
    }
}
