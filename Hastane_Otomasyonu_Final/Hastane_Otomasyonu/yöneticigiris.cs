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
using System.Data.Sql;
using MySql.Data.MySqlClient;

namespace Hastane_Otomasyonu
{
    public partial class yöneticigiris : Form
    {
        public yöneticigiris()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (textBox1.Text == "" || textBox2.Text == "")
                {

                    MessageBox.Show("Lütfen Gerekli Bilgileri Giriniz");

                }
                else
                {
                    baglanti.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * from  yönetici where  kullanici_adi = @kullanici AND kullanici_sifre = @pass",baglanti);
                    cmd.Parameters.AddWithValue("@kullanici", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                       
                        yönetici admin = new yönetici();
                        admin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("hatalı giriş yaptınız");
                    }
                    baglanti.Close();
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void yöneticigiris_Load(object sender, EventArgs e)
        {
            textBox1.Text = "admin";
            textBox2.Text = "1234";
        }

        private void yöneticigiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
        }
    }
}
