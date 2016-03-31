using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Diagnostics;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Shaolin_Check_In.Model;
using Shaolin_Check_In.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Shaolin_Check_In.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            this.InitializeComponent();
        }

        private void DatePicked(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            var rv = (RegistrationViewModel)DataContext;
            rv.Date = DateChooser.Date;
            rv.SearchForDate();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rv = (RegistrationViewModel)DataContext;
            rv.SearchTeam = (Team)teamDropDown.SelectedItem;
           rv.SearchForDate();
        }
    }
}
