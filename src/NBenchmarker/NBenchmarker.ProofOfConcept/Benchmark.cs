using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace NBenchmarker.ProofOfConcept
{
    public static class Benchmark
    {
        public static BenchmarkResult Run(Trial trial, ITrialConstraint constraint)
        {
            Contract.Requires(trial.Setup != null);
            Contract.Requires(trial.TearDown != null);

            trial.Setup();
            var status = new BenchmarkStatus();

            var watch = new Stopwatch();
            watch.Start();
            while (!constraint.Applies(status))
            {
                trial.Timed();
                status.Elapsed = watch.Elapsed;
                status.NumberOfIterations += 1;
            }
            watch.Stop();
            var result = new BenchmarkResult(status);

            trial.TearDown();

            return result;
        }
    }
}
