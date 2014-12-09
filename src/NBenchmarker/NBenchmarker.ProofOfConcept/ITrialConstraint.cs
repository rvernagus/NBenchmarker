
namespace NBenchmarker.ProofOfConcept
{
    public interface ITrialConstraint
    {
        bool Applies(BenchmarkStatus status);
    }
}
