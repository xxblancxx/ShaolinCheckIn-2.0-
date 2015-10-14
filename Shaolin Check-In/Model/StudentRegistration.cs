using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Check_In.Model
{
    class StudentRegistration
    {
        public int Id { get; set; }

        public int Team { get; set; }

        public string Name { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public string Date
        {
            get
            {
                string returnString = TimeStamp.Date.ToString(("dd-MM-yy"));
             //   return TimeStamp.Date.ToString("dd-MM-yy");
                return returnString;
            }
            private set { }
        }

    }
}
