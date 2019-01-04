CREATE PROCEDURE [dbo].[Select_AllBooks]

AS
	SELECT 
		B.BookID,
		B.Title,
		B.Author
	FROM
		Books B

