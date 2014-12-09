using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace NBenchmarker.ProofOfConcept
{
    public static class Benchmark
    {
        private static bool AnyConstraintApplies(Stopwatch watch, BenchmarkResult result, IList<ITrialConstraint> constraints)
        {
            watch.Stop();
            var anyApply = constraints.Any(c => c.Applies(result));
            watch.Start();
            return anyApply;
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
                var result = new BenchmarkResult(trial);

                var watch = new Stopwatch();
                watch.Start();
                while (!AnyConstraintApplies(watch, result, constraints))
                {
                    trial.TimedIteration();
                    result.ElapsedTime = watch.Elapsed;
                    result.NumberOfIterations += 1;
                    ExectuteNotTimedIteration(watch, trial);
                }
                watch.Stop();

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
