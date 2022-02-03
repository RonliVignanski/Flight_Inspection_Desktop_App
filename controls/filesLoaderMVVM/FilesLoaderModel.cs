using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace FlightGearApp
{
    class FilesLoaderModel : INotifyPropertyChanged
    {

        private IFilesParser fp;
        private IFilesParser fpForAnomalyCsv;
        private string excepCsv;
        private string excepXml;
        private string XMLPath;
        private string CSVPath;
        private string CSVAnomalyPath;

        public FilesLoaderModel()
        {
            excepCsv = "";
            excepXml = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public string xmlPath
        {
            get { return XMLPath; }
            set { XMLPath = value; }
        }
        public string XML_exception
        {
            get { return excepXml; }
            set {
                excepXml = value;
                NotifyPropertyChanged("XML_exception");
            }
        }
        public string CSVLearnpath
        {
            get { return CSVPath; }
            set { CSVPath = value; }
        }
        public string CSVAnomalypath
        {
            get { return CSVAnomalyPath; }
            set { CSVAnomalyPath = value; }
        }

        public string CSVLearn_exception
        {
            get { return excepCsv; }
            set {
                excepCsv = value;
                NotifyPropertyChanged("CSVLearn_exception");
            }
        }

        public string CSVAnomaly_exception
        {
            get { return excepCsv; }
            set {
                excepCsv = value;
                NotifyPropertyChanged("CSVAnomaly_exception");
            }
        }

        public string parseXML()
        {
            try
            {
                fp.parseXML();
                fpForAnomalyCsv.parseXML();
            }
            catch (Exception e)
            {
                if (e.Message == "xmlPath is not valid!")
                {
                    XML_exception = "xmlPath is not valid!";
                    return "xmlPath is not valid!";
                }
            }
            XML_exception = "";
            return "";
        }

        public string MatchXMLToCSV()
        {
            CSVLearn_exception = "";
            CSVAnomaly_exception = "";
            try
            {
                fp.matchXMLToCSV();
                fp.parseCSV();
            }
            catch (Exception e)
            {
                if (e.Message == "csvPath is not valid!")
                {
                    CSVLearn_exception = "csvLearnPath is not valid!";
                    try
                    {
                        fpForAnomalyCsv.matchXMLToCSV();
                        fpForAnomalyCsv.parseCSV();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "csvPath is not valid!")
                        {
                            CSVAnomaly_exception = "csvAnomalyPath is not valid!";
                            return "csvAnomalyPath is not valid!";
                        }
                    }
                    return "csvLearnPath is not valid!";
                }
            }
            try
            {
                fpForAnomalyCsv.matchXMLToCSV();
                fpForAnomalyCsv.parseCSV();
            }
            catch (Exception e)
            {
                if (e.Message == "csvPath is not valid!")
                {
                    CSVAnomaly_exception = "csvAnomalyPath is not valid!";
                    return "csvAnomalyPath is not valid!";
                }
            }
            CSVLearn_exception = "";
            CSVAnomaly_exception = "";
            return "";

        }

        public string createNewCsv()
        {
            CSVLearn_exception = "";
            CSVAnomaly_exception = "";
            try
            {
                fp.CreateRegCsv();
                fpForAnomalyCsv.CreateAnomalyCsv();
            }
            catch (Exception e)
            {
                if (e.Message == "csvPath is not valid!")
                {
                    CSVLearn_exception = "csvLearnPath is not valid!";
                    return "csvPath is not valid!";
                }
                CSVLearn_exception = "";
            }
            CSVLearn_exception = "";
            return "";
        }



        public IFilesParser getFilesParser()
        {
            return fp;
        }
        public IFilesParser getFilesParserForAnomalyCsv()
        {
            return fpForAnomalyCsv;
        }

        public void initializeParserForLearnCsv(string xmlPath, string csvPath)
        {
            fp = new FilesParser(csvPath, xmlPath);
        }

        public void initializeParserForAnomalyCsv(string xmlPath, string csvPath)
        {
            fpForAnomalyCsv = new FilesParser(csvPath, xmlPath);
        }
    }
}