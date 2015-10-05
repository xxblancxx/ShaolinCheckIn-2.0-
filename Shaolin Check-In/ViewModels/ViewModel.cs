using Shaolin_Check_In.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Shaolin_Check_In.ViewModels
{
    abstract class ViewModel
    {

        public MessageDialog MsgDialog { get; set; }
        private SingletonCommon _sCommon = SingletonCommon.Instance;
        public WSContext WsContext = new WSContext();

        public SingletonCommon SCommon
        {
            get { return SingletonCommon.Instance; }
            private set { }
        }

        public abstract void SetSelectedObject(Object obj);
    }
}

