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
    public partial class randevuAl : Form
    {
        public randevuAl()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                if (textBox2.Text != "" && comboBox1.Text != "")
                {
                    MySqlCommand randevuekle = new MySqlCommand("insert into randevular(randevu_hasta_id,randevu_tarih,randevu_saat,randevu_klinik_id,randevu_doktor_id)  values(@id,@tarih,@saat,@kid,@did)", baglanti);
                    randevuekle.Parameters.AddWithValue("@id", textBox1.Text.ToString());
                    randevuekle.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
                    randevuekle.Parameters.AddWithValue("@saat", textBox2.Text.ToString());
                    randevuekle.Parameters.AddWithValue("@kid", comboBox1.SelectedValue.ToString());
                    randevuekle.Parameters.AddWithValue("@did", comboBox2.SelectedValue.ToString());
                    randevuekle.ExecuteNonQuery();
                    baglanti.Close();   
                    textBox2.Clear();
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;

                    var result = MessageBox.Show("Randevunuz Alınmıştır", "Confirm", MessageBoxButtons.OK);

                    if (result == DialogResult.OK)
                    {
                        if (baglanti.State == ConnectionState.Open)
                            baglanti.Close();
                        baglanti.Open();
                        MySqlCommand sorgu = new MySqlCommand("select * from randevular where randevu_doktor_id = @did and randevu_klinik_id = @kid and randevu_tarih = @tarih", baglanti);
                        sorgu.Parameters.AddWithValue("@did", comboBox2.SelectedValue.ToString());
                        sorgu.Parameters.AddWithValue("@kid", comboBox1.SelectedValue.ToString());
                        sorgu.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
                        MySqlDataReader reader = sorgu.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["randevu_saat"].ToString() == button2.Text)
                            {
                                button2.BackColor = Color.Red;
                                button2.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button3.Text)
                            {
                                button3.BackColor = Color.Red;
                                button3.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button4.Text)
                            {
                                button4.BackColor = Color.Red;
                                button4.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button5.Text)
                            {
                                button5.BackColor = Color.Red;
                                button5.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button6.Text)
                            {
                                button6.BackColor = Color.Red;
                                button6.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button7.Text)
                            {
                                button7.BackColor = Color.Red;
                                button7.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button8.Text)
                            {
                                button8.BackColor = Color.Red;
                                button8.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button9.Text)
                            {
                                button9.BackColor = Color.Red;
                                button9.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button10.Text)
                            {
                                button10.BackColor = Color.Red;
                                button10.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button11.Text)
                            {
                                button11.BackColor = Color.Red;
                                button11.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button12.Text)
                            {
                                button12.BackColor = Color.Red;
                                button12.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button13.Text)
                            {
                                button13.BackColor = Color.Red;
                                button13.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button14.Text)
                            {
                                button14.BackColor = Color.Red;
                                button14.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button15.Text)
                            {
                                button15.BackColor = Color.Red;
                                button15.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button16.Text)
                            {
                                button16.BackColor = Color.Red;
                                button16.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button17.Text)
                            {
                                button17.BackColor = Color.Red;
                                button17.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button18.Text)
                            {
                                button18.BackColor = Color.Red;
                                button18.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button19.Text)
                            {
                                button19.BackColor = Color.Red;
                                button19.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button20.Text)
                            {
                                button20.BackColor = Color.Red;
                                button20.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button21.Text)
                            {
                                button21.BackColor = Color.Red;
                                button21.Enabled = false;
                            }
                            if (reader["randevu_saat"].ToString() == button22.Text)
                            {
                                button22.BackColor = Color.Red;
                                button22.Enabled = false;
                            }
                        }

                        baglanti.Close();
                    }

                    
                   


                }
                else
                {
                    MessageBox.Show("Lütfen Gerekli Bilgileri Doldurunuz");
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata!! " + " "+ ex);
            }
        }

        private void randevuAl_Load(object sender, EventArgs e)
        {
           
        }

        private void randevuAl_Load_1(object sender, EventArgs e)
        {
            panel3.Enabled = false;
           
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
                comboBox1.DisplayMember = "klinik_adi";
                comboBox1.ValueMember = "klinik_id";
                comboBox1.DataSource = dt;
                komut.ExecuteNonQuery();
                baglanti.Close();

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut1 = new MySqlCommand("select * from doktorlar", baglanti);
                MySqlDataAdapter da1 = new MySqlDataAdapter(komut1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                comboBox2.DisplayMember = "doktor_adi_soyadi";
                comboBox2.ValueMember = "doktor_id";
                comboBox2.DataSource = dt1;
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
            textBox2.Text = "08:00";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "08:30";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "09:00";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "09:30";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "10:00";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "10:30";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = "11:00";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = "11:30";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = "12:00";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "12:30";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = "13:00";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text = "13:30";
        }
        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = "14:00";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text = "14:30";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text = "15:00";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = "15:30";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox2.Text = "16:00";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox2.Text = "16:30";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Text = "17:00";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox2.Text = "17:30";
        }

        private void button22_Click(object sender, EventArgs e)
        {
           
            panel3.Enabled = true;
            button2.BackColor = Color.Green;
            button3.BackColor = Color.Green;
            button4.BackColor = Color.Green;
            button5.BackColor = Color.Green;
            button6.BackColor = Color.Green;
            button7.BackColor = Color.Green;
            button8.BackColor = Color.Green;
            button9.BackColor = Color.Green;
            button10.BackColor = Color.Green;
            button11.BackColor = Color.Green;
            button12.BackColor = Color.Green;
            button13.BackColor = Color.Green;
            button14.BackColor = Color.Green;
            button15.BackColor = Color.Green;
            button16.BackColor = Color.Green;
            button17.BackColor = Color.Green;
            button18.BackColor = Color.Green;
            button19.BackColor = Color.Green;
            button20.BackColor = Color.Green;
            button21.BackColor = Color.Green;


            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            try
            {
                if(baglanti.State == ConnectionState.Open)
                baglanti.Close();
                baglanti.Open();
                MySqlCommand sorgu = new MySqlCommand("select * from randevular where randevu_doktor_id = @did and randevu_klinik_id = @kid and randevu_tarih = @tarih",baglanti);
                sorgu.Parameters.AddWithValue("@did", comboBox2.SelectedValue.ToString());
                sorgu.Parameters.AddWithValue("@kid", comboBox1.SelectedValue.ToString());
                sorgu.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToShortDateString());
                MySqlDataReader reader = sorgu.ExecuteReader();
                while (reader.Read())
                {
                    if(reader["randevu_saat"].ToString() == button2.Text)
                    {
                        button2.BackColor = Color.Red;
                        button2.Enabled = false;                       
                    } 
                    if(reader["randevu_saat"].ToString() == button3.Text)
                    {
                        button3.BackColor = Color.Red;
                        button3.Enabled = false;
                    }
                     if(reader["randevu_saat"].ToString() == button4.Text)
                    {
                        button4.BackColor = Color.Red;
                        button4.Enabled = false;
                    }
                    if (reader["randevu_saat"].ToString() == button5.Text)
                    {
                        button5.BackColor = Color.Red;
                        button5.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button6.Text)
                    {
                        button6.BackColor = Color.Red;
                        button6.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button7.Text)
                    {
                        button7.BackColor = Color.Red;
                        button7.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button8.Text)
                    {
                        button8.BackColor = Color.Red;
                        button8.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button9.Text)
                    {
                        button9.BackColor = Color.Red;
                        button9.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button10.Text)
                    {
                        button10.BackColor = Color.Red;
                        button10.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button11.Text)
                    {
                        button11.BackColor = Color.Red;
                        button11.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button12.Text)
                    {
                        button12.BackColor = Color.Red;
                        button12.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button13.Text)
                    {
                        button13.BackColor = Color.Red;
                        button13.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button14.Text)
                    {
                        button14.BackColor = Color.Red;
                        button14.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button15.Text)
                    {
                        button15.BackColor = Color.Red;
                        button15.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button16.Text)
                    {
                        button16.BackColor = Color.Red;
                        button16.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button17.Text)
                    {
                        button17.BackColor = Color.Red;
                        button17.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button18.Text)
                    {
                        button18.BackColor = Color.Red;
                        button18.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button19.Text)
                    {
                        button19.BackColor = Color.Red;
                        button19.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button20.Text)
                    {
                        button20.BackColor = Color.Red;
                        button20.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button21.Text)
                    {
                        button21.BackColor = Color.Red;
                        button21.Enabled = false;
                    }
                     if (reader["randevu_saat"].ToString() == button22.Text)
                    {
                        button22.BackColor = Color.Red;
                        button22.Enabled = false;
                    }
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
