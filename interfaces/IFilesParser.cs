using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightGearApp
{
    public interface IFilesParser
    {
        string XMLpath { get; set; }

        string CSVpath { get; set; }

        List<string> XMLlist { get; set; }

        Dictionary<string, List<float>> XML_CSVmap { get; set; }

        Dictionary<int, string> CSVmap { get; set; }


        void parseXML();

        void matchXMLToCSV();

        void parseCSV();

        Dictionary<int, string> getCSV();

        Dictionary<string, List<float>> getXML_CSVMap();

        string getLineFromCsv(int index);

        List<float> getCsvColumn(string name);

        void CreateRegCsv();

        void CreateAnomalyCsv();

    }
}