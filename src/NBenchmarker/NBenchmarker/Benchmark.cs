
namespace NBenchmarker
{
    public static class Benchmark
    {
        public static void Run(Trial trial)
        {
            trial.TimedIteration();
        }
    }
}
