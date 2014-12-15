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
            Assert.IsNotNull(trial.BeforeEachIteration);
            Assert.IsNotNull(trial.ForEachIteration);
            Assert.IsNotNull(trial.TearDown);
            trial.SetUp();
            trial.BeforeEachIteration();
            trial.ForEachIteration();
            trial.TearDown();
        }
    }
}
