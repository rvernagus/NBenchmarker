using System;

namespace NBenchmarker.Tests.Fakes
{
    public class FakeStopwatch : IStopwatch
    {
        private TimeSpan _timeSpan;

        public FakeStopwatch()
        {
            this.CallOrder = "";
            _timeSpan = TimeSpan.Zero;
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
            _timeSpan = timeSpan;
        }

        public TimeSpan GetElapsedTime()
        {
            this.CallOrder += "3";
            return _timeSpan;
        }

        public string CallOrder { get; private set; }
    }
}
