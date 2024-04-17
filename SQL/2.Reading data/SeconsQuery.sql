SELECT
Person.Person.FirstName, Person.Person.LastName, Person.Person.BusinessEntityID,Person.PersonPhone.PhoneNumber
FROM Person.Person
JOIN
Person.PersonPhone on Person.BusinessEntityID = PersonPhone.BusinessEntityID
WHERE
Person.LastName LIKE 'L%'
ORDER BY
Person.LastName ASC,
Person.FirstName ASC;
