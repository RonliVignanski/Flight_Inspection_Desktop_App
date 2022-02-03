using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for WheelController.xaml
    /// </summary>
    public partial class WheelController : UserControl
    {
        WheelControllerViewModel wheelControllerVM;

        public WheelController()
        {
            InitializeComponent();
            wheelControllerVM = new WheelControllerViewModel(new WheelControllerModel());
            DataContext = wheelControllerVM;
        }

        public void setMapValues(Dictionary<string, List<float>> values)
        {
            wheelControllerVM.setMap(values);
        }

        public void run()
        {
            wheelControllerVM.run();
        }

        public void setTime(int time)
        {
            wheelControllerVM.VM_Time = time;
        }

        public void setShouldStop(bool shouldStop)
        {
            wheelControllerVM.VM_ShouldStop = shouldStop;
        }

        public void setPace(int pace)
        {
            wheelControllerVM.VM_Pace = pace;
        }
    }
}
