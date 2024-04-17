--Transfer Inventory Between Warehouses:
BEGIN TRANSACTION;

-- Update inventory for outgoing warehouse
UPDATE Production.ProductInventory
SET Quantity = Quantity - 50
WHERE ProductID = 747 AND ProductInventory.LocationID = 10 --  for outgoing warehouse;

-- Update inventory for incoming warehouse
UPDATE Production.ProductInventory
SET Quantity = Quantity + 50
WHERE ProductID = 747 AND ProductInventory.LocationID = 20 --  for incoming warehouse;

COMMIT TRANSACTION;
