CREATE TABLE Product(
	productID INTEGER PRIMARY KEY IDENTITY,
	productName NVARCHAR(MAX)  NOT NULL,
	productDescription NVARCHAR(MAX) NOT NULL,
	discountAmount INTEGER NOT NULL,
	price FLOAT NOT NULL,
	discount FLOAT NOT NULL,
	productImage VARBINARY(MAX),
	imageType NVARCHAR(50),
)