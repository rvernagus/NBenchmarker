using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NBenchmarker
{
    [ExcludeFromCodeCoverage]  // Just a facade for BCL Stopwatch
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

        public void Start()
        {
            _watch.Start();
        }

        public void Stop()
        {
            _watch.Stop();
        }
    }
}
