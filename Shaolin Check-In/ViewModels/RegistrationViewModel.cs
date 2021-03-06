﻿using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Shaolin_Check_In.Common;

namespace Shaolin_Check_In.ViewModels
{
    class RegistrationViewModel : ViewModel, INotifyPropertyChanged
    {

        private string _searchText;
        // private ObservableCollection<StudentRegistration> _localOnlyList;

        public DateTimeOffset? Date { get; set; }
        public Team SearchTeam { get; set; }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (value == _searchText) return;
                _searchText = value;
                OnPropertyChanged();
                SearchForDate();
            }
        }

        public ObservableCollection<StudentRegistration> LocalStudentRegistrations
        {
            get
            { // OrderByDescending so newest Registration is shown first.
                SCommon.DisplayedStudentRegistrations = new ObservableCollection<StudentRegistration>(SCommon.DisplayedStudentRegistrations.OrderByDescending(s => s.TimeStamp));
                return SCommon.DisplayedStudentRegistrations; ;
            }
            set
            {
                if (Equals(value, SCommon.DisplayedStudentRegistrations)) return;
                SCommon.DisplayedStudentRegistrations = value;
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
        

        public void SearchNameInAlreadySorted(string name)
        {
            if (name != null)
            {


                var studreg = new ObservableCollection<StudentRegistration>();
                if (name != "")
                {
                    foreach (var sr in LocalStudentRegistrations)
                    {
                        if (sr.Name.ToLower().Contains(name.ToLower()))
                        {
                            studreg.Add(sr);
                        }

                    }
                    LocalStudentRegistrations = studreg;

                }
                else
                {

                    LocalStudentRegistrations = LocalStudentRegistrations;

                }

            }
        }

        public void SearchForDate()
        { // Sort shown StudentRegistrations by Date.
            var date = Date;
            if (date != null)
            {
                string dateString = date.Value.ToString("dd/MM/yyyy");
                var studreg = new ObservableCollection<StudentRegistration>();


                if (!string.IsNullOrEmpty(SearchText))
                {
                    
                        if (dateString != "")
                        {
                            foreach (var sr in SCommon.StudentRegistrationList)
                            {
                                string tempString = sr.TimeStamp.Date.ToString("dd/MM/yyyy");
                                if (dateString.Contains(tempString))
                                {
                                    studreg.Add(sr);
                                }

                            }
                            LocalStudentRegistrations = studreg;
                            SearchNameInAlreadySorted(SearchText);
                        SearchForTeam();
                        }
                    
                }
                else if (string.IsNullOrEmpty(SearchText))
                {
                    if (dateString != "")
                    {
                        foreach (var sr in SCommon.StudentRegistrationList)
                        {
                            string tempString = sr.TimeStamp.Date.ToString("dd/MM/yyyy");
                            if (dateString.Contains(tempString))
                            {
                                studreg.Add(sr);
                            }

                        }
                        LocalStudentRegistrations = studreg;
                        SearchForTeam();
                    }
                }

            }
            else if (!string.IsNullOrEmpty(SearchText) && SearchTeam!=null)
            {
                LocalStudentRegistrations = SCommon.StudentRegistrationList;
                SearchNameInAlreadySorted(SearchText);
                SearchForTeam();
            }
            else if (string.IsNullOrEmpty(SearchText) && SearchTeam != null)
            {
                LocalStudentRegistrations = SCommon.StudentRegistrationList;
                SearchForTeam();
            }
            else if (!string.IsNullOrEmpty(SearchText))
            {
                LocalStudentRegistrations = SCommon.StudentRegistrationList;
                SearchNameInAlreadySorted(SearchText);
            }
            else if (string.IsNullOrEmpty(SearchText))
            {
                LocalStudentRegistrations = SCommon.StudentRegistrationList;
            }
        }

        public void SearchForTeam()
        {

            var studreg = new ObservableCollection<StudentRegistration>();
            if (SearchTeam != null)
            {
                foreach (var sr in LocalStudentRegistrations)
                {
                    if (sr.Team == SearchTeam.Id)
                    {
                        studreg.Add(sr);
                    }

                }
                LocalStudentRegistrations = studreg;

            }
            else
            {

                LocalStudentRegistrations = LocalStudentRegistrations;

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
