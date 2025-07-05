using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Exceptions;
public class ExpiredProductException : Exception
{
    public ExpiredProductException(string productName)
        : base($"Product '{productName}' is expired and cannot be purchased.") { }
}