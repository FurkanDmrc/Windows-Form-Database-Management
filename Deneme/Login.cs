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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-V4PRQL1\\SQLEXPRESS;Initial Catalog=Proje;Integrated Security=True");

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtkullanici_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand login = new SqlCommand("Select *from Users Where Username=@username and Userpassword=@userpassword", con);
            login.Parameters.AddWithValue("@username", txtkullanici.Text);
            login.Parameters.AddWithValue("@userpassword", txtsifre.Text);

            SqlDataReader dataReader = login.ExecuteReader();
            if (txtkullanici.Text != "" && txtsifre.Text != "")
            {
                if (dataReader.Read())
                {
                    MessageBox.Show("Giriş Yapıldı!");
                    YoneticiPaneli yoneticiPaneli = new YoneticiPaneli();
                    yoneticiPaneli.Show();
                    this.Hide();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Girilen Değerleri Kontrol Edin");
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
