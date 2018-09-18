// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using UIComposition.EmployeeModule.Models;

namespace UIComposition.EmployeeModule.ViewModels
{
    /// <summary>
    /// View model to support the Employee Details view.
    /// </summary>
    public class EmployeeDetailsViewModel : INotifyPropertyChanged
    {
        private Employee _currentEmployee;

        public string ViewName
        {
            get { return "Employee Details"; }
        }
        
        public Employee CurrentEmployee
        {
            get { return _currentEmployee; }
            set
            {
                _currentEmployee = value;
                NotifyPropertyChanged("CurrentEmployee");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}