using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hastane_Otomasyonu
{
    public partial class randevuGörüntüle : Form
    {
        public randevuGörüntüle()
        {
            InitializeComponent();
        }
        doktorPaneli doktor = new doktorPaneli();

        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void randevuGörüntüle_Load(object sender, EventArgs e)
        {

        }
        public static MySqlDataAdapter da;
        public static DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
               
                var result = MessageBox.Show("Randevuyu iptal etmek istediğinize emin misiniz", "Confirm", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand sil = new MySqlCommand("delete from randevular where randevu_id=@id", baglanti);
                    sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    sil.ExecuteNonQuery();
                    baglanti.Close();

                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    

                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand görüntüle = new MySqlCommand("Select randevular.randevu_id,klinkler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hasta.hasta_tc,hasta.hasta_ad,hasta.hasta_soyad,doktorlar.doktor_adi_soyadi from " +
                        "randevular INNER JOIN hasta on randevular.randevu_hasta_id=hasta.hasta_id INNER JOIN klinkler ON randevular.randevu_klinik_id=klinkler.klinik_id INNER JOIN doktorlar ON randevular.randevu_doktor_id = doktorlar.doktor_id where doktorlar.doktor_id=@id", baglanti);
                    görüntüle.Parameters.AddWithValue("@id",textBox1.Text);
                    da = new MySqlDataAdapter(görüntüle);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglanti.Close();
                    MessageBox.Show("Seçilen Randevu Başarıyla İptal Edilmiştir.");
                }
                if (result == DialogResult.Cancel)
                {
                    //when its cancel i prefer to stay on the same window 
                }

               
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            randevuMuayne muayene = new randevuMuayne();
            muayene.Show();
            
            try
            {
                
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand sorgu = new MySqlCommand(" select*from hasta where hasta.hasta_tc = @tc", baglanti);
                    sorgu.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["hasta_tc"].Value.ToString());
                    MySqlDataReader oku = sorgu.ExecuteReader();
                    while (oku.Read())
                    { 
                        muayene.maskedTextBox1.Text = oku[1].ToString();
                        muayene.textBox1.Text = oku[2].ToString();
                        muayene.textBox2.Text = oku[3].ToString();
                        muayene.textBox6.Text = oku[4].ToString();
                        muayene.textBox7.Text = oku[5].ToString();
                        muayene.textBox8.Text = oku[6].ToString();
                        muayene.maskedTextBox3.Text = oku[7].ToString();
                        muayene.textBox3.Text = oku[8].ToString();
                        muayene.textBox4.Text = oku[9].ToString();
                        muayene.maskedTextBox2.Text = textBox1.Text;
                        muayene.maskedTextBox5.Text = dataGridView1.CurrentRow.Cells["klinik_id"].Value.ToString();
                    }
                    baglanti.Close();
                
              

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


                var result = MessageBox.Show("Randevuyu iptal etmek istediğinize emin misiniz", "Confirm", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();
                    baglanti.Open();
                    MySqlCommand sil = new MySqlCommand("delete from randevular where randevu_id=@id", baglanti);
                    sil.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    sil.ExecuteNonQuery();
                    baglanti.Close();

                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }


                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                    baglanti.Open();
                    MySqlCommand görüntüle = new MySqlCommand("Select randevular.randevu_id,klinkler.klinik_adi,randevular.randevu_tarih,randevular.randevu_saat,hasta.hasta_tc,hasta.hasta_ad,hasta.hasta_soyad,doktorlar.doktor_adi_soyadi from " +
                        "randevular INNER JOIN hasta on randevular.randevu_hasta_id=hasta.hasta_id INNER JOIN klinkler ON randevular.randevu_klinik_id=klinkler.klinik_id INNER JOIN doktorlar ON randevular.randevu_doktor_id = doktorlar.doktor_id where hasta.hasta_id=@id", baglanti);
                    görüntüle.Parameters.AddWithValue("@id", textBox1.Text);
                    da = new MySqlDataAdapter(görüntüle);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    görüntüle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Seçilen Randevu Başarıyla İptal Edilmiştir.");
                }
                if (result == DialogResult.Cancel)
                {
                    //when its cancel i prefer to stay on the same window 
                }


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
