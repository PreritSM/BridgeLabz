using System;
using System.Net.Http.Headers;

namespace emp_wages_line
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to the assignment on Employee Wage");
            //emp_wages myObj = new emp_wages();
            //myObj.empP_or_A();
            //myObj.dailyWage();
            //myObj.partTimeWage();
            //myObj.wagesForMonth();
            //myObj.wagesForMonthparameters();

            // BELOW CODE USES ARRAYLIST OF OBJECTS EXPLICITLY IN MAIN
            
           
            Console.WriteLine("Enter the number of companies' data you want to insert");
            int company_count = Convert.ToInt32(Console.ReadLine());
            int[] wage_array = new int[company_count];
            emp_wages_refactor[] Wages_comp = new emp_wages_refactor[company_count];

            for (int i = 0; i < company_count; i++)
            {
                Console.WriteLine("Enter company name");
                string company_name = Convert.ToString(Console.ReadLine());
                Console.WriteLine($"Enter the Wages for each full day of work at company {i + 1} : ");
                int dailywage = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Total working hrs in a day : ");
                int workinghrs = Convert.ToInt32(Console.ReadLine());
                Wages_comp[i] = new emp_wages_refactor(company_name, dailywage, workinghrs);
                wage_array[i] = Wages_comp[i].wagesForMonthparameters();
                Console.WriteLine("\n");
            }

            for (int i = 0; i < wage_array.Length; i++)
            {
                Console.WriteLine($"The final wage of the company {i + 1} is {wage_array[i]} ");
            }
            

            // BELOW CODE USES THE OOPS CONCEPTS AND SPECIAL FOCUS ON INTERFACES
            /* 
             Console.WriteLine("Enter the number of companies' data you want to insert");
             int company_count = Convert.ToInt32(Console.ReadLine());

             IEmpWageInfo obj= new EmpWageInfo();

             for (int i = 0; i < company_count;i++)
             {
                 Console.WriteLine("Enter company name in lower case");
                 string company_name = Convert.ToString(Console.ReadLine());
                 Console.WriteLine($"Enter the Wages for each full day of work at company {i + 1} : ");
                 int dailywage = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter the Total working hrs in a day : ");
                 int workinghrs = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter Total working days in a month");
                 int workingdays = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("\n\n");
                 obj.setCompInfo(company_name, dailywage, workinghrs, workingdays);
             }

             obj.wageCalculator();


             Console.WriteLine("Enter the number of queries");
             int queries = Convert.ToInt32(Console.ReadLine());
             for (int i = 0;i < queries;i++)
             {
                 Console.WriteLine("Enter the company name in lower case");
                 string comp = Convert.ToString(Console.ReadLine());
                 try
                 {
                     Console.WriteLine($"The total wage of the {comp} is {obj.queryRes(comp)} .");
                 }
                 catch
                 {
                     Console.WriteLine("Invalid input");
                     continue;
                 }


             }
             */


        }
    }
}