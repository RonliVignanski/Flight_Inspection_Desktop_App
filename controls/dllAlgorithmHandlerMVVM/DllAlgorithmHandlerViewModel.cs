using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightGearApp.controls.DllAlgorithmAndGraphHandlerMVVM
{
    public class DllAlgorithmHandlerViewModel : INotifyPropertyChanged
    {
        private DllAlgorithmHandlerModel model;

        public DllAlgorithmHandlerViewModel(DllAlgorithmHandlerModel dllAlgorithmAndGraphModel)
        {
            model = dllAlgorithmAndGraphModel;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public string VM_DllPath
        {
            get { return model.DllPath; }
            set { model.DllPath = value; }
        }

        public void setValues(Dictionary<string, List<float>> values, List<string> keysList)
        {
            model.setValues(values, keysList);
        }
        public void StartDllHandling(string path)
        {
            model.StartDllHandling(path);
        }
    }
}
