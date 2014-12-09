using System;

namespace NBenchmarker.ProofOfConcept
{
    public class BenchmarkStatus
    {
        public TimeSpan Elapsed { get; set; }

        public int NumberOfIterations { get; set; }
    }
}
