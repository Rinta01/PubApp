using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubList
{
    class Pubs
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Metro { get; set; }
        public string Address { get; set; }
        private string loc;

        public string Location
        {
            get { return loc; }
            set {
                string mde = Metro + Address;
                loc = mde;
                loc = value; }
        }

        private Positions Cranes;

        public Positions InternalB
        {
            get { return Cranes; }
            set { Cranes = value; }
        }


        private bool v;

        public bool Vstd
        {
            get { return v; }
            set
            {
                if (value == true)
                {
                    vs = "yes";
                }
                else
                    vs = "no";

                v = value;
                
            }
        }

        public string vs;
        

        //public string Pubinfo()
        //{
        //    return string.Format("{0} :м.{1}", Name, Metro); //string. Format создает строчку ( фича для {0})
        //}

        public Pubs(string Name, string b, string c, string d, Positions e, int f, bool g)
        {
            this.Name = Name;
            Comment = b;
            Metro = c;
            Address = d;
            Cranes = e;
            Number = f;
            Vstd = g;
        }

    }
}
