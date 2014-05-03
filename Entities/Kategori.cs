using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kategori:Bilesen
    {
        public String Aciklama { get; set; }

        public Kategori(int id, string adi)
            : base(id, adi)
        {

        }
        public Kategori(string adi)
            : base(adi)
        {

        }
        public override bool Equals(object obj)
        {
            bool value = false;
            if (obj is Kategori)
            {
                Kategori Check = (Kategori)obj;
                if (this.ID == Check.ID && this.Adi == Check.Adi && this.Aciklama == Check.Aciklama)
                {
                    value = true;
                }
            }
            return value;
        }
    }
}
