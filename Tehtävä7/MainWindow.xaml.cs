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

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            Station station = (Station)stationComboBox.SelectedItem;
            string query = "http://rata.digitraffic.fi/api/v1/live-trains?station=" + station.stationShortCode;
            string response = await getDataFromApi(query);
            List<Train> trains = JsonConvert.DeserializeObject<List<Train>>(response);
            trainDataGrid.DataContext = trains;
        }

        public async void InitComboBox()
        {
            string response = await getDataFromApi("http://rata.digitraffic.fi/api/v1/metadata/station");
            List<Station> stations = JsonConvert.DeserializeObject<List<Station>>(response);
            stationComboBox.DisplayMemberPath = "stationName";
            stationComboBox.ItemsSource = stations;
        }
        public async Task<string> getDataFromApi(string url)
        {
            WebClient client = new WebClient();
            try
            {
                Uri uri = new Uri(url);
                statusTextBlock.Text = "Getting data from the server...";
                string response = await client.DownloadStringTaskAsync(uri);
                statusTextBlock.Text = "Done";
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
