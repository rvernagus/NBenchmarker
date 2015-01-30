using NBenchmarker;
using System;
using System.Linq;

namespace TimeTrialExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var trials = new Trial[]
            {
                new SixHundredMillisecondTrial(),
                new TwoHundredMillisecondTrial(),
                new TenMillisecondTrial()
            };
            var benchmarker = new Benchmarker();
            benchmarker.AddConstraint(new SecondsConstraint(5));
            benchmarker.Run(trials)
                .ToList()
                .ForEach(result =>
                {
                    Console.WriteLine(result.TrialName);
                    Console.WriteLine("Elapsed time: " + result.ElapsedTime);
                    Console.WriteLine("# of iterations: " + result.NumberOfIterations);
                    Console.WriteLine("Avg iteration duration: " + result.IterationAverageDuration);
                    Console.WriteLine();
                });

            Console.ReadLine();
        }
    }
}
