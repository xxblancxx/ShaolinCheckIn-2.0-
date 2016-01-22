using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;
using Shaolin_Check_In.View;

namespace Shaolin_Check_In.ViewModels
{
    class NewTeamViewModel : ViewModel
    {
        private RelayArgCommand<Club> _createTeamCommand;
        public string Name { get; set; }

        public RelayArgCommand<Club> CreateTeamCommand
        {
            get
            {
                _createTeamCommand = new RelayArgCommand<Club>(CreateTeam);
                return _createTeamCommand;
            }
            set { _createTeamCommand = value; }
        }

        public void CreateTeam(Club club)
        {
            if (Name == null || Name == "")
            {
                MsgDialog = new MessageDialog("Indtast holdnavn.");
                MsgDialog.ShowAsync();
            }
            else if (!club.Equals(null))
            {
                Team team = new Team(Name, club.Id);
                WsContext.CreateTeam(team);
                frame.Navigate(typeof(CreateNewPage));
            }

        }
        public override void SetSelectedObject(object obj) {/*Not Needed for this VM*/}
    }
}
