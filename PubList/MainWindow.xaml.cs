using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pubs> pubs = new List<Pubs> ();
        List<Pubs> visited_pubs = new List<Pubs>();
        public int i = 1;
        public MainWindow()
        {
             InitializeComponent();
            using (FileStream fs = new FileStream("../../List.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs, Encoding.Default);       /* File.ReadAllLines(@"../../List.txt", Encoding.Default);*/
                
                    while (!sr.EndOfStream)
                    {
                    try
                    {
                        string[] input_text = sr.ReadLine().Split(':');

                        Pubs r = new Pubs
                        {
                            Number = i,
                            Name = input_text[0],
                            Metro = input_text[1]

                        };
                        i++;
                        pubs.Add(r);
                    }
                    catch { };
                    
                }
                sr.Close();
            }
            foreach (Pubs item in pubs)
            {
                List1.Items.Add(item);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Pubs p5 = new Pubs { Number = i++, Name = AdditionName.Text, Metro = AddMetro.Text };
            pubs.Add(p5);
            if (!(string.IsNullOrEmpty(AdditionName.Text) || string.IsNullOrEmpty(AddMetro.Text)))
            {
                
                List1.Items.Add(p5);

                 using (FileStream fs = new FileStream("../../List.txt", FileMode.Append , FileAccess.Write))
                  //true записывает данные в файл перманентно.
                {
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    sw.WriteLine("\n"+p5.Pubinfo()+"\n");

                    sw.Close();
                 
                }
            }
            else
            {
                MessageBox.Show(" Введите данные в поля! ");
            }
            AdditionName.Clear();
            AddMetro.Clear();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Random g = new Random();
            int r = g.Next(0, pubs.Count);
            WhereTo.Items.Clear();
            WhereTo.Items.Add(pubs.ElementAt(r).Name.ToString());
            
            
        }

        private void AddToVisited_Click(object sender, RoutedEventArgs e)
        {
            var r = (Pubs)List1.SelectedItem;
            Pubs p = new Pubs {
                Number = r.Number,
                Name = r.Name,
                Metro = r.Metro };
            visited_pubs.Add(p);

            foreach (Pubs item in visited_pubs)
            {
                //MessageBox.Show(item.Pubinfo);
            }
        }
    }
}

