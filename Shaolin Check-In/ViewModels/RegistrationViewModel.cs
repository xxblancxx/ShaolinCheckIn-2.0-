﻿using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Shaolin_Check_In.Common;

namespace Shaolin_Check_In.ViewModels
{
    class RegistrationViewModel : ViewModel, INotifyPropertyChanged
    {

        private string _searchText;
      
        private ObservableCollection<StudentRegistration> _localStudentRegistrations;


        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value == _searchText) return;
                _searchText = value;
                OnPropertyChanged();
                SearchForStudentName(SearchText);
            }
        }

        

        public ObservableCollection<StudentRegistration> LocalStudentRegistrations
        {
            get
            { // OrderByDescending so newest Registration is shown first.
                _localStudentRegistrations = new ObservableCollection<StudentRegistration>(_localStudentRegistrations.OrderByDescending(s => s.TimeStamp));
                return _localStudentRegistrations; ;
            }
            set
            {
                if (Equals(value, _localStudentRegistrations)) return;
                _localStudentRegistrations = value;
                OnPropertyChanged();
            }
        }

        public override void SetSelectedObject(object obj)
        {
            // Not implemented as of yet. No plans to do so, before thinking of altering existing registrations
        }

        public RegistrationViewModel()
        {
            LocalStudentRegistrations = SCommon.StudentRegistrationList;
            //SearchDate = DateTime.Today;
        }
        public void SearchForStudentName(string name)
        { // Search List of StudentRegistrations, for specific student name.

            var studreg = new ObservableCollection<StudentRegistration>();
            if (name != "")
            {
                foreach (var sr in SCommon.StudentRegistrationList)
                {
                    if (sr.Name.ToLower().Contains(name.ToLower()))
                    {
                        studreg.Add(sr);
                    }
                    LocalStudentRegistrations = studreg;
                }
            }
            else
            {
                LocalStudentRegistrations = SCommon.StudentRegistrationList;
            }
        }

       

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
