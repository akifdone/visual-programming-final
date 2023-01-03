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
    public partial class randevuMuayne : Form
    {
        public randevuMuayne()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");

        private void button4_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            //comboBox1.SelectedIndex = 0;
            textBox5.Clear();
            panel3.Enabled = true;
            button5.Enabled = true;

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Enabled = true;
            panel3.Enabled = false;

            listBox1.Items.Clear();
            //comboBox1.SelectedIndex = 0;
            textBox5.Clear();
            panel3.Enabled = false;
            button5.Enabled = true;




        }

        private void randevuMuayne_Load(object sender, EventArgs e)
        {


            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("select * from testler",baglanti);
                MySqlDataAdapter da = new MySqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox1.DisplayMember = "test_adi";
                comboBox1.ValueMember = "test_id";
                comboBox1.DataSource = dt;
                baglanti.Close();


               
            }
            catch (Exception hata)
            {

                MessageBox.Show("hata meydana geldi" + " " + hata);
            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox1.Text);
            
            if(comboBox1.SelectedIndex > 0 && listBox1.Items.Count > 0)
            {
                button3.Enabled = true;
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex > 0 && listBox1.Items.Count > 0)
            {

                try
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("insert into tahliller(tahlil_doktor_id, tahlil_hasta_id, tahlil_klinik_id, tahlil_test_id) values(@did,@hid,@kid,@tid)", baglanti);
                    komut.Parameters.AddWithValue("did", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("hid", maskedTextBox4.Text);
                    komut.Parameters.AddWithValue("kid", maskedTextBox5.Text);
                    komut.Parameters.AddWithValue("tid", comboBox1.SelectedValue);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("İstediğini Test Laboratuvara Gönderildli");
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);
                }

                listBox1.Items.Clear();
                comboBox1.SelectedIndex = 0;
                
            }
            else
            {
                MessageBox.Show("Lütfen Bir Test Ekleyiniz");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            comboBox1.SelectedIndex = 0;
            textBox5.Clear();
            panel3.Enabled = false;
            button5.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            acilGörüntüle acil = new acilGörüntüle();
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();
            MySqlCommand temizle = new MySqlCommand("delete from acil where acil_hasta_id=@id", baglanti);
            temizle.Parameters.AddWithValue("@id", maskedTextBox4.Text);
            temizle.ExecuteNonQuery();
            baglanti.Close();
            this.Close();

            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if(maskedTextBox4.Text != "")
            {

                try
                {
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand("insert into receteler(recete_doktor_id,recete_hasta_id,recete_tanı) values(@did,@hid,@tanı)", baglanti);
                    komut.Parameters.AddWithValue("@did", maskedTextBox2.Text);
                    komut.Parameters.AddWithValue("@hid", maskedTextBox4.Text);
                    komut.Parameters.AddWithValue("@tanı", textBox5.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Gönderildi");
                    baglanti.Close();
                }
                catch (Exception hata)
                {

                    MessageBox.Show(hata.Message);

                }
            }
            
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void randevuMuayne_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.BackColor = Color.MediumTurquoise;
        }
    }
}
