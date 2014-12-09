
namespace NBenchmarker
{
    public interface ITrialConstraint
    {
        bool Applies(BenchmarkResult result);
    }
}
