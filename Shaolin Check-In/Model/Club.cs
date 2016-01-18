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
        private SingletonCommon _sCommon;
        private List<Team> _teamList;

        public List<Team> TeamList
        {
            get { return _teamList; }
            set { _teamList = value; }
        }

        public int Id { get; set; }
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

        //public string Address { get; set; }

        public Club(string name, int id /*string address*/)
        {
            Name = name;
            Id = id;
            _sCommon = SingletonCommon.Instance;
            TeamList = new List<Team>();

        }

        public override string ToString()
        {
            return Name;
        }
    }
}

