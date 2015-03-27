using NBenchmarker;
using System;
using System.Linq;

namespace BoxingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var trials = new Trial[]
            {
                new ArrayListTrial(),
                new ListOfObjectTrial(),
                new ListOfIntTrial(),
            };

            var benchmarker = new Benchmarker();
            benchmarker.AddConstraint(new SecondsConstraint(10));
            Console.WriteLine("Running trials...");
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
