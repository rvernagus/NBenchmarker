using NBenchmarker;

namespace StringSearchExample
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
