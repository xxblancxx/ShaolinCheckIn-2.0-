using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;
using Shaolin_Check_In.View;

namespace Shaolin_Check_In.ViewModels
{
    class NewClubViewModel : ViewModel
    {
        private ICommand _createClubCommand;

        public ICommand CreateClubCommand
        {
            get
            {
                _createClubCommand = new RelayCommand(CreateClub);
                return _createClubCommand;
            }
            set { _createClubCommand = value; }
        }

        public string Name { get; set; }

        public async void CreateClub()
        {

            if (Name == null || Name.Equals(""))
            {
                MsgDialog = new MessageDialog("Indtast Klubnavn");
                MsgDialog.ShowAsync();
            }
            else if (Name != null || Name != "")
            {
                Club club = new Club(Name);
                await WsContext.CreateClub(club);
                frame.Navigate(typeof(CreateNewPage));
                WsContext.LoadClubs();
            }

        }


        public override void SetSelectedObject(object obj) {/*No Need*/}
    }
}
