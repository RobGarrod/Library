CREATE PROCEDURE [dbo].[Select_AllCustomers]

AS
	SELECT 
		C.Id,
		C.Name,
		C.Age
	FROM
		Customer C

