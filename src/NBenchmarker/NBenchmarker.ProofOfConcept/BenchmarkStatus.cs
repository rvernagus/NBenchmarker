using System;

namespace NBenchmarker.ProofOfConcept
{
    public class BenchmarkStatus
    {
        public string TrialName { get; set; }

        public TimeSpan Elapsed { get; set; }

        public int NumberOfIterations { get; set; }
    }
}
