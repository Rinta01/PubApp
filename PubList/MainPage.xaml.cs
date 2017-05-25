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
            if (File.Exists(@".././tpubs.txt") && new FileInfo(@".././tpubs.txt").Length == 0)
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

                            Pubs r = new Pubs(input[0], input[3], input[1], input[2], i, input[4], double.Parse(input[5]));
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

        private void Some_Method() //this method is called
        {
            ExpD_Click(new object(), new RoutedEventArgs());
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
                        if (srch.Text.ToUpper() == item.Name.ToUpper())
                        {
                            List1.Items.Clear();
                            List1.Items.Add(item);

                        }
                        else MessageBox.Show("No such items were found.");
                    }
                }


                if (a == "Metro")
                {
                    foreach (Pubs i in pubs)
                    {
                        if (srch.Text.ToUpper() == i.Metro.ToUpper())
                        {
                            List1.Items.Clear();
                            List1.Items.Add(i);
                        }
                        else MessageBox.Show("No such items were found.");
                    }
                }

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
            catch (Exception exx) { MessageBox.Show(exx.Message); }
        }
        private void ImpT_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream(@"../../tpubs.txt", FileMode.Create, FileAccess.Write);
            FileStream ff = new FileStream(@"../../tpos.txt", FileMode.Create, FileAccess.Write);

            using (StreamWriter sr = new StreamWriter(fs, Encoding.Default))
            {
                StreamWriter ss = new StreamWriter(ff, Encoding.Default);

                //sr.WriteLine("Name  /Metro  /Address  /Comment  /Visit  /Average Price");
                foreach (var item in pubs)
                {
                    sr.WriteLine(item.Pubinfo());

                    //sr.WriteLine("BName  /Sort  /Brewery  /Country  /Alc  /Bprice");
                    foreach (var j in item.Cranes)
                    {
                        ss.WriteLine(j.PosInfo());
                    }

                }
                ss.Close();
                ff.Close();
            }
            fs.Close();


            MessageBox.Show("Successfully imported to tpubs.txt");
        }


        private void ExpT_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
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
                List<Positions> lb = new List<Positions>();
                while (!sr.EndOfStream)
                {
                    sb += sr.ReadLine();
                }
                while (!ss.EndOfStream)
                {
                    bb += ss.ReadLine();
                }
                var mbo = sb.Split(';');
                var mbb = bb.Split(';');

                sr.Close();
                fs.Close();
                if (File.ReadAllText("../../tpos.txt") == "")
                {

                    foreach (var item in mbo)
                    {

                        var MassBo = item.Split(',');
                        if (item == null)
                            break;
                        pb.Add(new Pubs(MassBo[0], MassBo[3], MassBo[1], MassBo[2], lb, i, MassBo[4], double.Parse(MassBo[5])));
                    }

                    foreach (Pubs item in pb)
                    {
                        List1.Items.Add(item);
                    }
                    fs.Close();
                    MessageBox.Show("Your data was successfully imported from tpubs.txt (beer list not incl.)");
                }
                else
                {

                    foreach (var jj in mbb)
                    {
                        var MassBb = jj.Split(',');
                        if (MassBb.Length < 11)
                        { break; }
                        lb.Add(new Positions(MassBb[1], MassBb[3], MassBb[5], MassBb[7], double.Parse(MassBb[9]), int.Parse(MassBb[11])));
                    }

                    foreach (var item in mbo)
                    {
                        var MassBo = item.Split(',');
                        pb.Add(new Pubs(MassBo[1], MassBo[7], MassBo[3], MassBo[5], lb, i, MassBo[7], double.Parse(MassBo[9])));
                    }

                    foreach (Pubs item in pb)
                    {
                        List1.Items.Add(item);
                    }

                    fs.Close();
                    MessageBox.Show("Your data was successfully imported from tpubs.txt");

                }
            }
            else
                MessageBox.Show("You need to import any data first.");
            //}
            //catch (Exception exx) { MessageBox.Show(exx.Message); }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            var a = List1.SelectedItem;
            List1.Items.Remove(a);
            pubs.Remove((Pubs)a);
        }

        private void Been_Click(object sender, RoutedEventArgs e)
        {
            var a = List1.SelectedItem;
            foreach (var item in pubs)
            {
                if ((Pubs)a == item)
                {
                    item.vs = "yes";
                    List1.Items.Refresh();
                }
            }
        }


        private void Nbeen_Click(object sender, RoutedEventArgs e)
        {
            var a = List1.SelectedItem;
            foreach (var item in pubs)
            {
                if ((Pubs)a == item)
                {
                    item.vs = "no";
                    List1.Items.Refresh();
                }
            }

        }
    }
}

