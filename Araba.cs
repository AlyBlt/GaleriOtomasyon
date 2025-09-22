using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaleriUygulamasiAB
{
    public enum Durum
    {
        Galeride,
        Kirada
    }

    public enum ArabaTipi
    {
        SUV = 1,
        Hatchback = 2,
        Sedan = 3
    }
    internal class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public ArabaTipi ArabaTipi { get; set; }
        public decimal KiralamaBedeli {  get; set; }
        public Durum Durum {  get; set; }
       


        public List<int>KiralamaSureleri=new List<int>();

        public Araba(string plaka, string marka, ArabaTipi arabaTipi, decimal kiralamaBedeli)
        {
            this.Plaka = plaka.ToUpper();
            this.Marka = marka.ToUpper();
            this.ArabaTipi = arabaTipi;
            this.KiralamaBedeli = kiralamaBedeli;
            this.Durum = Durum.Galeride;

        }

        public int KiralamaSayisi
        {
            get { return this.KiralamaSureleri.Count; }

        }

        public int ToplamKiralamaSuresi
        {
            get
            {

                return this.KiralamaSureleri.Sum();
            }
        }


        

    }

}
