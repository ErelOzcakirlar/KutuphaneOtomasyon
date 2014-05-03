using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Yazar:Bilesen
    {
        public String Soyadi { get; set; }
        public String Ozgecmis { get; set; }

        public Yazar(int id, string adi, string soyadi)
            : base(id, adi)
        {
            this.Soyadi = soyadi;
        }
        public Yazar(string adi, string soyadi)
            : base(adi)
        {
            this.Soyadi = soyadi;
        }
        public override string ToString()
        {
            return base.ToString() + " " + this.Soyadi;
        }
        public override bool Equals(object obj)
        {
            bool value = false;
            if (obj is Yazar)
            {
                Yazar Check = (Yazar)obj;
                if (this.ID == Check.ID && this.Adi == Check.Adi && this.Soyadi == Check.Soyadi && this.Ozgecmis == Check.Ozgecmis)
                {
                    value = true;
                }
            }
            return value;
        }
    }
}
