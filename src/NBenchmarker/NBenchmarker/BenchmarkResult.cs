using System;

namespace NBenchmarker
{
    public class BenchmarkResult
    {
        public BenchmarkResult(Trial trial)
        {
            this.TrialName = trial.Name;
            this.ElapsedTime = TimeSpan.Zero;
            this.NumberOfIterations = 0;
        }

        public string TrialName { get; private set; }

        public TimeSpan ElapsedTime { get; set; }

        public int NumberOfIterations { get; set; }
    }
}
