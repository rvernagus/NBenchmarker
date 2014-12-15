using System;

namespace NBenchmarker
{
    public class BenchmarkResult
    {
        public BenchmarkResult(string trialName)
        {
            this.TrialName = trialName;
            this.ElapsedTime = TimeSpan.Zero;
            this.NumberOfIterations = 0;
        }

        public string TrialName { get; private set; }

        public TimeSpan ElapsedTime { get; set; }

        public int NumberOfIterations { get; set; }

        public TimeSpan IterationAverageDuration
        {
            get
            {
                var avgTicks = this.ElapsedTime.Ticks / this.NumberOfIterations;
                return TimeSpan.FromTicks(avgTicks);
            }
        }
    }
}
