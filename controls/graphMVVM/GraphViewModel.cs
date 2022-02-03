using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace FlightGearApp
{
    class GraphViewModel : INotifyPropertyChanged
    {
        private GraphModel model;

        public GraphViewModel()
        {
            this.model = new GraphModel();

            this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
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
        public int VM_Time
        {
            get { return model.Time; }
            set { model.Time = value; }
        }
        public int VM_Pace
        {
            get { return model.Pace; }
            set { model.Pace = value; }
        }
        public bool VM_ShouldStop
        {
            get { return model.ShouldStop; }
            set { model.ShouldStop = value; }
        }

        public string VM_SelectedDataName
        {
            get { return model.SelectedDataName; }
            set { model.SelectedDataName = value; }
        }

        public PlotModel VM_ModelGraph { get { return model.ModelGraph; } set { model.ModelGraph = value; } }
        public PlotModel VM_ModelCorrelationGraph
        {
            get { return model.ModelCorrelationGraph; }
            set { model.ModelCorrelationGraph = value; }
        }
        public PlotModel VM_RegLine { get { return model.RegLine; } set { model.RegLine = value; } }

        public List<string> getStringsDataList() { return model.getStringsList(); }
        public void setMaps(Dictionary<string, List<float>> learnMap, List<string> strings, Dictionary<string, List<float>> anomalyMap)
        {
            model.setMaps(learnMap, strings,anomalyMap);
        }

        public void updateAnomalyMap(List<string> strings, Dictionary<string, List<float>> anomalyMap)
        {
            model.updateAnomalyMap(strings, anomalyMap);
        }

        public void run()
        {
            this.model.run();
        }
    }
}
