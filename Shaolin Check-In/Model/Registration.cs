using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Check_In.Model
{
    class Registration : INotifyPropertyChanged
    {

        private DateTimeOffset _timeStamp;
        public int Id { get; set; }

        public DateTimeOffset TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }

        // Needs implementation of getting the Name. to view list of registrations.

        public int Student { get; set; }


        public Registration(int student)
        {
            TimeStamp = DateTimeOffset.Now; // needs to change either here or api.
            Student = student;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        //public override string ToString()
        //{
        //    return string.Format("{0},     {1}", _studentObject.Name, _timeStamp);
        //}


    }
}
