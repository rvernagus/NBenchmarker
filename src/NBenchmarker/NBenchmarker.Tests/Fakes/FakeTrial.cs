
namespace NBenchmarker.Tests.Fakes
{
    public class FakeTrial : Trial
    {
        private bool _setUpWasCalled;
        private bool _beforeEachIterationWasCalled;
        private bool _forEachIterationWasCalled;
        private bool _afterEachIterationWasCalled;
        private bool _tearDownWasCalled;

        public FakeTrial(string name)
            : base(name)
        {
            this.CallOrder = "";
            this.SetUp = () =>
                { _setUpWasCalled = true; CallOrder += "1"; };
            this.BeforeEachIteration = () =>
                { _beforeEachIterationWasCalled = true; CallOrder += "2"; };
            this.ForEachIteration = () =>
                { _forEachIterationWasCalled = true; CallOrder += "3"; };
            this.AfterEachIteration = () =>
                { _afterEachIterationWasCalled = true; CallOrder += "4"; };
            this.TearDown = () =>
                { _tearDownWasCalled = true; CallOrder += "5"; };
        }

        public string CallOrder { get; private set; }
    }
}
