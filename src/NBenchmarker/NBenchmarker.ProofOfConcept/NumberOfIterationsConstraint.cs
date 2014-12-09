
namespace NBenchmarker.ProofOfConcept
{
    public class NumberOfIterationsConstraint : ITrialConstraint
    {
        private int _numberOfIterations;

        public NumberOfIterationsConstraint(int numberOfIterations)
        {
            _numberOfIterations = numberOfIterations;
        }

        public bool Applies(BenchmarkStatus status)
        {
            return status.NumberOfIterations >= _numberOfIterations;
        }
    }
}
