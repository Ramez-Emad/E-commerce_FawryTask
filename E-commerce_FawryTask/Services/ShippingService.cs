using E_commerce_FawryTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Services;
public class ShippingService
{
    public void Ship(List<IShippable> shippableItems)
    {
        Console.WriteLine("** Shipment notice **");
        double totalWeight = 0;

        var grouped = shippableItems
            .GroupBy(s => s.GetName())
            .ToList();

        foreach (var group in grouped)
        {
            var weight = group.First().GetWeight();
            Console.Write($"{group.Count()}x {group.Key}");
            Console.WriteLine($"\t{weight * group.Count()}g");
            totalWeight += weight * group.Count();
        }

        Console.WriteLine($"Total package weight {totalWeight/1000.0:F1}kg\n\n");
    }
}
