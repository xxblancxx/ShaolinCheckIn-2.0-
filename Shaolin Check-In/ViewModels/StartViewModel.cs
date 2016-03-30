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
using Windows.UI.Xaml.Controls;
using Shaolin_Check_In.View;

namespace Shaolin_Check_In.ViewModels
{
    class StartViewModel : ViewModel
    {
        private RelayArgCommand<Club> _selectClubCommand;

        private bool msgdialogShown;
        private RelayCommand _navigateCommand;
        private RelayCommand _navigateToCreateCommand;
        private RelayCommand _navigateToActivity;

        public RelayCommand NavigateToActivityCommand
        {
            get
            {
                _navigateCommand = new RelayCommand(ChangeViewToActivity);
                return _navigateToActivity;
            }
            set { _navigateToActivity = value; }
        }

        public RelayCommand NavigateToMessagesCommand
        {
            get
            {
                _navigateCommand = new RelayCommand(ChangeViewToMessages);
                return _navigateCommand;
            }
            set { _navigateCommand = value; }
        }

        public RelayCommand NavigateToCreateCommand
        {
            get
            {
                _navigateToCreateCommand = new RelayCommand(ChangeViewToCreate);
                return _navigateToCreateCommand;
            }
            set { _navigateToCreateCommand = value; }
        }

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
            { // Loads Objects from DB on startup. Sets AlreadyLoaded to true if no exceptions happen, so it only happens once automatically.
                try
                {
                    //WsContext.LoadClubs();
                    //WsContext.LoadTeams();
                    //WsContext.LoadStudents();
                    WsContext.LoadRegistrations();
                    WsContext.LoadStudentRegistrations();
                    WsContext.LoadMessages();
                    WsContext.LoadUserLogins();
                    SCommon.AlreadyLoaded = true;
                }
                catch (HttpRequestException)
                { // If no internetconnection, HTTPRequests returns exception
                    if (!msgdialogShown)
                    {
                        RetryConnectionDialog();
                    }

                } // Upon cancellationToken.Cancel - Should not crash. Do nothing though.
                catch (OperationCanceledException) { }
            }

        }

        public void ChangeViewToActivity()
        {
            SCommon.DesiredFrame = typeof(ActivityPage);
            frame.Navigate(typeof(CredentialsPage));
        }
        public void ChangeViewToMessages()
        {
            SCommon.DesiredFrame = typeof(MessagePage);
            frame.Navigate(typeof(CredentialsPage));
        }
        public void ChangeViewToCreate()
        {
            SCommon.DesiredFrame = typeof(CreateNewPage);
            frame.Navigate(typeof(CredentialsPage));
        }
        public StartViewModel()
        {
            msgdialogShown = false;
            GetAllFromDatabase();
        }

        #region MsgDialog
        // If no internetconnection, this dialog gives option of trying again (if slow) or closing application
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
        #endregion

        #region Commands in MsgDialog
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
        #endregion



    }
}
