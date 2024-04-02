using StructuralDesignPatterns.Components;
using StructuralDesignPatterns.Decorator;

internal class Program
{
    public static void Main(string[] args)
    {
        // Example usage
        string text = "Hello World.";

        // Applying different formatting options
        ITextFormat bold = new BoldText();
        ITextFormat italic = new ItalicText();
        ITextFormat underline = new UnderlineText();
        ITextFormat redColor = new ColorText("red");

        // Combining multiple formatting options
        ITextFormat combinedFormat = new CombinedFormat(bold, italic, redColor);

        // Applying formatting to text
        string formattedText = combinedFormat.Apply(text);

        // Printing formatted text
        Console.WriteLine(formattedText);
    }
}