
namespace NBenchmarker.ProofOfConcept.Trials
{
    public class StringContainsTrial : Trial
    {
        public StringContainsTrial(string stringToSearch, string stringToFind)
            : base("String.Contains")
        {
            this.ForEachIteration = () =>
            {
                stringToSearch.Contains(stringToFind);
            };
        }
    }
}
