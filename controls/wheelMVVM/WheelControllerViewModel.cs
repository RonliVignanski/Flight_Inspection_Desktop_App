using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FlightGearApp
{
    public class WheelControllerViewModel : INotifyPropertyChanged
    {
        WheelControllerModel wheelControllerModel;

        public WheelControllerViewModel(WheelControllerModel wheelControllerModel)
        {
            this.wheelControllerModel = wheelControllerModel;
            this.wheelControllerModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
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

        public void setMap(Dictionary<string, List<float>> value)
        {
            wheelControllerModel.setMap(value);
        }

        public int VM_Time
        {
            get { return wheelControllerModel.Time; }
            set { wheelControllerModel.Time = value; }
        }

        public int VM_Pace
        {
            get { return wheelControllerModel.Pace; }
            set { wheelControllerModel.Pace = value; }
        }

        public bool VM_ShouldStop
        {
            get { return wheelControllerModel.ShouldStop; }
            set { wheelControllerModel.ShouldStop = value; }
        }

        public float VM_Alieron
        {
            get { return wheelControllerModel.Alieron; }
            set { wheelControllerModel.Alieron = value; }
        }

        public float VM_Elevator
        {
            get { return wheelControllerModel.Elevator; }
            set { wheelControllerModel.Elevator = value; }
        }

        public float VM_Rudder
        {
            get { return wheelControllerModel.Rudder; }
            set { wheelControllerModel.Rudder = value; }
        }

        public float VM_Throttle
        {
            get { return wheelControllerModel.Throttle; }
            set { wheelControllerModel.Throttle = value; }
        }

        public void run()
        {
            wheelControllerModel.run();
        }
    }
}
