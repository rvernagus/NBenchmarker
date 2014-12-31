using System;
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

            this.SetUp = result => result.Data["TotalMemory"] = 0L;

            this.ForEachIteration = () => list.Add(i);

            this.AfterEachIteration = result =>
            {
                var totalMemory = GC.GetTotalMemory(false);
                if (totalMemory > (Int64)result.Data["TotalMemory"])
                {
                    result.Data["TotalMemory"] = totalMemory;
                }
            };

            this.TearDown = () =>
            {
                list.Clear();
                GC.Collect();
            };
        }
    }
}
