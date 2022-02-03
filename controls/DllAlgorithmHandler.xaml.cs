using FlightGearApp;
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
using FlightGearApp.controls.DllAlgorithmAndGraphHandlerMVVM;
using FlightGearApp.windows;
using System.ComponentModel;

namespace FlightGearApp.controls
{

    public partial class DllAlgorithmHandler : UserControl, INotifyPropertyChanged
    {

        private Dictionary<string, List<float>> XML_CSVMap;
        private DllAlgorithmHandlerViewModel vm;
        private LoadDllAlgorithm loadDllAlgorithm;
        public DllAlgorithmHandler()
        {
            vm = new DllAlgorithmHandlerViewModel(new DllAlgorithmHandlerModel());
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void Set_Anomalies_Detection_Algorithm(object sender, RoutedEventArgs e)
        {
            loadDllAlgorithm = new LoadDllAlgorithm();
            loadDllAlgorithm.Show();
            loadDllAlgorithm.PropertyChanged += delegate (Object s, PropertyChangedEventArgs p)
            {
                vm.PropertyChanged += delegate (object s2, PropertyChangedEventArgs time)
                {
                    NotifyPropertyChanged(time.PropertyName);
                };
                vm.StartDllHandling(p.PropertyName);
            };
        }
        public void setValues(Dictionary<string, List<float>> values, List<string> keysList)
        {
            vm.setValues(values, keysList);
        }
    }
}
