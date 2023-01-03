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
using System.Reflection.Emit;
using MySql.Data.MySqlClient;

namespace Hastane_Otomasyonu
{
    public partial class doktorTahlilsonuc : Form
    {
        public doktorTahlilsonuc()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            panel3.Enabled = false;
        }

        private void doktorTahlilsonuc_Load(object sender, EventArgs e)
        {
            
            
            panel3.Enabled = false;
            button4.Enabled = false;
            
            
            // ilacları comboboxa çekmek
            try
            {
                
                panel3.Enabled = false;

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from ilaclar", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox4.DisplayMember = "ilac_adi";
                comboBox4.ValueMember = "ilac_id";
                comboBox4.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            

            string adi = dataGridView1.CurrentRow.Cells["sonuc_hasta_adi"].Value.ToString();
            string tarih = dataGridView1.CurrentRow.Cells["sonuc_tarih"].Value.ToString();
            string aciklma = dataGridView1.CurrentRow.Cells["sonuc_aciklama"].Value.ToString();
            string test = dataGridView1.CurrentRow.Cells["sonuc_test_adi"].Value.ToString();
            string tahlil_id = dataGridView1.CurrentRow.Cells["sonuc_tahlil_id"].Value.ToString();
            string doktor_id = dataGridView1.CurrentRow.Cells["sonuc_doktor_id"].Value.ToString();

            string hasta_id = "0";
            textBox3.Text = adi;
            textBox4.Text = test;
            dateTimePicker1.Text = tarih;
            richTextBox1.Text = aciklma;
            textBox5.Text = doktor_id;
            textBox1.Text = tahlil_id;

            // hasta idsini tahliller tablosundan çekmek için

            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            MySqlCommand sorgu = new MySqlCommand("select * from tahliller where tahlil_id=@id", baglanti);
            sorgu.Parameters.AddWithValue("@id", textBox1.Text);
            MySqlDataReader oku = sorgu.ExecuteReader();
            if (oku.Read())
            {
                hasta_id = oku[2].ToString();
            }
            textBox6.Text = hasta_id;
            baglanti.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           

            try
            {
                // hasta_ilac tablosuna veri ekleme

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("insert into hasta_ilac(hasta_tahlil_id,hasta_ilac_adi,hasta_ilac_kul) values(@tahlil,@ilac,@kullanım)",baglanti);
                komut.Parameters.AddWithValue("@tahlil", textBox1.Text);
                komut.Parameters.AddWithValue("@ilac", comboBox4.Text);
                komut.Parameters.AddWithValue("@kullanım", richTextBox2.Text);
                komut.ExecuteNonQuery();
                listBox1.Items.Add(comboBox4.Text);
                MessageBox.Show("İlaç Eklendi");
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


                //veri tabanına receteler tablosuna veri ekleme

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("insert into receteler(recete_doktor_id,recete_hasta_id,recete_tanı,recete_tahlil_id) values(@did,@hid,@tanı,@tahlil) ",baglanti);
                komut.Parameters.AddWithValue("@did",textBox5.Text);
                komut.Parameters.AddWithValue("@hid",textBox6.Text);
                komut.Parameters.AddWithValue("@tanı",textBox2.Text);
                komut.Parameters.AddWithValue("@tahlil", textBox1.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Tanı Gönderildi");

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                MySqlCommand sil = new MySqlCommand("delete from labsonuclar where sonuc_id=@id", baglanti);
                sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                sil.ExecuteNonQuery();
                baglanti.Close();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from labsonuclar where sonuc_doktor_id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["sonuc_doktor_id"].Value.ToString());
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();


            }
            catch (Exception hata)
            {

               MessageBox.Show(hata.Message);
            }
           
        }
    }
}
