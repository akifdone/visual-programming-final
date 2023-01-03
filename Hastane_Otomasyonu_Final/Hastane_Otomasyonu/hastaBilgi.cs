using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Hastane_Otomasyonu
{
    public partial class hastaBilgi : Form
    {
        public hastaBilgi()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");

        private void hastaBilgi_Load(object sender, EventArgs e)
        {
            
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();   
                }
                //hasta bilgi güncelleme
                baglanti.Open();
                MySqlCommand güncelle = new MySqlCommand("update hasta set hasta_tel=@tel, hasta_posta=@posta, hasta_parola =@pass, hasta_adres=@adres where hasta_tc = @tc ",baglanti);
                güncelle.Parameters.AddWithValue("@tc",maskedTextBox1.Text);
                güncelle.Parameters.AddWithValue("@tel", maskedTextBox2.Text.ToString());
                güncelle.Parameters.AddWithValue("@posta", textBox5.Text.ToString());
                güncelle.Parameters.AddWithValue("@pass", maskedTextBox5.Text.ToString());
                güncelle.Parameters.AddWithValue("@adres",textBox9.Text.ToString());
                güncelle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Bilgileriniz Başarıyla Güncellenmiştir");

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }
    }
}
