using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NBenchmarker.Tests
{
    [TestClass]
    public class NumberOfIterationsConstraintTests
    {
        Trial trial;
        BenchmarkResult result;

        [TestInitialize]
        public void TestInitialize()
        {
            trial = new Trial("");
            result = new BenchmarkResult(trial.Name);
        }

        [TestClass]
        public class TheAppliesMethod : NumberOfIterationsConstraintTests
        {
            [TestMethod]
            public void IsFalseWhenIterationsAreLessThanStoredValue()
            {
                result.NumberOfIterations = 4;
                var constraint = new NumberOfIterationsConstraint(5);
                Assert.IsFalse(constraint.Applies(result));
            }

            [TestMethod]
            public void IsTrueWhenIterationsAreEqualToStoredValue()
            {
                result.NumberOfIterations = 5;
                var constraint = new NumberOfIterationsConstraint(5);
                Assert.IsTrue(constraint.Applies(result));
            }

            [TestMethod]
            public void IsTrueWhenIterationsAreGreaterThanStoredValue()
            {
                result.NumberOfIterations = 6;
                var constraint = new NumberOfIterationsConstraint(5);
                Assert.IsTrue(constraint.Applies(result));
            }
        }
    }
}
