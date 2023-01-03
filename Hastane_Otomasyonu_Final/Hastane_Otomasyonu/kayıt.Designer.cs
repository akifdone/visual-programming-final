namespace Hastane_Otomasyonu
{
    partial class kayıt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kayıt));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textPass = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textAdress = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hastaDogumTrh = new System.Windows.Forms.MaskedTextBox();
            this.comboboxKan = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textPosta = new System.Windows.Forms.TextBox();
            this.textTel = new System.Windows.Forms.MaskedTextBox();
            this.texthstAnne = new System.Windows.Forms.TextBox();
            this.texthstBaba = new System.Windows.Forms.TextBox();
            this.comboboxDogumyeri = new System.Windows.Forms.ComboBox();
            this.textCinsiyeti = new System.Windows.Forms.ComboBox();
            this.texthastaSoyadi = new System.Windows.Forms.TextBox();
            this.texthastaAdi = new System.Windows.Forms.TextBox();
            this.textTc = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Azure;
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(435, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 32);
            this.button3.TabIndex = 94;
            this.button3.Text = "Şifre Belirle";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Azure;
            this.button2.Location = new System.Drawing.Point(436, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 34);
            this.button2.TabIndex = 93;
            this.button2.Text = "Hastane Girişim Var";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(168, 449);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(324, 16);
            this.label12.TabIndex = 92;
            this.label12.Text = "(Parolanız 5 karakter olmalı ve sayılardan oluşmalıdır)";
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(308, 424);
            this.textPass.Mask = "00000";
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(121, 22);
            this.textPass.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(160, 424);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 20);
            this.label11.TabIndex = 90;
            this.label11.Text = "Parola";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.Location = new System.Drawing.Point(167, 493);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(96, 20);
            this.label18.TabIndex = 89;
            this.label18.Text = "Hasta Adres";
            // 
            // textAdress
            // 
            this.textAdress.Location = new System.Drawing.Point(308, 493);
            this.textAdress.Name = "textAdress";
            this.textAdress.Size = new System.Drawing.Size(186, 78);
            this.textAdress.TabIndex = 88;
            this.textAdress.Text = "";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.MintCream;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(500, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 78);
            this.button1.TabIndex = 86;
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hastaDogumTrh
            // 
            this.hastaDogumTrh.Location = new System.Drawing.Point(308, 252);
            this.hastaDogumTrh.Mask = "00/00/0000";
            this.hastaDogumTrh.Name = "hastaDogumTrh";
            this.hastaDogumTrh.Size = new System.Drawing.Size(121, 22);
            this.hastaDogumTrh.TabIndex = 87;
            this.hastaDogumTrh.ValidatingType = typeof(System.DateTime);
            // 
            // comboboxKan
            // 
            this.comboboxKan.FormattingEnabled = true;
            this.comboboxKan.Items.AddRange(new object[] {
            "O R-",
            "O R+",
            "A R-",
            "A R+",
            "B R-",
            "B R+",
            "AB R-",
            "AB R+"});
            this.comboboxKan.Location = new System.Drawing.Point(308, 190);
            this.comboboxKan.Name = "comboboxKan";
            this.comboboxKan.Size = new System.Drawing.Size(121, 24);
            this.comboboxKan.TabIndex = 85;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(183, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 20);
            this.label14.TabIndex = 84;
            this.label14.Text = "Kan Grubu";
            // 
            // textPosta
            // 
            this.textPosta.Location = new System.Drawing.Point(308, 392);
            this.textPosta.Name = "textPosta";
            this.textPosta.Size = new System.Drawing.Size(121, 22);
            this.textPosta.TabIndex = 83;
            // 
            // textTel
            // 
            this.textTel.Location = new System.Drawing.Point(308, 358);
            this.textTel.Mask = "(999) 000-0000";
            this.textTel.Name = "textTel";
            this.textTel.Size = new System.Drawing.Size(121, 22);
            this.textTel.TabIndex = 82;
            // 
            // texthstAnne
            // 
            this.texthstAnne.Location = new System.Drawing.Point(308, 325);
            this.texthstAnne.Name = "texthstAnne";
            this.texthstAnne.Size = new System.Drawing.Size(121, 22);
            this.texthstAnne.TabIndex = 81;
            // 
            // texthstBaba
            // 
            this.texthstBaba.Location = new System.Drawing.Point(308, 287);
            this.texthstBaba.Name = "texthstBaba";
            this.texthstBaba.Size = new System.Drawing.Size(121, 22);
            this.texthstBaba.TabIndex = 80;
            // 
            // comboboxDogumyeri
            // 
            this.comboboxDogumyeri.FormattingEnabled = true;
            this.comboboxDogumyeri.Items.AddRange(new object[] {
            "Adana",
            "Adıyaman",
            "Afyonkarahisar",
            "Ağrı",
            "Aksaray",
            "Amasya",
            "Ankara",
            "Antalya",
            "Ardahan",
            "Artvin",
            "Aydın",
            "Balıkesir",
            "Bartın",
            "Batman",
            "Bayburt",
            "Bilecik",
            "Bingöl",
            "Bitlis",
            "Bolu",
            "Burdur",
            "Bursa",
            "Çanakkale",
            "Çankırı",
            "Çorum",
            "Denizli",
            "Diyarbakır",
            "Düzce",
            "Edirne",
            "Elazığ",
            "Erzincan",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Giresun",
            "Gümüşhane",
            "Hakkâri",
            "Hatay",
            "Iğdır",
            "Isparta",
            "İstanbul",
            "İzmir",
            "Kahramanmaraş",
            "Karabük",
            "Karaman",
            "Kars",
            "Kastamonu",
            "Kayseri",
            "Kilis",
            "Kırıkkale",
            "Kırklareli",
            "Kırşehir",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Manisa",
            "Mardin",
            "Mersin",
            "Muğla",
            "Muş",
            "Nevşehir",
            "Niğde",
            "Ordu",
            "Osmaniye",
            "Rize",
            "Sakarya",
            "Samsun",
            "Şanlıurfa",
            "Siirt",
            "Sinop",
            "Sivas",
            "Şırnak",
            "Tekirdağ",
            "Tokat",
            "Trabzon",
            "Tunceli",
            "Uşak",
            "Van",
            "Yalova",
            "Yozgat",
            "Zonguldak"});
            this.comboboxDogumyeri.Location = new System.Drawing.Point(308, 220);
            this.comboboxDogumyeri.Name = "comboboxDogumyeri";
            this.comboboxDogumyeri.Size = new System.Drawing.Size(121, 24);
            this.comboboxDogumyeri.TabIndex = 79;
            // 
            // textCinsiyeti
            // 
            this.textCinsiyeti.FormattingEnabled = true;
            this.textCinsiyeti.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.textCinsiyeti.Location = new System.Drawing.Point(308, 158);
            this.textCinsiyeti.Name = "textCinsiyeti";
            this.textCinsiyeti.Size = new System.Drawing.Size(121, 24);
            this.textCinsiyeti.TabIndex = 78;
            // 
            // texthastaSoyadi
            // 
            this.texthastaSoyadi.Location = new System.Drawing.Point(308, 123);
            this.texthastaSoyadi.Name = "texthastaSoyadi";
            this.texthastaSoyadi.Size = new System.Drawing.Size(121, 22);
            this.texthastaSoyadi.TabIndex = 77;
            // 
            // texthastaAdi
            // 
            this.texthastaAdi.Location = new System.Drawing.Point(308, 90);
            this.texthastaAdi.Name = "texthastaAdi";
            this.texthastaAdi.Size = new System.Drawing.Size(121, 22);
            this.texthastaAdi.TabIndex = 76;
            // 
            // textTc
            // 
            this.textTc.Location = new System.Drawing.Point(308, 56);
            this.textTc.Mask = "00000000000";
            this.textTc.Name = "textTc";
            this.textTc.Size = new System.Drawing.Size(121, 22);
            this.textTc.TabIndex = 75;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(160, 392);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 20);
            this.label10.TabIndex = 74;
            this.label10.Text = "Hasta E-Posta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(118, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 20);
            this.label9.TabIndex = 73;
            this.label9.Text = "Hasta Cep Telefonu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(148, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 72;
            this.label8.Text = "Hasta Anne Adı";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(140, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 71;
            this.label7.Text = "Hasta Baba Adı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(117, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 20);
            this.label6.TabIndex = 70;
            this.label6.Text = "Hasta Doğum Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(131, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 20);
            this.label5.TabIndex = 69;
            this.label5.Text = "Hasta Doğum Yeri";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(155, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 68;
            this.label4.Text = "Hasta Cinsiyeti";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(165, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 67;
            this.label3.Text = "Hasta Soyadı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(191, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "Hasta Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(194, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 65;
            this.label1.Text = "Hasta TC";
            // 
            // kayıt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(792, 639);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textAdress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hastaDogumTrh);
            this.Controls.Add(this.comboboxKan);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textPosta);
            this.Controls.Add(this.textTel);
            this.Controls.Add(this.texthstAnne);
            this.Controls.Add(this.texthstBaba);
            this.Controls.Add(this.comboboxDogumyeri);
            this.Controls.Add(this.textCinsiyeti);
            this.Controls.Add(this.texthastaSoyadi);
            this.Controls.Add(this.texthastaAdi);
            this.Controls.Add(this.textTc);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "kayıt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "kayıt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.kayıt_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox textPass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RichTextBox textAdress;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox hastaDogumTrh;
        private System.Windows.Forms.ComboBox comboboxKan;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textPosta;
        private System.Windows.Forms.MaskedTextBox textTel;
        private System.Windows.Forms.TextBox texthstAnne;
        private System.Windows.Forms.TextBox texthstBaba;
        private System.Windows.Forms.ComboBox comboboxDogumyeri;
        private System.Windows.Forms.ComboBox textCinsiyeti;
        private System.Windows.Forms.TextBox texthastaSoyadi;
        private System.Windows.Forms.TextBox texthastaAdi;
        private System.Windows.Forms.MaskedTextBox textTc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}