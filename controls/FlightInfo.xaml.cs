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
using FlightGearApp;

namespace FlightGearApp.controls
{
    /// <summary>
    /// Interaction logic for FlightInfo.xaml
    /// </summary>
    public partial class FlightInfo : UserControl
    {
        FlightInfoViewModel vm;
        
        public FlightInfo()
        {
            InitializeComponent();
            vm = new FlightInfoViewModel(new FlightInfoModel());
            DataContext = vm;
        }

        public void setFlightValues(Dictionary<string, List<float>> values)
        {
            vm.setMap(values);
        }

        public void run()
        {
            vm.run();
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
    }
}
