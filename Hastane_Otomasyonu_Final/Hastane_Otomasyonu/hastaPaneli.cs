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
    public partial class hastaPaneli : Form
    {
        public hastaPaneli()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");

        private void button3_Click(object sender, EventArgs e)
        {
            randevuAl randevu = new randevuAl();
            randevu.textBox1.Text = label2.Text;
            randevu.Show();
            
           

        }

        private void hastaPaneli_Load(object sender, EventArgs e)
        {
       
        }
       
        public static MySqlDataAdapter da;
        public static DataTable dt;
        public static MySqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                randevuGörüntüle randevu = new randevuGörüntüle();
                randevu.Show();
                randevu.button2.Visible = false;
                randevu.button1.Visible = false;
                randevu.textBox1.Text = label2.Text.ToString();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand görüntüle = new MySqlCommand("Select randevular.randevu_id,klinkler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hasta.hasta_tc,hasta.hasta_ad,hasta.hasta_soyad,doktorlar.doktor_adi_soyadi from " +
                    "randevular INNER JOIN hasta on randevular.randevu_hasta_id=hasta.hasta_id INNER JOIN klinkler ON randevular.randevu_klinik_id=klinkler.klinik_id INNER JOIN doktorlar ON randevular.randevu_doktor_id = doktorlar.doktor_id where hasta.hasta_id=@id", baglanti);
                görüntüle.Parameters.AddWithValue("@id", label2.Text);
                da = new MySqlDataAdapter(görüntüle);
                dt = new DataTable();
                da.Fill(dt);
                randevu.dataGridView1.DataSource = dt;
                görüntüle.ExecuteNonQuery();
                baglanti.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("hata" + " " + ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            hastaTahlil tahlil = new hastaTahlil();
            tahlil.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            hastaBilgi bilgi = new hastaBilgi();
            bilgi.Show();

            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                hastaPaneli hasta = new hastaPaneli();
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select*from hasta where hasta_id=@id", baglanti);                
                komut.Parameters.AddWithValue("id", label2.Text);
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    bilgi.maskedTextBox1.Text = oku[1].ToString(); // tc
                    bilgi.textBox1.Text = oku[2].ToString();       //ad
                    bilgi.textBox2.Text = oku[3].ToString(); //soyad
                    bilgi.textBox6.Text = oku[4].ToString(); //cinsiyet
                    bilgi.textBox7.Text = oku[5].ToString(); //kan grubu
                    bilgi.textBox8.Text = oku[6].ToString(); //dogum yeri
                    bilgi.maskedTextBox3.Text = oku[7].ToString(); //tarih
                    bilgi.textBox3.Text = oku[8].ToString(); // baba adı
                    bilgi.textBox4.Text = oku[9].ToString(); // ana adı
                    bilgi.maskedTextBox4.Text = oku[12].ToString(); // eski parola


                }
                baglanti.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void hastaPaneli_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
        }
    }
}
