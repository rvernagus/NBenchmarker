using System;

namespace NBenchmarker
{
    public static class Benchmark
    {
        public static BenchmarkResult Run(Trial trial, IStopwatch stopwatch)
        {
            var result = new BenchmarkResult(trial);

            stopwatch.Start();
            trial.TimedIteration();
            stopwatch.Stop();

            result.ElapsedTime = stopwatch.GetElapsedTime();
            return result;
        }

        public static BenchmarkResult Run(Trial trial)
        {
            return Run(trial, new DefaultStopwatch());
        }
    }
}
