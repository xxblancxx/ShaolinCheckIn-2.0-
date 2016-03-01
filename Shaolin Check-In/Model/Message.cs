using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Check_In.Model
{
    class Message
    {
       
        public Message( string content, bool frontpage)
        {
          Content = content;
          Frontpage = frontpage;
        
        }
        

        public int Id { get; set; }
        
        public string Content { get; set; }

        public bool Frontpage { get; set; }

      
        public override string ToString()
        {
            return Content;
        }
    }
}
