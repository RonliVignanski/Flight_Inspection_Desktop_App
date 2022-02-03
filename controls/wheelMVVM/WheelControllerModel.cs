using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightGearApp
{
    public class WheelControllerModel : INotifyPropertyChanged
    {
        private volatile float alieron;
        private volatile float elevator;
        private volatile float rudder;
        private volatile float throttle;
        private int time;
        private int pace;
        private volatile bool shouldStoped;
        private volatile Dictionary<string, List<float>> map;
        private int flightLength;

        public WheelControllerModel()
        {
            time = 0;
            pace = 100;
            alieron = 125;
            elevator = 125;
            rudder = 0;
            throttle = 0;
            shouldStoped = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }

        }

        public void setMap(Dictionary<string, List<float>> value)
        {
            map = value;
            setFlightLength();
        }

        public void setFlightLength()
        {
            flightLength = map["elevator1"].Count;
        }

        public int Time
        {
            get { return time; }
            set {
                time = value;
                NotifyPropertyChanged("Time");
            }
        }
        public int Pace
        {
            get { return pace; }
            set {
                pace = value;
                NotifyPropertyChanged("Pace");
            }
        }

        public bool ShouldStop
        {
            get { return shouldStoped; }
            set {
                shouldStoped = value;
                if (value == false)
                {
                    run();
                }
                NotifyPropertyChanged("ShouldStop");
            }
        }

        public float Alieron
        {
            get { return alieron; }
            set {
                alieron = value * 100 + 125;
                NotifyPropertyChanged("Alieron");
            }
        }

        public float Elevator
        {
            get { return elevator; }
            set {
                elevator = value * 100 + 125;
                NotifyPropertyChanged("Elevator");
            }
        }

        public float Rudder
        {
            get { return rudder; }
            set {
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }

        public float Throttle
        {
            get { return throttle; }
            set {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }

        public void showLine(int time)
        {
            Alieron = map["aileron1"][time];
            Elevator = map["elevator1"][time];
            Rudder = map["rudder1"][time];
            Throttle = map["throttle1"][time];
        }

        public void run()
        {
            Thread t = new Thread(
                delegate ()
                {
                    while (time < flightLength && !shouldStoped)
                    {
                        showLine(time);
                        Thread.Sleep(pace);
                        time++;
                    }
                }
            );
            t.Start();
        }
    }
}
