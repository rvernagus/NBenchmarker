using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NBenchmarker.Tests
{
    //[TestClass]
    public class TrialTests
    {
        [TestClass]
        public class TheConstructor : TrialTests
        {
            [TestMethod]
            public void CreatesATrialWithTheGivenName()
            {
                var trial = new Trial("A Trial");
                Assert.AreEqual("A Trial", trial.Name);
            }

            [TestMethod]
            public void CreatesATrialWithEmptyActions()
            {
                var trial = new Trial("A Trial");
                Assert.IsNotNull(trial.SetUp);
                Assert.IsNotNull(trial.BeforeEachIteration);
                Assert.IsNotNull(trial.ForEachIteration);
                Assert.IsNotNull(trial.TearDown);
                trial.SetUp(null);
                trial.BeforeEachIteration();
                trial.ForEachIteration();
                trial.TearDown();
            }
        }
    }
}
