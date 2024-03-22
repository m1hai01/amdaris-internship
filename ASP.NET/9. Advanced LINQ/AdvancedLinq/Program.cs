using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Person[] drivers =
        {
            new Person("Mihai", "Audi", 100), new Person("Ion", "Bmw",1234),
            new Person("Andrei", "Porsche",63545), new Person("Viorel", "Dacia",100000),
            new Person("Ana", "Audi",123412), new Person("Sveta", "Bmw",9887),
        };

        //grouping by cass
        Console.WriteLine("GroupBy:");

        var carsGroup = drivers.GroupBy(p => p.Car);

        foreach (var car in carsGroup)
        {
            Console.WriteLine($"{car.Key}: {car.Count()} person(s)");
        }

        Console.WriteLine("Join:");

        Car[] cars =
        {
            new Car("Audi", "Disel"),
            new Car("Bmw", "Gasoline"),
            new Car("Porsche", "Hybrid"),
            new Car("Dacia", "Gas")
        };

        //join base car
        var driversJoin = drivers.Join(cars,
            d => d.Car,
            c => c.Brand,
            (d, c) => new { Name = d.Name, Car = c.Brand, Fuel = c.Fuel });

        foreach (var driver in driversJoin)
        {
            Console.WriteLine($"{driver.Name} - {driver.Car}  ({driver.Fuel})");
        }

        Console.WriteLine("GroupJoin:");

        var driversGJoin = cars.GroupJoin(drivers,
            car => car.Brand,
            d => d.Car,
            (c, driversJoin) => new
            {
                Brand = c.Brand,
                Drivers = driversJoin
            })
            .Select(carDrivers => new
            {
                carDrivers.Brand,
                TotalParcurs = carDrivers.Drivers.Sum(driver => driver.Parcurs),
                Drivers = carDrivers.Drivers
                .Select(driver => new { driver.Name, driver.Parcurs })
                .ToList()
            });

        var driverss = driversGJoin
            .Select(car => car.Drivers)
            .ToList();


        foreach (var car in driversGJoin)
        {
            Console.WriteLine($"{car.Brand}, total parcurs: {car.TotalParcurs}");
            foreach (var driver in car.Drivers)
            {
                Console.WriteLine($"\t{driver.Name}: {driver.Parcurs}");
            }
            Console.WriteLine();
        }


        Console.WriteLine("Zip:");

        var result = drivers.Zip(cars);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.First} - {item.Second}");
        }

        //set operators
        Console.WriteLine("Concat:");
        List<string> name1 = new List<string> { "M", "I", "H", "A", "I" };
        List<string> name2 = new List<string> { "M", "I", "H", "A", "E", "L", "A" };
        var concat = name1.Concat(name2).ToList();

        foreach (var item in concat)
        {
            Console.Write(item);
        }
        Console.WriteLine();

        Console.WriteLine("Intersect:");
        var intersect = name1.Intersect(name2).ToList();

        foreach (var item in intersect)
        {
            Console.Write(item);
        }
        Console.WriteLine();


        Console.WriteLine("Union:");
        var union = name1.Union(name2).ToList();

        foreach (var item in union)
        {
            Console.Write(item);
        }
        Console.WriteLine();


        Console.WriteLine("Except:");
        var except = name2.Except(name1).ToList();

        foreach (var item in except)
        {
            Console.Write(item);
        }
        Console.WriteLine("AsEnumerable:");

        //conversion methods
        var numbers = Enumerable.Range(1, 5);
        //seful when you want to switch between query provider types or force the use of LINQ to Objects
        var enumerableNumbers = numbers.AsEnumerable();

        foreach (var item in enumerableNumbers)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("AsQueryable:");
        //used when you want to build dynamic LINQ queries.
        var queryableNumbers = numbers.AsQueryable();
        foreach (var item in queryableNumbers)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Cast:");


        ArrayList list = new ArrayList { 1, 2, 3, 4, 5 };
        //cast elements of a sequence to a specified type.
        var castedList = list.Cast<int>();

        foreach (var num in castedList)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine("OfType:");


        //filters the elements of a sequence based on a specified type.
        var mixedList = new List<object> { 1, "two", 3, "four", 5 };
        var filteredList = mixedList.OfType<int>().Cast<int>();
        foreach (var item in filteredList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("ToArray:");

        //converts a sequence to an array.
        var numberArray = numbers.ToArray();

        foreach (var num in numberArray)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine("ToList:");

        //to list
        var numberList = numbers.ToList();

        foreach (var num in numberList)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine("Dictionary:");

        //to dictionary
        var fruits = new[] { "apple", "banana", "cherry" };
        var dictionary = fruits.ToDictionary(fruit => fruit[0]);

        foreach (var entry in dictionary)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        Console.WriteLine("Lookup:");

        //Keys(string) represent the grouping criterion, which is either "Even" or "Odd".
        //Values(int) are the numbers in the original sequence that match each grouping criterion.


        var lookup = numbers.ToLookup(n => n % 2 == 0);

        var even = lookup[true].ToList();

        foreach (var group in lookup)
        {
            Console.WriteLine(group.Key);
            foreach (var num in group)
            {
                Console.WriteLine($"    {num}");
            }
        }

        //Aggregation methods
        Console.WriteLine("Count:");

        var count = numbers.Count();
        Console.WriteLine($"There are {count} numbers in collection");

        var minVal = numbers.Min();
        Console.WriteLine($"Min Value is {minVal}");

        var maxValue = numbers.Max();
        Console.WriteLine($"Max Value is {maxValue}");

        var sumVal = numbers.Sum();
        Console.WriteLine($"Sum is {sumVal}");

        var avgVal = numbers.Average();
        Console.WriteLine($"Average is {avgVal}");

        int query = numbers.Aggregate((x, y) => x - y);
        Console.WriteLine(query);

        //quantifiesr methods
        List<string> listNr = new List<string> { "1", "2", "3", "4", "5" };

        Console.WriteLine("Contains");
        var contains = listNr.Contains("2");
        Console.WriteLine(contains);

        Console.WriteLine("Any");
        var any = listNr.Any(x => x == "3");
        Console.WriteLine(any);

        Console.WriteLine("SequenceEqual");
        List<string> listNr1 = new List<string> { "1", "2", "3" };
        var sEqual = listNr.SequenceEqual(listNr1);
        Console.WriteLine(sEqual);

        //element operators
        Console.WriteLine("First");
        var first = listNr.First();
        Console.WriteLine(first);

        Console.WriteLine("Last");
        var last = listNr.Last();
        Console.WriteLine(last);

        //throws an exception if there is more than one match
        List<string> listSingle = new List<string> { "1", "1", "2", "3", "4", "5" };

        Console.WriteLine("Single");
        //var single = listNr.Single();
        //Console.WriteLine(single);

        Console.WriteLine("ElementAt");
        var elementAt = listNr.ElementAt(2);
        Console.WriteLine(elementAt);

        //generation operators

        //empty sequence
        var empty = Enumerable.Empty<string>();

        //creates sequence of repeating elements
        var repeatedArray = Enumerable.Repeat(new[] { 1, 2, 3 }, 3); // Repeat the array {1, 2, 3}, 3 times
        foreach (var arr in repeatedArray)
        {
            Console.WriteLine(string.Join(", ", arr));
        }


        // Create a new collection of anonymous objects with selected properties
        var anonymousDrivers = drivers.Select(p => new { p.Name, p.Car });

        // Print out the anonymous objects
        foreach (var driver in anonymousDrivers)
        {
            Console.WriteLine($"Name: {driver.Name}, Car: {driver.Car}");
        }
    }
}

record class Person(string Name, string Car, int Parcurs);
record class Car(string Brand, string Fuel);

