Insert into Employee_Payroll (Name,Salary,StartDate) values ('Prerit', 40000,GETDATE());
Insert into Employee_Payroll (Name,Salary,StartDate) values ('Aayush', 60000,'2023-01-29');

Select * from Employee_Payroll;

Select * from Employee_Payroll where Name = 'Prerit';

Select Name,Salary from Employee_Payroll where StartDate Between Cast('2023-01-30' as date) and Getdate();

Alter table Employee_Payroll ADD Gender char(1);
Select * from Employee_Payroll;

Update Employee_Payroll set Gender='M' where Id = 1;
Update Employee_Payroll set Gender ='M' where Id =2;
