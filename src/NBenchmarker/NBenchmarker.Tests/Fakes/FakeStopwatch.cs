using System;

namespace NBenchmarker.Tests.Fakes
{
    public class FakeStopwatch : IStopwatch
    {
        private TimeSpan _timeSpan;

        public FakeStopwatch()
        {
            this.OrderOfCalls = "";
            _timeSpan = TimeSpan.Zero;
        }

        public void Start()
        {
            this.OrderOfCalls += "1";
        }

        public void Stop()
        {
            this.OrderOfCalls += "2";
        }

        public void SetElapsedTime(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
        }

        public TimeSpan GetElapsedTime()
        {
            this.OrderOfCalls += "3";
            return _timeSpan;
        }

        public string OrderOfCalls { get; private set; }
    }
}
