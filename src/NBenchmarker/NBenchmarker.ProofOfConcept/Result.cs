using System;

namespace NBenchmarker.ProofOfConcept
{
    public class Result
    {
        public Result(TimeSpan elapsedTime)
        {
            this.ElapsedTime = elapsedTime;
        }

        public TimeSpan ElapsedTime { get; protected set; }
    }
}
