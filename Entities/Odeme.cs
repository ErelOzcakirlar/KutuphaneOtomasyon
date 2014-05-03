using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Odeme
    {
        public DateTime Tarih { get; set; }
        public String Adi { get; set; }
        public String Soyadi { get; set; }
        public String Aciklama { get; set; }
        public Decimal Tutar { get; set; }
        public String OdemeTipi { get; set; }

        public Odeme(DateTime tarih, String adi, String soyadi, String aciklama, Decimal tutar, String odemeTipi)
        {
            this.Tarih = tarih;
            this.Adi = adi;
            this.Soyadi = soyadi;
            this.Aciklama = aciklama;
            this.Tutar = tutar;
            this.OdemeTipi = odemeTipi;
        }
        public override string ToString()
        {
            return Tarih.ToShortDateString() + " - " + Adi + " " + Soyadi + " - " + Aciklama + " " + Tutar.ToString() + " TL " + OdemeTipi;
        }
    }
}
