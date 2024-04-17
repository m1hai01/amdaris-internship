BEGIN TRANSACTION;

-- Adjust product pricing based on market analysis
UPDATE Production.Product
SET ListPrice = ListPrice * 0.95 -- 5% discount
WHERE ProductID IN (
    SELECT ProductID
    FROM Production.Product
    WHERE Color = 'Blue'
);

COMMIT TRANSACTION;
