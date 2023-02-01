Alter procedure AddEmployeeWithTryCatch(
@Name varchar(50),
@Salary float,
@StartDate date,
@Gender char(1)
)
As
Begin
Begin Try
Insert into Employee_Payroll(Name,Salary,StartDate,Gender) values (@Name,@Salary,@StartDate,@Gender);
End Try
Begin Catch
Select 
ERROR_NUMBER() as Error_Number,
ERROR_LINE() as Error_Line,
ERROR_MESSAGE() as Error_message
End Catch
End;

Exec AddEmployeeWithTryCatch null,50000,'2023-01-09','F+'

Create