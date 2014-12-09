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
            result = new BenchmarkResult(trial);
        }

        [TestMethod]
        public void DoesNotApplyWhenIterationsAreLessThan()
        {
            result.NumberOfIterations = 4;
            var constraint = new NumberOfIterationsConstraint(5);
            Assert.IsFalse(constraint.Applies(result));
        }

        [TestMethod]
        public void AppliesWhenIterationsAreEqual()
        {
            result.NumberOfIterations = 5;
            var constraint = new NumberOfIterationsConstraint(5);
            Assert.IsTrue(constraint.Applies(result));
        }

        [TestMethod]
        public void AppliesWhenIterationsAreGreaterThan()
        {
            result.NumberOfIterations = 6;
            var constraint = new NumberOfIterationsConstraint(5);
            Assert.IsTrue(constraint.Applies(result));
        }
    }
}
