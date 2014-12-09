using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

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

        private static void ExectuteNotTimedIteration(Stopwatch watch, Trial trial)
        {
            watch.Stop();
            trial.NotTimedIteration();
            watch.Start();
        }

        public static BenchmarkResult Run(Trial trial, params ITrialConstraint[] constraints)
        {
            Contract.Requires(trial.SetUp != null);
            Contract.Requires(trial.TearDown != null);

            var taskResult = Task.Run(() =>
            {
                trial.SetUp();
                var status = new BenchmarkStatus();
                status.TrialName = trial.Name;

                var watch = new Stopwatch();
                watch.Start();
                while (!AnyConstraintApplies(watch, status, constraints))
                {
                    trial.TimedIteration();
                    status.Elapsed = watch.Elapsed;
                    status.NumberOfIterations += 1;
                    ExectuteNotTimedIteration(watch, trial);
                }
                watch.Stop();
                var result = new BenchmarkResult(status);

                trial.TearDown();

                return result;
            });

            taskResult.Wait();
            return taskResult.Result;
        }

        public static IList<BenchmarkResult> RunAll(IList<Trial> trials, params ITrialConstraint[] constraints)
        {
            return trials.Select(trial => Benchmark.Run(trial, constraints)).ToList();
        }
    }
}
