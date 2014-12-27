﻿using System.Collections.Generic;
using System.Linq;

namespace NBenchmarker
{
    public class Benchmarker
    {
        private ICollection<IBenchmarkConstraint> _constraints;
        private bool _useDefaultConstraint;

        public Benchmarker()
        {
            _useDefaultConstraint = true;
            _constraints = new List<IBenchmarkConstraint>();
            var defaultConstraint = new NumberOfIterationsConstraint(1);
            _constraints.Add(defaultConstraint);
        }

        public IList<BenchmarkResult> Run(IEnumerable<Trial> trials)
        {
            return Run(trials.ToArray());
        }

        public IList<BenchmarkResult> Run(params Trial[] trials)
        {
            return trials.Select(trial => Run(trial)).ToList();
        }

        public BenchmarkResult Run(Trial trial)
        {
            var result = new BenchmarkResult(trial.Name);

            trial.SetUp();
            trial.Stopwatch.Start();

            while (ShouldContinue(result))
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

        public void AddConstraint(IBenchmarkConstraint constraint)
        {
            RemoveDefaultConstraintFirstTime();

            _constraints.Add(constraint);
        }

        private void RemoveDefaultConstraintFirstTime()
        {
            if (_useDefaultConstraint)
            {
                _constraints.Clear();
                _useDefaultConstraint = false;
            }
        }
    }
}
