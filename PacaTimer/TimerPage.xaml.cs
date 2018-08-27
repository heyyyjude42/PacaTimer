using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PacaTimer
{
    /// <summary>
    /// The page that wraps around a timer object.
    /// </summary>
    public sealed partial class TimerPage : Page
    {
        public TimerViewModel ViewModel
        {
            get => DataContext as TimerViewModel;
            set => DataContext = value;
        }

        public TimerPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is TimerViewModel vm)
            {
                ViewModel = vm;
            }
            base.OnNavigatedTo(e);
        }
    }
}
