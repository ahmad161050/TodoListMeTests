using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TodoListMeTests.Pages;

namespace TodoListMeTests.StepDefinitions
{
    [Binding]
    public class TodoListSteps
    {
        private static IWebDriver driver; // Using a static WebDriver instance to persist across scenarios
        private static WebDriverWait wait;
        private static TodoListPage todoListPage;

        // Initialize the WebDriver once before any test runs
        [BeforeTestRun]
        public static void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://todolistme.net/");
            driver.Manage().Window.Maximize();
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(3000); // Allow UI to fully load before interactions
            
            todoListPage = new TodoListPage(driver);
        }

        [Given(@"I open the TodoList application")]
        public void GivenIOpenTheTodoListApplication()
        {
            // The browser session is already initialized in Setup(), so no need to open a new one
            Console.WriteLine("Using existing browser session.");
        }

        [When(@"I add a new task ""(.*)"" to the list ""Today's Tasks""")]
        public void WhenIAddANewTaskToList(string task)
        {
            todoListPage.AddTaskToList(task);
            wait.Until(d => todoListPage.IsTaskDisplayed(task));
            Thread.Sleep(2000); // Short pause for visibility
        }

        [Then(@"the task ""(.*)"" should be displayed in the list ""Today's Tasks""")]
        public void ThenTheTaskShouldBeDisplayedInTheList(string task)
        {
            Assert.IsTrue(todoListPage.IsTaskDisplayed(task), $"Task '{task}' was not added successfully.");
            Thread.Sleep(2000); // Short pause for visibility
        }

        [When(@"I delete the task ""(.*)"" from the list ""Today's Tasks""")]
        public void WhenIDeleteTheTaskFromTheList(string task)
        {
            if (!todoListPage.IsTaskDisplayed(task))
            {
                throw new Exception($"Task '{task}' was not found in the list, deletion cannot proceed.");
            }
            
            Console.WriteLine($"Attempting to delete task: {task}");
            todoListPage.DeleteTaskFromList(task);
            wait.Until(d => todoListPage.IsTaskDeleted(task));
        }

        [Then(@"the task ""(.*)"" should not be displayed in the list ""Today's Tasks""")]
        public void ThenTheTaskShouldNotBeDisplayedInTheList(string task)
        {
            Assert.IsTrue(todoListPage.IsTaskDeleted(task), $"Task '{task}' was not deleted successfully.");
            Thread.Sleep(2000); // Short pause for visibility
        }

        // Close the browser only once after all tests have finished executing
        [AfterTestRun]
        public static void TearDown()
        {
            Console.WriteLine("Closing browser after all tests.");
            Thread.Sleep(3000); // Final pause before closing
            driver.Quit();
        }
    }
}
