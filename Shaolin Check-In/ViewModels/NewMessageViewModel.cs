using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Shaolin_Check_In.Annotations;
using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;

namespace Shaolin_Check_In.ViewModels
{
    class NewMessageViewModel : ViewModel, INotifyPropertyChanged
    {
        private string _message;
        private bool _frontPage;
        private ObservableCollection<Team> _teamList;
        private RelayArgCommand<Club> _pickClubCommand;
        private RelayArgCommand<Team> _createMessageCommand;

        public RelayArgCommand<Team> CreateMessageCommand
        {
            get
            {
                _createMessageCommand = new RelayArgCommand<Team>(CreateNewMessage);
                return _createMessageCommand;
            }
            set { _createMessageCommand = value; }
        }

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
        public string Message
        {
            get { return _message; }
            set
            {
                if (value == _message) return;
                _message = value;
                OnPropertyChanged();
            }
        }

       
        public bool FrontPage
        {
            get { return _frontPage; }
            set
            {
                if (value == _frontPage) return;
                _frontPage = value;
                OnPropertyChanged();
            }
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

        public async void CreateNewMessage(Team team)
        {
            var newMsg = new Message(Message,FrontPage,team.Id);
            var dbcontext = new WSContext();
            await dbcontext.CreateMessage(newMsg);
            dbcontext.LoadMessages();
        }
        public override void SetSelectedObject(object obj)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
