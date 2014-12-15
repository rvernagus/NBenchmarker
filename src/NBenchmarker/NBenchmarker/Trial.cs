using System;

namespace NBenchmarker
{
    public class Trial
    {
        public Trial(string name)
        {
            this.Name = name;
            this.SetUp = () => { };
            this.BeforeEachIteration = () => { };
            this.ForEachIteration = () => { };
            this.AfterEachIteration = () => { };
            this.TearDown = () => { };
        }

        public string Name { get; private set; }

        public Action SetUp { get; set; }

        public Action BeforeEachIteration { get; set; }

        public Action ForEachIteration { get; set; }

        public Action AfterEachIteration { get; set; }

        public Action TearDown { get; set; }
    }
}
