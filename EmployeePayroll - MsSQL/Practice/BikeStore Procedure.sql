create procedure ListDataItems
as
begin
Select * from sales.customers order by zip_code;
end;

Exec ListDataItems;

create procedure FindProducts (@zipcode as varchar(5))
as
Begin 
Select * from sales.customers where zip_code = @zipcode
end;

exec FindProducts '10301';