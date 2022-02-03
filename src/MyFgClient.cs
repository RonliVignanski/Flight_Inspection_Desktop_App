using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightGearApp
{
    class MyFgClient : IFgClient
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private volatile bool isConnectionIsSet; 

        public MyFgClient() { isConnectionIsSet = false; }

        public TcpClient TcpClient
        {
            get { return tcpClient; }
        }
        public NetworkStream NetworkStream
        {
            get { return networkStream; }
        }

        public void closeConnection()
        {
            networkStream.Close();
            tcpClient.Close();
            isConnectionIsSet = false;
        }

        //return -1 if failed
        public int setConnection(string IP, int port)
        {
            try
            {
                tcpClient = new TcpClient(IP, port);
                networkStream = tcpClient.GetStream();
                isConnectionIsSet = true;
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        public void send(string data)
        {
            if(networkStream == null)
            {
                return;
            }
            try{
                byte[] msgToSend = Encoding.ASCII.GetBytes(data);
                networkStream.Write(msgToSend, 0, msgToSend.Length);
                networkStream.Flush();
            }
            catch { }
        }

        public void send(string dataPath, float value)
        {
            byte[] msgToSend = Encoding.ASCII.GetBytes("set " + dataPath + " " + value.ToString());
            networkStream.Write(msgToSend, 0, msgToSend.Length);
            networkStream.Flush();
        }
    }
}
