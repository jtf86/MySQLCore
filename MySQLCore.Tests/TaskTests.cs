using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MySQLCore.Models;

namespace MySQLCore.Tests
{

    [TestClass]
    public class TaskTests : IDisposable
    {

        public void Dispose()
        {
            Task.DeleteAll();
        }


        [TestMethod]
        public void VerifyName_True()
        {
            //Arrange
            Task newTask = new Task("Walk the dog");

            //Assert
            Assert.AreEqual("Walk the dog", newTask.GetName());
        }

        [TestMethod]
        public void VerifyName_False()
        {
            //Arrange
            Task newTask = new Task("Mow the lawn");

            //Assert
            Assert.AreNotEqual("Walk the dog", newTask.GetName());
        }

        [TestMethod]
        public void SaveToDatabase_True()
        {
            // Arrange
            Task newTask = new Task("Make DB Connection Work");
            newTask.Save();
            List<Task> arrangedList = new List<Task> {};
            arrangedList.Add(newTask);
            // Act
            List<Task> allTasks = Task.GetAll();

            Console.Write("the id from the arranged list is ");
            Console.WriteLine(arrangedList[0].GetId());
            Console.Write("the id from the recovred list is ");
            Console.WriteLine(allTasks[0].GetId());

            // Assert
            CollectionAssert.AreEqual(arrangedList, allTasks);
        }
    }
}
