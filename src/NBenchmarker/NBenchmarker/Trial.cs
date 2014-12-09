using System;

namespace NBenchmarker
{
    public class Trial
    {
        public Trial(string name)
        {
            this.Name = name;
            this.SetUp = () => { };
            this.NotTimedIteration = () => { };
            this.TimedIteration = () => { };
            this.TearDown = () => { };
        }

        public string Name { get; private set; }

        public Action SetUp { get; set; }

        public Action NotTimedIteration { get; set; }

        public Action TimedIteration { get; set; }

        public Action TearDown { get; set; }
    }
}
