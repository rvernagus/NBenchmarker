using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NBenchmarker.Tests
{
    [TestClass]
    public class TrialTests
    {
        [TestMethod]
        public void HasAName()
        {
            var trial = new Trial("A Trial");
            Assert.AreEqual("A Trial", trial.Name);
        }

        [TestMethod]
        public void NewTrialHasEmptyActions()
        {
            var trial = new Trial("A Trial");
            Assert.IsNotNull(trial.SetUp);
            Assert.IsNotNull(trial.NotTimedIteration);
            Assert.IsNotNull(trial.TimedIteration);
            Assert.IsNotNull(trial.TearDown);
            trial.SetUp();
            trial.NotTimedIteration();
            trial.TimedIteration();
            trial.TearDown();
        }
    }
}
