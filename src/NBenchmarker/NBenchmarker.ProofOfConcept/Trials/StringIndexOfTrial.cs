
namespace NBenchmarker.ProofOfConcept.Trials
{
    public class StringIndexOfTrial : Trial
    {
        public StringIndexOfTrial(string stringToSearch, string stringToFind)
            : base("String.IndexOf")
        {
            this.ForEachIteration = () =>
            {
                stringToSearch.IndexOf(stringToFind);
            };
        }
    }
}
