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


CREATE  PROC uspGetProductList(
    @model_year SMALLINT
) AS 
BEGIN
    DECLARE @product_list VARCHAR(MAX);

    SET @product_list = '';

    SELECT
        @product_list = @product_list + product_name 
                        + CHAR(10)
    FROM 
        production.products
    WHERE
        model_year = @model_year
    ORDER BY 
        product_name;

    PRINT @product_list;
END;

Exec uspGetProductList '2018';