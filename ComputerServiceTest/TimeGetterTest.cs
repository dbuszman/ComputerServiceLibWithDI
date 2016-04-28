using System;
using ComputerService;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerServiceTest
{
    [TestClass]
    public class TimeGetterTest
    {
        [TestMethod]
        public void CurrentTimeGetterTest()
        {
            DateTime fixedDate = DateTime.Parse("2016, 3, 15").Date;
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => { return new DateTime(2016, 3, 15); };
                
                var currentTimeGetter = new CurrentTimeGetter();
                
                DateTime currentTime = currentTimeGetter.GetCurrentTime();
                
                Assert.AreEqual(fixedDate, currentTime);
            }
        }
    }
}
