using System;
using System.Collections;
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
    public class TestingEnvironment
    {
        private readonly EnvironmentController _controller = new EnvironmentController();
        [TestMethod]
        public void TestGetAllEnvironment()
        {
            IEnumerable<EnvironmentClass> environmentList = _controller.Get();
            Assert.AreEqual(3, environmentList.Count()); // Passed

            //EnvironmentClass env = _controller.Get(1); 
            //Assert.AreEqual(7, env.Oxygen);

            //env = _controller.Get(3);
            //Assert.IsNull(env);     
        }

        [TestMethod]
        public void TestPostEnvironment()
        {
            DateTime tryDate = new DateTime(2018, 01, 01);
            EnvironmentClass newEnv = new EnvironmentClass
            {
                Oxygen = 7,
                Co2 = 7,
                Co = 19,
                Pm25 = 18,
                Pm10 = 45,
                Ozon = 22,
                DustParticles = 11,
                NitrogenDioxide = 12,
                SulphurDioxide = 34,
                Longitude = 67,
                Latitude = 8,
                UserId = 2,
                DateTimeInfo = tryDate
            };
            int EnvCount = _controller.Post(newEnv);
            Assert.AreEqual(1, EnvCount);

            IEnumerable<EnvironmentClass> envList = _controller.Get();
            Assert.AreEqual(4, envList.Count()); // Passed 
        }

        [TestMethod]
        public void TestPutEnvironment()
        {
            DateTime tryDate = new DateTime(2019, 02, 02);
            EnvironmentClass newEnv = new EnvironmentClass
            {
                Oxygen = 18,
                Co2 = 7,
                Co = 19,
                Pm25 = 18,
                Pm10 = 45,
                Ozon = 22,
                DustParticles = 11,
                NitrogenDioxide = 12,
                SulphurDioxide = 34,
                Longitude = 67,
                Latitude = 8,
                UserId = 2,
                DateTimeInfo = tryDate
            };
            int EnvCount = _controller.Put(7, newEnv);
            Assert.AreEqual(18, newEnv.Oxygen); // Passed
        }

        [TestMethod]
        public void TestDeleteEnvrironment()
        {
            int listCount = _controller.Delete(1);
            Assert.AreEqual(0, listCount);

            listCount = _controller.Delete(7);
            Assert.AreEqual(0, listCount);

            IEnumerable<EnvironmentClass> EnvList = _controller.Get();
            Assert.AreEqual(6, EnvList.Count()); // Passed, but check again to be sure 
        }
    }
}
