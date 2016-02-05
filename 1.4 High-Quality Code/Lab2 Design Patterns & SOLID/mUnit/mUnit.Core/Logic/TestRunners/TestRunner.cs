namespace mUnit.Core.Logic.TestRunners
{
    using System.Reflection;

    public abstract class TestRunner
    {
        protected TestRunner(MethodInfo methodInfo, object typeInstance)
        {
            this.TestMethod = methodInfo;
            this.TestResult = TestResult.NotRun;
            this.TypeInstance = typeInstance;
        }

        public MethodInfo TestMethod { get; set; }

        public object TypeInstance { get; set; }

        public object[] MethodArgs { get; set; }

        public TestResult TestResult { get; set; }

        public string FailReason { get; set; }

        protected void SetFailResult(string message)
        {
            this.FailReason = message;
            this.TestResult = TestResult.Failed;
        }

        public abstract void RunTest();
    }
}
