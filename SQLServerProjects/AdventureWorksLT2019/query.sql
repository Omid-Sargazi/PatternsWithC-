USE AdventureWorks2019;
GO
SELECT TOP 10 p.FirstName, p.LastName
FROM Person.Person p
JOIN Sales.Customer c ON p.BusinessEntityID = c.PersonID
WHERE p.PersonType IN ('IN', 'SC');
GO


SELECT TOP 5 BusinessEntityID, FirstName, LastName, PersonType
FROM Person.Person WHERE PersonType IN ('IN', 'SC');
GO

SELECT TOP 5 CustomerID, PersonID
FROM Sales.Customer
WHERE PersonID IS NOT NULL;
GO
