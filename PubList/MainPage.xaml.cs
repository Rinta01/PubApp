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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Pubs> pubs = new List<Pubs>();
        public int i = 1;
        public MainPage()
        {
            InitializeComponent();
            if(File.Exists(".././tpubs.txt") && !(File.ReadAllText(".././tpubs.txt") == ""))
            {
                ExpT.IsEnabled = true;
            }
            else
            {
                using (FileStream fs = new FileStream("../../List.txt", FileMode.Open, FileAccess.Read))
                {
                    StreamReader sr = new StreamReader(fs, Encoding.Default);

                    string[] input;
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            input = sr.ReadLine().Split(';');
                            string input_text = input[0];
                            string m = input[1];
                            string b = input[2];
                            Pubs r = new Pubs(input_text,m,b,i);
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

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           NavigationService.Navigate(Pages.Addnewitem); ;
        }

        private void Randomize_Click(object sender, RoutedEventArgs e)
        {
            Random g = new Random();
            int r = g.Next(0, pubs.Count);
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
            NavigationService.Navigate(Pages.Addnewitem);
        }

        private void MenuItem_Delete(object sender, MouseButtonEventArgs e)
        {
            
            int a = List1.SelectedIndex;
            List1.Items.RemoveAt(a);
           
        }

        private void MenuItem_Visited(object sender, MouseButtonEventArgs e)
        {
            var a = List1.SelectedItem;
            foreach (var item in pubs)
            {
                if (a.Equals(item))
                {
                    item.vs = "yes";
                }
            }
            List1.Items.Refresh();
        }

        private void MenuItem_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void Whr_Click(object sender, RoutedEventArgs e)
        {
            string a = cbox.Text;
            try
            {
                if (a == "Name")
                {
                    foreach (Pubs item in pubs)
                    {
                        if (srch.Text == item.Name)
                        {
                            List1.Items.Clear();
                            List1.Items.Add(item);

                        }
                    }
                }
                else MessageBox.Show("No such items were found.");

                if (a=="Metro")
                {
                    foreach (Pubs i in pubs)
                    {
                        if (srch.Text == i.Metro)
                        {
                            List1.Items.Clear();
                            List1.Items.Add(i);
                        }
                    }
                }
                else MessageBox.Show("No such items were found.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ImpD_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(@"../../pubs.dat", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(fs, pubs);

            }
            MessageBox.Show("Successfully imported to pubs.dat");
        }

        private void ExpD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("../../pubs.dat"))
                {
                    List1.Items.Clear();
                    FileStream fs = new FileStream(@"../../pubs.dat", FileMode.Open, FileAccess.Read);


                    BinaryFormatter bf = new BinaryFormatter();

                    List<Pubs> pb = (List<Pubs>)bf.Deserialize(fs);
                    foreach (Pubs item in pb)
                    {
                        List1.Items.Add(item);
                    }

                    fs.Close();
                    MessageBox.Show("Your data was successfully imported from pubs.dat");
                
               
                }
                else
                    MessageBox.Show("You need to import any data first.");
            }
            catch(Exception exx) { MessageBox.Show(exx.Message); }
        }
        private void ImpT_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(@"../../tpubs.txt", FileMode.Create, FileAccess.Write);
            FileStream ff = new FileStream(@"../../tpos.txt", FileMode.Create, FileAccess.Write);

            StreamWriter sr = new StreamWriter(fs, Encoding.Default);
            StreamWriter ss = new StreamWriter(fs, Encoding.Default);


            foreach (var item in pubs)
                {
                    sr.Write(item.Pubinfo());

                foreach (var j in item.Cranes)
                {
                    ss.Write(j.PosInfo());
                }
                ss.WriteLine(";");
            }
            ff.Close();
            ss.Close();
            sr.Close();
            fs.Close();
            
            
            MessageBox.Show("Successfully imported to tpubs.txt");
        }

        private void ExpT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("../../tpubs.txt"))
                {
                    List1.Items.Clear();
                    FileStream fs = new FileStream(@"../../tpubs.txt", FileMode.Open, FileAccess.Read);
                    FileStream ff = new FileStream(@"../../tpos.txt", FileMode.Open, FileAccess.Read);

                    StreamReader sr = new StreamReader(fs, Encoding.Default);
                    StreamReader ss = new StreamReader(ff, Encoding.Default);
                    string sb = "";
                    string bb = "";
                    List<Pubs> pb = new List<Pubs>();
                    List < Positions > lb = new List<Positions>();
                    while (!sr.EndOfStream)
                    {
                        sb += sr.ReadLine();
                    }
                    sr.Close();
                    fs.Close();
                    while (!ss.EndOfStream)
                    {
                        bb += ss.ReadLine();
                    }
                    var mbb = bb.Split(',');
                    var mbo = sb.Split(',');
                    foreach (var jj in mbb)
                    {
                        var MassBb = jj.Split(':');
                        lb.Add(new Positions(MassBb[1], MassBb[3], MassBb[5], MassBb[7], double.Parse(MassBb[9]), int.Parse(MassBb[11])));
                    }
                    
                    foreach (var item in mbo)
                    {
                        var MassBo = item.Split(':');
                        pb.Add(new Pubs(MassBo[1], MassBo[7], MassBo[3], MassBo[5],lb,i,MassBo[7],double.Parse(MassBo[9])));   
                    }
                    
                    foreach (Pubs item in pb)
                    {
                        List1.Items.Add(item);
                    }

                    fs.Close();
                    MessageBox.Show("Your data was successfully imported from tpubs.txt");
                
                    
                }
                else
                    MessageBox.Show("You need to import any data first.");
            }
            catch (Exception exx) { MessageBox.Show(exx.Message); }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var a = List1.SelectedItem;
            List1.Items.Remove(a);
            pubs.Remove((Pubs)a);
        }
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

