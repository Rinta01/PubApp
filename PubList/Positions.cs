using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubList
{
    [Serializable]
    public class Positions
    {
        public string BName { get; set; }
        public string Country { get; set; }
        public string Brewery { get; set; }
        public string Sort { get; set; }
        public double Alc { get; set; }
        public int Bprice { get; set; }


        public Positions(string a, string b, string c, string d, double e, int f)
        {
            BName = a;
            Sort = b;
            Brewery = c;
            Country = d;
            Alc = e;
            Bprice = f;
        }

        public string PosInfo()
        {
            return string.Format("{0},{1},{2},{3},{4},{5};", BName, Sort, Brewery, Country, Alc, Bprice);
        }
      
    }
}
