--Update Product Prices and Sales Orders:
BEGIN TRANSACTION;

-- Update product prices
UPDATE Production.Product
SET ListPrice = ListPrice * 1.1
WHERE Color = 'Red';

-- Update sales orders with affected products
UPDATE Sales.SalesOrderDetail
SET UnitPrice = UnitPrice * 1.1
WHERE ProductID IN (
    SELECT ProductID
    FROM Production.Product
    WHERE Color = 'Red'
);

COMMIT TRANSACTION;
