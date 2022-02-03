using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace FlightGearApp
{
    class FlightInfoModel : INotifyPropertyChanged
    {
        private volatile float altitude;
        private volatile float speed;
        private volatile float direction;
        private volatile float yaw;
        private volatile float roll;
        private volatile float pitch;
        private volatile int time;
        private volatile int pace;
        private volatile bool shouldStoped;
        private volatile Dictionary<string, List<float>> map;
        private int numOfLines;
        private float angleSpeed;
        private float angleAltitude;
        private float angleDirection;

        public FlightInfoModel()
        {
            shouldStoped = true;
            pace = 100;
            time = 0;
            altitude = 0;
            speed = 0;
            direction = 0;
            yaw = 0;
            roll = 0;
            pitch = 0;
            angleSpeed = 0;
            angleAltitude = 0;
            angleDirection = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
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

        public float AngleSpeed
        {
            get { return angleSpeed; }
            set {
                angleSpeed = value;
                NotifyPropertyChanged("AngleSpeed");
            }
        }
        public float AngleAltitude
        {
            get { return angleAltitude; }
            set {
                angleAltitude = value;
                NotifyPropertyChanged("AngleAltitude");
            }
        }
        public float AngleDirection
        {
            get { return angleDirection; }
            set {
                angleDirection = value;
                NotifyPropertyChanged("AngleDirection");
            }
        }

        public float Altitude
        {
            get { return altitude; }
            set {
                altitude = value;
                NotifyPropertyChanged("Altitude");
            }
        }

        public float Speed
        {
            get { return speed; }
            set {
                speed = value;
                NotifyPropertyChanged("Speed");
            }
        }
        public float Direction
        {
            get { return direction; }
            set {
                direction = value;
                NotifyPropertyChanged("Direction");
            }
        }
        public float Yaw
        {
            get { return yaw; }
            set {
                yaw = value;
                NotifyPropertyChanged("Yaw");
            }
        }
        public float Roll
        {
            get { return roll; }
            set {
                roll = value;
                NotifyPropertyChanged("Roll");
            }
        }
        public float Pitch
        {
            get { return pitch; }
            set {
                pitch = value;
                NotifyPropertyChanged("Pitch");
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
        public void ChangeTimeAndPace(int time)
        {
            Time = time;
        }

        public void setMap(Dictionary<string, List<float>> value)
        {
            map = value;
            findNumOfLines();
        }

        public void findNumOfLines()
        {
            numOfLines = map["elevator1"].Count;
        }

        public void run()
        {
            Thread t = new Thread(
                delegate ()
                {
                    while (time < numOfLines && !shouldStoped)
                    {
                        showLine(time);
                        time++;
                        Thread.Sleep(pace);
                    }
                }
            );
            t.Start();
        }

        public void showLine(int time)
        {
            Altitude = map["altimeter_indicated-altitude-ft1"][time];
            AngleAltitude = -130 + 256 * (Altitude / map["altimeter_indicated-altitude-ft1"].Max());
            Speed = map["airspeed-kt1"][time];
            float maxSpeed =map["airspeed-kt1"].Max();
            AngleSpeed = -129 + 256 * (Speed / maxSpeed);
            Direction = map["indicated-heading-deg1"][time];
            AngleDirection = -130 + 256 * (Direction / map["indicated-heading-deg1"].Max());
            Yaw = map["side-slip-deg1"][time];
            Roll = map["roll-deg1"][time];
            Pitch = map["pitch-deg1"][time];
        }
    }
}
