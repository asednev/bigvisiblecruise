using System;
using System.ComponentModel;

namespace CruiseControlToys.Lib
{

    public class ProjectStatus : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _currentBuildStatus;
        private string _name;
        private DateTime _measuredAt;

        public string CurrentBuildStatus
        {
            get 
            {
                return _currentBuildStatus; 
            }
            set 
            {
                _currentBuildStatus = value;
                NotifyPropertyChanged("CurrentBuildStatus");
            }
        }

        public string Name 
        { 
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public DateTime MeasuredAt
        {
            get
            {
                return _measuredAt;
            }
            set
            {
                _measuredAt = value;
                NotifyPropertyChanged("MeasuredAt");
            }
        }

        public ProjectStatus()
        {

        }

        public ProjectStatus(string projectName, string currentBuildStatus) 
        {
            this.Name = projectName;
            this.CurrentBuildStatus = currentBuildStatus;
            this.MeasuredAt = DateTime.Now;
        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }

}
