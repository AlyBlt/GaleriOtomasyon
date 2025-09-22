# Galeri Otomasyon Uygulaması

Bu C# konsol uygulaması, basit bir **galeri otomasyon sistemini** simüle eder. Kullanıcılar araçları kiralayabilir, teslim edebilir, listeleyebilir ve yeni araç ekleyip silebilir. 

---

## Özellikler

- Araba kiralama ve iade işlemleri
- Galerideki ve kiradaki arabaları listeleme
- Yeni araba ekleme ve silme
- Konsol menüsü üzerinden kolay kullanım
- Tarih-saat bilgisi ile profesyonel görünüm  
- Temiz menü arayüzü (`Console.Clear()` desteği)  

---

## Uygulama Menüsü

Uygulama açıldığında karşınıza aşağıdaki gibi bir menü gelir:

Galeri Otomasyon Sistemi
-------------------------
1. Araba Kirala
2. Araba Teslim Al
3. Kiradaki Arabaları Listele
4. Galerideki Arabaları Listele
5. Tüm Arabaları Listele
6. Kiralama İptali
7. Araba Ekle
8. Araba Sil
9. Bilgileri Göster

Uygulamadan çıkış yapmak için 0'a basılır. Herhangi bir aşamada uygulamadan menü seçimine gelmek için X'e basılır.
Her işlem sonunda konsolu temizlemek için seçenek sunulur. İsteğe bağlı olarak konsol temizlenip ya da temizlenmeden menü seçimine gidilir.

Tüm işlemler kullanıcı dostu bir konsol arayüzüyle gerçekleştirilir. Menüde her zaman güncel **tarih ve saat** görüntülenir.

---

## Proje Yapısı

| Dosya / Klasör             | Açıklama                                              |
|----------------------------|-------------------------------------------------------|
| `Program.cs`               | Uygulamanın giriş noktası (Main fonksiyonu)           |
| `Araba.cs`                 | Araba sınıfı ve temel özellikleri (Marka, Model vb.)  |
| `Galeri.cs`                | Kiralama, teslim, silme gibi işlemleri yöneten sınıf  |
| `Genel.cs`                 | Yardımcı metotlar                                     |
| `GaleriUygulamasiAB.sln`   | Visual Studio çözüm dosyası                           |
| `bin/`, `obj/`, `.vs/`     | Derleme ve proje ortam dosyaları (ignore edilir)      |


---

## Nasıl Çalıştırılır?

1. GitHub üzerinden bu repoyu klonlayın.
  [GitHub Repository Linki](https://github.com/AlyBlt/GaleriOtomasyon.git)
2. Visual Studio ile projeyi açın.









