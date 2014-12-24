using System.Collections.Generic;
using System.Linq;

namespace NBenchmarker
{
    public class Benchmark
    {
        private ICollection<IBenchmarkConstraint> _constraints;

        public Benchmark()
        {
            _constraints = new List<IBenchmarkConstraint>();
            var defaultConstraint = new NumberOfIterationsConstraint(1);
            _constraints.Add(defaultConstraint);
        }

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

        internal bool ShouldContinue(BenchmarkResult result)
        {
            return !_constraints.Any(constraint => constraint.Applies(result));
        }
    }
}
