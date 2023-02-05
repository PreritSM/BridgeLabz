Select * from sales.customers;

Create Procedure UpdateName
(@id int,
@Name varchar(255))
as 
Begin
Begin try
	Update sales.customers Set first_name =@Name where customer_id =@id;
End try
Begin Catch
Select
ERROR_NUMBER() AS ErrorNumber,
ERROR_LINE() AS ErrorLine,
ERROR_MESSAGE() AS ErrorMessage;
end Catch
end;

Exec UpdateName 26, 'Prerit';

Exec UpdateName '10';

Create Procedure UpdateName29
(@id int,
@Name varchar(255))
as 

Begin try
	Update sales.customers Set first_name =@Name where customer_id =@id;
End try
Begin Catch
Select
ERROR_NUMBER() AS ErrorNumber,
ERROR_LINE() AS ErrorLine,
ERROR_MESSAGE() AS ErrorMessage;
end Catch;

Exec UpdateName29 '5',Prerit;