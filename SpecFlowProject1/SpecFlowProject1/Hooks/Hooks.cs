using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Utility;
using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

/*[BeforeTestRun]
[BeforeFeature]
[BeforeScenario]
[BeforeScenarioBlock]
[BeforeStep]
[AfterStep]
[AfterScenarioBlock]
[AfterScenario]
[AfterFeature]
[AfterTestRun]*/


namespace SpecFlowProject1.Hooks
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        public readonly IObjectContainer _container;
        private static ScenarioContext _scenarioContext;
        public IWebDriver driver;

        public Hooks(IObjectContainer container)
        {
                             
            _container = container;//get the container varaible and assign to internal variable
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }     

        [BeforeFeature]
        [Scope(Feature = "Member addition")]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");            
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
                
        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativepath = @"..\..\..\..\SpecFlowProject1\Drivers";
            var chromeDriverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativepath));
            driver = new ChromeDriver(chromeDriverPath);
            System.Threading.Thread.Sleep(8000);
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(5000);
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }
      
        [AfterStep]
        public void AfterStep()
        {

            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;

                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;

                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;

                default:
                    CreateNode<And>();
                    break;

            }
        }
        //When scenario fails
        public void CreateNode<T>() where T : IGherkinFormatterModel
        {            
            if (_scenarioContext.ScenarioExecutionStatus.ToString() == "TestSkipped")
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending");
            }
            else if (_scenarioContext.TestError != null)
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);                
            }
            else
            {
                _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text);              
              
            }
        }
        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)            
            {
                ExtentReport.LogScreenshot("Ending Test", addScreenshot(driver, _scenarioContext));
                driver.Quit();
            }
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
            

        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            
            ExtentReportTearDown();
        }
    }
}


    


