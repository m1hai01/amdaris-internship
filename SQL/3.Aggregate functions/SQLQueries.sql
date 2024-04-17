--Total Sales by Product Category:
SELECT pc.Name AS Category, SUM(soh.TotalDue) AS TotalSales
FROM Sales.SalesOrderHeader soh
JOIN Sales.SalesOrderDetail sod ON soh.SalesOrderID = sod.SalesOrderID
JOIN Production.Product p ON sod.ProductID = p.ProductID
JOIN Production.ProductSubcategory psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
JOIN Production.ProductCategory pc ON psc.ProductCategoryID = pc.ProductCategoryID
GROUP BY pc.Name
ORDER BY TotalSales DESC;

--Top 5 customers based on their total purchase amount:
SELECT TOP 5 c.CustomerID, p.FirstName + ' ' + p.LastName AS CustomerName, c.AccountNumber, SUM(soh.TotalDue) AS TotalSales
FROM Sales.Customer c
JOIN Sales.SalesOrderHeader soh ON c.CustomerID = soh.CustomerID
JOIN Person.Person p ON c.PersonID = p.BusinessEntityID
GROUP BY c.CustomerID, p.FirstName, p.LastName, c.AccountNumber
ORDER BY TotalSales DESC;

--Monthly Sales Trend
SELECT YEAR(OrderDate) AS OrderYear, MONTH(OrderDate) AS OrderMonth, SUM(TotalDue) AS MonthlySales
FROM Sales.SalesOrderHeader
GROUP BY YEAR(OrderDate), MONTH(OrderDate)
ORDER BY OrderYear, OrderMonth;

--Average Sales Amount per Order
SELECT AVG(TotalDue) AS AvgSalesPerOrder
FROM Sales.SalesOrderHeader;

--Sales by Territory:
SELECT st.Name AS Territory, SUM(soh.TotalDue) AS TotalSales
FROM Sales.SalesOrderHeader soh
JOIN Sales.SalesTerritory st ON soh.TerritoryID = st.TerritoryID
GROUP BY st.Name
ORDER BY TotalSales DESC;

--Sales by Product and Year:
SELECT p.Name AS ProductName, YEAR(soh.OrderDate) AS OrderYear, SUM(sod.LineTotal) AS TotalSales
FROM Sales.SalesOrderDetail sod
JOIN Production.Product p ON sod.ProductID = p.ProductID
JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID
GROUP BY p.Name, YEAR(soh.OrderDate)
ORDER BY ProductName, OrderYear;

--Find the average order quantity for each product color:
SELECT p.Color AS ProductColor, AVG(sod.OrderQty) AS AvgOrderQuantity
FROM Production.Product p
JOIN Sales.SalesOrderDetail sod ON p.ProductID = sod.ProductID
GROUP BY p.Color;

--Find the number of products sold in each subcategory along with their average list price:
SELECT psc.Name AS Subcategory, COUNT(*) AS NumberOfProducts, AVG(p.ListPrice) AS AvgListPrice
FROM Production.Product p
JOIN Production.ProductSubcategory psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
GROUP BY psc.Name;

SELECT p.ProductID
FROM Production.Product p
LEFT JOIN Sales.SalesOrderDetail sod on p.ProductID = sod.ProductID
WHERE sod.ProductID = NULL;