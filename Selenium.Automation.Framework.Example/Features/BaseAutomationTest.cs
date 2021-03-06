﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace Selenium.Automation.Framework.Example.Features
{
    [TestFixture]
    [TestClass]
    public abstract class BaseAutomationTest : AutomationTest
    {
        public TestContext TestContext { get; set; }

        [SetUp]
        [TestInitialize]
        public void TestInitialize()
        {
            StartTest();

            Browser.Open("https://github.com/");
        }

        [TearDown]
        public void TearDown()
        {
            EndTest(() => NUnit.Framework.TestContext.CurrentContext.Result.Status == TestStatus.Failed);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            EndTest(() => TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed));
        }
    }
}
