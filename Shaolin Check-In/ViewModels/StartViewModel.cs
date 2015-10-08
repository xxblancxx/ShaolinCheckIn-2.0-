using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace Shaolin_Check_In.ViewModels
{
    class StartViewModel : ViewModel
    {
        private RelayArgCommand<Club> _selectClubCommand;

        private bool msgdialogShown;
        public RelayArgCommand<Club> SelectClubCommand
        {
            get
            {
                _selectClubCommand = new RelayArgCommand<Club>(SetSelectedObject);
                return _selectClubCommand;
            }
            set { _selectClubCommand = value; }
        }
        public override void SetSelectedObject(Object club)
        {
            Club c = (Club)club;
            SCommon.SelectedClub = c;
        }

        public void GetAllFromDatabase()
        {
            if (!SCommon.AlreadyLoaded)
            {
                LoadClubs();
                LoadTeams();
                LoadStudents();
                LoadRegistrations();
                LoadStudentRegistrations();
                SCommon.AlreadyLoaded = true;
            }

        }

        public StartViewModel()
        {
            msgdialogShown = false;
            GetAllFromDatabase();
        }
        private async void LoadClubs()
        { // Load clubs from DB into Singleton
            try
            {
                SCommon.ClubList = await WsContext.GetAllClubs();
            }
            catch (HttpRequestException)
            {
                if (!msgdialogShown)
                {
                    RetryConnectionDialog();
                }

            }
            catch (OperationCanceledException) { }

        }
        private async void LoadTeams()
        { // Load teams from DB into Singleton
            try
            {
                SCommon.TeamList = await WsContext.GetAllTeams();
            }
            catch (HttpRequestException)
            {
                if (!msgdialogShown)
                {
                    RetryConnectionDialog();
                }
            }
            catch (OperationCanceledException) { }


        }
        private async void LoadStudents()
        { // Load students from DB into Singleton
            try
            {
                SCommon.StudentList = await WsContext.GetAllStudents();
            }
            catch (HttpRequestException)
            {
                if (!msgdialogShown)
                {
                    RetryConnectionDialog();
                }
            }
            catch (OperationCanceledException) { }

        }

        private async void LoadRegistrations()
        { // Load all Registrations from DB into Singleton
            try
            {
                SCommon.RegistrationList = await WsContext.GetAllRegistrations();
            }
            catch (HttpRequestException)
            {
                if (!msgdialogShown)
                {
                    RetryConnectionDialog();
                }
            }
            catch (OperationCanceledException) { }
        }
        private async void LoadStudentRegistrations()
        { // Load User registrations from View, into singleton.
            try
            {
                SCommon.StudentRegistrationList = await WsContext.GetAllStudentRegistrations();
            }
            catch (HttpRequestException)
            {
                if (!msgdialogShown)
                {
                    RetryConnectionDialog();
                }
            }
            catch (OperationCanceledException) { }

        }

        public void RetryLoadCommand(IUICommand command)
        {
            msgdialogShown = false;
            WsContext.CancelToken.Cancel();
            GetAllFromDatabase();
        }

        public void CloseApplicationCommand(IUICommand command)
        {
            Application.Current.Exit();
        }

        public async void RetryConnectionDialog()
        {
            msgdialogShown = true;
            MessageDialog msgdialog = new MessageDialog("Der opstod en fejl med forbindelsen");
            UICommand retryButton = new UICommand("Prøv Igen");
            retryButton.Invoked = RetryLoadCommand;
            msgdialog.Commands.Add(retryButton);
            UICommand closeButton = new UICommand("Luk App");
            closeButton.Invoked = CloseApplicationCommand;
            msgdialog.Commands.Add(closeButton);
            await msgdialog.ShowAsync();
        }

    }
}
