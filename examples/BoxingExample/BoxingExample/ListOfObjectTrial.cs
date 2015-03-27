using NBenchmarker;
using System;
using System.Collections.Generic;

namespace BoxingExample
{
    public class ListOfObjectTrial : Trial
    {
        public ListOfObjectTrial()
            : base("List<object> Trial")
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
                list.Capacity = 0;
                GC.Collect(2, GCCollectionMode.Forced, true);
            };
        }
    }
}
