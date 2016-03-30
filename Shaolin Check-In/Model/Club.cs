using Shaolin_Check_In.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Check_In.Model
{
    class Club
    {

        private string _name;
        //  private SingletonCommon _sCommon;
        private List<Team> _teamList;

        public List<Team> TeamList
        {
            get { return _teamList; }
            set { _teamList = value; }
        }

        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;

            }
        }

        public Club(string name)
        {
            Name = name;
            TeamList = new List<Team>();

        }

        public override string ToString()
        {
            return Name;
        }
    }
}

