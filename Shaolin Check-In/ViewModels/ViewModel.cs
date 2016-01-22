using Shaolin_Check_In.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Shaolin_Check_In.ViewModels
{
    abstract class ViewModel
    {

        public MessageDialog MsgDialog { get; set; }
        public SingletonCommon _sCommon = SingletonCommon.Instance;
        public WSContext WsContext = new WSContext();
        public Frame frame = (Frame)Window.Current.Content;
        public SingletonCommon SCommon
        {
            get { return SingletonCommon.Instance; }
            private set { }
        }

        public abstract void SetSelectedObject(Object obj);
    }
}

