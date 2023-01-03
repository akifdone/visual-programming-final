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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hastane_Otomasyonu
{
    public partial class bekleyenHasta : Form
    {
        public bekleyenHasta()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");

        private void button1_Click(object sender, EventArgs e)
        {
            randevuMuayne muayene = new randevuMuayne();
            muayene.Show();
            string deger = dataGridView1.CurrentRow.Cells["hasta_id"].Value.ToString();
            textBox1.Text = deger;
       
            try
            {
                if(textBox1.Text != "" )
                {
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand sorgu = new MySqlCommand("select * from hasta,bekleyenHasta where hasta_id=@id",baglanti);
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
                        

                        
                    }
                    baglanti.Close();

                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("select * from bekleyenHasta where bekleyen_id = @id", baglanti);
                    komut.Parameters.AddWithValue("id", dataGridView1.CurrentRow.Cells["bekleyen_id"].Value.ToString());
                    MySqlDataReader oku1 = komut.ExecuteReader();
                    if (oku1.Read())
                    {
                        muayene.maskedTextBox5.Text = oku1[1].ToString();
                        muayene.maskedTextBox2.Text = oku1[2].ToString();
                    }
                    baglanti.Close();

                   
                }
                else
                {
                    MessageBox.Show("Lütfen Hasta İD Giriniz");
                }
                
            }
            catch (Exception hata)
            {

                MessageBox.Show("hata" + "" + hata);
            }
        }

        private void bekleyenHasta_Load(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
