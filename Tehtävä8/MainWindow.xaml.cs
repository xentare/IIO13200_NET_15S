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

namespace Tehtävä8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            XmlDataProvider provider = dataGridSelaaPalautteita.DataContext as XmlDataProvider;
            Uri uri = new Uri(Tehtävä8.Properties.Settings.Default.dataSource);
            provider.Source = uri;
            provider.XPath = "palautteet/palaute";
            dataGridSelaaPalautteita.DataContext = provider;

        }
    }
}
