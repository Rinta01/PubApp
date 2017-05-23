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
using System.Windows.Shapes;

namespace PubList
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        MainWindow wnd;
        List<Positions> beer = new List<Positions>();
        public AddItem()
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
            tb.GotFocus +=Comment_GotFocus;
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
        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                
                    Positions p = new Positions(Crane.Text, cmb.SelectedValue.ToString(), Brewery.Text, BCountry.Text, double.Parse(AlcV.Text), BPrice.Text);
                    beer.Add(p);
                    LCr.Items.Add(p);
                    
                
                 if (String.IsNullOrEmpty(Crane.Text) || String.IsNullOrEmpty(cmb.SelectedValue.ToString()))
                    MessageBox.Show("Please select the beer sort or fill in its name");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void vv_Click(object sender, RoutedEventArgs e)
        {
            CheckBox check = sender as CheckBox;
            MessageBox.Show(check.IsChecked.Value.ToString());

        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {

            Pubs np = new Pubs(Nm.Text, Comment.Text, Metro.Text, Address.Text, beer, wnd.i, (bool)vv.Content);
            wnd.i++;
            wnd.List1.Items.Add(np);

        }
    }
}
