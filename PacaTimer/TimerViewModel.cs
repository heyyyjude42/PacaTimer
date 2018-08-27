﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        public TimerViewModel(string name, List<TimerSegment> segments)
        {
            _name = name;
            _segments = segments;
            SetActiveSegment(0);
        }

        public void SetActiveSegment(int index)
        {
            _currentSegment = index;
            _activeSegment = _segments[_currentSegment];
            _currentSecondaryLabelIndex = 0;
            _activeSecondaryLabel = _activeSegment.SecondaryLabels[_currentSecondaryLabelIndex];
            _nextUpLabel = _segments.Count - index != 1 ? "Next up: " + _segments[_currentSegment + 1].Label : "";
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
                _name = value;
                OnPropertyChanged();
            }
        }

        public string NextUpLabel
        {
            get => _nextUpLabel;
            set
            {
                _nextUpLabel = value;
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
    }
}