﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        List<Positions> beer = new List<Positions>();
        public AddNewItem()
        {
            InitializeComponent();
        }

        private void Metro_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
                tb.Text = string.Empty;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
        }

        private void Address_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
                tb.Text = string.Empty;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
        }

        private void Comment_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.FontWeight = FontWeights.Regular;
            tb.FontStyle = FontStyles.Normal;
        }

        private void Nm_GotFocus(object sender, RoutedEventArgs e)
        {
            Nm.Text = "";
           
        }

        private void Crane_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
                tb.Text = string.Empty;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
        }

        private void BCountry_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
                tb.Text = string.Empty;
                tb.FontWeight = FontWeights.Regular;
            tb.FontStyle = FontStyles.Normal;
        }

        private void AlcV_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
                tb.Text = string.Empty;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
        }

        private void Brewery_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
                tb.Text = string.Empty;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
        }
        private void BPrice_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
                 tb.Text = string.Empty;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            
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
                if (String.IsNullOrEmpty(Crane.Text) || String.IsNullOrEmpty(cmb.Text))
                {
                    MessageBox.Show("Please select the beer sort or fill in its name");
                    return;
                }
                if (!(Regex.IsMatch(AlcV.Text, @"^\d+$"))||!(Regex.IsMatch(BPrice.Text, @"^\d+$")))
                {
                    MessageBox.Show("Check if you entered all the info correctly (some of it is numeric)");
                    return;
                }

                NCheck(Brewery.Text);
                NCheck(BPrice.Text);
                NCheck(BCountry.Text);
                
                    Positions p = new Positions(Crane.Text, cmb.Text, Brewery.Text, BCountry.Text, double.Parse(AlcV.Text), int.Parse(BPrice.Text));

                    beer.Add(p);
                    LCr.Items.Add(p);
                    Crane.Clear();
                    cmb.SelectedValue = null; ;
                    Brewery.Clear();
                    AlcV.Clear();
                    BPrice.Clear();
                    BCountry.Clear();
                //int a = int.Parse(BPrice.Text);
                //AvPr.Add(a);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
}

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if (String.IsNullOrEmpty(Nm.Text) || String.IsNullOrEmpty(Comment.Text) || String.IsNullOrEmpty(Metro.Text) || String.IsNullOrEmpty(Address.Text) || String.IsNullOrEmpty(yn.Text) || beer.Contains(null))
                {
                    MessageBox.Show("Please fill in all the reqired info.");
                }
               else if (beer.Count == 0)
                {
                
                Pubs np = new Pubs(Nm.Text, Comment.Text, Metro.Text, Address.Text, Pages.MainPage.i, yn.Text);
                Pages.MainPage.pubs.Add(np);
                    Pages.MainPage.i++;
                    Pages.MainPage.List1.Items.Add(np);
                    Pages.MainPage.List1.Items.Refresh();
                    NavigationService.Navigate(Pages.MainPage);
                    Nm.Clear();
                    Metro.Clear();
                    Comment.Clear();
                    Address.Clear();
                yn.SelectedValue = null;
                Crane.Clear();
                cmb.SelectedValue = null; ;
                Brewery.Clear();
                AlcV.Clear();
                BPrice.Clear();
                BCountry.Clear();

            }
                else
                {
                    Pubs np = new Pubs(Nm.Text, Comment.Text, Metro.Text, Address.Text, beer, Pages.MainPage.i, yn.Text);
                Pages.MainPage.pubs.Add(np);
                Pages.MainPage.i++;
                    Pages.MainPage.List1.Items.Add(np);
                    Pages.MainPage.List1.Items.Refresh();
                    NavigationService.Navigate(Pages.MainPage);
                    Nm.Clear();
                    Metro.Clear();
                    Comment.Clear();
                    Address.Clear();
                    yn.SelectedValue = null;
                Crane.Clear();
                cmb.SelectedValue = null; ;
                Brewery.Clear();
                AlcV.Clear();
                BPrice.Clear();
                BCountry.Clear();

            }
            //}
            //catch (Exception ee){ MessageBox.Show(ee.Message); }
        }
    
        public double Average_Value(List<int> abc)
        {
            List<int> bra = new List<int>();
            if (bra.Count == 1)
                return bra.ElementAt(0);
            return bra.Average();

        }
        private void Nm_LostFocus(object sender, RoutedEventArgs e)
        {
            
            Nm.FontWeight = FontWeights.Regular;
            Nm.FontStyle = FontStyles.Normal;
        }
    }
   
}
