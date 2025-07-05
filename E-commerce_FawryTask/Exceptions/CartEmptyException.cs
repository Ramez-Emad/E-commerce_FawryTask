using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_FawryTask.Exceptions;
public class CartEmptyException : Exception
{
    public CartEmptyException() : base("Cart is Empty") { }
}