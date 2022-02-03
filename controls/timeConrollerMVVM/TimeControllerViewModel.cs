using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FlightGearApp
{
    public class TimeControllerViewModel : INotifyPropertyChanged
    {
        TimeControllerModel timeControllerModel;

        public TimeControllerViewModel(TimeControllerModel timeControllerModel)
        {
            this.timeControllerModel = timeControllerModel;
            timeControllerModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
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

        public void setMap(Dictionary<int, string> value)
        {
            timeControllerModel.setMap(value);
        }

        public int VM_Time
        {
            get { return timeControllerModel.Time; }
            set { timeControllerModel.Time = value; }
        }

        public int VM_FlightLength
        {
            get { return timeControllerModel.FlightLength; }
        }

        public int VM_Pace
        {
            get { return timeControllerModel.Pace; }
            set { timeControllerModel.Pace = value; }
        }

        public string VM_PassTime
        {
            get { return timeControllerModel.PassTime; }
            set { timeControllerModel.PassTime = value; }
        }

        public string VM_AllTime
        {
            get { return timeControllerModel.AllTime; }
            set { timeControllerModel.AllTime = value; }
        }

        public void StartApp()
        {
            timeControllerModel.StartApp();
        }

        public void Run()
        {
            timeControllerModel.Run();
        }

        public void PauseFlight()
        {
            timeControllerModel.PauseFlight();
        }

        public void ResetFlight()
        {
            timeControllerModel.ResetFlight();
        }

        public void EditPace(int newPace)
        {
            timeControllerModel.EditPace(newPace);
        }

        public void setTime(int time)
        {
            timeControllerModel.Time = time;
        }
    }
}
