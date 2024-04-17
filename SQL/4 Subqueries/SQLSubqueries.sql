--List Products with Inventory Less Than Average:
SELECT ProductID, Name, ProductNumber, SafetyStockLevel, ReorderPoint
FROM Production.Product
WHERE SafetyStockLevel < (
    SELECT AVG(SafetyStockLevel)
    FROM Production.Product
);

--Display Territories with Highest Sales:
SELECT st.TerritoryID, st.Name, TotalSales
FROM Sales.SalesTerritory st
JOIN (
    SELECT TerritoryID, SUM(TotalDue) AS TotalSales
    FROM Sales.SalesOrderHeader
    GROUP BY TerritoryID
) AS SalesByTerritory ON st.TerritoryID = SalesByTerritory.TerritoryID
ORDER BY TotalSales DESC;

--Find Orders with Products Exceeding a Certain Price:
SELECT SalesOrderID, OrderDate, TotalDue
FROM Sales.SalesOrderHeader
WHERE SalesOrderID IN (
    SELECT SalesOrderID
    FROM Sales.SalesOrderDetail
    WHERE UnitPrice > 100
);

--List Orders Placed by Customers with a Specific Territory:
SELECT SalesOrderID, OrderDate
FROM Sales.SalesOrderHeader
WHERE CustomerID IN (
    SELECT CustomerID
    FROM Sales.Customer
    WHERE TerritoryID = (
        SELECT TerritoryID
        FROM Sales.SalesTerritory
        WHERE Name = 'Northwest'
    )
);

--SELECT SalesOrderID, OrderDate
--FROM Sales.SalesOrderHeader sod
--JOIN Sales.Customer c ON sod.CustomerID = c.CustomerID
--JOIN Sales.SalesTerritory st ON sod.TerritoryID = st.TerritoryID
--WHERE st.Name = 'Northwest'

--Retrieve Products with Maximum List Price:
SELECT Name, ListPrice
FROM Production.Product
WHERE ListPrice = (
    SELECT MAX(ListPrice)
    FROM Production.Product
);
--Find Customers with Orders Placed After a Specific Date:
SELECT c.CustomerID, p.FirstName, p.LastName
FROM Sales.Customer c
JOIN Person.Person p ON c.PersonID = p.BusinessEntityID
WHERE c.CustomerID IN (
    SELECT soh.CustomerID
    FROM Sales.SalesOrderHeader soh
    WHERE soh.OrderDate > '2011-01-01'
);


--List Products Sold in Multiple Sales Orders:
SELECT Name, ProductNumber
FROM Production.Product
WHERE ProductID IN (
    SELECT ProductID
    FROM Sales.SalesOrderDetail
    GROUP BY ProductID
    HAVING COUNT(DISTINCT SalesOrderID) > 1
);
--Customers who have not placed any orders
SELECT c.CustomerID, p.FirstName, p.LastName
FROM Sales.Customer c
JOIN Person.Person p ON c.PersonID = p.BusinessEntityID
WHERE c.CustomerID NOT IN (
    SELECT DISTINCT soh.CustomerID
    FROM Sales.SalesOrderHeader soh
);
