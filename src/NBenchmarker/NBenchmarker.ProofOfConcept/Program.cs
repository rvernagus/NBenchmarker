using System;
using System.Threading;

namespace NBenchmarker.ProofOfConcept
{
    class Program
    {
        static void Main(string[] args)
        {
            var trial = new Trial()
            {
                Setup = () =>
                {
                    Console.WriteLine("Setup...");
                    Thread.Sleep(500);
                },
                Timed = () =>
                {
                    Thread.Sleep(200);
                },
                TearDown = () =>
                {
                    Console.WriteLine("Tear down...");
                    Thread.Sleep(500);
                },
                NumberOfIterations = 10,
            };

            var result = Benchmark.Run(trial);
            Console.WriteLine(result.ElapsedTime);
            Console.ReadLine();
        }
    }
}
