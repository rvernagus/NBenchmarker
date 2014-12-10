using System.Text.RegularExpressions;

namespace NBenchmarker.ProofOfConcept.Trials
{
    public class RegexMatchTrial : Trial
    {
        public RegexMatchTrial(string stringToSearch, string stringToFind)
            : base("Regex.IsMatch")
        {
            Regex.IsMatch(stringToSearch, stringToFind);
        }
    }
}
