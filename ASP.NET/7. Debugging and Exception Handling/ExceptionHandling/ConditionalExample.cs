#define DEBUG
using System;


namespace ExceptionHandling
{
    public class ConditionalExample
    {
        public void Test()
        {
#if DEBUG
            Console.WriteLine("Debug mode");
#endif
        }
    }
}
