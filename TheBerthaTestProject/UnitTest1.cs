using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc.Core;
using System.Collections.Generic;
using TheBerthaRestConsumer.Controllers;
using TheBerthaRestConsumer.Model;
using System.Linq;
using System;

namespace TheBerthaTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private readonly HealthController _controller = new HealthController();

        [TestMethod]
        public void TestGetAllMethod()
        {
            IEnumerable<Health> healthDataList = _controller.Get();
            Assert.AreEqual(1, healthDataList.Count());

            Health healthData = _controller.Get(8);
            Assert.AreEqual(67, healthData.HeartRate);

            healthData = _controller.Get(1);
            Assert.IsNull(healthData);
        }

        [TestMethod]  
        public void TestDeleteMethod()
        {
            int listCount = _controller.Delete(1);
            Assert.AreEqual(0, listCount);

            listCount = _controller.Delete(7);
            Assert.AreEqual(0, listCount);

            IEnumerable<Health> healthDataList = _controller.Get();
            Assert.AreEqual(1, healthDataList.Count());
        }

        [TestMethod]
        public void TestPostMethod()
        {
            DateTime tryDate = new DateTime(2018, 01, 01);
            Health newHealthData = new Health
            {
                BloodPressureUpper = 100,
                BloodPressureDown = 50,
                HeartRate = 77,
                Temperature = 36,
                UserId = 1,
                DateTimeInfo = tryDate
            };
            int healthDataCount = _controller.Post(newHealthData);
            Assert.AreEqual(1, healthDataCount);

            IEnumerable<Health> healthDataList = _controller.Get();
            Assert.AreEqual(4, healthDataList.Count());
        }

        [TestMethod]
        public void TestPutMethod()
        {
            DateTime tryDate = new DateTime(2019, 02, 02);
            Health newHealthData = new Health
            {
                BloodPressureUpper = 101,
                BloodPressureDown = 51,
                HeartRate = 77,
                Temperature = 36,
                UserId = 1,
                DateTimeInfo = tryDate
            };
            int healthDataCount = _controller.Put(11, newHealthData);
            Assert.AreEqual(101, newHealthData.BloodPressureUpper);
        }


    }
}
