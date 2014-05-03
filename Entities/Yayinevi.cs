using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Yayinevi:Bilesen
    {
        public String Adres { get; set; }
        public int KurulusYili { get; set; }

        public Yayinevi(int id, string adi)
            : base(id, adi)
        { }
        public Yayinevi(string adi)
            : base(adi)
        { }
        public override bool Equals(object obj)
        {
            bool value = false;
            if (obj is Yayinevi)
            {
                Yayinevi Check = (Yayinevi)obj;
                if (this.ID == Check.ID && this.Adi == Check.Adi && this.Adres == Check.Adres && this.KurulusYili == Check.KurulusYili)
                {
                    value = true;
                }
            }
            return value;
        }
        
    }
}
