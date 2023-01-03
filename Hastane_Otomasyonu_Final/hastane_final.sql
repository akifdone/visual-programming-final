-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 03 Oca 2023, 12:29:09
-- Sunucu sürümü: 10.4.27-MariaDB
-- PHP Sürümü: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `hastane_final`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `acil`
--

CREATE TABLE `acil` (
  `acil_id` int(11) NOT NULL,
  `acil_doktor_id` int(11) NOT NULL,
  `acil_aciklama` varchar(50) NOT NULL,
  `acil_alan` varchar(50) NOT NULL,
  `acil_hasta_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `bekleyenhasta`
--

CREATE TABLE `bekleyenhasta` (
  `bekleyen_id` int(11) NOT NULL,
  `bekleyen_klinik_id` int(11) NOT NULL,
  `bekleyen_doktor_id` int(11) NOT NULL,
  `bekleyen_hasta_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `bekleyenhasta`
--

INSERT INTO `bekleyenhasta` (`bekleyen_id`, `bekleyen_klinik_id`, `bekleyen_doktor_id`, `bekleyen_hasta_id`) VALUES
(1, 1, 3, 1),
(2, 4, 3, 1),
(3, 1, 3, 1),
(4, 6, 3, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `doktorlar`
--

CREATE TABLE `doktorlar` (
  `doktor_id` int(11) NOT NULL,
  `kullanici_adi` varchar(50) NOT NULL,
  `sifre` int(11) NOT NULL,
  `doktor_adi_soyadi` varchar(50) NOT NULL,
  `doktor_klinik_id` int(11) NOT NULL,
  `doktor_tc` varchar(50) NOT NULL,
  `doktor_kan` varchar(50) NOT NULL,
  `doktor_dtarih` varchar(50) NOT NULL,
  `doktor_cep` varchar(50) NOT NULL,
  `doktor_eposta` varchar(50) NOT NULL,
  `doktor_adres` varchar(50) NOT NULL,
  `doktor_cinsiyet` varchar(50) NOT NULL,
  `doktor_alan` varchar(50) NOT NULL,
  `doktor_klink` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `doktorlar`
--

INSERT INTO `doktorlar` (`doktor_id`, `kullanici_adi`, `sifre`, `doktor_adi_soyadi`, `doktor_klinik_id`, `doktor_tc`, `doktor_kan`, `doktor_dtarih`, `doktor_cep`, `doktor_eposta`, `doktor_adres`, `doktor_cinsiyet`, `doktor_alan`, `doktor_klink`) VALUES
(3, 'akif', 12345, 'Mehmet Akif Döne1', 2, '41', 'Arh +', '01.09.2003', '(530)    -', 'gebze', 'aa', 'Kadın', 'Kırmızı Alan', ''),
(5, 'burcu', 12345, 'Burcu Patavatsız', 4, '10', 'Arh +', '29.09.2003', '530', 'burcu_ankara', 'ankara', 'belirsiz', 'Kırmızı Alan', ''),
(6, 'emre', 12345, 'Emre Uzun', 2, '81', 'Arh +', '01.09.2003', '530', 'emre_uzun', 'gebze', 'erkek', 'Kırmızı Alan', ''),
(7, 'ali', 12345, 'Yücel Fil', 3, '61', 'Arh +', '01.09.2003', '530', 'yücel_fil', 'trabzon', 'erkek', 'Yeşil Alan', ''),
(8, 'taha', 12345, 'Taha Karakaya', 6, '16', 'Arh +', '01.09.2003', '530', 'taha_karakaya', 'bursa', 'erkek', 'Sarı Alan', ''),
(9, 'nursel', 12345, 'Nursel Otlakçı', 7, '34', 'Arh +', '01.09.2003', '530', 'nursel_otlakci', 'istanbul', 'Kadın', 'Sarı Alan', ''),
(10, 'fatma', 12345, 'Fatma Onay', 5, '52', 'Arh +', '01.09.2003', '530', 'fatma_onay', 'odu', 'Kadın', 'Yeşil Alan', ''),
(11, 'kamuran', 12345, 'Kamuran Akbaş', 2, '08', 'Arh +', '01.09.2003', '530', 'kamuran_akbas', 'artvin', 'Kadın', 'Sarı Alan', '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hasta`
--

CREATE TABLE `hasta` (
  `hasta_id` int(11) NOT NULL,
  `hasta_tc` varchar(50) NOT NULL,
  `hasta_ad` varchar(50) NOT NULL,
  `hasta_soyad` varchar(50) NOT NULL,
  `hasta_cinsiyeti` varchar(50) NOT NULL,
  `hasta_kan` varchar(50) NOT NULL,
  `hasta_dogumYeri` varchar(50) NOT NULL,
  `hasta_dogumTarihi` varchar(50) NOT NULL,
  `hasta_babaAdi` varchar(50) NOT NULL,
  `hasta_anaAdi` varchar(50) NOT NULL,
  `hasta_tel` varchar(50) NOT NULL,
  `hasta_posta` varchar(50) NOT NULL,
  `hasta_parola` int(11) NOT NULL,
  `hasta_adres` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `hasta`
--

INSERT INTO `hasta` (`hasta_id`, `hasta_tc`, `hasta_ad`, `hasta_soyad`, `hasta_cinsiyeti`, `hasta_kan`, `hasta_dogumYeri`, `hasta_dogumTarihi`, `hasta_babaAdi`, `hasta_anaAdi`, `hasta_tel`, `hasta_posta`, `hasta_parola`, `hasta_adres`) VALUES
(1, '43243338516', 'Mehmet  Akif ', 'Döne', 'Erkek', 'Arh +', 'Rize', '01.09.2003', 'Selahattin', 'Ummehan', '(530) 647-2153', 'akif.dutge', 12345, 'gebze');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hasta_ilac`
--

CREATE TABLE `hasta_ilac` (
  `hasta_ilac_id` int(11) NOT NULL,
  `hasta_tahlil_id` int(11) NOT NULL,
  `hasta_ilac_adi` varchar(50) NOT NULL,
  `hasta_ilac_kul` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `hasta_ilac`
--

INSERT INTO `hasta_ilac` (`hasta_ilac_id`, `hasta_tahlil_id`, `hasta_ilac_adi`, `hasta_ilac_kul`) VALUES
(1, 1, 'Parol', 'günde 3 kez sabah akşam\nyatarken'),
(2, 2, 'Parol', 'asasas');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ilaclar`
--

CREATE TABLE `ilaclar` (
  `ilac_id` int(11) NOT NULL,
  `ilac_adi` varchar(50) NOT NULL,
  `ilac_fiyat` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `ilaclar`
--

INSERT INTO `ilaclar` (`ilac_id`, `ilac_adi`, `ilac_fiyat`) VALUES
(4, 'Parol', ''),
(5, 'Arveles', ''),
(6, 'B12', '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `iletisim`
--

CREATE TABLE `iletisim` (
  `iletisim_id` int(11) NOT NULL,
  `iletisim_ad` varchar(50) NOT NULL,
  `iletisim_soyad` varchar(50) NOT NULL,
  `iltisim_sikayet` varchar(50) NOT NULL,
  `iletisim_bilgileri` varchar(50) NOT NULL,
  `iletisim_kontrol` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `klinkler`
--

CREATE TABLE `klinkler` (
  `klinik_id` int(11) NOT NULL,
  `klinik_adi` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `klinkler`
--

INSERT INTO `klinkler` (`klinik_id`, `klinik_adi`) VALUES
(1, 'Beslenme ve Diyet.'),
(2, 'Beyin ve Sinir Cerrahisi.'),
(3, 'Check Up.'),
(4, 'Cildiye (Dermatoloji)'),
(5, 'Çocuk Sağlığı ve Hastalıkları'),
(6, 'Fizik Tedavi ve Rehabilitasyon.'),
(7, 'Kadın Doğum (Obstetri)'),
(8, 'Kulak Burun Boğaz (KBB)');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `lab`
--

CREATE TABLE `lab` (
  `lab_id` int(11) NOT NULL,
  `lab_tahlil_id` int(11) NOT NULL,
  `lab_test_id` int(11) NOT NULL,
  `kontrol` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `labsonuclar`
--

CREATE TABLE `labsonuclar` (
  `sonuc_id` int(11) NOT NULL,
  `sonuc_doktor_id` int(11) NOT NULL,
  `sonuc_tahlil_id` int(11) NOT NULL,
  `sonuc_test_adi` varchar(50) NOT NULL,
  `sonuc_hasta_adi` varchar(50) NOT NULL,
  `sonuc_aciklama` varchar(50) NOT NULL,
  `sonuc_tarih` varchar(50) NOT NULL,
  `kontrol` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `labsonuclar`
--

INSERT INTO `labsonuclar` (`sonuc_id`, `sonuc_doktor_id`, `sonuc_tahlil_id`, `sonuc_test_adi`, `sonuc_hasta_adi`, `sonuc_aciklama`, `sonuc_tarih`, `kontrol`) VALUES
(1, 1, 1, 'D vitamini', 'Mehmet  Akif  Döne', 'degerler normal', '29 Aralık 2022 Perşembe', 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `randevular`
--

CREATE TABLE `randevular` (
  `randevu_id` int(11) NOT NULL,
  `randevu_hasta_id` int(11) NOT NULL,
  `randevu_tarih` varchar(50) NOT NULL,
  `randevu_saat` varchar(50) NOT NULL,
  `randevu_klinik_id` int(11) NOT NULL,
  `randevu_doktor_id` int(11) NOT NULL,
  `iptal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `randevular`
--

INSERT INTO `randevular` (`randevu_id`, `randevu_hasta_id`, `randevu_tarih`, `randevu_saat`, `randevu_klinik_id`, `randevu_doktor_id`, `iptal`) VALUES
(10, 1, '3.01.2023', '08:00', 1, 9, 0),
(11, 1, '3.01.2023', '10:00', 6, 12, 0),
(12, 1, '3.01.2023', '09:30', 5, 11, 0),
(13, 1, '3.01.2023', '12:30', 1, 5, 0),
(14, 1, '3.01.2023', '14:00', 2, 5, 0),
(15, 1, '3.01.2023', '14:00', 3, 5, 0),
(28, 1, '3.01.2023', '08:00', 1, 3, 0),
(29, 1, '3.01.2023', '08:30', 1, 3, 0),
(30, 1, '3.01.2023', '09:00', 1, 3, 0),
(31, 1, '3.01.2023', '09:30', 1, 3, 0),
(34, 1, '3.01.2023', '10:30', 1, 3, 0),
(35, 1, '3.01.2023', '11:00', 1, 3, 0),
(37, 1, '3.01.2023', '08:30', 3, 3, 0),
(41, 1, '3.01.2023', '14:00', 1, 3, 0),
(42, 1, '3.01.2023', '08:00', 1, 6, 0),
(43, 1, '3.01.2023', '16:00', 3, 7, 0),
(44, 1, '3.01.2023', '15:00', 1, 3, 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `receteler`
--

CREATE TABLE `receteler` (
  `recete_id` int(11) NOT NULL,
  `recete_ilac_id` int(11) NOT NULL,
  `recete_doktor_id` int(11) NOT NULL,
  `recete_hasta_id` int(11) NOT NULL,
  `recete_tanı` varchar(50) NOT NULL,
  `recete_tahlil_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `receteler`
--

INSERT INTO `receteler` (`recete_id`, `recete_ilac_id`, `recete_doktor_id`, `recete_hasta_id`, `recete_tanı`, `recete_tahlil_id`) VALUES
(1, 0, 1, 1, 'üşütmüş', 1),
(2, 0, 3, 1, 'sıkıınıtı', 0),
(3, 0, 3, 1, 'durumu normal', 0),
(4, 0, 3, 1, 'bişe yok', 2);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `tahliller`
--

CREATE TABLE `tahliller` (
  `tahlil_id` int(11) NOT NULL,
  `tahlil_doktor_id` int(11) NOT NULL,
  `tahlil_hasta_id` int(11) NOT NULL,
  `tahlil_klinik_id` int(11) NOT NULL,
  `tahlil_test_id` int(11) NOT NULL,
  `kontrol` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `tahliller`
--

INSERT INTO `tahliller` (`tahlil_id`, `tahlil_doktor_id`, `tahlil_hasta_id`, `tahlil_klinik_id`, `tahlil_test_id`, `kontrol`) VALUES
(1, 1, 1, 0, 2, ''),
(2, 3, 1, 6, 2, '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `testler`
--

CREATE TABLE `testler` (
  `test_id` int(11) NOT NULL,
  `test_adi` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `testler`
--

INSERT INTO `testler` (`test_id`, `test_adi`) VALUES
(1, 'B12'),
(2, 'D vitamini'),
(3, 'Gebelik');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yönetici`
--

CREATE TABLE `yönetici` (
  `kullanici_id` int(11) NOT NULL,
  `kullanici_adi` varchar(50) NOT NULL,
  `kullanici_sifre` varchar(50) NOT NULL,
  `kullanici_adsoyad` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `yönetici`
--

INSERT INTO `yönetici` (`kullanici_id`, `kullanici_adi`, `kullanici_sifre`, `kullanici_adsoyad`) VALUES
(1, 'admin', '1234', 'Mehmet Akif Döne');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `acil`
--
ALTER TABLE `acil`
  ADD PRIMARY KEY (`acil_id`);

--
-- Tablo için indeksler `bekleyenhasta`
--
ALTER TABLE `bekleyenhasta`
  ADD PRIMARY KEY (`bekleyen_id`);

--
-- Tablo için indeksler `doktorlar`
--
ALTER TABLE `doktorlar`
  ADD PRIMARY KEY (`doktor_id`);

--
-- Tablo için indeksler `hasta`
--
ALTER TABLE `hasta`
  ADD PRIMARY KEY (`hasta_id`);

--
-- Tablo için indeksler `hasta_ilac`
--
ALTER TABLE `hasta_ilac`
  ADD PRIMARY KEY (`hasta_ilac_id`);

--
-- Tablo için indeksler `ilaclar`
--
ALTER TABLE `ilaclar`
  ADD PRIMARY KEY (`ilac_id`);

--
-- Tablo için indeksler `klinkler`
--
ALTER TABLE `klinkler`
  ADD PRIMARY KEY (`klinik_id`);

--
-- Tablo için indeksler `lab`
--
ALTER TABLE `lab`
  ADD PRIMARY KEY (`lab_id`);

--
-- Tablo için indeksler `labsonuclar`
--
ALTER TABLE `labsonuclar`
  ADD PRIMARY KEY (`sonuc_id`);

--
-- Tablo için indeksler `randevular`
--
ALTER TABLE `randevular`
  ADD PRIMARY KEY (`randevu_id`);

--
-- Tablo için indeksler `receteler`
--
ALTER TABLE `receteler`
  ADD PRIMARY KEY (`recete_id`);

--
-- Tablo için indeksler `tahliller`
--
ALTER TABLE `tahliller`
  ADD PRIMARY KEY (`tahlil_id`);

--
-- Tablo için indeksler `testler`
--
ALTER TABLE `testler`
  ADD PRIMARY KEY (`test_id`);

--
-- Tablo için indeksler `yönetici`
--
ALTER TABLE `yönetici`
  ADD PRIMARY KEY (`kullanici_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `acil`
--
ALTER TABLE `acil`
  MODIFY `acil_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Tablo için AUTO_INCREMENT değeri `bekleyenhasta`
--
ALTER TABLE `bekleyenhasta`
  MODIFY `bekleyen_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `doktorlar`
--
ALTER TABLE `doktorlar`
  MODIFY `doktor_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Tablo için AUTO_INCREMENT değeri `hasta`
--
ALTER TABLE `hasta`
  MODIFY `hasta_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `hasta_ilac`
--
ALTER TABLE `hasta_ilac`
  MODIFY `hasta_ilac_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `ilaclar`
--
ALTER TABLE `ilaclar`
  MODIFY `ilac_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `klinkler`
--
ALTER TABLE `klinkler`
  MODIFY `klinik_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tablo için AUTO_INCREMENT değeri `lab`
--
ALTER TABLE `lab`
  MODIFY `lab_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `labsonuclar`
--
ALTER TABLE `labsonuclar`
  MODIFY `sonuc_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `randevular`
--
ALTER TABLE `randevular`
  MODIFY `randevu_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- Tablo için AUTO_INCREMENT değeri `receteler`
--
ALTER TABLE `receteler`
  MODIFY `recete_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tablo için AUTO_INCREMENT değeri `tahliller`
--
ALTER TABLE `tahliller`
  MODIFY `tahlil_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `testler`
--
ALTER TABLE `testler`
  MODIFY `test_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `yönetici`
--
ALTER TABLE `yönetici`
  MODIFY `kullanici_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
