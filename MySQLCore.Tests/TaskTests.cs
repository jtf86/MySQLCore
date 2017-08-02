using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySQLCore.Models;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
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
    }
}
