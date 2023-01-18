using System;

namespace emp_wages_line
{
    class emp_wages_refactor
    {
        int wage_per_hour = 20;
        int full_day_hours = 8;
        int part_day_hours = 4;
        string company = "default";
        public emp_wages_refactor( string compName,int wages, int workhr)
        {
            this.wage_per_hour = wages;
            this.full_day_hours = workhr;
            this.part_day_hours = workhr / 2;
            this .company = compName;
        }

        // Function for random number generation
        public int choice(int lower_limit, int upper_limit)
        {
            Random num = new Random();
            int val = num.Next(lower_limit, upper_limit);
            return val;
        }
        
        public int wagesForMonthparameters()
        {
            Console.WriteLine("Calculating Wages for a month (30 days) with parameters \n Assuming only 20 days of work or 100 hrs");
            // Wage parameters

            // Calculating properties
            int worked_days = 0;
            int hours_worked = 0;
            int final_wage_for_month = 0;
            for (int i = 0; i < 30; i++)
            {
                // Calling a random number generator
                int val = choice(0, 3);
                if (val == 1 && worked_days < 21 && (hours_worked + 8) < 101)
                {
                    hours_worked += 8;
                    worked_days++;
                    final_wage_for_month += wage_per_hour * full_day_hours;
                }
                else if (val == 2 && worked_days < 21 && (hours_worked + 4) < 101)
                {
                    hours_worked += 4;
                    worked_days++;
                    final_wage_for_month += wage_per_hour * part_day_hours;
                }
                else
                {
                    final_wage_for_month += 0;
                }
            }
            Console.WriteLine("Total number of days worked : " + worked_days);
            Console.WriteLine("Total hours worked by the employee : " + hours_worked);
            Console.WriteLine("The final wages for the whole month : " + final_wage_for_month);
            Console.WriteLine("The above data is for the company : "+ company + " .");
            return final_wage_for_month;
        }


    }

}

