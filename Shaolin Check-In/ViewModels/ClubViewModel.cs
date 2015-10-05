using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Check_In.ViewModels
{
    class ClubViewModel : ViewModel
    {
        private RelayArgCommand<Team> _selectTeamCommand;
        public ObservableCollection<Team> TeamList { get; set; }
        public RelayArgCommand<Team> SelectTeamCommand
        {
            get
            {
                _selectTeamCommand = new RelayArgCommand<Team>(SetSelectedObject);
                return _selectTeamCommand;
            }
            private set { _selectTeamCommand = value; }

        }

        public ClubViewModel()
        {
            TeamList = new ObservableCollection<Team>();
            foreach (var t in SCommon.TeamList)
            {
                if (t.Club.Equals(SCommon.SelectedClub.Id))
                {
                    TeamList.Add(t);
                }
            }
        }
        public override void SetSelectedObject(object obj)
        {
            Team t = (Team)obj;
            SCommon.SelectedTeam = t;
        }
    }
}
