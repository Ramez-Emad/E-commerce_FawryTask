using E_commerce_FawryTask.Exceptions;
using E_commerce_FawryTask.Interfaces;
using E_commerce_FawryTask.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Models.Carts;
public class Cart
{
    private readonly List<CartItem> _items = [];

    public void Add(Product product, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be more than 0");

        if (product is IExpirable expirable && expirable.IsExpired())
            throw new ExpiredProductException(product.Name);

        if (quantity > product.Quantity)
            throw new OutOfStockException(product.Name, quantity , product.Quantity);

        _items.Add(new CartItem(product, quantity));
    }

    public List<CartItem> GetItems() => _items;
    public bool IsEmpty() => _items.Count == 0;
}
