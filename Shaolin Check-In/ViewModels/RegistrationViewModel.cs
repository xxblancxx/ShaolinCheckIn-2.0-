using Shaolin_Check_In.Model;
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

                }
                LocalStudentRegistrations = studreg;
            }
            else
            {
                LocalStudentRegistrations = SCommon.StudentRegistrationList;
            }
        }

        public void SearchForDate(DateTimeOffset? date)
        { // Sort shown StudentRegistrations by Date.
            // TODO; View isn't updated properly ?
            string dateString = date.ToString();
            var studreg = new ObservableCollection<StudentRegistration>();
           
            if (!dateString.Contains(DateTime.Today.ToString("dd/MM/yy")))
            {
                if (dateString != "")
                {
                    foreach (var sr in SCommon.StudentRegistrationList)
                    {
                        string tempString = sr.TimeStamp.Date.ToString("MM/dd/yyyy");
                        if (dateString.Contains(tempString))
                        {
                            studreg.Add(sr);
                        }

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
