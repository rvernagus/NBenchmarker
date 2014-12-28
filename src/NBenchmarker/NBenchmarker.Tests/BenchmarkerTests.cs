using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace NBenchmarker.Tests
{
    [TestClass]
    public class BenchmarkerTests
    {
        private Benchmarker benchmarker;
        private Fakes.FakeTrial trial;
        private BenchmarkResult result;

        [TestInitialize]
        public void TestInitialize()
        {
            benchmarker = new Benchmarker();
            trial = new Fakes.FakeTrial("");
            result = new BenchmarkResult("");
        }

        [TestMethod]
        public void BenchmarkExecutesTrialActionsInSequence()
        {
            benchmarker.Run(trial);

            Assert.AreEqual("12345", trial.CallOrder);
        }

        [TestMethod]
        public void ResultRecordsStopwatchElapsedTime()
        {
            trial.SetElapsedTime(TimeSpan.FromSeconds(1));

            var result = benchmarker.Run(trial);

            Assert.AreEqual(TimeSpan.FromSeconds(1), result.ElapsedTime);
        }

        [TestMethod]
        public void AddsIterationToResult()
        {
            var wasCalled = false;
            trial.AfterEachIteration = result =>
            {
                Assert.AreEqual(1, result.NumberOfIterations);
                wasCalled = true;
            };

            benchmarker.Run(trial);

            Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void ExecutesStopwatchInSequence()
        {
            benchmarker.Run(trial);

            var stopwatch = (Fakes.FakeStopwatch)trial.Stopwatch;
            Assert.AreEqual("123", stopwatch.CallOrder);
        }

        [TestMethod]
        public void DefaultIteratesOneTime()
        {
            var result = benchmarker.Run(trial);

            Assert.AreEqual(1, result.NumberOfIterations);
        }

        [TestMethod]
        public void ContinuesForOneIterationByDefault()
        {
            Assert.IsTrue(benchmarker.ShouldContinue(result));

            result.NumberOfIterations = 1;

            Assert.IsFalse(benchmarker.ShouldContinue(result));
        }

        [TestMethod]
        public void IfConstraintIsAddedContinuesAccordingToNew()
        {
            result.NumberOfIterations = 1;

            Assert.IsFalse(benchmarker.ShouldContinue(result));

            benchmarker.AddConstraint(new NumberOfIterationsConstraint(2));

            Assert.IsTrue(benchmarker.ShouldContinue(result));
        }

        [TestMethod]
        public void ContinueWithNumberOfIterationsConstraint()
        {
            benchmarker.AddConstraint(new NumberOfIterationsConstraint(2));

            result.NumberOfIterations = 1;
            Assert.IsTrue(benchmarker.ShouldContinue(result));

            result.NumberOfIterations = 2;
            Assert.IsFalse(benchmarker.ShouldContinue(result));
        }

        [TestMethod]
        public void ContinueWithSecondsConstraint()
        {
            benchmarker.AddConstraint(new SecondsConstraint(5));

            result.ElapsedTime = TimeSpan.FromSeconds(4.9);
            Assert.IsTrue(benchmarker.ShouldContinue(result));

            result.ElapsedTime = TimeSpan.FromSeconds(5.0);
            Assert.IsFalse(benchmarker.ShouldContinue(result));
        }

        [TestMethod]
        public void ReturnsResultForEachTrial()
        {
            var trial1 = new Fakes.FakeTrial("1");
            var trial2 = new Fakes.FakeTrial("2");
            var trial3 = new Fakes.FakeTrial("3");

            var results = benchmarker.Run(trial1, trial2, trial3);

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("1", results[0].TrialName);
            Assert.AreEqual("2", results[1].TrialName);
            Assert.AreEqual("3", results[2].TrialName);
        }

        [TestMethod]
        public void AllowEnumerableOfTrialsToBeRun()
        {
            var trial1 = new Fakes.FakeTrial("1");
            var trial2 = new Fakes.FakeTrial("2");
            var trial3 = new Fakes.FakeTrial("3");
            IEnumerable<Trial> trials = new Trial[] { trial1, trial2, trial3 };

            var results = benchmarker.Run(trials);

            Assert.AreEqual(3, results.Count);
        }
    }
}
