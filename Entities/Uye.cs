using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Uye : Bilesen
    {
        public String Soyadi { get; set; }
        public String TCKimlik { get; set; }
        public String Telefon { get; set; }
        public String Adres { get; set; }
        public DateTime UyelikTarihi { get; set; }
        public String Display { get { return this.ToString(); } }

        public Uye(int id, string adi, string soyadi, string tc, DateTime tarih)
            : base(id, adi)
        {
            this.Soyadi = soyadi;
            this.TCKimlik = tc;
            this.UyelikTarihi = tarih;
        }
        public Uye(string adi, string soyadi, string tc, DateTime tarih)
            : base(adi)
        {
            this.Soyadi = soyadi;
            this.TCKimlik = tc;
            this.UyelikTarihi = tarih;
        }
        public override string ToString()
        {
            return this.ID.ToString() + ", " + this.Adi + " " + this.Soyadi;
        }
    }
}
