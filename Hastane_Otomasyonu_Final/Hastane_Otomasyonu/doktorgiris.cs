using MySql.Data.MySqlClient;
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

namespace Hastane_Otomasyonu
{
    public partial class doktorgiris : Form
    {
        public doktorgiris()
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
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand cmd =  new MySqlCommand ("Select * from  doktorlar where  kullanici_adi = @kullanici AND sifre = @pass", baglanti);
                    cmd.Parameters.AddWithValue("@kullanici", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        doktorPaneli dktpanel = new doktorPaneli();
                        dktpanel.textBox2.Text = textBox1.Text.ToString();
                        dktpanel.textBox4.Text = dr["doktor_id"].ToString();
                        dktpanel.textBox1.Text = dr["doktor_adi_soyadi"].ToString();
                        dktpanel.textBox3.Text = dr["doktor_tc"].ToString();
                        dktpanel.Show();
                        this.Hide();
                        baglanti.Close();
                    }
                    else
                    {
                        MessageBox.Show("hatalı giriş yaptınız");
                    }
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show("hatameydan geldi" + " " + hata);
            }
        }

        private void doktorgiris_Load(object sender, EventArgs e)
        {
            textBox1.Text = "akif";
            textBox2.Text = "12345";
        }

        private void doktorgiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa ana = new anasayfa();
            ana.Show();

        }
    }
}
