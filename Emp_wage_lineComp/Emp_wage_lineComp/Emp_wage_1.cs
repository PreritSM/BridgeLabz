using System;

namespace emp_wages_line{

    class emp_wages
    {

        // Function for random number generation
        public int choice(int lower_limit, int upper_limit)
        {
            Random num = new Random();
            int val = num.Next(lower_limit, upper_limit);
            return val;
        }

        // Function for USE CASE - 1

        public void empP_or_A()
        {
            Console.WriteLine("This function is for attendance using random function");
            // Creating a random number generator
            int val = choice(0, 2);
            Console.WriteLine("The random number generated is " + val);
            int present = 1;
            if (val == present)
            {
                Console.WriteLine("The employee is present");
            }
            else
            {
                Console.WriteLine("The employee is absent");
            }
        }

        // Function for USE CASE - 2

        public void dailyWage()
        {
            Console.WriteLine("Calculating daily wage of employees acc. to their attendance :");
            // Calling a random number generator
            int val = choice(0, 2);
            Console.WriteLine("The random number generated is " + val);
            int present = 1;
            // Checking for attendance and calculating wage
            int wage_per_hour = 20;
            int full_day_hours = 8;
            if (val == present)
            {
                Console.WriteLine("The employee is present");
            }
            else
            {
                Console.WriteLine("The employee is absent");
            }
            Console.WriteLine("The wage calculated for the employee is " + (wage_per_hour * full_day_hours * val));
        }

        // Function for USE CASE - 3

        public void partTimeWage()
        {
            Console.WriteLine("Calculating Part time wages (assuming part time - 4hrs) :");
            // Calling a random number generator
            int val = choice(0, 3);
            int present = 1;
            int part_time = 2;
            // Checking for attendance and calculating wage
            int wage_per_hour = 20;
            int full_day_hours = 8;
            if (val == present)
            {
                Console.WriteLine("The employee is present");
                Console.WriteLine("The wage calculated for the employee is " + (wage_per_hour * full_day_hours * val));
            }
            else if (val == part_time)
            {
                Console.WriteLine("The employee is available part time");
                Console.WriteLine("The wage calculated for the employee is " + (wage_per_hour * (full_day_hours / 2) * 1));
            }
            else
            {
                Console.WriteLine("The employee is present");
                Console.WriteLine("The wage calculated for the employee is " + (wage_per_hour * full_day_hours * val));
            }
        }

        // Function for USE CASE - 4

        public void switchWage()
        {
            Console.WriteLine("Calculating Part time wages (assuming part time - 4hrs) using Switch Case :");
            // Calling a random number generator
            int val = choice(0, 3);

            // Wage parameters
            int wage_per_hour = 20;
            int full_day_hours = 8;

            switch (val)
            {
                case 0:
                    Console.WriteLine("The employee is absent");
                    Console.WriteLine("The wage calculated for the employee is " + (wage_per_hour * full_day_hours * 0));
                    break;
                case 1:
                    Console.WriteLine("The employee is present");
                    Console.WriteLine("The wage calculated for the employee is " + (wage_per_hour * full_day_hours * 1));
                    break;
                case 2:
                    Console.WriteLine("The employee is available part time");
                    Console.WriteLine("The wage calculated for the employee is " + (wage_per_hour * (full_day_hours / 2) * 1));
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

        // Function for USE CASE - 5
        public void wagesForMonth()
        {
            Console.WriteLine("Calculating Wages for a month (30 days)");
            // Wage parameters
            int wage_per_hour = 20;
            int full_day_hours = 8;
            int part_day_hours = 4;
            // Calculating properties
            int worked_days = 0;
            int final_wage_for_month = 0;
            for (int i = 0; i < 30; i++)
            {
                // Calling a random number generator
                int val = choice(0, 3);
                if (val == 1 && worked_days < 21)
                {
                    worked_days++;
                    final_wage_for_month += wage_per_hour * full_day_hours;
                }
                else if (val == 2 && worked_days < 21)
                {
                    worked_days++;
                    final_wage_for_month += wage_per_hour * part_day_hours;
                }
                else
                {
                    final_wage_for_month += 0;
                }
            }
            Console.WriteLine("Total number of days worked : " + worked_days);
            Console.WriteLine("The final wages for the whole month : " + final_wage_for_month);
        }
    }
    


    
    
}