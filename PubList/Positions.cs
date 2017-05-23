using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubList
{
    [Serializable]
    class Positions
    {
        public string BName { get; set; }
        public string Country { get; set; }
        public string Brewery { get; set; }
        public string Sort { get; set; }
        public double Alc { get; set; }
        public string Bprice { get; set; }


        public Positions(string a, string b)
        {
            BName = a;
            Sort = b;
            Brewery = "";
            Country = "";
            Alc = 0;
            Bprice = "";
        }

        public Positions(string a, string b, string c, string d, double e, string f)
        {
            //if (a == null || b == null||c==null||d==null||e==null||f==null)
            //{
            //    return;
            //}
            BName = a;
            Sort = b;
            Brewery = c;
            Country = d;
            Alc = e;
            Bprice = f;
        }

        public Positions(string a, string b, string c)
        {
           
            BName = a;
            Sort = b;
            Brewery = c;
            Country = "";
            Alc = 0;
            Bprice = "";
           
        }

        public Positions(string a, string b, string c, string d )
        {     
            BName = a;
            Sort = b;
            Brewery = c;
            Country = d;
            Alc = 0;
            Bprice = "";

        }
        public Positions(string a, string b, string c, string d, double e)
        {
            BName = a;
            Sort = b;
            Brewery = c;
            Country = d;
            Alc = e;
            Bprice = "";
        }
    }
}
