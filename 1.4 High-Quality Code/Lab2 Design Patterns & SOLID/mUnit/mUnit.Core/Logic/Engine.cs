namespace mUnit.Core.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Attributes;
    using Interfaces;
    using TestRunners;

    public class Engine
    {
        private readonly string assemblyPath;

        public Engine(string assemblyPath, IOutputWriter writer)
        {
            this.assemblyPath = assemblyPath;
            this.OutputWriter = writer;
        }

        public IOutputWriter OutputWriter { get; private set; }

        public void Run()
        {
            var assemblyLoader = new AssemblyLoader(this.assemblyPath);
            var assembly = assemblyLoader.Assembly;

            var testMethodLoader = new TestMethodLoader(assembly);
            var testContainers = testMethodLoader.LoadTestMethods();
            foreach (var testContainer in testContainers)
            {
                var instance = Activator.CreateInstance(testContainer.Key);
                var testMethods = testContainer.Value;
                foreach (MethodInfo testMethod in testMethods)
                {
                    var testType = this.GetTestType(testMethod);

                    var testRunner = TestRunnerFactory.GetTestRunner(
                        testType,
                        testMethod,
                        instance);

                    testRunner.RunTest();
                    this.LogTestResult(testRunner, testMethod);
                }
            }
        }

        private void LogTestResult(TestRunner testRunner, MethodInfo testMethod)
        {
            switch (testRunner.TestResult)
            {
                case TestResult.Passed:
                    this.OutputWriter.Write(
                        string.Format(
                            "Test {0} passed!",
                            testMethod.Name));
                    break;
                case TestResult.Failed:
                    this.OutputWriter.Write(
                        string.Format(
                            "Test {0} failed. Reason: {1}",
                            testMethod.Name,
                            testRunner.FailReason));
                    break;
                case TestResult.Skipped:
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException("TestResult not supported");
            }
        }

        private TestType GetTestType(MethodInfo testMethod)
        {
            var uniqueAttributeTypes = new HashSet<string>();
            var allAttributes = testMethod.GetCustomAttributes();
            foreach (var attr in allAttributes)
            {
                uniqueAttributeTypes.Add(attr.GetType().Name);
            }

            if (uniqueAttributeTypes.Contains(typeof (TestCaseAttribute).Name))
            {
                if (uniqueAttributeTypes.Contains(typeof (ShouldThrowAttribute).Name))
                {
                    return TestType.TestCasesShouldThrow;
                }
                
                return TestType.TestCasesNormal;
            }

            if (uniqueAttributeTypes.Contains(typeof (ShouldThrowAttribute).Name))
            {
                return TestType.ShouldThrow;
            }

            return TestType.Normal;
        }
    }
}
