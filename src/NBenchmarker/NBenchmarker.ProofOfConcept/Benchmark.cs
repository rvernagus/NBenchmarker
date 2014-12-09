using System.Diagnostics;

namespace NBenchmarker.ProofOfConcept
{
    public static class Benchmark
    {
        public static Result Run(Trial trial)
        {
            trial.Setup();

            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < trial.NumberOfIterations; i++)
            {
                trial.Timed();
            }
            watch.Stop();
            var result = new Result(watch.Elapsed);

            trial.TearDown();

            return result;
        }
    }
}
