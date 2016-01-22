﻿using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace Shaolin_Check_In.ViewModels
{
    class StudentViewModel : ViewModel
    {
        private RelayArgCommand<Student> _selectStudentCommand;
        private ObservableCollection<Student> _studentList;
        private IAsyncOperation<IUICommand> _asyncOp;
        private DispatcherTimer _timer;
        public Student SelectedStudent { get; set; }

        public ObservableCollection<Student> StudentList
        {
            get
            {
                //On Get; Return Collection in Alphabetical order
                _studentList = new ObservableCollection<Student>(_studentList.OrderBy(s => s.Name));
                return _studentList;
            }
            set
            {
                if (Equals(value, _studentList)) return;
                _studentList = value;
            }
        }


        public RelayArgCommand<Student> SelectStudentCommand
        {
            get
            {
                _selectStudentCommand = new RelayArgCommand<Student>(SetSelectedObject);
                return _selectStudentCommand;
            }
            private set { _selectStudentCommand = value; }

        }

        public StudentViewModel()
        {
            StudentList = new ObservableCollection<Student>();
            foreach (var s in SCommon.StudentList)
            {
                if (s.Team.Equals(SCommon.SelectedTeam.Id) && s.IsActive)
                {
                    StudentList.Add(s);
                }
            }
        }
        public async override void SetSelectedObject(object obj)
        {
            SelectedStudent = (Student)obj;
            //   SCommon.SelectedStudent = student;
            var alreadyRegisteredList = new List<Registration>();

            foreach (var reg in SCommon.RegistrationList)
            {
                if (reg.Student.Equals(SelectedStudent.Id) && reg.TimeStamp.Date.Equals(DateTime.Today))
                {
                    alreadyRegisteredList.Add(reg);
                }
            }
            if (alreadyRegisteredList.Count.Equals(0))
            {
                MsgDialog = new MessageDialog("Vælg handling nedenunder", "Hej " + SelectedStudent.Name);

                //Register button
                MsgDialog.Commands.Add(new UICommand("Mød Ind", ClickrgButton));

                if (SelectedStudent.Image == null)
                {
                    MsgDialog.Commands.Add(new UICommand("Tilføj Billede", ClickPictureButton));
                }

                //Cancel button
                MsgDialog.Commands.Add(new UICommand("Annuller", ClickcancelButton));
                await MsgDialog.ShowAsync();
            }
            else
            {
                MsgDialog = new MessageDialog("Du er allerede registreret, god træning!",
                    "Hej " + SelectedStudent.Name);
                await MsgDialog.ShowAsync();
            }


        }

        private void ClickPictureButton(IUICommand command)
        {
            // Needs implementation of Filepicker and picture.
        }
        private void ClickcancelButton(IUICommand command)
        {
            //cancel, nothing happens.
        }
        private async void ClickrgButton(IUICommand command)
        {
            // Register the student

            if (SelectedStudent != null)
            {
                var st = new Registration(SelectedStudent.Id);
                await WsContext.CreateRegistration(st);
                MsgDialog = new MessageDialog("Du er hermed registreret");
                WsContext.LoadStudentRegistrations();
                SCommon.RegistrationList.Add(st);

                try
                {
                    _timer = new DispatcherTimer();
                    _timer.Tick += StopAfterTime;
                    _timer.Interval = new TimeSpan(0, 0, 0, 1,500); 
                    _asyncOp = MsgDialog.ShowAsync();
                    _timer.Start();
                }
                catch (TaskCanceledException)
                {
                    //Caught
                }
            }
        }

        private void StopAfterTime(object sender, object e)
        {
            _asyncOp.Cancel();
            _timer.Start();
        }
    }
}
