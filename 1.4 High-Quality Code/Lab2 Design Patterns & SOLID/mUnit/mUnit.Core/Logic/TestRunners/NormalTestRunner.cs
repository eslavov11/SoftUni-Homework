namespace mUnit.Core.Logic.TestRunners
{
    using System;
    using System.Reflection;

    public class NormalTestRunner : TestRunner
    {
        public NormalTestRunner(
            MethodInfo methodInfo, 
            object typeInstance)
            : base(methodInfo, typeInstance)
        {
        }

        public override void RunTest()
        {
            try
            {
                this.TestMethod.Invoke(this.TypeInstance, this.MethodArgs);
                this.TestResult = TestResult.Passed;
            }
            catch (Exception ex)
            {
                this.SetFailResult(ex.InnerException.Message);
            }
        }
    }
}
