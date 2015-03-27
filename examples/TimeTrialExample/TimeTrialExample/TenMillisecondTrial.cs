using NBenchmarker;
using System;
using System.Threading;

namespace TimeTrialExample
{
    public class TenMillisecondTrial : Trial
    {
        public TenMillisecondTrial()
            : base("10ms Trial")
        {
            this.SetUp = _ =>
            {
                Console.WriteLine("10ms trial set up...");
                Thread.Sleep(100);
            };
            this.BeforeEachIteration = () =>
            {
                Console.Write("|");
                Thread.Sleep(10);
            };
            this.ForEachIteration = () =>
            {
                Console.Write(".");
                Thread.Sleep(10);
            };
            this.TearDown = () =>
            {
                Console.WriteLine("\n10ms trial tear down...");
                Thread.Sleep(100);
            };
        }
    }
}
