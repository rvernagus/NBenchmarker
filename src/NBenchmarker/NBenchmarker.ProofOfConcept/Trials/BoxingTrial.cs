using System.Collections.Generic;

namespace NBenchmarker.ProofOfConcept.Trials
{
    public class BoxingTrial : Trial
    {
        public BoxingTrial()
            : base("Boxing an int")
        {
            var list = new List<object>();
            var i = 0;

            this.ForEachIteration = () =>
            {
                list.Add(i);
            };
        }
    }
}
