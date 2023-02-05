using System;
using EmployeeDataAdo.Net;

namespace EmployeePayRollAdo.Net
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ado.Net tutorial");
            EmployeeRepository employeeRepository = new EmployeeRepository();
            EmployeeRepository.GetAllEmployees();
        }
    }
}

