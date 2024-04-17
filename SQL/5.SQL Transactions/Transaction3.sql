-- Update Employee Salary and Deduct Taxes:
BEGIN TRANSACTION;

-- Update employee salary with 5% increase
UPDATE HumanResources.EmployeePayHistory
SET Rate = Rate * 1.05 -- 5% salary increase
WHERE RateChangeDate > '2010-01-01'
AND Rate * 1.05 <= 200.00; -- Rate remains within the acceptable upper limit

-- Deduct taxes from the updated salary
-- Keep in mind the range specified by the constraint
UPDATE HumanResources.EmployeePayHistory
SET Rate = CASE 
            WHEN Rate * 0.85 >= 6.50 THEN Rate * 0.85 -- Apply 15% tax deduction 
            ELSE 6.50 -- Set Rate to minimum acceptable value
          END
WHERE RateChangeDate > '2010-01-01';

COMMIT TRANSACTION;
