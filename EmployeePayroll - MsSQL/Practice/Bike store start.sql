use BikeStores;
Select * from BikeStores.sales.customers;

Select * from sales.order_items;

Select * from sys.tables;

Select Distinct Top 5 
list_price from sales.order_items
order by list_price asc;

SELECT
    product_id,
    product_name,
    category_id,
    model_year,
    list_price
FROM
    production.products
WHERE
    category_id = 1
ORDER BY
    list_price DESC;

SELECT
    c.customer_id,
    first_name,
    last_name,
    order_id
FROM
    sales.customers c
INNER JOIN sales.orders o ON o.customer_id = c.customer_id;

SELECT p.product_name,p.model_year,b.brand_name
FROM
production.products p
INNER JOIN production.brands b on p.brand_id = b.brand_id;

SELECT s.first_name, s.last_name,o.shipped_date
FROM sales.staffs as s
INNER JOIN sales.orders as o on s.store_id = o.store_id;

