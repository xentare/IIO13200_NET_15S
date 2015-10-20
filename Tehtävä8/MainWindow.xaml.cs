using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
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

namespace Tehtävä8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XDocument palautteet;
        string dataSource;

        public MainWindow()
        {
            InitializeComponent();

            dataSource = Tehtävä8.Properties.Settings.Default.dataSource;

            getPalautteet();             
        }
        /*
        * Hakee palautteet ja esittää ne palautteet-välilehden data-gridissä
        */
        public void getPalautteet()
        {
            try {
                palautteet = XDocument.Load(dataSource);
                DataSet dataset = new DataSet();
                dataset.ReadXml(palautteet.CreateReader());
                dataGridSelaaPalautteita.DataContext = dataset.Tables[0];
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);  
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach(TextBox tb in FindVisualChildren<TextBox>(mainWindow))
            {
                if(tb.Text.Length <= 0)
                {
                    MessageBox.Show("All textboxes have to be filled!");
                    return;
                }
            }

            try {
                palautteet.Root.Add(
                    new XElement("palaute",
                    new XElement("pvm", txtBoxPäivämäärä.Text),
                    new XElement("tekija", txtBoxNimi.Text),
                    new XElement("asioid", txtBoxNimi.Text), //ASIOID TÄHÄN
                    new XElement("opittu", txtBoxOlenOppinut.Text),
                    new XElement("haluanoppia", txtBoxHaluanOppia.Text),
                    new XElement("hyvaa", txtBoxHyvää.Text),
                    new XElement("parannettavaa", txtBoxParannettavaa.Text),
                    new XElement("muuta", txtBoxMuuta.Text)));
                palautteet.Save(dataSource);
            }
            catch(Exception err)
            {
                MessageBox.Show("Tiedostoa ei löydy!");
                return;
            }
            MessageBox.Show("Tiedot tallennettu onnistuneesti!");
            getPalautteet();
        }


        //http://stackoverflow.com/questions/974598/find-all-controls-in-wpf-window-by-type
        //Looping through all objects
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

    }
}
