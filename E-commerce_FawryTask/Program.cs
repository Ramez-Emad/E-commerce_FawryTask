using E_commerce_FawryTask.Exceptions;
using E_commerce_FawryTask.Models.Customers;
using E_commerce_FawryTask.Models.Products;
using E_commerce_FawryTask.Services;
using System.ComponentModel.DataAnnotations;

try
{
    var customer = new Customer("Ahmed", 10000);

    var cheese = new Cheese("Cheese", 100, 5, false, 200);
    var biscuits = new Biscuits("Biscuits", 150, 3, false, 700);
    var tv = new TV("TV", 300, 5, 154);
    var scratchCard = new MobileScratchCard("Scratch Card", 50, 10);

    var cart = customer.Cart;
    cart.Add(cheese, 2);
    cart.Add(biscuits, 1);
    cart.Add(scratchCard, quantity: 1);
    var checkoutService = new CheckoutService();
    checkoutService.Checkout(customer);
}
catch (OutOfStockException ex)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Stock issue: {ex.Message}");
}
catch (InsufficientBalanceException ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Payment failed: {ex.Message}");
}
catch (ExpiredProductException ex)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine($"Expired product: {ex.Message}");
}
catch (CartEmptyException ex)
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine($"Cart is empty: {ex.Message}");
}
catch (ArgumentException ex)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine($"Invalid argument: {ex.Message}");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
finally
{
    Console.ResetColor();
}