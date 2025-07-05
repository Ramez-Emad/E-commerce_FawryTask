using E_commerce_FawryTask.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Models.Customers;
public class Customer
{
    public string Name { get; } 
    public double Balance { get; private set; }
    public Cart Cart { get; } = new Cart();

    public Customer(string name, double balance)
    {
        if (balance < 0)
            throw new ArgumentException("Balance must be zero or more");

        Name = name;
        Balance = balance;
    }
    public void DeductBalance(double amount)
    {
        Balance -= amount;
    }
}
