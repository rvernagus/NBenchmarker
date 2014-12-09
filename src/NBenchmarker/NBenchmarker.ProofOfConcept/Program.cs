using System;
using System.Threading;
using System.Linq;

namespace NBenchmarker.ProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            var trial1 = new Trial("Trial 1")
            {
                Setup = () =>
                {
                    Console.WriteLine("Trial 1 Setup...");
                    Thread.Sleep(500);
                },
                Timed = () =>
                {
                    Thread.Sleep(200);
                },
                TearDown = () =>
                {
                    Console.WriteLine("Trial 1 Tear down...");
                    Thread.Sleep(500);
                },
            };

            var trial2 = new Trial("Trial 2")
            {
                Timed = () =>
                {
                    Thread.Sleep(600);
                },
            };

            var trial3 = new Trial("Trial 3")
            {
                Timed = () =>
                {
                    Thread.Sleep(10);
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
                .RunAll(new[] { trial1, trial2, trial3 }, new SecondsConstraint(5))
                .ToList()
                .ForEach(result =>
                {
                    Console.WriteLine(result.TrialName);
                    Console.WriteLine("Elapsed time: " + result.ElapsedTime);
                    Console.WriteLine("# of iterations: " + result.NumberOfIterations);
                });



            Console.ReadLine();
        }
    }
}
