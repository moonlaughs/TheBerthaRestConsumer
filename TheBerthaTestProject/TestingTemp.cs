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
    public class TestingTemp
    {
        private readonly TemperatureController _controller = new TemperatureController();

        [TestMethod]
        public void TestGetAllTemp()
        {
            IEnumerable<Temperature> tempList = _controller.Get();
            Assert.AreEqual(70, tempList.Count());

            Temperature temp = _controller.Get(1);
            Assert.AreEqual("1", temp.Id);

            temp = _controller.Get(8);
            Assert.IsNull(temp); 
        }

        [TestMethod]
        public void TestPostTemp()
        {
            DateTime tryDate = new DateTime(2018, 01, 01);
            Temperature newTemp = new Temperature
            {
                Temp = 2,
                DT = tryDate
            };
            int tempCount = _controller.Post(newTemp);
            Assert.AreEqual(1, tempCount);

            IEnumerable<Temperature> tempList = _controller.Get();
            Assert.AreEqual(70, tempList.Count()); 
        }
    }
}
