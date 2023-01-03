using MySql.Data.MySqlClient;
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
    public partial class iletişim : Form
    {
        public iletişim()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                   
                baglanti.Open();
                MySqlCommand iletisim = new MySqlCommand("insert into iletisim(iletisim_ad, iletisim_soyad, iltisim_sikayet, iletisim_bilgileri) values(@ad,@soyad,@sikayet,@bilgiler)", baglanti);
                iletisim.Parameters.AddWithValue("@ad", textBox1.Text);
                iletisim.Parameters.AddWithValue("@soyad", textBox2.Text);
                iletisim.Parameters.AddWithValue("@bilgiler", textBox3.Text);
                iletisim.Parameters.AddWithValue("@sikayet", textBox4.Text);
                iletisim.ExecuteNonQuery();
                MessageBox.Show("Talebiniz Alındı");
                baglanti.Close();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void iletişim_Load(object sender, EventArgs e)
        {

        }
    }
}
