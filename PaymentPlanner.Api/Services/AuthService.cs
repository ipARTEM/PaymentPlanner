using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentPlanner.Api.Services
{
    public class AuthService
    {
        public AuthService()
        {

            Employees = new List<string>
            {
                "Biden",
                "Tramp",
                "Obama"
            };

        }

        public List <string> Employees { get; set; }

        


        public bool Login(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            var isEmployeeExist = Employees.Contains(lastName);

            if (isEmployeeExist)
            {
                UserSession.Sessions.Add(lastName);
            }

            return isEmployeeExist;
        }
    }

    public static class UserSession
    {
        public static HashSet<string> Sessions { get; set; } = new HashSet<string>();
    }
}
