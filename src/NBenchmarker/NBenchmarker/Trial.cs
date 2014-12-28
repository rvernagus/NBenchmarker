using System;

namespace NBenchmarker
{
    public class Trial
    {
        public Trial(string name)
        {
            this.Name = name;
            this.Stopwatch = new DefaultStopwatch();
            this.SetUp = () => { };
            this.BeforeEachIteration = () => { };
            this.ForEachIteration = () => { };
            this.AfterEachIteration = _ => { };
            this.TearDown = () => { };
        }

        public string Name { get; private set; }

        public IStopwatch Stopwatch { get; set; }

        public Action SetUp { get; set; }

        public Action BeforeEachIteration { get; set; }

        public Action ForEachIteration { get; set; }

        public Action<BenchmarkResult> AfterEachIteration { get; set; }

        public Action TearDown { get; set; }
    }
}
