using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubList
{
 [Serializable]   
    class Pubs
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Metro { get; set; }
        public string Address { get; set; }
        private string loc;
        public double AvPrice { get; set; }

        public string Location
        {
            get { return loc; }
            set {
                string mde = Metro + Address;
                loc = mde;
                loc = value; }
        }

        List<Positions> Cranes = new List<Positions>();
       
        //private bool v;

        //public bool Vstd
        //{
        //    get { return v; }
        //    set
        //    {
        //        if (value == true)
        //        {
        //            vs = "yes";
        //        }
        //        else
        //            vs = "no";

        //        v = value;
                
        //    }
        //}

        public string vs { get; set; }


        //public string Pubinfo()
        //{
        //    return string.Format("{0} :м.{1}", Name, Metro); //string. Format создает строчку ( фича для {0})
        //}

        public Pubs(string Name, int b, string c, string d)
        {
            this.Name = Name;
            Number = b;
            Metro = c;
            vs = d;
            
        }
        public Pubs(string Name, string b, string c, string d, int f, string g)
        {
            this.Name = Name;
            Comment = b;
            Metro = c;
            Address = d;
            Number = f;
            vs = g;
            
        }
        public Pubs(string Name, string b, string c, string d, List<Positions> e, int f, string g, double h)
        {
            this.Name = Name;
            Comment = b;
            Metro = c;
            Address = d;
            Cranes = e;
            Number = f;
            vs = g;
            AvPrice = h;
        }

    }
}
