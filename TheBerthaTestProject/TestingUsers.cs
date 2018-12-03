using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheBerthaRestConsumer;
using TheBerthaRestConsumer.Controllers;
using TheBerthaRestConsumer.Model;

namespace TheBerthaTestProject
{
    [TestClass]
    public class TestingUsers
    {
        private readonly UsersController _controller = new UsersController();

        [TestMethod]
        public void TestGetAllUsers()
        {
            IEnumerable<Users> usersList = _controller.Get();
            Assert.AreEqual(3, usersList.Count());

            Users users = _controller.Get(1);
            Assert.AreEqual("Izq", users.FirstName);

            users = _controller.Get(8);
            Assert.IsNull(users); // Passed
        }

        [TestMethod]
        public void TestPostUsers()
        {
            Users newUsers = new Users
            {
                FirstName ="Milena",
                LastName = "Ognianova",
                UserName = "mimi",
                Pass = "pass",
                Age = 20,
                Gender = "F",
                TypeOfUser ="S"
            };
            int usersCount = _controller.Post(newUsers);
            Assert.AreEqual(1, usersCount);

            IEnumerable<Users> usersList = _controller.Get();
            Assert.AreEqual(4, usersList.Count()); // Passed
        }

        [TestMethod]
        public void TestPutUsers()
        { 
            Users newUsers = new Users()
            {
                FirstName = "Izabela",
                LastName = "k",
                UserName = "ooo",
                Pass = "ooo",
                Age = 20,
                Gender = "F",
                TypeOfUser = "U"
            };
            int usersCount = _controller.Put(1, newUsers);
            Assert.AreEqual("Izabela", newUsers.FirstName); // Passed
        }

        [TestMethod]
        public void TestDeleteUsers()
        {
            int listCount = _controller.Delete(78);
            Assert.AreEqual(0, listCount); // Passed
        }
    }
}
