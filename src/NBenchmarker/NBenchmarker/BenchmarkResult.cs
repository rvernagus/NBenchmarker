﻿using System;
using System.Collections.Generic;

namespace NBenchmarker
{
    public class BenchmarkResult
    {
        private TimeSpan _elapsedTime;
        private int _numberOfIterations;

        public BenchmarkResult(string trialName)
        {
            this.TrialName = trialName;
            this.ElapsedTime = TimeSpan.Zero;
            this.NumberOfIterations = 0;
            this.Data = new Dictionary<string, object>();
        }

        public string TrialName { get; private set; }

        public IDictionary<string, object> Data { get; private set; }

        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException("value", value, "ElapsedTime cannot be less than TimeSpan.Zero");
                }
                else
                {
                    _elapsedTime = value;
                }
            }
        }

        public int NumberOfIterations
        {
            get { return _numberOfIterations; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "NumberOfIterations cannot be less than 0");
                }
                else
                {
                    _numberOfIterations = value;
                }
            }
        }

        public TimeSpan IterationAverageDuration
        {
            get
            {
                var avgTicks = this.ElapsedTime.Ticks / this.NumberOfIterations;
                return TimeSpan.FromTicks(avgTicks);
            }
        }
    }
}
