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
            do
            {
                trial.Timed();
                status.NumberOfIterations += 1;
                status.Elapsed = watch.Elapsed;
            } while (!constraint.Applies(status));
            watch.Stop();
            var result = new BenchmarkResult(status);

            trial.TearDown();

            return result;
        }
    }
}
