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
        public string Metro { get; set; }

        public string Pubinfo()
        {
            return string.Format("{0} :м.{1}", Name, Metro); //string. Format создает строчку ( фича для {0})
        }

        public void Show(Pubs a)
        {
            //Pubs A = new Pubs{ Number = Number; Metro = "м." + Metro; Name =Name };
            a.Metro = "м." + Metro;
            
        }
    }
}
