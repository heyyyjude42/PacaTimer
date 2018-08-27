using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using PacaTimer.Annotations;

namespace PacaTimer
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private List<TimerSegment> _segments;
        private TimerSegment _activeSegment;
        private string _name;
        private int _currentSegment = 0;
        private int _currentSecondaryLabelIndex = 0;
        private string _nextUpLabel;
        private string _activeSecondaryLabel;
        private DispatcherTimer _timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 1)};

        public TimerViewModel(string name, List<TimerSegment> segments)
        {
            Name = name;
            Segments = segments;
            SetActiveSegment(0);
            _timer.Tick += Timer_OnTick;
        }

        private void Timer_OnTick(object sender, object e)
        {
            ActiveSegment.Duration -= new TimeSpan(0, 0, 1);
        }

        public void SetActiveSegment(int index)
        {
            _currentSegment = index;
            ActiveSegment = _segments[_currentSegment];
            _currentSecondaryLabelIndex = 0;
            ActiveSecondaryLabel = _activeSegment.SecondaryLabels[_currentSecondaryLabelIndex];
            NextUpLabel = _segments.Count - index != 1 ? "Next up: " + _segments[_currentSegment + 1].Label : "";
        }

        public List<TimerSegment> Segments
        {
            get => _segments;
            set
            {
                _segments = value;
                OnPropertyChanged();
            }
        }

        public TimerSegment ActiveSegment
        {
            get => _activeSegment;
            set
            { 
                _activeSegment = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value.ToUpper();
                OnPropertyChanged();
            }
        }

        public string NextUpLabel
        {
            get => _nextUpLabel;
            set
            {
                _nextUpLabel = value.ToUpper();
                OnPropertyChanged();
            }
        }

        public string ActiveSecondaryLabel
        {
            get => _activeSecondaryLabel;
            set
            {
                _activeSecondaryLabel = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Play()
        {
            Debug.WriteLine("test");
            //_timer.Start();
        }

        public void Pause()
        {
            _timer.Stop();
        }

        public void UpdateLabels(string primaryLabel, List<string> secondaryLabels)
        {
            throw new NotImplementedException();
        }

        public void ChangeSegmentDuration(int index, TimeSpan time)
        {
            throw new NotImplementedException();
        }
    }
}
