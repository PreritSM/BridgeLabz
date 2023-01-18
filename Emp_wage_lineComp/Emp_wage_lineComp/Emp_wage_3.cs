using System;

namespace emp_wages_line
{
    public interface IEmpWageInfo
    {
        public void setCompInfo(string company_name, int dailywage, int fulldayhrs, int workingdays);
        public void wageCalculator();

        public int queryRes(string company_name);
    }
    public class CompDetails
    {
        public string company_name;
        public int dailywage;
        public int fulldayhrs;
        public int workingdays;

        public int total_wage = 0;
        public CompDetails( string company_name, int dailywage, int fulldayhrs, int workingdays )
        {
            this.company_name = company_name;
            this.dailywage = dailywage; 
            this.fulldayhrs= fulldayhrs;    
            this.workingdays = workingdays;
        }

        public void setTotalwage (int totalwage )
        {
            this.total_wage = totalwage;
        }

    }

    public class EmpWageInfo : IEmpWageInfo
    {
        public LinkedList<CompDetails> detailsLL;
        public Dictionary<string, CompDetails> QueryList;

        public EmpWageInfo()
        {
            this.detailsLL = new LinkedList<CompDetails>();
            this.QueryList = new Dictionary<string, CompDetails>();
        }

        public void setCompInfo(string company_name, int dailywage, int fulldayhrs, int workingdays)
        {   
            CompDetails companyCreds = new CompDetails( company_name, dailywage,fulldayhrs, workingdays );
            detailsLL.AddLast(companyCreds);
            QueryList.Add(company_name, companyCreds);
        }

        public int choice(int lower_limit, int upper_limit)
        {
            Random num = new Random();
            int val = num.Next(lower_limit, upper_limit);
            return val;
        }

        public void wageCalculator()
        {
            foreach(CompDetails compDetails_obj in detailsLL)
            {
                calcCode(compDetails_obj);
            }
        }  
        public void calcCode(CompDetails obj )
        {
            int worked_days = 0;
            int hours_worked = 0;
            int final_wage_for_month = 0;
            for (int i = 0; i < 30; i++)
            {

                int val = choice(0, 3);
                if (val == 1 && worked_days < obj.workingdays && (hours_worked + 8) < 101)
                {
                    hours_worked += 8;
                    worked_days++;
                    final_wage_for_month += obj.dailywage * obj.fulldayhrs;
                }
                else if (val == 2 && obj.workingdays < 21 && (hours_worked + 4) < 101)
                {
                    hours_worked += 4;
                    worked_days++;
                    final_wage_for_month += obj.dailywage * (obj.fulldayhrs/2);
                }
                else
                {
                    final_wage_for_month += 0;
                }
            }

            obj.setTotalwage(final_wage_for_month);

        }

        public int queryRes(string company_name)
        {
            return this.QueryList[company_name].total_wage;

        }

    }


}

