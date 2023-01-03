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
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Hastane_Otomasyonu
{
    public partial class doktorbilgi : Form
    {
        public doktorbilgi()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                if(maskedTextBox2.Text != " " && textBox5.Text != " " && maskedTextBox5.Text != "" && textBox9.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand güncelle = new MySqlCommand("update doktorlar set doktor_cep=@cep, doktor_eposta=@eposta, sifre=@sifre, doktor_adres=@adres where kullanici_adi=@ad",baglanti);
                    güncelle.Parameters.AddWithValue("ad", maskedTextBox3.Text);
                    güncelle.Parameters.AddWithValue("cep", maskedTextBox2.Text.ToString());
                    güncelle.Parameters.AddWithValue("eposta", textBox5.Text.ToString());
                    güncelle.Parameters.AddWithValue("sifre", maskedTextBox5.Text.ToString());
                    güncelle.Parameters.AddWithValue("adres", textBox9.Text.ToString());
                    güncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Bilgileriniz Güncellenmiştir");
                }
                else
                {
                    MessageBox.Show("Lütfen Gerekli Alanları Ekisksiz Doldurunuz");
                }
                
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void doktorbilgi_Load(object sender, EventArgs e)
        {

        }
    }
}
