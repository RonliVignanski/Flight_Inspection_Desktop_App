using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightGearApp.controls
{
    public class DllAlgorithmGraphViewModel : INotifyPropertyChanged
    {
        DllAlgorithmGraphModel model;
        public DllAlgorithmGraphViewModel(DllAlgorithmGraphModel m)
        {
            model = m;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void learnAndDetect()
        {
            model.learnAndDetect();
        }

        public PlotModel VM_Graph
        {
            get { return model.Graph; }
            set { model.Graph = value; }
        }

        public string VM_SelectedDataName
        {
            get { return model.SelectedDataName; }
            set { model.SelectedDataName = value; }
        }

        public List<string> VM_Anomalies
        {
            get { return model.Anomalies; }
            set { model.Anomalies = value; }
        }

        public void drawGraph()
        {
            model.drawGraph();
        }

        public void setSelectedData(string data)
        {
            model.SelectedDataName = data;
        }

        public float getTimeStepOfAnomalyReport(string report)
        {
            return model.getTimeStepOfAnomalyReport(report);
        }
    }
}
