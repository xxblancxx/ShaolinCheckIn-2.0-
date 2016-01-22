using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Shaolin_Check_In.Annotations;
using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;
using Shaolin_Check_In.View;

namespace Shaolin_Check_In.ViewModels
{
    class NewStudentViewModel : ViewModel, INotifyPropertyChanged
    {
        private string _username;
        private RelayArgCommand<Club> _pickClubCommand;
        private ObservableCollection<Team> _teamList;
        private RelayArgCommand<Team> _createStudentWithTeam;

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

        public string Name
        {
            get { return _username; }
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged();
            }
        }

        public RelayArgCommand<Team> CreateStudentWithTeam

        {
            get
            {
                _createStudentWithTeam = new RelayArgCommand<Team>(CreateStudent);
                return _createStudentWithTeam;
            }
            set { _createStudentWithTeam = value; }
        }

        public RelayArgCommand<Club> PickClubCommand
        {
            get
            {
                _pickClubCommand = new RelayArgCommand<Club>(SortTeamsByClub);
                return _pickClubCommand;
            }
            set { _pickClubCommand = value; }
        }

        public void SortTeamsByClub(Club club)
        {
            var tempTeamlist = new ObservableCollection<Team>();

            foreach (var team in _sCommon.TeamList)
            {
                if (team.Club == club.Id)
                {
                    tempTeamlist.Add(team);
                }
            }
            TeamList = tempTeamlist;
        }
        public async void CreateStudent(Team team)
        {
            if (Name == null || Name == "")
            {
                MsgDialog = new MessageDialog("Indtast medlemmets navn.");
                MsgDialog.ShowAsync();
            }
            else if (team != null)
            {
                int teamNumber = team.Id;
                Student newStudent = new Student(Name, teamNumber);
                await WsContext.CreateStudent(newStudent);
                WsContext.LoadStudents();
                frame.Navigate(typeof (CreateNewPage));
            }
            
        
        }
        public override void SetSelectedObject(object obj) {/* Do Nothing Really*/}

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
