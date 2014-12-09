
namespace NBenchmarker
{
    public interface IBenchmarkConstraint
    {
        bool Applies(BenchmarkResult result);
    }
}
