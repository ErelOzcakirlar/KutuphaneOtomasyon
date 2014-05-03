using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bilesen
    {
        int _id;
        public int ID { 
            get {
                return this._id;
            }
        }
        public string Adi { get; set; }

        public Bilesen(int id, string adi)
        {
            this._id = id;
            this.Adi = adi;
        }
        public Bilesen(string adi)
        {
            this._id = 0;
            this.Adi = adi;
        }

        public override string ToString()
        {
            return this.Adi;
        }
    }
}
