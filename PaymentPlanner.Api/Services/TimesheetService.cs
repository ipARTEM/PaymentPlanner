using PaymentPlanner.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentPlanner.Api.Services
{
    public class TimesheetService
    {
        public bool TrackTime(TimeLog timeLog)
        {

            

            Timesheet.TimeLogs.Add(timeLog);

            return true;
            
        }
    }


    public static class Timesheet
    {
        public static List<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
    }
}
