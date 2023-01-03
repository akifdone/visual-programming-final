using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyonu
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
            doktorgiris dktgiris = new doktorgiris();
            dktgiris.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastagiris hstgiris = new hastagiris();
            hstgiris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            laboratuvar lb = new laboratuvar();
            lb.Show();
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            kayıt kyt = new kayıt();
            kyt.Show();
            this.Hide();
            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          
            yöneticigiris admin = new yöneticigiris();
            admin.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            hastaKabul hstkabul = new hastaKabul();
            hstkabul.Show();
            this.Hide();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            iletişim contac = new iletişim();
            contac.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
