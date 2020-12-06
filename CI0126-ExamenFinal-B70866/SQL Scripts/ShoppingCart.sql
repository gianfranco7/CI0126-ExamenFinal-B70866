CREATE TABLE ShoppingCart(
	productID INTEGER PRIMARY KEY IDENTITY,
	productAmount INTEGER NOT NULL,
	FOREIGN KEY(productID) REFERENCES Product(productID)
)