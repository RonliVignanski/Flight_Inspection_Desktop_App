using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace FlightGearApp
{
    interface IFgClient
    {
        TcpClient TcpClient { get;}
        NetworkStream NetworkStream { get; }

        int setConnection(string IP, int port);
        void closeConnection();
        //write line of data from CSV
        void send(string data);
        //set the value of a data with its path from XML by sending a "set" msg to the FG
        void send(string dataPath, float value);

    }
}
