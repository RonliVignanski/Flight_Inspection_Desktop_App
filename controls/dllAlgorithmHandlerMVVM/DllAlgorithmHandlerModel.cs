using FlightGearApp.windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightGearApp.controls.DllAlgorithmAndGraphHandlerMVVM
{
    public class DllAlgorithmHandlerModel : INotifyPropertyChanged
    {
        private string dllPath;
        private volatile Dictionary<string, List<float>> XML_CSVMap;
        private List<string> keysList;

        public DllAlgorithmHandlerModel()
        {
            XML_CSVMap = new Dictionary<string, List<float>>();
            keysList = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string DllPath
        {
            get
            {
                return dllPath;
            }
            set { NotifyPropertyChanged(dllPath); ; dllPath = value; }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void StartDllHandling(string path)
        {
            dllPath = path;
            DllAlgorithmGraph dllAlgorithmGraph = new DllAlgorithmGraph(dllPath, XML_CSVMap, keysList);
            dllAlgorithmGraph.learnAndDetect();
            dllAlgorithmGraph.Show();
            dllAlgorithmGraph.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }

        public void setValues(Dictionary<string, List<float>> newValues, List<string> newKeysList)
        {
            XML_CSVMap = newValues;
            keysList = newKeysList;
        }
    }
}
