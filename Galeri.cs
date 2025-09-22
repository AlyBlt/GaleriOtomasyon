using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleriUygulamasiAB
{
    internal class Galeri
    {

        public List<Araba> Arabalar = new List<Araba>();

        public Galeri()
        {
            SahteVeriGir();
        }


        public void ArabaKirala(string plaka, int sure)
        {
            Araba a = this.Arabalar.FirstOrDefault(a => a.Plaka == plaka.ToUpper());
            if (a!= null && a.Durum==Durum.Galeride)
            {
                a.Durum = Durum.Kirada;
                a.KiralamaSureleri.Add(sure);
            }
            
        }
        public void ArabaTeslimAl(string plaka)
        {
            Araba a = this.Arabalar.FirstOrDefault(a => a.Plaka == plaka.ToUpper());
            if (a != null && a.Durum == Durum.Kirada)
            {
                a.Durum = Durum.Galeride;
                
            }

        }
        public void KiralamaIptal(string plaka)
        {
            Araba a = this.Arabalar.FirstOrDefault(a => a.Plaka == plaka.ToUpper());
            if (a != null && a.Durum == Durum.Kirada)
            {
                a.Durum = Durum.Galeride;
                a.KiralamaSureleri.RemoveAt(a.KiralamaSureleri.Count - 1);

            }

        }

        public int GaleridekiAracSayisi
        {

            get { return this.Arabalar.Count(a => a.Durum == Durum.Galeride); }
        }

        public int ToplamAracSayisi
        {
            get { return this.Arabalar.Count; }
        }
        public int KiradakiAracSayisi
        {
            get { return this.Arabalar.Count(t => t.Durum == Durum.Kirada); }
        }
        public int ToplamAracKiralamaSuresi
        {
            get { return this.Arabalar.Sum(a => a.KiralamaSureleri.Sum()); }
        }

        public int ToplamAracKiralamaAdedi
        {
            get { return this.Arabalar.Sum(a => a.KiralamaSayisi); }
        }

        public decimal Ciro
        {
            get { return this.Arabalar.Sum(a => a.ToplamKiralamaSuresi * a.KiralamaBedeli); }
        }

        public void ArabaEkle(string plaka, string marka, ArabaTipi arabaTipi, decimal kiralamaBedeli) 
        {
            Araba a = new Araba(plaka, marka, arabaTipi, kiralamaBedeli);
            this.Arabalar.Add(a);
        }

        public void ArabaSil(string plaka)
        {
            Araba a = this.Arabalar.Where(x => x.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null && a.Durum == Durum.Galeride)
            {
                this.Arabalar.Remove(a);
            }
        }

        public void SahteVeriGir()
        {
            ArabaEkle("34arb3434", "FIAT", ArabaTipi.Sedan, 70);
            ArabaEkle("35arb3535", "KIA", ArabaTipi.SUV, 60);
            ArabaEkle("34us2342", "OPEL",ArabaTipi.Hatchback, 50);

        }
    }
}
