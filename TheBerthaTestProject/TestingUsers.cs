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
            Assert.AreEqual("Izq", users.firstName);

            users = _controller.Get(8);
            Assert.IsNull(users); // Passed
        }

        [TestMethod]
        public void TestPostUsers()
        {
            Users newUsers = new Users
            {
                firstName ="Milena",
                lastName = "Ognianova",
                userName = "mimi",
                pass = "pass",
                year = 20,
                gender = "F",
                typeOfUser ="S"
            };
            bool usersCount = _controller.Post(newUsers);
            Assert.AreEqual(true, usersCount);

            IEnumerable<Users> usersList = _controller.Get();
            Assert.AreEqual(4, usersList.Count()); // Passed
        }

        [TestMethod]
        public void TestPutUsers()
        { 
            Users newUsers = new Users()
            {
                firstName = "Izabela",
                lastName = "k",
                userName = "ooo",
                pass = "ooo",
                year = 20,
                gender = "F",
                typeOfUser = "U"
            };
            int usersCount = _controller.Put(1, newUsers);
            Assert.AreEqual("Izabela", newUsers.firstName); // Passed
        }

        [TestMethod]
        public void TestDeleteUsers()
        {
            int listCount = _controller.Delete(78);
            Assert.AreEqual(0, listCount); // Passed
        }
    }
}
