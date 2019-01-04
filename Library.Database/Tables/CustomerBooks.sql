CREATE TABLE [dbo].[CustomerBooks]
(
	[CustomerBooksId] INT NOT NULL IDENTITY PRIMARY KEY,
	[CustomerID] INT,
	[BookID] INT, 
    CONSTRAINT [FK_CustomerBooks_Customers] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]), 
    CONSTRAINT [FK_CustomerBooks_Books] FOREIGN KEY ([BookID]) REFERENCES [Books]([BookID])
)
