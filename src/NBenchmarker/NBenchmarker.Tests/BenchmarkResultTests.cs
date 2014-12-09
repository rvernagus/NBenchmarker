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
            result = new BenchmarkResult(trial);
        }

        [TestMethod]
        public void InitialStateStoresTrialName()
        {
            Assert.AreEqual("trial1", result.TrialName);
            Assert.AreEqual(TimeSpan.Zero, result.ElapsedTime);
            Assert.AreEqual(0, result.NumberOfIterations);
        }
    }
}
