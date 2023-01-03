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
    public partial class acilGörüntüle : Form
    {
        public acilGörüntüle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void acilGörüntüle_Load(object sender, EventArgs e)
        {

            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from acil", baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randevuMuayne muayene = new randevuMuayne();
            acilGörüntüle acil = new acilGörüntüle();
            muayene.Show();
            muayene.maskedTextBox5.Visible = false;
            muayene.label16.Visible = false;
            string alan;
            alan = dataGridView1.CurrentRow.Cells["acil_alan"].Value.ToString();
            switch (alan)
            {
                case "Yeşil Alan":
                    muayene.BackColor = Color.LimeGreen;
                    break;
                case "Sarı Alan":
                    muayene.BackColor = Color.Khaki;
                    break;
                case "Kırmızı Alan":
                    muayene.BackColor = Color.Salmon;
                    break;
                default:
                    break;
    
            }
            textBox1.Text  = dataGridView1.CurrentRow.Cells["acil_hasta_id"].Value.ToString();
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand sorgu = new MySqlCommand("select * from hasta where hasta_id=@id", baglanti);
                sorgu.Parameters.AddWithValue("@id", textBox1.Text);
                MySqlDataReader oku = sorgu.ExecuteReader();

                if (oku.Read())
                {
                    muayene.maskedTextBox4.Text = textBox1.Text.ToString();
                    muayene.maskedTextBox1.Text = oku[1].ToString();
                    muayene.textBox1.Text = oku[2].ToString();
                    muayene.textBox2.Text = oku[3].ToString();
                    muayene.textBox6.Text = oku[4].ToString();
                    muayene.textBox7.Text = oku[5].ToString();
                    muayene.textBox8.Text = oku[6].ToString();
                    muayene.maskedTextBox3.Text = oku[7].ToString();
                    muayene.textBox3.Text = oku[8].ToString();
                    muayene.textBox4.Text = oku[9].ToString();
                    muayene.maskedTextBox2.Text = dataGridView1.CurrentRow.Cells["acil_doktor_id"].Value.ToString();



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
