
/*

DROP TABLE BE.Customer;
DROP TABLE BE.Store;
DROP TABLE BE.Orders;
DROP TABLE BE.Product;

DROP SCHEMA BE;

*/


CREATE SCHEMA BE;
GO


CREATE TABLE BE.Customer 
(
	custID INT NOT NULL PRIMARY KEY,
	fullName NVARCHAR(150) NOT NULL DEFAULT 'insertname',
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
	orderID INT NOT NULL PRIMARY KEY,
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


INSERT INTO BE.Customer(custID, fullName, custPassword) VALUES
	(0, 'Jebediah Georgeson', 'lemonfresh'),
	(1, 'Sara Georgedaughter', 'hatemylastname')


INSERT INTO BE.Store(storeID, storeLocation) VALUES
	(0, 'Northerville'),
	(1, 'Westerville'),
	(2, 'Southerville'),
	(3, 'Easterville')

INSERT INTO BE.Product(productID, productName, price) VALUES
	(0, 'Apple', 1.00),
	(1, 'Orange', 1.50)


-- skipping productname
INSERT INTO BE.Orders(orderID, customerId, storeId, productId, itemName, productQuantity, orderPurchaseDate) VALUES
	(0, 0, 1, 0, 'Apple', 3, SYSDATETIMEOFFSET() ),
	(1, 1, 3, 1, 'Orange', 2, SYSDATETIMEOFFSET() )



/*

SELECT * FROM BE.Customer
SELECT * FROM BE.Store
SELECT * FROM BE.Product
SELECT * FROM BE.Orders

*/