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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace Hastane_Otomasyonu
{
    public partial class yöneticiBilgi : Form
    {
        public yöneticiBilgi()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void yöneticiBilgi_Load(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }

            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select * from yönetici", baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand sil = new MySqlCommand("delete from yönetici where kullanici_id=@id", baglanti);
                    sil.Parameters.AddWithValue("@id", textBox1.Text);
                    sil.ExecuteNonQuery();

                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }

                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("select * from yönetici", baglanti);
                    MySqlDataAdapter da = new MySqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Kullanici Başarıyla Silindi");
                }
                else
                {
                    MessageBox.Show("Önce bir kullanıcı seçiniz");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && maskedTextBox1.Text != "")
                {

                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand gunceller = new MySqlCommand("update yönetici set kullanici_adi=@kad,kullanici_sifre=@sifre,kullanici_adsoyad=@ad where kullanici_id=@id", baglanti);
                    gunceller.Parameters.AddWithValue("@id", textBox1.Text);
                    gunceller.Parameters.AddWithValue("@kad", textBox3.Text);
                    gunceller.Parameters.AddWithValue("@sifre", maskedTextBox1.Text);
                    gunceller.Parameters.AddWithValue("@ad", textBox2.Text);
                    gunceller.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kullanici Bilgileri Basariyla Güncellendi");

                }
                else
                {
                    MessageBox.Show("Alanlar Boş Bırakılamaz");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand ekle = new MySqlCommand("insert into yönetici(kullanici_adi,kullanici_sifre,kullanici_adsoyad)values(@kad,@sifre,@ad)", baglanti);
                    ekle.Parameters.AddWithValue("@kad", textBox3.Text);
                    ekle.Parameters.AddWithValue("@sifre", maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@ad", textBox2.Text);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("select * from yönetici", baglanti);
                    MySqlDataAdapter da = new MySqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("Kullanici Basariyla Eklendi");
                }
                else
                {
                    MessageBox.Show("Alanlar Boş Bırakılamaz");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
