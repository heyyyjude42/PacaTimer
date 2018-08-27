using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        public async void Play()
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => ViewModel.Play());
        }

        public async void Pause()
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => ViewModel.Pause());
        }

        public async void UpdateLabels(string primaryLabel, List<string> secondaryLabels)
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => ViewModel.UpdateLabels(primaryLabel, secondaryLabels));
        }

        /// <summary>
        /// Doing this will reset the timer to that segment!
        /// </summary>
        /// <param name="index"></param>
        public async void SetActiveSegment(int index)
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => ViewModel.SetActiveSegment(index));
        }
        
        public async void ChangeSegmentDuration(int index, TimeSpan time)
        {
            await this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => ViewModel.ChangeSegmentDuration(index, time));
        }
    }
}
