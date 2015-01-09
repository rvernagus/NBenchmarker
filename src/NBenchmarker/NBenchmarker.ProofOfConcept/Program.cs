using NBenchmarker.ProofOfConcept.Trials;
using System;
using System.Linq;

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
            //var trials = new Trial[] 
            //{
            //    new StringContainsTrial("abcdefghijklmnop", "jkl"),
            //    new StringIndexOfTrial("abcdefghijklmnop", "jkl"),
            //    new RegexMatchTrial("abcdefghijklmnop", "jkl"),
            //};
            var trials = new Trial[]
            {
                new BoxingTrial(),
                new NoBoxingTrial(),
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
                    Console.WriteLine("Largest Total Memory: " + result.Data["TotalMemory"]);
                    Console.WriteLine();
                });



            Console.ReadLine();
        }
    }
}
