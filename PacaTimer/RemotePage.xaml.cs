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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PacaTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RemotePage : Page
    {
        private TimerPage _timer;

        public RemotePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null && e.Parameter is TimerPage timer)
            {
                _timer = timer;
            }

            base.OnNavigatedTo(e);
        }

        private void xPlay_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (xPlay.Symbol == Symbol.Pause)
            {
                _timer.Pause();
                xPlay.Symbol = Symbol.Play;
            }
            else
            {
                _timer.Play();
                xPlay.Symbol = Symbol.Pause;
            }
        }
    }
}
