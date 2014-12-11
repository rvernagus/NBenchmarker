using NBenchmarker.ProofOfConcept.Trials;
using System;
using System.Linq;
using System.Threading;

namespace NBenchmarker.ProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            //var trials = new Trial[]
            //{
            //    new SixHundredMillisecondTrial(),
            //    new TwoHundredMillisecondTrial(),
            //    new TenMillisecondTrial()
            //};
            var trials = new Trial[] 
            {
                new StringContainsTrial("abcdefghijklmnop", "jkl"),
                new StringIndexOfTrial("abcdefghijklmnop", "jkl"),
                new RegexMatchTrial("abcdefghijklmnop", "jkl"),
            };
            Benchmark
                .RunAll(trials, new SecondsConstraint(5))
                //.RunAll(trials, new NumberOfIterationsConstraint(10))
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
