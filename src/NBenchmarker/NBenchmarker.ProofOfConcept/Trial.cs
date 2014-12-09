using System;

namespace NBenchmarker.ProofOfConcept
{
    public class Trial
    {
        public Trial()
        {
            this.Setup = () => { };
            this.Timed = () => { };
            this.TearDown = () => { };
        }

        public Action Setup { get; set; }

        public Action Timed { get; set; }

        public Action TearDown { get; set; }
    }
}
