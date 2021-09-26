using NUnit.Framework;
using PaymentPlanner.Api.Models;
using PaymentPlanner.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPlanner.Tests
{
    public class TimesheetServiceTests
    {
        public void TrackTime_ShouldReturnTrue()
        {
            //arrange
            var timeLog = new TimeLog
            {
                Date = new DateTime(),

                WorkingHours = 1,
                LastName = ""
            };


            var service = new TimesheetService();
            //act
            var result = service.TrackTime(timeLog);

            //assert
            Assert.IsTrue(result);
        }

         [Test]
        public void TrackTime_ShouldReturnFalse()
        {
            //arrange
            //var period = new DateTime();
            //var workingTimeHours = 1;
            //var lastName = "";

            var timeLog = new TimeLog
            {
                Date = new DateTime(),

                WorkingHours = 1,
                LastName = ""
            };


            var service=new TimesheetService();
            //act
            var result = service.TrackTime(timeLog); 

            //assert
            Assert.IsFalse(result);
        }


    }
}
