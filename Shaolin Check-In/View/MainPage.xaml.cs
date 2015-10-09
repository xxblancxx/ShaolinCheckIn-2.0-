using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Shaolin_Check_In
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }



        // Show commandbar
        //or close, depending on current state
        private void CommandBarClick(object sender, RoutedEventArgs e)
        {
            var rt = new RotateTransform();

            if (commandBar.Visibility == Visibility.Collapsed)
            {
                commandBar.Visibility = Visibility.Visible;
                rt.Angle = -90;
                commandBarActivationButton.RenderTransform = rt;
            }
            else if(commandBar.Visibility == Visibility.Visible)
            {
                commandBar.Visibility = Visibility.Collapsed;
                rt.Angle = 90;
                commandBarActivationButton.RenderTransform = rt;
            }
        }
    }
}
