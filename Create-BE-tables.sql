
/*



DROP TABLE BE.Inventory;
DROP TABLE BE.Packages;
DROP TABLE BE.Orders;
DROP TABLE BE.Product;
DROP TABLE BE.Customer;
DROP TABLE BE.Store;



DROP SCHEMA BE;


*/


CREATE SCHEMA BE;
GO


CREATE TABLE BE.Customer 
(
	custID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	fullName NVARCHAR(150) NOT NULL UNIQUE DEFAULT 'insertname',
	custPassword NVARCHAR(150) NOT NULL DEFAULT 'livelaughlove',
	--CONSTRAINT PK_Cust_ID PRIMARY KEY (CustID)
);

CREATE TABLE BE.Store 
(
	storeID INT NOT NULL PRIMARY KEY,
	storeLocation NVARCHAR(100) NOT NULL DEFAULT 'Store Location',
	-- product
);

CREATE TABLE BE.Product
(
	productID INT NOT NULL PRIMARY KEY,
	productName NVARCHAR(100) NOT NULL DEFAULT 'Default Product',
	price MONEY NOT NULL DEFAULT 0.00,
);

CREATE TABLE BE.Orders
(
	orderID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	customerId INT NOT NULL,
	storeId INT NOT NULL,
	productId INT NOT NULL,
	itemName NVARCHAR(100) NOT NULL DEFAULT 'Default Product',
	productQuantity INT NOT NULL,
	orderPurchaseDate DATETIMEOFFSET NOT NULL DEFAULT SYSDATETIMEOFFSET(),
	FOREIGN KEY (customerId) REFERENCES BE.Customer(custID) ON DELETE CASCADE, 
	FOREIGN KEY (storeId) REFERENCES BE.Store(storeID) ON DELETE CASCADE,
	FOREIGN KEY (productId) REFERENCES BE.Product(productID) ON DELETE CASCADE,
);

CREATE TABLE BE.Packages
(
	packageID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	customerId INT NOT NULL,
	storeId INT NOT NULL,
	productId INT NOT NULL,
	OrderId INT NOT NULL,
	CONSTRAINT fk_pack_customer FOREIGN KEY (customerId) REFERENCES BE.Customer(custID) ON DELETE CASCADE,
	CONSTRAINT fk_pack_store FOREIGN KEY (storeId) REFERENCES BE.Store(storeID) ON DELETE CASCADE,
	CONSTRAINT fk_pack_product FOREIGN KEY (productId) REFERENCES BE.Product(productID) ON DELETE CASCADE,
	CONSTRAINT fk_pack_orders FOREIGN KEY (orderId) REFERENCES BE.Orders(orderID),                         --ON DELETE CASCADE,
);

CREATE TABLE BE.Inventory
(
	storeId INT NOT NULL,
	productId INT NOT NULL,
	amount INT NOT NULL,
	CONSTRAINT ck_inventory PRIMARY KEY (storeId, productId),
	CONSTRAINT fk_Inv_store FOREIGN KEY (storeId) REFERENCES BE.Store(storeID) ON DELETE CASCADE,
	CONSTRAINT fk_Inv_product FOREIGN KEY (productId) REFERENCES BE.Product(productID) ON DELETE CASCADE,
);
GO


-- trigger delete customer foreign key by cascade

CREATE OR ALTER TRIGGER trig_delete_cascade_customer
ON BE.Customer INSTEAD OF DELETE
AS
BEGIN

	SET NOCOUNT ON
	DELETE FROM BE.Packages WHERE customerId IN (SELECT custID FROM DELETED);
	DELETE FROM BE.Customer WHERE custID IN (SELECT custID FROM DELETED);

END;
GO

/*
-- trigger delete orders foreign key by cascade
CREATE OR ALTER TRIGGER trig_delete_cascade_orders
ON BE.Orders INSTEAD OF DELETE
AS
BEGIN

	SET NOCOUNT ON
	DELETE FROM BE.Packages WHERE orderId IN (SELECT orderID FROM DELETED);
	DELETE FROM BE.Orders WHERE orderID IN (SELECT orderID FROM DELETED);

END;
GO
*/


-- trigger delete store foreign key by cascade
CREATE OR ALTER TRIGGER trig_delete_cascade_store
ON BE.Store INSTEAD OF DELETE
AS
BEGIN

	SET NOCOUNT ON
	DELETE FROM BE.Packages WHERE storeId IN (SELECT storeID FROM DELETED);
	DELETE FROM BE.Inventory WHERE storeId IN (SELECT storeID FROM DELETED);
	DELETE FROM BE.Store WHERE storeID IN (SELECT storeID FROM DELETED);

END;
GO


-- trigger delete product foreign key by cascade
CREATE OR ALTER TRIGGER trig_delete_cascade_product
ON BE.Product INSTEAD OF DELETE
AS
BEGIN

	SET NOCOUNT ON
	DELETE FROM BE.Packages WHERE productId IN (SELECT productID FROM DELETED);
	DELETE FROM BE.Inventory WHERE productId IN (SELECT productID FROM DELETED);
	DELETE FROM BE.Product WHERE productID IN (SELECT productID FROM DELETED);

END;
GO

/*

INSERT INTO BE.Customer(custID, fullName, custPassword) VALUES
	(0, 'Jebediah Georgeson', 'lemonfresh'),
	(1, 'Sara Georgedaughter', 'hatemylastname')

*/

INSERT INTO BE.Store(storeID, storeLocation) VALUES
	(1, 'Northerville'),
	(2, 'Westerville'),
	(3, 'Southerville'),
	(4, 'Easterville');


INSERT INTO BE.Product(productID, productName, price) VALUES
	(1, 'Apple', 0.80),
	(2, 'Orange', 1.00),
	(3, 'Banana', 0.30);

GO

--Inventory Insertions

--Northerville
	INSERT INTO BE.Inventory(storeId, productId, amount) VALUES
		(1, 1, 300),
		(1, 2, 250),
		(1, 3, 500),

--Westerville
		(2, 1, 300),
		(2, 2, 250),
		(2, 3, 500),

--Southerville
		(3, 1, 300),
		(3, 2, 250),
		(3, 3, 500),

--Easterville
		(4, 1, 300),
		(4, 2, 250),
		(4, 3, 500);

GO




/*
-- skipping productname
INSERT INTO BE.Orders(orderID, customerId, storeId, productId, itemName, productQuantity, orderPurchaseDate) VALUES
	(0, 0, 1, 0, 'Apple', 3, SYSDATETIMEOFFSET() ),
	(1, 1, 3, 1, 'Orange', 2, SYSDATETIMEOFFSET() )


*/

/*

SELECT * FROM BE.Customer
SELECT * FROM BE.Store
SELECT * FROM BE.Product
SELECT * FROM BE.Orders
SELECT * FROM BE.Packages
SELECT * FROM BE.Inventory

*/