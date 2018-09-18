// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Windows.Data;
using UIComposition.EmployeeModule.Models;
using UIComposition.EmployeeModule.Services;

namespace UIComposition.EmployeeModule.ViewModels
{
    /// <summary>
    /// View model to support the Employee Projects view.
    /// </summary>
    public class EmployeeProjectsViewModel : INotifyPropertyChanged
    {
        public EmployeeProjectsViewModel(IEmployeeDataService dataService)
        {
            if (dataService == null) throw new ArgumentNullException("dataService");

            // Initialize a CollectionView for the project list.
            Projects = new ListCollectionView(dataService.GetProjects());
        }

        public string ViewName
        {
            get { return "Employee Projects"; }
        }

        private Employee _currentEmployee;

        public Employee CurrentEmployee
        {
            get { return _currentEmployee; }
            set
            {
                _currentEmployee = value;

                // Filter the list of projects to those that are assigned to the current employee.
                if (CurrentEmployee != null)
                {
                    Projects.Filter = obj => ((Project)obj).Id == CurrentEmployee.Id;
                }

                Projects.Refresh();

                NotifyPropertyChanged("CurrentEmployee");
                NotifyPropertyChanged("Projects");
            }
        }

        public ICollectionView Projects { get; private set; }

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