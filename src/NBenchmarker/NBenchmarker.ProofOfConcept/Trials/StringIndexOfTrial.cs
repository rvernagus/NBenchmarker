
namespace NBenchmarker.ProofOfConcept.Trials
{
    public class StringIndexOfTrial : Trial
    {
        public StringIndexOfTrial(string stringToSearch, string stringToFind)
            : base("String.IndexOf")
        {
            this.TimedIteration = () =>
            {
                stringToSearch.IndexOf(stringToFind);
            };
        }
    }
}
