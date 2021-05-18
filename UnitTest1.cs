using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace Sitest
{
    public class angularTodo
    {
        public IWebDriver driver;
        public angularTodo(IWebDriver driver)
        {
            this.driver = driver;
        }
        public angularTodo GoToPage()
        {
            driver.Navigate().GoToUrl("https://todomvc.com/examples/angularjs/#/");
            return this;
        }
        IWebElement TodoTask => driver.FindElement(By.ClassName("new-todo"));
        public angularTodo AddTask(string item)
        {
            TodoTask.SendKeys(item);
            TodoTask.Submit();
            return this;
        }
        IWebElement Mark => driver.FindElement(By.CssSelector("label[for=toggle-all]"));
        public void CompleteAll()
        {
            Mark.Click();
        }
        IWebElement ClearAll => driver.FindElement(By.CssSelector($"button.clear-completed"));
        public void CompleteItem(int id)
        {
            driver.FindElement(By.CssSelector($"ul.todo-list li:nth-child({id}) input.toggle")).Click();
        }
        public void ClearItem(int id)
        {
            var selectedTask = driver.FindElement(By.CssSelector($"li:nth-child({id}) label.ng-binding"));
            var action = new Actions(driver);
            action.MoveToElement(selectedTask).Build().Perform();
            driver.FindElement(By.CssSelector($"li:nth-child({id}) button.destroy")).Click();
        }
        public void ClearCompletedItems()
        {
            ClearAll.Click();
        }
        IWebElement ItemsLeft => driver.FindElement(By.CssSelector("strong.ng-binding"));
        public int GetTodoCount()
        {
            return Int32.Parse(ItemsLeft.GetAttribute("innerHTML"));
        }

        public int GetTabElementNumber()
        {
            return driver.FindElements(By.CssSelector($"li.ng-scope")).Count;
        }
        IWebElement Active => driver.FindElement(By.CssSelector($"ul.filters li:nth-child(2) a"));
        IWebElement Completed => driver.FindElement(By.CssSelector($"ul.filters li:nth-child(3) a"));
        IWebElement All => driver.FindElement(By.CssSelector($"ul.filters li:nth-child(1) a"));
        public void ShowItems(ItemsStatus itemsStatus) =>
            (itemsStatus switch
            {
                ItemsStatus.All => All,
                ItemsStatus.Active => Active,
                ItemsStatus.Completed => Completed,
                _ => throw new ArgumentException()
            })
            .Click();
    }
    public enum ItemsStatus
    {
        All, Active, Completed,
    }
}