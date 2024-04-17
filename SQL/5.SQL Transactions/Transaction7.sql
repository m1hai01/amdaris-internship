BEGIN TRANSACTION;

-- Increase product prices for metal products 
UPDATE Production.Product
SET ListPrice = ListPrice * 1.15 -- 15% increase
WHERE ProductID IN (
    SELECT ProductID
    FROM Production.Product
    WHERE Name LIKE '%Metal%' 
);

COMMIT TRANSACTION;
