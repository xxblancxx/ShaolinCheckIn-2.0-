using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;

namespace Shaolin_Check_In.ViewModels
{
    class ActivityViewModel : ViewModel
    {
        private RelayArgCommand<Club> _setClubActivityCommand;
        private Club _club;
        private Team _team;
        private Student _student;
        private string _currentActivityType;
        private RelayArgCommand<Team> _setTeamActivityCommand;
        private RelayArgCommand<Student> _setStudentActivityCommand;

        public RelayArgCommand<Club> SetClubActivityCommand
        {
            get
            {
                _setClubActivityCommand = new RelayArgCommand<Club>(SetClubActivity);
                return _setClubActivityCommand;
            }
            set { _setClubActivityCommand = value; }
        }

        public RelayArgCommand<Team> SetTeamActivityCommand
        {
            get
            {
                _setTeamActivityCommand = new RelayArgCommand<Team>(SetTeamActivity);
                return _setTeamActivityCommand;
            }
            set { _setTeamActivityCommand = value; }
        }

        public RelayArgCommand<Student> SetStudentActivityCommand
        {
            get
            {
                _setStudentActivityCommand = new RelayArgCommand<Student>(SetStudentActivity);
                return _setStudentActivityCommand;
            }
            set { _setStudentActivityCommand = value; }
        }

        public void SetClubActivity(Club club)
        {
            _club = club;
            if (_club.IsActive)
            {
                MsgDialog = new MessageDialog(_club.Name + " er Aktiv. Vil du markere denne som Inaktiv?");
                _currentActivityType = "club";
                MsgDialog.Commands.Add(new UICommand("Ja", InactivityClick));
                MsgDialog.Commands.Add(new UICommand("Nej"));
                MsgDialog.ShowAsync();
            }
            else if (!_club.IsActive)
            {
                MsgDialog = new MessageDialog(_club.Name + " er Inaktiv. Vil du markere denne som Aktiv?");
                _currentActivityType = "club";
                MsgDialog.Commands.Add(new UICommand("Ja", ActivityClick));
                MsgDialog.Commands.Add(new UICommand("Nej"));
                MsgDialog.ShowAsync();
            }
        }
        public void SetTeamActivity(Team team)
        {
            _team = team;
            if (_team.IsActive)
            {
                MsgDialog = new MessageDialog(_team.Name + " er Aktiv. Vil du markere denne som Inaktiv?");
                _currentActivityType = "team";
                MsgDialog.Commands.Add(new UICommand("Ja", InactivityClick));
                MsgDialog.Commands.Add(new UICommand("Nej"));
                MsgDialog.ShowAsync();
            }
            else if (!_team.IsActive)
            {
                MsgDialog = new MessageDialog(_team.Name + " er Inaktiv. Vil du markere denne som Aktiv?");
                _currentActivityType = "team";
                MsgDialog.Commands.Add(new UICommand("Ja", ActivityClick));
                MsgDialog.Commands.Add(new UICommand("Nej"));
                MsgDialog.ShowAsync();
            }
        }
        public void SetStudentActivity(Student student)
        {
            _student = student;
            if (_student.IsActive)
            {
                MsgDialog = new MessageDialog(_student.Name + " er Aktiv. Vil du markere denne som Inaktiv?");
                _currentActivityType = "student";
                MsgDialog.Commands.Add(new UICommand("Ja", InactivityClick));
                MsgDialog.Commands.Add(new UICommand("Nej"));
                MsgDialog.ShowAsync();
            }
            else if (!_student.IsActive)
            {
                MsgDialog = new MessageDialog(_student.Name + " er Inaktiv. Vil du markere denne som Aktiv?");
                _currentActivityType = "student";
                MsgDialog.Commands.Add(new UICommand("Ja", ActivityClick));
                MsgDialog.Commands.Add(new UICommand("Nej"));
                MsgDialog.ShowAsync();
            }
        }
        private async void ActivityClick(IUICommand command)
        {
            if (_currentActivityType == "club")
            {
                _club.IsActive = true;
               await WsContext.UpdateClub(_club);
                WsContext.LoadClubs();
            }
            else if (_currentActivityType == "team")
            {
                _team.IsActive = true;
                await WsContext.UpdateTeam(_team);
                WsContext.LoadTeams();
            }
            else if (_currentActivityType == "student")
            {
                _student.IsActive = true;
                await WsContext.UpdateStudent(_student);
                WsContext.LoadStudents();
            }
        }
        private async void InactivityClick(IUICommand command)
        {
            if (_currentActivityType == "club")
            {
                _club.IsActive = false;
                await WsContext.UpdateClub(_club);
                WsContext.LoadClubs();
            }
            else if (_currentActivityType == "team")
            {
                _team.IsActive = false;
                await WsContext.UpdateTeam(_team);
                WsContext.LoadTeams();
            }
            else if (_currentActivityType == "student")
            {
                _student.IsActive = false;
                await WsContext.UpdateStudent(_student);
                WsContext.LoadStudents();
            }
        }
        public override void SetSelectedObject(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
