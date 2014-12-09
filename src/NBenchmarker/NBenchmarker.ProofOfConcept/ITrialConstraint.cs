
namespace NBenchmarker.ProofOfConcept
{
    public interface ITrialConstraint
    {
        bool Applies(BenchmarkResult result);
    }
}
