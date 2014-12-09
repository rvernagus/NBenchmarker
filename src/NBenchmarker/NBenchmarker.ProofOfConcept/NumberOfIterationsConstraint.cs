
namespace NBenchmarker.ProofOfConcept
{
    public class NumberOfIterationsConstraint : ITrialConstraint
    {
        private int _numberOfIterations;

        public NumberOfIterationsConstraint(int numberOfIterations)
        {
            _numberOfIterations = numberOfIterations;
        }

        public bool Applies(BenchmarkResult result)
        {
            return result.NumberOfIterations >= _numberOfIterations;
        }
    }
}
