Select max(Salary) from Employee_Payroll;

Select * from Employee_Payroll where Salary = (Select max(Salary) from Employee_Payroll);


