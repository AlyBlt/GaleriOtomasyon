using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace GaleriUygulamasiAB
{
    internal class Program
    {
        //NOT: Burada nesneyi ilk önce static oluşturdum (static Galeri OtoGaleri = new Galeri();) -->
        //çünkü program class'ında Main ve diğer tüm metotlar static idi (static void Menu(), static void SecimAl()...vs).
        // Bu şu demek: static bir metodun içinde, yalnızca static üyeleri kullanabilirsin.
        //Diğer bir çözüm yolu: Eğer bir alan (OtoGaleri) static değilse, bu alana instance(nesne) oluşturmadan erişemeyiz.
        //Daha büyük, OOP temelli uygulama yapacaksak, test edilebilir ve esnek yapı istiyorsak instance (non-static) yapı kullanmak daha faydalı.
        //Instance yapıda tüm metotlar artık static void yerine void oluyor.

        //Static yapıda, SecimAl(), Menu(), ArabaKirala()...vs tüm metotlar static void yapıda (static void SecimAl()).
        //Static yapı şöyle:
        // static Galeri OtoGaleri = new Galeri();
        // static void Main(string[] args)
        // {
        //   Uygulama();
        // }
        // static void Uygulama()
        //{
        //    Menu();
        //    SecimAl();
        //}



        //Diğer çözüm yolu Main ve diğer metotları instance yapmak.Aşağıdaki gibi:

        Galeri OtoGaleri = new Galeri();
        
        static void Main(string[] args)
        {
           Program p = new Program();  // nesne oluştur
           p.Uygulama();               // artık non-static metotlar kullanılabilir (instance metotları çalıştır)
        }


        void Uygulama()
        {
            Menu();
            SecimAl();

        }

        void BaslikYazdir(string baslik) 
        {
            Console.WriteLine("\n-"+ baslik +"-\n");
        }

        void Menu()
        {
            Console.WriteLine("\nGaleri Otomasyon");
            Console.WriteLine($"\nTarih: {DateTime.Now.ToShortDateString()}  Saat: {DateTime.Now.ToLongTimeString()}\n");
            Console.WriteLine("1- Araba Kirala (K)");
            Console.WriteLine("2- Araba Teslim Al (T)");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)");
            Console.WriteLine("4- Galerideki Arabaları Listele (M)");
            Console.WriteLine("5- Tüm Arabaları Listele (A)");
            Console.WriteLine("6- Kiralama İptali (I)");
            Console.WriteLine("7- Araba Ekle (Y)");
            Console.WriteLine("8- Araba Sil (S)");
            Console.WriteLine("9- Bilgileri Göster (G)");
            Console.WriteLine("\nUygulamadan çıkmak için sıfıra (0) basın.");
            Console.WriteLine("\nHerhangi bir aşamada menü seçimine dönebilmek için X'e basın.");
            

        }

        void SecimAl()
        {
            int sayac = 1;

            while (true)
            {
                

                Console.Write("\nSeçiminiz: ");
                string secim = Console.ReadLine().ToUpper();
                

                    switch (secim)
                    {
                        case "1":
                        case "K":
                            ArabaKirala();
                            break;
                        case "2":
                        case "T":
                            ArabaTeslimAl();
                            break;
                        case "3":
                        case "R":
                            KiradaArabaListele();
                            break;
                        case "4":
                        case "M":
                            GalerideArabaListele();
                            break;
                        case "5":
                        case "A":
                            TumArabaListele();
                            break;
                        case "6":
                        case "I":
                            KiralamaIptali();
                            break;
                        case "7":
                        case "Y":
                            ArabaEkle();
                            break;
                        case "8":
                        case "S":
                            ArabaSil();
                            break;
                        case "9":
                        case "G":
                            BilgileriGoster();
                            break;
                        case "X":
                            continue;
                        case "0":
                        Environment.Exit(0);
                        break;
                        default:
                            sayac++;
                            break;
                    }
                

                if (sayac > 10)
                {   Console.WriteLine("Çok fazla hatalı giriş yapıldı. Uygulama sonlandırılıyor."); 
                    Environment.Exit(0); 
                }

            }
            
        }
         void ArabaKirala()
        {
            Araba secilenAraba = null;

            BaslikYazdir("Araba Kirala"); 

            if (!Genel.GalerideArabaVarMi(OtoGaleri))
            {
                TemizlemeSecimi();
                return;
            }

            // PLAKA GİRİŞ VE KONTROL DÖNGÜSÜ
            while (true)
            {
                string plaka = Genel.PlakaKontrol("Kiralanacak arabanın plakası: ");
                if (plaka == null) return;

                secilenAraba = OtoGaleri.Arabalar.Find(a => a.Plaka == plaka);

                if (Genel.ArabaGalerideMi(OtoGaleri, plaka))
                {
                   
                    break;
                }
                else
                {
                    continue;
                }
                
            }

            // KİRALAMA SÜRESİ GİRİŞİ
            int sure;
            while (true)
            {
                Console.Write("Kiralanma süresi (saat): ");
                string giris = Console.ReadLine();
                if (giris.ToUpper() == "X")
                    return;

                if (int.TryParse(giris, out sure) && sure > 0)
                    break;

                Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
            }

            // KİRALA
            OtoGaleri.ArabaKirala(secilenAraba.Plaka, sure);
            Console.WriteLine($"\n{secilenAraba.Plaka} plakalı araba {sure} saatliğine kiralandı.");
            TemizlemeSecimi();
                       
        }
            
                   


         void ArabaTeslimAl()
        {
            Araba secilenAraba = null;
            string plaka;
            BaslikYazdir("Araba Teslim Al"); 

            if (!Genel.KiradaArabaVarMi(OtoGaleri))
            {
                TemizlemeSecimi();
                return;
            }

            while (true)
            {
               
                plaka = Genel.PlakaKontrol("Teslim edilecek arabanın plakası: ");
                if (plaka == null) return;


                secilenAraba = OtoGaleri.Arabalar.Find(a => a.Plaka == plaka);


                if (Genel.ArabaKiradaMi(OtoGaleri, plaka))
                {
                   
                    break;
                }
                else
                {
                    continue;
                }
 
            }
            OtoGaleri.ArabaTeslimAl(plaka);
            Console.WriteLine("\nAraba galeride beklemeye alındı.");
            TemizlemeSecimi();

        }

         void KiradaArabaListele()
        {
            
            BaslikYazdir("Kiradaki Arabalar"); 
            

            if (!OtoGaleri.Arabalar.Any(a => a.Durum == Durum.Kirada))
            {
                Console.WriteLine("Listelenecek araç yok.");
                TemizlemeSecimi();
                return;
            }

            Console.WriteLine("Plaka".PadRight(12) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum");
            Console.WriteLine("----------------------------------------------------------------------");

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Durum == Durum.Kirada)
                {
                    Console.WriteLine(item.Plaka.PadRight(12) + item.Marka.PadRight(12) + item.KiralamaBedeli.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralamaSayisi.ToString().PadRight(12) + item.Durum.ToString());
                }
            }

            TemizlemeSecimi();
        }

         void GalerideArabaListele()
        {
            
            BaslikYazdir("Galerideki Arabalar");
           
            if (!OtoGaleri.Arabalar.Any(a => a.Durum == Durum.Galeride))
            {
                Console.WriteLine("Listelenecek araç yok.");
                TemizlemeSecimi();
                return;
            }

            Console.WriteLine("Plaka".PadRight(12) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum");
            Console.WriteLine("----------------------------------------------------------------------");

            foreach (Araba item in OtoGaleri.Arabalar)
            {
                if (item.Durum == Durum.Galeride)
                {
                    Console.WriteLine(item.Plaka.PadRight(12) + item.Marka.PadRight(12) + item.KiralamaBedeli.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralamaSayisi.ToString().PadRight(12) + item.Durum.ToString());
                }
            }
            TemizlemeSecimi();
        }

        void TumArabaListele()
        {
            BaslikYazdir("Tüm Arabalar");
         
            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
                TemizlemeSecimi();
                return;
            }

            Console.WriteLine("Plaka".PadRight(12) + "Marka".PadRight(12) + "K. Bedeli".PadRight(12) + "Araba Tipi".PadRight(12) + "K. Sayısı".PadRight(12) + "Durum");
            Console.WriteLine("----------------------------------------------------------------------");
            
            foreach (Araba item in OtoGaleri.Arabalar)
            {
                Console.WriteLine(item.Plaka.PadRight(12) + item.Marka.PadRight(12) + item.KiralamaBedeli.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralamaSayisi.ToString().PadRight(12) + item.Durum.ToString());
            }
            TemizlemeSecimi();
        }

        void KiralamaIptali()
        {
            Araba secilenAraba = null;
            string plaka;

            BaslikYazdir("Kiralama İptali"); 

            if (!Genel.KiradaArabaVarMi(OtoGaleri))
            {
                TemizlemeSecimi();
                return;
            }

            while (true)
            {

                plaka = Genel.PlakaKontrol("Kiralaması iptal edilecek arabanın plakası: ");
                if (plaka == null) return;

                secilenAraba = OtoGaleri.Arabalar.Find(a => a.Plaka == plaka);

                if (Genel.ArabaKiradaMi(OtoGaleri, plaka))
                {
                    break;
                }

                else
                {
                    continue;
                }
            }

                    OtoGaleri.KiralamaIptal(plaka);
                    Console.WriteLine("\nİptal gerçekleştirildi.");
                    TemizlemeSecimi();

        }

         void ArabaEkle()
        {
            Araba secilenAraba = null;
            string plaka;
            string marka;
            decimal fiyat;
            string arabaTipi;

            BaslikYazdir("Araba Ekle"); 
           
            while (true)
            {

                plaka = Genel.PlakaKontrol("Eklenecek arabanın plakası: ");
                if (plaka == null) return;

                secilenAraba = OtoGaleri.Arabalar.Find(a => a.Plaka == plaka);

                if (secilenAraba != null)
                {
                    Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                    continue;
                }
                else
                {
                    break;
                }
            }
            
            while (true)
            {
                
                Console.Write("Marka: ");
                marka = Console.ReadLine().ToUpper();
               

                if (!int.TryParse(marka,out int sayi))
                {
                    if (marka == "X") return;
                    else break;
                }
                else
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    continue;
                }

            }
            while (true)
            {

                Console.Write("Kiralama Bedeli: ");
                string kiraBedeli = Console.ReadLine();
                if (kiraBedeli.ToUpper() == "X") return;

                if (decimal.TryParse(kiraBedeli, out fiyat))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    continue;
                }

            }

            bool ilkSoru = true;
            while (true)
            {
                int secim;
                Console.Write("Araba Tipi: ");
                if (ilkSoru)
                {
                    Console.WriteLine("\nSUV için 1");
                    Console.WriteLine("Hatchback için 2");
                    Console.WriteLine("Sedan için 3");
                   
                    ilkSoru = false;
                    continue;
                }
                arabaTipi = Console.ReadLine();
                if (arabaTipi.ToUpper() == "X") return;

                if (!int.TryParse(arabaTipi, out secim) || secim < 1 || secim > 3)
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                    continue;
                }
               

                // Enum.Parse ile string/number'dan enum'a çevir
                ArabaTipi secilenTip = (ArabaTipi)secim;

                OtoGaleri.ArabaEkle(plaka, marka, secilenTip, fiyat);
                Console.WriteLine("\nAraba başarılı bir şekilde eklendi.");
                break;

                //else 
                //{
                //    if (arabaTipi=="1")
                //    {
                //        OtoGaleri.ArabaEkle(plaka, marka, ArabaTipi.SUV, fiyat);
                //        Console.WriteLine("Araba başarılı bir şekilde eklendi.");
                //        break;
                //    }
                //    if (arabaTipi == "2")
                //    {
                //        OtoGaleri.ArabaEkle(plaka, marka, ArabaTipi.Hatchback, fiyat);
                //        Console.WriteLine("Araba başarılı bir şekilde eklendi.");
                //        break;
                //    }
                //    if (arabaTipi == "3")
                //    {
                //        OtoGaleri.ArabaEkle(plaka, marka, ArabaTipi.Sedan, fiyat);
                //        Console.WriteLine("\nAraba başarılı bir şekilde eklendi.");
                //        break;
                //    }
                //}
                
            }
            TemizlemeSecimi();
        }

        void ArabaSil()
        {
            
            Araba secilenAraba = null;
            string plaka;

            BaslikYazdir("Araba Sil");
            Console.WriteLine("Not: Kiradaki arabalar silinemez.\n");
            if (!Genel.GalerideArabaVarMi(OtoGaleri))
            {
                TemizlemeSecimi();
                return;
            }

            while (true)
            {

                plaka = Genel.PlakaKontrol("Silmek istediğiniz arabanın plakası: ");
                if (plaka == null) return;

                secilenAraba = OtoGaleri.Arabalar.Find(a => a.Plaka == plaka);

                if (Genel.ArabaGalerideMi(OtoGaleri, plaka))
                {

                    break;
                }
                else
                {
                    continue;
                }
            }

                OtoGaleri.ArabaSil(plaka);
                Console.WriteLine("\nAraba silindi.");
                TemizlemeSecimi();

        }

        void BilgileriGoster()
        {

                BaslikYazdir("Galeri Bilgileri");
                Console.WriteLine("Toplam araba sayısı: " + OtoGaleri.ToplamAracSayisi);
                Console.WriteLine("Kiradaki araba sayısı: " + (OtoGaleri.ToplamAracSayisi - OtoGaleri.GaleridekiAracSayisi));
                Console.WriteLine("Bekleyen araba sayısı: " + OtoGaleri.GaleridekiAracSayisi);
                Console.WriteLine("Toplam araba kiralama süresi: " + OtoGaleri.ToplamAracKiralamaSuresi);
                Console.WriteLine("Toplam araba kiralama adedi: " + OtoGaleri.ToplamAracKiralamaAdedi);
                Console.WriteLine("Ciro: " + OtoGaleri.Ciro);

        }

         void TemizlemeSecimi()
        {
            Console.Write("\nEkranı temizlemek için Z tuşuna basın. Menü seçimine dönmek için ENTER yeterlidir: ");
            string secim = Console.ReadLine().ToUpper();

            if (secim == "Z")
            {
                Console.Clear();
                Menu();

            }
        }























    }

}
