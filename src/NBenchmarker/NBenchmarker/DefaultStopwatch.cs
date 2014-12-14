using System;
using System.Diagnostics;

namespace NBenchmarker
{
    public class DefaultStopwatch : IStopwatch
    {
        private Stopwatch _watch;

        public DefaultStopwatch()
        {
            _watch = new Stopwatch();
        }

        public TimeSpan GetElapsedTime()
        {
            return _watch.Elapsed;
        }
    }
}
