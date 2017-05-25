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

        public List<Positions> Cranes
        {
            get { return _cranes; }
            set {_cranes = value; }
        }

        List<Positions> _cranes = new List<Positions>();
       
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


        public string Pubinfo()
        {
           return string.Format("{0},{1},{2},{3},{4},{5};", Name, Metro,Address, Comment, vs,AvPrice); //string. Format создает строчку ( фича для {0})
        }

        public Pubs(string a, string c, string d, int f)
        {
            Name = a;
            Metro = c;
            vs = d;
            Number = f;
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
        public Pubs(string Name, string b, string c, string d, int f, string g, double h)
        {
            this.Name = Name;
            Comment = b;
            Metro = c;
            Address = d;
            Number = f;
            vs = g;
            AvPrice = h;
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
