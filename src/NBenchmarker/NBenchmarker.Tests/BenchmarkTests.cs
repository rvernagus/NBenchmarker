using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NBenchmarker.Tests
{
    [TestClass]
    public class BenchmarkTests
    {
        [TestMethod]
        public void BenchmarkExecutesTrialActionsInSequence()
        {
            var trial = new Fakes.FakeTrial("");

            Benchmark.Run(trial);

            Assert.AreEqual("12345", trial.CallOrder);
        }

        [TestMethod]
        public void ResultRecordsStopwatchElapsedTime()
        {
            var trial = new Fakes.FakeTrial("");
            trial.SetElapsedTime(TimeSpan.FromSeconds(1));

            var result = Benchmark.Run(trial);

            Assert.AreEqual(TimeSpan.FromSeconds(1), result.ElapsedTime);
        }

        [TestMethod]
        public void ExecutesStopwatchInSequence()
        {
            var trial = new Fakes.FakeTrial("");

            Benchmark.Run(trial);

            var stopwatch = (Fakes.FakeStopwatch)trial.Stopwatch;
            Assert.AreEqual("123", stopwatch.CallOrder);
        }

        [TestMethod]
        public void DefaultIteratesOneTime()
        {
            var trial = new Fakes.FakeTrial("");

            var result = Benchmark.Run(trial);

            Assert.AreEqual(1, result.NumberOfIterations);
        }
    }
}
