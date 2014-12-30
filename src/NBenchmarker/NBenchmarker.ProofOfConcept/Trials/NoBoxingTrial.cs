using System.Collections.Generic;

namespace NBenchmarker.ProofOfConcept.Trials
{
    public class NoBoxingTrial : Trial
    {
        public NoBoxingTrial()
            : base("No Boxing an int")
        {
            var list = new List<int>();
            var i = 0;

            this.ForEachIteration = () =>
            {
                list.Add(i);
            };
        }
    }
}
