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
        public string Location { get; set; }
        public bool Vstd { get; set; }

        public List<Positions> beer = new List<Positions>();

        //public string Pubinfo()
        //{
        //    return string.Format("{0} :м.{1}", Name, Metro); //string. Format создает строчку ( фича для {0})
        //}

        public Pubs(string Name, int Number)
        {
            this.Name = Name;
            this.Number = Number;
        }
    }
}
