using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PubList
{
    /// <summary>
    /// Логика взаимодействия для AddNewItem.xaml
    /// </summary>
    public partial class AddNewItem : Page

    {
        List<int> AvPr = new List<int>();
        MainPage mp = new MainPage();
        List<Positions> beer = new List<Positions>();
        public AddNewItem()
        {
            InitializeComponent();
        }

    private void Metro_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= Metro_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += Metro_GotFocus;
        }

        private void Address_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= Metro_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += Metro_GotFocus;
        }

        private void Comment_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= Comment_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += Comment_GotFocus;
        }

        private void Nm_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= Nm_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += Nm_GotFocus;
        }

        private void Crane_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= Crane_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += Crane_GotFocus;
        }

        private void BCountry_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= BCountry_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += BCountry_GotFocus;
        }

        private void Brewery_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= Brewery_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += Brewery_GotFocus;
        }
        private void BPrice_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= BPrice_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += BPrice_GotFocus;
        }

        public void NCheck(string a)
        {
            if (String.IsNullOrEmpty(a))
                a = "-";
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string a = Crane.Text;
                string b = cmb.Text;
                string c = Brewery.Text;
                double d = double.Parse(AlcV.Text);
                string f = BPrice.Text;
                string g = BCountry.Text;

                if (String.IsNullOrEmpty(Crane.Text) || String.IsNullOrEmpty(cmb.Text))
                    MessageBox.Show("Please select the beer sort or fill in its name");

                NCheck(c);
                NCheck(f);
                NCheck(g);
                if (AlcV.Text == "")
                    d = 0;

                Positions p = new Positions(Crane.Text, cmb.Text, Brewery.Text, BCountry.Text, double.Parse(AlcV.Text), int.Parse(BPrice.Text));
                AvPr.Add(int.Parse(BPrice.Text));
                beer.Add(p);
                LCr.Items.Add(p);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Nm.Text) || String.IsNullOrEmpty(Comment.Text) || String.IsNullOrEmpty(Metro.Text) || String.IsNullOrEmpty(Address.Text) || String.IsNullOrEmpty(yn.Text) || beer.Contains(null))
            {
                MessageBox.Show("Please fill in all the reqired info.");
            }
            else if(beer.Count == 0)
            {
                Pubs np = new Pubs(Nm.Text, Comment.Text, Metro.Text, Address.Text, mp.i, yn.Text);
                mp.i++;
                mp.List1.Items.Add(np);
                NavigationService.Navigate(Pages.MainPage);
            }
            else
            {
                Pubs np = new Pubs(Nm.Text, Comment.Text, Metro.Text,Address.Text, beer, mp.i, yn.Text,Average_Value(AvPr));
                mp.i++;
                mp.List1.Items.Add(np);
                NavigationService.Navigate(Pages.MainPage);
            }
        }


        public double Average_Value(List<int> abc)
        {
            List<int> bra = new List<int>();
            return bra.Average();            
        }
    }
   
}
