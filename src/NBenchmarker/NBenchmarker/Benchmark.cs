
namespace NBenchmarker
{
    public class Benchmark
    {
        public BenchmarkResult Run(Trial trial)
        {
            var result = new BenchmarkResult(trial.Name);

            trial.SetUp();
            trial.Stopwatch.Start();

            while (result.NumberOfIterations < 1)
            {
                trial.BeforeEachIteration();
                trial.ForEachIteration();
                trial.AfterEachIteration();
                result.NumberOfIterations += 1;
            }

            trial.Stopwatch.Stop();
            trial.TearDown();

            result.ElapsedTime = trial.Stopwatch.GetElapsedTime();
            return result;
        }
    }
}
