using System;
using System.ComponentModel;

namespace FlightGearApp
{
    class FilesLoaderViewModel : INotifyPropertyChanged
    {
        private FilesLoaderModel fmodel;

        public FilesLoaderViewModel(FilesLoaderModel fm)
        {
            fmodel = fm;
            this.fmodel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string VM_xmlPath
        {
            get { return fmodel.xmlPath; }
            set { fmodel.xmlPath = value; }
        }
        public string VM_XML_exception
        {
            get { return fmodel.XML_exception;}
        }

        public string VM_CSVLearnpath
        {
            get { return fmodel.CSVLearnpath; }
            set { fmodel.CSVLearnpath = value; }
        }

        public string VM_CSVAnomalypath
        {
            get { return fmodel.CSVAnomalypath; }
            set { fmodel.CSVAnomalypath = value; }
        }


        public string VM_CSVLearn_exception
        {
            get { return fmodel.CSVLearn_exception; }
        }
        public string VM_CSVAnomaly_exception
        {
            get { return fmodel.CSVAnomaly_exception; }
        }

        public string MatchXMLToCSV()
        {
            return fmodel.MatchXMLToCSV();
        }

        public string parseXML()
        {
            return fmodel.parseXML();
        }

        public string createNewCsv()
        {
            return fmodel.createNewCsv();
        }

        public void initializeParserForLearnCsv(string xmlPath, string csvPath)
        {
            fmodel.initializeParserForLearnCsv(xmlPath, csvPath);
        }
        public void initializeParserForAnomalyCsv(string xmlPath, string csvPath)
        {
            fmodel.initializeParserForAnomalyCsv(xmlPath, csvPath);
        }

        public IFilesParser getFilesParser()
        {
            return fmodel.getFilesParser();
        }
        public IFilesParser getFilesParserForAnomalyCsv()
        {
            return fmodel.getFilesParserForAnomalyCsv();
        }
    }
}