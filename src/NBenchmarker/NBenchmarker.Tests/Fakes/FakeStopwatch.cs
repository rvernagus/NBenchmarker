using System;
using System.Collections.Generic;
using System.Linq;

namespace NBenchmarker.Tests.Fakes
{
    public class FakeStopwatch : IStopwatch
    {
        private Queue<TimeSpan> _timeSpans;

        public FakeStopwatch()
        {
            _timeSpans = new Queue<TimeSpan>();
            this.CallOrder = "";
            SetElapsedTime(TimeSpan.Zero);
        }

        public void Start()
        {
            this.CallOrder += "1";
        }

        public void Stop()
        {
            this.CallOrder += "2";
        }

        public void SetElapsedTime(TimeSpan timeSpan)
        {
            SetElapsedTimes(timeSpan);
        }

        public TimeSpan GetElapsedTime()
        {
            this.CallOrder += "3";
            if (_timeSpans.Count == 1)
            {
                return _timeSpans.Peek();
            }
            else
            {
                return _timeSpans.Dequeue();
            }
        }

        public string CallOrder { get; private set; }

        public void SetElapsedTimes(params TimeSpan[] timeSpans)
        {
            _timeSpans = new Queue<TimeSpan>();
            foreach (var timeSpan in timeSpans)
            {
                _timeSpans.Enqueue(timeSpan);
            }
        }
    }
}
