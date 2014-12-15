using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NBenchmarker.Tests
{
    [TestClass]
    public class BenchmarkResultTests
    {
        Trial trial;
        BenchmarkResult result;

        [TestInitialize]
        public void TestInitialize()
        {
            trial = new Trial("trial1");
            result = new BenchmarkResult(trial.Name);
        }

        [TestMethod]
        public void InitialStateStoresTrialName()
        {
            Assert.AreEqual("trial1", result.TrialName);
            Assert.AreEqual(TimeSpan.Zero, result.ElapsedTime);
            Assert.AreEqual(0, result.NumberOfIterations);
        }

        [TestMethod]
        public void CalculatesIterationAverageDuration()
        {
            // 1 / 1
            result.ElapsedTime = TimeSpan.FromTicks(1);
            result.NumberOfIterations = 1;
            Assert.AreEqual(TimeSpan.FromTicks(1), result.IterationAverageDuration);

            // 2 / 2
            result.ElapsedTime = TimeSpan.FromTicks(2);
            result.NumberOfIterations = 2;
            Assert.AreEqual(TimeSpan.FromTicks(1), result.IterationAverageDuration);

            // 10000 / 50
            result.ElapsedTime = TimeSpan.FromTicks(10000);
            result.NumberOfIterations = 50;
            Assert.AreEqual(TimeSpan.FromTicks(200), result.IterationAverageDuration);
        }
    }
}
