using System;

namespace NBenchmarker
{
    public static class Benchmark
    {
        public static BenchmarkResult Run(Trial trial, IStopwatch stopwatch)
        {
            var result = new BenchmarkResult(trial.Name);

            trial.SetUp();
            stopwatch.Start();

            while (result.NumberOfIterations < 1)
            {
                trial.BeforeEachIteration();
                trial.ForEachIteration();
                trial.AfterEachIteration();
                result.NumberOfIterations += 1;
            }

            stopwatch.Stop();
            trial.TearDown();

            result.ElapsedTime = stopwatch.GetElapsedTime();
            return result;
        }

        public static BenchmarkResult Run(Trial trial)
        {
            return Run(trial, new DefaultStopwatch());
        }
    }
}
