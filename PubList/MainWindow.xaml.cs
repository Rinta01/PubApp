using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<Pubs> pubs = new List<Pubs> ();
        public int i = 1;
        public MainWindow()
        {
             InitializeComponent();
            using (FileStream fs = new FileStream("../../List.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs, Encoding.Default);       /* File.ReadAllLines(@"../../List.txt", Encoding.Default);*/

                string[] input;
                    while (!sr.EndOfStream)
                    {
                    try
                    {
                        input = sr.ReadLine().Split(';');
                        string input_text = input[0];
                        string m = input[1];
                        string b = input[2];
                        Pubs r = new Pubs(input_text,i,m,b);
                        i++;
                        pubs.Add(r);
                    }
                    catch { };
                    

                }
                foreach (Pubs item in pubs)
                {
                    List1.Items.Add(item);
                }
                sr.Close();
            }
            
        }

        //private void Add_Click(object sender, RoutedEventArgs e)
        //{
        //    Pubs p5 = new Pubs { Number = i++, Name = AdditionName.Text};
        //    pubs.Add(p5);
        //    if (!(string.IsNullOrEmpty(AdditionName.Text) || string.IsNullOrEmpty(AddMetro.Text)))
        //    {

        //        List1.Items.Add(p5);

        //         using (FileStream fs = new FileStream("../../List.txt", FileMode.Append , FileAccess.Write))
        //          //true записывает данные в файл перманентно.
        //        {
        //            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
        //            sw.WriteLine("\n"+p5.Pubinfo()+"\n");

        //            sw.Close();

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show(" Введите данные в поля! ");
        //    }

        //}
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddItem wnd = new AddItem();
            wnd.Show();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            foreach (ListViewItem item in List1.Items)
            {

            }
        }

        private void Randomize_Click(object sender, RoutedEventArgs e)
        {
            Random g = new Random();
            int r = g.Next(0, pubs.Count);
        }

        private void cbx_Checked(object sender, RoutedEventArgs e)
        {
            Pubs a = sender as Pubs;
          
        }

        private void srch_GotFocus(object sender, RoutedEventArgs e)
        {
            
            TextBox tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                tb.Text = string.Empty;
                tb.GotFocus -= srch_GotFocus;
                tb.FontWeight = FontWeights.Regular;
                tb.FontStyle = FontStyles.Normal;
            }
            tb.GotFocus += srch_GotFocus;
        }

        private void MenuItem_Edit(object sender, MouseButtonEventArgs e)
        {   

        }

        private void MenuItem_Delete(object sender, MouseButtonEventArgs e)
        {
            var a = List1.SelectedItem;
            List1.Items.Remove(a);
            pubs.Remove((Pubs)a);
            

        }

        private void MenuItem_Visited(object sender, MouseButtonEventArgs e)
        {

        }

        private void MenuItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddDat_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(@"../../pubs.dat", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, pubs);

            }
            MessageBox.Show("Successfully imported to pubs.dat");
        }


        //private void AddToVisited_Click(object sender, RoutedEventArgs e)
        //{
        //    var r = (Pubs)List1.SelectedItem;
        //    Pubs p = new Pubs {
        //        Number = r.Number,
        //        Name = r.Name,
        //        Metro = r.Metro };
        //    visited_pubs.Add(p);
        //}
    }
}

