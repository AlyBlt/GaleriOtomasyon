using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GaleriUygulamasiAB
{
    internal class Genel
    {
        public static string? PlakaKontrol(string mesaj)
        {

            while (true)
            {
                Console.Write(mesaj);
                string plaka = Console.ReadLine().ToUpper();

                if (plaka == "X") return null;



                if (!Regex.IsMatch(plaka, @"^[0-9]{2}[A-Z]{2,3}[0-9]{2,4}$") || plaka.Length < 7)
                {


                    Console.WriteLine("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");
                    continue;


                }

                return plaka;

            }
        }

        public static bool KiradaArabaVarMi(Galeri otoGaleri)
        {
            if (otoGaleri.KiradakiAracSayisi == 0)
            { Console.WriteLine("Kirada hiç araba yok."); }
            return otoGaleri.KiradakiAracSayisi > 0;
        }

        public static bool GalerideArabaVarMi(Galeri otoGaleri)
        {
            if (otoGaleri.GaleridekiAracSayisi == 0)
            { Console.WriteLine("Tüm araçlar kirada."); }
            return otoGaleri.GaleridekiAracSayisi > 0;
        }


        public static bool ArabaGalerideMi(Galeri otoGaleri, string plaka)
        {
            Araba secilenAraba = otoGaleri.Arabalar.Find(a => a.Plaka == plaka.ToUpper());

            if (secilenAraba == null)
            {
                Console.WriteLine("Galeriye ait bu plakada bir araba yok. Tekrar deneyin.");
                return false;
            }

            if (secilenAraba.Durum==Durum.Kirada)
            {
                Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                return false; 
            }

                      
            return true;
        }

        public static bool ArabaKiradaMi(Galeri otoGaleri, string plaka)
        {
            Araba secilenAraba = otoGaleri.Arabalar.Find(a => a.Plaka == plaka.ToUpper());
            if (secilenAraba == null)
            {
                Console.WriteLine("Galeriye ait bu plakada bir araba yok. Tekrar deneyin.");
                return false;
            }

            if (secilenAraba.Durum == Durum.Galeride)
            {
                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                return false;
            }

           
            return true;
        }

        

    }



}

