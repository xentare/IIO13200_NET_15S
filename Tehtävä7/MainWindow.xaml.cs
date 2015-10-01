using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace Tehtävä7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitComboBox();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Station station = (Station)stationComboBox.SelectedItem;
            string query = "http://rata.digitraffic.fi/api/v1/live-trains?station=HKI";//" + station.stationCode;
            string response = getDataFromApi(query);
            List<Train> trains = JsonConvert.DeserializeObject<List<Train>>(response);

            trainDataGrid.DataContext = trains;
        }

        public void InitComboBox()
        {
            string response = getDataFromApi("http://rata.digitraffic.fi/api/v1/metadata/station");
            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(response);
            stationComboBox.DisplayMemberPath = "stationName";
            stationComboBox.ItemsSource = stations;
        }
        public string getDataFromApi(string url)
        {
            WebClient client = new WebClient();
            try
            {
                Uri uri = new Uri(url);
                string response = client.DownloadString(uri);
                return response;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return "";
        }
    }
}
