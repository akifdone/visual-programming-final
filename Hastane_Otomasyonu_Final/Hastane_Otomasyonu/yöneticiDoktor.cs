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
    public partial class yöneticiDoktor : Form
    {
        public yöneticiDoktor()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void yöneticiDoktor_Load(object sender, EventArgs e)
        {
            if(baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select * from doktorlar ",baglanti);
            MySqlDataAdapter da = new MySqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();


            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            MySqlCommand randevu = new MySqlCommand("select * from klinkler", baglanti);
            MySqlDataAdapter da2 = new MySqlDataAdapter(randevu);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox1.DisplayMember = "klinik_adi";
            comboBox1.ValueMember = "klinik_id";
            comboBox1.DataSource = dt2;
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                MySqlCommand q = new MySqlCommand("select * from doktorlar where doktor_id =@id", baglanti);
                q.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MySqlDataReader oku = q.ExecuteReader();
                while (oku.Read())
                {
                    maskedTextBox1.Text = oku[5].ToString();
                    textBox1.Text = oku[3].ToString();
                    comboBox3.Text = oku[11].ToString();
                    textBox7.Text = oku[6].ToString();
                    textBox8.Text = oku[7].ToString();
                    textBox9.Text = oku[10].ToString();
                    maskedTextBox2.Text = oku[8].ToString();
                    textBox5.Text = oku[9].ToString();
                    maskedTextBox3.Text = oku[1].ToString();
                    maskedTextBox4.Text = oku[2].ToString();
                    textBox2.Text = oku[4].ToString();
                    comboBox2.Text = oku["doktor_alan"].ToString();
                    comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["doktor_klinik_id"].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells["doktor_id"].Value.ToString();
                   
                }
                baglanti.Close();
            }
            catch
            {
                MessageBox.Show("Hata! Lütfen daha sonra tekrar deneyiniz");
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                MySqlCommand sil = new MySqlCommand("delete from doktorlar where doktor_id=@id", baglanti);
                sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                sil.ExecuteNonQuery();
                baglanti.Close();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from doktorlar ", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();

                MessageBox.Show("Doktor Başarıyla Silindi");       
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            comboBox3.SelectedIndex = 0;
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.SelectedValue.ToString();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox5.Text != "" && maskedTextBox1.Text != "")
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("insert into doktorlar(kullanici_adi,sifre,doktor_adi_soyadi,doktor_klinik_id,doktor_tc,doktor_kan,doktor_dtarih,doktor_cep,doktor_eposta,doktor_adres,doktor_cinsiyet,doktor_alan)values(@kadi,@sifre,@ad,@klinik,@tc,@kan,@dtarih,@cep,@eposta,@adres,@cinsiyet,@alan)", baglanti);
                    komut.Parameters.AddWithValue("@kadi", maskedTextBox3.Text);
                    komut.Parameters.AddWithValue("@sifre", maskedTextBox5.Text);
                    komut.Parameters.AddWithValue("@ad", textBox1.Text);
                    komut.Parameters.AddWithValue("@klinik", textBox2.Text);
                    komut.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    komut.Parameters.AddWithValue("@kan", textBox7.Text);
                    komut.Parameters.AddWithValue("@dtarih", textBox8.Text);
                    komut.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@eposta", textBox5.Text);
                    komut.Parameters.AddWithValue("@adres", textBox9.Text);
                    komut.Parameters.AddWithValue("@cinsiyet", comboBox3.Text);
                    komut.Parameters.AddWithValue("@alan", comboBox2.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand komut2 = new MySqlCommand("select * from doktorlar ", baglanti);
                    MySqlDataAdapter da = new MySqlDataAdapter(komut2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();

                    MessageBox.Show("Doktor başarıyla eklendi");
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Alanlar Boş Bırakılamaz");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox3.Text != "" )
            {
                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("UPDATE doktorlar SET kullanici_adi=@kadi,sifre=@sifre,doktor_adi_soyadi=@ad,doktor_klinik_id=@klinik,doktor_tc=@tc,doktor_kan=@kan,doktor_dtarih=@dtarih,doktor_cep=@cep,doktor_eposta=@eposta,doktor_adres=@adres,doktor_cinsiyet=@cinsiyet, doktor_alan=@alan where doktor_id=@id ", baglanti);
                    komut.Parameters.AddWithValue("@id", textBox3.Text);
                    komut.Parameters.AddWithValue("@kadi",maskedTextBox3.Text.ToString());
                    komut.Parameters.AddWithValue("@sifre", maskedTextBox5.Text);
                    komut.Parameters.AddWithValue("@ad", textBox1.Text.ToString());
                    komut.Parameters.AddWithValue("@klinik",textBox2.Text);
                    komut.Parameters.AddWithValue("@tc", maskedTextBox1.Text.ToString());
                    komut.Parameters.AddWithValue("@kan", textBox7.Text);
                    komut.Parameters.AddWithValue("@dtarih", textBox8.Text);
                    komut.Parameters.AddWithValue("@cep", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@eposta", textBox5.Text);
                    komut.Parameters.AddWithValue("@adres", textBox9.Text);
                    komut.Parameters.AddWithValue("@cinsiyet",comboBox3.Text.ToString());
                    komut.Parameters.AddWithValue("@alan",comboBox2.Text.ToString());

                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Doktor bilgileri başarıyla güncellendi");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Alanlar Boş Bırakılamaz");
        }
    }

       
    
}
