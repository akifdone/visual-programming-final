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
    public partial class laboratuvar : Form
    {
        public laboratuvar()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");


        public static MySqlDataAdapter da;
        public static DataTable dt;
        private void laboratuvar_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select tahliller.tahlil_id,testler.test_adi,doktorlar.doktor_adi_soyadi,hasta.hasta_ad,hasta.hasta_soyad from tahliller INNER JOIN testler on tahliller.tahlil_test_id = testler.test_id " +
                    "INNER JOIN doktorlar on tahliller.tahlil_doktor_id = doktorlar.doktor_id " +
                    "INNER JOIN hasta on tahliller.tahlil_hasta_id=hasta.hasta_id " , baglanti);
               //MySqlCommand komut = new MySqlCommand("select tahliller.tahlil_id,testler.test_adi,doktorlar.doktor_adi_soyadi, from tahliller INNER JOIN testler on tahliller.tahlil_test_id = testler.test_id INNER JOIN doktorlar on tahliller.tahlil_doktor_id = doktorlar.doktor_id", baglanti);
               da = new MySqlDataAdapter(komut);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);            
            }
           

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                
                
                
                // tahlil daha önce kontrol edilip edilmediği için
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from labsonuclar where sonuc_tahlil_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["tahlil_id"].Value.ToString());
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    if ( oku["kontrol"].ToString() == "1")
                    {
                        MessageBox.Show("Test Yapıldı Doktorun Kontrol Etmesini Bekleyiniz ");
                    }
                    
                }
                else
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells["tahlil_id"].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells["test_adi"].Value.ToString();
                    string ad = dataGridView1.CurrentRow.Cells["hasta_ad"].Value.ToString();
                    string soyad = dataGridView1.CurrentRow.Cells["hasta_soyad"].Value.ToString();
                    textBox5.Text = ad + " " + soyad;

                    // tes id veritabından çekmek için
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand komut1 = new MySqlCommand("select * from testler where test_adi=@test", baglanti);
                    komut1.Parameters.AddWithValue("@test", textBox3.Text);
                    MySqlDataReader oku1 = komut1.ExecuteReader();
                    if (oku1.Read())
                    {
                        textBox4.Text = oku1[0].ToString(); // test id
                    }
                    baglanti.Close();

                }
                baglanti.Close();  
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox4.Text != "")
            {

                try
                {

                    string doktor_id = "0";

                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand sorgu = new MySqlCommand("select * from tahliller where tahlil_id = @id", baglanti);
                    sorgu.Parameters.AddWithValue("@id", textBox1.Text);
                    MySqlDataReader oku = sorgu.ExecuteReader();
                    if (oku.Read())
                    {
                        doktor_id = oku[1].ToString();
                    }
                    baglanti.Close();


                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("insert into labsonuclar(sonuc_tahlil_id,sonuc_doktor_id,sonuc_test_adi,sonuc_hasta_adi,sonuc_aciklama,sonuc_tarih,kontrol) " +
                        "values(@tid,@did,@tadi,@hadi,@aciklama,@tarih,@kontrol)", baglanti);
                    komut.Parameters.AddWithValue("@tid", textBox1.Text);
                    komut.Parameters.AddWithValue("@tadi", textBox3.Text);
                    komut.Parameters.AddWithValue("@hadi", textBox5.Text);
                    komut.Parameters.AddWithValue("@did", doktor_id);
                    komut.Parameters.AddWithValue("@aciklama", textBox2.Text);
                    komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Text.ToString());
                    komut.Parameters.AddWithValue("@kontrol", "1");
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Sonuç Gönderildi");
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }
                
            
            }
        }

        private void laboratuvar_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa ana = new anasayfa();
            ana.Show();
        }
    }
}
