using System;

namespace NBenchmarker.Tests.Helpers
{
    public static class StopWatchHelper
    {
        //public static Fakes.FakeStopwatch GetFiveSecondStopwatch()
        //{
        //    var stopwatch = new Fakes.FakeStopwatch();
        //    stopwatch.SetElapsedTimes(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3), TimeSpan.FromSeconds(4), TimeSpan.FromSeconds(5));
        //    return stopwatch;
        //}

        //public static Fakes.FakeStopwatch GetFiveSecondStopwatchWithTwoTicks()
        //{
        //    var stopwatch = new Fakes.FakeStopwatch();
        //    stopwatch.SetElapsedTimes(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(5));
        //    return stopwatch;
        //}

        public static Fakes.FakeStopwatch GetStopwatchWithTicks(params TimeSpan[] timeSpans)
        {
            var stopwatch = new Fakes.FakeStopwatch();
            stopwatch.SetElapsedTimes(timeSpans);
            return stopwatch;
        }
    }
}
