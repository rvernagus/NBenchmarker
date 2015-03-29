using NBenchmarker;
using System.Text.RegularExpressions;

namespace StringSearchExample
{
    public class RegexMatchTrial : Trial
    {
        public RegexMatchTrial(string stringToSearch, string stringToFind)
            : base("Regex.IsMatch")
        {
            this.ForEachIteration = () =>
            {
                Regex.IsMatch(stringToSearch, stringToFind);
            };
        }
    }
}
