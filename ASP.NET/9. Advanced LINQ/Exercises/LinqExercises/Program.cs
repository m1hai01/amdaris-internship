// Class representing a single order item
public class OrderItem
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

// Class representing a single order
public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal TotalAmount => Items.Sum(item => item.Quantity * item.Price);
    public int CustomerId { get; set; }
}

// Class representing a customer
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Order> Orders { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        // Sample usage of classes
        var customer1 = new Customer { Id = 1, Name = "John Doe", Email = "john@example.com", Orders = new List<Order>() };
        var customer2 = new Customer { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Orders = new List<Order>() };
        var customer3 = new Customer { Id = 3, Name = "Alice Johnson", Email = "alice@example.com", Orders = new List<Order>() };
        var customer4 = new Customer { Id = 4, Name = "Bob Williams", Email = "bob@example.com", Orders = new List<Order>() };

        var order1 = new Order
        {
            Id = 1,
            OrderDate = DateTime.Parse("2024-03-22"),
            Items = new List<OrderItem>
            {
                new OrderItem { Id = 1, ProductName = "Cola", Quantity = 2, Price = 10 },
                new OrderItem { Id = 2, ProductName = "Corona", Quantity = 1, Price = 20 }
            },
            CustomerId = 1
        };

        var order2 = new Order
        {
            Id = 2,
            OrderDate = DateTime.Parse("2024-03-23"),
            Items = new List<OrderItem>
            {
                new OrderItem { Id = 3, ProductName = "Baban", Quantity = 3, Price = 15 },
                new OrderItem { Id = 4, ProductName = "Cola", Quantity = 2, Price = 10 }
            },
            CustomerId = 2
        };

        var order3 = new Order
        {
            Id = 3,
            OrderDate = DateTime.Parse("2024-03-24"),
            Items = new List<OrderItem>
            {
                new OrderItem { Id = 5, ProductName = "RedBull", Quantity = 2, Price = 25 },
                new OrderItem { Id = 6, ProductName = "Cricova", Quantity = 3, Price = 30 }
            },
            CustomerId = 3
        };

        var order4 = new Order
        {
            Id = 4,
            OrderDate = DateTime.Parse("2024-03-25"),
            Items = new List<OrderItem>
            {
                new OrderItem { Id = 7, ProductName = "Calarasi", Quantity = 1, Price = 40 },
                new OrderItem { Id = 8, ProductName = "Om", Quantity = 4, Price = 20 }
            },
            CustomerId = 4
        };

        customer1.Orders.Add(order1);
        customer2.Orders.Add(order2);
        customer3.Orders.Add(order3);
        customer4.Orders.Add(order4);
        customer1.Orders.Add(order2);

        //all customers who have place an order
        var customersWithOrders = new List<Customer> { customer1, customer2, customer3, customer4 }
                                    .Where(customer => customer.Orders.Any());

        foreach (var customer in customersWithOrders)
        {
            Console.WriteLine($"Customer {customer.Name} has placed an order.");
        }

        // all orders along with their customer details
        var ordersWithCustomerDetails = from customer in new List<Customer> { customer1, customer2, customer3, customer4 }
                                        from order in customer.Orders
                                        select new
                                        {
                                            Order = order,
                                            Customer = customer
                                        };

        // Display the orders along with their associated customer details
        foreach (var orderWithCustomer in ordersWithCustomerDetails)
        {
            Console.WriteLine($"Order ID: {orderWithCustomer.Order.Id}, " +
                              $"Order Date: {orderWithCustomer.Order.OrderDate}, " +
                              $"Customer Name: {orderWithCustomer.Customer.Name}, " +
                              $"Customer Email: {orderWithCustomer.Customer.Email}");
        }

        //total quantity of each product
        var quantityProduct = from customer in new List<Customer> { customer1, customer2, customer3, customer4 }
                              from order in customer.Orders
                              from item in order.Items
                              group item by item.ProductName into productGroup
                              select new
                              {
                                  Product = productGroup.Key,
                                  TotalQuantity = productGroup.Sum(item => item.Quantity)
                              };

        foreach (var product in quantityProduct)
        {
            Console.WriteLine($"Product name: {product.Product} and its quantity: {product.TotalQuantity}");
        }

        //customers who have placed an order after a certain date
        DateTime targetDate = DateTime.Parse("2024-03-23");
        var dateOrder = from customer in new List<Customer> { customer1, customer2, customer3, customer4 }
                        from order in customer.Orders
                        where customer.Orders.Any(order => order.OrderDate > targetDate)
                        select customer;

        foreach (var customer in dateOrder)
        {
            Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.Name} place order after {targetDate}");
        }

        var nameToSearch = "John Doe";
        //Retrieve orders placed by a specific customer sorted by order date.
        var specificCustomer = from customer in new List<Customer> { customer1, customer2, customer3, customer4 }
                               where customer.Name == nameToSearch
                               from order in customer.Orders
                               orderby order.OrderDate
                               select order;

        foreach (var order in specificCustomer)
        {
            Console.WriteLine($"Order ID: {order.Id}, Order Date: {order.OrderDate}");
            foreach (var item in order.Items)
            {
                Console.WriteLine($" - Product: {item.ProductName}, Quantity: {item.Quantity}, Price: {item.Price}");
            }
        }

        //Retrieve all orders with their associated customer details sorted by the total order amount

        //Calculate the total revenue generated from all orders.
        var totalRevenue = (from customer in new List<Customer> { customer1, customer2, customer3, customer4 }
                            from order in customer.Orders
                            select order.TotalAmount).Sum();

        Console.WriteLine($"Total Revenue: {totalRevenue}");

        //Find the customer who has placed the most orders.
        var mostOrders = new List<Customer> { customer1, customer2, customer3, customer4 }
                         .Select(customer => new { Customer = customer, OrderCount = customer.Orders.Count })
                         .OrderByDescending(x => x.OrderCount)
                         .Select(x => x.Customer)
                         .FirstOrDefault();

        if (mostOrders != null)
        {
            Console.WriteLine($"Customer with the most orders:");
            Console.WriteLine($"ID: {mostOrders.Id}, Name: {mostOrders.Name}");
        }
        else
        {
            Console.WriteLine("No customers found.");
        }

        //Group orders by customer and find the average order amount for each customer.

        //Join orders with their respective customers. trebuie liste diferite si cu idiuri de legatura
        var ordersWithCustomers = from customer in new List<Customer> { customer1, customer2, customer3, customer4 }
                                  from order in customer.Orders
                                  where customer.Id == order.Id
                                  select new
                                  {
                                      Order = order,
                                      Customer = customer
                                  };

        foreach (var orderWithCustomer in ordersWithCustomers)
        {
            Console.WriteLine($"Order ID: {orderWithCustomer.Order.Id}, " +
                              $"Order Date: {orderWithCustomer.Order.OrderDate}, " +
                              $"Customer Name: {orderWithCustomer.Customer.Name}, " +
                              $"Customer Email: {orderWithCustomer.Customer.Email}");
        }

        //Join orders with their order items.
        var ordersWithOrderItems = from customer in new List<Customer> { customer1, customer2, customer3, customer4 }
                                   from order in customer.Orders
                                   from item in order.Items
                                   where order.Id == item.Id
                                   select new
                                   {
                                       Order = order,
                                       OrderItem = item
                                   };

        foreach (var orderWithItem in ordersWithOrderItems)
        {
            Console.WriteLine($"Order ID: {orderWithItem.Order.Id}, " +
                              $"Order Date: {orderWithItem.Order.OrderDate}, " +
                              $"Item ID: {orderWithItem.OrderItem.Id}, " +
                              $"Product Name: {orderWithItem.OrderItem.ProductName}, " +
                              $"Quantity: {orderWithItem.OrderItem.Quantity}, " +
                              $"Price: {orderWithItem.OrderItem.Price}");
        }

        //Find customers who have ordered a specific product.
        string productNameToSearch = "Om"; // Example product name to search

        var customersWithSpecificProduct = from customer in new List<Customer> { customer1, customer2, customer3, customer4 }
                                           where customer.Orders.Any(order => order.Items.Any(item => item.ProductName == productNameToSearch))
                                           select customer;

        foreach (var customer in customersWithSpecificProduct)
        {
            Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}");
        }
    }
}