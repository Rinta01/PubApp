using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubList
{
    class Positions
    {
        public string BName { get; set; }
        public string Country { get; set; }
        public string Brewery { get; set; }
        public string Sort { get; set; }
        public double Alc { get; set; }
        

        public Positions(string a)
        {
            BName=a;
            //Country= b;
            //Brewery= c;
            //Sort=d;
            //Alc=e;
        }
   
    }
}
