using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
