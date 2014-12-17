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
            var stopwatch = new Fakes.FakeStopwatch();
            stopwatch.SetElapsedTime(TimeSpan.FromSeconds(1));
            var trial = new Trial("")
            {
                Stopwatch = stopwatch
            };

            var result = Benchmark.Run(trial);

            Assert.AreEqual(TimeSpan.FromSeconds(1), result.ElapsedTime);
        }

        //[TestMethod]
        //public void ExecutesStopwatchInSequence()
        //{
        //    var trial = new Trial("");
        //    var stopwatch = Helpers.StopWatchHelper.GetFiveSecondStopwatchWithTwoTicks();

        //    Benchmark.Run(trial, stopwatch);

        //    Assert.AreEqual("13323", stopwatch.CallOrder);
        //}

        //[TestMethod]
        //public void DefaultIteratesForFiveSeconds()
        //{
        //    var trial = new Fakes.FakeTrial("");
        //    var stopwatch = Helpers.StopWatchHelper.GetFiveSecondStopwatch();

        //    var result = Benchmark.Run(trial, stopwatch);

        //    Assert.AreEqual(5, result.NumberOfIterations);
        //}
    }
}
