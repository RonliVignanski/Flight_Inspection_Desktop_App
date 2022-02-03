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

namespace FlightGearApp.controls
{
    /// <summary>
    /// Interaction logic for GraphController.xaml
    /// </summary>
    public partial class GraphController : UserControl
    {
        GraphViewModel vm;
        public GraphController()
        {
            this.vm = new GraphViewModel();
            InitializeComponent();
            DataContext = vm;
        }

        private void XML_data_strings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.VM_SelectedDataName = XML_data_strings.SelectedItem.ToString();
        }

        public void setMaps(Dictionary<string, List<float>> learnMap, List<string> strings, Dictionary<string, List<float>> anomalyMap)
        {
            vm.setMaps(learnMap, strings, anomalyMap);
            XML_data_strings.ItemsSource = vm.getStringsDataList();
        }

        public void updateAnomalyMap(List<string> strings, Dictionary<string, List<float>> anomalyMap)
        {
            vm.updateAnomalyMap(strings, anomalyMap);
        }

        public void setTime(int time)
        {
            vm.VM_Time = time;
        }

        public void setShouldStop(bool shouldStop)
        {
            vm.VM_ShouldStop = shouldStop;
        }

        public void setPace(int pace)
        {
            vm.VM_Pace = pace;
        }

        public void run()
        {
            vm.run();
        }
    }
}
