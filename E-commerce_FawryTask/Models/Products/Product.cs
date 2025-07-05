using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Models.Products;
public abstract class Product
{
    public string Name { get; }
    public double Price { get; }
    public int Quantity { get; private set; }

    protected Product(string name, double price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name must not be empty");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than 0");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0");

        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void ReduceQuantity(int amount)
    {
        if (amount <= 0 || amount > Quantity)
            throw new ArgumentException("Invalid reduction amount.");

        Quantity -= amount;
    }
}
