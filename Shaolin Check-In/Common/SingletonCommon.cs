using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Check_In.Common
{

    class SingletonCommon : INotifyPropertyChanged
    {
        private static SingletonCommon _instance = new SingletonCommon();
        private ObservableCollection<Club> _clubList;
        private ObservableCollection<Team> _teamList;
        private ObservableCollection<Student> _studentList;
        private ObservableCollection<StudentRegistration> _studentRegistrationList;
        private ObservableCollection<Registration> _registrationList;
        private ObservableCollection<StudentRegistration> _displayedStudentRegistrations;
        private string _frontpageMessage;

        public List<UserLogin> UserLoginList { get; set; }

        public ObservableCollection<Message> MessageList { get; set; }

        public ObservableCollection<StudentRegistration> DisplayedStudentRegistrations
        {
            get
            {
                if (_displayedStudentRegistrations != null)
                {
                      _displayedStudentRegistrations =
                    new ObservableCollection<StudentRegistration>(_displayedStudentRegistrations.OrderByDescending(s => s.TimeStamp));
                }
              
                return _displayedStudentRegistrations;
            }
            set
            {
                _displayedStudentRegistrations = value;
                OnPropertyChanged();
            }
        }

        public string FrontpageMessage
        {
            get { return _frontpageMessage; }
            set
            {
                _frontpageMessage = value;
                OnPropertyChanged();
            }
        }

        //Bool to see if all main gets from db already happened on Startup.
        public bool AlreadyLoaded { get; set; }

        //These "Selected" properties, hold the lastly chosen one in next page.
        public Club SelectedClub { get; set; }
        public Team SelectedTeam { get; set; }

        //Current list of Registrations in Database
        public ObservableCollection<Registration> RegistrationList
        {
            get { return _registrationList; }
            set
            {
                if (Equals(value, _registrationList)) return;
                _registrationList = value;
                OnPropertyChanged();
            }
        }

        //Current list of StudentRegistrations (Id, Name, Timestamp)
        public ObservableCollection<StudentRegistration> StudentRegistrationList
        {
            get { return _studentRegistrationList; }
            set
            {
                if (Equals(value, _studentRegistrationList)) return;
                _studentRegistrationList = value;
                OnPropertyChanged();
            }
        }

        //Current list of Clubs
        public ObservableCollection<Club> ClubList
        {
            get { return _clubList; }
            set
            {
                if (Equals(value, _clubList)) return;
                _clubList = value;
                OnPropertyChanged();
            }
        }

        //Current list of Teams
        public ObservableCollection<Team> TeamList
        {
            get { return _teamList; }
            set
            {
                if (Equals(value, _teamList)) return;
                _teamList = value;
                OnPropertyChanged();
            }
        }

        //Current list of Students
        public ObservableCollection<Student> StudentList
        {
            get { return _studentList; }
            set
            {
                if (Equals(value, _studentList)) return;
                _studentList = value;
                OnPropertyChanged();
            }
        }



        public static SingletonCommon Instance
        {
            get { return _instance; }
            private set { }
        }

        //private Constructor, only Instance can initialize.
        private SingletonCommon() { }

        public void SetFrontpageMessage()
        {
            if (MessageList != null)
            {
                var newestMessage = new Message(null, false, 0);
                foreach (var message in MessageList)
                {
                    if (message.Id > newestMessage.Id && message.Frontpage)
                    {
                        newestMessage = message;
                    }
                }
                FrontpageMessage = newestMessage.ToString();
            }
        }



        #region OnPropertyChanged Handlers
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}


