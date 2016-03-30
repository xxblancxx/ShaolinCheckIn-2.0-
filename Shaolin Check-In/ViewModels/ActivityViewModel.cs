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
        private string _currentActivityGroup;
        public RelayArgCommand<Club> SetClubActivityCommand
        {
            get
            {
                _setClubActivityCommand = new RelayArgCommand<Club>(SetClubActivity);
                return _setClubActivityCommand;
            }
            set { _setClubActivityCommand = value; }
        }

        public void SetClubActivity(Club club)
        {
            _club = club;
            if (_club.IsActive)
            {
                MsgDialog = new MessageDialog(_club.Name + " er Aktiv. Vil du markere denne som Inaktiv?");
                _currentActivityGroup = "club";
                MsgDialog.Commands.Add(new UICommand("Ja", InactivityClick));
                MsgDialog.Commands.Add(new UICommand("Nej"));
                MsgDialog.ShowAsync();
            }
            else if (!_club.IsActive)
            {
                MsgDialog = new MessageDialog(_club.Name + " er Inaktiv. Vil du markere denne som Aktiv?");
                _currentActivityGroup = "club";
                MsgDialog.Commands.Add(new UICommand("Ja", ActivityClick));
                MsgDialog.Commands.Add(new UICommand("Nej"));
                MsgDialog.ShowAsync();
            }
        }

        private async void ActivityClick(IUICommand command)
        {
            if (_currentActivityGroup == "club")
            {
                _club.IsActive = true;
               await WsContext.UpdateClub(_club);
                WsContext.LoadClubs();
            }
        }
        private async void InactivityClick(IUICommand command)
        {
            if (_currentActivityGroup == "club")
            {
                _club.IsActive = false;
                await WsContext.UpdateClub(_club);
                WsContext.LoadClubs();
            }
        }
        public override void SetSelectedObject(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
