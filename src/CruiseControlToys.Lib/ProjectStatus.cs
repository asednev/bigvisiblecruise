using System;
using System.ComponentModel;

namespace CruiseControlToys.Lib
{

    public class ProjectStatus
    {

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
            set
            {
                _measuredAt = value;
            }
        }

        public ProjectStatus(string projectName, string currentBuildStatus) 
        {
            this.Name = projectName;
            this.CurrentBuildStatus = currentBuildStatus;
            this.MeasuredAt = DateTime.Now;
        }

    }

}
