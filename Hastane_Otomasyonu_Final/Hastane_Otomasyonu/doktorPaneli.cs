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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hastane_Otomasyonu
{
    public partial class doktorPaneli : Form
    {
        public doktorPaneli()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");

        private void button7_Click(object sender, EventArgs e)
        {
            
            
            try
            {

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                    MySqlCommand sorgulama = new MySqlCommand("select * from doktorlar where doktor_id=@id", baglanti);
                    sorgulama.Parameters.AddWithValue("@id", textBox4.Text);
                    MySqlDataReader oku = sorgulama.ExecuteReader();
                    if(oku.Read())
                    {
                            doktorbilgi bilgi = new doktorbilgi();
                            bilgi.Show();
                            bilgi.maskedTextBox3.Text = oku["kullanici_adi"].ToString();
                            bilgi.maskedTextBox1.Text = oku["doktor_tc"].ToString();
                            bilgi.textBox1.Text = oku["doktor_adi_soyadi"].ToString();
                            bilgi.textBox6.Text = oku["doktor_cinsiyet"].ToString();
                            bilgi.textBox7.Text = oku["doktor_kan"].ToString();
                            bilgi.textBox8.Text = oku["doktor_dtarih"].ToString();
                            bilgi.maskedTextBox2.Text = oku["doktor_cep"].ToString();
                            bilgi.textBox5.Text = oku["doktor_eposta"].ToString();
                            bilgi.maskedTextBox4.Text = oku["sifre"].ToString();
                            bilgi.textBox5.Text = oku["doktor_adres"].ToString();


                    }
                    
                    baglanti.Close();
             

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata!! " + " " + hata);

            }
        }

        public static MySqlDataAdapter da;
        public static DataTable dt;
       
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                bekleyenHasta hasta = new bekleyenHasta();
                 hasta.Show();
               
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand bekleyen_list = new MySqlCommand("select bekleyenHasta.bekleyen_id,klinkler.klinik_adi,doktorlar.doktor_adi_soyadi,hasta.hasta_ad,hasta.hasta_soyad,hasta.hasta_id from " +
                    "bekleyenHasta INNER JOIN klinkler on bekleyenHasta.bekleyen_klinik_id = klinkler.klinik_id  " +
                    "INNER JOIN doktorlar on bekleyenHasta.bekleyen_doktor_id = doktorlar.doktor_id " +
                    "INNER JOIN hasta on bekleyenHasta.bekleyen_hasta_id = hasta.hasta_id where bekleyenHasta.bekleyen_doktor_id=@id", baglanti);
                bekleyen_list.Parameters.AddWithValue("@id",textBox4.Text);
                da = new MySqlDataAdapter(bekleyen_list);
                dt = new DataTable();
                da.Fill(dt);
                hasta.dataGridView1.DataSource = dt;
                baglanti.Close();
            }

            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                randevuGörüntüle randevu = new randevuGörüntüle();
                randevu.Show();
                randevu.button3.Visible = false;
                randevu.textBox1.Text = textBox4.Text;

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand görüntüle = new MySqlCommand("Select randevular.randevu_id,klinkler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hasta.hasta_tc,hasta.hasta_ad,hasta.hasta_soyad,doktorlar.doktor_adi_soyadi,klinkler.klinik_id " +
                    "from randevular INNER JOIN hasta on randevular.randevu_hasta_id=hasta.hasta_id " +
                    "INNER JOIN klinkler ON randevular.randevu_klinik_id=klinkler.klinik_id " +
                    "INNER JOIN doktorlar ON randevular.randevu_doktor_id = doktorlar.doktor_id where doktorlar.doktor_id=@id", baglanti);
                görüntüle.Parameters.AddWithValue("@id", textBox4.Text);
                da = new MySqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                randevu.dataGridView1.DataSource = dt;
                baglanti.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void doktorPaneli_Load(object sender, EventArgs e)
        {

        }

        private void doktorPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            anasayfa ana = new anasayfa();
            ana.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doktorTahlilsonuc tahlil = new doktorTahlilsonuc(); 
            tahlil.Show();
            //sonuçlar tablosu bağlantı
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from labsonuclar where sonuc_doktor_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", textBox4.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                tahlil.dataGridView1.DataSource = dt;
                baglanti.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                randevuGörüntüle randevu = new randevuGörüntüle();
                randevu.Show();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand görüntüle = new MySqlCommand("Select randevular.randevu_id,klinkler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hasta.hasta_tc,hasta.hasta_ad,hasta.hasta_soyad,doktorlar.doktor_adi_soyadi from " +
                    "randevular INNER JOIN hasta on randevular.randevu_hasta_id=hasta.hasta_id INNER JOIN klinkler ON randevular.randevu_klinik_id=klinkler.klinik_id INNER JOIN doktorlar ON randevular.randevu_doktor_id = doktorlar.doktor_id where doktorlar.doktor_id=@id", baglanti);
                görüntüle.Parameters.AddWithValue("@id",textBox4.Text);
                da = new MySqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                randevu.dataGridView1.DataSource = dt;
                baglanti.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("hata" + " " + ex);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            acilGörüntüle acil = new acilGörüntüle();
            randevuMuayne muayene = new randevuMuayne();
            acil.Show();
            
        }

    }
}
