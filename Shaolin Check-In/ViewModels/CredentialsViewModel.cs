using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Shaolin_Check_In.Annotations;
using Shaolin_Check_In.Common;

namespace Shaolin_Check_In.ViewModels
{
    class CredentialsViewModel : ViewModel, INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private RelayArgCommand<string> _logInCommand;

        public string Username
        {
            get { return _username; }
            set
            {
                if (value == _username) return;
                _username = value;
                OnPropertyChanged();
            }
        }

        public RelayArgCommand<string> LogInCommand
        {
            get
            {
                _logInCommand = new RelayArgCommand<string>(LogIn);
                return _logInCommand;
            }
            set { _logInCommand = value; }
        }


        public void LogIn(string password)
        {
            bool canNavigate = false;
            foreach (var userLogin in SCommon.UserLoginList)
            {
                if (userLogin.Password == password && userLogin.Username == Username)
                {
                    canNavigate = true;
                }
            }
            if (canNavigate)
            {
                frame.Navigate(SCommon.DesiredFrame);
            }
            else
            {
               MsgDialog = new MessageDialog("Forkert Brugernavn eller Adgangskode");
                MsgDialog.ShowAsync();
            }
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
