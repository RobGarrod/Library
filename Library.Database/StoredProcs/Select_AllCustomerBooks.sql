CREATE PROCEDURE [dbo].[Select_AllCustomerBooks]
	@CustomerID AS INT
AS
	SELECT 
		CB.CustomerBooksId,
		CB.CustomerID,
		CB.BookID
	FROM
		CustomerBooks CB
	WHERE 
		CB.CustomerID = @CustomerID

