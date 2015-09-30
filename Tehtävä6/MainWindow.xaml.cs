//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;

namespace JAMK.ICT.ADOBlanco
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      IniMyStuff();
    }

    private void IniMyStuff()
    {
      //TODO täytetään combobox asiakkaitten maitten nimillä
      //esimerkki kuinka App.Configissa oleva connectionstring luetaan
      lbMessages.Content = JAMK.ICT.Properties.Settings.Default.Tietokanta;
            string error;
            DataTable dt = new DataTable();
            List<string> list = new List<string>();
            dt = (JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(JAMK.ICT.Properties.Settings.Default.Tietokanta, "wine", out error));
            foreach(DataRow row in dt.Rows)
            {
                if (!list.Contains(row["Country"].ToString()))
                    {
                        list.Add(row["Country"].ToString());
                    }
            }
            cbCountries.ItemsSource = list;
        }

    private void btnGet3_Click(object sender, RoutedEventArgs e)
    {
        dgCustomers.DataContext = JAMK.ICT.Data.DBPlacebo.GetTestCustomers();
    }

    private void btnGetAll_Click(object sender, RoutedEventArgs e)
    {
            string error;
        dgCustomers.DataContext = JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(JAMK.ICT.Properties.Settings.Default.Tietokanta, "wine", out error);
    }

    private void btnGetFrom_Click(object sender, RoutedEventArgs e)
    {
            string error;
            DataTable dt = new DataTable();
            dt = (JAMK.ICT.Data.DBPlacebo.GetAllCustomersFromSQLServer(JAMK.ICT.Properties.Settings.Default.Tietokanta, "wine", out error));
            DataView view = new DataView(dt,"","Name",DataViewRowState.CurrentRows);
            view.RowFilter = "Country = '" + cbCountries.Text + "'";
            dgCustomers.DataContext = view;

        }

        private void btnYield_Click(object sender, RoutedEventArgs e)
        {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }
    }
}
