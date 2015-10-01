using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JSONdemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string json = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Methods
        private void Demo1()
        {
            json = GetSimpleJson();
            List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(json);
            dataGrid.DataContext = persons;
        }
        public void setTestData()
        {
            var webRequest = (HttpWebRequest)WebRequest.Create("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
            var webResponse = (HttpWebResponse)webRequest.GetResponse();

            if (webResponse.StatusCode == HttpStatusCode.OK && webResponse.ContentLength > 0)
            {
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                List<Politic> persons = JsonConvert.DeserializeObject<List<Politic>>(s);
                dataGrid.DataContext = persons;
            }
            else
            {
                MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
            }
        }
        public string DownloadString(string address)
        {
            WebClient client = new WebClient();
            try { 
            string reply = client.DownloadString(address);
                return reply;
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return "";
        }

        private string GetSimpleJson()
        {
            return @"[
                      {'Name':'Olli opiskelija','Gender':'Male','Birthday':'1995-12-24'},
                      {'Name':'Matti Mainio','Gender':'Male','Birthday':'1985-12-24'}
                     ]";
        }

        #endregion

        private void button_Click(object sender, RoutedEventArgs e)
        {
           string que = DownloadString("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
            List<Politic> persons = JsonConvert.DeserializeObject<List<Politic>>(que);
            dataGrid.DataContext = persons;
            //setTestData();
        }
    }
}