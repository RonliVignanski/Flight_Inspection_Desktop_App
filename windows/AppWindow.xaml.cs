using FlightGearApp.controls;
using Microsoft.Win32;
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

namespace FlightGearApp.windows
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        string XMLPath;
        public AppWindow(IFilesParser fpForLearnCsv, IFilesParser fpForAnomalyCsv)
        {
            InitializeComponent();
            XMLPath = fpForLearnCsv.XMLpath;
            TimeConroller.setTimeControllerValues(fpForAnomalyCsv.getCSV());
            DllAlgorithmHandler.setValues(fpForAnomalyCsv.getXML_CSVMap(), fpForAnomalyCsv.XMLlist);
            DllAlgorithmHandler.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                TimeConroller.setTime(Int32.Parse(e.PropertyName));
            };
            TimeConroller.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                string property = e.PropertyName;
                string[] propertyValues = new string[2];
                propertyValues = property.Split('-');
                if (propertyValues[0] == "Time")
                {
                    FlightInfo.setTime(Int32.Parse(propertyValues[1]));
                    WheelController.setTime(Int32.Parse(propertyValues[1]));
                    GraphController.setTime(Int32.Parse(propertyValues[1]));
                }
                else if (propertyValues[0] == "ShouldStop")
                {
                    if (propertyValues[1] == "true")
                    {
                        FlightInfo.setShouldStop(true);
                        WheelController.setShouldStop(true);
                        GraphController.setShouldStop(true);
                    }
                    else
                    {
                        FlightInfo.setShouldStop(false);
                        WheelController.setShouldStop(false);
                        GraphController.setShouldStop(false);
                    }
                }
                else if (propertyValues[0] == "Pace")
                {
                    FlightInfo.setPace(Int32.Parse(propertyValues[1]));
                    WheelController.setPace(Int32.Parse(propertyValues[1]));
                    WheelController.setPace(Int32.Parse(propertyValues[1]));
                }
            };

            FlightInfo.setFlightValues(fpForAnomalyCsv.getXML_CSVMap());
            FlightInfo.run();
            WheelController.setMapValues(fpForAnomalyCsv.getXML_CSVMap());
            WheelController.run();
            GraphController.setMaps(fpForLearnCsv.getXML_CSVMap(), fpForLearnCsv.XMLlist, fpForAnomalyCsv.getXML_CSVMap());
            GraphController.run();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String newCSVPath = "";
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "CSV files(*.csv)| *.csv";
            if (fd.ShowDialog() == true)
            {
                newCSVPath = fd.FileName;
                FilesParser newAnomaly = new FilesParser(newCSVPath, XMLPath);
                newAnomaly.parseXML();
                newAnomaly.matchXMLToCSV();
                newAnomaly.parseCSV();
                newAnomaly.CreateAnomalyCsv();

                TimeConroller.setTimeControllerValues(newAnomaly.getCSV());
                FlightInfo.setFlightValues(newAnomaly.getXML_CSVMap());
                WheelController.setMapValues(newAnomaly.getXML_CSVMap());
                GraphController.updateAnomalyMap(newAnomaly.XMLlist, newAnomaly.getXML_CSVMap());
                DllAlgorithmHandler.setValues(newAnomaly.getXML_CSVMap(), newAnomaly.XMLlist);
            }
        }

        private void Disconnect_Button(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
