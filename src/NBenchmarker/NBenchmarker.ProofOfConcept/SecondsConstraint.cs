using System;

namespace NBenchmarker.ProofOfConcept
{
    public class SecondsConstraint : ITrialConstraint
    {
        private TimeSpan _seconds;

        public SecondsConstraint(int seconds)
        {
            _seconds = TimeSpan.FromSeconds(seconds);
        }

        public bool Applies(BenchmarkResult result)
        {
            return result.ElapsedTime >= _seconds;
        }
    }
}
