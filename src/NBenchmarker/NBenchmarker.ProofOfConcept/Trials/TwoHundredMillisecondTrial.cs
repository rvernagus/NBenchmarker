using System;
using System.Threading;

namespace NBenchmarker.ProofOfConcept.Trials
{
    public class TwoHundredMillisecondTrial : Trial
    {
        public TwoHundredMillisecondTrial()
            : base("200ms Trial")
        {
            this.SetUp = () =>
            {
                Console.WriteLine("200ms trial set up...");
                Thread.Sleep(500);
            };
            this.TimedIteration = () =>
            {
                Console.Write(".");
                Thread.Sleep(200);
            };
            this.TearDown = () =>
            {
                Console.WriteLine("\n200ms trial 1 tear down...");
                Thread.Sleep(500);
            };
        }
    }
}
