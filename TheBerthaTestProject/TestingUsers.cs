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
        public void TestDeleteUsers()
        {
            int listCount = _controller.Delete(78);
            Assert.AreEqual(0, listCount);

            int howMany = _controller.Delete(1);
            Assert.AreEqual(1, howMany);

            //IEnumerable<Users> usersList = _controller.Get();
            //Assert.AreEqual(2, usersList.Count());
        }
    }
}
