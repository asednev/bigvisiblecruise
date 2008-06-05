using System;
using System.ComponentModel;

namespace CruiseControlToys.Lib
{

    public class ProjectStatus
    {

        private string _currentBuildStatus;
        private string _name;
        private DateTime _measuredAt;
        private DateTime _lastBuildTime;

        public string CurrentBuildStatus
        {
            get 
            {
                return _currentBuildStatus; 
            }
            set 
            {
                _currentBuildStatus = value;
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
            }
        }

        public DateTime MeasuredAt
        {
            get
            {
                return _measuredAt;
            }
            private set
            {
                _measuredAt = value;
            }
        }

        public DateTime LastBuildTime
        {
            get { return _lastBuildTime; }
            set { _lastBuildTime = value; }
        }

        public ProjectStatus(string projectName, string currentBuildStatus, DateTime lastBuildTime) 
        {
            this.Name = projectName;
            this.CurrentBuildStatus = currentBuildStatus;
            this.MeasuredAt = DateTime.Now;
            this.LastBuildTime = lastBuildTime;
        }

    }

}
