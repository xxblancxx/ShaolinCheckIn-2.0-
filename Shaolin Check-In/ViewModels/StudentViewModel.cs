using Shaolin_Check_In.Common;
using Shaolin_Check_In.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace Shaolin_Check_In.ViewModels
{
    class StudentViewModel : ViewModel
    {
        private RelayArgCommand<Student> _selectStudentCommand;
        public Student SelectedStudent { get; set; }

        public ObservableCollection<Student> StudentList { get; set; }


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
                if (s.Team.Equals(SCommon.SelectedTeam.Id))
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
                UICommand rgButton = new UICommand("Mød Ind");
                rgButton.Invoked = ClickrgButton;
                MsgDialog.Commands.Add(rgButton);

                if (SelectedStudent.Image == null)
                {
                    UICommand pictureButton = new UICommand("Tilføj Billede");
                    pictureButton.Invoked = ClickcancelButton; //ClickPictureButton;
                    MsgDialog.Commands.Add(pictureButton);
                }

                //Cancel button
                UICommand cancelButton = new UICommand("Annuller");
                cancelButton.Invoked = ClickcancelButton;
                MsgDialog.Commands.Add(cancelButton);



                await MsgDialog.ShowAsync();
            }
            else
            {
                MsgDialog = new MessageDialog("Du er allerede registreret, god træning!",
                    "Hej " + SelectedStudent.Name);
                await MsgDialog.ShowAsync();
            }


        }
        private void ClickcancelButton(IUICommand command)
        {
            //cancel, nothing happens.
        }
        private void ClickrgButton(IUICommand command)
        {
            // Register the student

            if (SelectedStudent != null)
            {
                var st = new Registration(SelectedStudent.Id);
                WsContext.CreateRegistration(st);
                SCommon.RegistrationList.Add(st);
            }
        }
    }
}
