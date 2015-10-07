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
        private int tries;
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
            LoadClubs();
            //LoadTeams();
            //LoadStudents();
            //LoadRegistrations();
            //LoadStudentRegistrations();
        }

        public StartViewModel()
        {
            tries = new int();
            msgdialogShown = false;
            GetAllFromDatabase();
        }
        private async void LoadClubs()
        {
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
            catch (TaskCanceledException)
            {
                if (tries >= 2)
                {
                    tries = 0;
                    if (!msgdialogShown)
                    {
                        RetryConnectionDialog();
                    }
                }
                else
                {
                    tries++;
                    GetAllFromDatabase();
                }
            }

        }
        private async void LoadTeams()
        {
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
            catch (TaskCanceledException)
            {
                if (tries >= 2)
                {
                    tries = 0;
                    if (!msgdialogShown)
                    {
                        RetryConnectionDialog();
                    }
                }
                else
                {
                    tries++;
                    GetAllFromDatabase();
                }
            }

        }
        private async void LoadStudents()
        {
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
            catch (TaskCanceledException)
            {
                if (tries >= 2)
                {
                    tries = 0;
                    if (!msgdialogShown)
                    {
                        RetryConnectionDialog();
                    }
                }
                else
                {
                    tries++;
                    GetAllFromDatabase();
                }
            }

        }

        private async void LoadRegistrations()
        {
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
            catch (TaskCanceledException)
            {
                if (tries >= 2)
                {
                    tries = 0;
                    if (!msgdialogShown)
                    {
                        RetryConnectionDialog();
                    }
                }
                else
                {
                    tries++;
                    GetAllFromDatabase();
                }
            }
        }
        private async void LoadStudentRegistrations()
        {
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
            catch (TaskCanceledException)
            {
                if (tries >= 2)
                {
                    tries = 0;
                    if (!msgdialogShown)
                    {
                        RetryConnectionDialog();
                    }
                }
                else
                {
                    tries++;
                    GetAllFromDatabase();
                }
            }

        }

        public void RetryLoadCommand(IUICommand command)
        {
            msgdialogShown = false;
            GetAllFromDatabase();
        }

        public void CloseApplicationCommand(IUICommand command)
        {
            Application.Current.Exit();
        }

        public async void RetryConnectionDialog()
        {
            msgdialogShown = true;
            MessageDialog msgdialog = new MessageDialog("Kunne ikke forbinde til internettet, luk programmet, eller prøv igen.");
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
