using System;
using System.Threading;

namespace NBenchmarker.ProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            var trial1 = new Trial()
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

            var trial2 = new Trial()
            {
                Timed = () =>
                {
                    Thread.Sleep(600);
                },
            };

            Console.WriteLine("Trial 1");
            var result = Benchmark.Run(trial1, new SecondsConstraint(10));
            Console.WriteLine("Elapsed time: " + result.ElapsedTime);
            Console.WriteLine("# of iterations: " + result.NumberOfIterations);

            Console.WriteLine("Trial 2");
            result = Benchmark.Run(trial2, new SecondsConstraint(10));
            Console.WriteLine("Elapsed time: " + result.ElapsedTime);
            Console.WriteLine("# of iterations: " + result.NumberOfIterations);

            Console.ReadLine();
        }
    }
}
