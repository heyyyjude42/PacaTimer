using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PacaTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(200, 100));
            ApplicationView.PreferredLaunchViewSize = new Size(400, 500);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private async void MakeNewTimerWindow(TimerViewModel vm)
        {
            var newView = CoreApplication.CreateNewView();
            var newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(typeof(TimerPage), vm);
                Window.Current.Content = frame;
                Window.Current.Activate();
                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }

        private async void xWriting_Clicked(object sender, RoutedEventArgs routedEventArgs)
        {
            var prepSegment = new TimerSegment
            {
                Label = "Work together to plan your essays.",
                SecondaryLabels = new List<string>
                {
                    "You can use your books and devices.",
                    "Each of you must pick a different topic and argue for or against it.",
                    "Take notes on the provided sheet, but do not start writing your essays."
                },
                Duration = xOneDay.IsChecked == true ? new TimeSpan(0, 20, 0) : new TimeSpan(0, 25, 0)
            };

            var writeSegment = new TimerSegment
            {
                Label = "Write by yourself.",
                SecondaryLabels = new List<string>
                {
                    "Use pen or pencil.",
                    "There is no required format or word count.",
                    "Drawings of alpacas are optional but recommended."
                },
                Duration = xOneDay.IsChecked == true ? new TimeSpan(0, 40, 0) : new TimeSpan(0, 45, 0)
            };

            var reviewSegment = new TimerSegment
            {
                Label = "Review your essays as a team.",
                SecondaryLabels = new List<string>
                {
                    "Give each other ideas on how to improve them.",
                    "You may not use devices or outside resources during this time.",
                    "You may not finish someone else's essay for them."
                },
                Duration = xOneDay.IsChecked == true ? new TimeSpan(0, 12, 0) : new TimeSpan(0, 15, 0)
            };

            var timerViewModel = new TimerViewModel("Collaborative Writing",
                new List<TimerSegment> {prepSegment, writeSegment, reviewSegment});

            // now make a new window for the timer (so the kids don't see the controls)
            MakeNewTimerWindow(timerViewModel);
        }

        private void xChallenge_Clicked(object sender, RoutedEventArgs routedEventArgs)
        {
            var segment = new TimerSegment
            {
                Label = "Do not sit next to someone from your school!",
                SecondaryLabels = new List<string>
                {
                    "Make sure your ID is filled out correctly.",
                    "Completely fill in all the bubbles.",
                    "You may fill in up to FIVE answers per question."
                },
                Duration = xOneDay.IsChecked == true ? new TimeSpan(0, 12, 0) : new TimeSpan(0, 15, 0)
            };

            var timerViewModel = new TimerViewModel("Scholar's Challenge",
                new List<TimerSegment> { segment });
            MakeNewTimerWindow(timerViewModel);
        }

        private void xCustom_Clicked(object sender, RoutedEventArgs routedEventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
