using System;

// Product: Represents the coffee beverage
internal class Coffee
{
    public string Description { get; set; }
}

// Builder: Abstract builder for constructing coffee
internal interface ICoffeeBuilder
{
    void SetBaseCoffee();

    void AddMilk(string type);

    void AddSugar();

    Coffee GetCoffee();
}

// Concrete builder for Espresso
internal class EspressoBuilder : ICoffeeBuilder
{
    private Coffee _coffee;

    public EspressoBuilder()
    {
        _coffee = new Coffee();
    }

    public void SetBaseCoffee()
    {
        _coffee.Description = "Espresso";
    }

    public void AddMilk(string type)
    {
        // Espresso doesn't contain milk
    }

    public void AddSugar()
    {
        // Espresso doesn't contain sugar
    }

    public Coffee GetCoffee()
    {
        return _coffee;
    }
}

// Concrete builder for Cappuccino
internal class CappuccinoBuilder : ICoffeeBuilder
{
    private Coffee _coffee;

    public CappuccinoBuilder()
    {
        _coffee = new Coffee();
    }

    public void SetBaseCoffee()
    {
        _coffee.Description = "Cappuccino";
    }

    public void AddMilk(string type)
    {
        _coffee.Description += " + " + type + " milk";
    }

    public void AddSugar()
    {
        _coffee.Description += " + Sugar";
    }

    public Coffee GetCoffee()
    {
        return _coffee;
    }
}

// Concrete builder for Flat White
internal class FlatWhiteBuilder : ICoffeeBuilder
{
    private Coffee _coffee;

    public FlatWhiteBuilder()
    {
        _coffee = new Coffee();
    }

    public void SetBaseCoffee()
    {
        _coffee.Description = "Flat white";
    }

    public void AddMilk(string type)
    {
        _coffee.Description += " + " + type + " milk";
    }

    public void AddSugar()
    {
        _coffee.Description += " + Sugar";
    }

    public Coffee GetCoffee()
    {
        return _coffee;
    }
}

// Director: Constructs coffee beverages using builders
internal class CoffeeShop
{
    public Coffee MakeCoffee(ICoffeeBuilder builder, string milkType, bool addSugar)
    {
        builder.SetBaseCoffee();
        if (milkType != null)
        {
            builder.AddMilk(milkType);
        }
        if (addSugar)
        {
            builder.AddSugar();
        }
        return builder.GetCoffee();
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        CoffeeShop coffeeShop = new CoffeeShop();

        // Making a Cappuccino with Soy milk and Sugar
        var cappuccinoBuilder = new CappuccinoBuilder();
        var cappuccino = coffeeShop.MakeCoffee(cappuccinoBuilder, "Soy", true);
        Console.WriteLine("Cappuccino: " + cappuccino.Description);

        // Making an Espresso without milk but with Sugar
        var espressoBuilder = new EspressoBuilder();
        var espresso = coffeeShop.MakeCoffee(espressoBuilder, null, true); // Passing null for milk type
        Console.WriteLine("Espresso: " + espresso.Description);

        // Making a Flat White with Regular milk and Sugar
        var flatWhiteBuilder = new FlatWhiteBuilder();
        var flatWhite = coffeeShop.MakeCoffee(flatWhiteBuilder, "Regular", true);
        Console.WriteLine("Flat White: " + flatWhite.Description);
    }
}