using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Hastane_Otomasyonu
{
    public partial class hastaKabul : Form
    {
        public hastaKabul()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");

        void idsorgulama()
        {
            if (baglanti.State == ConnectionState.Open)
                baglanti.Close();
            baglanti.Open();
            MySqlCommand id = new MySqlCommand("select hasta_id from hasta where hasta_tc=@tc ", baglanti);
            id.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
            MySqlDataReader oku = id.ExecuteReader();
            while (oku.Read())
            {
                textBox6.Text = oku[0].ToString();
                textBox7.Text = oku[0].ToString();

            }
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                if (maskedTextBox1.Text != "")
                {

                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand sorgulama = new MySqlCommand("select * from hasta where hasta_tc=@tc", baglanti);
                    sorgulama.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    MySqlDataReader oku = sorgulama.ExecuteReader();
                    if (oku.Read())
                    {
                        textBox6.Text = oku[0].ToString();
                        textBox7.Text = oku[0].ToString();
                        textBox1.Text = oku[2].ToString();
                        textBox2.Text = oku[3].ToString();
                        comboBox1.Text = oku[4].ToString();
                        comboBox4.Text = oku[5].ToString();
                        comboBox2.Text = oku[6].ToString();
                        maskedTextBox3.Text = oku[7].ToString();
                        textBox3.Text = oku[8].ToString();
                        textBox4.Text = oku[9].ToString();
                        maskedTextBox2.Text = oku[10].ToString();
                        textBox5.Text = oku[11].ToString();
                        richTextBox2.Text = oku[13].ToString();
                        MessageBox.Show("Bu kritere uyan bir hasta bulundu.");
                        
                        

                     }
                    else
                        MessageBox.Show("Bu kriterde bir hasta bulunamadı. Lütfen kayıt yapınız.");
                    baglanti.Close();
                }
                else
                    MessageBox.Show("Önce Hasta TC'si giriniz.");

            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata!! "+" "+ hata);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "" )
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
                MessageBox.Show("Önce Hasta Girişi Yapınız");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox4.Text != "" )
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }
            else
                MessageBox.Show("Önce Hasta Girişi Yapınız");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into hasta (hasta_tc,hasta_ad,hasta_soyad,hasta_cinsiyeti,hasta_kan,hasta_dogumYeri,hasta_dogumTarihi,hasta_babaAdi,hasta_anaAdi,hasta_tel,hasta_posta,hasta_parola,hasta_adres) " +
                "values(@hasta_tc,@hasta_ad,@hasta_soyad,@hasta_cinsiyeti,@hasta_kan,@hasta_dogumYeri,@hasta_dogumTarihi,@hasta_babaAdi,@hasta_anaAdi,@hasta_tel,@hasta_posta,@hasta_parola, @hasta_adres)";
                MySqlCommand komut = new MySqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@hasta_tc", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@hasta_ad",textBox1.Text);
                komut.Parameters.AddWithValue("@hasta_soyad",textBox2.Text);
                komut.Parameters.AddWithValue("@hasta_cinsiyeti", comboBox1.Text);
                komut.Parameters.AddWithValue("@hasta_kan", comboBox4.Text);
                komut.Parameters.AddWithValue("@hasta_dogumYeri", comboBox2.Text);
                komut.Parameters.AddWithValue("@hasta_dogumTarihi", maskedTextBox3.Text);
                komut.Parameters.AddWithValue("@hasta_babaAdi", textBox3.Text);
                komut.Parameters.AddWithValue("@hasta_anaAdi", textBox4.Text);
                komut.Parameters.AddWithValue("@hasta_tel", maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@hasta_posta", textBox5.Text);
                komut.Parameters.AddWithValue("@hasta_parola","");
                komut.Parameters.AddWithValue("@hasta_adres",richTextBox2.Text);
               

                komut.ExecuteNonQuery();
                baglanti.Close();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand sorgulama = new MySqlCommand("select * from hasta where hasta_tc=@tc", baglanti);
                sorgulama.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                MySqlDataReader oku = sorgulama.ExecuteReader();
                if (oku.Read())
                {
                    textBox6.Text = oku[0].ToString();
                    textBox7.Text = oku[0].ToString();

                }
                baglanti.Close();
                MessageBox.Show("kayıt eklendi");

              
            }
            catch (Exception hata)
            {

                MessageBox.Show("hatameydan geldi" + "" + hata.Message);



            }
        }

        private void hastaKabul_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from doktorlar", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox5.DisplayMember = "doktor_adi_soyadi";
                comboBox5.ValueMember = "doktor_id";
                comboBox5.DataSource = dt;
                komut.ExecuteNonQuery();
                baglanti.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from klinkler", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox3.DisplayMember = "klinik_adi";
                comboBox3.ValueMember = "klinik_id";
                comboBox3.DataSource = dt;
                komut.ExecuteNonQuery();
                baglanti.Close();
                
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                    baglanti.Open();
                string kayit = "insert into bekleyenHasta (bekleyen_klinik_id,bekleyen_doktor_id,bekleyen_hasta_id) " +
                "values(@klinik_id,@doktor_id,@hasta_id)";
                MySqlCommand komut = new MySqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@klinik_id", comboBox3.SelectedValue.ToString());
                komut.Parameters.AddWithValue("@doktor_id", comboBox5.SelectedValue.ToString());
                komut.Parameters.AddWithValue("@hasta_id", textBox6.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Muayene Oluşturuldu");

            }
            catch (Exception hata)
            {

                MessageBox.Show("hatameydan geldi" + "" + hata.Message);



            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from doktorlar where doktor_alan = @alan", baglanti);
                komut.Parameters.AddWithValue("@alan", button9.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                listBox1.DisplayMember = "doktor_adi_soyadi";
                listBox1.ValueMember = "doktor_id";
                listBox1.DataSource = dt;
                komut.ExecuteNonQuery();
                baglanti.Close();
                label22.Text = button9.Text;
            }
            catch (Exception hata )
            {

                MessageBox.Show(hata.Message);
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from doktorlar where doktor_alan = @alan", baglanti);
                komut.Parameters.AddWithValue("@alan", button8.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                listBox1.DisplayMember = "doktor_adi_soyadi";
                listBox1.ValueMember = "doktor_id";
                listBox1.DataSource = dt;
                komut.ExecuteNonQuery();
                baglanti.Close();
                label22.Text = button8.Text;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from doktorlar where doktor_alan = @alan", baglanti);
                komut.Parameters.AddWithValue("@alan", button7.Text);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                listBox1.DisplayMember = "doktor_adi_soyadi";
                listBox1.ValueMember = "doktor_id";
                listBox1.DataSource = dt;
                komut.ExecuteNonQuery();
                baglanti.Close();
                label22.Text = button7.Text;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("insert into acil(acil_doktor_id,acil_alan,acil_hasta_id) " +
                    "values(@did,@alan,@hid)", baglanti);
                komut.Parameters.AddWithValue("@did", listBox1.SelectedValue.ToString());
                komut.Parameters.AddWithValue("@alan", label22.Text.ToString());
                komut.Parameters.AddWithValue("@hid", textBox6.Text.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Doktor Seçildi");

              
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            
            
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)

        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("update acil set  acil_aciklama=@aciklama where acil_hasta_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", textBox6.Text);
                komut.Parameters.AddWithValue("@aciklama",richTextBox1.Text.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Alındı");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            

        }

        private void hastaKabul_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa anasayfa = new anasayfa();
            anasayfa.Show();
        }
    }
   
}
