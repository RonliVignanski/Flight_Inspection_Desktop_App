using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FlightGearApp
{
    class FlightInfoViewModel : INotifyPropertyChanged
    {
        FlightInfoModel fm;

        public FlightInfoViewModel(FlightInfoModel fm)
        {
            this.fm = fm;
            this.fm.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
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


        public void run()
        {
            fm.run();
        }

        public float VM_AngleSpeed
        {
            get { return fm.AngleSpeed; }
            set { fm.AngleSpeed = value; }
        }
        public float VM_AngleAltitude
        {
            get { return fm.AngleAltitude; }
            set { fm.AngleAltitude = value; }
        }
        public float VM_AngleDirection
        {
            get { return fm.AngleDirection; }
            set { fm.AngleDirection = value; }
        }

        public int VM_Time
        {
            get { return fm.Time; }
            set { fm.Time = value; }
        }
        public int VM_Pace
        {
            get { return fm.Pace; }
            set { fm.Pace = value; }
        }
        public bool VM_ShouldStop
        {
            get { return fm.ShouldStop; }
            set {  fm.ShouldStop = value; }
        }

        public void setMap(Dictionary<string, List<float>> value)
        {
            fm.setMap(value);
        }

        public float VM_Altitude
        {
            get { return fm.Altitude; }
            set {  fm.Altitude = value; }
        }

        public float VM_Speed
        {
            get {  return fm.Speed; }
            set {  fm.Speed = value; }
        }
        public float VM_Direction
        {
            get { return fm.Direction; }
            set { fm.Direction = value; }
        }
        public float VM_Yaw
        {
            get { return fm.Yaw; }
            set { fm.Yaw = value; }
        }
        public float VM_Roll
        {
            get { return fm.Roll; }
            set { fm.Roll = value; }
        }
        public float VM_Pitch
        {
            get { return fm.Pitch; }
            set { fm.Pitch = value; }
        }
    }
}
