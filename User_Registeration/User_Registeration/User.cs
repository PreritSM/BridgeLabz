using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace User_Registeration
{
    public class RegexDemo
    {
        public static string FirstNamePattern = "^[A-Z][a-z]{2,}$";

        public bool ValidateFirstName(string firstName)
        {
            return Regex.IsMatch(firstName,FirstNamePattern);
        }
    }
}
