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
    public partial class yöneticiKlinik : Form
    {
        public yöneticiKlinik()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void yöneticiKlinik_Load(object sender, EventArgs e)
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
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Width = 235;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();

                baglanti.Open();
                MySqlCommand ekle = new MySqlCommand("insert into klinkler(klinik_adi) values(@ad) ", baglanti);
                ekle.Parameters.AddWithValue("ad", textBox2.Text);
                ekle.ExecuteNonQuery();
               
                baglanti.Close();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from klinkler", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Width = 235;
                baglanti.Close();

                MessageBox.Show("Klinik Başarıyla Eklendi");
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                MySqlCommand sil = new MySqlCommand("delete from klinkler where klinik_id=@id", baglanti);
                sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                sil.ExecuteNonQuery();
                baglanti.Close();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from klinkler", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[1].Width = 235;
                baglanti.Close();

                MessageBox.Show("Klinik Başarıyla Silindi");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
