using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;

namespace NBenchmarker.ProofOfConcept
{
    public static class Benchmark
    {
        private static bool AnyConstraintApplies(Stopwatch watch, BenchmarkStatus status, IList<ITrialConstraint> constraints)
        {
            watch.Stop();
            var result = constraints.Any(c => c.Applies(status));
            watch.Start();
            return result;
        }

        public static BenchmarkResult Run(Trial trial, params ITrialConstraint[] constraints)
        {
            Contract.Requires(trial.Setup != null);
            Contract.Requires(trial.TearDown != null);

            trial.Setup();
            var status = new BenchmarkStatus();
            status.TrialName = trial.Name;

            var watch = new Stopwatch();
            watch.Start();
            while (!AnyConstraintApplies(watch, status, constraints))
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

        public static IList<BenchmarkResult> RunAll(IList<Trial> trials, params ITrialConstraint[] constraints)
        {
            return trials.Select(trial => Benchmark.Run(trial, constraints)).ToList();
        }
    }
}
