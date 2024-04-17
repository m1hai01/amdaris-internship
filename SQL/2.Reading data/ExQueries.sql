-- ex1
SELECT FirstName, LastName, BusinessEntityID AS Employee_id FROM Person.Person
ORDER BY LastName ASC;
-- ex2
SELECT
Person.Person.FirstName, Person.Person.LastName, Person.Person.BusinessEntityID,Person.PersonPhone.PhoneNumber
FROM Person.Person
JOIN
Person.PersonPhone on Person.BusinessEntityID = PersonPhone.BusinessEntityID
WHERE
Person.LastName LIKE 'L%'
ORDER BY
Person.LastName ASC,
Person.FirstName ASC;
--ex3
-- This SQL query retrieves salespersons who belong to a territory,
-- have non-zero SalesYTD, and then ranks them based on their SalesYTD
-- within each PostalCode group.
SELECT 
-- This function assigns a unique sequential integer to each row 
-- within a partition of a result set defined by the PARTITION BY clause.
    ROW_NUMBER() OVER(PARTITION BY P.PostalCode ORDER BY S.SalesYTD DESC) AS RowNumber,
    PP.LastName,
    S.SalesYTD,
    P.PostalCode
FROM 
    Sales.SalesPerson AS S
JOIN 
    Sales.SalesTerritory AS T ON S.TerritoryID = T.TerritoryID
JOIN 
    Person.Address AS P ON S.BusinessEntityID = P.AddressID
JOIN 
    Person.Person AS PP ON S.BusinessEntityID = PP.BusinessEntityID
WHERE 
    T.TerritoryID IS NOT NULL
    AND S.SalesYTD != 0
ORDER BY 
    P.PostalCode ASC,
    S.SalesYTD DESC;
-- ex4
-- Retrieve the total cost of each sales order ID that exceeds
-- 100,000 from the Sales.SalesOrderDetail table
SELECT 
    SalesOrderID, 
    SUM(LineTotal) AS TotalCost
FROM 
    Sales.SalesOrderDetail
GROUP BY 
    SalesOrderID
HAVING 
    SUM(LineTotal) > 100000;
