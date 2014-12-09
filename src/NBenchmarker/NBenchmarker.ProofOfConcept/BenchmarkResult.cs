using System;

namespace NBenchmarker.ProofOfConcept
{
    public class BenchmarkResult
    {
        public BenchmarkResult(BenchmarkStatus status)
        {
            this.TrialName = status.TrialName;
            this.ElapsedTime = status.Elapsed;
            this.NumberOfIterations = status.NumberOfIterations;
        }

        public string TrialName { get; private set; }

        public TimeSpan ElapsedTime { get; private set; }

        public int NumberOfIterations { get; private set; }
    }
}
