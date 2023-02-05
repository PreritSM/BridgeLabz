--- GET ALL EMPLOYEES

ALter procedure GetAllEmployeeData
as
Begin
Select * from Employee_Payroll
end;

Exec GetAllEmployeeData;

Create Procedure InsertDataInPayroll
(
@Name varchar(50),
@Salary float,
@StartDate date,
@Gender char(1) ,
@PhoneNumber bigint,
@Address varchar(50),
@Department varchar(50)
)
as
Begin
Insert into Employee_Payroll(Name,Salary,StartDate,Gender,PhoneNumber,Address,Department) values (@Name,@Salary,@StartDate,
@Gender,@PhoneNumber,@Address,@Department);
end;

Exec InsertDataInPayroll 'RAM',80000,'2019-06-23','M',9324194329,'Gagangiri','Informatica' ;
