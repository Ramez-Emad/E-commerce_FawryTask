using E_commerce_FawryTask.Exceptions;
using E_commerce_FawryTask.Interfaces;
using E_commerce_FawryTask.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Services;
public class CheckoutService
{
    private const double ShippingFeePerItem = 10;

    public void Checkout(Customer customer)
    {
        var cart = customer.Cart;

        if (cart.IsEmpty())
            throw new CartEmptyException();

        var items = cart.GetItems();

        double subtotal = 0;
        double shippingFee = 0;

        List<IShippable> shippableItems = [];

        foreach (var item in items)
        {
            var product = item.Product;
            var qty = item.Quantity;

            if (product.Quantity < qty)
                throw new OutOfStockException(product.Name, qty, product.Quantity);

            if (product is IExpirable expirable && expirable.IsExpired())
                throw new ExpiredProductException(product.Name);

            subtotal += product.Price * qty;

            if (product is IShippable)
            {
                shippingFee += ShippingFeePerItem * qty;
                shippableItems.AddRange(Enumerable.Repeat((IShippable)product, qty));
            }
        }

        double totalAmount = subtotal + shippingFee;

        if (customer.Balance < totalAmount)
            throw new InsufficientBalanceException();

        foreach (var item in items)
            item.Product.ReduceQuantity(item.Quantity);

        customer.DeductBalance(totalAmount);

        if (shippableItems.Any())
        {
            new ShippingService().Ship(shippableItems);
        }

        // Receipt
        Console.WriteLine("** Checkout receipt **");
        foreach (var item in items)
            Console.WriteLine($"{item.Quantity}x {item.Product.Name}\t{item.Product.Price}");

        Console.WriteLine("----------------------");
        Console.WriteLine($"Subtotal\t\t{subtotal}");
        Console.WriteLine($"Shipping\t\t{shippingFee}");
        Console.WriteLine($"Amount\t\t\t{totalAmount}");
        Console.WriteLine("----------------------");

    }
}
