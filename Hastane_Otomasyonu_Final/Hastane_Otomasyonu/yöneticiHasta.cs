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
    public partial class yöneticiHasta : Form
    {
        public yöneticiHasta()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void yöneticiHasta_Load(object sender, EventArgs e)
        {
            if(baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select * from hasta",baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                MySqlCommand c = new MySqlCommand("select * from hasta where hasta_id=@id", baglanti);
                c.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MySqlDataReader oku = c.ExecuteReader();
                while (oku.Read())
                {
                    maskedTextBox1.Text = oku[1].ToString();
                    textBox1.Text = oku[2].ToString();
                    textBox2.Text = oku[3].ToString();
                    textBox6.Text = oku[4].ToString();
                    textBox7.Text = oku[5].ToString();
                    textBox8.Text = oku[6].ToString();
                    maskedTextBox3.Text = oku[7].ToString();
                    textBox3.Text = oku[8].ToString();
                    textBox4.Text = oku[9].ToString();
                    maskedTextBox2.Text = oku[10].ToString();
                    textBox5.Text = oku[0].ToString();
                    textBox9.Text = oku[13].ToString();

                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("hata!! lütfen daha sonra tekrar deneyin");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox5.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand guncelle = new MySqlCommand("update hasta set hasta_tc=@tc,hasta_ad=@ad,hasta_soyad=@soyad,hasta_cinsiyeti=@cinsiyet,hasta_kan=@kan,hasta_dogumYeri=@dogumy,Hasta_dogumTarihi=@tarih,Hasta_babaAdi=@baba,hasta_anaAdi=@anne,hasta_tel=@cep,hasta_adres=@adres where hasta_id=@id", baglanti);
                    guncelle.Parameters.AddWithValue("@id", textBox5.Text);
                    guncelle.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    guncelle.Parameters.AddWithValue("@ad", textBox1.Text);
                    guncelle.Parameters.AddWithValue("@soyad", textBox2.Text);
                    guncelle.Parameters.AddWithValue("@cinsiyet", textBox6.Text);
                    guncelle.Parameters.AddWithValue("@kan", textBox7.Text);
                    guncelle.Parameters.AddWithValue("@dogumy", textBox8.Text);
                    guncelle.Parameters.AddWithValue("@tarih", maskedTextBox3.Text);
                    guncelle.Parameters.AddWithValue("@baba", textBox3.Text);
                    guncelle.Parameters.AddWithValue("@anne", textBox4.Text);
                    guncelle.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                    guncelle.Parameters.AddWithValue("@adres", textBox9.Text);
                    guncelle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Hasta Başarıyla Güncellendi");
                }
                else
                {
                    MessageBox.Show("Alanlar Boş Geçilemez");
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Clear();
            maskedTextBox3.Clear();
            maskedTextBox2.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                MySqlCommand sil = new MySqlCommand("delete from hasta where hasta_id=@id", baglanti);
                sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                sil.ExecuteNonQuery();
                baglanti.Close();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from hasta", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

                MessageBox.Show("Kullanici Başarıyla Silindi");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
