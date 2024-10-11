use [E:\VISUAL STUDIO PROJECTS\WINERY\WINERY\APP_DATA\WINERY.MDF]
create table products(
	product_id INT IDENTITY(1,1) PRIMARY KEY,
	product_name nvarchar(50) NOT NULL,
	product_desc nvarchar(MAX) NOT NULL,
	product_price FLOAT(10) NOT NULL,
	pruduct_capacity INT NOT NULL,
	product_origin nvarchar(50)
)
go

insert into products
values
('Test Wine #1', 'A testing wine number 1', 20.00, 450, 'Russia'),
('Test Wine #2', 'A testing wine number 2', 59.00, 450, 'United States'),
('Test Wine #3', 'A testing wine number 3', 90.00, 500, 'France');

go

select * from products