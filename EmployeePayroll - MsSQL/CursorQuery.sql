Declare @Id int
Declare @Name varchar(50)
Declare @Salary float
Declare @Gender char(1)
Declare @StartDate date

--Declare Emp_Cursor Cursor
--for Select Id,Name,Salary,StartDate,Gender from Employee_Payroll
--open Emp_Cursor
--fetch next from Emp_Cursor into @Id,@Name,@Salary,@StartDate,@Gender
--begin
--Print 'Id: '+ Cast(@Id as varchar(10)) + 'Emp Name: ' +@Name + ' Salary: '+ Cast(@Salary as varchar(10))+
-- ' StartDate: ' + Cast(@StartDate as varchar(20)) + ' Gender: ' + Cast(@Gender as varchar(2));
--fetch next from Emp_Cursor into @Id,@Name,@Salary,@StartDate,@Gender
--end
--close Emp_Cursor
--Deallocate Emp_Cursor

Declare Emp_Cursor Cursor
for Select Id,Name,Salary,StartDate,Gender from Employee_Payroll
open Emp_Cursor
fetch next from Emp_Cursor into @Id,@Name,@Salary,@StartDate,@Gender
while @@FETCH_STATUS=0
Begin	
If @Id%2=0
begin
update Employee_Payroll set Name = 'kira' where Current of Emp_Cursor
end
Print 'Id: '+ Cast(@Id as varchar(10)) + 'Emp Name: ' +@Name + ' Salary: '+ Cast(@Salary as varchar(10))+
 ' StartDate: ' + Cast(@StartDate as varchar(20)) + ' Gender: ' + Cast(@Gender as varchar(2));
fetch next from Emp_Cursor into @Id,@Name,@Salary,@StartDate,@Gender
end
close Emp_Cursor
Deallocate Emp_Cursor
