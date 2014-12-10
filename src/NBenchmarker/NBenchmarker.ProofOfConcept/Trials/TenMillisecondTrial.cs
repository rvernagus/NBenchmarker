using System;
using System.Threading;

namespace NBenchmarker.ProofOfConcept.Trials
{
    public class TenMillisecondTrial : Trial
    {
        public TenMillisecondTrial()
            : base("10ms Trial")
        {
            this.SetUp = () =>
            {
                Console.WriteLine("Trial 3 Setup...");
                Thread.Sleep(100);
            };
            this.NotTimedIteration = () =>
            {
                Console.Write("|");
                Thread.Sleep(10);
            };
            this.TimedIteration = () =>
            {
                Console.Write(".");
                Thread.Sleep(10);
            };
            this.TearDown = () =>
            {
                Console.WriteLine("\nTrial 3 Teardown...");
                Thread.Sleep(100);
            };
        }
    }
}
