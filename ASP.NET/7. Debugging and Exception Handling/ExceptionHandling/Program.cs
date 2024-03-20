

using ExceptionHandling;

public class InvalidArgumentException : Exception
{
    public InvalidArgumentException() : base() { }

    public InvalidArgumentException(string message) : base(message) { }

    public InvalidArgumentException(string message, Exception innerException) : base(message, innerException) { }

}

public class CustomException : Exception
{
    public CustomException() : base() { }

    public CustomException(string message) : base(message) { }

    public CustomException(string message, Exception innerException) : base(message, innerException) { }


}

public class Example
{
    public void CheckArguments(int arg)
    {
        if (arg <= 0)
        {
            throw new InvalidArgumentException("Argument must be greather than 0");
        }
    }

    public void RethrowExample()
    {
        try
        {
            //some operation
            throw new CustomException("Error during operation");
        }
        catch (CustomException ex)
        {
            Console.WriteLine($"Custom Exception: {ex.Message}");
            throw;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Example example = new Example();
        ConditionalExample example1 = new ConditionalExample();
        example1.Test();

        int x = 5;
        int y = 0;

        int[] numbers = { 1, 2, 3 };
        int index = 4;
        try
        {
            //example.CheckArguments(-5);

            int z = x / y;

            Console.WriteLine($"Result: {y}");

            int value = numbers[index];
            Console.WriteLine($"Value at index {index}: {value}");
        }
        catch (InvalidArgumentException ex)
        {
            Console.WriteLine($"Caught InvalidArgumentException: {ex.Message}");
        }
        catch (DivideByZeroException) when (y == 0)
        {
            Console.WriteLine("Y must not be equal to zero!");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Index is out of range!");
        }
        catch (Exception)
        {
            Console.WriteLine("An exception occurred!");
        }
        finally
        {
            Console.WriteLine("Finally block");
        }


        // rethrow
        try
        {
            example.RethrowExample();
        }
        catch (CustomException ex)
        {
            Console.WriteLine($"Caught CustomException outside: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Finally block executed after rethrow.");
        }

        Console.ReadLine();
    }
}