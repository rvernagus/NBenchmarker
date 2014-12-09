using System;

namespace NBenchmarker.ProofOfConcept
{
    public class Trial
    {
        public Trial(string name)
        {
            this.Name = name;
            this.Setup = () => { };
            this.NotTimedIteration = () => { };
            this.TimedIteration = () => { };
            this.TearDown = () => { };
        }

        public string Name { get; set; }

        public Action Setup { get; set; }

        public Action TimedIteration { get; set; }

        public Action NotTimedIteration { get; set; }

        public Action TearDown { get; set; }
    }
}
