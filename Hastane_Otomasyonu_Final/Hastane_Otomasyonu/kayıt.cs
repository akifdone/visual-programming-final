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
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;database=hastane_final;Uid=root;Pwd='';");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string kayit = "insert into hasta (hasta_tc,hasta_ad,hasta_soyad,hasta_cinsiyeti,hasta_kan,hasta_dogumYeri,hasta_dogumTarihi,hasta_babaAdi,hasta_anaAdi,hasta_tel,hasta_posta,hasta_parola,hasta_adres) " +
                "values(@hasta_tc,@hasta_ad,@hasta_soyad,@hasta_cinsiyeti,@hasta_kan,@hasta_dogumYeri,@hasta_dogumTarihi,@hasta_babaAdi,@hasta_anaAdi,@hasta_tel,@hasta_posta,@hasta_parola, @hasta_adres)";
                MySqlCommand komut = new MySqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@hasta_tc",textTc.Text);
                komut.Parameters.AddWithValue("@hasta_ad",texthastaAdi.Text);
                komut.Parameters.AddWithValue("@hasta_soyad",texthastaSoyadi.Text);
                komut.Parameters.AddWithValue("@hasta_cinsiyeti",textCinsiyeti.Text);
                komut.Parameters.AddWithValue("@hasta_kan",comboboxKan.Text);
                komut.Parameters.AddWithValue("@hasta_dogumYeri", comboboxDogumyeri.Text);
                komut.Parameters.AddWithValue("@hasta_dogumTarihi", hastaDogumTrh.Text);
                komut.Parameters.AddWithValue("@hasta_babaAdi",texthstBaba.Text);
                komut.Parameters.AddWithValue("@hasta_anaAdi",texthstAnne.Text);
                komut.Parameters.AddWithValue("@hasta_tel",textTel.Text);
                komut.Parameters.AddWithValue("@hasta_posta",textPosta.Text);
                komut.Parameters.AddWithValue("@hasta_parola",textPass.Text);
                komut.Parameters.AddWithValue("@hasta_adres",textAdress.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("kayıt eklendi");

            }
            catch (Exception hata)
            {

                MessageBox.Show("hatameydan geldi"+""+hata.Message);


                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(texthastaAdi.Text != " " && texthastaSoyadi.Text !=" "  && textPosta.Text != " " )
            {
                button1.Enabled = false;
                button3.Enabled = true;
            }

          

            try
            {
                if (textTc.Text != " ")
                {
                    if (baglanti.State == ConnectionState.Open)
                        baglanti.Close();

                    baglanti.Open();
                    MySqlCommand sorgulama = new MySqlCommand("select * from hasta where hasta_tc=@tc", baglanti);
                    sorgulama.Parameters.AddWithValue("@tc", textTc.Text);
                    MySqlDataReader oku = sorgulama.ExecuteReader();
                    if (oku.Read())
                    {

                        texthastaAdi.Text = oku[2].ToString();
                        texthastaSoyadi.Text = oku[3].ToString();
                        textCinsiyeti.Text = oku[4].ToString();
                        comboboxKan.Text = oku[5].ToString();
                        comboboxDogumyeri.Text = oku[6].ToString();
                        hastaDogumTrh.Text = oku[7].ToString();
                        texthstBaba.Text = oku[8].ToString();
                        texthstAnne.Text = oku[9].ToString();
                        textTel.Text = oku[10].ToString();
                        textPosta.Text = oku[11].ToString();
                        textAdress.Text = oku[13].ToString();
                        MessageBox.Show("Bu kritere uyan bir hasta bulundu.");
                        


                    }
                    else
                        MessageBox.Show("Bu kriterde bir hasta bulunamadı. Lütfen kayıt yapınız.");
                    baglanti.Close();
                }
                else
                    MessageBox.Show("Önce Hasta TC'si giriniz.");

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata!! " + " " + hata);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
                if (textPass.Text != "" && textPass.Text.Length > 4)
                {
                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();
                    string kayit = "insert into hasta (hasta_parola) values(@hasta_parola)";
                    MySqlCommand komut = new MySqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@hasta_parola", textPass.Text);
                    MessageBox.Show("Şifreniz Oluşturuldu");

                }
                else
                {

                    MessageBox.Show("Lütfen Geçerli Bir Değer Girniz");
                }



        }

        private void kayıt_FormClosed(object sender, FormClosedEventArgs e)
        {
            anasayfa ana = new anasayfa();
            ana.Show();
        }
    }
}
