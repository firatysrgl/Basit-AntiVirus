🛡️ Basit Antivirüs Simülasyonu (C#)

Bu proje, imza tabanlı (signature-based) virüs tespit yönteminin nasıl çalıştığını göstermek amacıyla C# ile geliştirilmiş, eğitim amaçlı bir konsol uygulamasıdır.



Uygulama, belirli bir hedef klasörü tarar, dosyaların içeriklerini okur ve veritabanında tanımlı olan "zararlı imza" ile eşleşme arar.



🚀 Özellikler

Dizin Tarama: Hedef klasördeki (C:\\TestKlasoru) tüm dosyaları listeler.



İmza Analizi: Dosya içeriklerini okuyarak tanımlanmış zararlı string ifadesini arar.



Otomatik Temizleme: Zararlı imza tespit edilen dosyaları otomatik olarak siler (karantina/temizleme simülasyonu).



Görsel Geri Bildirim: Konsol ekranında güvenli dosyalar için yeşil, tehditler için kırmızı renkli uyarılar verir.



⚙️ Nasıl Çalışır?

Antivirüs yazılımlarının en temel çalışma prensibi olan "İmza Eşleştirme" mantığını kullanır.



Program çalıştırıldığında C:\\TestKlasoru dizinine erişir.



Her bir dosyanın içeriğini (byte/text) okur.



Eğer dosya içeriğinde VIRUS\_IMZASI\_X99\_BU\_DOSYA\_TEHLIKELI metni geçiyorsa, bu dosya virüslü olarak işaretlenir.



Tespit edilen dosya sistemden silinir.



🧪 Nasıl Test Edilir? (Kurulum)

Bu projeyi test etmek için bilgisayarınızda aşağıdaki ortamı hazırlamanız gerekir:



Klasörü Oluşturun: Bilgisayarınızın C: sürücüsünde TestKlasoru adında bir klasör açın.



Yol: C:\\TestKlasoru



Zararlı Dosya Oluşturun (Simülasyon): Bu klasörün içine virus.txt adında bir metin belgesi oluşturun ve içine sadece şu kodu yapıştırıp kaydedin:



Plaintext



VIRUS\_IMZASI\_X99\_BU\_DOSYA\_TEHLIKELI

Temiz Dosya Oluşturun: Aynı klasöre notlar.txt adında başka bir dosya oluşturun ve içine rastgele güvenli metinler (örneğin: "Alışveriş listesi") yazın.



Programı Çalıştırın: Projeyi derleyin ve çalıştırın. Program virus.txt dosyasını tespit edip silecek, notlar.txt dosyasına dokunmayacaktır.



💻 Kod Yapısı

Proje tek bir Program.cs dosyasından oluşur ve temel System.IO kütüphanelerini kullanır.



Directory.GetFiles: Klasördeki dosyaları bulmak için.



File.ReadAllText: Dosya içeriğini analiz etmek için.



File.Delete: Tehdidi ortadan kaldırmak için.



📷 Ara Yüz Ekranı









⚠️ Yasal Uyarı

Bu yazılım sadece eğitim ve demonstrasyon amaçlıdır. Gerçek bir güvenlik yazılımı değildir ve sisteminizi gerçek dünyadaki tehditlere (malware, trojan, ransomware vb.) karşı korumaz. Sadece if-else ve dosya işlemleri mantığını kavramak için tasarlanmıştır.



👤 Geliştirici



Fırat Yunus Yaşaroğlu



📧 Email: firat9041@gmail.com



🔗 GitHub: https://github.com/firatysrgl



🔗 LinkedIn: https://www.linkedin.com/in/firat-yunus-yasaroglu/

