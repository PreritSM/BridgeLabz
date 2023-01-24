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
            string FirstNamePattern = "^[A-Z][a-z]{2,}$";
            return Regex.IsMatch(firstName,FirstNamePattern);
        }

        public bool ValidateLastName(string lastName)
        {
            string LastNamePattern = "^[A-Z][a-z]{2,}";
            return Regex.IsMatch(lastName,LastNamePattern);
        }
        public bool ValidateEmail(string email)
        {
            string EmailPattern = "^[A-Za-z]+\\.?[A-Za-z]+@[A-Za-z]+\\.[A-Za-z]+\\.?[A-Za-z]+";
            return Regex.IsMatch(email,EmailPattern);
        }
        public bool ValidatePhoneNumber(string phoneNumber)
        {
            string PhonePattern = "^[0-9]{2,3}\\s[0-9]{10}";
            return Regex.IsMatch(phoneNumber, PhonePattern);
        }
        
        public bool ValidatePassword(string password)
        {
            bool digit = false, capital = false, specialchar = false;
            foreach (char s in password)
            {
                int val = Convert.ToInt32(s);
                if ( val>47 && val<58)
                {
                    digit = true;
                }

                if ( val >64 && val < 91)
                {
                    capital = true;
                }

                if ((val >31 && val<48) || (val >57 && val<65) || (val> 90 && val<97)
                    || (val >122 && val<127))
                {
                    specialchar = true;
                }

                
            }
            if (digit && capital && specialchar && (password.Length >= 8))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
