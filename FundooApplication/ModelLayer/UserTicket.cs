using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class UserTicket
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }
        public string Token { get; set; }

        public DateTime CreatedAt { get; set; } 
    }
}
