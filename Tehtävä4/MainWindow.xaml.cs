using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Xml;
using System.Xml.Linq;

namespace Tehtävä4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string path = ConfigurationManager.AppSettings.Get("viiniData");
            List<string> maatList = new List<string>();

            XDocument doc = null;
            try
            {
                doc = XDocument.Load(path);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("");
                MessageBox.Show("Can't find XML filepath, terminating...");
                //this.Close();
            }
    
            //Haetaan maat XML-tagien sisästä
            var maat = doc.Descendants("maa");
            maatList.Add("Kaikki");
            foreach(var maa in maat)
            {
                if (!maatList.Contains(maa.Value))
                {
                    maatList.Add(maa.Value);
                }
            }
            maatComboBox.ItemsSource = maatList;
            maatComboBox.SelectedIndex = 0;

            //Asetetaan alkuarvot viinilistalle
            XmlDataProvider dp = viinitListView.DataContext as XmlDataProvider;
            dp.Source = new System.Uri(path);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            XmlDataProvider dp = viinitListView.DataContext as XmlDataProvider;

            if (maatComboBox.Text != "Kaikki")
            {
                dp.XPath = string.Format("viinikellari/wine[contains(maa,\"{0}\")]", maatComboBox.Text);
            }
            else
            {
                dp.XPath = "viinikellari/wine";
            }
        }
    }
}
