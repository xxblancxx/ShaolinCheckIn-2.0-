using Shaolin_Check_In.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Check_In.Model
{
    class Team
    {
        private string _name;
        private SingletonCommon _sCommon;
        private List<Student> _studentList;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;

            }
        }

        public SingletonCommon SCommon
        {
            get { return _sCommon; }
            set { _sCommon = value; }
        }


        public int Id { get; set; }
        public int Club { get; set; }
        public Team(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
