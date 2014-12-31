using System;
using System.Threading;

namespace NBenchmarker.ProofOfConcept.Trials
{
    public class SixHundredMillisecondTrial : Trial
    {
        public SixHundredMillisecondTrial()
            : base("600ms Trial")
        {
            this.SetUp = _ =>
            {
                Console.WriteLine("600ms trial set up...");
                Thread.Sleep(100);
            };
            this.ForEachIteration = () =>
            {
                Console.Write(".");
                Thread.Sleep(600);
            };
            this.TearDown = () =>
            {
                Console.WriteLine("\n600ms trial tear down...");
                Thread.Sleep(100);
            };
        }
    }
}
