using System;

namespace NBenchmarker.ProofOfConcept
{
    public class Trial
    {
        public Trial(string name)
        {
            this.Name = name;
            this.Setup = () => { };
            this.Timed = () => { };
            this.TearDown = () => { };
        }

        public string Name { get; set; }

        public Action Setup { get; set; }

        public Action Timed { get; set; }

        public Action TearDown { get; set; }
    }
}
