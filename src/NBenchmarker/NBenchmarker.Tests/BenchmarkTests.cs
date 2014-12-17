using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
