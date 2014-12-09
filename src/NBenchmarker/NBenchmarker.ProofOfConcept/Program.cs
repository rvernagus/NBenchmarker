using System;
using System.Threading;
using System.Linq;

namespace NBenchmarker.ProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            var trial1 = new Trial("200ms Action")
            {
                Setup = () =>
                {
                    Console.WriteLine("Trial 1 Setup...");
                    Thread.Sleep(500);
                },
                Timed = () =>
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

            var trial2 = new Trial("600ms Action")
            {
                Setup = () =>
                {
                    Console.WriteLine("Trial 2 Setup...");
                    Thread.Sleep(100);
                },
                Timed = () =>
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

            var trial3 = new Trial("10ms Action")
            {
                Setup = () =>
                {
                    Console.WriteLine("Trial 3 Setup...");
                    Thread.Sleep(100);
                },
                Timed = () =>
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

            //Console.WriteLine(trial1.Name);
            //var result = Benchmark.Run(trial1, new SecondsConstraint(5));
            //Console.WriteLine("Elapsed time: " + result.ElapsedTime);
            //Console.WriteLine("# of iterations: " + result.NumberOfIterations);

            //Console.WriteLine(trial2.Name);
            //result = Benchmark.Run(trial2, new SecondsConstraint(5));
            //Console.WriteLine("Elapsed time: " + result.ElapsedTime);
            //Console.WriteLine("# of iterations: " + result.NumberOfIterations);

            //Console.WriteLine(trial3.Name);
            //result = Benchmark.Run(trial3, new SecondsConstraint(5));
            //Console.WriteLine("Elapsed time: " + result.ElapsedTime);
            //Console.WriteLine("# of iterations: " + result.NumberOfIterations);

            Benchmark
                //.RunAll(new[] { trial1, trial2, trial3 }, new SecondsConstraint(5))
                .RunAll(new[] { trial1, trial2, trial3 }, new NumberOfIterationsConstraint(10))
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
