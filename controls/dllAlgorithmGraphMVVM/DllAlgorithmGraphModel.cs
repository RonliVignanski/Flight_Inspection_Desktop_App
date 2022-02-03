using FlightGearApp.src;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightGearApp.controls
{
    public class DllAlgorithmGraphModel : INotifyPropertyChanged
    {
        private string dllPath;
        private volatile Dictionary<string, List<float>> XML_CSVMap;
        private List<string> keysList;
        private List<AnomalyReports> anomalyReports;
        List<string> anomaliesToDisplay;
        private List<string> corrFeatures;
        private string selectedItem;
        private PlotModel graphToDraw;
        private object instance;

        public DllAlgorithmGraphModel(string path, Dictionary<string, List<float>> values, List<string> keys)
        {
            dllPath = path;
            XML_CSVMap = values;
            keysList = keys;
            anomalyReports = new List<AnomalyReports>();
            corrFeatures = new List<string>();
            selectedItem = keys[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PlotModel Graph
        {
            get { return graphToDraw; }
            set { graphToDraw = value; NotifyPropertyChanged("Graph"); }
        }

        public string SelectedDataName
        {
            get { return selectedItem; }
            set { selectedItem = value; NotifyPropertyChanged("SelectedDataName"); }
        }

        public List<string> Anomalies
        {
            get { return anomaliesToDisplay; }
            set { anomaliesToDisplay = value; NotifyPropertyChanged("Anomalies"); }
        }

        public object Parse { get; private set; }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void learnAndDetect()
        {
            Assembly assembly = Assembly.LoadFile(dllPath);

            Type type = assembly.GetType("AnomalyReportAlgorithm.AnomalyReportAlgorithm");

            var obj = Activator.CreateInstance(type);

            //methods
            var create = type.GetMethod("Create_Algorithm_Learn_And_Detect");

            var getAnomalyReports = type.GetMethod("Get_Anomaly_Reports");

            var getNumOfReports = type.GetMethod("Get_Num_Of_Reports");

            var getAnomalyReportDescriptionByIndex = type.GetMethod("Get_Anomaly_Reports_Description_By_Index");

            var getAnomalyReportTimestepByIndex = type.GetMethod("Get_Anomaly_Reports_TimeStep_By_Index");

            var getCorrFeatures = type.GetMethod("Get_Corr_Features");

            //invoke methods
            instance = create.Invoke(obj, null);

            var numOfReports = (int)getNumOfReports.Invoke(obj, new object[] { instance });

            for (int i = 0; i < (int)numOfReports; i++)
            {
                int timeStep = (int)getAnomalyReportTimestepByIndex.Invoke(obj, new object[] { instance, i });
                string report = (string)getAnomalyReportDescriptionByIndex.Invoke(obj, new object[] { instance, i });
                anomalyReports.Add(new AnomalyReports(report, timeStep));
            }
        }

        public void drawGraph()
        {
            Assembly assembly = Assembly.LoadFile(dllPath);

            Type type = assembly.GetType("AnomalyReportAlgorithm.AnomalyReportAlgorithm");

            var obj = Activator.CreateInstance(type);

            var drawGraphMethod = type.GetMethod("Get_Graph");

            var tmp = new PlotModel { Title = SelectedDataName };

            List<string> currentAnomalies = new List<string>();
            int numOfReport = 1;
            foreach (var report in anomalyReports)
            {
                string[] items = report.description.Split('+');
                if (SelectedDataName == items[0] ||
                    SelectedDataName == items[1])
                {
                    currentAnomalies.Add(numOfReport.ToString() + ": " + items[0] + "," + items[1]);
                    numOfReport++;
                }
            }
            Anomalies = currentAnomalies;
            this.Graph = (PlotModel)drawGraphMethod.Invoke(obj, new object[] { instance, SelectedDataName ,
            XML_CSVMap});
        }

        public float getTimeStepOfAnomalyReport(string report)
        {
            int reportIndex = Int32.Parse(report.Split(':')[0]);
            string[] items = report.Split(',');
            int indexOfEndOfTheNumber = getIndexOfEndOfTheNumber(items[0]);
            if (indexOfEndOfTheNumber == -1) { Console.WriteLine("ERROR at getIndexOfEndOfTheNumber"); }
            items[0] = items[0].Remove(0, indexOfEndOfTheNumber + 1);
            for (int i = 0; i < anomalyReports.Count; i++)
            {
                string[] currentReportItems = anomalyReports[i].description.Split('+');
                if (currentReportItems[0] == items[0] && currentReportItems[1] == items[1])
                {
                    
                    if (anomalyReports[i].timeStep + reportIndex < XML_CSVMap[keysList[0]].Count)
                    {
                        return anomalyReports[i].timeStep + reportIndex;
                    }
                    else
                    {
                        return anomalyReports[anomalyReports.Count - 1].timeStep;
                    }
                }
            }
            return 0;
        }

        private int getIndexOfEndOfTheNumber(string v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                if (Char.IsDigit(v[i]))
                {
                    continue;
                }
                else
                {
                    i++;
                    return i;
                }
            }
            return -1;
        }
    }
}
