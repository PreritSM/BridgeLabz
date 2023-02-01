Alter procedure GetEmployee
As
Begin
select * from Employee_Payroll;
End;

Execute GetEmployee;

Create procedure AddEmployee(
@Name varchar(50),
@Salary float,
@StartDate date,
@Gender char(1)
)
As
Begin
Insert into Employee_Payroll(Name,Salary,StartDate,Gender) values (@Name,@Salary,@StartDate,@Gender);
End;

Exec AddEmployee 'Swapna',50000,'2023-01-09','F'

Create Procedure UpdateEmployee
(

@Name varchar(50),
@Salary float,
@StartDate date,
@Gender char(1),
@Id int	
)
AS
Begin
Update Employee_Payroll set Name = @Name,Salary = @Salary,StartDate= @StartDate,Gender = @Gender where Id = @Id;
End;

Exec UpdateEmployee 'UpdatedUser',35000,'2023-01-13','F',2;

