BEGIN TRANSACTION;

-- Reduce product prices for old products
UPDATE Production.Product
SET ListPrice = ListPrice * 0.8 -- 20% discount
WHERE ProductID IN (
    SELECT ProductID
    FROM Production.Product
    WHERE SellStartDate < '2011-01-01' -- Products still available for sale
);

COMMIT TRANSACTION;
