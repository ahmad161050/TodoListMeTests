using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TodoListMeTests.Pages
{
    public class TodoListPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // Locators 
        private By taskInputField => By.XPath("//input[@id='newtodo']");
        private By taskItem(string task) => By.XPath($"//span[contains(@id, 'mytodo') and text()='{task}']");
        private By deleteButton(string task) => By.XPath($"//span[contains(@id, 'mytodo') and text()='{task}']/following-sibling::img[@class='delete']");


        // Constructor
        public TodoListPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Add Task Method
        public void AddTaskToList(string task)
        {
            var inputField = wait.Until(d => d.FindElement(taskInputField));
            inputField.Clear();
            inputField.SendKeys(task);
            inputField.SendKeys(Keys.Enter);
        }

        // Check if Task is Displayed
        public bool IsTaskDisplayed(string task)
        {
            return wait.Until(d => d.FindElements(taskItem(task)).Count > 0);
        }

        // Delete Task Method (Click task first to make delete button visible)
        public void DeleteTaskFromList(string task)
        {
            var taskElement = wait.Until(d => d.FindElement(taskItem(task)));
            taskElement.Click(); // Click to reveal delete button

            var deleteBtn = wait.Until(d => d.FindElement(deleteButton(task)));
            deleteBtn.Click();
        }

        // Check if Task is Deleted
        public bool IsTaskDeleted(string task)
        {
            return wait.Until(d => d.FindElements(taskItem(task)).Count == 0);
        }
    }
}
