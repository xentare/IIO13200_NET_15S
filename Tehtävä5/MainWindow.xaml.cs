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

namespace Tehtävä5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetDataTable_Click(object sender, RoutedEventArgs e)
        {
            dgData.DataContext = DBDemoxOy.GetDataReal();
        }

        private void haeLäsnäoloniButton_Click(object sender, RoutedEventArgs e)
        {
            dgData.DataContext = DBDemoxOy.GetDataView(asioidTextBox.Text);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Tehtävä5.opiskelijat opiskelijat = ((Tehtävä5.opiskelijat)(this.FindResource("opiskelijat")));
        }
    }
}
