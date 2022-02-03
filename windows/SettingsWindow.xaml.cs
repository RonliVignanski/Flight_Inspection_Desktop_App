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
using System.Windows.Shapes;
using FlightGearApp;

namespace FlightGearApp.windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private FilesLoaderViewModel flViewModel;

        public SettingsWindow()
        {
            InitializeComponent();
            flViewModel = new FilesLoaderViewModel(new FilesLoaderModel());
            DataContext = flViewModel;
        }

        private void loadCSV_button(object sender, RoutedEventArgs e)
        {
            flViewModel.initializeParserForLearnCsv(xmlBox.Text, csvBox.Text);
            flViewModel.initializeParserForAnomalyCsv(xmlBox.Text, csvBox2.Text);

            string s1 = flViewModel.parseXML();
            string s2 = flViewModel.MatchXMLToCSV();
            
            if (s1 == "" && s2 == "")
            {
                flViewModel.createNewCsv();
                windows.AppWindow appWindow = new AppWindow(flViewModel.getFilesParser(),flViewModel.getFilesParserForAnomalyCsv());
                this.Close();
                appWindow.Show();
            }
        }        
    }
}
