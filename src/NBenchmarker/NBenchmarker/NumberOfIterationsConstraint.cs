
namespace NBenchmarker
{
    public class NumberOfIterationsConstraint : IBenchmarkConstraint
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
