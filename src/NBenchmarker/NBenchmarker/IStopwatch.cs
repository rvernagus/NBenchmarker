using System;

namespace NBenchmarker
{
    public interface IStopwatch
    {
        TimeSpan GetElapsedTime();
    }
}
