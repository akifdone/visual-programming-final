using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class yönetici : Form
    {
        public yönetici()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            yöneticiContact contact = new yöneticiContact();
            contact.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            yöneticiBilgi bilgi = new yöneticiBilgi();
            bilgi.Show();
        }

        private void yönetici_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            yöneticiHasta hasta = new yöneticiHasta();
            hasta.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yöneticiDoktor doktor = new yöneticiDoktor();
            doktor.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yöneticiKlinik klinik = new yöneticiKlinik();
            klinik.Show();
        }

        private void yönetici_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
        }
    }
}
