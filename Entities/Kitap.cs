using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kitap : Bilesen
    {
        # region Properties
        public int BasimYili { get; set; }
        public Yazar[] Author { get; set; }
        public Yayinevi Publisher { get; set; }
        public Kategori Category { get; set; }
        public int SayfaSayisi { get; set; }
        public bool KiralamaDurumu { get; set; }
        public bool HasarDurumu { get; set; }
        public Decimal Fiyat { get; set; }
        public String Kapak { get; set; }
        public String Ozet { get; set; }

        # endregion
        # region Constructors
        public Kitap(string adi, int basimYili, Yazar[] yazar, Yayinevi yayinevi, Kategori kategori, int sayfa, bool kiralama, bool hasar, Decimal fiyat)
            : base(adi)
        {
            this.BasimYili = basimYili;
            this.Author = yazar;
            this.Publisher = yayinevi;
            this.Category = kategori;
            this.SayfaSayisi = sayfa;
            this.KiralamaDurumu = kiralama;
            this.HasarDurumu = hasar;
            this.Fiyat = fiyat;
        }
        public Kitap(int id, string adi, int basimYili, Yazar[] yazar, Yayinevi yayinevi, Kategori kategori, int sayfa, bool kiralama, bool hasar, Decimal fiyat)
            : base(id, adi)
        {
            this.BasimYili = basimYili;
            this.Author = yazar;
            this.Publisher = yayinevi;
            this.Category = kategori;
            this.SayfaSayisi = sayfa;
            this.KiralamaDurumu = kiralama;
            this.HasarDurumu = hasar;
            this.Fiyat = fiyat;
        }
        # endregion
        public override string ToString()
        {
            String Value = this.Adi;
            if (this.Author != null)
            {
                for (int i = 0; i < this.Author.Length; i++)
                {
                    Value += ", " + this.Author[i].ToString();
                }
            }
            Value += ", " + this.Publisher.ToString() + ", " + this.Category.ToString() + ", " + this.Fiyat.ToString() + " TL";
            return Value;
        }

        public override bool Equals(object obj)
        {
            bool value = false;
            if (obj is Kitap)
            {
                Kitap Check = (Kitap)obj;
                if (this.ID == Check.ID && this.Adi == Check.Adi && this.BasimYili == Check.BasimYili && this.Category.Equals(Check.Category) && this.Publisher.Equals(Check.Publisher) &&
                    this.SayfaSayisi == Check.SayfaSayisi && this.HasarDurumu == Check.HasarDurumu && this.KiralamaDurumu == Check.KiralamaDurumu && this.Fiyat == Check.Fiyat &&
                    this.Kapak == Check.Kapak && this.Ozet == Check.Kapak)
                {
                    if (this.Author == null && Check.Author == null)
                    {
                        value = true;
                    }
                    else if(this.Author != null && Check.Author != null && this.Author.Length == Check.Author.Length)
                    {
                        value = true;
                        foreach (Yazar item in this.Author)
                        {
                            if (!Check.Author.Contains(item))
                            {
                                value = false;
                                break;
                            }//if
                        }//foreach
                    }//iç if
                }//dış if
            }//en dış if
            return value;
        }
    }
}
