using System;
using System.Threading;

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

            Console.WriteLine(trial1.Name);
            var result = Benchmark.Run(trial1, new SecondsConstraint(10));
            Console.WriteLine("Elapsed time: " + result.ElapsedTime);
            Console.WriteLine("# of iterations: " + result.NumberOfIterations);

            Console.WriteLine(trial2.Name);
            result = Benchmark.Run(trial2, new SecondsConstraint(10));
            Console.WriteLine("Elapsed time: " + result.ElapsedTime);
            Console.WriteLine("# of iterations: " + result.NumberOfIterations);

            Console.ReadLine();
        }
    }
}
