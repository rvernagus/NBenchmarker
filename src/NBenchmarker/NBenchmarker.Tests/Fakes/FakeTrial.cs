
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
            this.OrderOfCalls = "";
            this.SetUp = () =>
                { _setUpWasCalled = true; OrderOfCalls += "1"; };
            this.BeforeEachIteration = () =>
                { _beforeEachIterationWasCalled = true; OrderOfCalls += "2"; };
            this.ForEachIteration = () =>
                { _forEachIterationWasCalled = true; OrderOfCalls += "3"; };
            this.AfterEachIteration = () =>
                { _afterEachIterationWasCalled = true; OrderOfCalls += "4"; };
            this.TearDown = () =>
                { _tearDownWasCalled = true; OrderOfCalls += "5"; };
        }

        public string OrderOfCalls { get; private set; }
    }
}
