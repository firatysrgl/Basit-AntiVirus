using System;
using System.IO;
using System.Threading;

namespace BasitAntivirus
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konsol başlığını ve rengini ayarla (Güven verici mavi renk)
            Console.Title = "Güvenlik Duvarı & Antivirüs";
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("     ANTİVİRÜS TARAMA MODÜLÜ BAŞLATILIYOR...    ");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            // 1. AYARLAR
            // Virüsün hedef aldığı klasör ve virüsün içine koyduğu gizli şifre (İmza)
            string taranacakKlasor = @"C:\TestKlasoru";
            string arananImza = "VIRUS_IMZASI_X99_BU_DOSYA_TEHLIKELI"; // Virüstekiyle AYNISI olmalı!

            Console.WriteLine($"Hedef Klasör: {taranacakKlasor}");
            Console.WriteLine("İmza Veritabanı Yüklendi. Tarama başlıyor...\n");

            // Biraz bekle (gerçekçi olsun diye)
            Thread.Sleep(1500);

            // 2. KLASÖR KONTROLÜ
            if (Directory.Exists(taranacakKlasor))
            {
                // Klasördeki tüm dosyaları bul
                string[] dosyalar = Directory.GetFiles(taranacakKlasor);
                int tehditSayisi = 0;

                foreach (string dosya in dosyalar)
                {
                    try
                    {
                        // Dosyanın ismini al
                        string dosyaAdi = Path.GetFileName(dosya);
                        Console.Write($"Taranıyor: {dosyaAdi} ... ");

                        // DOSYA İÇERİĞİNİ OKU
                        string icerik = File.ReadAllText(dosya);

                        // 3. İMZA KONTROLÜ (Signature Matching)
                        if (icerik.Contains(arananImza))
                        {
                            // VİRÜS BULUNDU!
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" [TEHDİT TESPİT EDİLDİ!]");
                            Console.WriteLine($"   -> Virüs İmzası: {arananImza}");

                            // SİLME İŞLEMİ
                            File.Delete(dosya);
                            Console.WriteLine("   -> Dosya başarıyla SİLİNDİ ve Karantinaya alındı.");
                            tehditSayisi++;
                        }
                        else
                        {
                            // TEMİZ DOSYA
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" [TEMİZ]");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n   Hata: Dosya okunamadı. {ex.Message}");
                    }

                    // Rengi tekrar maviye döndür
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Thread.Sleep(500); // Her dosya arasında yarım saniye bekle (görsellik için)
                }

                Console.WriteLine("\n------------------------------------------------");
                if (tehditSayisi > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"TARAMA BİTTİ: {tehditSayisi} adet virüs temizlendi. Sistem artık güvenli.");
                }
                else
                {
                    Console.WriteLine("TARAMA BİTTİ: Hiçbir tehdit bulunamadı.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Uyarı: Taranacak klasör bulunamadı. Önce virüsü çalıştırın!");
            }

            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}