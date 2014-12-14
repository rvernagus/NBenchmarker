using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            trial.TimedIteration = () => wasCalled = true;
            Benchmark.Run(trial);
            Assert.IsTrue(wasCalled, "Expected TimedIteration to be called");
        }

        [TestMethod]
        public void RunBenchmarkTimesIteration()
        {
            var trial = new Trial("");
            var seq = new MockSequence();
            var mockWatch = new Mock<IStopwatch>(MockBehavior.Strict);
            mockWatch.InSequence(seq).Setup(w => w.Start());
            mockWatch.InSequence(seq).Setup(w => w.Stop());
            mockWatch.InSequence(seq).Setup(w => w.GetElapsedTime()).Returns(TimeSpan.FromMilliseconds(100));

            var result = Benchmark.Run(trial, mockWatch.Object);
            Assert.AreEqual(TimeSpan.FromMilliseconds(100), result.ElapsedTime);
            mockWatch.Verify();
        }
    }
}
