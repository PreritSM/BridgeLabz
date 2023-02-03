Insert into Employee_Payroll (Name,Salary,StartDate) values ('Prerit', 40000,GETDATE());
Insert into Employee_Payroll (Name,Salary,StartDate) values ('Aayush', 60000,'2023-01-29');

Select * from Employee_Payroll;

Select * from Employee_Payroll where Name = 'Prerit';

Select Name,Salary from Employee_Payroll where StartDate Between Cast('2023-01-30' as date) and Getdate();

Alter table Employee_Payroll ADD Gender char(1);
Select * from Employee_Payroll;

Update Employee_Payroll set Gender='M' where Id = 4;
Update Employee_Payroll set Name ='Manish', Salary= 60000 where Id =4;

Select SUM(Salary) as TotalSal_F from Employee_Payroll where Gender= 'M' group by Gender; 

--ALter Table Employee_Payroll Drop column PhoneNumber;
--Alter Table Employee_Payroll Drop column Address,Department;
Alter table Employee_Payroll ADD 
PhoneNumber bigint NOT NULL Default 1234567890,
Address varchar(50) NOT NULL Default 'Sharda University',
Department varchar(50) NOT NULL Default 'Engineering';

Alter Table Employee_Payroll ADD
Basic_Pay bigint,
Deductions bigint,
Taxable_Pay bigint,
Income_Tax bigint,
Net_Pay Bigint;

--Alter Table Employee_Payroll Drop Column
--Basic_Pay,Deductions,Taxable_Pay,Income_Tax,Net_Pay;