--- Scalar Valued Function
create function EastOrWest
(@direction decimal
)
returns char(4) as
Begin
Declare @return char(4);
set @return = 'same';
if(@direction>0.00) set @return ='east';
if (@direction<0.00) set @return = 'west';
return @return
end;

Select dbo.EastOrWest(1);

create function GrossFunction(@Id int)
returns Money
as
begin
Declare @BasicPay Money, @HRA Money,@DA Money,@PF Money,@Gross Money
Select @BasicPay = Salary from Employee_Payroll where Id = @Id
Set @HRA = @BasicPay*0.1
Set @DA = @BasicPay*0.2
Set @PF = @BasicPay*0.1
Set @Gross = @BasicPay+@DA+@PF+@HRA
Return @Gross
end;

Select dbo.GrossFunction(3);

--- Table Valued Functions

Create Function GetEmployeeByID(@Id int)
returns table
as
return (Select * from Employee_Payroll where Id=@Id);

Select * from GetEmployeeByID(3);