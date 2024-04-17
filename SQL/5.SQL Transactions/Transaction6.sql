BEGIN TRANSACTION;

-- Update product prices for high-demand products
UPDATE Production.Product
SET ListPrice = ListPrice * 1.15 -- 15% price increase
WHERE ProductID IN (
    SELECT ProductID
    FROM Production.Product
    WHERE SafetyStockLevel < 100
);

-- Update sales orders with affected products
UPDATE Sales.SalesOrderDetail
SET UnitPrice = UnitPrice * 1.15
WHERE ProductID IN (
    SELECT ProductID
    FROM Production.Product
    WHERE SafetyStockLevel < 100
);

COMMIT TRANSACTION;
