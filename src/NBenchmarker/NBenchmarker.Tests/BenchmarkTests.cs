using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;

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
            trial.TimedIteration = () => wasCalled = true;
            Benchmark.Run(trial);
            Assert.IsTrue(wasCalled, "Expected TimedIteration to be called");
        }

        [TestMethod]
        public void RunBenchmarkTimesIteration()
        {
            var mockWatch = new Mock<IStopwatch>();
            mockWatch.Setup(w => w.GetElapsedTime()).Returns(TimeSpan.FromMilliseconds(100));

            var trial = new Trial("");
            trial.TimedIteration = () => Thread.Sleep(100);

            var result = Benchmark.Run(trial, mockWatch.Object);
            Assert.AreEqual(TimeSpan.FromMilliseconds(100), result.ElapsedTime);
        }
    }
}
