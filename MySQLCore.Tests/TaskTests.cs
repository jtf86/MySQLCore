using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MySQLCore.Models;

namespace MySQLCore.Tests
{

[TestClass]
public class TaskTest : IDisposable
  {
    public TaskTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=todo_test;";
    }
    public void Dispose()
    {
      Task.DeleteAll();
      Category.DeleteAll();
    }

    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Task.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_TrueForSameDescription_Task()
    {
      //Arrange, Act
      Task firstTask = new Task("Mow the lawn");
      Task secondTask = new Task("Mow the lawn");

      //Assert
      Assert.AreEqual(firstTask, secondTask);
    }

    [TestMethod]
    public void Save_TaskSavesToDatabase_TaskList()
    {
      //Arrange
      Task testTask = new Task("Mow the lawn");
      testTask.Save();

      //Act
      List<Task> result = Task.GetAll();
      List<Task> testList = new List<Task>{testTask};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_id()
    {
      //Arrange
      Task testTask = new Task("Mow the lawn");
      testTask.Save();

      //Act
      Task savedTask = Task.GetAll()[0];

      int result = savedTask.GetId();
      int testId = testTask.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_FindsTaskInDatabase_Task()
    {
      //Arrange
      Task testTask = new Task("Mow the lawn");
      testTask.Save();

      //Act
      Task result = Task.Find(testTask.GetId());

      //Assert
      Assert.AreEqual(testTask, result);
    }

  }
}
