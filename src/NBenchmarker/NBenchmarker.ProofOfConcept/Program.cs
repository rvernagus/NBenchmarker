using System;
using System.Linq;
using System.Threading;

namespace NBenchmarker.ProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            var trial1 = new Trial("Trial 1: 200ms Action")
            {
                SetUp = () =>
                {
                    Console.WriteLine("Trial 1 Setup...");
                    Thread.Sleep(500);
                },
                TimedIteration = () =>
                {
                    Console.Write(".");
                    Thread.Sleep(200);
                },
                TearDown = () =>
                {
                    Console.WriteLine("\nTrial 1 Tear down...");
                    Thread.Sleep(500);
                },
            };

            var trial2 = new Trial("Trial 2: 600ms Action")
            {
                SetUp = () =>
                {
                    Console.WriteLine("Trial 2 Setup...");
                    Thread.Sleep(100);
                },
                TimedIteration = () =>
                {
                    Console.Write(".");
                    Thread.Sleep(600);
                },
                TearDown = () =>
                {
                    Console.WriteLine("\nTrial 2 Teardown...");
                    Thread.Sleep(100);
                },
            };

            var trial3 = new Trial("Trial 3: 10ms Action")
            {
                SetUp = () =>
                {
                    Console.WriteLine("Trial 3 Setup...");
                    Thread.Sleep(100);
                },
                NotTimedIteration = () =>
                {
                    Console.Write("|");
                    Thread.Sleep(10);
                },
                TimedIteration = () =>
                {
                    Console.Write(".");
                    Thread.Sleep(10);
                },
                TearDown = () =>
                {
                    Console.WriteLine("\nTrial 3 Teardown...");
                    Thread.Sleep(100);
                },
            };

            Benchmark
                .RunAll(new[] { trial1, trial2, trial3 }, new SecondsConstraint(5))
                //.RunAll(new[] { trial1, trial2, trial3 }, new NumberOfIterationsConstraint(10))
                .ToList()
                .ForEach(result =>
                {
                    Console.WriteLine(result.TrialName);
                    Console.WriteLine("Elapsed time: " + result.ElapsedTime);
                    Console.WriteLine("# of iterations: " + result.NumberOfIterations);
                    Console.WriteLine();
                });



            Console.ReadLine();
        }
    }
}
