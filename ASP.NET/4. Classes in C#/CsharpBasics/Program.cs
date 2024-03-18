
using CsharpBasics;


Rectangle rectangle = new Rectangle(5, 6);
Console.WriteLine("Area of rectangle: " + rectangle.Area());

Circle circle = new Circle(3);
Console.WriteLine("Area of circle: " + circle.Area());

//is 
if(circle is Shape)
{
    Console.WriteLine("True");
}
else
{
    Console.WriteLine("False");
}

//as
object str1 = 2;
string tesla = str1 as string;
if(str1 is string tesla2)
{
    Console.WriteLine("Tesla2");
}
Console.WriteLine(tesla);

var mihai = new Person("Mihai", new Company("Amdaris"));
var ion = (Person)mihai.Clone();
ion.Name = "Ion";
ion.Work.Name = "Endava";

Console.WriteLine(ion.Name);
Console.WriteLine(ion.Work.Name);


string[] shapes = { "square", "rectangle", "circle", "triangle" };
GeometricalFiguresEnumerator enumerator = new GeometricalFiguresEnumerator(shapes);

Console.WriteLine("Method 1: Using while loop with MoveNext() and Current");
while (enumerator.MoveNext())
{
    string shape = (string)enumerator.Current;
    Console.WriteLine(shape);
}
Console.WriteLine();

enumerator.Reset();


//triangle with 3 sides
Triangle triangle1 = new Triangle(3, 4, 5);
Console.WriteLine("Triangle 1 Area: " + triangle1.Area());

//triangle with base and height
Triangle triangle2 = new Triangle(6, 8);
Console.WriteLine("Triangle 2 Area: " + triangle2.Area());


//named and optional arg

 void PersonInformation(string name,int age, double height, int weight, bool isProgrammer = false)
{
    Console.WriteLine($"My name is {name}, i am {age} old, my height is {height} cm and weight is {weight} kg.");
    if (isProgrammer == true)
    {
        Console.WriteLine("I am programmer");
    }
    else
    {
        Console.WriteLine("I am not programmer");
    }

}

PersonInformation(name: "Mihai", age: 22, height: 1.78, weight: 84, true);
PersonInformation("Ion", 25, 1.81, 81);