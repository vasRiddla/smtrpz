using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Sitest
{
    public class Tests
    {
        IWebDriver driver;
        angularTodo todosPage;
        List<string> tasks;
        [SetUp]
        public void SetupTodoPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            todosPage = new angularTodo(driver);
            todosPage.GoToPage();
        }
        [SetUp]
        public void SetupTaskList()
        {
            tasks = new List<string>()
            {
                "One", "Two", "Three", "Four", "Five", "Six"
            };
            foreach (var task in tasks)
            {
                todosPage.AddTask(task);
            }
        }
        [Test]
        public void AddItems_StringList_Added()
        {
            var newerTasks = new List<string>()
            {
                "One*", "Two*", "Three*"
            };
            foreach (var task in newerTasks)
            {
                todosPage.AddTask(task);
            }
            var result = tasks.Count + newerTasks.Count;
            Assert.AreEqual(result, todosPage.GetTodoCount());
        }
        [Test]
        public void AddItem_EmptyString_NotAdded()
        {
            var emptyTask = String.Empty;
            todosPage.AddTask(emptyTask);
            var result = tasks.Count;
            Assert.AreEqual(result, todosPage.GetTodoCount());
        }
        [Test]
        public void CompleteAll_AllItems_Completed()
        {
            todosPage.CompleteAll();
            var result = tasks.Count;
            todosPage.ShowItems(ItemsStatus.Completed);
            Assert.AreEqual(result, todosPage.GetTabElementNumber());
        }
        [Test]
        public void ShowItems_AllItems_Showed()
        {
            todosPage.CompleteItem(2);
            todosPage.CompleteItem(3);
            todosPage.ShowItems(ItemsStatus.All);
            var result = tasks.Count;
            Assert.AreEqual(result, todosPage.GetTabElementNumber());
        }
        [Test]
        public void ShowItems_ActiveItems_Showed()
        {
            var completedTasks = new List<int>()
            {
                4, 5
            };
            foreach (var id in completedTasks)
            {
                todosPage.CompleteItem(id);
            }
            todosPage.ShowItems(ItemsStatus.Active);
            var result = tasks.Count - completedTasks.Count;
            Assert.AreEqual(result, todosPage.GetTabElementNumber());
        }
        [Test]
        public void ShowItems_CompletedItems_Showed()
        {
            var completedTasks = new List<int>()
            {
                1, 4, 5
            };
            foreach (var id in completedTasks)
            {
                todosPage.CompleteItem(id);
            }
            todosPage.ShowItems(ItemsStatus.Completed);
            var result = completedTasks.Count;
            Assert.AreEqual(result, todosPage.GetTabElementNumber());
        }
        [Test]
        public void ClearItem_ElementsId_Cleared()
        {
            var deletededTasks = new List<int>()
            {
                1, 5
            };
            foreach (var id in deletededTasks)
            {
                todosPage.ClearItem(id);
            }
            var result = tasks.Count - deletededTasks.Count;
            Assert.AreEqual(result, todosPage.GetTodoCount());
        }
        [Test]
        public void ClearCompletedItems_ComleatedItems_Completed()
        {
            var completedTasks = new List<int>()
            {
                1, 5
            };
            foreach (var id in completedTasks)
            {
                todosPage.CompleteItem(id);
            }
            todosPage.ClearCompletedItems();
            todosPage.ShowItems(ItemsStatus.Completed);
            var result = 0;
            Assert.AreEqual(result, todosPage.GetTabElementNumber());
        }
    }
}