// See https://aka.ms/new-console-template for more information
using DelegatesLinq;
using System.Linq;

class Program
{
    delegate int Transformer(int Item);


    static void Main(string[] args)
    {

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        var odds = numbers.Where(x => x % 2 != 0);
        var squares = numbers.Select(x => x * x);
        Console.WriteLine("Odd numbers:");
        foreach (var odd in odds)
        {
            Console.WriteLine(odd);
        }

        Console.WriteLine("Squared numbers:");
        foreach (var num in squares)
        {
            Console.WriteLine(num);
        }

        //define delegate
        //Transformer doubleTransformer = DoubleNumber;

        //use anonymous methods
        Transformer doubleTransformer = delegate (int x)
        {
            return x * 2;
        };

        //use lambda
        Transformer doubleTransformer1 = (int x) =>  x * 2; 

        //double each number in the collection
        TransformerCollection(numbers, doubleTransformer1);

        //print
        Console.WriteLine("DOubled numbers:");
        foreach (var item in numbers)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();

        //extension method
        string s = "hello world";
        char c = 'l';
        int i = s.CharCount(c);
        Console.WriteLine(i);
    }

    //transform each item in collection
    static void TransformerCollection(List<int> collection, Transformer transformer)
    {
        var selector = (int i) => i + 1;

        var value = collection.Select(selector).ToList();
        for (int i = 0; i < collection.Count; i++)
        {
            collection[i] = transformer(collection[i]);
        }
    }

    static int DoubleNumber(int number)
    {
        return number * 2;
    }

    
 




}
