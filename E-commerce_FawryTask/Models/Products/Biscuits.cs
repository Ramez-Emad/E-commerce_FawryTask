using E_commerce_FawryTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Models.Products;
public class Biscuits
    : Product, IExpirable, IShippable
{
    private readonly bool _expired ;
    private readonly double _weight;

    public Biscuits(string name, double price, int quantity, bool expired, double weight) : base(name, price, quantity)
    {
        if (weight <= 0)
            throw new ArgumentException("Weight must be greater than 0.");

        _expired = expired;
        _weight = weight;
    }

    public bool IsExpired() => _expired;
    public double GetWeight() => _weight;
    public string GetName() => Name;
}
