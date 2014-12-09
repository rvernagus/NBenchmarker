using System;

namespace NBenchmarker.ProofOfConcept
{
    public class Trial
    {
        public Action Setup { get; set; }

        public Action Timed { get; set; }

        public Action TearDown { get; set; }

        public int NumberOfIterations { get; set; }
    }
}
