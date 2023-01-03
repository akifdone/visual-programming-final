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
    public partial class yöneticiContact : Form
    {
        public yöneticiContact()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void yöneticiContact_Load(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                MySqlCommand görüntüle = new MySqlCommand("select * from iletisim", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(görüntüle);
                DataTable  dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                    baglanti.Close();
                baglanti.Open();
                MySqlCommand c = new MySqlCommand("select * from iletisim where iletisim_id=@id", baglanti);
                c.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MySqlDataReader oku = c.ExecuteReader();
                while (oku.Read())
                {

                    textBox1.Text = oku[1].ToString();
                    textBox2.Text = oku[2].ToString();
                    textBox3.Text = oku[4].ToString();
                    textBox4.Text = oku[3].ToString();
                }
                baglanti.Close();
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
                
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand sil = new MySqlCommand("delete from iletisim where iletisim_id=@id", baglanti);
                    sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Kullanici Başarıyla Silindi");
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
