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
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AracFormu aracFormu = new AracFormu();
            aracFormu.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             MusteriFormu  musteriFormu = new MusteriFormu(); 
            musteriFormu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MusteriContext context = new MusteriContext())
            {
                context.Database.Create();
                MessageBox.Show("Database Oluşturuldu");
            }
        }
    }
}
