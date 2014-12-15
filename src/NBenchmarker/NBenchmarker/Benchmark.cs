
namespace NBenchmarker
{
    public static class Benchmark
    {
        public static BenchmarkResult Run(Trial trial, IStopwatch stopwatch)
        {
            var result = new BenchmarkResult(trial.Name);

            trial.SetUp();
            stopwatch.Start();

            trial.BeforeEachIteration();
            trial.ForEachIteration();
            trial.AfterEachIteration();

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
