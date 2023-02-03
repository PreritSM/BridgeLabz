create table Employee_Payroll_Audit(
ID int Identity,
AuditData text
)

create trigger TriggInsertEmployee
on Employee_Payroll
For Insert
as
Begin
Declare @ID int
Select @ID = Id from inserted
Insert into Employee_Payroll_Audit values('New Employee with Id = '+Cast(@ID as Varchar(10)) + ' is added at'+ Cast(GetDate() as varchar(25)));
end;

Insert into Employee_Payroll (Address,Gender,Name) values ('HomeTown','F','Rishija');

Select * from Employee_Payroll_Audit;
Select * from Employee_Payroll;

create trigger TriggerUpdateEmployee
on Employee_Payroll
for Update
as 
begin
Declare @Id int
select @Id= Id from inserted
insert into Employee_Payroll_Audit values ('New Employee WIth ID=' + CAST(@Id as varchar(10)) + 'is updated at' + CAST(getdate() as varchar));
end; 

update Employee_Payroll set Name = 'bala' where Id=2;