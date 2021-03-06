﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NBenchmarker.Tests
{
    [TestClass]
    public class SecondsConstraintTests
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
        public class TheAppliesMethod : SecondsConstraintTests
        {
            [TestMethod]
            public void IsFalseWhenSecondsAreLessThanStoredValue()
            {
                result.ElapsedTime = TimeSpan.FromSeconds(4);
                var constraint = new SecondsConstraint(5);
                Assert.IsFalse(constraint.Applies(result));
            }

            [TestMethod]
            public void IsTruenWhenSecondsAreEqualToStoredValue()
            {
                result.ElapsedTime = TimeSpan.FromSeconds(5);
                var constraint = new SecondsConstraint(5);
                Assert.IsTrue(constraint.Applies(result));
            }

            [TestMethod]
            public void IsTrueWhenSecondsAreGreaterThanStoredValue()
            {
                result.ElapsedTime = TimeSpan.FromSeconds(6);
                var constraint = new SecondsConstraint(5);
                Assert.IsTrue(constraint.Applies(result));
            }
        }
    }
}
