using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using System.Windows.Shapes;
using FlightGearApp.controls;
using FlightGearApp.src;
using OxyPlot;

namespace FlightGearApp.windows
{

    public partial class DllAlgorithmGraph : Window, INotifyPropertyChanged
    {
        DllAlgorithmGraphViewModel vm;
        private WriteYoureOwnAlgorithmWindow writeYoureOwnAlgorithmWindow;

        public event PropertyChangedEventHandler PropertyChanged;
        public DllAlgorithmGraph(string path, Dictionary<string, List<float>> values, List<string> keysList)
        {
            InitializeComponent();
            vm = new DllAlgorithmGraphViewModel(new DllAlgorithmGraphModel(path, values, keysList));
            XML_data_strings.ItemsSource = keysList;
            DataContext = vm;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void learnAndDetect()
        {
            vm.learnAndDetect();
        }

        private void XML_data_strings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.setSelectedData(XML_data_strings.SelectedItem.ToString());
            vm.drawGraph();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedItem != null)
            {
                float timeStep = vm.getTimeStepOfAnomalyReport(ListBox.SelectedItem.ToString());
                NotifyPropertyChanged(timeStep.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            writeYoureOwnAlgorithmWindow = new WriteYoureOwnAlgorithmWindow();
            writeYoureOwnAlgorithmWindow.Show();
        }
    }
}
