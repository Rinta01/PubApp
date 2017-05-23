using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubList
{
    class Pages
    {
        private static AddNewItem _addnewitem = new AddNewItem();
        private static MainPage _mainPage = new MainPage();
        //private static AddPersonPage _addPersonPage = new AddPersonPage();

        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
        }

        public static AddNewItem Addnewitem
        {
            get
            {
                return _addnewitem;
            }
        }

        //public static AddPersonPage AddPersonPage
        //{
        //    get
        //    {
        //        return _addPersonPage;
        //    }
        //}

    }
}
