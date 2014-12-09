using System;

namespace NBenchmarker.ProofOfConcept
{
    public class BenchmarkResult
    {
        public BenchmarkResult(BenchmarkStatus status)
        {
            this.ElapsedTime = status.Elapsed;
            this.NumberOfIterations = status.NumberOfIterations;
        }

        public TimeSpan ElapsedTime { get; private set; }

        public int NumberOfIterations { get; private set; }
    }
}
