CREATE TABLE ShoppingCart(
	productID INTEGER,
	productAmount INTEGER NOT NULL,
	FOREIGN KEY(productID) REFERENCES Product(productID)
)