BEGIN TRANSACTION;

-- Promote employee by updating job title
UPDATE HumanResources.Employee
SET JobTitle = 'Senior Sales Representative'
WHERE BusinessEntityID = 280; 

-- Adjust salary for the promoted employee
UPDATE HumanResources.EmployeePayHistory
SET Rate = Rate * 1.08 -- 8% salary increase 
WHERE BusinessEntityID = 280; 


COMMIT TRANSACTION;
