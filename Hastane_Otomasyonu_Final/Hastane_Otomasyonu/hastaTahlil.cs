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
    public partial class hastaTahlil : Form
    {
        public hastaTahlil()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void hastaTahlil_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from doktorlar",baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "doktor_adi_soyadi";
                comboBox1.ValueMember = "doktor_id";
                comboBox1.DataSource = dt;
                komut.ExecuteNonQuery();
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
                if(baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                // hasta recete tablosunu doktro id'ye göre çekme
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select receteler.recete_id,doktorlar.doktor_adi_soyadi,hasta.hasta_ad,hasta.hasta_soyad," +
                "receteler.recete_tahlil_id from receteler INNER JOIN doktorlar on receteler.recete_doktor_id=doktorlar.doktor_id INNER JOIN hasta on recete_hasta_id=hasta.hasta_id where receteler.recete_doktor_id=@id",baglanti);
                komut.Parameters.AddWithValue("@id",comboBox1.SelectedValue);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                komut.ExecuteNonQuery();
                button3.Enabled = true;
                baglanti.Close();

               
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            richTextBox2.Clear();
            listBox1.Items.Clear();
            richTextBox1.Clear();
            textBox3.Clear();
            textBox1.Text = dataGridView1.CurrentRow.Cells["recete_tahlil_id"].Value.ToString();
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }

                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from receteler where recete_tahlil_id = @id",baglanti);
                komut.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells["recete_tahlil_id"].Value.ToString());
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    richTextBox2.Text = oku[4].ToString();
                }
                baglanti.Close();

                if(baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }  
                baglanti.Open();
                MySqlCommand komut2 = new MySqlCommand("select * from hasta_ilac where hasta_tahlil_id = @tahlil_id",baglanti);
                komut2.Parameters.AddWithValue("@tahlil_id",dataGridView1.CurrentRow.Cells["recete_tahlil_id"].Value.ToString());
                MySqlDataReader oku2  = komut2.ExecuteReader();
                listBox1.DisplayMember = "hasta_ilac_adi";
                listBox1.ValueMember = "hasat_ilac_id";
                while (oku2.Read())
                {
                    listBox1.Items.Add(oku2[2]);
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("hata"+" "+hata);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // ilaç id
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand sorgu = new MySqlCommand("select * from hasta_ilac where hasta_ilac_adi = @adi", baglanti);
                sorgu.Parameters.AddWithValue("@adi", listBox1.SelectedItem);
                MySqlDataReader oku = sorgu.ExecuteReader();
                if (oku.Read())
                {
                    textBox3.Text = oku[0].ToString();
                }
                baglanti.Close();

                
                // ilaç kullanımı
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand sorgu2 = new MySqlCommand("select * from hasta_ilac where hasta_tahlil_id=@id and hasta_ilac_adi = @adi", baglanti);
                sorgu2.Parameters.AddWithValue("id", textBox1.Text);
                sorgu2.Parameters.AddWithValue("adi", listBox1.SelectedItem.ToString());
                MySqlDataReader oku2 = sorgu2.ExecuteReader();
                if (oku2.Read())
                {
                    richTextBox1.Text = oku2[3].ToString();
                }
                baglanti.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
           
            
        }
    }
}
