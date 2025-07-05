using E_commerce_FawryTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Models.Products;

public class TV : Product, IShippable
{
    private readonly double _weight;

    public TV(string name, double price, int quantity , double weight) : base(name, price, quantity)
    {
        if (weight <= 0)
            throw new ArgumentException("Weight must be greater than 0.");

        _weight = weight;
    }
    public double GetWeight() => _weight;
    public string GetName() => Name;
}
