using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NBenchmarker.Tests
{
    [TestClass]
    public class BenchmarkTests
    {
        [TestMethod]
        public void RunBenchmarkExecutesIteration()
        {
            var wasCalled = false;
            var trial = new Trial("");
            trial.ForEachIteration = () => wasCalled = true;
            Benchmark.Run(trial);
            Assert.IsTrue(wasCalled, "Expected TimedIteration to be called");
        }

        [TestMethod]
        public void IterationIsTimed()
        {
            var trial = new Trial("");
            var stopWatch = new Fakes.FakeStopwatch();
            stopWatch.SetElapsedTime(TimeSpan.FromMilliseconds(100));

            var result = Benchmark.Run(trial, stopWatch);

            Assert.AreEqual(TimeSpan.FromMilliseconds(100), result.ElapsedTime);
        }

        [TestMethod]
        public void ExecutesStopwatchInSequence()
        {
            var trial = new Trial("");
            var stopWatch = new Fakes.FakeStopwatch();

            Benchmark.Run(trial, stopWatch);

            Assert.AreEqual("123", stopWatch.OrderOfCalls);
        }

        [TestMethod]
        public void ExecutesTrialActionsInSequence()
        {
            var trial = new Fakes.FakeTrial("");

            Benchmark.Run(trial);

            Assert.AreEqual("12345", trial.OrderOfCalls);
        }
    }
}
