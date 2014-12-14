using System;

namespace NBenchmarker
{
    public interface IStopwatch
    {
        void Start();

        void Stop();

        TimeSpan GetElapsedTime();
    }
}
